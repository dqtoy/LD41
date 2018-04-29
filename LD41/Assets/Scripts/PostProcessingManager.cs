using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingManager : SingletonBehaviour<PostProcessingManager> {

    public PostProcessingBehaviour postProcessingBehaviour;
    public AmplifyColorEffect amplifyColorEffect;

	private void Start()
	{
        InitDOF();
	}

	private void Update()
	{
	}

	public void ChangeDOFSetting(float focusDistance, float aperture, float focalLength)
    {
        var dofSettings = postProcessingBehaviour.profile.depthOfField.settings;
        dofSettings.focusDistance = focusDistance;
        dofSettings.aperture = aperture;
        dofSettings.focalLength = focalLength;
        postProcessingBehaviour.profile.depthOfField.settings = dofSettings;
    }

    public void ChangeDOFToNear()
    {
        ChangeDOFSetting(10, 3.5f, 90);
    }

    public void ChangeDOFToFar()
    {
        ChangeDOFSetting(35, 3, 150);
    }

    public void InitDOF()
    {
        ChangeDOFSetting(10, 3.5f, 90);
    }

    public void SpecialDOFEffect()
    {
        StartCoroutine(PlayDOFEffectCoroutine());
    }

    private IEnumerator PlayDOFEffectCoroutine()
    {
        yield return new WaitForSeconds(10);
        ChangeDOFToFar();
        yield return new WaitForSeconds(4);
        ChangeDOFToNear();

    }

    public void UpdateGray(float amount)
    {
        amplifyColorEffect.BlendAmount = amount;
    }
}
