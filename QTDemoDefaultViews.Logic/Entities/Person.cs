
namespace QTDemoDefaultViews.Logic.Entities
{
    [Table("Persons")]
    [Index(nameof(LastName), nameof(FirstName), IsUnique = true)]
    public class Person : VersionEntity
    {
        [MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(64)]
        public string LastName { get; set; } = string.Empty;
    }
}
