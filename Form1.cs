using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TłumaczFifi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] Normal = {"A",  "B",  "C",  "D",  "E",  "F",  "G",  "H",  "I",  "K",  "L",  "M",  "N",  "O",  "P",  "Q",  "R",  "S",  "T",  "U",  "V",  "W",  "X",  "Y",  "Z"};
        string[] Number = {"11", "12", "13", "14", "15", "21", "22", "23", "24", "25", "31", "32", "33", "34", "35", "41", "42", "43", "44", "45", "51", "52", "53", "54", "55"};
        string lewo = "";

        private void button1_Click(object sender, EventArgs e)
        {
            lewo = textBox1.Text;
            int lewDlug = lewo.Length;
            string wynik = "",znak="";
            for (int i = 0; i < lewDlug; i++){
                for (int j = 0; j < 25; j++){
                    znak = null;
                    if (lewo[i].ToString().ToUpper() == Normal[j]){
                        znak = Number[j];
                        if (i < lewDlug - 1){ if (i >= 0 && lewo[i + 1] != ' ') znak += " "; }
                        j = 24;
                    }
                    else if (lewo[i] == ' '){
                        znak = ", "; j = 24;
                    }else if (lewo[i].ToString().ToUpper() == "J"){
                        znak = "24";
                        if (i < lewDlug - 1) { if (i >= 0 && lewo[i + 1] != ' ') znak += " "; }
                        j = 24;
                    }
                    switch (lewo[i].ToString().ToUpper()){
                        case "Ś": znak = "43 "; j = 24; break;
                        case "Ą": znak = "11 "; j = 24; break;
                        case "Ę": znak = "15 "; j = 24; break;
                        case "Ć": znak = "13 "; j = 24; break;
                        case "Ż": znak = "55 "; j = 24; break;
                        case "Ź": znak = "55 "; j = 24; break;
                        case "Ł": znak = "31 "; j = 24; break;
                        case "Ó": znak = "34 "; j = 24; break;
                    }
                    wynik += znak;
                }
                if (znak == null){
                    textBox2.Text = "Error 404";
                    MessageBox.Show("FiFi nie rozpoznaje znaku \"" + lewo[i].ToString() + "\"\n\nZamknij te okno i usuń ten znak");
                    i = lewDlug - 1; break;
                }
                textBox2.Text = wynik;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lewo = textBox1.Text;
            int lewDlug = lewo.Length;
            string wynik = "", znak = "";
            bool pomniejsz = false;
            for (int i = 0; i < lewDlug; i+=2){
                for (int j = 0; j < 25; j++) {
                    znak = null;
                    if (lewo[i]!=' ') {
                        if (lewo[i] == ',') {
                            znak = " "; j = 24; pomniejsz = false;
                        } else if (lewo[i].ToString() + lewo[i + 1] == Number[j]) {
                            znak = Normal[j];
                            if (pomniejsz) znak = znak.ToLower();
                            pomniejsz = true;
                            j = 24;
                        }
                    }else{
                        i--;
                        znak = "";
                        j = 24;
                    }
                    wynik += znak;
                }
                if (znak == null){
                    textBox2.Text = "Error 404";
                    MessageBox.Show("FiFi nie rozpoznaje liczby \"" + lewo[i].ToString() + lewo[i+1].ToString() + "\"\n\nZamknij te okno i usuń tą liczbę");
                    i = lewDlug - 1; break;
                }
                textBox2.Text = wynik;
            }
        }
    }
}
