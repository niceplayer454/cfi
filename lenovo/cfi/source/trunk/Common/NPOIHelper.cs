using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common;

using System.IO;
using System.Configuration;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;


namespace Lenovo.CFI.BLL
{
    public class NPOIHelper
    {
        public static string GetCellStringValue(Cell cell)
        {
            if (cell == null) return null;

            string value = null;

            switch ((int)cell.CellType)
            {
                case 0: // NUMERIC
                    //if (cell.CellStyle.DataFormat != 0)
                    //    value = cell.DateCellValue.ToString("yyyy-MM-dd");
                    //else
                        value = cell.NumericCellValue.ToString();
                    break;
                case 1: // STRING
                    value = cell.StringCellValue;
                    break;
                case 2: // FORMULA
                    value = cell.StringCellValue;
                    break;
                case 3: // BLANK
                    value = null;
                    break;
                case 4: // BOOLEAN
                    value = cell.BooleanCellValue ? "1" : "0";
                    break;
                case 5:
                    value = null;
                    break;
                default:
                    value = null;
                    break;
            }

            if (value != null)
            {
                value = value.Trim();
                if (value == String.Empty) value = null;
            }

            return value;
        }

        /// <summary>
        /// 根据系统模板创建HSSFWorkbook
        /// </summary>
        /// <param name="relativeFileName">模板文件名</param>
        /// <returns></returns>
        public static Workbook CreateWorkbookFromTemplate(string absoluteFileName)
        {
            using (FileStream file = new FileStream(absoluteFileName, FileMode.Open, FileAccess.Read))
            {
                return new HSSFWorkbook(file);
            }
        }

        /// <summary>
        /// 将HSSFWorkbook保存为Excel文件
        /// </summary>
        /// <param name="dirPath">目录名称（结尾不含目录分隔符）</param>
        /// <param name="fileName">文件名称（不含后缀）</param>
        /// <param name="workbook"></param>
        /// <returns></returns>
        public static string SaveWorkbookToExcel(string dirPath, string fileName, Workbook workbook)
        {
            return SaveWorkbookToExcel(dirPath, fileName, workbook, true);
        }

        /// <summary>
        /// 将HSSFWorkbook保存为Excel文件
        /// </summary>
        /// <param name="dirPath">目录名称（结尾不含目录分隔符）</param>
        /// <param name="fileName">文件名称（不含后缀）</param>
        /// <param name="workbook"></param>
        /// <param name="ensureDir"></param>
        /// <returns></returns>
        public static string SaveWorkbookToExcel(string dirPath, string fileName, Workbook workbook, bool ensureDir)
        {
            if (ensureDir && !Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

            string filePath = dirPath + Path.DirectorySeparatorChar + fileName + ".xls";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fs);
                fs.Close();
            }

            return filePath;
        }

        public static string SaveWorkbookToExcel(string filePath, Workbook workbook, bool ensureDir)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (ensureDir && !Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fs);
                fs.Close();
            }

            return filePath;
        }

        /// <summary>
        /// 将HSSFWorkbook保存为Excel文件，并使用临时目录和随机文件名
        /// </summary>
        /// <param name="workbook"></param>
        /// <returns></returns>
        public static string SaveWorkbookToExcelWithRandomName(Workbook workbook)
        {
            return SaveWorkbookToExcel(Path.GetTempPath(), Path.GetRandomFileName(), workbook);
        }


        public static void SetCellStyle(CellStyle cellStyle, CellBorderType borderType)
        {
            cellStyle.BorderTop = borderType;
            cellStyle.BorderBottom = borderType;
            cellStyle.BorderLeft = borderType;
            cellStyle.BorderRight = borderType;
        }

        public static void SetCellStyle(CellStyle cellStyle, CellBorderType borderType, HorizontalAlignment hAlign)
        {
            cellStyle.BorderTop = borderType;
            cellStyle.BorderBottom = borderType;
            cellStyle.BorderLeft = borderType;
            cellStyle.BorderRight = borderType;
            cellStyle.Alignment = hAlign;
        }

        public static void SetCellStyle(CellStyle cellStyle, CellBorderType borderType, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            cellStyle.BorderTop = borderType;
            cellStyle.BorderBottom = borderType;
            cellStyle.BorderLeft = borderType;
            cellStyle.BorderRight = borderType;
            cellStyle.Alignment = hAlign;
            cellStyle.VerticalAlignment = vAlign;
        }

        public static void SetCellStyle(CellStyle cellStyle, short bColor, short fColor, FillPatternType pattern)
        {
            cellStyle.FillBackgroundColor = bColor;          // 47
            cellStyle.FillForegroundColor = fColor;          // 64
            cellStyle.FillPattern = pattern;
        }












        /*


        public static void copyRow(HSSFSheet sheet, HSSFRow oldRow, HSSFRow newRow)
        {
            Set mergedRegions = new HashSet();
            if (oldRow.getHeight() >= 0)
            {
                newRow.Height = oldRow.Height;
            }
            for (int j = oldRow.getFirstCellNum(); j <= oldRow.getLastCellNum(); j++)
            {
                HSSFCell oldCell = oldRow.getCell(j);
                HSSFCell newCell = newRow.getCell(j);
                if (oldCell != null)
                {
                    if (newCell == null)
                    {
                        newCell = newRow.createCell(j);
                    }
                    copyCell(oldCell, newCell, true);
                    CellRangeAddress mergedRegion = getMergedRegion(sheet, oldRow
                            .getRowNum(), oldCell.getColumnIndex());
                    if (mergedRegion != null)
                    {
                        CellRangeAddress newMergedRegion = new CellRangeAddress(
                                newRow.getRowNum(), newRow.getRowNum()
                                        + mergedRegion.getLastRow()
                                        - mergedRegion.getFirstRow(), mergedRegion
                                        .getFirstColumn(), mergedRegion
                                        .getLastColumn());
                        if (isNewMergedRegion(newMergedRegion, mergedRegions))
                        {
                            mergedRegions.add(newMergedRegion);
                            sheet.addMergedRegion(newMergedRegion);
                        }
                    }
                }
            }
        }

        public static void copyRow(HSSFSheet srcSheet, HSSFSheet destSheet,
                HSSFRow srcRow, HSSFRow destRow)
        {
            Set mergedRegions = new TreeSet();
            if (srcRow.getHeight() >= 0)
            {
                destRow.setHeight(srcRow.getHeight());
            }
            for (int j = srcRow.getFirstCellNum(); j <= srcRow.getLastCellNum(); j++)
            {
                HSSFCell oldCell = srcRow.getCell(j);
                HSSFCell newCell = destRow.getCell(j);
                if (oldCell != null)
                {
                    if (newCell == null)
                    {
                        newCell = destRow.createCell(j);
                    }
                    copyCell(oldCell, newCell, true);
                    CellRangeAddress mergedRegion = getMergedRegion(srcSheet,
                            srcRow.getRowNum(), oldCell.getColumnIndex());
                    if (mergedRegion != null)
                    {
                        // Region newMergedRegion = new Region( destRow.getRowNum(),
                        // mergedRegion.getColumnFrom(),
                        // destRow.getRowNum() + mergedRegion.getRowTo() -
                        // mergedRegion.getRowFrom(), mergedRegion.getColumnTo() );
                        CellRangeAddress newMergedRegion = new CellRangeAddress(
                                mergedRegion.getFirstRow(), mergedRegion
                                        .getLastRow(), mergedRegion
                                        .getFirstColumn(), mergedRegion
                                        .getLastColumn());
                        if (isNewMergedRegion(newMergedRegion, mergedRegions))
                        {
                            mergedRegions.add(newMergedRegion);
                            destSheet.addMergedRegion(newMergedRegion);
                        }
                    }
                }
            }
        }

        public static void copyRow(HSSFSheet srcSheet, HSSFSheet destSheet,
                HSSFRow srcRow, HSSFRow destRow, String expressionToReplace,
                String expressionReplacement)
        {
            Set mergedRegions = new HashSet();
            if (srcRow.getHeight() >= 0)
            {
                destRow.setHeight(srcRow.getHeight());
            }
            for (int j = srcRow.getFirstCellNum(); j <= srcRow.getLastCellNum(); j++)
            {
                HSSFCell oldCell = srcRow.getCell(j);
                HSSFCell newCell = destRow.getCell(j);
                if (oldCell != null)
                {
                    if (newCell == null)
                    {
                        newCell = destRow.createCell(j);
                    }
                    copyCell(oldCell, newCell, true, expressionToReplace,
                            expressionReplacement);
                    CellRangeAddress mergedRegion = getMergedRegion(srcSheet,
                            srcRow.getRowNum(), oldCell.getColumnIndex());
                    if (mergedRegion != null)
                    {
                        // Region newMergedRegion = new Region( destRow.getRowNum(),
                        // mergedRegion.getColumnFrom(),
                        // destRow.getRowNum() + mergedRegion.getRowTo() -
                        // mergedRegion.getRowFrom(), mergedRegion.getColumnTo() );
                        CellRangeAddress newMergedRegion = new CellRangeAddress(
                                mergedRegion.getFirstRow(), mergedRegion
                                        .getLastRow(), mergedRegion
                                        .getFirstColumn(), mergedRegion
                                        .getLastColumn());
                        if (isNewMergedRegion(newMergedRegion, mergedRegions))
                        {
                            mergedRegions.add(newMergedRegion);
                            destSheet.addMergedRegion(newMergedRegion);
                        }
                    }
                }
            }
        }

        public static void copySheets(HSSFSheet newSheet, HSSFSheet sheet)
        {
            int maxColumnNum = 0;
            for (int i = sheet.getFirstRowNum(); i <= sheet.getLastRowNum(); i++)
            {
                HSSFRow srcRow = sheet.getRow(i);
                HSSFRow destRow = newSheet.createRow(i);
                if (srcRow != null)
                {
                    Util.copyRow(sheet, newSheet, srcRow, destRow);
                    if (srcRow.getLastCellNum() > maxColumnNum)
                    {
                        maxColumnNum = srcRow.getLastCellNum();
                    }
                }
            }
            for (int i = 0; i <= maxColumnNum; i++)
            {
                newSheet.setColumnWidth(i, sheet.getColumnWidth(i));
            }
        }

        public static void copySheets(HSSFSheet newSheet, HSSFSheet sheet,
                String expressionToReplace, String expressionReplacement)
        {
            int maxColumnNum = 0;
            for (int i = sheet.getFirstRowNum(); i <= sheet.getLastRowNum(); i++)
            {
                HSSFRow srcRow = sheet.getRow(i);
                HSSFRow destRow = newSheet.createRow(i);
                if (srcRow != null)
                {
                    Util.copyRow(sheet, newSheet, srcRow, destRow,
                            expressionToReplace, expressionReplacement);
                    if (srcRow.getLastCellNum() > maxColumnNum)
                    {
                        maxColumnNum = srcRow.getLastCellNum();
                    }
                }
            }
            for (int i = 0; i <= maxColumnNum; i++)
            {
                newSheet.setColumnWidth(i, sheet.getColumnWidth(i));
            }
        }

        public static void copyCell(HSSFCell oldCell, HSSFCell newCell,
                bool copyStyle)
        {
            if (copyStyle)
            {
                newCell.setCellStyle(oldCell.getCellStyle());
            }
            switch (oldCell.getCellType())
            {
                case HSSFCell.CELL_TYPE_STRING:
                    newCell.setCellValue(oldCell.getRichStringCellValue());
                    break;
                case HSSFCell.CELL_TYPE_NUMERIC:
                    newCell.setCellValue(oldCell.getNumericCellValue());
                    break;
                case HSSFCell.CELL_TYPE_BLANK:
                    newCell.setCellType(HSSFCell.CELL_TYPE_BLANK);
                    break;
                case HSSFCell.CELL_TYPE_BOOLEAN:
                    newCell.setCellValue(oldCell.getBooleanCellValue());
                    break;
                case HSSFCell.CELL_TYPE_ERROR:
                    newCell.setCellErrorValue(oldCell.getErrorCellValue());
                    break;
                case HSSFCell.CELL_TYPE_FORMULA:
                    newCell.setCellFormula(oldCell.getCellFormula());
                    break;
                default:
                    break;
            }
        }

        public static void copyCell(HSSFCell oldCell, HSSFCell newCell,
                bool copyStyle, String expressionToReplace,
                String expressionReplacement)
        {
            if (copyStyle)
            {
                newCell.setCellStyle(oldCell.getCellStyle());
            }
            switch (oldCell.getCellType())
            {
                case HSSFCell.CELL_TYPE_STRING:
                    String oldValue = oldCell.getRichStringCellValue().getString();
                    newCell.setCellValue(new HSSFRichTextString(oldValue.replaceAll(
                            expressionToReplace, expressionReplacement)));
                    break;
                case HSSFCell.CELL_TYPE_NUMERIC:
                    newCell.setCellValue(oldCell.getNumericCellValue());
                    break;
                case HSSFCell.CELL_TYPE_BLANK:
                    newCell.setCellType(HSSFCell.CELL_TYPE_BLANK);
                    break;
                case HSSFCell.CELL_TYPE_BOOLEAN:
                    newCell.setCellValue(oldCell.getBooleanCellValue());
                    break;
                case HSSFCell.CELL_TYPE_ERROR:
                    newCell.setCellErrorValue(oldCell.getErrorCellValue());
                    break;
                case HSSFCell.CELL_TYPE_FORMULA:
                    newCell.setCellFormula(oldCell.getCellFormula());
                    break;
                default:
                    break;
            }
        }



        */
    }

}
