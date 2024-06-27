using Network.Application;
using Network.Application.Handlers;
using Network.Infrastructure.Views;
using VContainer;

namespace Network.Infrastructure
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