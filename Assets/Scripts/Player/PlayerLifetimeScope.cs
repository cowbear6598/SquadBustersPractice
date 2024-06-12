using Player.Handlers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player
{
	public class PlayerLifetimeScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			// builder.RegisterComponentInNewPrefab(prefab, Lifetime.Scoped);
			// builder.Register<PlayerMoveHandler>(Lifetime.Scoped)
			//        .AsImplementedInterfaces()
			//        .AsSelf();
		}
	}
}