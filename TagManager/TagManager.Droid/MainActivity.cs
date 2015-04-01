using Android.App;
using Android.Content.PM;
using Android.Gms.Common.Apis;
using Android.Gms.Tagmanager;
using Android.OS;
using Android.Runtime;
using Java.Lang;
using Java.Util.Concurrent;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TagManager.Droid
{
    [Activity(Label = "TagManagerSample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        private static TagManagerClass _tagmanager;
        public static MainActivity AppContext { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AppContext = this;

            Forms.Init(this, bundle);

            _tagmanager = TagManagerClass.GetInstance(this);

            _tagmanager.SetVerboseLoggingEnabled(true);

            var pendingResult = _tagmanager.LoadContainerPreferNonDefault("GTM-XXXXXX",
              Resource.Raw.gtm_analytics);

            pendingResult.SetResultCallback(new TagMnagerResultCallback(), 2, TimeUnit.Seconds);

            LoadApplication(new App());


        }

        private class TagMnagerResultCallback : Object, IResultCallback
        {

            public void OnResult(Object result)
            {

                var containerHolder = result.JavaCast<IContainerHolder>();

                //TODO - if you need to keep a reference to the containerHolder to retreive configuration, unmark next line
                // ContainerHolderSingleton.SetContainerHolder(containerHolder);

                if (!containerHolder.Status.IsSuccess)
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(AppContext);
                    builder.SetTitle("Error");
                    builder.SetMessage("Can't load Google tag manager");
                    builder.SetCancelable(false);
                    builder.SetPositiveButton("OK", delegate { AppContext.Finish(); });
                    builder.Show();
                }
                else
                {
                    _tagmanager.DataLayer.PushEvent("openScreen", DataLayer.MapOf("screenName", "testScreen"));
                }
            }
        }
    }
}

