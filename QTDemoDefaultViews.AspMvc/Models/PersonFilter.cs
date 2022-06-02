namespace QTDemoDefaultViews.AspMvc.Models
{
    public class PersonFilter
    {
        public bool HasValue => string.IsNullOrEmpty(FirstName) == false || string.IsNullOrEmpty(LastName) == false;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public override string ToString()
        {
            return $"FirstName: {(string.IsNullOrEmpty(FirstName) == false ? FirstName : "---")} LastName: {(string.IsNullOrEmpty(LastName) == false ? LastName : "---")}";
        }
    }
}
