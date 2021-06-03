using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAR
{
    public partial class FrmSettings : Form
    {
      
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadCorrScanHDG_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
           string Str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            Db.OpenDb(Str);
            BtnBasicData_Click(sender, e);
           
        }

        private void BtnBasicData_Click(object sender, EventArgs e)
        {
            ShowGroup(grpbasicData);
        }
        private void ShowGroup(GroupBox g, GroupBox g2 = null, GroupBox g3 = null)
        {
            foreach (var item in PnlScData.Controls)
            {
                if (item is GroupBox)
                    ((GroupBox)item).Visible = false;
                grpby.Visible = true;
                g.Visible = true;
                g.Top = 75;
                g.Left = 135;
                if (g2 != null)
                {
                    g2.Visible = true;
                    g2.Top = 75;
                    g2.Left = 350;
                }
                if (g3 != null)
                {
                    g3.Visible = true;
                    g3.Top = 75;
                    g3.Left = 565;
                }

            }
        }

        private void btnacdata_Click(object sender, EventArgs e)
        {
            ShowGroup(grpacdata1, grpacdata2, grpacdata3);
        }

        private void btnclutter_Click(object sender, EventArgs e)
        {
            ShowGroup(grpclutter);
        }

        private void BtnMeasurementUnits_Click(object sender, EventArgs e)
        {
            ShowGroup(grpmsrunits);
        }

        private void BtnMissedApproach_Click(object sender, EventArgs e)
        {
            ShowGroup(grpmissedapp);
        }

        private void BtnRCF_Click(object sender, EventArgs e)
        {
            ShowGroup(grprcf);
        }

        private void btngoa_Click(object sender, EventArgs e)
        {
            ShowGroup(grpgoa);
        }

        private void btnScnr_Click(object sender, EventArgs e)
        {
            PnlScData.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = "";
            foreach (var g in PnlScData.Controls)
            {
                if (g is GroupBox)
                {

                    foreach (var tt in ((GroupBox)g).Controls)
                    {
                        if (tt is Button || tt is Label)
                        {
                            string s = "";
                        }
                        else
                        {
                            ss += ((Control)tt).Name.ToString() + "/";
                        }

                    }
                }
            }

            string x = "";
        }

        private void btnparmater_Click(object sender, EventArgs e)
        {
            ShowGroup(grpparameter);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string v1, v2, v3, v4, v5, v6;
            v1 = v2 = v3 = v4 = v5 = v6 = "R";
            if (MissedAppL.Checked)
                v1 = "L";
            if (rcfdirL.Checked)
                v2 = "L";
            if (GoADirL.Checked)
                v3 = "L";
            if (acdevdir1L.Checked)
                v4 = "L";
            if (acdevdir2L.Checked)
                v5 = "L";
            if (acdevdir3L.Checked)
                v6 = "L";


            StringBuilder s = new StringBuilder("insert into scdata(exname,sname,slocation,latitude,logtude,rwdir,rwdirtype,rwlength,rwwidth,fieldelevation,glideangle,wvfrom,wvto,actype1,acspeed1,acsqn1,accallsign1,acdevgld1,acdevhdg1,acdevdir1,actype2,acspeed2,acsqn2,accallsign2,acdevgld2,acdevhdg2,acdevdir2,actype3,acspeed3,acsqn3,accallsign3,acdevgld3,acdevhdg3,acdevdir3,ground,cloud,rain,birds,filter,ach,corrscanhdg,corrscanglide,videothreshold,scalelinear,sim1msr2040,sim2510,msrkmnm,mslinNonlin,Mis_alth,MissedAppSpeed,MissedAppDir,goAalth,goaSpeed,goAdir,rcf_alth,rcfspeed,rcfdir,originator,sdate,srevised) values('");
            s.Append(exname.Text);
            s.Append("','");
            s.Append(sname.Text);
            s.Append("','");
            s.Append(slocation.Text);
            s.Append("','");
            s.Append(latitude.Text);
            s.Append("','");
            s.Append(logtude.Text);
            s.Append("','");
            s.Append(rwdir.Text);
            s.Append("','");
            s.Append(rwdirtype.Text);
            s.Append("','");
            s.Append(rwlength.Text);
            s.Append("','");
            s.Append(rwwidth.Text);
            s.Append("','");
            s.Append(fieldelevation.Text);
            s.Append("','");
            s.Append(glideangle.Text);
            s.Append("','");
            s.Append(wvfrom.Text);
            s.Append("','");
            s.Append(wvto.Text);
            s.Append("','");
            s.Append(actype1.Text);
            s.Append("','");
            s.Append(acspeed1.Text);
            s.Append("','");
            s.Append(acsqn1.Text);
            s.Append("','");
            s.Append(accallsign1.Text);
            s.Append("','");
            s.Append(acdevgld1.Text);
            s.Append("','");
            s.Append(acdevhdg1.Text);
            s.Append("','");
            s.Append(v4);
            s.Append("','");
            s.Append(actype2.Text);
            s.Append("','");
            s.Append(acspeed2.Text);
            s.Append("','");
            s.Append(acsqn2.Text);
            s.Append("','");
            s.Append(accallsign2.Text);
            s.Append("','");
            s.Append(acdevgld2.Text);
            s.Append("','");
            s.Append(acdevhdg2.Text);
            s.Append("','");
            s.Append(v5);
            s.Append("','");
            s.Append(actype3.Text);
            s.Append("','");
            s.Append(acspeed3.Text);
            s.Append("','");
            s.Append(acsqn3.Text);
            s.Append("','");
            s.Append(accallsign3.Text);
            s.Append("','");
            s.Append(acdevgld3.Text);
            s.Append("','");
            s.Append(acdevhdg3.Text);
            s.Append("','");
            s.Append(v6);
            s.Append("','");
            s.Append(ground.Text);
            s.Append("','");
            s.Append(cloud.Text);
            s.Append("','");
            s.Append(rain.Text);
            s.Append("','");
            s.Append(birds.Text);
            s.Append("','");
            s.Append(filter.Text);
            s.Append("','");
            s.Append(ach.Text);
            s.Append("','");
            s.Append(corrscanhdg.Text);
            s.Append("','");
            s.Append(corrscanglide.Text);
            s.Append("','");
            s.Append(videothreshold.Text);
            s.Append("','");
            s.Append(scalelinear.Text);
            s.Append("','");
            s.Append(sim1msr2040.Text);
            s.Append("','");
            s.Append(sim2510.Text);
            s.Append("','");
            s.Append(msrkmnm.Text);
            s.Append("','");
            s.Append(mslinNonlin.Text);
            s.Append("','");
            s.Append(Mis_alth.Text);
            s.Append("','");
            s.Append(MissedAppSpeed.Text);
            s.Append("','");
            s.Append(v1);
            s.Append("','");
            s.Append(goAalth.Text);
            s.Append("','");
            s.Append(goaSpeed.Text);
            s.Append("','");
            s.Append(v2);
            s.Append("','");
            s.Append(rcf_alth.Text);
            s.Append("','");
            s.Append(rcfspeed.Text);
            s.Append("','");
            s.Append(v3);
            s.Append("','");
            s.Append(originator.Text);
            s.Append("','");
            s.Append(sdate.Text);
            s.Append("','");
            s.Append(srevised.Text);
            s.Append("')");
            Db.Execute(s.ToString());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmPAR f = new FrmPAR();
            f.Show();
        }
    }
}
