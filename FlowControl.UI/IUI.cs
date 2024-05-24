namespace FlowControl.UI
{
    public interface IUI
    {
        string GetInput();
        void Print(string message);
        void PrintLine(string message = "");
    }
}
