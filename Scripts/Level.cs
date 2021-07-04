using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableblocks;   //serialized for debugging
    [SerializeField] SceneLoader loader;

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }
    public void countblocks()
    {
        breakableblocks++;
    }
    public void blockdestroyed()
    {
        breakableblocks--;
        if(breakableblocks <= 0 )
        {
            loader.LoadNextScene();
        }
    }
}
