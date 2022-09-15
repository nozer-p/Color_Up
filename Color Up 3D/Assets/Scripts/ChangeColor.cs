using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer[] mat;

    private List<int> index = new List<int>();

    private void Start()
    {

        for (int i = 0; i < materials.Length;)
        {
            index.Add(i);
        }

        for (int i = 0; i < mat.Length;)
        {
            int rand = Random.Range(0, index.Count);
            mat[i].material = materials[rand];
            index.Remove(rand);
        }
    }
}
