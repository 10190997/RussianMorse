using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Morse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly Dictionary<char, string> Morze = new Dictionary<char, string>
        {
            { (char)32, " " },
            { 'а', ".-" },
            { 'б', "-..." },
            { 'в', ".--" },
            { 'г', "--." },
            { 'д', "-.." },
            { 'е', "." },
            { 'ё', "." },
            { 'ж', "...-" },
            { 'з', "--.." },
            { 'и', ".." },
            { 'й', ".---" },
            { 'к', "-.-" },
            { 'л', ".-.." },
            { 'м', "--" },
            { 'н', "-." },
            { 'о', "---" },
            { 'п', ".--." },
            { 'р', ".-." },
            { 'с', "..." },
            { 'т', "-" },
            { 'у', "..-" },
            { 'ф', "..-." },
            { 'х', "...." },
            { 'ц', "-.-." },
            { 'ч', "---." },
            { 'ш', "----" },
            { 'щ', "--.-" },
            { 'ъ', "--.--" },
            { 'ы', "-.--" },
            { 'ь', "-..-" },
            { 'э', "..-.." },
            { 'ю', "..--" },
            { 'я', ".-.-" },
            { 'a', ".-" },
            { 'b', "-..." },
            { 'c', "-.-." },
            { 'd', "-.." },
            { 'e', "." },
            { 'f', "..-." },
            { 'g', "--." },
            { 'h', "...." },
            { 'i', ".." },
            { 'j', ".---" },
            { 'k', "-.-" },
            { 'l', ".-.." },
            { 'm', "--" },
            { 'n', "-." },
            { 'o', "---" },
            { 'p', ".--." },
            { 'q', "--.-" },
            { 'r', ".-." },
            { 's', "..." },
            { 't', "-" },
            { 'u', "..-" },
            { 'v', "...-" },
            { 'w', ".--" },
            { 'x', "-..-" },
            { 'y', "-.--" },
            { 'z', "--.." },
            { '1', ".----" },
            { '2', "..---" },
            { '3', "...--" },
            { '4', "....-" },
            { '5', "....." },
            { '6', "-...." },
            { '7', "--..." },
            { '8', "---.." },
            { '9', "----." },
            { '0', "-----" },
            { '.', "......" },
            { ',', ".-.-.-" },
            { '!', "--..--" },
            { '?', "..--.." },
            { '\'', ".----." },
            { '"', ".-..-." },
            { ';', "-.-.-." },
            { ':', "---..." },
            { '—', "-....-" },
            { '-', "-....-" },
            { '+', ".-.-." },
            { '=', "-...-" },
            { '_', "..--.-" },
            { '/', "-..-." },
            { '(', "-.--.-" },
            { ')', "-.--.-" },
            { '&', ".-..." },
            { '$', "...-..-" },
            { '@', ".--.-." }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TbText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string translation = "";
            for (int i = 0; i < tbText.Text.Length; i++)
            {
                char item = tbText.Text[i];
                try
                {
                    translation += Morze[char.ToLower(item)];
                    if (i < 1)
                    {
                        if (!char.IsWhiteSpace(item))
                        {
                            translation += (char)160;
                        }
                    }
                    else if (!char.IsWhiteSpace(item) && !char.IsWhiteSpace(tbText.Text[i - 1]))
                    {
                        translation += (char)160;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Символ не найден");
                    tbText.Text = tbText.Text.Remove(tbText.Text.Length - 1);
                    tbText.CaretIndex = tbText.Text.Length;
                }
            }
            tbMorze.Text = translation;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            btnPlay.Click -= BtnPlay_Click;

            var text = tbText.Text;
            //Пауза между знаками в букве — одна точка, между буквами в слове — 3 точки, между словами — 7 точек
            SoundPlayer longSound = new SoundPlayer("../../sounds/long.wav"); // -
            SoundPlayer shortSound = new SoundPlayer("../../sounds/short.wav"); // .

            foreach (char item in text)
            {
                string sounds;
                try
                {
                    sounds = Morze[char.ToLower(item)];
                }
                catch (Exception)
                {
                    MessageBox.Show("Проигрывание остановлено. Нераспознанный символ");
                    break;
                }
                
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
            //Thread.Sleep(1000); //одна точка
            //Thread.Sleep(3000); //три точки
            //Thread.Sleep(7000); //семь точек
        }
    }
}

