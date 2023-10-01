using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_color : MonoBehaviour
{
    // List of available colors shared by each player instance
    public static List<UnityEngine.Color> availableColors = new List<UnityEngine.Color> {new Color(1,0,0,1), new Color(1, 0.2f, 0.5f, 1), Color.grey, Color.magenta, new Color(0.4f, 1f, 0.5f, 1), Color.yellow };

    // Start is called before the first frame update
    void Start()
    {
        //Get the Renderer component from the new player
        var playerRenderer = gameObject.GetComponent<Renderer>();

        // If no colors are available, use green
        int count = availableColors.Count;
        if (count < 1)
        {
            //Set the color
            PlayerScript playerScript = gameObject.GetComponent<PlayerScript>();
            playerScript.UpdateColor(Color.green);
            //playerScript.playerColor = Color.green;
        }
        else
        // Use a random color of the available colors and remove that color from the list
        {
            int randomIndex = Random.Range(0, count - 1);
            UnityEngine.Color playerColor = availableColors[randomIndex];
            availableColors.RemoveAt(randomIndex);

            //Set the color
            PlayerScript playerScript = gameObject.GetComponent<PlayerScript>();
            playerScript.UpdateColor(playerColor);
            //playerScript.playerColor = playerColor;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
