using System;

namespace Engine
{
	public class PlayerMission
	{
		public Mission Details{ get; set; }
		public bool IsCompleted{ get; set; }

		public PlayerMission (Mission details)
		{
			Details = details;
			IsCompleted = false;
		}

	}
}

