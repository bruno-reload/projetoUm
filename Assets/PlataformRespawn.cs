using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformRespawn : MonoBehaviour {
    private float timeCallAmount;
    public static PlataformRespawn current;
    void Awake(){
        current = this;
    }	
	void Update () {
        timedCall(Player.playerJumpTime + Plataform.plataformTime);
      }

    void newPlataform(){
        GameObject obj = GetComponent<ObjectPooling>().getObjAtPool();

        if (obj == null) return;
        print(ProgresseManager.pos);
        obj.transform.position = transform.position + ProgresseManager.pos;
        obj.SetActive(true);
    }

    void timedCall(float end){
        if(timeCallAmount <= 0){
            BroadcastMessage("newPlataform",end);
            timeCallAmount = end;
        }
        timeCallAmount -= Time.deltaTime;
    }
    //preciso saber qual a distancia max que o player poderá pular em função da velocidade que ele vai está quando pular
    //preciso usar o tamanho da tela pra definir a posição das plataformas em y e a distância do pulo do player para definir a distnacia em x
    //a variação da velocidade de movimentação do jogo
    //tudo deve ser gerado randomicamente respeitando o limite maximo das capacidades do player
    //deve ser verificado se o player tem power-ups para ter efeitos 

}
