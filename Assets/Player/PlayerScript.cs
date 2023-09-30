using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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


}
