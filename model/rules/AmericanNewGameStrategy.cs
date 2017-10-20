using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_dealer.GiveCardTo(a_player, true);

            a_dealer.GiveCardTo(a_dealer, true);

            a_dealer.GiveCardTo(a_player, true);

            a_dealer.GiveCardTo(a_dealer, false);

            return true;
        }
    }
}
