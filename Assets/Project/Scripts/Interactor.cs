using UnityEngine;

public class Interactor : MonoBehaviour
{
    public enum TypeOfInteractor{
        None,
        ONOFF,
        ObjectPickUp,
        ValveSocket 
    }
    public enum ObjectType{
        None,
        ValveHandle,
        SteamPipe 
    }

    public float interactDistance = 3f;   
    public LayerMask interactableLayer;  
    private ObjectType currentHeldItem = ObjectType.None;

    private void Update()
    {
       
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactDistance, interactableLayer))
        {
            IIntractable target = hitInfo.collider.GetComponent<IIntractable>();

            if (target != null)
            {
                Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.green);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    PerformInteraction(target);
                }
            }
        }
    }
    void PerformInteraction(IIntractable target)
    {
        TypeOfInteractor type = target.GetTypeofInteractorObject();

        if (type == TypeOfInteractor.ObjectPickUp)
        {
            
            currentHeldItem = target.GetObjectType(); 
            Debug.Log("Picked up: " + currentHeldItem);
            target.destroy(); 
        }
        else if (type == TypeOfInteractor.ValveSocket)
        {
            
            bool success = target.Interact(currentHeldItem); 
            
            if (success)
            {
                Debug.Log("Puzzle Solved!");
                currentHeldItem = ObjectType.None; 
            }
            else
            {
                Debug.Log("Missing required item!");
                target.Interact(); 
            }
        }
    }
}