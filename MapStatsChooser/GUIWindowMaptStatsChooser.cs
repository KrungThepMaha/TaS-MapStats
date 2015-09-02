using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Plugin.KTMBobisback.MapStatsChooser
{
    /// <summary>
    ///     The main GUI window for the map stats chooser.
    /// </summary>
    public class GUIWindowMapStatsChooser : MonoBehaviour
    {
        private readonly GUIManager guiMgr = GUIManager.getInstance();

        //vars for displaying messages error and regular.
        private static readonly Timer UpdateTimer = new Timer(5000);
        private static bool _showErrorDialog = false;
        private static string _messageTitle = "";
        private static string _message = "";

        /// <summary>
        ///     This function is called once when this window starts up. 
        ///     Do any one time setup/init things in this function.
        /// </summary>
        void Start()
        {
            UpdateTimer.Elapsed += UpdateDisplay;
        }
        
        /// <summary>
        ///     This is called alot less then ongui and can have some model data manipulation in it.
        ///     This is also were any hotkeys are intercepted.
        /// </summary>
        void Update()
        {
        }

        /// <summary>
        ///     called anywhere from 60 times a sec to 1000 times a second. Only display GUI in this function. 
        ///     No model data should built/manipulated in this function.
        /// </summary>
        void OnGui()
        {
            if (_showErrorDialog) {
                DisplayErrorDialog();
                UpdateTimer.Start();
            }
        }

        /// <summary>
        ///     Basic function for displaying a simple "toast" error message.
        ///     This message is on a timer for 5 seconds by default.
        /// </summary>
        /// <param name="error">
        ///     The string the reprosents the error message that needs to be dispalyed.
        /// </param>
        public static void DisplayErrorMessage(string error)
        {
            DisplayMessage("An Error has Occurred", error);
        }

        /// <summary>
        ///     A simple function to display a message on the screen. 
        ///     This message is on a timer for 5 seconds by default.
        /// </summary>
        /// <param name="title">
        ///     The title of the message to display.
        /// </param>
        /// <param name="body">
        ///     The body of the message to display.
        /// </param>
        public static void DisplayMessage(string title, string body)
        {
            _messageTitle = title;
            _message = body;
            _showErrorDialog = true;
        }
        
        //This will stop the display from showing when the timer runs out.
        private void UpdateDisplay(object sender, ElapsedEventArgs e)
        {
            _showErrorDialog = false;
            UpdateTimer.Stop();
        }

        //This will display the error dailog box.
        private void DisplayErrorDialog()
        {
            Rect displayErrorRect = new Rect(Screen.width / 2 - 160, Screen.height - 130, 320, 120);
            guiMgr.DrawWindow(displayErrorRect, _messageTitle, false);
            displayErrorRect.y += 50;
            displayErrorRect.height += 50;
            guiMgr.DrawTextCenteredWhite(displayErrorRect, _message);
        }
    }
}
