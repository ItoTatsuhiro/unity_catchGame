using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Spawner_item : MonoBehaviour
{
    [SerializeField]
    [Header("�����A�C�e�������Ԋu")] private float _interval = 1.0f;     // �A�C�e�������Ԋu
    private float _elapsed;             // �O�񐶐�����̌o�ߎ���

    [SerializeField]
    [Header("��������I�u�W�F�N�g")] private GameObject _item = null;

    //private Item _item_script = null;       // �A�C�e���̃X�N���v�g������p

    [SerializeField]
    [Header("���A�A�C�e��1")] private GameObject _rareItem = null;
    [SerializeField]
    [Range(0f, 1f)]
    [Header("���A�A�C�e��1�m��")] private float _rareItem_probability = 0;


    //[SerializeField]
    //[Header("���A�A�C�e��2")] private GameObject _rareItem2 = null;
    //[SerializeField]
    //[Range(0f, 1f)]
    //[Header("���A�A�C�e��2�m��")] private float _rare2_probability = 0;



    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed > _interval)
        {
            var Item_probability = Random.value;
            _elapsed = 0;

            var x = Random.Range(-5, 5);
            var y = Random.Range(3, 10);

            //Debug.Log("x = " + x + " y = " + y);

            if(Item_probability > _rareItem_probability)
            {
                //Debug.Log("Item");
                var item = Instantiate(_item);
                //_item_script = item.GetComponent<Item>();
                var rigidbody = item.GetComponent<Rigidbody2D>();
                item.transform.position = transform.position;
                rigidbody.AddForce(new Vector2(x, y), ForceMode2D.Impulse);

            }
            else
            {
                //Debug.Log("rareItem");
                var rareItem_ = Instantiate(_rareItem);

                var rigidbody = rareItem_.GetComponent<Rigidbody2D>();
                rareItem_.transform.position = transform.position;
                rigidbody.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
            }
        }
    }
}
