using UnityEngine;

public class NoiseMeter : MonoBehaviour
{
    public static NoiseMeter Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addNoise(float amount)
    {
        Debug.Log($"<color=cyan>NOISE METER: +{amount} noise added! (Shhh!)</color>");
    }
}