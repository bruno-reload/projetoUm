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
