using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace StudentPerformanceApp.Entities
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
                if (_address != "U" && _address != "R")
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
                if (_familySize != "LE3" && _familySize != "GT3")
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

        public  int FatherJobNumber()
        {
            switch (_fatherJob)
            {
                case "TEACHER":
                    return 1;
                case "HEALTH":
                    return 2;
                case "SERVICES":
                    return 3;
                case "AT_HOME":
                    return 4;
                case "OTHER":
                    return 5;
                default :
                    return 0;
            }
        }


        public int MotherJobNumber()
        {
            switch (_motherJob)
            {
                case "TEACHER":
                    return 1;
                case "HEALTH":
                    return 2;
                case "SERVICES":
                    return 3;
                case "AT_HOME":
                    return 4;
                case "OTHER":
                    return 5;
                default:
                    return 0;
            }
        }

        private static readonly string[] ValidJobs = { "TEACHER", "HEALTH", "SERVICES", "AT_HOME", "OTHER" };

        private string _motherJob;

        /// <summary>
        /// Mjob - mother's job (nominal: "teacher", "health" care related, civil "services" (e.g. administrative or police), "at_home" or "other")
        /// </summary>
        public string MotherJob
        {
            get { return _motherJob; }
            set
            {
                _motherJob = value.ToUpper().Trim();
                if (!ValidJobs.Contains(_motherJob))
                    ErrorList.Add("Invalid mother's job - " + _motherJob);
            }
        }

        private string _fatherJob;
        /// <summary>
        /// father's job (nominal: "teacher", "health" care related, civil "services" (e.g. administrative or police), "at_home" or "other")
        /// </summary>
        public string FatherJob
        {
            get { return _fatherJob; }
            set
            {
                _fatherJob = value.ToUpper().Trim();
                if (!ValidJobs.Contains(_fatherJob))
                    ErrorList.Add("Invalid father's job - " + _fatherJob);
            }
        }

        private static readonly string[] ValidReason = { "HOME", "REPUTATION", "COURSE", "OTHER" };
        private string _reason;
        /// <summary>
        /// reason to choose this school (nominal: close to "home", school "reputation", "course" preference or "other")
        /// </summary>
        public string Reason
        {
            get { return _reason; }
            set
            {
                _reason = value.ToUpper().Trim();
                if (!ValidReason.Contains(_reason))
                    ErrorList.Add("Invalid Reason - " + _reason);
            }
        }

        public int ReasonNumber()
        {
            switch (_reason)
            {
                case "HOME":
                    return 1;
                case "SCHOOL":
                    return 2;
                case "REPUTATION":
                    return 3;
                case "COURSE":
                    return 4;
                case "OTHER":
                    return 5;
                default:
                    return 0;
            }
        }


        private static readonly string[] ValidStudentsGuardian = { "MOTHER", "FATHER", "OTHER" };

        private string _guardian;
        /// <summary>
        /// student's guardian (nominal: "mother", "father" or "other")
        /// </summary>
        public string Guardian
        {
            get { return _guardian; }
            set
            {
                _guardian = value.ToUpper().Trim();
                if (!ValidStudentsGuardian.Contains(_guardian))
                    ErrorList.Add("Invalid Guardian - " + _guardian);
            }
        }

        public int GuardianNumber()
        {
            switch (_guardian)
            {
                case "MOTHER":
                    return 1;
                case "FATHER":
                    return 2;
                case "OTHER":
                    return 3;
                default:
                    return 0;
            }
        }

        private int _travelTime;
        /// <summary>
        /// home to school travel time
        /// 1 - < 15 min
        /// 2 - 15 to 30 min
        /// 3 - 30 minto 1 hour
        /// 4 - >1 hour
        /// </summary>
        public int TravelTime
        {
            get { return _travelTime; }
            set
            {
                _travelTime = value;
                if(_travelTime < 1 || _travelTime > 4)
                    ErrorList.Add("Invalid travel time - " + _travelTime);
            }
        }

        private int _studyTime;

        /// <summary>
        /// weekly study time  
        /// 1 - < 2 hours
        /// 2 - 2 to 5 hours
        /// 3 - 5 to 10 hours
        /// 4 - > 10 hours
        /// </summary>
        public int StudyTime
        {
            get { return _studyTime; }
            set
            {
                _studyTime = value;
                if (_studyTime < 1 || _studyTime > 4)
                    ErrorList.Add("Invalid Study time - " + _studyTime);
            }
        }

        private int _failures;

        /// <summary>
        /// number of past class failures  
        /// n if 1 <= n<3, else 4
        /// </summary>
        public int Failures
        {
            get { return _failures; }
            set
            {
                _failures = value;
                if (_failures < 1 || _studyTime > 3)
                    _failures = 4;
            }
        }

        private string _schoolSuport;

        /// <summary>
        /// extra educational support (binary: yes or no)
        /// </summary>
        public string SchoolSuport
        {
            get { return _schoolSuport; }
            set
            {
                _schoolSuport = value.ToUpper().Trim();
                if (!(_schoolSuport == "YES" || _schoolSuport == "NO"))
                    ErrorList.Add("Invalid Extra educational - " + _schoolSuport);
            }
        }

        private string _familySuport;
        /// <summary>
        /// family educational support (binary: yes or no)
        /// </summary>
        public string FamilySuport
        {
            get { return _familySuport; }
            set
            {
                _familySuport = value.ToUpper().Trim();
                if (!(_familySuport == "YES" || _familySuport == "NO"))
                    ErrorList.Add("Invalid family educational support - " + _schoolSuport);
            }
        }

        private string _paid;

        /// <summary>
        /// extra paid classes within the course subject (Math or Portuguese) (binary: yes or no)
        /// </summary>
        public string Paid
        {
            get { return _paid; }
            set
            {
                _paid = value.ToUpper().Trim();
                if (!(_paid == "YES" || _paid == "NO"))
                    ErrorList.Add("Invalid Paid - " + _paid);
            }
        }

        private string _activities;

        /// <summary>
        ///  extra-curricular activities (binary: yes or no)
        /// </summary>
        public string Activities
        {
            get { return _activities; }
            set
            {
                _activities = value.ToUpper().Trim();
                if (!(_activities == "YES" || _activities == "NO"))
                    ErrorList.Add("Invalid extra-curricular activities - " + _activities);
            }
        }

        private string _nursery;
        /// <summary>
        /// attended nursery school (binary: yes or no)
        /// </summary>
        public string Nursery
        {
            get { return _nursery; }
            set
            {
                _nursery = value.ToUpper().Trim();
                if (!(_nursery == "YES" || _nursery == "NO"))
                    ErrorList.Add("Invalid attended nursery school - " + _nursery);
            }
        }

        private string _higher;

        /// <summary>
        /// Wants to take higher education (binary: yes or no)
        /// </summary>
        public string Higher
        {
            get { return _higher; }
            set
            {
                _higher = value.ToUpper().Trim();
                if (!(_higher == "YES" || _higher == "NO"))
                    ErrorList.Add("Invalid information of to take higher education - " + _higher);
            }
        }

        private string _internet;
        /// <summary>
        /// Internet access at home (binary: yes or no)
        /// </summary>
        public string Internet
        {
            get { return _internet; }
            set
            {
                _internet = value.ToUpper().Trim();
                if (!(_internet == "YES" || _internet == "NO"))
                    ErrorList.Add("Invalid Internet access at home - " + _internet);
            }
        }

        private string _romantic;

        /// <summary>
        /// with a romantic relationship (binary: yes or no)
        /// </summary>
        public string Romantic
        {
            get { return _romantic; }
            set
            {
                _romantic = value.ToUpper().Trim();
                if (!(_romantic == "YES" || _romantic == "NO"))
                    ErrorList.Add("Invalid romantic relationship - " + _romantic);
            }
        }

        private int _familyRelationships;

        /// <summary>
        /// quality of family relationships (numeric: from 1 - very bad to 5 - excellent)
        /// </summary>
        public int FamilyRelationships
        {
            get { return _familyRelationships; }
            set
            {
                _familyRelationships = value;
                if (_familyRelationships < 1 || _familyRelationships > 5)
                    ErrorList.Add("Invalid quality of family relationships - " + _familyRelationships);
            }
        }

        private int _freeTime;

        /// <summary>
        /// free time after school (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int FreeTime
        {
            get { return _freeTime; }
            set
            {
                _freeTime = value;
                if (_freeTime < 1 || _freeTime > 5)
                    ErrorList.Add("Invalid free time after school  - " + _freeTime);
            }
        }

        private int _goout;

        /// <summary>
        /// going out with friends (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int Goout
        {
            get { return _goout; }
            set
            {
                _goout = value;
                if (_goout < 1 || _goout > 5)
                    ErrorList.Add("Invalid information of going out with friends  - " + _goout);
            }
        }

        private int _workdayAlcoholConsumption;
        /// <summary>
        /// workday alcohol consumption (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int WorkdayAlcoholConsumption
        {
            get { return _workdayAlcoholConsumption; }
            set
            {
                _workdayAlcoholConsumption = value;
                if (_workdayAlcoholConsumption < 1 || _workdayAlcoholConsumption > 5)
                    ErrorList.Add("Invalid information of workday alcohol consumption  - " + _workdayAlcoholConsumption);
            }
        }

        private int _wekeendAlcoholConsumption;
        /// <summary>
        ///  weekend alcohol consumption (numeric: from 1 - very low to 5 - very high)
        /// </summary>
        public int WeekendAlcoholConsumption
        {
            get { return _wekeendAlcoholConsumption; }
            set
            {
                _wekeendAlcoholConsumption = value;
                if (_wekeendAlcoholConsumption < 1 || _wekeendAlcoholConsumption > 5)
                    ErrorList.Add("Invalid information of weekend alcohol consumption  - " + _wekeendAlcoholConsumption);
            }
        }

        private int _currentHealth;

        /// <summary>
        ///  current health status (numeric: from 1 - very bad to 5 - very good)
        /// </summary>
        public int CurrentHealthStatus
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
                if (_currentHealth < 1 || _currentHealth > 5)
                    ErrorList.Add("Invalid information of current health status  - " + _currentHealth);
            }
        }

        private int _absences;
        /// <summary>
        /// number of school absences (numeric: from 0 to 93)
        /// </summary>
        public int Absences
        {
            get { return _absences; }
            set
            {
                _absences = value;
                if (_absences < 0 || _absences > 93)
                    ErrorList.Add("Invalid information of number of school absences  - " + _absences);
            }
        }

        #region # these grades are related with the course subject, Math or Portuguese:

        private double _g1;

        /// <summary>
        /// first period grade (numeric: from 0 to 20)
        /// </summary>
        public double G1
        {
            get { return _g1; }
            set
            {
                _g1 = value;
                if (_g1 < 0 || _g1 > 20)
                    ErrorList.Add("Invalid information of first period grade  - " + _g1);
            }
        }

        private double _g2;

        /// <summary>
        /// second period grade (numeric: from 0 to 20)
        /// </summary>
        public double G2
        {
            get { return _g2; }
            set
            {
                _g2 = value;
                if (_g2 < 0 || _g2 > 20)
                    ErrorList.Add("Invalid information of second period grade  - " + _g2);
            }
        }

        private double _g3;

        /// <summary>
        /// final grade (numeric: from 0 to 20, output target)
        /// </summary>
        public double G3
        {
            get { return _g3; }
            set
            {
                _g3 = value;
                if (_g3 < 0 || _g3 > 20)
                    ErrorList.Add("Invalid information of final grade  - " + _g3);
            }
        }

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
            Map(m => m.WeekendAlcoholConsumption).Index(27);
            Map(m => m.CurrentHealthStatus).Index(28);
            Map(m => m.Absences).Index(29);
            Map(m => m.G1).Index(30);
            Map(m => m.G2).Index(31);
            Map(m => m.G3).Index(32);
        }
    }
}
