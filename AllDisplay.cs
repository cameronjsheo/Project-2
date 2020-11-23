using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DimensionData.Models
{
    public class AllDisplay
    {
        
        public int DetailD { get; set; }
        public int Age { get; set; }
        public string Attrition { get; set; }
        [DisplayName("Distance From Home")]
        public int DistanceFromHome { get; set; }
        public string Over18 { get; set; }
        public string Gender { get; set; }
        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }
        public int EducationID { get; set; }
        [DisplayName("Education Level")]
        public int Education { get; set; }
        [DisplayName("Education Field")]
        public string EducationField { get; set; }
        public int JobID { get; set; }
        [DisplayName("Job Role")]
        public string JobRole { get; set; }
        public string Department { get; set; }
        [DisplayName("Job Level")]
        public int JobLevel { get; set; }
        public int StandardHours { get; set; }
        public int EmployeeCount { get; set; }
        public string BusinessTravel { get; set; }
        [DisplayName("Stock Option Level")]
        public int StockOptionLevel { get; set; }
        public int SurveyID { get; set; }
        [DisplayName("Environment Satisfaction")]
        public int EnvironmentSatisfaction { get; set; }
        [DisplayName("Job Satisfaction")]
        public int JobSatsifaction { get; set; }
        [DisplayName("Relationship Satisfaction")]
        public int RelationshipSatisfaction { get; set; }
        public int PerformanceID { get; set; }
        [DisplayName("Job Involvement")]
        public int JobInvolvement { get; set; }
        [DisplayName("Performance Rating")]
        public int PerformanceRating { get; set; }
        [DisplayName("Work Life Balance")]
        public int WorkLifeBalance { get; set; }
        public int HistoryID { get; set; }
        [DisplayName("Number of Companies Worked")]
        public int NumCompaniesWorked { get; set; }
        [DisplayName("Total Working Years")]
        public int TotalWorkingYears { get; set; }
        [DisplayName("Training Times Last Year")]
        public int TrainingTimesLastYear { get; set; }
        public int YearsAtCompany { get; set; }
        [DisplayName("Years in Current Role")]
        public int YearsInCurrentRole { get; set; }
        [DisplayName("Years Since Last Promotion")]
        public int YearsSinceLastPromotion { get; set; }
        [DisplayName("Years With Current Manager")]
        public int YearsWithCurrManager { get; set; }
        public int CostID { get; set; }
        public int HourlyRate { get; set; }
        public int DailyRate { get; set; }
        public int MonthlyRate { get; set; }
        public int MonthlyIncome { get; set; }
        public string OverTime { get; set; }
        [DisplayName("Percent Salary Hike")]
        public int PercentSalaryHike { get; set; }
    }
}
