using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataModels
{
    [Serializable]
    public class User : IEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Occupation { get; set; }
        public string Age { get; set; }
    }
}
