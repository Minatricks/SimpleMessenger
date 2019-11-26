using System;
using System.Collections.Generic;
using System.Text;
using Chat.Contacts.Models;
using Chat.Db.Entities;

namespace Chat.Contacts.Mapping
{
    public static class ContactDtoMapper
    {
        public static MyContacstDto ToContactDto(this Contact entity)
        {
            return new MyContacstDto()
            {
                FriendId = entity.FriendId
            };
        }
    }
}
