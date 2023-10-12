using Banking.Logic;

Account myAccount;

Console.Write("Please enter the type of account. (C)heckingAccount, (B)usinessAccount or (S)avingsAccount: ");
string typeofaccount = Console.ReadLine()!;

switch (typeofaccount)
{
    case "C":
        myAccount = new CheckingAccount();
        break;

    case "B":
        myAccount = new BusinessAccount();
        break;

    case "S":
        myAccount = new SavingsAccount();
        break;

    default:
        return;
}

Console.Write("Please enter the Account number: ");
myAccount.AccountNumber = Console.ReadLine()!;

Console.Write("Please enter the Account holder:");
myAccount.AccountHolder = Console.ReadLine()!;

Console.Write("Please enter the current Balance: ");
myAccount.CurrentBalance = decimal.Parse(Console.ReadLine()!);



var myTransaction = new Transaction();

Console.Write("Enter the transaction account number: ");
myTransaction.AccountNumber = Console.ReadLine()!;

Console.Write("Enter the transaction description: ");
myTransaction.Description = Console.ReadLine()!;

Console.Write("Enter the transaction amount: ");
myTransaction.Amount = decimal.Parse(Console.ReadLine()!);

Console.Write("Enter the transaction timestamp: ");
myTransaction.TimeStamp = DateTime.Parse(Console.ReadLine()!);

if (myAccount.IsAllowed(myTransaction))
{
    myAccount.TryExecute(myTransaction);
    Console.Write("Transaction executed successfully. The new current balance is ");
    Console.Write(myAccount.CurrentBalance);
    Console.Write("€");
}
else
{
    System.Console.WriteLine($"Transaction with description {myTransaction.Description} on {myTransaction.TimeStamp} is not allowed!");
}