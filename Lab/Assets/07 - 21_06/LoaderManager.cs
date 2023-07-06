using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaeraManager :MonoBehaviourSingleton<CamaeraManager>
{
	void ProcessInputContrller()
	{

	}

	void ProcessInputMouseAndKeyboard()
	{

	}
}


public class LoaderManager : MonoBehaviourSingleton<LoaderManager>
{
	public float loadingProgress;
	public float timeLoading;
	public float minTimeToLoad = 2;

	public static event Action OnLevelFinishedLoading;

	public void LoadScene(string sceneName)
	{
		StartCoroutine(AsynchronousLoadWithFake(sceneName));
	}

	IEnumerator AsynchronousLoadWithFake(string scene)
	{
		loadingProgress = 0;
		timeLoading = 0;
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
		ao.allowSceneActivation = false;

		while (!ao.isDone)
		{
			timeLoading += Time.deltaTime;
			loadingProgress = ao.progress + 0.1f;
			loadingProgress = loadingProgress * timeLoading / minTimeToLoad;

			// Loading completed
			if (loadingProgress >= 1)
			{
				ao.allowSceneActivation = true;
				OnLevelFinishedLoading?.Invoke();
			}

			yield return null;
		}
	}
}
