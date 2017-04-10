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
    public partial class SwitchView : UserControl
    {
        #region members
        private bool state;     //state Variable für State Property
        private Switch sw; 
        #endregion 

        #region constructors
        public SwitchView()
        {
            InitializeComponent();
            //Switch beim Instanzieren von einem Switch-Objekt der Klasse SwitchView "ausschalten"
            pictureBox1.Image = Resource.SwitchOff;     //über Property von pictureBox1 kann zwischen SwitchOn und SwitchOff umgeschaltet werden
        }
        #endregion

        #region properties
        public Switch Switch
        {
            get { return sw; }
            set
            {
                // Falls bereits ein Eventhandler registriert war => diesen zuerst beim alten Switch-Objekt entfernen
                // Diese Codezeile ist optional
                if (sw != null) sw.SwitchStateChanged -= SwitchStateChanged;

                // Handler beim Switch-Objekt (Model) registrieren.
                sw = value;
                if (sw != null) this.sw.SwitchStateChanged += SwitchStateChanged;
            }
        }
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                //Wenn Switch State==true => Switch eingeschaltet, ansonsten ausgeschaltet
                if (state == true)
                {
                    pictureBox1.Image = Resource.SwitchOn;
                }
                else if (state == false)
                {
                    pictureBox1.Image = Resource.SwitchOff;
                }
            }
        }
        #endregion

        #region methods
        //Eventhandler für eine Änderung des Status der LED
        private void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            //Invoke Required ist nötig, da nur der Thread der hier die SwitchView erzeugt hat, etwas am 
            //GUI ändern darf. Wenn dieser Thread aktiv ist, ist InvokeRequired = false und das GUI wird aktualisiert
            //Ansonsten wenn ein anderer Thread zugreifen will, ist das InvokeRequired = true und die 
            //SwitchStateChanged Methode muss nochmals aufgerufen werden vom richtigen Thread. Das geschieht im 
            //Code unten nach der If-Anweisung Invoke(new.....)
            if (InvokeRequired)
            {
                Invoke(new EventHandler<SwitchEventArgs>(SwitchStateChanged), sender, e);
            }
            else
            {
                State = e.SwitchEnabled;
            }       
        }
        #endregion
    }
}