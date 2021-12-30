namespace TVProgram.Models
{
    class User : IModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
