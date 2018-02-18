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

public class PowerUpRespawn : MonoBehaviour {
    public static PowerUpRespawn current;
    private float timeCallAmount = 0;
    void Awake(){
        current = this;
    }
    void Update()
    {
        timedCall((Player.playerJumpTime + Plataform.plataformTime)*ProgresseManager.seed);
    }
    void newEffect()
    {
        GameObject obj = GetComponent<ObjectPooling>().getObjAtPool();
        if (obj == null) return;
        ProgresseManager.pos = obj.GetComponent<PowerUp>().changePlataform();
        obj.transform.position=transform.position+ProgresseManager.pos;
        obj.SetActive(true);
    }

    void timedCall(float end)
    {
        if (timeCallAmount <= 0)
        {
            BroadcastMessage("newEffect", end);
            timeCallAmount = end;
        }
        timeCallAmount -= Time.deltaTime;
    }
}
