using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Airbus_Checklists.Customization;
using System.ComponentModel;

namespace Airbus_Checklists
{
    public partial class Website : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public Website()
        {
            InitializeComponent();
            SavedInfoHolder sih = new SavedInfoHolder();
            this.Background = sih.LoadBackgroundColor();
        }
    }
}
