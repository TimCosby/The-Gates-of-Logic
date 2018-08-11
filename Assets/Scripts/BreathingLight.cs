using UnityEngine;

public class BreathingLight : MonoBehaviour
{
    public Trigger Trigger;
    public Material[] ObjectMaterial;
    public float duration = 1.0F;
    Renderer rend;

    private bool triggeredOnce = false;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (Trigger == null)
        {
            Trigger = GetComponent<Trigger>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rend != null)
        {
            if (Trigger.Triggered)
            {
                rend.sharedMaterial = ObjectMaterial[0];
                triggeredOnce = true;
            }
            else
            {
                if (!triggeredOnce)
                {
                    float lerp = (Mathf.PingPong(Time.time, duration) / duration);
                    rend.material.Lerp(ObjectMaterial[1], ObjectMaterial[0], lerp);
                } else
                {
                    rend.sharedMaterial = ObjectMaterial[1];
                }
            }      
        }
    }
}