using Mirror;
using Network.Handlers;
using UnityEngine;
using VContainer;

namespace Network.Views
{
	public class NetworkManagerView : NetworkManager
	{
		[Inject] private readonly NetworkClientRepository repository;

		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
			=> Debug.Log("OnServerAddPlayer");

		public override void OnServerConnect(NetworkConnectionToClient conn)
		{
			Debug.Log("OnServerConnect");

			repository.AddClient(conn);
		}

		public override void OnClientSceneChanged() { base.OnClientSceneChanged(); }

		public override void OnStartClient()
			=> Debug.Log("OnStartClient");

		public override void OnServerDisconnect(NetworkConnectionToClient conn)
		{
			repository.RemoveClient(conn);

			base.OnServerDisconnect(conn);

			Debug.Log("OnServerDisconnect");
		}

		public override void OnStartServer()
			=> Debug.Log("OnStartServer");

		public override void OnServerReady(NetworkConnectionToClient conn)
		{
			base.OnServerReady(conn);

			Debug.Log("OnServerReady");
		}
	}
}