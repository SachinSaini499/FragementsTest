using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Dimensions.Database.Tables
{
  public  class BarcodeDetailsTbl
    {
        [PrimaryKey, AutoIncrement]
        public Int32 Id { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public string Barcode { get; set; }
        public string Date { get; set; }
    }
}