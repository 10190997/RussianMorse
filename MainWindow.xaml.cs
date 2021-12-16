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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Morze
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
                    translation += "☺";
                }
            }
            tbMorze.Text = translation;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Window window = new SoundWindow(tbText.Text);
            window.ShowDialog();
        }
    }
}
