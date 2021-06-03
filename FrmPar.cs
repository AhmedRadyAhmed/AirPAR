using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace PAR
{
    public partial class FrmPAR : Form
    {

        bool isPaint = true;
        EastPar[] par = new EastPar[3];
        private int _current = 0;
        double _rwLength = 20;
        bool _isLinear = false;
        private string _unitDist;

        public FrmPAR()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            string Str = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            Db.OpenDb(Str);
            DataTable tbCurves = Db.GetTable("Select * From MyCurves  order by crv");
            DataTable tbVLines = Db.GetTable("Select * From LinesRatio order by recid");  //vertical lines in 40 non linear

            ParDrawing.Start(tbCurves, tbVLines, _rwLength, 1, _isLinear);
          
           
            par[0] = new EastPar(_rwLength, _unitDist, 200, 660, 500, 250, 20, 950, 1200, _isLinear, true);

            par[0].Get_Dist_Interval_Data = ParDrawing.Get_Dist_Interval_Data;
            par[0].RefreshSim += Form1_RefreshSim;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //  e.Graphics.DrawImage(ParDrawing.GetImage(), 0, 0, ParDrawing.w, ParDrawing.h);
            //par[0].Get_Dist_Interval_Data = ParDrawing.Get_Dist_Interval_Data;
        }
        private void BtnM20_Click(object sender, EventArgs e)
        {
            if (BtnM20.Text == "M-40")
            {
                ParDrawing.RwLength = 20;
                par[0].RwLength = 20;
                BtnM20.Text = "M-20";
            }

            else
            {
                par[0].RwLength = 40;
                ParDrawing.RwLength = 40;
                BtnM20.Text = "M-40";
            }
            this.Refresh();
        }

        private void BtnKm_Nm_Click(object sender, EventArgs e)
        {
            if (BtnKm_Nm.Text.ToLower() == "km")
            {
                BtnKm_Nm.Text = "NM";

                _unitDist = "nm";
            }

            else
            {
                _unitDist = "km";
                BtnKm_Nm.Text = "KM";
            }

        }

        private void BtnEqDis_Click(object sender, EventArgs e)
        {
            ParDrawing.IsEqDis = !ParDrawing.IsEqDis;
        }

        private void RadVideoThreshold_SelectedItemChanged(object sender, EventArgs e)
        {
            ParDrawing.VideoThreshold = Convert.ToInt32(RadVideoThreshold.Text);
            this.Refresh();
        }

        private void BtnParam_Click(object sender, EventArgs e)
        {
            PnlParam.Visible = !PnlParam.Visible;
        }

        private void FrmPAR_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                par[_current].MoveGlideUp();
            if (e.KeyCode == Keys.Down)
                par[_current].MoveGlideDown();
            if (e.KeyCode == Keys.Left)
                par[_current].MoveHDGDown();
            if (e.KeyCode == Keys.Right)
                par[_current].MoveHDGeUp();
            if (e.KeyCode == Keys.G && e.Control | e.Alt)
            {
                par[_current].IsG = true;
            }
            if (e.KeyCode == Keys.H && e.Control | e.Alt)
            {
                par[_current].IsH = true;
            }
        }

        private void FrmPAR_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + "|" + e.Y;
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            //par[_current].Stop();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            //par[_current].Pause();
        }

        private void cmbAcSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //par[_current].AcCurSpeed =Convert.ToInt32(cmbAcSpeed.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ParDrawing.IsLinear = !ParDrawing.IsLinear;
            par[0].IsLinear = ParDrawing.IsLinear;
            this.Refresh();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {


            par[_current].Start();
            //par[_current].RefreshSim += Form1_RefreshSim;
            //par[_current].Get_Dist_Interval_Data = ParDrawing.Get_Dist_Interval_Data;
        }


        private void Form1_RefreshSim()
        {

            lb1.Left = par[0].Glide_X;
            lb2.Left = par[0].HDG_X;
            lb1.Top = par[0].Glide_Y - lb1.Height / 2;
            lb2.Top = par[0].HDG_Y - lb1.Height / 2;


            //lb1_2.Left = par[1].Glide_X;
            //lb2_2.Left = par[1].HDG_X;
            //lb1_2.Top = par[1].Glide_Y - lb1.Height / 2;
            //lb2_2.Top = par[1].HDG_Y - lb1.Height / 2;

            LbD.Text = String.Format("{0:0.00}", par[_current].Distance) + " " + par[_current].DistUnit;
            lbGlid.Text = String.Format("{0:0.00}", par[_current].Glide);
            LblHdg.Text = String.Format("{0:0.00}", Math.Abs(par[_current].HDG));
            LblLR.Text = par[_current].HDGDir;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "";
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    if (c.R == 255 && c.G == 255 && c.B == 0)
                    {
                        s += i.ToString() + "|" + j.ToString() + Environment.NewLine;

                    }
                }

            }

            s += " ";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            Bitmap _b = ParDrawing.GetImage(); 
            _b.Save("toto.gif", System.Drawing.Imaging.ImageFormat.Gif);
            pictureBox1.Image = Image.FromFile("toto.gif");
        }
    }
}
