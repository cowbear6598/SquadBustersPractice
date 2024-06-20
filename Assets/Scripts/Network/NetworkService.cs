using VContainer;

namespace Network
{
	public class NetworkService : INetwork
	{
		[Inject] private readonly CustomNetworkManager networkManager;

		public void StartServer()
			=> networkManager.StartServer();

		public void StartClient()
			=> networkManager.StartClient();
	}
}