using Network;
using UnityEngine;
using VContainer;

namespace Unity.Main
{
	public class Bootstrap : MonoBehaviour
	{
		[Inject] private readonly INetwork network;

		[SerializeField] private bool IsDedicatedServer;

		public void Start()
		{
			if (IsDedicatedServer)
				network.StartServer();
			else
				network.StartClient();
		}
	}
}