using Network.Applications;
using Network.Applications.Handlers;
using Network.Infrastructures.Views;
using VContainer;

namespace Network.Infrastructures
{
	public class NetworkService : INetworkService
	{
		[Inject] private readonly NetworkManagerView   networkManagerView;
		[Inject] private readonly NetworkPlayerHandler playerHandler;

		public void StartServer()
			=> networkManagerView.StartServer();

		public void StartClient()
			=> networkManagerView.StartClient();

		public void RemoveAllPlayers()
			=> playerHandler.RemoveAllPlayers();
	}
}