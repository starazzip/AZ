using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵人移動類
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
        //調用敵人移動方法
        Moving();
    }

    void Moving()
    {
        //如果index小於 路徑點數組點最大下標 就繼續移動
        if (index <= positions.Length - 1)
        {
            //獲得 單位向量
            transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
            // transform.position =  Vector3.up * 0.3f;
            if (Vector3.Distance(positions[index].position, transform.position) <= 1f)
            {
                index++;
            }
        }

    }
}