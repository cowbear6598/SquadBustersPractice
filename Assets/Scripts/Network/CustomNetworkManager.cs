using Mirror;
using UnityEngine;

namespace Network
{
	public class CustomNetworkManager : NetworkManager
	{
		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
		{
			Debug.Log("OnServerAddPlayer");
		}

		public override void OnServerConnect(NetworkConnectionToClient conn)
		{
			Debug.Log("OnServerConnect");
		}

		public override void OnStartServer()
		{
			Debug.Log("OnStartServer");
		}

		public override void OnServerReady(NetworkConnectionToClient conn)
		{
			base.OnServerReady(conn);

			Debug.Log("OnServerReady");
		}
	}
}