using Network;
using UnityEngine;
using VContainer;

namespace Player.Views
{
	public class PlayerSpawner : MonoBehaviour
	{
		[Inject] private INetworkService networkService;

		[SerializeField] private Transform[] spawnPoints;
		[SerializeField] private PlayerView  playerPrefab;

		private void Start()
		{
			// Instantiate(playerPrefab, spawnPoints[0].position, Quaternion.identity);
		}
	}
}