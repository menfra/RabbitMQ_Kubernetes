using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    interface IEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
