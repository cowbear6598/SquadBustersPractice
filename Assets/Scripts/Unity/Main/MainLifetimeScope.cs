using System;
using Controller;
using Controller.Application.Inputs;
using Controller.Infrastructure;
using Network;
using Network.Application;
using Network.Application.Handlers;
using Network.Infrastructure;
using Network.Infrastructure.Views;
using SoapTools.SceneController;
using TimeProvider;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Unity.Main
{
	public class MainLifetimeScope : LifetimeScope
	{
		[SerializeField] private NetworkSettings networkSettings;

		protected override void Configure(IContainerBuilder builder)
		{
			BindScene(builder);
			BindNetwork(builder);
			BindTimeProvider(builder);
			BindController(builder);
		}
		private void BindScene(IContainerBuilder builder)
			=> builder.Register<SceneRepository>(Lifetime.Singleton);

		private void BindNetwork(IContainerBuilder builder)
		{
			builder.RegisterInstance(networkSettings.playerHandlerSettings);
			builder.RegisterComponentInHierarchy<NetworkManagerView>();
			builder.Register<NetworkClientRepository>(Lifetime.Singleton);
			builder.Register<NetworkPlayerHandler>(Lifetime.Singleton);
			builder.Register<NetworkService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}

		private void BindTimeProvider(IContainerBuilder builder)
		{
			builder.Register<TimeService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}

		private void BindController(IContainerBuilder builder)
		{
			builder.Register<PCInput>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();

			builder.Register<ControllerService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}

		[Serializable]
		public class NetworkSettings
		{
			public NetworkPlayerHandler.Settings playerHandlerSettings;
		}
	}
}