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
    void move(){
        
        float distanciaZ = transform.position.z - Camera.main.transform.position.z;
        float bordaEsquerda = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaZ + transform.position.x)).x;
        float bordaDireita = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanciaZ - transform.position.x)).x;
        float bordaSuperior = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanciaZ)).y;
        float bordaInferior = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanciaZ)).y;


        CharacterController controller = GetComponent<CharacterController>();

        float restricaoX = Mathf.Clamp(Touch.eixoX, bordaEsquerda, bordaDireita);
        float restricaoZ = Mathf.Clamp(Touch.eixoZ, bordaSuperior, bordaInferior);

        if (controller.isGrounded){
            moveDirection = new Vector3(restricaoX, transform.position.y, restricaoZ);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Touch.jump)
                moveDirection.y =  jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
 