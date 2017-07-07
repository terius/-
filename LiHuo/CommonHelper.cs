using FGTran;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public  class CommonHelper
    {
        public static Hashtable GetDataGridViewColumns(DataGridView dgv)
        {
            Hashtable ht = new Hashtable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                ht[column.DataPropertyName] = column.HeaderText;
            }
            return ht;
        }

        public static Hashtable GetDataGridViewDisplayColumns(DataGridView dgv)
        {
            Hashtable ht = new Hashtable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    ht[column.DataPropertyName] = column.HeaderText;
                }
            }
            return ht;
        }

        public static void AddColumn(DataGridView dgv,string ColumnName,string DataName,bool readOnly = true,int width=100, DataGridViewColumnSortMode sortAble = DataGridViewColumnSortMode.NotSortable,bool isShow= true)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = column.DataPropertyName = DataName;
            column.HeaderText = ColumnName;
            column.ReadOnly = readOnly;
            column.Width = width;
            column.SortMode = sortAble;
            column.Visible = isShow;
            dgv.Columns.Add(column);
        }

        public static void AddHideColumn(DataGridView dgv, string ColumnName, string DataName)
        {
             AddColumn(dgv, ColumnName, DataName, true, 100, DataGridViewColumnSortMode.NotSortable, false);
        }
    }
}
