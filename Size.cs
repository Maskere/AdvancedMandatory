namespace Mandatory;

/// <summary>
/// Represents a simple two-dimensional size or dimension (Width/X and Height/Y).
/// It is used to define spatial extent and provides operator overloading for convenient size manipulation.
/// </summary>
public struct Size{
    /// <summary>
    /// Gets or sets the X component of the size (typically Width).
    /// </summary>
    public int X {get;set;}
    /// <summary>
    /// Gets or sets the Y component of the size (typically Height).
    /// </summary>
    public int Y {get;set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Size"/> struct with the specified dimensions.
    /// </summary>
    /// <param name="x">The X dimension (Width).</param>
    /// <param name="y">The Y dimension (Height).</param>
    public Size(int x, int y){
        X = x;
        Y = y;
    }

    /// <summary>
    /// Overloads the addition operator (+) to combine two sizes.
    /// </summary>
    /// <param name="currentSize">The base size.</param>
    /// <param name="newSize">The size to add.</param>
    /// <returns>A new <see cref="Size"/> representing the sum of the two dimensions.</returns>
    public static Size operator +(Size currentSize, Size newSize){
        return new Size(currentSize.X + newSize.X,currentSize.Y + newSize.Y);
    }

    /// <summary>
    /// Overloads the subtraction operator (-) to calculate the difference between two sizes.
    /// </summary>
    /// <param name="currentSize">The base size.</param>
    /// <param name="newSize">The size to subtract.</param>
    /// <returns>A new <see cref="Size"/> representing the difference in dimensions.</returns>
    public static Size operator -(Size currentSize, Size newSize){
        return new Size(currentSize.X - newSize.X,currentSize.Y - newSize.Y);
    }
}
