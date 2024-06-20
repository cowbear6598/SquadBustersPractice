using Network;
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
				networkService.StartClient();
		}

		private async void StartServer()
		{
			networkService.StartServer();

			var builder = new SceneControllerBuilder(sceneRepository);

			foreach (var subScene in subScenes)
				builder.LoadScene(subScene);

			await builder.Execute();
		}
	}
}