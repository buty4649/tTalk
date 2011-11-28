using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tTalk
{
    public partial class OAuth : Form
    {
        public string PIN
        {
            get
            {
                return ctl_textbox_pin.Text;
            }
        }

        public OAuth()
        {
            InitializeComponent();
        }
    }
}
