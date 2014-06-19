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
using NAudio;
using NAudio.Wave;

namespace MonAlarm
{
    public partial class AlarmPage : Form
    {
        SoundControl SC = new SoundControl();
        
         
        public AlarmPage()
        {
            InitializeComponent();
            SC.Playsong();
            Thingsto();
        }


        public void Thingsto() {
            StreamReader sr = new StreamReader(new FileStream("Things.txt", FileMode.Open));//체크리스트박스에 물건들을 띄움
            while (sr.EndOfStream == false)
            {
                checkedListBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != checkedListBox1.Items.Count)
            {
                MessageBox.Show("다 안챙겼습니다");
            }
            else {
                MessageBox.Show("좋은하루되세요!");
                SC.Stopsong();
                this.Close();
                
                //음악 추가되면 음악 정지 추가

            }
            }
    }

    public class SoundControl
    {
        IWavePlayer waveout;
            AudioFileReader audiofilereader;

        
            
        public void Playsong()
        {
            StreamReader sr = new StreamReader(new FileStream("music.txt", FileMode.Open));
            waveout = new WaveOut();
            audiofilereader = new AudioFileReader(@sr.ReadLine());
            waveout.Init(audiofilereader);
            waveout.Play();
            sr.Close();
        }

        public void Stopsong()
        {
            
            waveout.Stop();
        }
    }

}
