using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS
{
    internal class PeriodTableViewSource : UITableViewSource
    {
        private List<string> periodo;
        private FilterOrdersViewController filterOrdersViewController;

        string CellId = "PeriodCellView";

        public PeriodTableViewSource(List<string> periodo, FilterOrdersViewController filterOrdersViewController)
        {
            this.periodo = periodo;
            this.filterOrdersViewController = filterOrdersViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (PeriodCellView)tableView.DequeueReusableCell(CellId, indexPath);
            cell.FillOptions(periodo, indexPath);

            //Si ya existe una opcion seleccionada
            var checkPeriod = NSUserDefaults.StandardUserDefaults.StringForKey("OrderPeriod");

            if (checkPeriod != null)
            {
                var statusRow = periodo[indexPath.Row];

                if (statusRow == checkPeriod)
                {
                    cell.SelectOption();
                    tableView.SelectRow(indexPath, false, UITableViewScrollPosition.None);

                    if (statusRow == "Personalizado")
                    {
                        filterOrdersViewController.HidePeriod(false);
                        filterOrdersViewController.SetPeriod();
                    }
                    else
                    {
                        filterOrdersViewController.HidePeriod(true);
                    }
                }
            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return periodo.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            PeriodCellView customCell = tableView.CellAt(indexPath) as PeriodCellView;
            customCell.SelectOption();
            var status = periodo[indexPath.Row];

            if (status == "Personalizado")
            {
                filterOrdersViewController.HidePeriod(false);
                filterOrdersViewController.SetPeriod();
            }
            else {
                filterOrdersViewController.HidePeriod(true);
            }
            
            NSUserDefaults.StandardUserDefaults.SetString(status, "OrderPeriod");
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            PeriodCellView customCell = tableView.CellAt(indexPath) as PeriodCellView;
            customCell.DeselectOption();
        }
    }
}