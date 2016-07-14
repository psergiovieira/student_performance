using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Accord.Statistics.Analysis;
using CsvHelper;
using TrabalhoIA.Entities;

namespace TrabalhoIA
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsPortugueseCourse = ReadRecords(@"D:\Studies\UFLA\IA\student\student-por.csv", Course.Portuguese);
            var studentsMathCourse = ReadRecords(@"D:\Studies\UFLA\IA\student\student-mat.csv", Course.Math);

            var matrix = ConvertToMatrix(studentsPortugueseCourse);

            var pca = new PrincipalComponentAnalysis(matrix, AnalysisMethod.Center);
            pca.Compute();

            Console.ReadLine();
        }

        private static double[,] ConvertToMatrix(List<Student> students)
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



        static List<Student> ReadRecords(string path, Course course)
        {
            var students = new List<Student>();
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
            }

            return students;
        }

        static bool IsRepeated(Student student, List<Student> students)
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
