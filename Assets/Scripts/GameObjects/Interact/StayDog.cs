using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 止まる犬に関するプログラム
public class StayDog : MonoBehaviour, IInteractive
{
    [SerializeField] GameObject player;  // プレイヤーオブジェクト
    [SerializeField] GameObject nowStayDogPos;  // マップでの犬の滞在地の表示用Cube

    public void Interact()
    {
        Debug.Log("犬当たったよ");
        
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<AudioSource>().enabled = false;

        Destroy(nowStayDogPos);

        transform.parent = player.gameObject.transform;
        this.transform.localPosition = new Vector3(0.0f, 0.0f, -5.0f);
        this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }
}