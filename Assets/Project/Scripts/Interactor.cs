using UnityEngine;

/// <summary>
/// Handles player interaction with objects in the world.
/// Attach this to the player alongside the camera.
/// </summary>
public class Interactor : MonoBehaviour
{
    // Types of interactions available
    public enum TypeOfInteractor
    {
        None,
        ONOFF,
        ObjectPickUp,
        ValveSocket 
    }

    // Types of objects that can be picked up or used
    public enum ObjectType
    {
        None,
        ValveHandle,
        SteamPipe 
    }

    [Header("Settings")]
    public float interactDistance = 3f;   
    public LayerMask interactableLayer;  

    // Tracks what item the player is currently holding
    private ObjectType currentHeldItem = ObjectType.None;

    private void Update()
    {
        // Cast a ray forward from the player
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactDistance, interactableLayer))
        {
            // Check if we hit something interactable
            IIntractable target = hitInfo.collider.GetComponent<IIntractable>();

            if (target != null)
            {
                Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.green);

                // Player pressed interact key
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PerformInteraction(target);
                }
            }
        }
    }

    /// <summary>
    /// Handles the interaction based on the target's type.
    /// </summary>
    void PerformInteraction(IIntractable target)
    {
        TypeOfInteractor type = target.GetTypeofInteractorObject();

        // Handle pickup objects
        if (type == TypeOfInteractor.ObjectPickUp)
        {
            currentHeldItem = target.GetObjectType(); 
            Debug.Log("Picked up: " + currentHeldItem);
            target.destroy(); 
        }
        // Handle valve socket (requires an item)
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