using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Seed.BarCodeCore.Models
{
    public class ExcelHelper : IDisposable
    {
        private readonly string _fileName = null; //文件名
        private IWorkbook _workbook = null;
        private FileStream _fs = null;
        private bool _disposed;

        public ExcelHelper(string fileName)
        {
            this._fileName = fileName;
            _disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            _fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
                _workbook = new XSSFWorkbook();
            else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                _workbook = new HSSFWorkbook();

            try
            {
                if (_workbook != null)
                {
                    sheet = _workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                _workbook.Write(_fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
                    _workbook = new XSSFWorkbook(_fs);
                else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                    _workbook = new HSSFWorkbook(_fs);

                if (sheetName != null)
                {
                    sheet = _workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = _workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = _workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_fs != null)
                        _fs.Close();
                }

                _fs = null;
                _disposed = true;
            }
        }

        //public List<NcHandSaleInfo> XlsToSale()
        //{
        //    List<NcHandSaleInfo> list = new List<NcHandSaleInfo> {};
        //    ISheet sheet = null;
        //    _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
        //    if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
        //        _workbook = new XSSFWorkbook(_fs);
        //    else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
        //        _workbook = new HSSFWorkbook(_fs);
        //    sheet = _workbook.GetSheetAt(0);
        //    if (sheet != null)
        //    {
        //        IRow firstRow = sheet.GetRow(0);
        //        var startRow = sheet.FirstRowNum + 1;
        //        //最后一列的标号
        //        int rowCount = sheet.LastRowNum;
        //        for (int i = startRow; i <= rowCount; ++i)
        //        {
        //            IRow row = sheet.GetRow(i);
        //            if (row == null) continue; //没有数据的行默认是null　　　　　　　

        //            NcHandSaleInfo code = new NcHandSaleInfo();
        //            code.BigCode = row.GetCell(0).ToString();

        //            list.Add(code);
        //        }
        //    }
        //    return list;
        //}


        public List<Sale> XlsToSales()
        {
            List<Sale> list = new List<Sale> { };
            ISheet sheet = null;

            _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
                _workbook = new XSSFWorkbook(_fs);
            else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                _workbook = new HSSFWorkbook(_fs);
            sheet = _workbook.GetSheetAt(0);
            if (sheet != null)
            {
                IRow firstRow = sheet.GetRow(0);
                var startRow = sheet.FirstRowNum + 1;
                //最后一列的标号
                int rowCount = sheet.LastRowNum;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //没有数据的行默认是null　　　　　　　

                    Sale code = new Sale();
                    code.SaleInfo = row.GetCell(1).ToString();
                    code.OrderInfo = row.GetCell(0).ToString();
                    code.CreateTime = DateTime.Now;
                    list.Add(code);
                }
            }
            return list;
        }
    }
}
