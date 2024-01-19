namespace Domain.Models;

public partial class User
{
    public Guid UserId { get; set; }
    public virtual Wallet Wallet { get; set; }

    public string? UserName { get; set; }

    public string? Role { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? FirstName { get; set; }

    public string? SurName { get; set; }

    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();
}
