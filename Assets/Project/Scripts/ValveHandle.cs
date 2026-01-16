using UnityEngine;

/// <summary>
/// Physical valve handle that the player can pick up from the floor.
/// Used to fix the SteamPipe and stop the steam.
/// </summary>
public class ValveHandle : MonoBehaviour, IIntractable
{
    // Returns the identity of this object
    public Interactor.ObjectType GetObjectType()
    {
        return Interactor.ObjectType.ValveHandle; 
    }

    // This is a pickup item
    public Interactor.TypeOfInteractor GetTypeofInteractorObject()
    {
        return Interactor.TypeOfInteractor.ObjectPickUp; 
    }

    // Valve handle can always be picked up
    public bool CanInteract()
    {
        return true;
    }

    // Called when the player picks up this object
    public void destroy()
    {
        Destroy(gameObject);
    }

    public GameObject GetGameObject() 
    { 
        return gameObject; 
    }

    // Not used for pickup objects, but required by interface
    public void Interact() { }
    public bool Interact(Interactor.ObjectType objectType) { return false; }
}