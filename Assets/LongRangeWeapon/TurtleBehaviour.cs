using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //transform.position = new Vector3(0,0,2) * Time.deltaTime;
    }

    void OnCollisionEnter(){
        Destroy(gameObject);
    }
}
