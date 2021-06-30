using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public static float puntos;

    void Start()
    {
        puntos = 0;
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Seleccion niveles");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if (puntos == 5)
        {
            SceneManager.LoadScene("Victoria");
        }
    }      
}
