using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Service.Dto_s
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
    }
}