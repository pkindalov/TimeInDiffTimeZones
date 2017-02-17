using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TimeInDiffTimeZones
{
   
    public partial class frmMain : Form
    {
        Dictionary<String, String> timeZones = new Dictionary<string, string>();
        public frmMain()
        {
            InitializeComponent();


            ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();

            

            foreach (TimeZoneInfo zone in zones)
                timeZones.Add(zone.ToString(), zone.Id);
            //cmbZones.Items.Add(zone.Id);


            foreach (KeyValuePair<string, string> entry in timeZones)
            {
                // do something with entry.Value or entry.Key
                cmbZones.Items.Add(entry.Key);
            }

        }

        private void cmbZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String selectedTimeZone = cmbZones.Text;
            if (timeZones.ContainsKey(selectedTimeZone))
            {
                selectedTimeZone = timeZones[selectedTimeZone];
            }
            


            //txtResult.Text = selectedTimeZone;
            ConvertToOtherTimeZone(selectedTimeZone);
        }

        private void ConvertToOtherTimeZone(string selectedTimeZone)
        {
            try
            {
                var time = TimeZoneInfo.ConvertTime(DateTime.Now,
                    TimeZoneInfo.FindSystemTimeZoneById(selectedTimeZone));

                txtResult.Text = time.ToString();
            }
            catch (Exception e)
            {
                txtResult.Text = e.Message;
            }
           
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtResult.Text);
                lblStatus.Text = "Text copied successfully.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
           
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = " ";
        }

        private void txtResult_Click(object sender, EventArgs e)
        {
            lblStatus.Text = " ";
        }

        private void cmbZones_Click(object sender, EventArgs e)
        {
            lblStatus.Text = " ";
        }
    }
}
