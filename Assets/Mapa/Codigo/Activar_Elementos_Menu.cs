/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Activar_Elementos_Menu : MonoBehaviour
{
    public Canvas IU;
    public Button Boton_Activar_Elementos;


    // Start is called before the first frame update
    void Start()
    {
        if(Boton_Activar_Elementos != null)
        {
            Boton_Activar_Elementos.onClick.AddListener(ToggleCanvas);
        }
        if (IU != null)
        {
            IU.gameObject.SetActive(false);
        }
    }

    void ToggleCanvas()
    {

        //AudioManager.Instance.PlayEfect(0);
        if (IU != null && Boton_Activar_Elementos != null)
        {
            bool isActive = !IU.gameObject.activeSelf;
            IU.gameObject.SetActive(isActive);
            Boton_Activar_Elementos.gameObject.SetActive(false); // Oculta el botón cuando se muestra el Canvas
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   

}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activar_Elementos_Menu : MonoBehaviour
{
    public Canvas IU;  // El Canvas del menú
    public Button Boton_Activar_Elementos;  // Botón para mostrar el menú
    public Button Boton_Cerrar_Menu;  // Botón X para cerrar el menú

    void Start()
    {
        if (Boton_Activar_Elementos != null)
        {
            Boton_Activar_Elementos.onClick.AddListener(ToggleCanvas);
        }

        if (Boton_Cerrar_Menu != null)
        {
            Boton_Cerrar_Menu.onClick.AddListener(CloseCanvas);
        }

        if (IU != null)
        {
            IU.gameObject.SetActive(false); // Empieza oculto
        }

        if (Boton_Activar_Elementos != null)
        {
            Boton_Activar_Elementos.gameObject.SetActive(true); // Empieza visible
        }
    }

    void ToggleCanvas()
    {
        if (IU != null && Boton_Activar_Elementos != null)
        {
            IU.gameObject.SetActive(true); // Mostrar Canvas
            Boton_Activar_Elementos.gameObject.SetActive(false); // Ocultar botón de activar
        }
    }

    void CloseCanvas()
    {
        if (IU != null && Boton_Activar_Elementos != null)
        {
            IU.gameObject.SetActive(false); // Ocultar Canvas
            Boton_Activar_Elementos.gameObject.SetActive(true); // Volver a mostrar botón de activar
        }
    }
}

