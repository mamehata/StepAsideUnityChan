using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //アイテムが生成される範囲1
    private float difference1;
    //アイテムが生成される範囲2
    private float difference2;
    //Unityちゃんの座標
    private float unitychanposition;


    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }


    // Update is called once per frame
    void Update()
    {
        //Unityちゃんから50M先の距離を計算
        this.difference1 = this.unitychan.transform.position.z + 50;
        
        if (this.unitychan.transform.position.z - this.unitychanposition >= 15 && this.difference1 < goalPos)
        { 
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.difference1);
                }
                
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.difference1);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.difference1);
                    }
                }
            }
            //アイテム作成時のUnityちゃんの座標
            this.unitychanposition = this.unitychan.transform.position.z;
        }
    }
}
