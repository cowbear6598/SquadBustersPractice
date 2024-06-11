using System;
using Player;
using Player.Handlers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Unity.Game
{
	public class GameLifetimeScope : LifetimeScope
	{
		[SerializeField] private PlayerSettings playerSettings;

		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterInstance(playerSettings.moveSettings);

			builder.RegisterComponentInHierarchy<PlayerView>();
			builder.Register<PlayerMoveHandler>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}
	}

	[Serializable]
	public class PlayerSettings
	{
		public PlayerMoveHandler.Settings moveSettings;
	}
}