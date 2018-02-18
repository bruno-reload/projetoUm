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
