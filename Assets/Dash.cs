/*
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

using UnityEngine;

public class Dash : MonoBehaviour, PowerUp {
    public Sprite icone;
    void Update()
    {
        transform.position += PowerUpformMove();
    }
    public Sprite getIcone()
    {
        return icone;
    }
    public void setIcone(Sprite newIcone)
    {
        icone = newIcone;
    }
    public Vector3 powerUpEffect(Vector3 target)
    {
        return new Vector3(Player.speed.x*4,Player.speed.y/4, 0);
    }
    void OnTriggerStay(Collider other)
    { 
        if(other.tag == "Player"){
            gameObject.SetActive(false); 
        }
    }
    public Vector3 PowerUpformMove()
    {
        return Vector3.left * Plataform.speed.x * Time.deltaTime;
    }
    public Vector3 changePlataform()
    {
        return new Vector3(0, Player.playerJumpTime, 0);
    }

}
