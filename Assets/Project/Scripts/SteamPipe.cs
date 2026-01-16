using UnityEngine;

public class SteamPipe : MonoBehaviour, IIntractable
{
    [Header("Steam Corridor")]
    public GameObject steamParent; 

    [Header("Leak Steam")]
    public ParticleSystem leakSteam;

    private bool isFixed = false;

    public Interactor.ObjectType GetObjectType() { return Interactor.ObjectType.SteamPipe; }
    public Interactor.TypeOfInteractor GetTypeofInteractorObject() { return Interactor.TypeOfInteractor.ValveSocket; }
    public bool CanInteract() { return !isFixed; }
    public GameObject GetGameObject() { return gameObject; }
    public void destroy() { Destroy(gameObject); }
    public void Interact() { if(!isFixed) Debug.Log("Needs a valve!"); }

    public bool Interact(Interactor.ObjectType objectType)
    {
        if (objectType == Interactor.ObjectType.ValveHandle)
        {
            Debug.Log("<color=green>SUCCESS: Turning off the whole corridor!</color>");

            if (leakSteam != null) leakSteam.Stop();

            if (steamParent != null)
            {
                Collider col = steamParent.GetComponent<Collider>();
                if (col != null) col.enabled = false;

                ParticleSystem[] allSteam = steamParent.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem ps in allSteam)
                {
                    ps.Stop();
                }
            }

            if (NoiseMeter.Instance != null) NoiseMeter.Instance.addNoise(60f);

            isFixed = true;
            return true;
        }
        return false;
    }
}