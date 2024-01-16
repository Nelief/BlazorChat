namespace BlazorChat2.Model
{
    public class UserMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public bool IsCurrentUser { get; set; }
        public DateTime DateSent { get; set; }
    }
}
