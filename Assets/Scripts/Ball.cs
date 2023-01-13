using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Ball : MonoBehaviour
{

    public static float z;

    private float height = 0.58f, speed = 6;

    private bool move = false;

    private static Color currentColor;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    void Update()
    {
        if (Touch.IsPressing())
            move = true;


        if (move)
            Ball.z += speed * 0.025f;

        transform.position = new Vector3(0, height, Ball.z);

        UpdateColor();
    }



    /*public Color CurrentColor   // This is your property
    {
        get => currentColor;
        set => currentColor = value;
    }*/

    void UpdateColor()
    {
        meshRenderer.sharedMaterial.color = currentColor;
    }

    public static float GetZ()
    {
        return Ball.z;
    }
    
    public static Color SetColor(Color color)
    {
        return currentColor = color;
    }
    
    public static Color GetColor()
    {
        return currentColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hit")
        {
            Debug.Log("hit the wall");
        }
        if(other.tag == "Fail")
        {
            Debug.Log("Fail");
        }

        if (other.CompareTag("FinishLine"))
        {
            Debug.Log("LEvelup");
        }
    }
}

