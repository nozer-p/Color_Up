using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUp : MonoBehaviour
{
    [SerializeField] private Material playerMaterial;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            if (playerMaterial == other.gameObject.GetComponent<Materials>().GetMat())
            {
                scoreManager.PlusScore();
            }
            else
            {
                scoreManager.MinusScore();
            }
            Destroy(other.gameObject);
        }
    }
}
