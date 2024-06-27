namespace Network.Application
{
	public interface INetworkService
	{
		void StartServer();
		void StartClient();

		void RemoveAllPlayers();
	}
}