using System;
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
		}
	}

	[Serializable]
	public class PlayerSettings
	{
		public PlayerMoveHandler.Settings moveSettings;
	}
}