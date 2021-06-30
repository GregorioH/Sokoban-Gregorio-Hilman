using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 5;
    [SerializeField]
    public Transform puntoMovimiento;
    [SerializeField]
    private LayerMask capaObstaculos;

    private int movimientos = 0;
    private float segundosTranscurridos = 0;
    private int minutosTranscurridos = 0;
    private int horasTranscurridas = 0;

    public Text contadorMovimientos;
    public Text tiempoTranscurrido;

    void Start()
    {
        puntoMovimiento.parent = null;
    }

    void Update()
    {
        segundosTranscurridos += Time.deltaTime;

        int segundos = (int)segundosTranscurridos;

        if (segundos == 60)
        {
            minutosTranscurridos += 1;
            segundosTranscurridos = 0;
            
        }

        if (minutosTranscurridos == 60)
        {
            horasTranscurridas += 1;
            minutosTranscurridos = 0;
        }


        tiempoTranscurrido.text = "Tiempo transcurrido: " + horasTranscurridas.ToString("00") + ":" + minutosTranscurridos.ToString("00") + ":" + segundos.ToString("00");

        float cantidadMovimiento = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, puntoMovimiento.position, cantidadMovimiento);

        if (Vector3.Distance(transform.position, puntoMovimiento.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Movimiento(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                movimientos += 1;
                contadorMovimientos.text = "Movimientos realizados: " + movimientos;
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                Movimiento(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                movimientos += 1;
                contadorMovimientos.text = "Movimientos realizados: " + movimientos;
            }
        }

        if (Input.GetButton("Reiniciar"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetButton("Menu"))
        {
            SceneManager.LoadScene("Seleccion niveles");
        }
    }

    private void Movimiento(Vector3 direccion)
    {
        Vector3 posicionNueva = puntoMovimiento.position + direccion;
        if (!Physics2D.OverlapCircle(posicionNueva, 0.2f, capaObstaculos))
        {
            puntoMovimiento.position = posicionNueva;
        }
        else
        {
            movimientos -= 1;
        }
    }
}

