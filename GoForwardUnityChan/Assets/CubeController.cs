using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    //【課題用】サウンド
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //【課題用】サウンドコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //【課題】地面と、またはキューブ同士がぶつかる時にSEを再生

    //if文で地面とキューブ同士の衝突のみに再生条件を制限
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag")
        {
            //CubePrefabのAudio Sourseにアサインした「block」を再生
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("地面にぶつかる");//確認用
        }

        else if (collision.gameObject.tag == "CubeTag")
        {
            //CubePrefabのAudio Sourseにアサインした「block」を再生
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("キューブ同士がぶつかる");//確認用
        }

    }
}
