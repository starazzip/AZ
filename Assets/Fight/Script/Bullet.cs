using System;
using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    private Transform target;
    private Monster targetMonster;
    private GameObject MonsterContainer;
    private float speed = 100f;
    public int damage { get; private set; } = 2;
    private Tweener m_tweener;
    private float m_tweenerStartTime;
    private void Awake()
    {
        speed = 300f;
        MonsterContainer = GameObject.Find("Cav_Monsters");
    }
    void OnEnable()
    {
        targetMonster = MonsterContainer.gameObject.GetComponentInChildren<Monster>();
        target = targetMonster.transform;
        m_tweenerStartTime = Time.time;
        float duration = CaculateDuration();
        m_tweener = transform
            .DOMove(target.transform.position, duration)
            .OnUpdate(() =>
                {
                    float tt = Mathf.Clamp(duration - Time.time + m_tweenerStartTime, 0, duration);
                    m_tweener.ChangeEndValue(target.transform.position, tt, true);
                })
            .SetEase(Ease.Linear);
    }
    private void Update()
    {
        if (targetMonster == null || targetMonster.IsDead)
        {
            gameObject.Recycle();
        }
    }
    private float CaculateDuration()
    {
        return Vector2.Distance(this.transform.position, target.transform.position) / speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            gameObject.Recycle();
        }
    }
}