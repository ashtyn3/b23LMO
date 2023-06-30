using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItem : MonoBehaviour
{

    private int Score = 0;
    [SerializeField]
    private int value = 100;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collect"))
        {
            //Destroy Object
            Destroy(collision.gameObject);
            // Increase the Score
            Score += value;
            scoreText.text = "Score: " + Score;
            Debug.Log(Score);
        }

    }
}
