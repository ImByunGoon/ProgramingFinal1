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
            StreamReader sr = new StreamReader(new FileStream("Things.txt", FileMode.Open));
            StreamWriter sw = new StreamWriter(new FileStream("temp.txt", FileMode.Create));
           
                while (sr.EndOfStream == false)
                {
                    string member = sr.ReadLine().ToString();//things
                    int count=0;
                    foreach (object items in checkedItems) {
                        if (member == items.ToString())//같을 때
                        {
                            break;
                        }
                        else { //다를 때 
                            count++;
                            if (count == checkedItems.Count) {
                                sw.WriteLine(member);
                                count = 0;
                            }
                        }
                    
                    }                   

                }
                sr.Close();     
            sw.Close();

            StreamReader sr2 = new StreamReader(new FileStream("temp.txt", FileMode.Open));
            StreamWriter sw2 = new StreamWriter(new FileStream("Things.txt", FileMode.Create));
            while(sr2.EndOfStream==false){
                sw2.WriteLine(sr2.ReadLine().ToString());
            }
            sr2.Close();
            sw2.Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;

            
            this.Close();


        }         
    }
}
