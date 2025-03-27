﻿namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public List<UserFollower> Followers { get; set; } = new List<UserFollower>();
    }
}
