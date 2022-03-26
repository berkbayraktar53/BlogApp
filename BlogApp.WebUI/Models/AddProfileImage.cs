namespace BlogApp.WebUI.Models
{
    public class AddProfileImage
    {
        public int WriterId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? About { get; set; }
        public IFormFile? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}