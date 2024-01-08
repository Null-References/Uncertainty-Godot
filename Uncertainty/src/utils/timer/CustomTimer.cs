namespace Timer
{
	public abstract class CustomTimer
	{
		protected float Duration { get; private set; }

		protected float _remainingTime;

		protected CustomTimer(float duration)
		{
			Duration = duration;
			_remainingTime = duration;
		}
		protected CustomTimer()
		{
		}

		public void ResetTimer() => _remainingTime = Duration;
		public void ResetTimer(float duration)
		{
			Duration = duration;
			_remainingTime = duration;
		}

		public abstract void Tick(float deltaTime);
	}
}
