using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidad de movimiento del personaje

    public Sprite[] frontSprites;
    public Sprite[] backSprites;
    public Sprite[] leftSprites;
    public Sprite[] rightSprites;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float animationTimer = 0f;
    private float animationSpeed = 0.1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            AnimateCharacter(rightSprites);
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            AnimateCharacter(leftSprites);
        }
        else if (verticalInput > 0)
        {
            AnimateCharacter(backSprites);
        }
        else if (verticalInput < 0)
        {
            AnimateCharacter(frontSprites);
        }
    }

    void AnimateCharacter(Sprite[] sprites)
    {
        animationTimer += Time.deltaTime;

        if (animationTimer >= animationSpeed)
        {
            animationTimer = 0f;
            currentFrame = (currentFrame + 1) % sprites.Length;
        }

        spriteRenderer.sprite = sprites[currentFrame];
    }
}
