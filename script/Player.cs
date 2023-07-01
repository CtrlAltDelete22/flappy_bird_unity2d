
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteindex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(animatesprite), 015f, 0.15f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            direction = Vector3.up * strength;
        }
        if(Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) 
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;

    }
    private void animatesprite() 
    {
        spriteindex++;
        if(spriteindex >= sprites.Length) 
        {
            spriteindex = 0;
        }
        spriteRenderer.sprite = sprites[spriteindex];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle") 
        {
            FindObjectOfType<GameManager>().gameover();
        }
        else if (transform.position.y < -5) 
        {
            FindObjectOfType<GameManager>().gameover();
        }
        else if(collision.gameObject.tag == "scoring") 
        {
            FindObjectOfType<GameManager>().increasescore();
        }
    }
}
