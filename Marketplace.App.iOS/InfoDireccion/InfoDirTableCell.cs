using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class InfoDirTableCell : UITableViewCell
    {
        public InfoDirTableCell (IntPtr handle) : base (handle)
        {
        }

        internal void FillOptions(Dictionary<string, List<string>> oneData, NSIndexPath indexPath)
        {
            

            foreach (var item in oneData)
            {
                if(item.Key == "oneTitle")
                {
                    OneTitleLabel.Text = item.Value[indexPath.Row];
                }
                if (item.Key == "oneInfo")
                {
                    OneInfoLabel.Text = item.Value[indexPath.Row];
                 }

                if (item.Key == "twoTitle")
                {
                    TwoTitleLabel.Text = item.Value[indexPath.Row];
                }

                if (item.Key == "twoInfo")
                {
                    TwoInfoLabel.Text = item.Value[indexPath.Row];
                }

            }
        }

    }
}