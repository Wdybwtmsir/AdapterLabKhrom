using System;

interface IPayment
{
    void Pay(double amount);
}
class CashPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплата наличными: {amount} рублей");
    }
}
class CardPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплата картой: {amount} рублей");
    }
}
class OldPaymentSystem
{
    public void MakeTransaction(double money)
    {
        Console.WriteLine("Старая система обработала платёж: " + money);
    }
}
class OldPaymentAdapter : IPayment
{
    private OldPaymentSystem oldSystem;
    public OldPaymentAdapter(OldPaymentSystem oldSystem)
    {
        this.oldSystem = oldSystem;
    }
    public void Pay(double amount)
    {
        oldSystem.MakeTransaction(amount);
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Система оплаты запущена\n");
        double sumToPay = 1500;
        IPayment cash = new CashPayment();
        cash.Pay(sumToPay);
        IPayment card = new CardPayment();
        card.Pay(sumToPay);
        OldPaymentSystem oldSystem = new OldPaymentSystem();
        IPayment oldPaymentAdapter = new OldPaymentAdapter(oldSystem);
        oldPaymentAdapter.Pay(sumToPay);

        Console.WriteLine("\nВсе платежи успешно обработаны!");
    }
}