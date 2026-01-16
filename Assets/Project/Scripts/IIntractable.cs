using UnityEngine;

/// <summary>
/// Interface for all interactable objects in the game.
/// Any object the player can interact with must implement this.
/// </summary>
public interface IIntractable
{
    // Called for simple interactions (e.g., pressing a button)
    void Interact();

    // Called when player uses a held item on this object
    // Returns true if interaction was successful
    bool Interact(Interactor.ObjectType objectType);

    // Returns whether this object can currently be interacted with
    bool CanInteract();

    // Returns the category of interaction (PickUp, ONOFF, etc.)
    Interactor.TypeOfInteractor GetTypeofInteractorObject();

    // Returns the specific identity of this object
    Interactor.ObjectType GetObjectType();

    // Returns the GameObject reference
    GameObject GetGameObject();

    // Called to remove the object from the scene
    void destroy();
}