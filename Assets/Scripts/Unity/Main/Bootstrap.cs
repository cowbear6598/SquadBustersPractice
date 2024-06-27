using Network;
using Network.Applications;
using SoapTools.SceneController;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Unity.Main
{
	public class Bootstrap : MonoBehaviour
	{
		[Inject] private readonly INetworkService networkService;
		[Inject] private readonly SceneRepository sceneRepository;

		[SerializeField] private bool             IsDedicatedServer;
		[SerializeField] private AssetReference[] subScenes;

		public void Start()
		{
			if (IsDedicatedServer)
				StartServer();
			else
				StartClient();
		}

		private async void StartServer()
		{
			networkService.StartServer();

			var builder = new SceneControllerBuilder(sceneRepository);

			foreach (var subScene in subScenes)
				builder.LoadScene(subScene);

			await builder.Execute();
		}

		private void StartClient()
		{
			var builder = new SceneControllerBuilder(sceneRepository);

			builder.LoadScene(subScenes[0])
			       .Execute();
		}
	}
}