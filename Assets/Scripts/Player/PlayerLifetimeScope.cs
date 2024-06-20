﻿using Player.Handlers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player
{
	public class PlayerLifetimeScope : LifetimeScope
	{
		[SerializeField] private PlayerView playerView;

		protected override void Configure(IContainerBuilder builder)
		{
			// if (!playerView.isLocalPlayer)
			// 	return;

			builder.RegisterComponent(playerView);
			builder.Register<PlayerMoveHandler>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}
	}
}