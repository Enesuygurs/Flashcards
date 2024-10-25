using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Flashcards
{
   
    public partial class MainWindow : Window
    {
        private List<Flashcard> flashcards = new List<Flashcard>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(QuestionTextBox.Text) && !string.IsNullOrEmpty(AnswerTextBox.Text))
            {
                var flashcard = new Flashcard
                {
                    Question = QuestionTextBox.Text,
                    Answer = AnswerTextBox.Text
                };

                flashcards.Add(flashcard);
                QuestionTextBox.Clear();
                AnswerTextBox.Clear();
                MessageBox.Show("Flashcard saved.");
            }
            else
            {
                MessageBox.Show("Please enter text.");
            }
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (flashcards.Count == 0)
            {
                MessageBox.Show("No flashcard.");
                return;
            }

            var random = new System.Random();
            var card = flashcards[random.Next(flashcards.Count)];
            MessageBox.Show($"Question: {card.Question}\nAnswer: {card.Answer}", "Flashcard");
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeRestore_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
