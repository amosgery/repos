using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TicTacToe_OOP
{
    public class GameObjectSingleton
    {
        private static TicTacToeGame instance;
        private static object lockObject = new object();

        private GameObjectSingleton()
        {
            // Private constructor to prevent instantiation
        }
        public static TicTacToeGame getInstance()
        {
            lock (lockObject)
            {

                if (instance == null)
                {
                    instance = new TicTacToeGame();
                }
                return instance;
            }
        }
    }

}