using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Morze
{
    /// <summary>
    /// Логика взаимодействия для SoundWindow.xaml
    /// </summary>
    public partial class SoundWindow : Window
    {
        private string text;

        public SoundWindow(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Пауза между знаками в букве — одна точка, между буквами в слове — 3 точки, между словами — 7 точек
            SoundPlayer longSound = new SoundPlayer("../../sounds/long.wav"); // -
            SoundPlayer shortSound = new SoundPlayer("../../sounds/short.wav"); // .

            foreach (char item in text)
            {
                string sounds = MainWindow.Morze[char.ToLower(item)];
                Thread.Sleep(1000);
                foreach (char sound in sounds)
                {
                    switch (sound)
                    {
                        case '.':
                            {
                                shortSound.Play();
                                Thread.Sleep(500);
                                break;
                            }
                        case '-':
                            {
                                longSound.Play();
                                Thread.Sleep(500);
                                break;
                            }
                        case ' ':
                            {
                                shortSound.Play();
                                Thread.Sleep(3000);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            Close();
            //Thread.Sleep(1000); //одна точка
            //Thread.Sleep(3000); //три точки
            //Thread.Sleep(7000); //семь точек
        }
    }
}

