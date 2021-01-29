using System.Windows.Media;

namespace Reversi
{
    public class Player
    {
        public Brush PlayerColor { get; set; }
        public int PlayerID { get; set; }

        public Player(Brush playerColor, int playerId)
        {
            PlayerColor = playerColor;
            PlayerID = playerId;
        }
    }
}