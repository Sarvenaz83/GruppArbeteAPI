namespace Domain.Models;

public partial class User
{
    public Guid UserId { get; set; }
    public virtual Wallet Wallet { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;

    public string SurName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string TelephoneNumber { get; set; } = string.Empty;
    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();

}
