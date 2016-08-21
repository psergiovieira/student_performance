using System.Collections.Generic;
using System.Data;
using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Filters;
using StudentPerformanceApp.Classification;

namespace StudentPerformanceApp.Entities
{
    public class Bayes
    {
        public ConfusionMatrix Compute(List<Student> students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = UtilClassification.ALL_ATTRIBUTES;

            UtilClassification.FillColumns(data, labels);
            UtilClassification.FillRows(data, students);

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);
            int[][] inputs = symbols.ToIntArray(UtilClassification.TRAINING_ATTRIBUTES);

            int[] outputs = symbols.ToIntArray("famsize").GetColumn(0);

            // Gather information about decision variables
            var symbolCounts = SymbolCounts(codebook);

            int classCount = codebook["famsize"].Symbols;

            NaiveBayes target = new NaiveBayes(classCount, symbolCounts);

            // Compute the Naive Bayes model
            target.Estimate(inputs, outputs);

            List<bool> sucess = new List<bool>();
            int[] expected = new int[students.Count];
            int[] predicted = new int[students.Count];
            int count = 0;
            students.ForEach(student =>
            {
                int[] instance2 = codebook.Translate(student.School,
                    student.Age.ToString(),
                    student.Addreess,
                    student.Sex,
                    student.MotherEducation.ToString(),
                    student.ParentsCohabitationStatus.ToString(),
                    student.FatherEducation.ToString(),
                    student.TravelTime.ToString(),
                    student.StudyTime.ToString(),
                    student.FamilyRelationships.ToString(),
                    student.FreeTime.ToString(),
                    student.Goout.ToString(),
                    student.WorkdayAlcoholConsumption.ToString(),
                    student.WeekendAlcoholConsumption.ToString(),
                    student.CurrentHealthStatus.ToString(),
                    student.G1.ToString(),
                    student.G2.ToString(),
                    student.G3.ToString(),
                    student.SchoolSuport,
                    student.Failures.ToString(),
                    student.FamilySuport,
                    student.Paid,
                    student.Activities,
                    student.Nursery,
                    student.Higher,
                    student.Internet,
                    student.Romantic,
                    student.Absences.ToString(),
                    student.MotherJob,
                    student.FatherJob,
                    student.Reason,
                    student.Guardian);

                // Now, we can feed this instance to our model
                int output2 = target.Compute(instance2);

                // Finally, the result can be translated back to one of the codewords using
                string result2 = codebook.Translate("famsize", output2);
                bool isCorrect = result2 == student.FamilySize.ToString();
                sucess.Add(isCorrect);

                expected[count] = 1;
                predicted[count] = isCorrect ? 1 : 0;

                count++;
            });

            int positiveValue = 1;
            int negativeValue = 0;
            ConfusionMatrix matrix = new ConfusionMatrix(predicted, expected, positiveValue, negativeValue);

            return matrix;
        }

        private static int[] SymbolCounts(Codification codebook)
        {
            int[] symbolCounts =
            {
                codebook["school"].Symbols,
                codebook["age"].Symbols,
                codebook["address"].Symbols,
                codebook["sex"].Symbols,
                codebook["Medu"].Symbols,
                codebook["Pstatus"].Symbols,
                codebook["Fedu"].Symbols,
                codebook["traveltime"].Symbols,
                codebook["studytime"].Symbols,
                codebook["famrel"].Symbols,
                codebook["freetime"].Symbols,
                codebook["goout"].Symbols,
                codebook["Dalc"].Symbols,
                codebook["Walc"].Symbols,
                codebook["health"].Symbols,
                codebook["G1"].Symbols,
                codebook["G2"].Symbols,
                codebook["G3"].Symbols,
                codebook["schoolsup"].Symbols,
                codebook["failures"].Symbols,
                codebook["famsup"].Symbols,
                codebook["paid"].Symbols,
                codebook["activities"].Symbols,
                codebook["nursery"].Symbols,
                codebook["higher"].Symbols,
                codebook["internet"].Symbols,
                codebook["romantic"].Symbols,
                codebook["absences"].Symbols,
                codebook["Mjob"].Symbols,
                codebook["Fjob"].Symbols,
                codebook["reason"].Symbols,
                codebook["guardian"].Symbols
            };
            return symbolCounts;
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
