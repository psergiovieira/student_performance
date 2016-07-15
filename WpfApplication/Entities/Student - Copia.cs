using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIA.Entities
{
    public class Student
    {
        /// <summary>
        /// student's school (binary: "GP" - Gabriel Pereira or "MS" - Mousinho da Silveira)
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// student's sex (binary: "F" - female or "M" - male)
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// student's age (numeric: from 15 to 22)
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// student's home address type (binary: "U" - urban or "R" - rural)
        /// </summary>
        public string Addreess { get; set; }

        /// <summary>
        /// family size (binary: "LE3" - less or equal to 3 or "GT3" - greater than 3)
        /// </summary>
        public string FamilySize { get; set; }

        /// <summary>
        /// parent's cohabitation status (binary: "T" - living together or "A" - apart)
        /// </summary>
        public string ParentsCohabitationStatus { get; set; }

        /// <summary>
        /// mother's education (numeric: 0 - none,  1 - primary education (4th grade), 2 – 5th to 9th grade, 3 – secondary education or 4 – higher education)
        /// </summary>
        public int MotherEducation { get; set; }

        /// <summary>
        /// father's education (numeric: 0 - none,  1 - primary education (4th grade), 2 – 5th to 9th grade, 3 – secondary education or 4 – higher education)
        /// </summary>
        public int FatherEducation { get; set; }

        /// <summary>
        /// Mjob - mother's job (nominal: "teacher", "health" care related, civil "services" (e.g. administrative or police), "at_home" or "other")
        /// </summary>
        public string MotherJob { get; set; }

        /// <summary>
        /// father's job (nominal: "teacher", "health" care related, civil "services" (e.g. administrative or police), "at_home" or "other")
        /// </summary>
        public string FatherJob { get; set; }

        /// <summary>
        /// reason to choose this school (nominal: close to "home", school "reputation", "course" preference or "other")
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// student's guardian (nominal: "mother", "father" or "other")
        /// </summary>
        public string Guardian { get; set; }

        /// <summary>
        /// home to school travel time
        /// 1 - < 15 min
        /// 2 - 15 to 30 min
        /// 3 - 30 minto 1 hour
        /// 4 - >1 hour
        /// </summary>
        public int TravelTime { get; set; }

        /// <summary>
        /// weekly study time  
        /// 1 - < 2 hours
        /// 2 - 2 to 5 hours
        /// 3 - 5 to 10 hours
        /// 4 - > 10 hours
        /// </summary>
        public int StudyTime { get; set; }

        /// <summary>
        /// number of past class failures  
        /// n if 1 <= n<3, else 4
        /// </summary>
        public int Failures { get; set; }

        /// <summary>
        /// extra educational support (binary: yes or no)
        /// </summary>
        public string SchoolSuport { get; set; }

        /// <summary>
        /// family educational support (binary: yes or no)
        /// </summary>
        public string FamilySuport { get; set; }

        /// <summary>
        /// extra paid classes within the course subject (Math or Portuguese) (binary: yes or no)
        /// </summary>
        public string Paid { get; set; }

        /// <summary>
        ///  extra-curricular activities (binary: yes or no)
        /// </summary>
        public string Activities { get; set; }

        /// <summary>
        /// attended nursery school (binary: yes or no)
        /// </summary>
        public string Nursery { get; set; }

        /// <summary>
        /// Wants to take higher education (binary: yes or no)
        /// </summary>
        public string Higher { get; set; }

        /// <summary>
        /// Internet access at home (binary: yes or no)
        /// </summary>
        public string Internet { get; set; }

        /// <summary>
        /// with a romantic relationship (binary: yes or no)
        /// </summary>
        public string Romantic { get; set; }

        /// <summary>
        /// quality of family relationships (numeric: from 1 - very bad to 5 - excellent)
        /// </summary>
        public int FamilyRelationships { get; set; }

        /// <summary>
        /// free time after school (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int FreeTime { get; set; }

        /// <summary>
        /// going out with friends (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int Goout { get; set; }

        /// <summary>
        /// workday alcohol consumption (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int WorkdayAlcoholConsumption { get; set; }

        /// <summary>
        ///  weekend alcohol consumption (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int WeekendAcoholConsumption { get; set; }

        /// <summary>
        ///  current health status (numeric: from 1 - very bad to 5 - very good)
        /// </summary>
        public int CurrentHealthStatus { get; set; }

        /// <summary>
        /// number of school absences (numeric: from 0 to 93)
        /// </summary>
        public int Absences { get; set; }

        #region # these grades are related with the course subject, Math or Portuguese:

        /// <summary>
        /// first period grade (numeric: from 0 to 20)
        /// </summary>
        public double G1 { get; set; }

        /// <summary>
        /// second period grade (numeric: from 0 to 20)
        /// </summary>
        public double G2 { get; set; }

        /// <summary>
        /// final grade (numeric: from 0 to 20, output target)
        /// </summary>
        public double G3 { get; set; }

        #endregion
    }
}
