using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ĤH������
public class MonsterMove : MonoBehaviour
{

    private Transform[] positions;

    public int index = 0;

    public float speed = 20f;
    public void SetPath(WayPoints Path)
    {
        positions = Path.wayPoints;
    }


    // Update is called once per frame
    void Update()
    {
        //�եμĤH���ʤ�k
        Moving();
    }

    void Moving()
    {
        //�p�Gindex�p�� ���|�I�Ʋ��I�̤j�U�� �N�~�򲾰�
        if (index <= positions.Length - 1)
        {
            //��o ���V�q
            transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
            // transform.position =  Vector3.up * 0.3f;
            if (Vector3.Distance(positions[index].position, transform.position) <= 1f)
            {
                index++;
            }
        }

    }
}