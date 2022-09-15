using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    [SerializeField] private Material mat;

    public Material GetMat()
    {
        return mat;
    }
}