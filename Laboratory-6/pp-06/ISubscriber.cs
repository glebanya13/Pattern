namespace Lab6Lib
{
    public interface ISubscriber // интерфейс подписчика
    {
        void update(string eventname); // вызвать при наступлении события
    }
}
