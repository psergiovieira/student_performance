using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            Console.ReadLine();
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
                if (!IsRepeated(student, students))
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
