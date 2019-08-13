using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    /* Variables publicas */
    public float velocidad; //Velocidad de movimiento
    public Transform piesPosicion; //el gameobject para saber si esta tocando el suelo
    public LayerMask queEsPiso; //una layerMask para saber cuales gameobject son el piso
    public float jumpForce; //la fuerza del salto
    [Range(0, .3f)] [SerializeField] public float MovementSmoothing; //el pequeño delay en el movimiento
    [Range(0, 1f)] [SerializeField] public float chekearRadio; //el radio del circulo con el cual se dectecta si esta tocando el suelo
    /* Variables Privadas */
    private bool enSuelo; //para saber si esta o no tocando el suelo 
    private Rigidbody2D rb2d;
    private Animator amt;
    private SpriteRenderer spr;
    private Vector2 velocity = Vector2.zero;
    /* Variables Globales */
    float h;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        amt = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        /* Dibujo el circulo para saber cuando se toca el suelo 
           Retorna true o false gracias a que configure que la variable 
           enSuelo guarde un boleano
         */
        enSuelo = Physics2D.OverlapCircle(piesPosicion.position, chekearRadio, queEsPiso);
        amt.SetFloat("velocidad", Mathf.Abs(rb2d.velocity.x));
        amt.SetBool("enSuelo", enSuelo);
        if (h > 0)
        {
            spr.flipX = false;
        }
        else if (h < 0)
        {
            spr.flipX = true;
        }

       
        if (enSuelo == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
    }
    
     void FixedUpdate()
    {
        Mover(h * velocidad);     
    }

   

    void Mover(float h) {
        
        
        Vector2 targetVelocity = new Vector2(h, rb2d.velocity.y);
        //rb2d.velocity = new Vector2(h, rb2d.velocity.y);
        /* Con esto muevo el persona y ademas le doy un pequeño delay a su movimiento */
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, MovementSmoothing);
    }
}
