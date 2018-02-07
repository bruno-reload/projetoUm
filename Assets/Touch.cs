using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public static float eixoX = 0;
    public static float eixoZ = 0;
    public static bool jump = false;

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
}
