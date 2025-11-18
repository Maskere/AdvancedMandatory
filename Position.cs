namespace MandatoryGameframework;

/// <summary>
/// Represents a simple two-dimensional coordinate (X, Y) in the game world.
/// This struct is immutable-by-intent and provides convenient operator overloading for vector arithmetic.
/// </summary>
public struct Position {
    /// <summary>
    /// Gets or sets the X-coordinate.
    /// </summary>
    public int X {get;set;}
    /// <summary>
    /// Gets or sets the Y-coordinate.
    /// </summary>
    public int Y {get;set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> struct with the specified coordinates.
    /// </summary>
    /// <param name="x">The X-coordinate.</param>
    /// <param name="y">The Y-coordinate.</param>
    public Position(int x, int y){
        X = x;
        Y = y;
    }

    /// <summary>
    /// Overloads the addition operator (+) to combine two positions (vector addition).
    /// </summary>
    /// <param name="currentPos">The starting position.</param>
    /// <param name="newPos">The displacement vector to add.</param>
    /// <returns>A new <see cref="Position"/> representing the sum of the two positions.</returns>
    public static Position operator +(Position currentPos, Position newPos){
        return new Position(currentPos.X + newPos.X,currentPos.Y + newPos.Y);
    }

    /// <summary>
    /// Overloads the subtraction operator (-) to calculate the difference between two positions (vector subtraction).
    /// </summary>
    /// <param name="currentPos">The starting position.</param>
    /// <param name="newPos">The position to subtract.</param>
    /// <returns>A new <see cref="Position"/> representing the difference vector.</returns>
    public static Position operator -(Position currentPos, Position newPos){
        return new Position(currentPos.X - newPos.X,currentPos.Y - newPos.Y);
    }

    public override string ToString() {
        return $"{(X,Y)}";
    }
}
