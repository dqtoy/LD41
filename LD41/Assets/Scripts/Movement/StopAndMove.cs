using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StopAndMove : MonoBehaviour {

    public float distance;
    public float durination;

    private bool playFinalMove;

	// Use this for initialization
	void Start () {
        playFinalMove = false;
        Move();
	}

	private void Update()
	{
        if (!playFinalMove)
            return;
        
        transform.position += transform.forward * Time.deltaTime * distance;
	}

	private void Move()
	{
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward * distance, durination).SetRelative().SetDelay(durination / 2));
        sequence.Append(transform.DOMove(transform.forward * distance, durination).SetRelative().SetDelay(durination / 2));
        sequence.Append(transform.DOMove(transform.forward * distance, durination).SetRelative().SetDelay(durination / 2));
        sequence.Append(transform.DOMove(transform.forward * distance, durination).SetRelative().SetDelay(durination / 2));
        sequence.Append(transform.DOMove(transform.forward * distance, durination).SetRelative().SetDelay(durination / 2));

        sequence.AppendCallback(() => {
            playFinalMove = true;
        });

        sequence.Play();
	}
}
