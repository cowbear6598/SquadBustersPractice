﻿using Player.Application.Handlers;
using Player.Infrastructure.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player.Infrastructure.VContainer
{
	public class PlayerLifetimeScope : LifetimeScope
	{
		[SerializeField] private PlayerView                 playerView;
		[SerializeField] private PlayerMoveHandler.Settings moveHandlerSettings;

		protected override void Configure(IContainerBuilder builder)
		{
			// if (!playerView.isLocalPlayer)
			// 	return;

			builder.RegisterInstance(moveHandlerSettings);

			builder.RegisterComponent(playerView);
			builder.Register<PlayerMoveHandler>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();
		}
	}
}