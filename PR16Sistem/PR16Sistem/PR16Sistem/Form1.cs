using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.IO;

namespace PR16Sistem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // создаем новый объект Ping для отправки запросов
                Ping ping = new Ping();

                // получаем IP-адрес, который нужно проверить
                string ip = textBox2.Text;

                // отправляем 4 запроса и ждем ответа в течение 1 секунды
                PingReply reply = ping.Send(ip, 1000, new byte[32], new PingOptions(4, true));

                // выводим результаты пинга в текстовое поле
                textBox1.Text = $"Адрес: {ip} \r\n";
                textBox1.AppendText($"Задержка: {reply.RoundtripTime} мс \r\n");
                textBox1.AppendText($"Статус: {reply.Status} \r\n");
            }
            catch (PingException ex)
            {
                // если ошибка пинга, выводим сообщение об ошибке
                MessageBox.Show($"Ошибка пинга: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.Filter = "Text Files (.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }

        }

        
    }
        
}
