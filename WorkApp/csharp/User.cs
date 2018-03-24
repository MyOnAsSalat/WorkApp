using Realms;
namespace WorkApp.csharp
{
   public class User : RealmObject
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}