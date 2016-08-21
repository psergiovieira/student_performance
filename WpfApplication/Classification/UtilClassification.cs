using System.Collections.Generic;
using System.Data;
using StudentPerformanceApp.Entities;

namespace StudentPerformanceApp.Classification
{
    public class UtilClassification
    {
        public static string[] ALL_ATTRIBUTES = { "school", "age", "address", "sex", "Medu", "Pstatus", "Fedu", "traveltime",
                "studytime", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "G1","G2","G3", "schoolsup", "failures", "famsup", "paid", 
                "activities","nursery", "higher", "internet", "romantic", "absences", "Mjob", "Fjob", "reason", "guardian", "famsize" };

        public static string[] TRAINING_ATTRIBUTES = {
            "school", "age", "address", "sex", "Medu", "Pstatus", "Fedu", "traveltime",
            "studytime", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "G1", "G2", "G3", "schoolsup",
            "failures", "famsup", "paid",
            "activities", "nursery", "higher", "internet", "romantic", "absences", "Mjob", "Fjob", "reason", "guardian"
        };

        public static void FillColumns(DataTable data, string[] labels)
        {
            data.Columns.Add("ID");
            foreach (var label in labels)
            {
                data.Columns.Add(label);
            }
        }

        public static void FillRows(DataTable data, List<Student> students)
        {
            int count = 0;
            foreach (var student in students)
            {
                count++;
                data.Rows.Add(count.ToString(),
                    student.School,
                    student.Age,
                    student.Addreess,
                    student.Sex,
                    student.MotherEducation,
                    student.ParentsCohabitationStatus,
                    student.FatherEducation,
                    student.TravelTime,
                    student.StudyTime,
                    student.FamilyRelationships,
                    student.FreeTime,
                    student.Goout,
                    student.WorkdayAlcoholConsumption,
                    student.WeekendAlcoholConsumption,
                    student.CurrentHealthStatus,
                    student.G1,
                    student.G2,
                    student.G3,
                    student.SchoolSuport,
                    student.Failures,
                    student.FamilySuport,
                    student.Paid,
                    student.Activities,
                    student.Nursery,
                    student.Higher,
                    student.Internet,
                    student.Romantic,
                    student.Absences,
                    student.MotherJob,
                    student.FatherJob,
                    student.Reason,
                    student.Guardian,
                    student.FamilySize);
            };
        }
    }
}
