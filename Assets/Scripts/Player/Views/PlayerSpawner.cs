using Network;
using UnityEngine;
using VContainer;

namespace Player.Views
{
	public class PlayerSpawner : MonoBehaviour
	{
		[Inject] private INetwork network;

		[SerializeField] private Transform[] spawnPoints;
		[SerializeField] private PlayerView  playerPrefab;

		private void Start()
		{
			Instantiate(playerPrefab, spawnPoints[0].position, Quaternion.identity);
		}
	}
}