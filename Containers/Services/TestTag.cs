using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Containers.Services
{
    public class TestTag : ITestTag
    {
        public string TagIsOnline(string tag) => $"{tag} is online";
    }
}