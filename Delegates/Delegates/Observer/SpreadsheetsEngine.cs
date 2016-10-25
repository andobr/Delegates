using System;
using System.Collections.Generic;

namespace Delegates
{
    class SpreadsheetsEngine : IObservable
    {
        int?[,] cells;

        List<IObserver> observers;

        public int Rows
        {
            get { return cells.GetLength(0); }
        }

        public int Columns
        {
            get { return cells.GetLength(1); }
        }

        public int? this[int row, int column]
        {
            get
            {
                CheckIndex(row + 1, column + 1);
                return cells[row, column];
            }
        }


        public SpreadsheetsEngine(int rows, int columns)
        {
            cells = new int?[rows, columns];
            observers = new List<IObserver>();

            for (int x = 0; x < rows; x++)
                for (int y = 0; y < columns; y++)
                    cells[x, y] = null;
        }

        public void Put(int row, int column, int value)
        {
            CheckIndex(row + 1, column + 1);
            cells[row, column] = value;
            NotifyObservers(new UpdatedInfo { updatedRowIndex = row, updatedColumnIndex = column, updatedValue = value });
        }

        public void InsertRow(int rowIndex)
        {
            CheckIndex(rowIndex, 0);

            var result = new int?[Rows + 1, Columns];

            Array.Copy(cells, result, rowIndex * Columns);
            Array.Copy(cells, rowIndex * Columns, result, rowIndex * Columns + Columns, Rows * Columns - rowIndex * Columns);

            for (int y = 0; y < Columns; y++)
                result[rowIndex, y] = null; 
                     
            cells = result;

            NotifyObservers(new UpdatedInfo { newRow = rowIndex });
        }

        public void InsertColumn(int columnIndex)
        {
            CheckIndex(0, columnIndex);
            var result = new int?[Rows, Columns + 1];
            for (int x = 0; x < Rows; x++)
            {
                Array.Copy(cells, x * Columns, result, x * (Columns + 1), columnIndex);
                Array.Copy(cells, x * Columns + columnIndex, result, x * (Columns + 1) + columnIndex + 1, Columns - columnIndex);
                result[x, columnIndex] = null;               
            }
            cells = result;
            NotifyObservers(new UpdatedInfo { newColumn = columnIndex });
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

        public void NotifyObservers(UpdatedInfo info)
        {
            foreach (IObserver o in observers)
                o.Update(info);
        }

        private void CheckIndex(int row, int column)
        {
            if (row > Rows || column > Columns || row < 0 || column < 0)
                throw new ArgumentException($"Индекс должен быть положительным и не превышать размеры таблицы {Rows}x{Columns}");
        }
    }
}
