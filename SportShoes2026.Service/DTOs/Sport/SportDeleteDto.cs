using System;
using System.Collections.Generic;
using System.Text;

namespace SportShoes2026.Service.DTOs.Sport
{
    public class SportDeleteDto
    {
        public int SportId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
