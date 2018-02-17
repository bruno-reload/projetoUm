using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {
    public static float plataformTime;
    public static Vector2 speed = new Vector2(ProgresseManager.globalSpeed.x-3,0.0f);
    public static Vector3 size;
    public float timeScreem;
    //como a velocidade é de 5 a vida corresponde a 5 a plataforma quando tem seu extremo direito transposto a posição inicial do extremo esquer a plataforma some
    //a plataforma deve passar para o player, enemy, obstáculos power-ups sua velocidade e direção para que os mesmos uma vez que estejá tocando-a possa ser atualizado
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
