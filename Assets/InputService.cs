using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public float Horizontal {  get; private set; }
    public float Vertical { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis(nameof(Horizontal));
        Vertical = Input.GetAxis(nameof(Vertical));
    }
}
