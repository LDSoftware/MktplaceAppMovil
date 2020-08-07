using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS
{
    internal class TypeTableViewSource : UITableViewSource
    {
        string CellId = "TypeCellView";
        private List<string> tipo;
        private FilterOrdersViewController filterOrdersViewController;

        public TypeTableViewSource(List<string> tipo, FilterOrdersViewController filterOrdersViewController)
        {
            this.tipo = tipo;
            this.filterOrdersViewController = filterOrdersViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (TypeCellView)tableView.DequeueReusableCell(CellId, indexPath);
            cell.FillOptions(tipo, indexPath);
           
            //Si ya existe una opcion seleccionada
            var checkStatus = NSUserDefaults.StandardUserDefaults.StringForKey("OrderStatus");

            if (checkStatus != null)
            {
                var statusRow = tipo[indexPath.Row];

                if (statusRow == checkStatus) {
                    cell.SelectOption();
                    tableView.SelectRow(indexPath,false,UITableViewScrollPosition.None);
                }
            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tipo.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            TypeCellView customCell = tableView.CellAt(indexPath) as TypeCellView;
            customCell.SelectOption();
            var status = tipo[indexPath.Row];
            NSUserDefaults.StandardUserDefaults.SetString(status, "OrderStatus");
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            TypeCellView customCell = tableView.CellAt(indexPath) as TypeCellView;
            customCell.DeselectOption();
        }
    }
}