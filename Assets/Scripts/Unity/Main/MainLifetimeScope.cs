using Controller;
using Network;
using TimeProvider;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Unity.Main
{
	public class MainLifetimeScope : LifetimeScope
	{
		[SerializeField] private Bootstrap.Settings bootstrapSettings;

		protected override void Configure(IContainerBuilder builder)
		{
			BindNetwork(builder);
			BindBootstrap(builder);
			BindTimeProvider(builder);
			BindController(builder);
		}

		private static void BindNetwork(IContainerBuilder builder)
		{
			builder.RegisterComponentInHierarchy<CustomNetworkManager>();
			builder.Register<NetworkService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}
		private void BindBootstrap(IContainerBuilder builder)
		{
			builder.RegisterInstance(bootstrapSettings);
			builder.RegisterEntryPoint<Bootstrap>();
		}

		private static void BindTimeProvider(IContainerBuilder builder)
		{
			builder.Register<TimeService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}

		private static void BindController(IContainerBuilder builder)
		{
			builder.Register<ControllerService>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}
	}
}