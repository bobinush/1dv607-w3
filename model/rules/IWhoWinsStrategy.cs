using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWhoWinsStrategy
    {
        bool IsDealerWinner(model.Player a_dealer, model.Player a_player);
    }
}
