using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField] float screenwidth = 16f;
    [SerializeField] float maxx = 15f;
    [SerializeField] float minx = 1f;

    void Update()
    {
        float mousepos = Input.mousePosition.x / Screen.width * screenwidth;
        Vector2 paddlepos = new Vector2(transform.position.x, transform.position.y);
        paddlepos.x = Mathf.Clamp(mousepos, minx, maxx); 
        transform.position = paddlepos;
    }
}

