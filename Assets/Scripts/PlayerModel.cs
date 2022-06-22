using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private int Health, Score;
    [SerializeField] private TextMeshProUGUI score,finalScore, health;
    [SerializeField] private GameObject GameOver, Pause;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("damage"))
        {
            Destroy(collision.gameObject);
            Health -= 10;
            if (Health <= 0)
            {
                gameObject.SetActive(false);
                GameOver.SetActive(true);
                finalScore.text = $@"YOUR FINAL SCORE:{Score}";
            }
            else
            {
                health.text = $@"HEALTH:{Health}";
            }
        }
        else if(collision.gameObject.CompareTag("token"))
        {
            collision.gameObject.SetActive(false);
            Score += 100;
            score.text = $@"SCORE:{Score}";
        }
    }
    private void Awake()
    {
        StartCoroutine(ScoreOverTime());
    }
    IEnumerator ScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Score += 10;
            score.text = $@"SCORE:{Score}";
            if (Health <= 0)
            {
                yield break;
            }
        }
    }
}
