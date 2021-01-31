namespace Reversi
{
    public class Coordination
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordination(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Coordination(Coordination coordination)
        {
            Row = coordination.Row;
            Column = coordination.Column;
        }

        public void AddPoint(Coordination coordination)
        {
            Row += coordination.Row;
            Column += coordination.Column;
        }
    }
}