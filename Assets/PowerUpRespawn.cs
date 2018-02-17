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
