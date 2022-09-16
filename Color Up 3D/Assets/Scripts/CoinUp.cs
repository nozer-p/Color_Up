using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUp : MonoBehaviour
{
    [SerializeField] private Material playerMaterial;
    private ScoreManager scoreManager;

    [SerializeField] private GameObject[] colors;

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

        if (other.gameObject.CompareTag("ChangeColor"))
        {
            playerMaterial = other.gameObject.GetComponent<ColorsPlayer>().GetMat();
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i].GetComponent<SkinnedMeshRenderer>().material = other.gameObject.GetComponent<ColorsPlayer>().GetMat();
            }
        }
    }
}
