using UnityEngine;
using UnityEngine.InputSystem;

public class Birdscript : MonoBehaviour
{

    //reference to the rigidbody2D component of the bird
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public SpriteRenderer mySpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            mySpriteRenderer.color = new Color(Random.value, Random.value, Random.value);
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
        }
        
        if (transform.position.y < -5)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }
}
