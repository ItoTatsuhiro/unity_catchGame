using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int _delete_item_height = -10;      // �A�C�e���������鍂��

    [SerializeField]
    private int _itemscore = 10;        // �A�C�e�����擾�����ۂ̃X�R�A

    // �A�C�e���̃X�R�A��Ԃ��֐�
    public int getItemScore()
    {
        return _itemscore;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _delete_item_height)
        { 
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
