using Controller.Application.Inputs;
using Controller.Infrastructure;
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
			BindScene(builder);
			BindTimeProvider(builder);
			BindController(builder);
		}

		private void BindScene(IContainerBuilder builder)
			=> builder.Register<SceneRepository>(Lifetime.Singleton);

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
	}
}