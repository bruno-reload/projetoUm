using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour , PowerUp {
    public Sprite icone;
    public Sprite getIcone(){
        return icone;
    }
    public void setIcone(Sprite newIcone){
        icone = newIcone;
    }
    public Vector3 powerUpEffect(Vector3 target){
        return new Vector3(target.x, Player.speed.y,0);
    }
    void Update()
    {
        transform.position += PowerUpformMove();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
    public Vector3 PowerUpformMove()
    {
        return Vector3.left * Plataform.speed.x * Time.deltaTime;
    }
    public Vector3 changePlataform()
    {
        return new Vector3(0,Player.playerJumpTime);

    }
}
