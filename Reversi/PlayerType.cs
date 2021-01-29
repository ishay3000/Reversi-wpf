using System.Collections.Generic;
using System.Windows.Media;

namespace Reversi
{
    public enum PlayerType
    {
        BluePlayer = 0,
        RedPlayer = 1
    }

    public static class PlayerTypeToColor
    {
        private static Dictionary<PlayerType, Color> playerToColorDictionary = new Dictionary<PlayerType, Color>()
        {
            {PlayerType.BluePlayer, Colors.Blue},
            {PlayerType.RedPlayer, Colors.Red}
        };

        public static Brush GetPlayerBrush(PlayerType player)
        {
            return new SolidColorBrush(playerToColorDictionary[player]);
        }
    }
}