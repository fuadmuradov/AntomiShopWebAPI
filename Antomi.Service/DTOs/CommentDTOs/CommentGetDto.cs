using Antomi.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.CommentDTOs
{
    public class CommentGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ProductItemGetDto Product { get; set; }
        public bool isActive { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string AppUserName { get; set; }
        public DateTime CretadAt { get; set; }
    }
}
