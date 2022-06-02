namespace QTDemoDefaultViews.AspMvc.Models
{
    public class Person : IdentityModel
    {
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(64)]
        public string LastName { get; set; } = string.Empty;
    }
}
