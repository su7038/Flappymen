using UnityEngine;
using UnityEngine.InputSystem;

public class Birdscript : MonoBehaviour
{

    //reference to the rigidbody2D component of the bird
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public SpriteRenderer mySpriteRenderer;
    public float SpawnProtection = 2.9f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            mySpriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
        SpawnProtection = SpawnProtection - Time.deltaTime;

        if (SpawnProtection <= 0)
        {
            if (transform.position.y > 10 || transform.position.y < -10)
            {
                logic.GameOver();
                birdIsAlive = false;
            }
        }
        else if (transform.position.y < -5f)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SpawnProtection <= 0)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }
}
