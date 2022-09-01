using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class IpCheck : IEntity
    {
        public int Id { get; set; }

        public string IpAdres { get; set; }

        public string UrlAdres { get; set; }

        //public byte[] RowVersion { get; set; }
    }
}
