﻿using System;

namespace Chat.Db.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }


        public int MyId { get; set; }

        public User MyUser { get; set; }


        public int FriendId { get; set; }

        public User FriendUser { get; set; }
    }
}
