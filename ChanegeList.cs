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
    public partial class ChanegeList : Form
    {
        public ChanegeList()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader(new FileStream("Things.txt", FileMode.Open));//체크리스트박스에 물건들을 띄움
            while (sr.EndOfStream == false)
            {
                checkedListBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection  checkedItems = checkedListBox1.CheckedItems;
            foreach (object item in checkedItems)
            {
                StreamWriter sw = new StreamWriter(new FileStream("Things.txt", FileMode.Open));
               
                sw.Close();
            }
        }         
    }
}
