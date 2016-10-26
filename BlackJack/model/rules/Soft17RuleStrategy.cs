using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17RuleStrategy : IHitStrategy
    {
        private const int g_softLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcCardValues() == g_softLimit && a_dealer.FoundAce())
            {
                return true;
            }
            return a_dealer.CalcScore() < g_softLimit;
        }
        
    }
}
