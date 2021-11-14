using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataModels
{
    class GasNetWork : INetWork
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
