using System;
using System.Collections.Generic;
using System.Text;
using Chat.Contacts.Models;
using Chat.Db.Entities;

namespace Chat.Contacts.Mapping
{
    public static class ContactDtoMapper
    {
        public static ContactDto ToContactDto(this Contact entity)
        {
            return new ContactDto()
            {
                Id = entity.Id,
                UserId = entity.UserId
            };
        }
    }
}
