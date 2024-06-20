using Controller;
using Network;
using Network.Handlers;
using Network.Views;
using SoapTools.SceneController;
using TimeProvider;
using VContainer;
using VContainer.Unity;

namespace Unity.Main
{
	public class MainLifetimeScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<SceneRepository>(Lifetime.Singleton);

			BindNetwork(builder);
			BindTimeProvider(builder);
			BindController(builder);
		}

		private static void BindNetwork(IContainerBuilder builder)
		{
			builder.RegisterComponentInHierarchy<NetworkManagerView>();
			builder.Register<NetworkClientRepository>(Lifetime.Singleton);
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