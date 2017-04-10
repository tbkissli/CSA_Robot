using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//eigene usings
using RobotCtrl;
using RobotView;

namespace RobotView
{
    public partial class LedView : UserControl
    {
        #region members
        private bool state;
        private Led led;
        #endregion

        #region constructors
        public LedView()
        {
            InitializeComponent();
            //LED beim Instanzieren von einem LED-Objekt der Klasse LedView "ausschalten"
            pictureBox1.Image = Resource.LedOff;     //über Property von pictureBox1 kann zwischen LEDOn und LEDOff umgeschaltet werden
        }
        #endregion

        #region properties
        public Led Led
        {
            get { return led; }
            set
            {
                // Falls bereits ein Eventhandler registriert war => diesen zuerst beim alten Led-Objekt entfernen
                // Diese Codezeile ist optional
                if (led != null) led.LedStateChanged -= LedStateChanged;

                // Handler beim Led-Objekt (Model) registrieren.
                led = value;
                if (led != null) this.led.LedStateChanged += LedStateChanged;
            }
        }

        public bool State
        {
            get { return state; }
            set {
                state = value;
                //Wenn LED State==true => LED eingeschaltet, ansonsten ausgeschaltet
                if (state == true)
                {
                    pictureBox1.Image = Resource.LedOn;
                }
                else if (state == false)
                {
                    pictureBox1.Image = Resource.LedOff;
                }
            }
        }
        #endregion

        #region methods
        //Eventhandler für eine Änderung des Status der LED
        private void LedStateChanged(object sender, LedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<LedEventArgs>(LedStateChanged), sender, e);
            }
            else
            {
                State = e.LedEnabled;
            }
        }
        #endregion
    }
}