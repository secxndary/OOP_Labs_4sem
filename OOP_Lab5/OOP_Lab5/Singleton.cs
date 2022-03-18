namespace OOP_Lab4
{
    public class Singleton
    {
        public static Singleton instance;

        private Singleton() { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            else instance = null;
            return instance;
        }
    }

    public class Settings
    {
        public static Singleton settings;
    }
}
