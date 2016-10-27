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
        private rules.IAdvantageStrategy m_advantageRule;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_advantageRule = a_rulesFactory.GetAdvantageRule();
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
                DealOpenCardTo(a_player);
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                while (m_hitRule.DoHit(this))
                {
                    DealOpenCardTo(this);
                }
                return true;
            }

            return false;
        }

        public void DealOpenCardTo(Player a_player)
        {
            DealCardTo(a_player, true);
        }

        public void DrawHiddenCard()
        {
            DealCardTo(this, false);
        }

        private void DealCardTo(Player a_player, Boolean isVisible)
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(isVisible);
            a_player.DealCard(c);
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_advantageRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public int getMaxScore()
        {
            return g_maxScore;
        }
    }
}
