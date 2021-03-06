﻿/*
    The MIT License (MIT)

    Copyright (c) 17 of februery,2018 Bruno Correia Da Silva.

    Permission is hereby granted, free of charge, to any person obtaining a copy of
    this software and associated documentation files (the "Software"), to deal in
    the Software without restriction, including without limitation the rights to
    use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
    the Software, and to permit persons to whom the Software is furnished to do so,
    subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
    FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
    COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
    IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
    CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

    autor: Bruno Correia da Silva
    facebook:https://www.facebook.com/bruno.correiadasilva.7

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Vector2 speed = new Vector2(ProgresseManager.globalSpeed.x - 2,8.0f);
    public static float playerJumpTime;

    private Vector3 moveDirection = Vector3.zero;

    private float bordaEsquerda;
    private float bordaDireita;
    private float bordaSuperior;
    private float bordaInferior;

    private  float restricaoX;
    private float restricaoZ;

    private PowerUp effect_1;
    private PowerUp effect_2;

    private CharacterController controller;

    void Start(){
        
    }
    void FixedUpdate(){
        movimento();
    }
    void Update(){
        playerJumpTime = 4 * speed.y/ProgresseManager.gravity;
        print("playerJumpTime: " + playerJumpTime);
    }

    void movimento(){
        limitAreaVisivel();

        controller = GetComponent<CharacterController>();

        if (controller.isGrounded){
            
            moveDirection = new Vector3(restricaoX, 0, restricaoZ).normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed.x;

            if (Touch.jump)
            {
                moveDirection.y = speed.y;
            }
        } 
        if (Touch.effect_1 && effect_1 != null)
        {
            moveDirection = effect_1.powerUpEffect(moveDirection);
            effect_1 = null;
        }
        if (Touch.effetc_2 && effect_2 != null)
        {
            moveDirection = effect_2.powerUpEffect(moveDirection);
            effect_2 = null;
        }
      
        moveDirection.y -= ProgresseManager.gravity * Time.deltaTime;
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
    void OnTriggerStay(Collider coll){
        if(coll.tag == "Plataform"){
            transform.position += coll.GetComponent<Plataform>().PlataformMove();
        }
       
        if(coll.tag == "PowerUp"){
            effect_1 = effect_2;
            effect_2 = coll.gameObject.GetComponent<PowerUp>();
        }
       
           
        }
   
}
