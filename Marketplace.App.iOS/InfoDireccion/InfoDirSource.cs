using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS.InfoDireccion
{
    
    internal class InfoDirSource : UITableViewSource
    {
        string cellIdentifier;
        private Dictionary<string, List<string>> oneData;

        public InfoDirSource(Dictionary<string, List<string>> oneData, string v)
        {
            this.oneData = oneData;
            cellIdentifier = v;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (InfoDirTableCell)tableView.DequeueReusableCell(cellIdentifier, indexPath);
            cell.FillOptions(oneData, indexPath);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (cellIdentifier == "OneInfoDirTableCell")
            {
                return oneData["oneTitle"].Count;
            }
            else
            {
                return oneData["twoTitle"].Count;
            }
        }

        
    }
}
