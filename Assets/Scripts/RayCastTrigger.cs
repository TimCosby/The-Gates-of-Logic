using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RayCastTrigger : Trigger {

    public Transform center = null;
    public float reach = 3f;
    public string triggerTag;
    public LayerMask layerMask;

    private void Update()
    {
        Ray ray = new Ray(center.position, center.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reach, layerMask))
        {
            if (hit.collider.tag == triggerTag)
            {
                Triggered = true;
            } else
            {
                Triggered = false;
            }
        } else
        {
            Triggered = false;
        }
    }
}
