using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script para mover un objeto a donde se de click
 */
public class clickController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update

    Vector2 clickedPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // aqui obtengo la posicion del mouse al dar un click
            clickedPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //con esta linea hago que se mueva un gameObjet a la posicion que yo le doy click
            transform.position = Vector2.MoveTowards(transform.position, clickedPos, speed * Time.deltaTime);

        }
        /*
         * Aqui pregunto si la posicion del player (la convierto a un vector2) es diferente a la posicion de donde se clickeo
         * y si es diferente ejecutara el movimiento siempre hasta que sea igual
         */
        if ((Vector2)transform.position != clickedPos)
        {
            //con esta linea hago que se mueva un gameObjet a la posicion que yo le doy click
            transform.position = Vector2.MoveTowards(transform.position, clickedPos, speed * Time.deltaTime);
        }

    }


}
