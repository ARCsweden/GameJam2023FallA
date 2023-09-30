//using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Turtlebot : MonoBehaviour
{
    public GameObject turtlebot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        /*if( keyboard.spaceKey.wasPressedThisFrame )
	        Debug.Log("NEW INPUT SYSTEM, space key pressed");
        if(keyboard.spaceKey.wasPressedThisFrame){
            Instantiate(turtlebot);
        }*/
    }

    //void OnShoot(){
     //   Instantiate(turtlebot);
    //}
}
