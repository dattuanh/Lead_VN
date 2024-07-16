using System.Collections.Generic;

namespace Assets.Scripts.Hieu
{
    public class GameData
    {
        [System.Serializable]
        public class PlayerData
        {
            public string playerName;
            public int playerScore;
            public override string ToString()
            {
                return $"{playerName} {playerScore}";
            }
        }

        [System.Serializable]
        public class ListPlayers
        {
            public List<PlayerData> players = new List<PlayerData>();
        }
    }
}
