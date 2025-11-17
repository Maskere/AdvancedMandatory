namespace Mandatory;

/// <summary>
/// Manages all active game objects within the world.
/// This class is responsible for adding, removing, and tracking the lifecycle of <see cref="IGameObject"/> instances.
/// </summary>
public class WorldEntitiesManager : IWorldManager {
    /// <summary>
    /// Gets the list of all active <see cref="IGameObject"/> instances currently managed by the world.
    /// </summary>
    private List<IGameObject> GameObjects;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorldEntitiesManager"/> class, initializing the list of game objects.
    /// </summary>
    public WorldEntitiesManager() {
        this.GameObjects = new();
    }

    /// <summary>
    /// Adds a new <see cref="IGameObject"/> to the manager's list.
    /// </summary>
    /// <param name="gameObject">The game object to add.</param>
    /// <returns>The game object that was added.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="gameObject"/> is null.</exception>
    public IGameObject AddGameObject(IGameObject gameObject) {
        if (gameObject == null) throw new ArgumentNullException("GameObject is null");
        GameObjects.Add(gameObject);
        return gameObject;
    }

    /// <summary>
    /// Removes a specific <see cref="IGameObject"/> from the manager's list.
    /// </summary>
    /// <param name="gameObject">The game object to remove.</param>
    public void RemoveGameObject(IGameObject gameObject) {
        GameObjects.Remove(gameObject);
        gameObject.Dispose();
    }

    /// <summary>
    /// Removes all managed game objects from the list and calls <see cref="IDisposable.Dispose"/> on each one
    /// to ensure proper cleanup of resources.
    /// </summary>
    public void RemoveAllGameObjects() {
        foreach (IGameObject ob in GameObjects) {
            ob.Dispose();
        }
        GameObjects.Clear();
    }
}
