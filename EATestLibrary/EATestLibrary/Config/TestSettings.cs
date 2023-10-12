using EATestLibrary.Driver;

namespace EATestLibrary.Config
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri ApplicationUrl { get; set; }
        public float? TimeOutInterval { get; set; }
    }  
}
