using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {
    
    public GameObject obj;
    public int amount = 10;
    public bool increasing = true;

    List<GameObject> objectList;

	void Start () {
        objectList = new List<GameObject>();

        for( int i = 0; i < amount; i++ ){
            GameObject _obj = (GameObject) Instantiate(obj);
            _obj.SetActive(false);
            objectList.Add(_obj);
        }
	}
	
    public GameObject getObjAtPool(){
        for (int i = 0; i < objectList.Count; i++){
            if(!objectList[i].activeInHierarchy){
                return objectList[i];
            }
        }
        if(increasing){
            GameObject _obj = (GameObject)Instantiate(obj);
            objectList.Add(_obj);
            return _obj;
        }
        return null;
    }
}
