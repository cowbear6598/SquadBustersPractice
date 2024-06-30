using Network.Application;
using Network.Application.Handlers;
using Network.Infrastructure.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Network.Infrastructure.VContainer
{
	public class NetworkLifetimeScope : LifetimeScope
	{
		[SerializeField] private NetworkPlayerHandler.Settings playerHandlerSettings;

		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterInstance(playerHandlerSettings);
			builder.RegisterComponentInHierarchy<NetworkManagerView>();
			builder.Register<NetworkClientRepository>(Lifetime.Singleton);
			builder.Register<NetworkPlayerHandler>(Lifetime.Singleton);
			builder.Register<NetworkService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();

		}
	}
}