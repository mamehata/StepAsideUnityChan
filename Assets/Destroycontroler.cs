using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroycontroler : MonoBehaviour
{
    //�J�����̃I�u�W�F�N�g
    private GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
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
