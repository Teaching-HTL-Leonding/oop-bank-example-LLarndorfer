namespace Banking.Logic;

public abstract class Account
{
    public abstract bool IsAllowed(Transaction trans);

    public bool TryExecute(Transaction trans)
    {
        if (IsAllowed(trans) == true)
        {
            CurrentBalance += trans.Amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public string? AccountNumber { get; set; }
    public string? AccountHolder { get; set; }
    public decimal CurrentBalance { get; set; }

}

public class CheckingAccount : Account
{
    public override bool IsAllowed(Transaction trans)
    {
        if ((CurrentBalance + trans.Amount) >= -10000 && (CurrentBalance + trans.Amount) < 10_000_000 && trans.Amount <= 10000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class BusinessAccount : Account
{
    public override bool IsAllowed(Transaction trans)
    {
        if ((CurrentBalance + trans.Amount) >= -1_000_000 && (CurrentBalance + trans.Amount) < 100_000_000 && trans.Amount <= 100000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class SavingsAccount : Account
{
    public override bool IsAllowed(Transaction trans)
    {
        if ((CurrentBalance + trans.Amount) >= 0 && (CurrentBalance + trans.Amount) < 100_000_000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Transaction
{
    public string? AccountNumber { get; set; }

    public string? Description { get; set; }

    public DateTime TimeStamp { get; set; }

    public decimal Amount { get; set; }
}


