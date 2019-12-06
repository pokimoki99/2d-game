using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text scoreText;
    private float startTime;
    public Inspirational_system inspiration;
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
        if (scoreValue==5 || scoreValue== 10 || scoreValue == 15 || scoreValue == 20 || scoreValue == 25 || scoreValue == 30 || scoreValue == 35 || scoreValue == 40
             || scoreValue == 45 || scoreValue == 50)
        {
            inspiration.inspire = true;
        }

    }
}
