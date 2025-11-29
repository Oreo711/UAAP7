using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
	[SerializeField] private List<CinemachineCamera> _cameras;

	private Queue<CinemachineCamera> _cameraQueue;

	private void Awake()
	{
		_cameraQueue = new Queue<CinemachineCamera>(_cameras);
	}

	private void Update ()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			SwitchCamera();
		}
	}

	private void SwitchCamera ()
	{
		CinemachineCamera next = _cameraQueue.Dequeue();

		foreach (CinemachineCamera camera in _cameraQueue)
		{
			camera.gameObject.SetActive(false);
		}

		next.gameObject.SetActive(true);

		_cameraQueue.Enqueue(next);
	}
}
