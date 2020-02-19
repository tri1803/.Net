namespace Temp.Service.DTO
{
    /// <summary>
    /// Change password model
    /// </summary>
    public class ChangePassDto
    {
        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// current password
        /// </summary>
        public string CurrentPass { get; set; }
        
        /// <summary>
        /// new password
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// confirm new password
        /// </summary>
        public string ConfirmPass { get; set; } 
    }
}