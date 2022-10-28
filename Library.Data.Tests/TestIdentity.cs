using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Tests
{
    public class TestIdentity : ClaimsIdentity
    {
        public TestIdentity(params Claim[] claims) : base(claims)
        {
        }
    }
}
