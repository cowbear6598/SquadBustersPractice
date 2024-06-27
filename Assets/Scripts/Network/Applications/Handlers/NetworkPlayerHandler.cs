using System;
using Mirror;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace Network.Applications.Handlers
{
	public class NetworkPlayerHandler
	{
		[Inject] private readonly Settings                settings;
		[Inject] private readonly NetworkClientRepository repository;

		public void SpawnMenuPlayer(NetworkConnectionToClient conn)
		{
			var player = Object.Instantiate(settings.menuNetworkPlayerPrefab);

			NetworkServer.AddPlayerForConnection(conn, player);
		}

		public void RemoveAllPlayers()
		{
			var clients = repository.GetNetworkClient();

			foreach (var client in clients)
				NetworkServer.RemovePlayerForConnection(client, RemovePlayerOptions.Destroy);
		}

		[Serializable]
		public class Settings
		{
			public GameObject menuNetworkPlayerPrefab;
			public GameObject gameNetworkPlayerPrefab;
		}
	}
}