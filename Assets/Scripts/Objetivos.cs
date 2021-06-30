using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objetivos : MonoBehaviour
{
    public static int objetivosCompletados = 0;

    [SerializeField]
    private SpriteRenderer Color;
    [SerializeField]
    private Collider2D cl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivosCompletados == 3)
        {
            objetivosCompletados = 0;
            SceneManager.LoadScene("Seleccion niveles");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Objetivo")
        {
            objetivosCompletados += 1;
            Destroy(collision.gameObject);
            Color.color = UnityEngine.Color.green;
            cl.enabled = false;
        }
    }
}
