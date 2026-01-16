using UnityEngine;

public interface IIntractable
{
    void Interact();
    bool Interact(Interactor.ObjectType objectType);
    bool CanInteract();
    Interactor.TypeOfInteractor GetTypeofInteractorObject();
    Interactor.ObjectType GetObjectType();
    GameObject GetGameObject();
    void destroy();
}