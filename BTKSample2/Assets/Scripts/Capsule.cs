using UnityEngine;

public class Capsule : MonoBehaviour
{
    public int minScore = 10 , maxScore = 30;
    private GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            Destroy(this.gameObject);  
        }
          
    }
}
