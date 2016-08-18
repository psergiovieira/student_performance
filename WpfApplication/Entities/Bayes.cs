using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Statistics.Filters;

namespace StudentPerformanceApp.Entities
{
    public class Bayes
    {

        public void Compute(List<Student> students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = new[] { "school", "age", "address", "sex", "famsize", "Medu", "Pstatus", "Fedu", "traveltime",
                "studytime", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "G1","G2","G3" };

            data.Columns.Add("ID");
            foreach (var label in labels)
            {
                data.Columns.Add(label);
            }

            int count = 0;
            foreach (var student in students)
            {
                count++;
                data.Rows.Add(count.ToString(),
                                student.School,
                                student.Age,
                                student.Addreess,
                                student.Sex,
                                student.FamilySize,
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
                                student.G3);

            }

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);
            int[][] inputs = symbols.ToIntArray("school", "age", "address", "sex", "famsize", "Medu", "Pstatus", "Fedu", "traveltime",
                                                 "studytime", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "G1", "G2");

            int[] outputs = symbols.ToIntArray("G3").GetColumn(0);

            // Gather information about decision variables
            int[] symbolCounts =
            {
              codebook["school"].Symbols, 
              codebook["age"].Symbols, 
              codebook["address"].Symbols,   
              codebook["sex"].Symbols ,
              codebook["famsize"].Symbols, 
              codebook["Medu"].Symbols, 
              codebook["Pstatus"].Symbols,   
              codebook["Fedu"].Symbols    ,
              codebook["traveltime"].Symbols, 
              codebook["studytime"].Symbols, 
              codebook["famrel"].Symbols,   
              codebook["freetime"].Symbols    ,
              codebook["goout"].Symbols, 
              codebook["Dalc"].Symbols, 
              codebook["Walc"].Symbols,   
              codebook["health"].Symbols ,   
              codebook["G1"].Symbols,   
              codebook["G2"].Symbols 
            };

            int classCount = codebook["G3"].Symbols;


            NaiveBayes target = new NaiveBayes(classCount, symbolCounts);
            // Compute the Naive Bayes model
            target.Estimate(inputs, outputs);

            // We will be computing the label for a sunny, cool, humid and windy day:
            int[] instance = codebook.Translate("GP", "15", "U", "F", "GT3", "4", "A", "4", "2", "2", "4", "3", "4", "2", "2", "2", "11", "12");

            // Now, we can feed this instance to our model
            int output = target.Compute(instance);

            // Finally, the result can be translated back to one of the codewords using
            string result = codebook.Translate("G3", output); // result is "No"
            var a = 0;
        }

        public void Compute(double[,] students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = new[] { "school", "sex", "age", "G3" };


            foreach (var label in labels)
            {
                data.Columns.Add(label);
            }

            int count = 0;
            for (int i = 0; i < 635; i++)
            {
                data.Rows.Add(students[i, 0], students[i, 1], students[i, 2], students[i, 3]);
            }

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);
            int[][] inputs = symbols.ToIntArray("school", "sex", "age");

            int[] outputs = symbols.ToIntArray("G3").GetColumn(0);

            // Gather information about decision variables
            int[] symbolCounts =
            {
              codebook["school"].Symbols, 
              codebook["sex"].Symbols, 
              codebook["age"].Symbols
            };

            int classCount = codebook["G3"].Symbols;


            NaiveBayes target = new NaiveBayes(classCount, symbolCounts);
            // Compute the Naive Bayes model
            target.Estimate(inputs, outputs);

            // We will be computing the label for a sunny, cool, humid and windy day:
            int[] instance = codebook.Translate("1", "1", "17");

            // Now, we can feed this instance to our model
            int output = target.Compute(instance);

            // Finally, the result can be translated back to one of the codewords using
            string result = codebook.Translate("G3", output); // result is "No"

        }
    }
}
