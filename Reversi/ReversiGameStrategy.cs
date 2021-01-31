using System;
using System.Collections.Generic;

namespace Reversi
{
    class Offset
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Offset(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    public static class ReversiGameStrategy
    {
        private static int _boardSize;
        private static int _currentAnchorTile;
        public static List<List<Tile>> GameTiles;
        private static List<Tile> _opponentTiles;
        private static Dictionary<string, Offset> _directionsDictionary;


        public static void InitializeStrategy(List<List<Tile>> tiles, int boardSize)
        {
            GameTiles = tiles;
            _opponentTiles = new List<Tile>();
            _boardSize = boardSize;
            _directionsDictionary = new Dictionary<string, Offset>()
            {
                {"right", new Offset(0, 1)},
                {"left", new Offset(0, -1)},
                {"up", new Offset(-1, 0)},
                {"down", new Offset(1, 0)},
                {"south west", new Offset(1, -1)},
                {"south east", new Offset(1, 1)},
                {"north west", new Offset(-1, -1)},
                {"north east", new Offset(-1, 1)}
            };
        }

        public static bool StartConquering(Player player, int conqueringTile)
        {
            _currentAnchorTile = conqueringTile;

            foreach (KeyValuePair<string, Offset> direction in _directionsDictionary)
            {
                // FindOpponentTiles(direction.Value, player);
            }

            // if (_opponentTiles.Count > 0)
            // {
            //     GameTiles[_currentAnchorTile].Conquer(player);
            //     foreach (Tile opponentTile in _opponentTiles)
            //     {
            //         opponentTile.Conquer(player);
            //     }
            //     _opponentTiles.Clear();
            //
            //     return true;
            // }
            // else
            // {
            //     return false;
            // }
            return false;
        }

        private static bool IsValidTile(int index)
        {
            return index > 0 && index < GameTiles.Count;
        }

        private static void FindOpponentTiles(int offset, Player player)
        {
            /*List<Tile> opponentTiles = new List<Tile>();
            int startIndex = _currentAnchorTile;
            bool encounteredBlankTile = false, encounteredAllyTile = false;
            do
            {
                startIndex += offset;
                if (!IsValidTile(startIndex))
                {
                    break;
                }
                var tile = GameTiles[startIndex];
                if (!tile.Conquered)
                {
                    encounteredBlankTile = true;
                    break;
                }
                if (tile.OccupyingPlayer.PlayerId == player.PlayerId)
                {
                    encounteredAllyTile = true;
                    break;
                }

                opponentTiles.Add(GameTiles[startIndex]);
            } while (startIndex % _boardSize != 0);

            if (encounteredBlankTile || !encounteredAllyTile)
            {
                return;
            }

            foreach (Tile opponentTile in opponentTiles)
            {
                _opponentTiles.Add(opponentTile);
            }*/
        }

        public static bool PlayerHasMovesLeft(Player player)
        {
            /*for (int i = 0; i < GameTiles.Count; i++)
            {
                if (GameTiles[i].Conquered)
                {
                    continue;
                }

                _currentAnchorTile = i;
                foreach (KeyValuePair<string, int> direction in _directionsDictionary)
                {
                    FindOpponentTiles(direction.Value, player);
                    if (_opponentTiles.Count > 0)
                    {
                        _opponentTiles.Clear();
                        return true;
                    }
                }
            }

            return false;*/
            return false;
        }
    }
}