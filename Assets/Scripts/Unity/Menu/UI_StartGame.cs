﻿using Mirror;
using Network;
using Network.Application;
using SoapTools.SceneController;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using VContainer;

namespace Unity.Menu
{
	public class UI_StartGame : NetworkBehaviour
	{
		[Inject] private readonly SceneRepository sceneRepository;
		[Inject] private readonly INetworkService networkService;

		[SerializeField] private Button         startBtn;
		[SerializeField] private AssetReference gameScene;

		private void Awake()
			=> startBtn.onClick.AddListener(Cmd_StartGame);

		[Command(requiresAuthority = false)]
		private void Cmd_StartGame()
		{
			Rpc_StartGame();

			networkService.RemoveAllPlayers();
		}

		[ClientRpc]
		private async void Rpc_StartGame()
		{
			var builder = new SceneControllerBuilder(sceneRepository);

			await builder.UnloadAllScenes()
			             .LoadScene(gameScene)
			             .Execute();
		}
	}
}