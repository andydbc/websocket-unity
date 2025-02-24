using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    VisualEffect vfx;

    void Start()
    {
        vfx = GetComponent<VisualEffect>();
    }

    public void OnMessageReceived(string message)
    {
        vfx.enabled = !vfx.enabled;
    }
}
