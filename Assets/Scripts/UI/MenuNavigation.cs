using UnityEngine;
using UnityEngine.EventSystems;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] private GameObject defaultButton; // El botón que se seleccionará por defecto

    private void Update()
    {
        // Detecta si no hay ningún objeto seleccionado en el sistema de eventos
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            // Detecta entrada de teclado o controlador
            if (Input.GetAxis("VerticalP1") != 0 || Input.GetAxis("HorizontalP1") != 0 ||
                Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                // Selecciona el botón por defecto
                EventSystem.current.SetSelectedGameObject(defaultButton);
            }
        }
    }
}
