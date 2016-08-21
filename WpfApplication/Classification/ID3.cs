using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Filters;
using StudentPerformanceApp.Entities;

namespace StudentPerformanceApp
{
    public class ID3
    {
        public ID3()
        {

        }

        public int Compute(List<Student> students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = new[] { "school", "age", "address", "sex", "Medu", "Pstatus", "Fedu", "traveltime",
                "studytime", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "G1","G2","G3", "famsize" };

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
                                student.FamilySize);
            };

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);

            int[][] inputs = symbols.ToArray<int>(new[] { "school", "age", "address", "sex", "Medu", "Pstatus", "Fedu", "traveltime", 
                "studytime", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "G1","G2","G3" });

            int[] outputs = symbols.ToArray<int>("famsize");
            // Gather information about decision variables

            // Gather information about decision variables
            DecisionVariable[] attributes =
            {
              new DecisionVariable("school",     2), 
              new DecisionVariable("age", 8),  
              new DecisionVariable("address",    2),
              new DecisionVariable("sex",    2),
              new DecisionVariable("Medu", 5),
              new DecisionVariable("Pstatus", 5), 
              new DecisionVariable("Fedu", 5),
              new DecisionVariable("traveltime",4),   
              new DecisionVariable("studytime",4),           
              new DecisionVariable("famrel", 5),  
              new DecisionVariable("freetime", 5),  
              new DecisionVariable("goout",5), 
              new DecisionVariable("Dalc", 5), 
              new DecisionVariable("Walc",5),            
              new DecisionVariable("health",  5),   
              new DecisionVariable("G1",21),
              new DecisionVariable("G2",21),
              new DecisionVariable("G3",21)
            };

            int classCount = 21;

            //Create the decision tree using the attributes and classes
            DecisionTree tree = new DecisionTree(attributes, classCount);

            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(tree);

            // Learn the training instances!
            id3learning.Run(inputs, outputs);
            //var translate = codebook.Translate("GP", "15", "U", "F", "4", "A", "4", "2", "2", "4", "3", "4", "2", "2", "2", "11","12","11");
            //string answer = codebook.Translate("famsize", tree.Compute(translate));
            //var a = 0;

            List<bool> sucess = new List<bool>();
            students.ForEach(student =>
            {
                var translate2 = codebook.Translate(student.School,
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
                    student.G3.ToString());
                string answer2 = codebook.Translate("famsize", tree.Compute(translate2));
                sucess.Add(answer2 == student.FamilySize);
            });

            int q = sucess.Where(c => c).ToList().Count;

            return q;
        }

        #region Example
        public void ComputeError(List<Student> students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = new[] {"sex","age","address","famsize","Pstatus","Medu","Fedu","Mjob","Fjob",
                "reason","guardian","traveltime","studytime","failures","schoolsup","famsup","paid","activities",
                "nursery","higher","internet","romantic","famrel","freetime","goout","Dalc","Walc","health","absences",
                "G1","G2","G3","school"};

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
                    student.Sex,
                    student.Age,
                    student.Addreess,
                    student.FamilySize,
                    student.ParentsCohabitationStatus,
                    student.MotherEducation,
                    student.FatherEducation,
                    student.MotherJob,
                    student.FatherJob,
                    student.Reason,
                    student.Guardian,
                    student.TravelTime,
                    student.StudyTime,
                    student.Failures,
                    student.SchoolSuport,
                    student.FamilySuport,
                    student.Paid,
                    student.Activities,
                    student.Nursery,
                    student.Higher,
                    student.Internet,
                    student.Romantic,
                    student.FamilyRelationships,
                    student.FreeTime,
                    student.Goout,
                    student.WorkdayAlcoholConsumption,
                    student.WeekendAlcoholConsumption,
                    student.CurrentHealthStatus,
                    student.Absences,
                    student.G1,
                    student.G2,
                    student.G3,
                    student.School);

            }

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);

            int[][] inputs = symbols.ToArray<int>(new[]{"sex","age","address","famsize","Pstatus","Medu","Fedu","Mjob","Fjob",
                "reason","guardian","traveltime","studytime","failures","schoolsup","famsup","paid","activities",
                "nursery","higher","internet","romantic","famrel","freetime","goout","Dalc","Walc","health","absences",
                "G1","G2","G3"});

            int[] outputs = symbols.ToArray<int>("school");

            // Gather information about decision variables
            DecisionVariable[] attributes =
            {
            //  new DecisionVariable("school", 2), 
              new DecisionVariable("sex", 2),
              new DecisionVariable("age", 8),     
              new DecisionVariable("address",2),
              new DecisionVariable("famsize", 2),  
              new DecisionVariable("Pstatus", 2), 
              new DecisionVariable("Medu", 5),
              new DecisionVariable("Fedu", 5),   
              new DecisionVariable("Mjob",5), 
              new DecisionVariable("Fjob",5),  
              new DecisionVariable("reason",4), 
              new DecisionVariable("guardian", 3), 
              new DecisionVariable("traveltime",4),   
              new DecisionVariable("studytime",4), 
              new DecisionVariable("failures", 4), 
              new DecisionVariable("schoolsup",2), 
              new DecisionVariable("famsup", 2), 
              new DecisionVariable("paid",2),  
              new DecisionVariable("activities", 2), 
              new DecisionVariable("nursery", 2),  
               new DecisionVariable("higher", 2), 
              new DecisionVariable("internet", 2),  
              new DecisionVariable("romantic",2),    
              new DecisionVariable("famrel", 5), 
              new DecisionVariable("freetime", 5),  
              new DecisionVariable("goout",5), 
              new DecisionVariable("Dalc", 5), 
              new DecisionVariable("Walc",5), 
              new DecisionVariable("health",  5),  
              new DecisionVariable("absences", 94), 
              new DecisionVariable("G1",21),  
              new DecisionVariable("G2",21),
              new DecisionVariable("G3",21)
            };

            int classCount = 2;

            //Create the decision tree using the attributes and classes
            DecisionTree tree = new DecisionTree(attributes, classCount);

            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(tree);

            // Learn the training instances!
            id3learning.Run(inputs, outputs);
            var translate = codebook.Translate("F", "18", "U", "GT3", "A", "4", "4", "at_home", "teacher", "course", "mother", "2", "2",
                "0", "yes", "no", "no", "no", "yes", "yes", "no", "no", "4", "3", "4", "1", "1", "3", "4", "0", "11", "11");

            string answer = codebook.Translate("school", tree.Compute(translate));
        }

        public void Compute1(List<Student> students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = new[] { "school", "age", "address", "sex", "G3" };

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
                                student.G3);

            }

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);

            int[][] inputs = symbols.ToArray<int>(new[] { "school", "age", "address", "sex" });

            int[] outputs = symbols.ToArray<int>("G3");
            // Gather information about decision variables

            // Gather information about decision variables
            DecisionVariable[] attributes =
            {
              new DecisionVariable("school",     2), 
              new DecisionVariable("age", 8),  
              new DecisionVariable("address",    2),
              new DecisionVariable("sex",    2)
            };

            int classCount = 21;

            //Create the decision tree using the attributes and classes
            DecisionTree tree = new DecisionTree(attributes, classCount);

            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(tree);

            // Learn the training instances!
            id3learning.Run(inputs, outputs);
            var translate = codebook.Translate("GP", "15", "U", "F");
            string answer = codebook.Translate("G3", tree.Compute(translate));
            var a = 0;
        }

        public void Compute2(List<Student> students)
        {
            DataTable data = new DataTable("Students Performance");

            var labels = new[] { "school", "age", "address", "sex" };

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
                     student.Sex);

            }

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, labels);

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);

            int[][] inputs = symbols.ToArray<int>(new[] { "school", "age", "address" });

            int[] outputs = symbols.ToArray<int>("sex");
            // Gather information about decision variables

            // Gather information about decision variables
            DecisionVariable[] attributes =
            {
              new DecisionVariable("school",     2), 
              new DecisionVariable("age", 8),  
              new DecisionVariable("address",    2)
            };


            int classCount = 2; // 2 possible output values for playing tennis: yes or no

            //Create the decision tree using the attributes and classes
            DecisionTree tree = new DecisionTree(attributes, classCount);

            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(tree);

            // Learn the training instances!
            id3learning.Run(inputs, outputs);
            var translate = codebook.Translate("GP", "15", "U");
            string answer = codebook.Translate("sex", tree.Compute(translate));
        }

        public void PlayTennis()
        {
            DataTable data = new DataTable("Mitchell's Tennis Example");
            var labels = new[] { "Day", "Outlook", "Temperature", "Humidity", "Wind", "PlayTennis" };

            foreach (var label in labels)
            {
                data.Columns.Add(label);
            }

            data.Rows.Add("D1", "Sunny", "Hot", "High", "Weak", "No");
            data.Rows.Add("D2", "Sunny", "Hot", "High", "Strong", "No");
            data.Rows.Add("D3", "Overcast", "Hot", "High", "Weak", "Yes");
            data.Rows.Add("D4", "Rain", "Mild", "High", "Weak", "Yes");
            data.Rows.Add("D5", "Rain", "Cool", "Normal", "Weak", "Yes");
            data.Rows.Add("D6", "Rain", "Cool", "Normal", "Strong", "No");
            data.Rows.Add("D7", "Overcast", "Cool", "Normal", "Strong", "Yes");
            data.Rows.Add("D8", "Sunny", "Mild", "High", "Weak", "No");
            data.Rows.Add("D9", "Sunny", "Cool", "Normal", "Weak", "Yes");
            data.Rows.Add("D10", "Rain", "Mild", "Normal", "Weak", "Yes");
            data.Rows.Add("D11", "Sunny", "Mild", "Normal", "Strong", "Yes");
            data.Rows.Add("D12", "Overcast", "Mild", "High", "Strong", "Yes");
            data.Rows.Add("D13", "Overcast", "Hot", "Normal", "Weak", "Yes");
            data.Rows.Add("D14", "Rain", "Mild", "High", "Strong", "No");

            // Create a new codification codebook to 
            // convert strings into integer symbols
            Codification codebook = new Codification(data, "Outlook", "Temperature", "Humidity", "Wind", "PlayTennis");

            // Translate our training data into integer symbols using our codebook:
            DataTable symbols = codebook.Apply(data);
            int[][] inputs = symbols.ToArray<int>("Outlook", "Temperature", "Humidity", "Wind");
            int[] outputs = symbols.ToArray<int>("PlayTennis");

            // Gather information about decision variables
            DecisionVariable[] attributes =
            {
              new DecisionVariable("Outlook",     3), // 3 possible values (Sunny, overcast, rain)
              new DecisionVariable("Temperature", 3), // 3 possible values (Hot, mild, cool)  
              new DecisionVariable("Humidity",    2), // 2 possible values (High, normal)    
              new DecisionVariable("Wind",        2)  // 2 possible values (Weak, strong) 
            };

            int classCount = 2; // 2 possible output values for playing tennis: yes or no

            //Create the decision tree using the attributes and classes
            DecisionTree tree = new DecisionTree(attributes, classCount);

            // Create a new instance of the ID3 algorithm
            ID3Learning id3learning = new ID3Learning(tree);

            // Learn the training instances!
            id3learning.Run(inputs, outputs);

            string answer = codebook.Translate("PlayTennis", tree.Compute(codebook.Translate("Sunny", "Hot", "High", "Strong")));
        } 
        #endregion
    }
}
