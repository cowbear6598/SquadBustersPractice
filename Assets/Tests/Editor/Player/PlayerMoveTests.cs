using Controller;
using Controller.Application;
using NSubstitute;
using NUnit.Framework;
using Player;
using Player.Application.Handlers;
using Player.Infrastructure.Views;
using TimeProvider;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tests.Editor.Player
{
	[TestFixture]
	public class PlayerMoveTests
	{
		private IObjectResolver container;
		private IController     controller;
		private ITimeProvider   timeProvider;

		[SetUp]
		public void SetUp()
		{
			var settings = new PlayerMoveHandler.Settings
			{
				MoveSpeed = 1,
			};

			controller   = Substitute.For<IController>();
			timeProvider = Substitute.For<ITimeProvider>();

			var builder = new ContainerBuilder();

			builder.RegisterInstance(settings);
			builder.RegisterComponent(controller);
			builder.RegisterComponent(timeProvider);

			var playerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player.prefab");

			var playerObj = Object.Instantiate(playerPrefab);

			builder.RegisterComponent(playerObj.GetComponent<PlayerView>());
			builder.Register<PlayerMoveHandler>(Lifetime.Singleton)
			       .AsImplementedInterfaces()
			       .AsSelf();

			container = builder.Build();
		}

		[Test]
		[TestCase(1, 0, 0)]
		[TestCase(1, 5, 0)]
		[TestCase(0, 0, 1)]
		public void Should_Move_Correct(float x, float y, float z)
		{
			// Arrange
			var playerView = container.Resolve<PlayerView>();
			playerView.transform.position = Vector3.one;
			var position = new Vector3(x, y, z);

			// Act
			playerView.Move(position);

			// Assert
			Assert.AreEqual(position + Vector3.one, playerView.transform.position);
		}

		[Test]
		[TestCase(1, 0)]
		[TestCase(0, 1)]
		[TestCase(0.5f, 0)]
		public void Should_Move_Correct_By_Controller(float x, float y)
		{
			// Arrange
			var playerView  = container.Resolve<PlayerView>();
			var moveHandler = container.Resolve<PlayerMoveHandler>();
			controller.GetMoveAxis().Returns(new Vector2(x, y));
			timeProvider.GetDeltaTime().Returns(1);

			// Act
			moveHandler.Tick();

			// Assert
			Assert.AreEqual(new Vector3(x, 0, y), playerView.transform.position);
		}
	}
}