using UnityEngine;

/// <summary>
/// Singleton that tracks noise levels in the world.
/// Other scripts can call NoiseMeter.Instance.addNoise() to add noise.
/// </summary>
public class NoiseMeter : MonoBehaviour
{
    // Singleton instance so other scripts can access this easily
    public static NoiseMeter Instance;

    private void Awake()
    {
        // Set up singleton - only one NoiseMeter allowed
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Adds noise to the world. Called by other scripts when something loud happens.
    /// </summary>
    public void addNoise(float amount)
    {
        Debug.Log($"<color=cyan>NOISE METER: +{amount} noise added!</color>");
    }
}