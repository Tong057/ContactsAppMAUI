
namespace ContactsAppMAUI.Data
{
    public class Constants
    {
        public const string DatabaseFileName = "contacts.db3";
        public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
