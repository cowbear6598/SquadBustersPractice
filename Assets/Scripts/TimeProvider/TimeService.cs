using UnityEngine;

namespace TimeProvider
{
	public class TimeService : ITimeProvider
	{
		public float GetDeltaTime() => Time.deltaTime;
	}
}