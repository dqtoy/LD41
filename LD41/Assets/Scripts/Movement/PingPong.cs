using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Vector3 targetPos;
    public float LoopTime;

	private void Start()
	{
        Tweener tweener = transform.DOLocalMove(targetPos, LoopTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
	}

}
