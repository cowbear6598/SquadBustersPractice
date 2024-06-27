﻿using Player.Applications.Handlers;
using Player.Infrastructures.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player.Infrastructures.VContainer
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