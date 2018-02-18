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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {
    public static float plataformTime;
    public static Vector2 speed = new Vector2(ProgresseManager.globalSpeed.x-3,0.0f);
    public static Vector3 size;
    public float timeScreem;
    void OnEnable()
    {
        size = GetComponent<Collider>().bounds.size;
        plataformTime = size.x / speed.x;
        Invoke("reseta",plataformTime*4);
    }
	void Update () {
        transform.position += PlataformMove();
	}

    public void reseta(){
        gameObject.SetActive(false);
    }

    public Vector3 PlataformMove(){
        return Vector3.left * speed.x * Time.deltaTime;
    }
}
