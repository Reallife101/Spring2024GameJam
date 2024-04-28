using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveani : MonoBehaviour
{
    [SerializeField] private Material m;
    private float a = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        m.SetFloat("Offset",a);
        a += Time.unscaledDeltaTime * 1.4f;
    }
}
