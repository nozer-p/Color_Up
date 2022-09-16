using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsPlayer : MonoBehaviour
{
    private Material mat;

    public void SetMat(Material mat)
    {
        this.mat = mat;
    }

    public Material GetMat()
    {
        return mat;
    }
}