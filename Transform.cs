namespace Mandatory;

/// <summary>
/// Represents the concrete implementation of <see cref="ITransform"/>.
/// Its sole responsibility is to hold and manage the spatial position of a game object.
/// </summary>
public class Transform :ITransform {
    /// <summary>
    /// Gets or sets the current <see cref="Position"/> of the object in the game world.
    /// Default position is (0, 0).
    /// </summary>
    public Position Position { get;set;} = new(0,0);
}
