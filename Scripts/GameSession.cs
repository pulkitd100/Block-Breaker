using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // config para
    [Range(0.1f,10f)][SerializeField] float timespeed = 1f;
    [SerializeField] int pointsperblock;
    [SerializeField] Text scoretext;

    // state variable
    [SerializeField] int currentscore = 0;

    private void Awake()
    {
        int gamestatescount = FindObjectsOfType<GameSession>().Length;
        if(gamestatescount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoretext.text = currentscore.ToString();
    }
    void Update()
    {
        Time.timeScale = timespeed;
    }
    public void addtoscore()
    {
        currentscore += pointsperblock;
        scoretext.text = currentscore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
