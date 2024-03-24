using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;

using System;
using System.Timers;
using System.Threading.Tasks;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView imageView;
        int[] imageTable;
        int index;
        bool isRunning;
        Button btnStart, btnStop;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            Button btnBack=FindViewById<Button>(Resource.Id.buttonBack);
            Button btnNext = FindViewById<Button>(Resource.Id.buttonNext);
            btnStart = FindViewById<Button>(Resource.Id.buttonStart);
            btnStop = FindViewById<Button>(Resource.Id.buttonStop);

            imageTable = new int[7];            
            imageTable[0] = Resource.Drawable.img2;
            imageTable[1] = Resource.Drawable.img3;
            imageTable[2] = Resource.Drawable.img4;
            imageTable[3] = Resource.Drawable.img5;
            imageTable[4] = Resource.Drawable.img6;
            imageTable[5] = Resource.Drawable.img7;
            imageTable[6] = Resource.Drawable.img0;
            btnBack.Click += btnBack_Clicked;
            btnNext.Click += btnNext_Clicked;
            btnStart.Click += btnStart_Clicked;
            btnStop.Click += btnStop_Clicked;

            isRunning = false;
        }

        private async void btnStart_Clicked(object sender, System.EventArgs e)
        {
            isRunning = true;
            while (isRunning)
            {
                await Task.Delay(1000); // 1 saniye bekle
                index = (index + 1) % imageTable.Length;
                imageView.SetImageResource(imageTable[index]);
            }
        }

        private void btnStop_Clicked(object sender, System.EventArgs e)
        {
            isRunning = false;
        }


        // Bir onceki resmi göster
        private void btnBack_Clicked(object sender, System.EventArgs e)
        {
            if (index == 0) index = imageTable.Length - 1;
            imageView.SetImageResource(imageTable[index--]);         
        }

        // Bir sonraki resmi göster
        private void btnNext_Clicked(object sender, System.EventArgs e)
        {            
            index = (index + 1) % imageTable.Length;
            imageView.SetImageResource(imageTable[index]);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}