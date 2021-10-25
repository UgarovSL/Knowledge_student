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
using System.Text.RegularExpressions;

namespace Knowledge_student
{
    /// <summary>
    /// Логика взаимодействия для CreateQuestion.xaml
    /// </summary>
    /// 
    public static class RecordOfQuestion
    {
        public static Questions recordOfQuestion;
    }
    public partial class CreateQuestion : Page
    {
        public CreateQuestion()
        {
            InitializeComponent();
        }
        const int minLengthName = 0;
        const int maxLenghtName = 50;
        const int maxMaxPoint = 4;

        private void BtnCreateQuestion(object sender, RoutedEventArgs e)
        {
            string nameQuestion = textBoxNameQue.Text.Trim();
            string numberTheme = textBoxNumberTheme.Text.Trim();
            string nameAnswer = textBoxAnswer.Text.Trim().ToLower();
            string quePoint = textBoxPoint.Text.Trim();
            string numberTest = textBoxNumberTest.Text.Trim();

            if (nameQuestion.Length >= maxLenghtName || nameQuestion.Length <= minLengthName || !Regex.IsMatch(nameQuestion, @"[\dа-я]"))
            {

                textBoxNameQue.ToolTip = "Некорректно введено название теста.";
                var backgroundColor = new BrushConverter();
                textBoxNameQue.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNameQue.Background = Brushes.Transparent;
                textBoxNameQue.ToolTip = null;

            }
            if (!Regex.IsMatch(numberTheme, @"[\d0-9]"))
            {

                textBoxNumberTheme.ToolTip = "Некорректно введен номер темы.";
                var backgroundColor = new BrushConverter();
                textBoxNumberTheme.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNumberTheme.Background = Brushes.Transparent;
                textBoxNumberTheme.ToolTip = null;
            }
            if (nameAnswer.Length >= maxLenghtName || nameAnswer.Length <= minLengthName || !Regex.IsMatch(nameQuestion, @"^[\da-z]+$"))
            {

                textBoxAnswer.ToolTip = "Некорректно введено название ответа.";
                var backgroundColor = new BrushConverter();
                textBoxAnswer.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxAnswer.Background = Brushes.Transparent;
                textBoxAnswer.ToolTip = null;
            }
            if (quePoint.Length >= maxMaxPoint || !Regex.IsMatch(quePoint, @"[\d0-9]"))
            {

                textBoxPoint.ToolTip = "Некорректно введено колличество баллов.";
                var backgroundColor = new BrushConverter();
                textBoxPoint.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxPoint.Background = Brushes.Transparent;
                textBoxPoint.ToolTip = null;
            }
            if (!Regex.IsMatch(numberTest, @"[\d0-9]"))
            {

                textBoxNumberTest.ToolTip = "Некорректно введен номер теста.";
                var backgroundColor = new BrushConverter();
                textBoxNumberTest.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                textBoxNumberTest.Background = Brushes.Transparent;
                textBoxNumberTest.ToolTip = null;
                Questions addQuestion = null;
                using (var context = new Knowledge_controlEntities())
                {

                    int intQuePoint = Convert.ToInt32(quePoint);
                    int intNumberTheme = Convert.ToInt32(numberTheme);
                    int intNumberTest = Convert.ToInt32(numberTest);

                    if (context.Themes.Where(x => x.Number_theme == intNumberTheme).Select(x => x).Count() > 0)
                    {
                        if (context.Tests.Where(x => x.Number_test == intNumberTest).Select(x => x).Count() > 0)
                        {


                            addQuestion = context.Questions.Where(check => check.Question == nameQuestion).FirstOrDefault();

                            if (addQuestion == null)
                            {
                                var question = new Questions()
                                {
                                    Question = nameQuestion,
                                    Number_theme = intNumberTheme,
                                    Answers = nameAnswer,
                                    Points = intQuePoint,
                                    Number_test = intNumberTest

                                };
                                context.Questions.Add(question);
                                context.SaveChanges();


                                RecordOfQuestion.recordOfQuestion = context.Questions.Where(x => x.Question == nameQuestion && x.Number_theme == intNumberTheme).Select(x => x).FirstOrDefault();


                            }


                            else

                                MessageBox.Show("Такой вопрос уже существует");

                        }
                        else
                            MessageBox.Show("Такой темы не сущетсвует");
                    }
                    else
                        MessageBox.Show("Такой тест не сущетсвует");

                }
            }
        }
    }
}
