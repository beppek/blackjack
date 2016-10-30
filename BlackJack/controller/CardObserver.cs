using BlackJack.model;
using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class CardObserver : IObserver
    {
        private IView m_view;
        private Game m_game;

        public CardObserver(Game a_game, IView a_view)
        {
            m_view = a_view;
            m_game = a_game;
        }

        public void Update()
        {
            Thread.Sleep(1500);
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
