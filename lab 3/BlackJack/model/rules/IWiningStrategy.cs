using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWiningStrategy
    {
        bool isWinner(Dealer a_dealer, Player a_player, int maxScore);
    }
}
