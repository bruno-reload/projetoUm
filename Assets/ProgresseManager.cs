
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

public class ProgresseManager : MonoBehaviour {

    public static float gravity = 20;
    public static Vector2 globalSpeed = new Vector2(4.5f,10.0f);
    public static int seed = 1;
    public static Vector3 pos;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        globalSpeed.x += Time.deltaTime / 100;
        globalSpeed.y += Time.deltaTime / 100;
        pos.x = Player.playerJumpTime* Random.Range(-seed, seed);
        pos.y = Player.playerJumpTime* Random.Range(-seed, seed);
        pos.z = Player.playerJumpTime* Random.Range(-seed/2, seed/2);
	}
}
