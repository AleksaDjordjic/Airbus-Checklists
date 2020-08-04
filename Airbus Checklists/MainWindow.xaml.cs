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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Airbus_Checklists.Customization;

namespace Airbus_Checklists
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            DisableWindows();
            SavedInfoHolder sih = new SavedInfoHolder();
            this.Background = sih.LoadBackgroundColor();
        }

        #region Windows

        BasicPreparationChecklistWindow bpcw = new BasicPreparationChecklistWindow();
        CockpitPreparationChecklistWindow cpcw = new CockpitPreparationChecklistWindow();
        MCDUDataEntryChecklistWindow mdecw = new MCDUDataEntryChecklistWindow();
        CockpitPreparationChecklistPart2Window cpcw2 = new CockpitPreparationChecklistPart2Window();
        CustomizationWindow cw = new CustomizationWindow();
        UpdateNotes un = new UpdateNotes();
        Website website = new Website();

        void DisableWindows()
        {
            bpcw.Hide();
            cpcw.Hide();
            mdecw.Hide();
            cw.Hide();
            un.Hide();
            website.Hide();
        }

        #endregion

        private void BasicPreparation_Click(object sender, RoutedEventArgs e)
        {
            if (bpcw != null)
            {
                bpcw.Show();
            }
            else
            {
                bpcw = new BasicPreparationChecklistWindow();
                bpcw.Show();
            }
        }

        public void CompleteBasicPreparation()
        {
            BasicPreparation.Content += " (Completed)";
        }

        private void CockpitPreparation_Click(object sender, RoutedEventArgs e)
        {
            if (cpcw != null)
            {
                cpcw.Show();
            }
            else
            {
                cpcw = new CockpitPreparationChecklistWindow();
                cpcw.Show();
            }
        }

        public void CompleteCockpitPreparation()
        {
            CockpitPreparation.Content += " (Completed)";
        }

        private void MCDUDataEntry_Click(object sender, RoutedEventArgs e)
        {
            if (mdecw != null)
            {
                mdecw.Show();
            }
            else
            {
                mdecw = new MCDUDataEntryChecklistWindow();
                mdecw.Show();
            }
        }

        public void CompleteMCDUDataEntry()
        {
            MCDUDataEntry.Content += " (Completed)";
        }

        private void CockpitPreparationPart2_Click(object sender, RoutedEventArgs e)
        {
            if (cpcw2 != null)
            {
                cpcw2.Show();
            }
            else
            {
                cpcw2 = new CockpitPreparationChecklistPart2Window();
                cpcw2.Show();
            }
        }

        public void CompleteCockpitPreparationChecklistPart2()
        {
            CockpitPreparationPart2.Content += " (Completed)";
        }

        private void UpdateNotes_Click(object sender, RoutedEventArgs e)
        {
            if (un != null)
            {
                un.Show();
            }
            else
            {
                un = new UpdateNotes();
                un.Show();
            }
        }

        private void Customize_Click(object sender, RoutedEventArgs e)
        {
            if (cw != null)
            {
                cw.Show();
            }
            else
            {
                cw = new CustomizationWindow();
                cw.Show();
            }
        }

        private void Website_Click(object sender, RoutedEventArgs e)
        {
            if (website != null)
            {
                website.Show();
            }
            else
            {
                website = new Website();
                website.Show();
            }
        }
    }
}