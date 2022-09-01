using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{

    //VeriTabanımdaki Unit tablomun sütunları
    //Property olarak girip, ilişkilendiriyorum

    public class Unit :IEntity
    {
        public int UnitId { get; set; }

        public string UnitName { get; set; }
    }
}
