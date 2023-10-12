using Banking.Logic;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Account myAccount;


string[] splittedAccountData = {};
string[] splittedTransactionData = {};

string[] AccountData = File.ReadAllLines(args[0]);
string[] TransactionData = File.ReadAllLines(args[1]);

for(var i = 0; i < AccountData.Length; i++)
{
    splittedAccountData = AccountData[i].Split(';'); 
    splittedTransactionData = TransactionData[i].Split(';');


switch (splittedAccountData[0])
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

myAccount.AccountNumber = splittedAccountData[1];
myAccount.AccountHolder = splittedAccountData[2];
myAccount.CurrentBalance = decimal.Parse(splittedAccountData[3]);

var myTransaction = new Transaction();

myTransaction.AccountNumber = splittedTransactionData[0];
myTransaction.Description = splittedTransactionData[1];
var description = myTransaction.Description;
var accountnumber = myTransaction.AccountNumber;
myTransaction.Amount = decimal.Parse(splittedTransactionData[2]);
myTransaction.TimeStamp = DateTime.Parse(splittedTransactionData[3]);
var Amount = myTransaction.Amount;
var TimeStamp = myTransaction.TimeStamp;
if (myAccount.TryExecute(myTransaction))
{
    Console.Write("Transaction executed successfully. The new current balance is ");
    Console.Write(myAccount.CurrentBalance);
    Console.Write("€\n");
}
else
{
    System.Console.WriteLine($"Transaction with description {description} on {TimeStamp} is not allowed!\n");
}
}