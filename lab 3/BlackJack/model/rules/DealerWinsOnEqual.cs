using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsOnEqual : IWiningStrategy
    {
        public bool isWinner(Dealer a_dealer, Player a_player, int maxScore)
        {
            if (a_player.CalcScore() > maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > maxScore)
            {
                return false;
            }
            else if (a_dealer.CalcScore() == a_player.CalcScore())
            {
                return true;
            }
            return a_dealer.CalcScore() <= a_player.CalcScore();
        }
    }
}
