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
    public partial class BasicPreparationChecklistWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  
            this.Hide();      
        }

        public BasicPreparationChecklistWindow()
        {
            InitializeComponent();
            SavedInfoHolder sih = new SavedInfoHolder();
            this.Background = sih.LoadBackgroundColor();
            AddCheckboxesToList();
            maxChecked = checkboxes.Count;
            ChecklistStatusBar.Maximum = maxChecked;
        }

        List<CheckBox> checkboxes = new List<CheckBox>();
        int maxChecked;
        int completedItems;

        void AddCheckboxesToList()
        {
            checkboxes.Add(ChecklistItem1);
            checkboxes.Add(ChecklistItem2);
            checkboxes.Add(ChecklistItem3);
            checkboxes.Add(ChecklistItem4);
            checkboxes.Add(ChecklistItem5);
            checkboxes.Add(ChecklistItem6);
            checkboxes.Add(ChecklistItem7);
            checkboxes.Add(ChecklistItem8);
        }

        void CheckForCompletion()
        {
            completedItems = 0;

            for (int i = 0; i < checkboxes.Count; i++)
            {
                if (checkboxes.ElementAt(i).IsChecked == true)
                {
                    completedItems++;
                }
            }

            if (completedItems >= maxChecked)
            {
                ChecklistStatusTest.Content = "Checklist Completed !";
                MainWindow.mainWindow.CompleteBasicPreparation();
            }
            else
            {
                ChecklistStatusTest.Content = "Completed " + completedItems + " out of " + maxChecked + " items.";
            }

            ChecklistStatusBar.Value = completedItems;
        }

        private void ChecklistItem_Click(object sender, RoutedEventArgs e)
        {
            CheckForCompletion();
        }
    }
}
