namespace Updater
{
    public partial class Form1 : Form
    {
         public int progres { get; set; }
        public Form1()
        {
            InitializeComponent();
            progres =0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            circularProgressBar.Value = progres;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progres++;
            circularProgressBar.Value = progres;
            /*
            for (int i = 0; i < 100; i++)
            {
                progres++;
                circularProgressBar.Value = progres;
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cCircularProgresBackground1.Start();
        }
        /*
* https://stackoverflow.com/questions/4871263/how-to-create-a-circular-style-progressbar
* 
* 
* */
    }
}