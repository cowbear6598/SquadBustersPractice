using System;
using Mirror;
using Network;
using Network.Applications;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VContainer;

namespace Unity.Menu
{
	public class UI_Connect : MonoBehaviour
	{
		[Inject] private readonly INetworkService networkService;

		[SerializeField] private Button connectBtn;

		[SerializeField] private GameObject startBtn;

		private void Awake()
			=> connectBtn.onClick.AddListener(Connect);

		private void Connect()
		{
			networkService.StartClient();

			connectBtn.interactable = false;
		}
	}
}