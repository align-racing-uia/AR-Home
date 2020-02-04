using System;

namespace web_api.Models.Home
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string OAuthSubject { get; set; }
        public string OAuthIssuer { get; set; }
    }
    
    public class UserView
    {
        public string tokenId {get; set;}
    }
}