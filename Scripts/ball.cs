using UnityEngine;

public class ball : MonoBehaviour
{
    // config para
    [SerializeField] paddle paddle;
    [SerializeField] float xpush = 2f;
    [SerializeField] float ypush = 15f;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float randomfactor = 0.2f;

    //state
    Vector2 paddletoball;
    bool hasstarted;

    //cached
    AudioSource mysource;
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        paddletoball = transform.position - paddle.transform.position;
        mysource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(hasstarted == false)
        {
         lockballtopaddle();
         launchonmouseclick();
        }
    }

    private void launchonmouseclick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasstarted = true;
            rb.velocity = new Vector2(xpush, ypush);
        }    
    }

    private void lockballtopaddle()
    {
        hasstarted = false;
        Vector2 paddlepos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlepos + paddletoball;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitytweak = new Vector2(Random.Range(0f,randomfactor),Random.Range(0f,randomfactor));

       if (hasstarted == true)
       {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            mysource.PlayOneShot(clip);
            rb.velocity += velocitytweak;
       }
    }
}
