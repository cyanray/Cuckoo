namespace Cuckoo.Controls
{
    public interface IToast
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
