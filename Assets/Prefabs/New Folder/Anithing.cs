using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anithing : MonoBehaviour
{
    private float a;
    private Material m;


    // Update is called once per frame
    void Update()
    {
        m.SetVector("Vector2", new Vector2(a,a));
        a += Time.unscaledDeltaTime;
    }
}
