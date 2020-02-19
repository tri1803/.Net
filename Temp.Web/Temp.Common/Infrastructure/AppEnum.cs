namespace Temp.Common.Infrastructure
{
    /// <summary>
    /// role enum
    /// </summary>
    public enum Role
    {
        Admin = 1,
        Manager = 2,
        User = 3
    }

    /// <summary>
    /// user type for check request expired date
    /// </summary>
    public enum UserType
    {
        None = 0,
        Processing = 1,
        Reject = 2,
        Approve = 3
    }
}
