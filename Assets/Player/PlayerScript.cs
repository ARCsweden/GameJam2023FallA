using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject grenade;
    Rigidbody grenade_Rigidbody;
    public float impulsez = 2;
    public float impulsey = 4;
    //public Vector3 offset = new Vector3(1.0f,0.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0), ForceMode.Impulse);
    }

    void OnThrow()
    {

        GameObject g = Instantiate(grenade, transform.position+transform.forward , transform.rotation) ;
        g.GetComponent<Rigidbody>().AddForce(0, impulsey, impulsez, ForceMode.Impulse);
        UnityEngine.Debug.Log("NEW INPUT SYSTEM, g key pressed");
        Destroy(g, 5.0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}
