using System.Collections;
using System.Collections.Generic;
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
