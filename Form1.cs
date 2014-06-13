using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MonAlarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//화면 로드함으로 설정된 시간과 물건들의 파일을 불러서 화면을 띄움
        {
           
            StreamReader sr = new StreamReader(new FileStream("Things.txt", FileMode.Open));
            while (sr.EndOfStream == false)
            {
                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();

            StreamReader sr2 = new StreamReader(new FileStream("time.txt", FileMode.Open));
            label6.Text = string.Format("현재설정시간은 {0}시 {1}분 입니다."
                , sr2.ReadLine(), sr2.ReadLine());
            
            sr2.Close();
            
        }
        private void ShowTime() {
            label7.Text = System.DateTime.Now.ToString("hh:mm:ss");
        }
        private void tabtable1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)//특정 파일을 열고 그이름을 옆에 표시하기,디렉토리 가져오기?그러나 구현 못하는중
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.SafeFileName;
                textBox1.Text = a;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChanegeList chanegelist = new ChanegeList();
            chanegelist.ShowDialog();
            // changelist에서 선택된 애들을 가져와서
            // 지우는 작업
        }

        private void textbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//things.txt에 입력하는 코드
        {
            StreamWriter sw = new StreamWriter(new FileStream("Things.txt", FileMode.Append));
            sw.WriteLine(textBox2.Text);
            sw.Close();
            listBox1.Items.Clear();

            StreamReader sr = new StreamReader(new FileStream("Things.txt", FileMode.Open));
            while (sr.EndOfStream == false)
            {
                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void textbox2_textchanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)//things.txt에 입력하는 코드와 그걸 엔터로도 가능하게 하는것. 근데 현재 엔터를 누르면 실행은 되나 경고음이 남
        {
            if (e.KeyCode == Keys.Enter) {
                StreamWriter sw = new StreamWriter(new FileStream("Things.txt", FileMode.Append));
                sw.WriteLine(textBox2.Text);
                sw.Close();
                listBox1.Items.Clear();

                StreamReader sr = new StreamReader(new FileStream("Things.txt", FileMode.Open));
                while (sr.EndOfStream == false)
                {
                    listBox1.Items.Add(sr.ReadLine());
                }
                sr.Close();
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)//버튼을 누르면 새로운 시간을 설정
        {
            StreamWriter sw = new StreamWriter(new FileStream("time.txt", FileMode.OpenOrCreate));
            sw.WriteLine(numericUpDown1.Value);
            sw.WriteLine(numericUpDown2.Value);
            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("time.txt", FileMode.Open));
            label6.Text = string.Format("현재설정시간은 {0}시 {1}분 입니다."
                , sr.ReadLine(), sr.ReadLine());
            sr.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)//알람
        {
            ShowTime();
            StreamReader sr = new StreamReader(new FileStream("time.txt", FileMode.Open));

            if(System.DateTime.Now.Hour==Int16.Parse(sr.ReadLine())
                &&System.DateTime.Now.Minute==Int16.Parse(sr.ReadLine())){
                MessageBox.Show("알람!!!!!!!");
                timer1.Stop();
            }
            sr.Close();
        }
    }
    public class Alarm
    { 
        
    }
}
