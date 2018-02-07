using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private Vector3 moveDirection = Vector3.zero;

    public float speed = 10;
    public float gravity = 20.0F;
    public float jumpSpeed = 8.0F;

    private float bordaEsquerda;
    private float bordaDireita;
    private float bordaSuperior;
    private float bordaInferior;


    private  float restricaoX;
    private float restricaoZ;  

    void Start()
    {

    }
    void Update(){
        movimento();
    }
    void movimento(){
        limitAreaVisivel();

        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded){
            
            moveDirection = new Vector3(restricaoX, transform.position.y, restricaoZ).normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Touch.jump){
                moveDirection.y = jumpSpeed;
            }

        } 
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }


    public void limitAreaVisivel(){
        
        float distanciaZ = transform.position.z - Camera.main.transform.position.z;

        float xPos = transform.position.x;

        bordaEsquerda = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaZ + xPos)).x;
        bordaDireita = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanciaZ - xPos)).x;
        bordaSuperior = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaZ)).y;
        bordaInferior = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanciaZ)).y;

#if UNITY_ANDROID
        restricaoX = Mathf.Clamp(Touch.eixoX, bordaEsquerda, bordaDireita);
        restricaoZ = Mathf.Clamp(Touch.eixoZ, bordaSuperior, bordaInferior);
#endif
#if UNITY_EDITOR
        restricaoX = Mathf.Clamp(Input.GetAxis("Horizontal"), bordaEsquerda, bordaDireita);
        restricaoZ = Mathf.Clamp(Input.GetAxis("Vertical"), bordaSuperior, bordaInferior);
#endif

    }
}
    