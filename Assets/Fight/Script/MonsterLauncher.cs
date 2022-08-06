using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MonsterLauncher : MonoBehaviour
{
    [SerializeField] private Monster _monsterPrefab;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private WayPoints _path;
    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
            {
                Monster m = _monsterPrefab.Spawn(this.gameObject.transform);
                m.SetPath(_path);
                m.transform.localScale = Vector2.one;
                m.transform.localPosition = _startPosition.localPosition;
            })
            .AppendInterval(3)
            .SetLoops(10);
    }
}
