using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grenade : MonoBehaviour
{
    public GameObject grenade;
    public GameObject Explosion;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("CheckforPlayers", 5.0f);
        timer = 0;
}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5.0f)
        {
            Hitbox();
            timer = timer - 5.0f;
        }
    }

    void Hitbox()
    {
        GameObject g_radius = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(g_radius, 1.0f);
    }
 }
