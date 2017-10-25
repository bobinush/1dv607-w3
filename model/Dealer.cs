using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWhoWinsStrategy m_winRule;

        public event EventHandler SubscriberList;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.SoftSeventeenRule();
            m_winRule = a_rulesFactory.PlayerWinsRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                GiveCardTo(a_player, true);
                return true;
            }
            return false;
        }

        public void GiveCardTo(Player a_dealerOrPlayer, bool shouldShowCard) 
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(shouldShowCard);
            a_dealerOrPlayer.DealCard(c); 

            if (SubscriberList != null)
            {
                SubscriberList(this, EventArgs.Empty);
            }
        }

        public void Stand()
        {
            if (m_deck != null) 
            {
                ShowHand();
                while(m_hitRule.DoHit(this)) {
                  Hit(this);
                }
            }
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        
        
    }
}
