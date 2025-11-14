# ⚔️ RPG Game Entities

This project was a mandatory assignment.
This repository contains the core component and entity structure for a simple Role-Playing Game (RPG), built using C# and following several fundamental design patterns to ensure flexibility, maintainability, and testability.

---

## Design Patterns Used

The entity architecture is built upon the following patterns:

* **Decorator Pattern:** Used to enhance base items (Armor and Weapons) with additional effects or modifiers without altering their original classes.
    * **Components:** `IArmor`, `IWeapon`, `DefenceItemDecorator`, `OffenceItemDecorator`.
* **Composite Pattern:** Used to treat a collection of individual items (e.g., equipped weapons or armor) as a single component.
    * **Components:** `ArmorCollection`, `WeaponCollection`.
* **Abstract Factory Pattern:** Used to create families of related game objects (Creatures, Armor, Weapons) without specifying their concrete classes.
    * **Components:** `IGameObjectFactory`, `GameObjectFactory`.
* **Dependency Injection (via Constructors):** Used extensively (e.g., in `Creature` and `World`) to ensure services and components depend only on **abstractions (interfaces)**, adhering to the SOLID principles.

---

## Core Components

| Component | Role | Notes |
| :--- | :--- | :--- |
| **`Creature`** | Abstract base for all entities that attack, move, and equip gear. | Depends on `INotifier`, `IDamageCalculator`. |
| **`DefenceItem`** | Abstract base for all defensive items. | Base component for the Decorator hierarchy. |
| **`GameObject`** | Abstract base for all entities in the world. | Implements common traits: `Name`, `Lootable`, `Removeable`. |
| **`World<T>`** | Manages the game's grid and coordinates external services. | Generic class to hold map data (`T`). |
| **`Position`** / **`Size`** | Simple, immutable-by-intent structs for spatial coordinates and dimensions. | Includes operator overloads for vector math. |

---

## Services

* **`IWorldManager` (Implemented by `WorldEntitiesManager`):** Responsible for tracking the lifecycle of all active `IGameObject`s in the scene.
* **`IConfigFileReader`:** Responsible for reading and parsing configuration data (e.g., world dimensions).
