namespace Domain.Models;

public partial class Wallet
{
    public Guid WalletId { get; set; }

    public int? Balance { get; set; }
}
