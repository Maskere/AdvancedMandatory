namespace MandatoryGameframework;

/// <summary>
/// Represents a two-dimensional grid structure used to store elements of a specific type <typeparamref name="T"/>.
/// It enforces boundary checks and provides methods for initialization, retrieval, and modification of grid cell values.
/// </summary>
/// <typeparam name="T">The type of object stored in each cell of the grid. Must be a non-nullable reference or value type.</typeparam>
public class Grid<T> : IGrid<T> where T : notnull {
    private T[,] gridArray;
    private Func<int,int, T> originalCell;

    /// <summary>
    /// Gets the width (number of columns) of the grid.
    /// </summary>
    public int Width {get;}
    /// <summary>
    /// Gets the height (number of rows) of the grid.
    /// </summary>
    public int Height {get;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Grid{T}"/> class.
    /// </summary>
    /// <param name="width">The width of the grid (X dimension).</param>
    /// <param name="height">The height of the grid (Y dimension).</param>
    /// <param name="cell">A factory function used to initialize the value of each cell, based on its (x, y) coordinates.</param>
    public Grid(int width, int height, Func<int,int, T> cell){
        this.Width = width;
        this.Height = height;
        this.originalCell = cell;
        this.gridArray = new T[width,height];

        InitializeGrid(cell);
    }

    /// <summary>
    /// Retrieves the value stored at the specified grid coordinates.
    /// </summary>
    /// <param name="x">The X-coordinate (column).</param>
    /// <param name="y">The Y-coordinate (row).</param>
    /// <returns>The value of type <typeparamref name="T"/> at the given coordinates.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the coordinates are outside the grid bounds.</exception>
    public T GetValue(int x,int y){
        if(x >= Width || x < 0 || y >= Height || y < 0) throw new InvalidOperationException($"Coordinates {(x,y)} must be within the world bound");
        return gridArray[x,y];
    }

    /// <summary>
    /// Sets or updates the value at the specified grid coordinates.
    /// </summary>
    /// <param name="x">The X-coordinate (column).</param>
    /// <param name="y">The Y-coordinate (row).</param>
    /// <param name="value">The new value of type <typeparamref name="T"/> to place in the cell.</param>
    /// <exception cref="InvalidOperationException">Thrown if the coordinates are outside the grid bounds.</exception>
    public void SetValue(int x,int y,T value){
        if(x >= Width || x < 0 || y >= Height || y < 0) throw new InvalidOperationException($"Coordinates {(x,y)} must be within the world bound");
        gridArray[x,y] = value;
    }

    /// <summary>
    /// Removes the current value at the specified coordinates by reverting it to its original, initialized state.
    /// </summary>
    /// <param name="x">The X-coordinate (column).</param>
    /// <param name="y">The Y-coordinate (row).</param>
    public void RemoveValue(int x, int y){
        RevertValue(x,y);
    }

    /// <summary>
    /// Reverts the cell value at the specified coordinates back to the initial value provided by the factory function.
    /// </summary>
    /// <param name="x">The X-coordinate.</param>
    /// <param name="y">The Y-coordinate.</param>
    private void RevertValue(int x, int y){
        gridArray[x,y] = originalCell.Invoke(x,y);
    }

    /// <summary>
    /// Initializes all cells of the grid using the provided factory function.
    /// </summary>
    /// <param name="cell">The factory function to generate the initial value for each cell.</param>
    private void InitializeGrid(Func<int,int,T> cell){
        for(int x = 0; x < Width; x++){
            for(int y = 0; y < Height; y++){
                gridArray[x,y] = cell(x,y);
            }
        }
    }
}
