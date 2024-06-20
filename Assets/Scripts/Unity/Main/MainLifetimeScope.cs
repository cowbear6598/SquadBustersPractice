using Controller;
using Network;
using TimeProvider;
using VContainer;
using VContainer.Unity;

namespace Unity.Main
{
	public class MainLifetimeScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			BindNetwork(builder);
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