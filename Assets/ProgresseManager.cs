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
