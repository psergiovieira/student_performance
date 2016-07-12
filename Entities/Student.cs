using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace TrabalhoIA.Entities
{
    public class Student
    {
        public Student()
        {
            ErrorList = new List<string>();
        }

        public List<string> ErrorList;

        private string _school;
        /// <summary>
        /// student's school (binary: "GP" - Gabriel Pereira or "MS" - Mousinho da Silveira)
        /// </summary>
        public string School
        {
            get { return _school; }
            set
            {
                _school = value.ToUpper().Trim();
                if (!Util.ValidSchools.Contains(_school))
                {
                    ErrorList.Add("Invalid School - " + _school);
                }
            }
        }

        private string _sex;

        /// <summary>
        /// student's sex (binary: "F" - female or "M" - male)
        /// </summary>
        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value.ToUpper().Trim();
                if (_sex != "F" && _sex != "M")
                {
                    ErrorList.Add("Invalid Gender - " + _sex);
                }
            }
        }

        private int _age;

        /// <summary>
        /// student's age (numeric: from 15 to 22)
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                if (_age < 15 || _age > 22)
                {
                    ErrorList.Add("Invalid Age - " + _age);
                }
            }
        }

        private string _address;
        /// <summary>
        /// student's home address type (binary: "U" - urban or "R" - rural)
        /// </summary>
        public string Addreess
        {
            get { return _address; }
            set
            {
                _address = value.Trim().ToUpper();
                if (_address != "U" || _address != "R")
                    ErrorList.Add("Invalid Address - " + _address);
            }
        }

        private string _familySize;
        /// <summary>
        /// family size (binary: "LE3" - less or equal to 3 or "GT3" - greater than 3)
        /// </summary>
        public string FamilySize
        {
            get
            {
                return _familySize;
            }

            set
            {
                _familySize = value.Trim().ToUpper();
                if (_familySize != "LE3" || _familySize != "GT3")
                    ErrorList.Add("Invalid Family size - " + _familySize);
            }
        }

        private string _parentsCohabitationStatus;

        /// <summary>
        /// parent's cohabitation status (binary: "T" - living together or "A" - apart)
        /// </summary>
        public string ParentsCohabitationStatus
        {
            get
            {
                return _parentsCohabitationStatus;
            }
            set
            {
                _parentsCohabitationStatus = value.Trim().ToUpper();
                if (_parentsCohabitationStatus != "A" && _parentsCohabitationStatus != "T")
                    ErrorList.Add("Invalid parents cohabitation status - " + _parentsCohabitationStatus);
            }
        }

        private int _motherEducation;
        /// <summary>
        /// mother's education 
        /// 0 - none
        /// 1 - primary education (4th grade)
        /// 2 – 5th to 9th grade
        /// 3 – secondary education 
        /// 4 – higher education)
        /// </summary>
        public int MotherEducation
        {
            get
            {
                return _motherEducation;
            }
            set
            {
                _motherEducation = value;
                if (_motherEducation < 0 || _motherEducation > 4)
                    ErrorList.Add("Invalid mother's education - " + _motherEducation);
            }
        }

        private int _fatherEducation;
        /// <summary>
        /// father's education
        /// 0 - none
        /// 1 - primary education (4th grade)
        /// 2 – 5th to 9th grade
        /// 3 – secondary education 
        /// 4 – higher education)
        /// </summary>
        public int FatherEducation
        {
            get
            {
                return _fatherEducation;

            }
            set
            {
                _fatherEducation = value;
                if (_fatherEducation < 0 || _fatherEducation > 4)
                    ErrorList.Add("Invalid father's education - " + _fatherEducation);
            }
        }

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

        public Course TargetCourse { get; set; }
        #endregion

        public bool IsValid()
        {
            return ErrorList.Count == 0;
        }
    }

    sealed class StudentMap : CsvClassMap<Student>
    {
        public StudentMap()
        {
            Map(m => m.School).Index(0);
            Map(m => m.Sex).Index(1);
            Map(m => m.Age).Index(2);
            Map(m => m.Addreess).Index(3);
            Map(m => m.FamilySize).Index(4);
            Map(m => m.ParentsCohabitationStatus).Index(5);
            Map(m => m.MotherEducation).Index(6);
            Map(m => m.FatherEducation).Index(7);
            Map(m => m.MotherJob).Index(8);
            Map(m => m.FatherJob).Index(9);
            Map(m => m.Reason).Index(10);
            Map(m => m.Guardian).Index(11);
            Map(m => m.TravelTime).Index(12);
            Map(m => m.StudyTime).Index(13);
            Map(m => m.Failures).Index(14);
            Map(m => m.SchoolSuport).Index(15);
            Map(m => m.FamilySuport).Index(16);
            Map(m => m.Paid).Index(17);
            Map(m => m.Activities).Index(18);
            Map(m => m.Nursery).Index(19);
            Map(m => m.Higher).Index(20);
            Map(m => m.Internet).Index(21);
            Map(m => m.Romantic).Index(22);
            Map(m => m.FamilyRelationships).Index(23);
            Map(m => m.FreeTime).Index(24);
            Map(m => m.Goout).Index(25);
            Map(m => m.WorkdayAlcoholConsumption).Index(26);
            Map(m => m.WeekendAcoholConsumption).Index(27);
            Map(m => m.CurrentHealthStatus).Index(28);
            Map(m => m.Absences).Index(29);
            Map(m => m.G1).Index(30);
            Map(m => m.G2).Index(31);
            Map(m => m.G3).Index(32);
        }
    }
}
