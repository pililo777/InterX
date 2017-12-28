using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using System.Runtime.InteropServices;

namespace Andr1
{

    [Activity(Label = "Andr1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        [DllImport("SharedObject1")]
        public extern static int Cpp_GetValue();



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.button1);
 
            button.Click +=   new EventHandler ( Cpp_GetValue2  );
 
            
         }

        void HandleTouchUpInside(object sender, EventArgs ea)
        {
            //new UIAlertView("Touch3", "TouchUpInside handled", null, "OK", null).Show();
            Toast.MakeText(this, "click en el boton3", ToastLength.Long).Show();
            
        }


        protected void Cpp_GetValue2(object sender, EventArgs e) 
       
        {
 
            int n = Cpp_GetValue();
            EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);
            edit1.Text = System.IO.File.ReadAllText("/sdcard/data/data/Andr1.Andr1/files/test.txt");

        }


        /*
        [Java.Interop.Export("button_OnClick")]
        public void button_OnClick(View v)
        {
            Toast.MakeText(this, "Hello from " + v.Id, ToastLength.Long).Show();
        }
        */


    }
}

