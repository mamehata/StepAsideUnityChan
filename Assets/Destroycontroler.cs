using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroycontroler : MonoBehaviour
{
    //カメラのオブジェクト
    private GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.maincamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.maincamera.transform.position.z > this.gameObject.transform.position.z)
        {
            Destroy(this.gameObject);
        }  
    }
}
