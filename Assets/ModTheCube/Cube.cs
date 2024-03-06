using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    Vector3 originalScale;

    Color originalColor;
    void Start()
    {
        Material material = Renderer.material;
        originalColor = material.color; 
        originalScale = transform.localScale;
        StartCoroutine(ChangeCube());        
        

    }
    
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }

    IEnumerator ChangeCube()
    {
        while (true)
        {
            Material material = Renderer.material;

            if (transform.position.z != 6.5f)
            {
                transform.position = new Vector3(0, 0 , transform.position.z + .5f);
                transform.localScale = new Vector3(transform.localScale.x + .1f, transform.localScale.y + .1f, transform.localScale.z + .1f);
                material.color = new Color(material.color.r + .15f, material.color.g, material.color.b, material.color.a - .5f);
                yield return new WaitForSeconds(.5f);
            }
            else
            {
                transform.position = new Vector3(0, 0, -6.5f);
                transform.localScale = originalScale;
                material.color = originalColor;
            }
        }
    }
}
