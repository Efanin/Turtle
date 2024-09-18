namespace WinFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Command> cmds = new();
            string txt = textBox1.Text + "\n";
            while ((txt.IndexOf("\n") + 1) != 0)
            {
                string line = txt[0..txt.IndexOf("\n")];
                try
                {
                    cmds.Add(
                    new(line[0..line.IndexOf("(")], line[(line.IndexOf("(") + 1)..line.IndexOf(")")])
                    );
                }
                catch (Exception ex) { };
                txt = txt[(txt.IndexOf("\n") + 1)..^0];
            }

            Form2 f2 = new Form2(cmds);
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                textBox1.Text += @"
";
        }
    }
    public class Command
    {
        public string key;
        public string value;
        public Command(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
