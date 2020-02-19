namespace Temp.Service.DTO
{
    /// <summary>
    /// login model
    /// </summary>
    public class LogInDto
    {
        /// <summary>
        /// user name
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}