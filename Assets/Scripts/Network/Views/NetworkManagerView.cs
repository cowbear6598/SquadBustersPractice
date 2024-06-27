using Mirror;
using Network.Handlers;
using UnityEngine;
using VContainer;

namespace Network.Views
{
	public class NetworkManagerView : NetworkManager
	{
		[Inject] private readonly NetworkClientRepository repository;

		[SerializeField] private GameObject networkPlayerPrefab;

		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
		{
			Debug.Log("OnServerAddPlayer");

			base.OnServerAddPlayer(conn);
		}

		public override void OnServerConnect(NetworkConnectionToClient conn)
		{
			Debug.Log("OnServerConnect");

			repository.AddClient(conn);

			var player = Instantiate(networkPlayerPrefab);

			NetworkServer.AddPlayerForConnection(conn, player);

			base.OnServerConnect(conn);
		}

		public override void OnStartClient()
		{
			Debug.Log("OnStartClient");

			base.OnStartClient();
		}

		public override void OnServerDisconnect(NetworkConnectionToClient conn)
		{
			repository.RemoveClient(conn);

			base.OnServerDisconnect(conn);

			Debug.Log("OnServerDisconnect");
		}

		public override void OnStartServer()
		{
			base.OnStartServer();

			Debug.Log("OnStartServer");
		}

		public override void OnServerReady(NetworkConnectionToClient conn)
		{
			base.OnServerReady(conn);

			Debug.Log("OnServerReady");
		}
	}
}