using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Material[] materialsPlayer;
    [SerializeField] private GameObject[] mat;

    private List<int> index = new List<int>();

    private void Start()
    {

        for (int i = 0; i < materials.Length; i++)
        {
            index.Add(i);
        }

        for (int i = 0; i < mat.Length; i++)
        {
            int rand = Random.Range(0, index.Count);
            mat[i].GetComponent<MeshRenderer>().material = materials[rand];
            mat[i].GetComponent<ColorsPlayer>().SetMat(materialsPlayer[rand]);
            index.Remove(rand);
        }
    }
}
