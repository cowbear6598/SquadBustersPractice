namespace Network.Applications
{
	public interface INetworkService
	{
		void StartServer();
		void StartClient();

		void RemoveAllPlayers();
	}
}