using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    [SerializeField] Animator animator;
    public GameObject charlie;
    public Transform teleportLocation;
    public GameObject purpleTeleporter;
    public GameObject blueTeleporter;
    public GameObject cheese;
    private float _movementSpeed = 35;
    private int cheeseLeft = 1;
    public int currentLevel = 1;
    
    void Start()
    {
        SceneManager.activeSceneChanged += MoveToSpawn;
    }
    void MoveToSpawn(Scene current, Scene next)
    {
        transform.position = new Vector3(GameObject.Find("Spawn").gameObject.transform.position.x,
            GameObject.Find("Spawn").gameObject.transform.position.y + 5);
    }
    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        Movement();
    }
    void Respawn()
    {
        SceneManager.LoadScene(currentLevel);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cheese")
        {
        
            Destroy(collision.gameObject);
            cheeseLeft--;
            if(cheeseLeft == 0)
            {
                spawnPortal();
            }
            
        }
        else if (collision.gameObject.tag == "portal")
        {
            currentLevel++;
            cheeseUpdater();
            SceneManager.LoadScene(currentLevel);
            
        }
        else if (collision.gameObject.tag == "death")
        {
            Respawn();
            resetGameState();           
        }
    }
   
    void Movement()
    {
        //sets a max velocity for gravity and flapping wings
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 20);
        if (Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
            animator.SetTrigger("flap");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _movementSpeed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -_movementSpeed * Time.deltaTime);
            spriteRenderer.flipX = false;
        }

    }

    void spawnPortal()
    {
        GameObject purpleTeleporterClone = Instantiate(purpleTeleporter);
        purpleTeleporterClone.transform.position = GameObject.Find("UnopenedPortal").transform.position;
        Destroy(GameObject.Find("UnopenedPortal"));
    }
    void resetGameState()
    {
        cheeseUpdater();
        SceneManager.LoadScene(currentLevel);
    }
    void cheeseUpdater()
    {
        if(currentLevel == 1 || currentLevel == 2 || currentLevel == 8) { cheeseLeft = 1; }
        if(currentLevel == 4 || currentLevel == 5 || currentLevel == 6 || currentLevel == 7) { cheeseLeft = 2; }
        if(currentLevel == 3) { cheeseLeft = 3; }
       

    }
}

