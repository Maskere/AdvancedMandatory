using System.Xml;
namespace Mandatory;

public class World<T> : IDisposable{
    private Func<World<T>, int ,int ,T> originalCell;

    private int width;
    private int height;
    private T[,] gridArray;

    /// <summary>
    /// Initializes the grid using a function delegate with the width and height provided from a configuration file.
    /// The delegate function is called once for each grid coordinate to create an element of type T.
    /// </summary>
    /// <param name="cell"></param>
    public World(Func<World<T>,int,int,T> cell){
        originalCell = cell;

        LoadConfig(Environment.GetEnvironmentVariable("WORLD_CONFIG_PATH"));

        gridArray = new T[this.width,this.height];

        for(int x = 0; x < gridArray.GetLength(0); x++){
            for(int y = 0; y < gridArray.GetLength(1); y++){
                gridArray[x,y] = cell(this,x,y);
            }
        }
    }

    /// <summary>
    /// Initializes the grid using a function delegate with the provided width and height from the caller.
    /// The delegate function is called once for each grid coordinate to create an element of type T.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="cell"></param>
    public World(int width, int height,Func<World<T>,int,int,T> cell){
        originalCell = cell;

        gridArray = new T[this.width,this.height];

        for(int x = 0; x < gridArray.GetLength(0); x++){
            for(int y = 0; y < gridArray.GetLength(1); y++){
                gridArray[x,y] = cell(this,x,y);
            }
        }
    }

    public int Width{
        get => width;
    }

    public int Height{
        get => height;
    }

    /// <summary>
    /// Gets the object at the gridposition (x,y).
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public T Getvalue(int x,int y){
        return gridArray[x,y];
    }

    /// <summary>
    /// Sets an object at the gridposition (x,y)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="value"></param>
    public void SetValue(int x,int y,T value){
        if(x >= width || x < 0 || y >= height || y < 0){
            throw new InvalidOperationException($"Coordinates {(x,y)} must be within the world bound");
        }
        gridArray[x,y] = value;
    }

    /// <summary>
    /// Removes an object at the gridposition
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void RemoveValue(int x, int y){
        if(gridArray[x,y] != null){
            gridArray[x,y] = default(T)!;
        }
        RevertValue(x,y);
    }

    private void RevertValue(int x, int y){
        gridArray[x,y] = originalCell.Invoke(this,x,y);
    }

   /// <summary>
   /// Tries to get world width and height from a configuration file.
   /// If no configuration throw a FileNotFoundException
   /// </summary>
   /// <param name="confFile"></param>
   /// <exception cref="FileNotFoundException"></exception>
   /// <exception cref="ArgumentException"></exception>
    private void LoadConfig(string? confFile){
        if(confFile == null || !File.Exists(confFile)) throw new FileNotFoundException("Configuration file not found");

        XmlDocument? configDoc = new();
        configDoc.Load(confFile);

        XmlNode? worldWidth = configDoc.DocumentElement?.SelectSingleNode("//WorldWidth");
        XmlNode? worldHeight = configDoc.DocumentElement?.SelectSingleNode("//WorldHeight");

        if(worldWidth != null && worldHeight != null){
            string gridWidthStr = worldWidth.InnerText.Trim();
            if(!int.TryParse(gridWidthStr,out int w)){
                width = w;
            }

            string gridHeightStr = worldHeight.InnerText.Trim();
            if(!int.TryParse(gridHeightStr,out int h)){
                height = h;
            }
        }
        else{
            throw new ArgumentException($"Could not find WorldWidth and WorldHeight from {confFile}"); 
        }
    }

    /// <summary>
    /// Tries to get world width and height from a configuration file.
    /// If no configuration file, use the world width and height provided from the user in the contructor.
    /// </summary>
    /// <param name="confFile"></param>
    /// <param name="ctorWidth"></param>
    /// <param name="ctorHeight"></param>
    private void LoadConfig(string? confFile, int ctorWidth, int ctorHeight){
        if(confFile == null || !File.Exists(confFile)){
            width = ctorWidth;
            height = ctorHeight;
            return;
        }

        LoadConfig(confFile);
    }

    public void Dispose(){
    }
}
