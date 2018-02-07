using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private Vector3 moveDirection = Vector3.zero;

    public float speed = 10;
    public float gravity = 20.0F;
    public float jumpSpeed = 8.0F;

    void Start()
    {

    }
    void Update(){
        move();
    }
    void move()
    {

        float distanciaZ = transform.position.z - Camera.main.transform.position.z;

        float xPos = transform.position.x;

        float bordaEsquerda = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaZ + xPos)).x;
        float bordaDireita = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanciaZ - xPos)).x;
        float bordaSuperior = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaZ)).y;
        float bordaInferior = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanciaZ)).y;

        float restricaoX;
        float restricaoZ; 

#if UNITY_ANDROID
        restricaoX = Mathf.Clamp(Touch.eixoX, bordaEsquerda, bordaDireita);
        restricaoZ = Mathf.Clamp(Touch.eixoZ, bordaSuperior, bordaInferior);
#endif
#if UNITY_EDITOR
        restricaoX = Mathf.Clamp(Input.GetAxis("Horizontal"), bordaEsquerda, bordaDireita);
        restricaoZ = Mathf.Clamp(Input.GetAxis("Vertical"), bordaSuperior, bordaInferior);
#endif
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded){
            
            moveDirection = new Vector3(restricaoX, transform.position.y, restricaoZ);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Touch.jump){
                moveDirection.y = jumpSpeed;
            }

        }else{
            controller.Move(new Vector3(
                Mathf.Lerp(transform.position.x,restricaoX,1),
                Mathf.Lerp(transform.position.y ,0,1),
                Mathf.Lerp(transform.position.z ,restricaoZ,1)));
        }       
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
    