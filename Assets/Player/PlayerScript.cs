using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public PlayerManager playerManager;
    public float health, maxHealth;
    public HealthBar healthBar;
    public int playerIndex;
    public float moveForce;
    public float moveDeadzone = 0.3f;
    public float lookDeadzone = 0.3f;
    public float speed = 0;
    public GameObject turtle;
    public GameObject grenade;
    Rigidbody grenade_Rigidbody;
    public float impulsez = 2;
    public float impulsey = 10;

    public Color playerColor;
    //public Vector3 offset = new Vector3(1.0f,0.0f,0.0f);

    // Start is called before the first frame update
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.    
        health -= 10f;
        healthBar.UpdateHealthBar();
    }


    [SerializeField]
    Transform DirTransform;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private Camera mainCamera;
    Vector3 camTransform;

    [SerializeField] Vector3 InputDirection;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindAnyObjectByType<Camera>();
        playerManager = FindObjectOfType<PlayerManager>();
        maxHealth = 100;
        health = maxHealth;
        healthBar.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per physics tick
    private void FixedUpdate()
    {
        camTransform = new Vector3(-mainCamera.transform.right.x, 0, -mainCamera.transform.right.z);
        camTransform = camTransform.normalized;
        DirTransform.forward = camTransform;


        if (health <= 0)
        {
            health = maxHealth;
            healthBar.UpdateHealthBar();
            resetPlayer();
            playerManager.removeScore(20, playerIndex);
        }
        else
        {
            UpdateLook();
            UpdateMovement();
            //Debug.Log("moveInput: " + moveInput);
        }

    }

    // ------------------------------------------------------------------------------------------------
    // Functions:
    // ------------------------------------------------------------------------------------------------
    private void UpdateLook()
    {
        if(lookInput.x != 0 || lookInput.y != 0)
            transform.forward = DirTransform.right* lookInput.x + DirTransform.forward* lookInput.y;
    }

    private void UpdateMovement()
    {
        //Debug.Log(mainCamera.transform.right);

        gameObject.GetComponent<Rigidbody>().AddForce(-DirTransform.forward * moveForce * moveInput.x + DirTransform.right * moveForce * moveInput.y, ForceMode.Impulse);
    }


    // ------------------------------------------------------------------------------------------------
    // Input System Functions:
    // ------------------------------------------------------------------------------------------------
    void OnJump()
    {
        //Debug.Log("Jump!");
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,500,0), ForceMode.Impulse);
    }

    void OnMove(InputValue mInput)
    {
        //Debug.Log("mInput: "+ mInput);


        if (mInput.Get<Vector2>().x < -moveDeadzone || mInput.Get<Vector2>().x > moveDeadzone)
        {
            moveInput.x = mInput.Get<Vector2>().x;
        }
        else
        {
            moveInput.x = 0;
        }

        if (mInput.Get<Vector2>().y < -moveDeadzone || mInput.Get<Vector2>().y > moveDeadzone)
        {
            moveInput.y = mInput.Get<Vector2>().y;
        }
        else
        {
            moveInput.y = 0;
        }
    }

    void OnLook(InputValue lInput)
    {
        //Debug.Log("mInput: "+ mInput);

        if (lInput.Get<Vector2>().x < -moveDeadzone || lInput.Get<Vector2>().x > lookDeadzone)
        {
            lookInput.x = lInput.Get<Vector2>().x;
        }
        else
        {
            moveInput.x = 0;
        }

        if (lInput.Get<Vector2>().y < -moveDeadzone || lInput.Get<Vector2>().y > lookDeadzone)
        {
            lookInput.y = lInput.Get<Vector2>().y;
        }
        else
        {
            moveInput.y = 0;
        }
    }
    void OnShoot(){
        GameObject g=Instantiate(turtle, transform.position, transform.rotation);
        UnityEngine.Debug.Log("NEW INPUT SYSTEM, space key pressed");
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Grenade"))
        {
            Debug.Log("Damage");
            TakeDamage();
        }
        else
        {
            Debug.Log(collision.gameObject.tag);
        }
    }
    void resetPlayer()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObject.transform.position = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    public void UpdateColor(Color color){
        playerColor = color;
        playerManager.colorArray[playerIndex] = playerColor;
    }
    
    void OnThrow()
    {
        GameObject g = Instantiate(grenade, transform.position+transform.right, transform.rotation) ;
        g.GetComponent<Rigidbody>().AddForce(impulsey*gameObject.transform.right, ForceMode.Impulse);
        UnityEngine.Debug.Log("NEW INPUT SYSTEM, g key pressed");
        Destroy(g, 5.0f);
    }

}





 