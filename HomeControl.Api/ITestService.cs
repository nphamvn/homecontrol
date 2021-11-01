namespace HomeControl.Api.Tests
{
    public interface ITestService
    {
        bool Initialized { get; set; }
    }
    public class TestService : ITestService
    {
        private static TestService _instance = null;
        public static TestService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TestService();
                }
                return _instance;
            }
        }

        private TestService()
        {

        }
        public bool Initialized { get; set; }
        public void Initialize()
        {
            Initialized = true;
        }
    }
}