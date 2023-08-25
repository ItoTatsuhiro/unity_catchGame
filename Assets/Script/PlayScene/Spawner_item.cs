using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Spawner_item : MonoBehaviour
{
    [SerializeField]
    [Header("初期アイテム生成間隔")] private float _interval = 1.0f;     // アイテム生成間隔
    private float _elapsed;             // 前回生成からの経過時間

    [SerializeField]
    [Header("複製するオブジェクト")] private GameObject _item = null;

    //private Item _item_script = null;       // アイテムのスクリプトを入れる用

    [SerializeField]
    [Header("レアアイテム1")] private GameObject _rareItem = null;
    [SerializeField]
    [Range(0f, 1f)]
    [Header("レアアイテム1確率")] private float _rareItem_probability = 0;


    //[SerializeField]
    //[Header("レアアイテム2")] private GameObject _rareItem2 = null;
    //[SerializeField]
    //[Range(0f, 1f)]
    //[Header("レアアイテム2確率")] private float _rare2_probability = 0;



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
