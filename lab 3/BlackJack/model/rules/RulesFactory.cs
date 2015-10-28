using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
            //return new SoftSeventeeGameRule();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
            // return new InternationalNewGameStrategy();
        }

        public IWiningStrategy GetWinnerRule()
        {
            return new PlayerWinsOnEqual();
            //return new DealerWinsOnEqual();
        }
    }
}
