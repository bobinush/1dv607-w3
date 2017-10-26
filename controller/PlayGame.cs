using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.controller
{
    class PlayGame
    {
        private model.Game m_game;
        private view.IView m_view;

        public bool Play(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            int input = a_view.GetInput();

            if (input == (int)GameAlternative.Play)
            {
                a_game.NewGame();
            }
            else if (input == (int)GameAlternative.Hit)
            {
                a_game.Hit();
            }
            else if (input == (int)GameAlternative.Stand)
            {
                a_game.Stand();
            }

            return input != (int)GameAlternative.Quit;
        }
        
		public void HandleEvent(object sender, EventArgs args)
		{
			System.Threading.Thread.Sleep(1000);
			Console.Clear();
			
			m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
		}
    }
}
