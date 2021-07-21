using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Google.Apis.Sheets.v4;

using FinalBoss.Database.Services;
using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Sync
{
    public class TableImporter<T> where T : BaseEntity
    {
        private readonly string _spreadsheetId;

        public TableImporter(string spreadsheetId)
        {
            _spreadsheetId = spreadsheetId;
        }

        public Task<bool> ImportAsync<TService>(SheetsService sheetsService, string sheetName, TService service)
            where TService : IService<T>, IServiceAsync<T>
        {
            int rowCount = GetRowCount(sheetsService, sheetName);
            var columns = GetColumns(sheetsService, sheetName);

            var data = GetData<T>(sheetsService, sheetName, rowCount, columns.Count);

            //if (values != null && values.Count > 0)
            //{
            //    Console.WriteLine("Name, Major");
            //    foreach (var row in values)
            //    {
            //        // Print columns A and E, which correspond to indices 0 and 4.
            //        Console.WriteLine("{0}, {1}", row[0], row[4]);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No data found");
            //}

            return Task.FromResult(false);
        }

        private IList<IList<object>> GetData<T>(SheetsService sheetsService, string sheetName, int rowCount, int columnCount)
            where T : BaseEntity
        {
            string range = $"{sheetName}!A4:{GetColumnName(columnCount)}{4 - rowCount}";

            var request = sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = request.Execute();

            return response.Values;
        }

        private int GetRowCount(SheetsService sheetsService, string sheetName)
        {
            var request = sheetsService.Spreadsheets.Values.Get(_spreadsheetId, $"{sheetName}!B2");
            var response = request.Execute();

            return int.Parse(response.Values[0][0].ToString());
        }

        private IList<object> GetColumns(SheetsService sheetsService, string sheetName)
        {
            var request = sheetsService.Spreadsheets.Values.Get(_spreadsheetId, $"{sheetName}!A3:ZZZ3");
            var response = request.Execute();

            return response.Values[0];
        }

        private string GetColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = string.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
    }
}