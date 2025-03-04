using System;
using System.Drawing;
using System.Windows.Forms;

namespace MY_DESKTOP_APP.Allusercontrol
{
    public partial class UC_WELCOME : UserControl
    {
        public UC_WELCOME()
        {
            InitializeComponent();
        }

        int num = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Set new location and color based on 'num'
            if (num == 0)
            {
                
                labelBanner.ForeColor = Color.Blue; // Change color to Blue
                num++;
            }
            else if (num == 1)
            {
                
                labelBanner.ForeColor = Color.Red; // Change color to Red
                num++;
            }
            else if (num == 2)
            {
                // Ensure it stays within the visible bounds
                labelBanner.ForeColor = Color.Brown; // Change color to Brown
                num = 0;  // Reset to start again
            }

            // Ensure label is always within bounds of the UserControl (or parent container)
            if (labelBanner.Location.X < 0 || labelBanner.Location.Y < 0 ||
                labelBanner.Location.X + labelBanner.Width > this.Width ||
                labelBanner.Location.Y + labelBanner.Height > this.Height)
            {
                // Reset to initial position to stay inside bounds
                
            }
        }

        private void labelBanner_Click(object sender, EventArgs e)
        {
            timer1.Start(); // Start the timer when label is clicked
        }
    }
}
