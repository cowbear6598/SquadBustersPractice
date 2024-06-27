using System.Collections.Generic;
using Mirror;

namespace Network.Application
{
	public class NetworkClientRepository
	{
		private readonly List<NetworkConnectionToClient> clients = new();

		public void AddClient(NetworkConnectionToClient conn)
			=> clients.Add(conn);

		public void RemoveClient(NetworkConnectionToClient conn)
			=> clients.Remove(conn);

		public List<NetworkConnectionToClient> GetNetworkClient()
			=> clients;
	}
}