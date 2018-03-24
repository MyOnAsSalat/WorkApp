using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Java.Interop;
using Realms;
using WorkApp.csharp;

namespace WorkApp
{
    [Activity(Label = "WorkApp", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var realm = Realm.GetInstance();
            var usersDB = realm.All<User>().Where(x => x.userId == 1).ToList();
            if (usersDB.Any())
            {
                FindViewById<Button>(Resource.Id.load_data_button).Text = "Обновить";
                ListView listView = FindViewById<ListView>(Resource.Id.data_list_view);
                listView.Adapter = new CusotmListAdapter(this, usersDB);
            }

        }

        [Export("LoadButtonOnClick")]
        public async void LoadButtonOnClick(View a)
        {
            var vm = new MainViewModel();
            await vm.LoadData();
            listView.Adapter = new CusotmListAdapter(this, vm.Items);
            List<User> users = await Network.LoadJSON();
            ListView listView = FindViewById<ListView>(Resource.Id.data_list_view);
            listView.Adapter = new CusotmListAdapter(this, users);
            var realm = Realm.GetInstance();            
                realm.Write(() =>
                {
                    foreach (var val in users)
                    {
                        realm.Add(val);
                    }
                });
            FindViewById<Button>(Resource.Id.load_data_button).Text = "Обновить";
        }
      
    }
}

