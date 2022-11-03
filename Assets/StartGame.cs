using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public string TargetSceneName;

	public void LoadTargetScene()
	{
		SceneManager.LoadScene(TargetSceneName);
	}
}
