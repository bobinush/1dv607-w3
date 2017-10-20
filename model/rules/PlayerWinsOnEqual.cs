using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinsOnEqual : IWhoWinsStrategy
    {
        private const int g_maxScore = 21;

        public bool IsDealerWinner(model.Player a_dealer, model.Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }
            else if (a_dealer.CalcScore() > a_player.CalcScore())
            {
                return true;
            }
            return false; //if dealer and player have the same score
        }
    }
}
