using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPosition : MonoBehaviour {

    public float xPosition;
    public float yPosition;

    private void Update()
    {
        this.transform.position = new Vector2(Input.mousePosition.x + xPosition, Input.mousePosition.y + yPosition);
    }
}
