#if ANDROID
using Android.OS;
using Android.App;
using Android.Content;
using Android.Provider;

#endif
namespace NovitusApp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            #if ANDROID
            LoadDeviceInfo();
            #endif
        }

#if ANDROID
        private void LoadDeviceInfo()
        {
            
            ProducerLabel.Text = "Producent: " + Build.Manufacturer;
            ModelLabel.Text = "Model: " + Build.Model;

            
            ActivityManager activityManager = (ActivityManager)Android.App.Application.Context.GetSystemService(Context.ActivityService);
            ActivityManager.MemoryInfo memoryInfo = new ActivityManager.MemoryInfo();
            activityManager.GetMemoryInfo(memoryInfo);

            long totalRam = memoryInfo.TotalMem / (1024 * 1024);
            RamLabel.Text = "RAM: " + totalRam + " MB";

            
            var path = Android.OS.Environment.DataDirectory;
            StatFs stat = new StatFs(path.Path);

            long totalStorage = stat.BlockCountLong * stat.BlockSizeLong / (1024 * 1024 * 1024);
            StorageLabel.Text = "Pamięć: " + totalStorage + " GB";

            
            try
            {
                string serial = Build.GetSerial();
                SerialLabel.Text = "Numer seryjny: " + serial;
            }
            catch
            {
                SerialLabel.Text = "Numer seryjny: brak dostępu";
            }

            
            string androidId = Settings.Secure.GetString(
                Android.App.Application.Context.ContentResolver,
                Settings.Secure.AndroidId
            );

            DeviceIdLabel.Text = "ID urządzenia: " + androidId;
        }
#endif

    }
}
