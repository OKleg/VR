using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObjectData : MonoBehaviour
{
    public Color originalColor;
    void Awake()
    {
        originalColor = this.GetComponent<Renderer>().material.color;
    }
}
