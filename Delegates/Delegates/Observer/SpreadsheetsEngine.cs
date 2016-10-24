using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class SpreadsheetsEngine : IObservable
    {
        List<List<int?>> cells;

        List<IObserver> observers;

        public int Rows
        {
            get { return cells.Count; }
        }

        public int Columns
        {
            get { return cells[0].Count; }
        }

        public SpreadsheetsEngine(int rows, int columns)
        {
            cells = new List<List<int?>>();
            observers = new List<IObserver>();

            for (int x = 0; x < rows; x++)
            {
                cells.Add(new List<int?>());
                for (int y = 0; y < columns; y++)
                    cells[x].Add(null);
            }
        }

        public void Put(int row, int column, int value)
        {
            CheckIndex(row + 1, column + 1);
            cells[row][column] = value;
            NotifyObservers();
        }

        public void InsertRow(int rowIndex)
        {
            CheckIndex(rowIndex, 0);
            var newRow = new List<int?>();
            for (int x = 0; x < Columns; x++)
                newRow.Add(null);
            cells.Insert(rowIndex, newRow);
            NotifyObservers();
        }

        public void InsertColumn(int columnIndex)
        {
            CheckIndex(0, columnIndex);
            foreach (var item in cells)
                item.Insert(columnIndex, null);
            NotifyObservers();
        }

        public int? Get(int row, int column)
        {
            CheckIndex(row + 1, column + 1);
            return cells[row][column];
        }

        public void RegisterObserver(IObserver o)
        {
            if (!observers.Contains(o))
                observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            if (observers.Contains(o))
                observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
                o.Update(cells);
        }

        private void CheckIndex(int row, int column)
        {
            if (row > Rows || column > Columns || row < 0 || column < 0)
                throw new ArgumentException($"Индекс должен быть положительным и не превышать размеры таблицы {Rows}x{Columns}");
        }
    }
}
