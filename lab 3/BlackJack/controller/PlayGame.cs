using BlackJack.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : IObserver
    {
        private model.Game a_game;
        private view.IView a_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            this.a_game = a_game;
            this.a_view = a_view;
        }

        public bool Play()
        {
            a_view.DisplayWelcomeMessage();
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
            

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }
            
            var input = a_view.GetInput();

            if (input == view.GameControls.playGame)
            {
                a_game.NewGame();
            }
            else if (input == view.GameControls.hit)
            {
                a_game.Hit();
            }
            else if (input == view.GameControls.stand)
            {
                a_game.Stand();
            }
            return input != view.GameControls.quit;
        }

        public void cardDrawn(model.Card c)
        {
            a_view.DisplayCard(c);
            
            
            Thread.Sleep(500);
            
        }
    }
}
