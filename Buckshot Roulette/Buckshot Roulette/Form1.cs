using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Buckshot_Roulette
{
    public partial class Form1 : Form
    {
        private float formWidth, formHeight;
        private float button1X, button1Y, button1Width, button1Height;
        private float exitButtonX, exitButtonY, exitButtonWidth, exitButtonHeight;

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(@"playv2.png");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(@"play.png");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void esci_MouseEnter(object sender, EventArgs e)
        {
            esci.BackgroundImage = Image.FromFile(@"exitv2.png");
            esci.BackgroundImageLayout = ImageLayout.Stretch;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void esci_MouseLeave(object sender, EventArgs e)
        {
            esci.BackgroundImage = Image.FromFile(@"exit.png");
            esci.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private SoundPlayer soundPlayer;

        private void esci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private float pictureBoxX, pictureBoxY, pictureBoxWidth, pictureBoxHeight;

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;

            esci.FlatStyle = FlatStyle.Flat;
            esci.BackColor = Color.Transparent;
            esci.FlatAppearance.BorderSize = 0;
            esci.FlatAppearance.MouseDownBackColor = Color.Transparent;
            esci.FlatAppearance.MouseOverBackColor = Color.Transparent;

          
            formWidth = this.Width;
            formHeight = this.Height;

           
            button1X = button1.Left;
            button1Y = button1.Top;
            button1Width = button1.Width;
            button1Height = button1.Height;

            exitButtonX = esci.Left;
            exitButtonY = esci.Top;
            exitButtonWidth = esci.Width;
            exitButtonHeight = esci.Height;

            if (pictureBox1 != null)
            {
                pictureBoxX = pictureBox1.Left;
                pictureBoxY = pictureBox1.Top;
                pictureBoxWidth = pictureBox1.Width;
                pictureBoxHeight = pictureBox1.Height;
            }

            this.Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            soundPlayer = new SoundPlayer(@"Buckshot-Roulette-Main-Menu.wav");
            soundPlayer.PlayLooping();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float newWidth = this.Width / formWidth;
            float newHeight = this.Height / formHeight;

         
            button1.Left = (int)(button1X * newWidth);
            button1.Top = (int)(button1Y * newHeight);
            button1.Width = (int)(button1Width * newWidth);
            button1.Height = (int)(button1Height * newHeight);

            esci.Left = (int)(exitButtonX * newWidth);
            esci.Top = (int)(exitButtonY * newHeight);
            esci.Width = (int)(exitButtonWidth * newWidth);
            esci.Height = (int)(exitButtonHeight * newHeight);

        
            if (pictureBox1 != null)
            {
                pictureBox1.Left = (int)(pictureBoxX * newWidth);
                pictureBox1.Top = (int)(pictureBoxY * newHeight);
                pictureBox1.Width = (int)(pictureBoxWidth * newWidth);
                pictureBox1.Height = (int)(pictureBoxHeight * newHeight);
            }
        }

  
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            soundPlayer?.Stop(); 
        }
    }
}
