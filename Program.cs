using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            view.IView v = new view.SimpleView(); 
            controller.PlayGame ctrl = new controller.PlayGame();
            model.Dealer m_dealer = new model.Dealer(new model.rules.RulesFactory());
            m_dealer.SubscriberList += ctrl.HandleEvent;
            
            model.Game g = new model.Game(m_dealer);

            while (ctrl.Play(g, v));
        }
    }
}
