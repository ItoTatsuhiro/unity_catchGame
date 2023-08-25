using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Spawner_bomb : MonoBehaviour
{
    [SerializeField]
    [Header("�����o�N�_�������Ԋu")] private float _interval_max = 3.0f;     // �o�N�_���̐����Ԋu�̍ő�l
    private float _interval;            // �o�N�_���̐����Ԋu
    private float _elapsed;             // �O�񐶐�����̌o�ߎ���

    [SerializeField]
    [Header("��������I�u�W�F�N�g")] private GameObject _bomb = null;

    private void Start()
    {
        _interval = Random.Range(0, _interval_max);
        Debug.Log("interval = " +  _interval);
    }


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

            //Debug.Log("bomb");
            var bomb = Instantiate(_bomb);
            //_item_script = item.GetComponent<Item>();
            var rigidbody = bomb.GetComponent<Rigidbody2D>();
            bomb.transform.position = transform.position;
            rigidbody.AddForce(new Vector2(x, y), ForceMode2D.Impulse);

            _interval = Random.Range(0, _interval_max);
            Debug.Log("interval = " + _interval);

        }
    }
}
