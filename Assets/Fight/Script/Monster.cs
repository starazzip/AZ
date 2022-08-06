using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private Slider _hp;
    private int CurrentHp = 100;
    private int MaxHp = 100;
    public bool IsDead { get; private set; }
    private MonsterMove move;
    private void Awake()
    {
        CurrentHp = 100;
        MaxHp = 100;
        _hp.value = MaxHp;
        _hp.maxValue = MaxHp;
        _hp.minValue = 0;
        move = gameObject.AddComponent<MonsterMove>();
    }
    public void SetPath(WayPoints path)
    {
        move.SetPath(path);
    }
    private void OnEnable()
    {
        IsDead = false;
    }
    private void OnDisable()
    {
        IsDead = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            Bullet b = other.gameObject.GetComponent<Bullet>();
            takedamage(b.damage);
        }
    }
    void takedamage(int damage)
    {
        CurrentHp -= damage;
        _hp.value = CurrentHp;
        if (_hp.value == 0)
        {
            gameObject.Recycle();
        }
    }
}
