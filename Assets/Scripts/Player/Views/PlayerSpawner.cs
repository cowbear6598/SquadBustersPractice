using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player.Views
{
	public class PlayerSpawner : MonoBehaviour
	{
		[SerializeField] private Transform[] spawnPoints;
		[SerializeField] private PlayerView  playerPrefab;

		private void Start()
			=> Instantiate(playerPrefab, spawnPoints[0].position, Quaternion.identity);
	}
}