using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSample
{
    public static class FormNavigator
    {
        public static void Navigate(Form currentForm, Form nextForm)
        {
            currentForm.Hide();
            nextForm.ShowDialog();
            currentForm.Close();
        }
    }
}
