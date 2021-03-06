﻿using System;
using System.Collections.Generic;

namespace Reversi
{
    /// המחלקה הזו מסמלת את אסטרטגיית המשחק, ומכילה את גודל הלוח, המשבצת הכובשת הנוכחית,
    /// מטריצה של משבצות הלוח, רשימת עזר של משבצות יריב, ומפה של כיוונים לבדיקת משבצות.
    public static class ReversiGameStrategy
    {
        private static int _boardSize;
        private static Tile _currentAnchorTile;
        public static List<List<Tile>> GameTiles;
        private static List<Tile> _opponentTiles;
        private static Dictionary<string, Coordination> _directionsDictionary;


        public static void InitializeStrategy(List<List<Tile>> tiles, int boardSize)
        {
            GameTiles = tiles;
            _opponentTiles = new List<Tile>();
            _boardSize = boardSize;
            _directionsDictionary = new Dictionary<string, Coordination>()
            {
                {"right", new Coordination(0, 1)},
                {"left", new Coordination(0, -1)},
                {"up", new Coordination(-1, 0)},
                {"down", new Coordination(1, 0)},
                {"south west", new Coordination(1, -1)},
                {"south east", new Coordination(1, 1)},
                {"north west", new Coordination(-1, -1)},
                {"north east", new Coordination(-1, 1)}
            };
        }

        public static bool StartConquering(Player player, Tile tile)
        {
            _currentAnchorTile = tile;

            foreach (KeyValuePair<string, Coordination> direction in _directionsDictionary)
            {
                FindOpponentTiles(direction.Value, player);
            }

            if (_opponentTiles.Count > 0)
            {
                tile.Conquer(player);
                foreach (Tile opponentTile in _opponentTiles)
                {
                    opponentTile.Conquer(player);
                }
                _opponentTiles.Clear();
            
                return true;
            }

            return false;
        }

        private static bool IsValidTile(Coordination coordination)
        {
            int row = coordination.Row, column = coordination.Column;
            return row >= 0 && row < _boardSize && column >= 0 && column < _boardSize;
        }

        private static void FindOpponentTiles(Coordination offset, Player attackerPlayer)
        {
            List<Tile> opponentTiles = new List<Tile>();
            Coordination startCoordination = new Coordination(_currentAnchorTile.Coordination);
            bool encounteredBlankTile = false, encounteredAllyTile = false;
            do
            {
                startCoordination.AddPoint(offset);
                if (!IsValidTile(startCoordination))
                {
                    break;
                }

                var tile = GameTiles[startCoordination.Row][startCoordination.Column];
                if (!tile.Conquered)
                {
                    encounteredBlankTile = true;
                    break;
                }
                if (tile.OccupyingPlayer.PlayerId == attackerPlayer.PlayerId)
                {
                    encounteredAllyTile = true;
                    break;
                }
            
                opponentTiles.Add(tile);
            } while (true);

            if (encounteredBlankTile || !encounteredAllyTile)
            {
                return;
            }

            foreach (Tile opponentTile in opponentTiles)
            {
                _opponentTiles.Add(opponentTile);
            }
        }

        public static bool PlayerHasMovesLeft(Player player)
        {
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (GameTiles[i][j].Conquered)
                    {
                        continue;
                    }

                    foreach (KeyValuePair<string, Coordination> direction in _directionsDictionary)
                    {
                        _currentAnchorTile = GameTiles[i][j];
                        FindOpponentTiles(direction.Value, player);
                        if (_opponentTiles.Count > 0)
                        {
                            _opponentTiles.Clear();
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}