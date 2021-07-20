using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

using FinalBoss.Database.Services;
using FinalBoss.ObjectModel;
using System.Linq;

namespace FinalBoss.Database.Sync
{
    public class TableImporter
    {
        private readonly string _spreadsheetId;

        public TableImporter(string spreadsheetId)
        {
            _spreadsheetId = spreadsheetId;
        }

        public Task<bool> ImportAsync<TEntity, TService>(SheetsService sheetsService, string sheetName, TService service)
            where TEntity : BaseEntity
            where TService : IService<TEntity>, IServiceAsync<TEntity>
        {
            string rowCountRange = $"{sheetName}!B2";

            SpreadsheetsResource.ValuesResource.GetRequest request =
                sheetsService.Spreadsheets.Values.Get(_spreadsheetId, rowCountRange);

            ValueRange response = request.Execute();

            int rowCount = int.Parse(response.Values[0][0].ToString());
            int colCount = 0;

            string headersRange = $"{sheetName}!A3:ZZ3";

            request = sheetsService.Spreadsheets.Values.Get(_spreadsheetId, headersRange);

            response = request.Execute();

            IList<IList<Object>> values = response.Values;

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
    }
}