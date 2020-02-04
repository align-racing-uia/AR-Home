namespace web_api.Models.Home
{
    public class ShortcutCategory
    {
        public int Id { get; set; }
        public int ShortcutId { get; set; }
        public int CategoryId { get; set; }
        
        public Shortcut Shortcut { get; set; }
        public Category Category { get; set; }
    }
}