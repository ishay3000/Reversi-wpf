using System.Windows.Media;

namespace Reversi
{
    public class Player
    {
        public Brush PlayerColor { get; set; }
        public int PlayerId { get; set; }
        public string PlayerColorName { get; set; }
        public int Score { get; set; } = 0;

        public Player(Brush playerColor, int playerId, string colorName)
        {
            PlayerColor = playerColor;
            PlayerId = playerId;
            PlayerColorName = colorName;
        }
    }
}