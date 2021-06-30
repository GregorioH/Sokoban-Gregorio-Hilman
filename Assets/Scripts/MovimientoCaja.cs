using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCaja : MonoBehaviour
{
    [SerializeField]
    public Transform puntoMovimiento;
    [SerializeField]
    private float velocidad = 5;
    [SerializeField]
    private LayerMask capaObstaculos;

    public static bool contraPared;
    // Start is called before the first frame update
    void Start()
    {
        puntoMovimiento.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        float cantidadMovimiento = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, puntoMovimiento.position, cantidadMovimiento);

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
             Movimiento(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
            }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
             Movimiento(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
            }

    }

    private void Movimiento(Vector3 direccion)
    {
        Vector3 posicionNueva = puntoMovimiento.position + direccion;
        if (!Physics2D.OverlapCircle(posicionNueva, 0.2f, capaObstaculos))
        {
            puntoMovimiento.position = posicionNueva;
        }
    }
}
