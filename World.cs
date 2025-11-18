namespace MandatoryGameframework;

/// <summary>
/// Represents the game world, acting as a container and manager for the game grid and world objects.
/// It wraps an underlying <see cref="IGrid{T}"/> and integrates with world management services.
/// </summary>
/// <typeparam name="T">The type of object stored in each cell of the grid (e.g., a Tile or GameObject).</typeparam>
public class World<T> :IWorld, IDisposable where T : notnull{
    private IConfigFileReader? configFileReader;
    private IWorldManager WorldManager;

    private IGrid<T> grid;

    /// <summary>
    /// Initializes a new instance of the <see cref="World{T}"/> class, reading dimensions from a configuration file.
    /// </summary>
    /// <param name="configFileReader">The service used to read world dimensions and configuration.</param>
    /// <param name="cell">A function used to initialize the value of each new grid cell, taking (x, y) coordinates.</param>
    /// <param name="worldManager">The service responsible for managing game objects within the world.</param>
    public World(IConfigFileReader configFileReader, Func<int,int,T> cell,IWorldManager worldManager){
        configFileReader.GetWorldDimensions(out Size worldDimension);
        this.configFileReader = configFileReader;
        this.WorldManager = worldManager;

        this.grid = new Grid<T>(worldDimension.X,worldDimension.Y,cell);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="World{T}"/> class with explicitly defined dimensions.
    /// </summary>
    /// <param name="width">The width of the game world grid.</param>
    /// <param name="height">The height of the game world grid.</param>
    /// <param name="cell">A function used to initialize the value of each new grid cell, taking (x, y) coordinates.</param>
    /// <param name="worldManager">The service responsible for managing game objects within the world.</param>
    /// <exception cref="ArgumentException">Thrown if the width or height is less than or equal to 0.</exception>
    public World(int width, int height,Func<int,int,T> cell,IWorldManager worldManager){
        if(width <= 0 || height <= 0) throw new ArgumentException("World dimensions must be greater than 0");
        this.WorldManager = worldManager;

        this.grid = new Grid<T>(width,height,cell);
    }

    /// <summary>
    /// Gets the width of the game world grid.
    /// </summary>
    public int Width{
        get => grid.Width;
    }

    /// <summary>
    /// Gets the height of the game world grid.
    /// </summary>
    public int Height{
        get => grid.Height;
    }

    /// <summary>
    /// Retrieves the value (object) at the specified grid coordinates.
    /// </summary>
    /// <param name="x">The X-coordinate (column).</param>
    /// <param name="y">The Y-coordinate (row).</param>
    /// <returns>The value of type T at the given coordinates.</returns>
    public T GetValue(int x, int y){
        return grid.GetValue(x,y);
    }

    /// <summary>
    /// Attempts to set a value at a specified grid position.
    /// </summary>
    /// <remarks>
    /// This method only allows setting a value if the target grid cell is currently empty (null). 
    /// If successful, it optionally updates the position of a world object.
    /// </remarks>
    /// <typeparam name="T">The type of the value being stored in the grid.</typeparam>
    /// <param name="x">The X-coordinate (column index) of the grid cell.</param>
    /// <param name="y">The Y-coordinate (row index) of the grid cell.</param>
    /// <param name="value">The value to be set in the specified grid cell.</param>
    /// <param name="worldObject">An optional object that implements the <see cref="IWorldObject"/> interface.
    /// If provided and the value is successfully set, its <see cref="IWorldObject.Position"/> will be updated to the new (x, y) coordinates.</param>
    /// <exception cref="ArgumentException">Thrown if a value is already present (not null) at the specified (x, y) coordinates.</exception>
    public void SetValue(int x, int y, T value,IWorldObject? worldObject = null){
        grid.SetValue(x,y,value);

        if(worldObject != null){
            worldObject.Position = new Position(x,y);
        }
    }

    /// <summary>
    /// Removes the value (object) at the specified grid coordinates.
    /// </summary>
    /// <param name="x">The X-coordinate (column).</param>
    /// <param name="y">The Y-coordinate (row).</param>
    public void RemoveValue(int x, int y){
        grid.RemoveValue(x,y);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// This implementation instructs the WorldManager to remove all game objects.
    /// </summary>
    public void Dispose(){
        WorldManager.RemoveAllGameObjects();
        GC.SuppressFinalize(this);
    }
}
