using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panelToToggle; // Asigna esto desde el inspector

    public void TogglePanelVisibility()
    {
        if (panelToToggle != null)
            panelToToggle.SetActive(!panelToToggle.activeSelf); // Cambia la visibilidad del panel
    }
}
