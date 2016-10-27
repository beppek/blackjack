using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerAdvantageStrategy : IAdvantageStrategy
    {
        public Boolean IsDealerWinner(model.Dealer a_dealer, model.Player a_player)
        {
            int maxScore = a_dealer.getMaxScore();
            if (a_player.CalcScore() > maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > maxScore)
            {
                return false;
            }
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
