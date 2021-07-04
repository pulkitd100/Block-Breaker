using System;
using UnityEngine;

public class block : MonoBehaviour
{
    //config para
    [SerializeField] AudioClip destroysound;
    [SerializeField] GameObject particlevfx;
    [SerializeField] Sprite[] hitsprites;
   

    //cached
    Level level;

    //state variable
    [SerializeField] int timeshit; //for debugging

    public void Start()
    {
        countbreakableblocks();
       
    }

    private void countbreakableblocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "breakable")
        {

            level.countblocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "breakable")
        {
            handlehit();
        }
    }

    private void handlehit()
    {
        timeshit++;
        int maxhits = hitsprites.Length +1;
        if (timeshit >= maxhits)
        {
            Destroyblock();
        }
        else
        {
            shownexthitsprit();
        }
    }

    private void shownexthitsprit()
    {
        int spriteindex = timeshit - 1;
        if (hitsprites[spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitsprites[spriteindex];
        }
        else //made this for debugging
        {
            Debug.LogError("sprite is missing from array" + gameObject.name);
        }
    }

    public void Destroyblock()
    {
        PlaySFXondestroy();
        Destroy(gameObject);
        level.blockdestroyed();
        triggerpartcle();
    }

    private void PlaySFXondestroy()
    {
        FindObjectOfType<GameSession>().addtoscore();
        AudioSource.PlayClipAtPoint(destroysound, Camera.main.transform.position);
    }

    private void triggerpartcle()
    {
        GameObject sparkles = Instantiate(particlevfx,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
