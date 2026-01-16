using UnityEngine;

public class ValveHandle : MonoBehaviour, IIntractable
{

    public Interactor.ObjectType GetObjectType()
    {
        return Interactor.ObjectType.ValveHandle; 
    }

    public Interactor.TypeOfInteractor GetTypeofInteractorObject()
    {
        return Interactor.TypeOfInteractor.ObjectPickUp; 
    }

    public bool CanInteract()
    {
        return true;
    }

    public void destroy()
    {
        Debug.Log("<color=yellow>ACTION: ValveHandle object destroyed from scene.</color>");
        Destroy(gameObject);
    }

    public GameObject GetGameObject() { return gameObject; }
    public void Interact() { }
    public bool Interact(Interactor.ObjectType objectType) { return false; }
}