using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxTrigger : MonoBehaviour {

    [Header("Object:")]
    public string objectTextTitle;
    [TextArea]
    public string objectTextInfo;

    public GameObject Window;
    public TextMeshProUGUI displayTextTitle;
    public TextMeshProUGUI displayTextInfo;
    public bool singleUse = false;
    private bool hasUsed = false;

    public Transform center = null;
    public float reach = 3f;
    public string triggerTag = "TextboxTrigger";
    public LayerMask layerMask;


    private void Start()
    {
        Window.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(center.position, center.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reach, layerMask))
        {
            if (hit.collider.tag == triggerTag)
            {
                if (!singleUse || singleUse && !hasUsed)
                {
                    Window.SetActive(true);

                    if (Window != null)
                    {
                        displayTextTitle.text = objectTextTitle;
                        displayTextInfo.text = objectTextInfo;
                    }

                    hasUsed = true;
                }
            }
        } else
        {
            Window.SetActive(false);
        }
    }
}
