using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;

    //�y�ۑ�p�z�T�E���h
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //�y�ۑ�p�z�T�E���h�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo����j������
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //�y�ۑ�z�n�ʂƁA�܂��̓L���[�u���m���Ԃ��鎞��SE���Đ�

    //if���Œn�ʂƃL���[�u���m�̏Փ˂݂̂ɍĐ������𐧌�
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "groundTag")
        {
            //CubePrefab��Audio Sourse�ɃA�T�C�������ublock�v���Đ�
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("�n�ʂɂԂ���");//�m�F�p
        }

        else if (collision.gameObject.tag == "CubeTag")
        {
            //CubePrefab��Audio Sourse�ɃA�T�C�������ublock�v���Đ�
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("�L���[�u���m���Ԃ���");//�m�F�p
        }

    }
}
