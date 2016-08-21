using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Accord.Statistics;
using Accord.Statistics.Analysis;
using CsvHelper;
using LiveCharts;
using LiveCharts.Wpf;
using StudentPerformanceApp.Entities;

namespace StudentPerformanceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            var students = ReadRecords(_pathFile.Text, Course.Portuguese);
            _dataGrid.ItemsSource = students;
            var matrix = ConvertToMatrix(students);

            double entropy = matrix.Entropy();
       

            var id3 = new ID3();
            var id3Classification = id3.Compute(students);
            txDTAcuracia.Text = id3Classification.Accuracy.ToString("N2");
            txDTPrecisao.Text = id3Classification.Precision.ToString("N2");
            txDTRevocacao.Text = id3Classification.Recall.ToString("N2");
            

            var bayes = new Bayes();
            var bayesClassification = bayes.Compute(students);
            txNBAcuracia.Text = bayesClassification.Accuracy.ToString("N2");
            txNBPrecisao.Text = bayesClassification.Precision.ToString("N2");
            txNBRevocacao.Text = bayesClassification.Recall.ToString("N2");

         
           
            _matrixNumber.ItemsSource2D = matrix;
            var pca = new PrincipalComponentAnalysis(matrix, AnalysisMethod.Center);
            pca.Compute();



            var colletion = new SeriesCollection();
            var line = new LineSeries();
            line.Values = new ChartValues<double>();
            foreach (var principalComponent in pca.Components)
            {
                line.Values.Add(principalComponent.Eigenvalue);

            }
            colletion.Add(line);

            _chart.Series = colletion;
        }

        private double[,] ConvertToMatrix(List<Student> students)
        {
            double[,] matrix = new double[students.Count, 33];
            int countStudents = 0;
            foreach (var student in students)
            {

                matrix[countStudents, 0] = student.School == "GP" ? 1 : 2;//GP = 1 MS = 2
                matrix[countStudents, 1] = student.Sex == "F" ? 1 : 2;//F = 1 M = 2
                matrix[countStudents, 2] = student.Age;
                matrix[countStudents, 3] = student.Addreess == "U" ? 1 : 2;//U = 1 R = 2
                matrix[countStudents, 4] = student.FamilySize == "LE3" ? 3 : 4;//LE3 = 3 GT3 = 4
                matrix[countStudents, 5] = student.ParentsCohabitationStatus == "T" ? 1 : 2;//T = 1 A = 2
                matrix[countStudents, 6] = student.MotherEducation;
                matrix[countStudents, 7] = student.FatherEducation;
                matrix[countStudents, 8] = student.MotherJobNumber();
                matrix[countStudents, 9] = student.FatherJobNumber();
                matrix[countStudents, 10] = student.ReasonNumber();
                matrix[countStudents, 11] = student.GuardianNumber();
                matrix[countStudents, 12] = student.TravelTime;
                matrix[countStudents, 13] = student.StudyTime;
                matrix[countStudents, 14] = student.Failures;
                matrix[countStudents, 15] = student.SchoolSuport == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 16] = student.FamilySuport == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 17] = student.Paid == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 18] = student.Activities == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 19] = student.Nursery == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 20] = student.Higher == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 21] = student.Internet == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 22] = student.Romantic == "YES" ? 1 : 2;//YES = 1 NO = 2
                matrix[countStudents, 23] = student.FamilyRelationships;
                matrix[countStudents, 24] = student.FreeTime;
                matrix[countStudents, 25] = student.Goout;
                matrix[countStudents, 26] = student.WorkdayAlcoholConsumption;
                matrix[countStudents, 27] = student.WeekendAlcoholConsumption;
                matrix[countStudents, 28] = student.CurrentHealthStatus;
                matrix[countStudents, 29] = student.Absences;
                matrix[countStudents, 30] = student.G1;
                matrix[countStudents, 31] = student.G2;
                matrix[countStudents, 32] = student.G3;

                countStudents++;
            }

            return matrix;
        }

        List<Student> ReadRecords(string path, Course course)
        {
            var students = new List<Student>();
            var invalidStudentsData = new List<Student>();
            TextReader reader = File.OpenText(path);
            var csv = new CsvReader(reader);
            csv.Configuration.Delimiter = ";";
            csv.Configuration.RegisterClassMap<StudentMap>();

            while (csv.Read())
            {
                var student = csv.GetRecord<Student>();
                student.TargetCourse = course;
                if (!IsRepeated(student, students) && student.IsValid())
                    students.Add(student);
                else
                {
                    invalidStudentsData.Add(student);
                }
            }

            _invalidData.Text = invalidStudentsData.Count.ToString();

            return students;
        }

        bool IsRepeated(Student student, List<Student> students)
        {
            return
                students.Any(
                    c =>
                        c.School == student.School && c.Sex == student.Sex && c.Age == student.Age &&
                        c.Addreess == student.Addreess && c.FamilySize == student.FamilySize &&
                        c.ParentsCohabitationStatus == student.ParentsCohabitationStatus &&
                        c.MotherEducation == student.MotherEducation && c.FatherEducation == student.FatherEducation &&
                        c.MotherJob == student.MotherJob &&
                        c.FatherJob == student.FatherJob && c.Reason == student.Reason && c.Nursery == student.Nursery &&
                        c.Internet == student.Internet);
        }
   }
}
