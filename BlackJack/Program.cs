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
            model.Game g = new model.Game();
            view.IView v = new view.SimpleView(); // new view.SwedishView();

            model.IObserver po = new controller.CardObserver(g, v);
            g.AddCardObserver(po);

            controller.PlayGame ctrl = new controller.PlayGame();

            while (ctrl.Play(g, v));
        }
    }
}
