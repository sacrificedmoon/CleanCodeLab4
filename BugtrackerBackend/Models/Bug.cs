namespace BugtrackerBackend.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
