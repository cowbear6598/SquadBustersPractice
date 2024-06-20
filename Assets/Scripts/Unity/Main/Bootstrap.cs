using System;
using Network;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Unity.Main
{
	public class Bootstrap : MonoBehaviour
	{
		[Inject] private readonly Settings settings;
		[Inject] private readonly INetwork network;

		public void Start()
		{
			if (settings.isServer)
				network.StartServer();
		}

		[Serializable]
		public class Settings
		{
			public bool           isServer;
			public AssetReference gameScene;
		}
	}
}