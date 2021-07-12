using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupItemPermissions
{
    sealed public class ITPermission
    {
        public string Name { get; set; }
        public ushort Id { get; set; }
        public string Permission { get; set; }
        public string GetMessage { get; set; }
        public bool HasGetMessage { get; set; }
        public string DropMessage { get; set; }
        public bool HasDropMessage { get; set; }

        public ITPermission()
        {

        }

        public ITPermission(ushort id, int amount, string permission, string getMessage, bool hasGetMessage, string dropMessage, bool hasDropMessage)
        {
            Id = id;
            Permission = permission;
            GetMessage = getMessage;
            HasGetMessage = hasGetMessage;
            DropMessage = dropMessage;
            HasDropMessage = hasDropMessage;
        }
    }
}