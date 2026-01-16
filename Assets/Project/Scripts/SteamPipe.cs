using UnityEngine;

/// <summary>
/// Steam pipe that blocks the player's path.
/// Requires a ValveHandle to fix and disable the steam.
/// </summary>
public class SteamPipe : MonoBehaviour, IIntractable
{
    [Header("References")]
    [SerializeField] private ParticleSystem steamEffect;  // The steam particles
    [SerializeField] private Collider blockingCollider;   // The collider that blocks the player

    // Tracks if the pipe has been fixed
    private bool isFixed = false;

    // Returns the identity of this object
    public Interactor.ObjectType GetObjectType() 
    { 
        return Interactor.ObjectType.SteamPipe; 
    }

    // This object requires a valve to interact with
    public Interactor.TypeOfInteractor GetTypeofInteractorObject() 
    { 
        return Interactor.TypeOfInteractor.ValveSocket; 
    }

    // Can only interact if not already fixed
    public bool CanInteract() 
    { 
        return !isFixed; 
    }

    public GameObject GetGameObject() 
    { 
        return gameObject; 
    }

    public void destroy() 
    { 
        Destroy(gameObject); 
    }

    // Called when player interacts without holding an item
    public void Interact() { }

    /// <summary>
    /// Called when player uses an item on this pipe.
    /// If the item is a ValveHandle, fixes the pipe.
    /// </summary>
    public bool Interact(Interactor.ObjectType objectType)
    {
        // Check if the player is using the correct item
        if (objectType == Interactor.ObjectType.ValveHandle)
        {
            // Stop the steam particles if assigned
            if (steamEffect != null)
            {
                steamEffect.Stop();
            }

            // Disable the blocking collider if assigned
            if (blockingCollider != null)
            {
                blockingCollider.enabled = false;
            }

            // Add noise to alert enemies
            if (NoiseMeter.Instance != null)
            {
                NoiseMeter.Instance.addNoise(60f);
            }

            // Mark as fixed so we can't interact again
            isFixed = true;
            return true;
        }

        // Wrong item or no item
        return false;
    }
}