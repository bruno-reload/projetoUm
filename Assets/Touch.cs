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

public class Touch : MonoBehaviour {

    public static float eixoX = 0;
    public static float eixoZ = 0;
    public static bool jump = false;
    public static bool effect_1 = false;
    public static bool effetc_2 = false;

    private float max = 1;
    private float min = 0;

    public void CimaLiga(){
        eixoZ = max;
    }
    public void CimaDesliga(){
        eixoZ = min;
    }
    public void BaixoLiga(){
        eixoZ = -max;
    }
    public void BaixoDesliga(){
        eixoZ = min;
    }
    public void EsquerdaLiga()
    {
        eixoX = -max;
    }
    public void EsquerdaDesliga()
    {
        eixoX = min;
    }
    public void DireitaLiga()
    {
        eixoX = max;
    }
    public void DireitaDesliga()
    {
        eixoX = min;
    }
    public void PulaLiga(){
        jump = true;
    }
    public void PulaDesliga(){
        jump = false;
    }
    public void effect_1Liga(){
        effect_1 = true;
    }
    public void effect_1Desliga()
    {
        effect_1 = false;
    }
    public void effect_2Liga(){
        effetc_2 = true;
    }
    public void effect_2Desliga(){
        effetc_2 = false;
    }
}
