using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubMockFake
{
    public class StarBucks : IMakeACoffee
    {
        public bool CheckIngridentAvalability()
        {
            return true;
        }
        string IMakeACoffee.CoffeeMaking(int suggerPerSpone, int CoffeePack)
        {
            throw new NotImplementedException();
        }
        // Stub class of class Starbucks
        public class StubStarbucks : IMakeACoffee
        {
            public bool CheckIngridentAvalability()
            {
                return true;
            }
            public string CoffeeMaking(int suggerPerSpone, int CoffeePack)
            {
                return "Your Order is received.";
            }
        }
    }
}
