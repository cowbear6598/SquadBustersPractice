using Network.Views;
using VContainer;

namespace Network
{
	public class NetworkService : INetworkService
	{
		[Inject] private readonly NetworkManagerView networkManagerView;

		public void StartServer()
			=> networkManagerView.StartServer();

		public void StartClient()
			=> networkManagerView.StartClient();
	}
}