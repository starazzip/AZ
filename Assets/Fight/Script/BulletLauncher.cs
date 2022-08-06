using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    private GameObject MonsterContainer;
    private void Awake()
    {
        MonsterContainer = GameObject.Find("Cav_Monsters");
    }
    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            GameObject bullet = bulletPrefab.Spawn(bulletContainer.transform);
            bullet.transform.localScale = Vector3.one;
        }).AppendInterval(0.1f).SetLoops(-1);
    }
}
