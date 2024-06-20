using Mirror;
using UnityEngine;

namespace Network
{
	public class CustomNetworkManager : NetworkManager
	{
		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
		{
			Debug.LogError("OnServerAddPlayer");
		}

		public override void OnServerConnect(NetworkConnectionToClient conn)
		{
			Debug.LogError("OnServerConnect");
		}

		public override void OnStartServer()
		{
			Debug.LogError("OnStartServer");
		}

		public override void OnServerDisconnect(NetworkConnectionToClient conn)
		{
			base.OnServerDisconnect(conn);

			Debug.LogError("OnServerDisconnect");
		}

		public override void OnServerReady(NetworkConnectionToClient conn)
		{
			base.OnServerReady(conn);

			Debug.LogError("OnServerReady");
		}
	}
}