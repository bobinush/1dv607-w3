using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftSeventeenStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            // If the sum is between 17 and 20, check if the dealer has an ace. "Soft 17".
            // Has the dealer 21, wins the dealer.
            // Has the dealer over 21, CalcScore handles the score for us.
            int score = a_dealer.CalcScore();
            bool hasAce = false;

            if(score >= g_hitLimit && score < 21)
            {
                hasAce = a_dealer.HasAce();
            }

            return score < g_hitLimit || hasAce;
        }
    }
}
