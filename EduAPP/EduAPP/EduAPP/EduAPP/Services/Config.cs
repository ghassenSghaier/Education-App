using Xamarin.Forms;

namespace EduAPP.Services
{
	public static class Config
	{
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "http://10.0.2.2:5000" : "http://192.168.1.4:5000";        
        public static string FormationUrl = "http://192.168.1.4:5000/api/formation/{0}";                
        public static string InscriptionUrl = "http://192.168.1.4:5000/api/inscription/{0}";
        public static string InscriptionDelUrl = "http://192.168.1.4:5000/api/inscription?id={0}";
    }
}
