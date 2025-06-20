using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rotador : MonoBehaviour
{
    public GameObject objetoARotar;
    public Button botonRotar;
    public float anguloPorClick = 45f;

    void Start()
    {
        if (botonRotar != null)
        {
            botonRotar.onClick.AddListener(RotarUnaVez);
        }
    }

    void RotarUnaVez()
    {
        if (objetoARotar != null)
        {
            objetoARotar.transform.Rotate(Vector3.up * anguloPorClick);
        }
    }
}
