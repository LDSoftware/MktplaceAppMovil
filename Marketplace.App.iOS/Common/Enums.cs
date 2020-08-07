using System;
namespace Marketplace.App.iOS.Common
{
    [Flags]
    public enum FilterOrderType
    {
        ByDistributor=0,
        ByCid=1
    }

    [Flags]
    public enum ComesFrom
    {
        ByCategory = 0,
        BySearch = 1
    }
}
