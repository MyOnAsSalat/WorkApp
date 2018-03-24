using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorkApp.csharp
{
    class MainViewModel
    {

        public IList<User> Items { get; }


        public async Task LoadData()
        {
            return;
        }
    }
}