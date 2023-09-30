using System.Transactions;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerManager playerManager;
    public float health, maxHealth;
    public HealthBar healthBar;


    public int playerIndex;



    public float speed = 0;
    public GameObject turtle;
    // Start is called before the first frame update
    
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.    
        health -= 10f;
        healthBar.UpdateHealthBar();
    }
    
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        maxHealth = 100;
        health = maxHealth;
        healthBar.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(keyboard.spaceKey.wasPressedThisFrame){
            //transform.Translate(Vector3.forward);
        }
        if(health <= 0){
            health = maxHealth;
            healthBar.UpdateHealthBar();
            resetPlayer();
            playerManager.removeScore(20, playerIndex);

        }
    }

    void OnJump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0), ForceMode.Impulse);
    }

    void OnShoot(){
        GameObject g=Instantiate(turtle, transform.position, transform.rotation);
        UnityEngine.Debug.Log("NEW INPUT SYSTEM, space key pressed");
    }

    void OnMoveFront(){
        transform.Translate(Vector3.forward);
    }

    void OnCollisionEnter(){
        TakeDamage();
    }

    private void resetPlayer()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
    }


}
