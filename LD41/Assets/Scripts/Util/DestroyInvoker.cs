using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DestroyInvoker : MonoBehaviour 
{
	public UnityAction onDestroyCallback;
	public UnityAction onUpdateCallback;

	// Update is called once per frame
	void Update () 
	{
		if(onUpdateCallback != null) 
		{
			onUpdateCallback();
		}
	}

	void OnDestroy()
	{
		if(onDestroyCallback != null)
		{
			onDestroyCallback();
		}
	}
}