using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using ObjCRuntime;

namespace Marketplace.App.iOS
{
    public partial class FilterOrdersViewController : UIViewController
    {
        public FilterOrdersViewController (IntPtr handle) : base (handle)
        {

        }

        UIDatePicker datePickerOne = new UIDatePicker();
        UIDatePicker datePickerTwo = new UIDatePicker();
        UIView datePickerShow = new UIView();
        UIButton hidePicker = new UIButton();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            HandleButtons();
            DrawingViews();

            var tipo = new List<string>()
            {
                "Generada",
                "Atendida", 
                "Facturación en proceso",
                "Facturada"
            };

            var periodo = new List<string>()
            {
                "Últimos 10 días",
                "Mes anterior",
                "Personalizado"
            };

            TypeTableViewSource tipos = new TypeTableViewSource(tipo, this);
            TypeTableView.Source = tipos;
            PeriodTableViewSource periodos = new PeriodTableViewSource(periodo, this);
            PeriodTebleView.Source = periodos;
            TypeTableView.ReloadData();
            TypeTableView.Layer.CornerRadius = 5;
            TypeTableView.TableFooterView = new UIView();
            TypeHeightCL.Constant = TypeTableView.ContentSize.Height - 25;
            PeriodTebleView.ReloadData();
            PeriodTebleView.Layer.CornerRadius = 5;
            PeriodTebleView.TableFooterView = new UIView();
            PeriodHeigthCL.Constant = PeriodTebleView.ContentSize.Height - 25;
            PeriodView.Layer.CornerRadius = 5;

            this.NavigationItem.RightBarButtonItem = new UIBarButtonItem(title: "Limpiar", style: UIBarButtonItemStyle.Plain, target: this, action: new Selector("ClearFilters:"));
        }

        [Export("ClearFilters:")]
        private void ClearFilters(UIBarButtonItem sender)
        {

        }

        private void HandleButtons()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            DateOneButton.TouchUpInside += (sender, e) => {
                window.AddSubview(datePickerShow);
                datePickerOne.Hidden = false;
                datePickerTwo.Hidden = true;
                ShowDatePicker(1);
            };
            DateTwoButton.TouchUpInside += (sender, e) => {
                window.AddSubview(datePickerShow);
                datePickerTwo.Hidden = false;
                datePickerOne.Hidden = true;
                ShowDatePicker(2);
            };

            hidePicker.TouchUpInside += (sender, e) => {
                datePickerShow.RemoveFromSuperview();
            };
        }

        private void DrawingViews()
        {
            datePickerOne.Mode = UIDatePickerMode.Date;
            datePickerOne.MaximumDate = new NSDate();
            NSDateFormatter dateFormat = new NSDateFormatter();
            dateFormat.Locale = new NSLocale("es_MX");
            dateFormat.DateFormat = "dd/MM/yyyy";
            DateOneButton.SetTitle(dateFormat.ToString(datePickerOne.Date), UIControlState.Normal);
            datePickerOne.AddTarget(this, new Selector("DateChangedOne:"), UIControlEvent.ValueChanged);

            datePickerTwo.Mode = UIDatePickerMode.Date;
            datePickerTwo.MaximumDate = new NSDate();
            DateTwoButton.SetTitle(dateFormat.ToString(datePickerOne.Date), UIControlState.Normal);
            datePickerTwo.AddTarget(this, new Selector("DateChangedTwo:"), UIControlEvent.ValueChanged);

            //dateFormat.DateFormat = "yyyy/MM/dd";
            //NSUserDefaults.StandardUserDefaults.SetString(dateFormat.ToString(datePickerOne.Date), "InitDate");
            //NSUserDefaults.StandardUserDefaults.SetString(dateFormat.ToString(datePickerOne.Date), "EndDate");
        }

        private void ShowDatePicker(int v)
        {
            datePickerShow.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Width, 200);
            hidePicker.Frame = new CoreGraphics.CGRect(0, 0, 200, 30);
            hidePicker.SetTitle("Listo", UIControlState.Normal);
            hidePicker.SetTitleColor(UIColor.Black, UIControlState.Normal);
            if (v == 1)
            {
                datePickerShow.AddSubview(datePickerOne);
            }
            else
            {
                datePickerShow.AddSubview(datePickerTwo);
            }
            
            datePickerShow.InsertSubview(hidePicker, 2);
            datePickerShow.BackgroundColor = UIColor.White;

            datePickerShow.TranslatesAutoresizingMaskIntoConstraints = false;
            datePickerShow.CenterXAnchor.ConstraintEqualTo(this.View.CenterXAnchor).Active = true;
            datePickerShow.WidthAnchor.ConstraintEqualTo(this.View.WidthAnchor).Active = true;
            datePickerShow.HeightAnchor.ConstraintEqualTo(200).Active = true;
            datePickerShow.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;

            hidePicker.TranslatesAutoresizingMaskIntoConstraints = false;
            hidePicker.TopAnchor.ConstraintEqualTo(datePickerShow.TopAnchor).Active = true;
            hidePicker.TrailingAnchor.ConstraintEqualTo(datePickerShow.TrailingAnchor, -10).Active = true;
        }

        [Export("DateChangedOne:")]
        public void DateChangedOne(UIDatePicker picker)
        {
            NSDateFormatter dateFormat = new NSDateFormatter();
            dateFormat.Locale = new NSLocale("es_MX");
            dateFormat.DateFormat = "dd/MM/yyyy";
            DateOneButton.SetTitle(dateFormat.ToString(picker.Date), UIControlState.Normal);

            dateFormat.DateFormat = "yyyy/MM/dd";
            NSUserDefaults.StandardUserDefaults.SetString(dateFormat.ToString(picker.Date), "InitDate");
        }

        [Export("DateChangedTwo:")]
        public void DateChangedTwo(UIDatePicker picker)
        {
            NSDateFormatter dateFormat = new NSDateFormatter();
            dateFormat.Locale = new NSLocale("es_MX");
            dateFormat.DateFormat = "dd/MM/yyyy";
            DateTwoButton.SetTitle(dateFormat.ToString(picker.Date), UIControlState.Normal);

            dateFormat.DateFormat = "yyyy/MM/dd";
            NSUserDefaults.StandardUserDefaults.SetString(dateFormat.ToString(picker.Date), "EndDate");
        }

        public void HidePeriod(bool hide)
        {
            lblPeriodo.Hidden = hide;
            PeriodView.Hidden = hide;
        }

        public void SetPeriod()
        {
            var checkPeriod = NSUserDefaults.StandardUserDefaults.StringForKey("OrderPeriod");
            var fInitDate = DateTime.Now;
            var fEndDate= DateTime.Now;

            if (checkPeriod != null)
            {
                var strInit = NSUserDefaults.StandardUserDefaults.StringForKey("InitDate");
                var strEnd = NSUserDefaults.StandardUserDefaults.StringForKey("EndDate");

                if (strInit != "") {
                   fInitDate = DateTime.Parse(NSUserDefaults.StandardUserDefaults.StringForKey("InitDate"));
                }

                if (strEnd != "")
                {
                    fEndDate = DateTime.Parse(NSUserDefaults.StandardUserDefaults.StringForKey("EndDate"));
                }

                DateOneButton.SetTitle(fInitDate.ToString("dd/MM/yyyy"), UIControlState.Normal);
                DateTwoButton.SetTitle(fEndDate.ToString("dd/MM/yyyy"), UIControlState.Normal);

            }
        }
    }
}