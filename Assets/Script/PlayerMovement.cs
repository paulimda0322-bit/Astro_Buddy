using NUnit.Framework;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float speed = 5f;
    public int score =0;
    public GameObject Pistola;
    public int estrellasParaPistola= 5;
    public bool hasPistola= false;
    public int damageEnemy = 1;
    public bool puedeAtacar = false;
    public bool hasWon = false;
    public int enemigosDerrotados = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3 (moveHorizontal, moveVertical, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        if(score >= estrellasParaPistola && hasPistola)
        {
            puedeAtacar = true;
        }

        if(puedeAtacar && enemigosDerrotados >= 3 && ! hasWon)
        {
            hasWon = true;
            Debug.Log("You Won!");
        }
    }


    private void OnTriggerEnter2D( Collider2D other)
    {
       if(other.CompareTag("Star"))
        {
            score = score + 1;

            Destroy(other.gameObject);
            Debug.Log("Star collected!");
            Debug.Log("Score:"+ score); 

         if(score>=5)
            {
                Pistola.SetActive(true);
                Debug.Log("Pistola desbloqueada");
            }
        } 
        if(other.CompareTag("Pistola"))
        {
            hasPistola = true;
            Destroy(other.gameObject);
            Debug.Log("Pistola recogida");

        }
        if(other.CompareTag("Enemy"))
        {   if(puedeAtacar)
            {   enemigosDerrotados = enemigosDerrotados + 1; // sumar 1 al contador de enemigos derrotados
                Destroy(other.gameObject);
                Debug.Log("Enemigo destruido");
            }
            else
            {
                score = score - 1;
                Debug.Log("Te golpeó un enemigo. score:"+ score); 
            }
        
           


        }
       
    }
}
