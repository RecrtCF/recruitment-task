
namespace CouponFollow.Automation.Tests
{
    public class BaseTest
    {
        private Properties.Settings _settings;

        private Properties.Settings Settings
        {
            get 
            {
                if (_settings == null)
                {
                    _settings = new Properties.Settings();
                }
                return _settings;
            }
        }

        protected string BaseUrl => Settings.baseUrl;

        protected string CatcVersion => Settings.catcVersion;
    }
}
