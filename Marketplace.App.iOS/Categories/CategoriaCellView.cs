using Foundation;
using Marketplace.App.iOS.Categories;
using Marketplace.App.iOS.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class CategoriaCellView : UICollectionViewCell
    {

        public static NSString CellID = new NSString("CategoriaCell_Id");
        public Schemas.Category.CategoryInfo CurrentCategory { get; private set; }

        public CategoriaCellView(IntPtr handle) : base(handle)
        {
        
        }
        public CategoriaCellView() : base()
        {
        }

        public void updateCell(Schemas.Category.CategoryInfo entity)
        {

            // Establecemos el texto del label dentro del collectionview
            lblName.Text = entity.Name;
            // Establecemos la imagen dentro del collectionview
            CategoryImage.Image = MarketHelper.FromUrl(entity.Image);

            // Aqui comprobamos que la imagen del modulo NUBE viene rara
            //if (entity.Id == 6)
            //{
            //    btnCategoryImage.SetImage(MarketHelper.FromUrl("https://sitioinstitucional.blob.core.windows.net/contenido-sitio/Aplicativos-internos/mktp/categories/contables.png"), UIControlState.Normal);
            //}
        }

        public void SetCategory(Schemas.Category.CategoryInfo Category)
        {
            this.CurrentCategory = Category;
        }
    }
}