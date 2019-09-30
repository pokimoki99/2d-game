using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text scoreText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = (int)(Time.time - startTime);

        scoreText.text = "Score : " + scoreValue;
    }
}
