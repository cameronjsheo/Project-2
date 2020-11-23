using DimensionData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DimensionData.DAL
{
    public class Context
    {
        string connectionString = "Server = tcp:admin23.database.windows.net,1433;Initial Catalog = DimensionDataDB; Persist Security Info=False;User ID = Admin17; Password=ad17@1505;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public IEnumerable<Employee> GetEmployees()
        {
            var emplist = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT EmployeeNumber, Gender, Age, Department, JobRole, JobLevel  from JobInformation, Employee, EmpDetails where JobInformation.JobID = Employee.JobID and Empdetails.DetailD = Employee.DetailsID"
                    , con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var employee = new Employee();
                    employee.EmployeeNumber = Convert.ToInt32(dr["EmployeeNumber"].ToString());
                    employee.Gender = dr["Gender"].ToString();
                    employee.Age = Convert.ToInt32(dr["Age"].ToString());
                    employee.Department = dr["Department"].ToString();
                    employee.JobRole = dr["JobRole"].ToString();
                    employee.JobLevel = Convert.ToInt32(dr["JobLevel"].ToString());

                    emplist.Add(employee);
                }
                con.Close();
            }
            return emplist;
        }

        public AllDisplay ReturnAll(int? Id)
        {
            var item = new AllDisplay();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee, EmpDetails, EmployeeEdu, JobInformation, Surveys, EmployeePerform, EmployeeHist, CostCompany WHERE JobInformation.JobID = @id and Surveys.SurveyID = @id and EmployeePerform.PerformanceID = @id and EmployeeHist.HistoryID = @id and EmployeeEdu.EducationID = @id and EmpDetails.DetailD = @id and CostCompany.CostID = @id"
                    , con);

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    item.DetailD = Convert.ToInt32(dr["DetailD"].ToString());
                    item.Age = Convert.ToInt32(dr["Age"].ToString());
                    item.Attrition = (dr["Attrition"].ToString());
                    item.DistanceFromHome = Convert.ToInt32(dr["DistanceFromHome"].ToString());
                    item.Over18 = (dr["Over18"].ToString());
                    item.Gender = (dr["Gender"].ToString());
                    item.MaritalStatus = (dr["MaritalStatus"].ToString());
                    item.EducationID = Convert.ToInt32(dr["EducationID"].ToString());
                    item.Education = Convert.ToInt32(dr["Education"].ToString());
                    item.EducationField = (dr["EducationField"].ToString());
                    item.JobID = Convert.ToInt32(dr["JobID"].ToString());
                    item.JobRole = (dr["JobRole"].ToString());
                    item.Department = (dr["Department"].ToString());
                    item.JobLevel = Convert.ToInt32(dr["JobLevel"].ToString());
                    item.StandardHours = Convert.ToInt32(dr["StandardHours"].ToString());
                    item.EmployeeCount = Convert.ToInt32(dr["EmployeeCount"].ToString());
                    item.BusinessTravel = (dr["BusinessTravel"].ToString());
                    item.StockOptionLevel = Convert.ToInt32(dr["StockOptionLevel"].ToString());
                    item.SurveyID = Convert.ToInt32(dr["SurveyID"].ToString());
                    item.EnvironmentSatisfaction = Convert.ToInt32(dr["EnvironmentSatisfaction"].ToString());
                    item.JobSatsifaction = Convert.ToInt32(dr["JobSatisfaction"].ToString());
                    item.RelationshipSatisfaction = Convert.ToInt32(dr["RelationshipSatisfaction"].ToString());
                    item.PerformanceID = Convert.ToInt32(dr["PerformanceID"].ToString());
                    item.JobInvolvement = Convert.ToInt32(dr["JobInvolvement"].ToString());
                    item.PerformanceRating = Convert.ToInt32(dr["PerformanceRating"].ToString());
                    item.WorkLifeBalance = Convert.ToInt32(dr["WorkLifeBalance"].ToString());
                    item.HistoryID = Convert.ToInt32(dr["HistoryID"].ToString());
                    item.NumCompaniesWorked = Convert.ToInt32(dr["NumCompaniesWorked"].ToString());
                    item.TotalWorkingYears = Convert.ToInt32(dr["TotalWorkingYears"].ToString());
                    item.TrainingTimesLastYear = Convert.ToInt32(dr["TrainingTimesLastYear"].ToString());
                    item.YearsAtCompany = Convert.ToInt32(dr["YearsAtCompany"].ToString());
                    item.YearsInCurrentRole = Convert.ToInt32(dr["YearsInCurrentRole"].ToString());
                    item.YearsSinceLastPromotion = Convert.ToInt32(dr["YearsSinceLastPromotion"].ToString());
                    item.YearsWithCurrManager = Convert.ToInt32(dr["YearsWithCurrManager"].ToString());
                    item.CostID = Convert.ToInt32(dr["CostID"].ToString());
                    item.HourlyRate = Convert.ToInt32(dr["HourlyRate"].ToString());
                    item.DailyRate = Convert.ToInt32(dr["DailyRate"].ToString());
                    item.MonthlyRate = Convert.ToInt32(dr["MonthlyRate"].ToString());
                    item.MonthlyIncome = Convert.ToInt32(dr["MonthlyIncome"].ToString());
                    item.OverTime = (dr["OverTime"].ToString());
                    item.PercentSalaryHike = Convert.ToInt32(dr["PercentSalaryHike"].ToString());


                }
                con.Close();
            }
            return item;
        }

        public void UpdateAll(AllDisplay allDisplay, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE EmpDetails SET Age = @Age, Attrition = @Attrition, DistanceFromHome = @DistanceFromHome, Over18 = @Over18, Gender = @Gender, MaritalStatus = @MaritalStatus WHERE DetailD = @Id"
                    , con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Age", allDisplay.Age);
                    cmd.Parameters.AddWithValue("@Attrition", allDisplay.Attrition);
                    cmd.Parameters.AddWithValue("@DistanceFromHome", allDisplay.DistanceFromHome);
                    cmd.Parameters.AddWithValue("@Over18", allDisplay.Over18);
                    cmd.Parameters.AddWithValue("@Gender", allDisplay.Gender);
                    cmd.Parameters.AddWithValue("@MaritalStatus", allDisplay.MaritalStatus);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE EmployeeEdu SET Education = @Education, EducationField = @EducationField WHERE EducationID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Education", allDisplay.Education);
                    cmd.Parameters.AddWithValue("@EducationField", allDisplay.EducationField);

                    cmd.ExecuteNonQuery();

                }

                using (SqlCommand cmd = new SqlCommand("UPDATE JobInformation SET JobRole = @JobRole, Department = @Department, JobLevel = @JobLevel, StandardHours = @StandardHours, EmployeeCount = @EmployeeCount, BusinessTravel = @BusinessTravel, StockOptionLevel = @StockOptionLevel WHERE JobID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@JobRole", allDisplay.JobRole);
                    cmd.Parameters.AddWithValue("@Department", allDisplay.Department);
                    cmd.Parameters.AddWithValue("@JobLevel", allDisplay.JobLevel);
                    cmd.Parameters.AddWithValue("@StandardHours", allDisplay.StandardHours);
                    cmd.Parameters.AddWithValue("@EmployeeCount", allDisplay.EmployeeCount);
                    cmd.Parameters.AddWithValue("@BusinessTravel", allDisplay.BusinessTravel);
                    cmd.Parameters.AddWithValue("@StockOptionLevel", allDisplay.StockOptionLevel);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE Surveys SET EnvironmentSatisfaction = @EnvironmentSatisfaction, JobSatisfaction = @JobSatisfaction, RelationshipSatisfaction = @RelationshipSatisfaction WHERE SurveyID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@EnvironmentSatisfaction", allDisplay.EnvironmentSatisfaction);
                    cmd.Parameters.AddWithValue("@JobSatisfaction", allDisplay.JobSatsifaction);
                    cmd.Parameters.AddWithValue("@RelationshipSatisfaction", allDisplay.RelationshipSatisfaction);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE EmployeePerform SET JobInvolvement = @JobInvolvement, PerformanceRating = @PerformanceRating, WorkLifeBalance = @WorkLifeBalance WHERE PerformanceID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@JobInvolvement", allDisplay.JobInvolvement);
                    cmd.Parameters.AddWithValue("@PerformanceRating", allDisplay.PerformanceRating);
                    cmd.Parameters.AddWithValue("@WorkLifeBalance", allDisplay.WorkLifeBalance);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE EmployeeHist SET NumCompaniesWorked = @NumCompaniesWorked, TotalWorkingYears = @TotalWorkingYears, TrainingTimesLastYear = @TrainingTimesLastYear, YearsAtCompany = @YearsAtCompany, YearsInCurrentRole = @YearsInCurrentRole, YearsSinceLastPromotion = @YearsSinceLastPromotion, YearsWithCurrManager = @YearsWithCurrManager WHERE HistoryID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@NumCompaniesWorked", allDisplay.NumCompaniesWorked);
                    cmd.Parameters.AddWithValue("@TotalWorkingYears", allDisplay.TotalWorkingYears);
                    cmd.Parameters.AddWithValue("@TrainingTimesLastYear", allDisplay.TrainingTimesLastYear);
                    cmd.Parameters.AddWithValue("@YearsAtCompany", allDisplay.YearsAtCompany);
                    cmd.Parameters.AddWithValue("@YearsInCurrentRole", allDisplay.YearsInCurrentRole);
                    cmd.Parameters.AddWithValue("@YearsSinceLastPromotion", allDisplay.YearsSinceLastPromotion);
                    cmd.Parameters.AddWithValue("@YearsWithCurrManager", allDisplay.YearsWithCurrManager);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE CostCompany SET HourlyRate = @HourlyRate, DailyRate = @DailyRate, MonthlyRate = @MonthlyRate, MonthlyIncome = @MonthlyIncome, OverTime = @OverTime, PercentSalaryHike = @PercentSalaryHike WHERE CostID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@HourlyRate", allDisplay.HourlyRate);
                    cmd.Parameters.AddWithValue("@DailyRate", allDisplay.DailyRate);
                    cmd.Parameters.AddWithValue("@MonthlyRate", allDisplay.MonthlyRate);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", allDisplay.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@OverTime", allDisplay.OverTime);
                    cmd.Parameters.AddWithValue("@PercentSalaryHike", allDisplay.PercentSalaryHike);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public void Insert(AllDisplay allDisplay)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmpDetails (Age , Attrition , DistanceFromHome , Over18 , Gender, MaritalStatus) VALUES(@Age, @Attrition, @DistanceFromHome, @Over18, @Gender, @MaritalStatus)"
                    , con))
                {
                    cmd.Parameters.AddWithValue("@Age", allDisplay.Age);
                    cmd.Parameters.AddWithValue("@Attrition", allDisplay.Attrition);
                    cmd.Parameters.AddWithValue("@DistanceFromHome", allDisplay.DistanceFromHome);
                    cmd.Parameters.AddWithValue("@Over18", allDisplay.Over18);
                    cmd.Parameters.AddWithValue("@Gender", allDisplay.Gender);
                    cmd.Parameters.AddWithValue("@MaritalStatus", allDisplay.MaritalStatus);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeEdu (Education, EducationField) VALUES (@Education, @EducationField)", con))
                {
                    cmd.Parameters.AddWithValue("@Education", allDisplay.Education);
                    cmd.Parameters.AddWithValue("@EducationField", allDisplay.EducationField);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO JobInformation (JobRole, Department, JobLevel, StandardHours, EmployeeCount, BusinessTravel, StockOptionLevel) VALUES(@JobRole, @Department, @JobLevel, @StandardHours, @EmployeeCount, @BusinessTravel, @StockOptionLevel)", con))
                {
                    cmd.Parameters.AddWithValue("@JobRole", allDisplay.JobRole);
                    cmd.Parameters.AddWithValue("@Department", allDisplay.Department);
                    cmd.Parameters.AddWithValue("@JobLevel", allDisplay.JobLevel);
                    cmd.Parameters.AddWithValue("@StandardHours", allDisplay.StandardHours);
                    cmd.Parameters.AddWithValue("@EmployeeCount", allDisplay.EmployeeCount);
                    cmd.Parameters.AddWithValue("@BusinessTravel", allDisplay.BusinessTravel);
                    cmd.Parameters.AddWithValue("@StockOptionLevel", allDisplay.StockOptionLevel);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Surveys (EnvironmentSatisfaction, JobSatisfaction, RelationshipSatisfaction) VALUES(@EnvironmentSatisfaction, @JobSatisfaction, @RelationshipSatisfaction)", con))
                {
                    cmd.Parameters.AddWithValue("@EnvironmentSatisfaction", allDisplay.EnvironmentSatisfaction);
                    cmd.Parameters.AddWithValue("@JobSatisfaction", allDisplay.JobSatsifaction);
                    cmd.Parameters.AddWithValue("@RelationshipSatisfaction", allDisplay.RelationshipSatisfaction);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeePerform (JobInvolvement, PerformanceRating, WorkLifeBalance) VALUES(@JobInvolvement, @PerformanceRating, @WorkLifeBalance)", con))
                {
                    cmd.Parameters.AddWithValue("@JobInvolvement", allDisplay.JobInvolvement);
                    cmd.Parameters.AddWithValue("@PerformanceRating", allDisplay.PerformanceRating);
                    cmd.Parameters.AddWithValue("@WorkLifeBalance", allDisplay.WorkLifeBalance);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeHist (NumCompaniesWorked , TotalWorkingYears, TrainingTimesLastYear , YearsAtCompany, YearsInCurrentRole, YearsSinceLastPromotion, YearsWithCurrManager) VALUES(@NumCompaniesWorked, @TotalWorkingYears, @TrainingTimesLastYear, @YearsAtCompany, @YearsInCurrentRole, @YearsSinceLastPromotion, @YearsWithCurrManager)", con))
                {
                    cmd.Parameters.AddWithValue("@NumCompaniesWorked", allDisplay.NumCompaniesWorked);
                    cmd.Parameters.AddWithValue("@TotalWorkingYears", allDisplay.TotalWorkingYears);
                    cmd.Parameters.AddWithValue("@TrainingTimesLastYear", allDisplay.TrainingTimesLastYear);
                    cmd.Parameters.AddWithValue("@YearsAtCompany", allDisplay.YearsAtCompany);
                    cmd.Parameters.AddWithValue("@YearsInCurrentRole", allDisplay.YearsInCurrentRole);
                    cmd.Parameters.AddWithValue("@YearsSinceLastPromotion", allDisplay.YearsSinceLastPromotion);
                    cmd.Parameters.AddWithValue("@YearsWithCurrManager", allDisplay.YearsWithCurrManager);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO CostCompany (HourlyRate, DailyRate, MonthlyRate, MonthlyIncome, OverTime, PercentSalaryHike) VALUES(@HourlyRate, @DailyRate, @MonthlyRate, @MonthlyIncome, @OverTime, @PercentSalaryHike)", con))
                {
                    cmd.Parameters.AddWithValue("@HourlyRate", allDisplay.HourlyRate);
                    cmd.Parameters.AddWithValue("@DailyRate", allDisplay.DailyRate);
                    cmd.Parameters.AddWithValue("@MonthlyRate", allDisplay.MonthlyRate);
                    cmd.Parameters.AddWithValue("@MonthlyIncome", allDisplay.MonthlyIncome);
                    cmd.Parameters.AddWithValue("@OverTime", allDisplay.OverTime);
                    cmd.Parameters.AddWithValue("@PercentSalaryHike", allDisplay.PercentSalaryHike);

                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT MAX(JobID) from JobInformation", con))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    using (SqlCommand cmdd = new SqlCommand("INSERT INTO Employee (JobID, DetailsID, CostID, EducationID, SurveyID, HistoryID, PerformanceID) VALUES('" + count + "', '" + count + "', '" + count + "', '" + count + "', '" + count + "', '" + count + "', '" + count + "')", con))
                    {
                        cmdd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }

        }

        public void DeleteRecords(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employee where EmployeeNumber = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Surveys WHERE SurveyID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeePerform WHERE PerformanceID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeHist WHERE HistoryID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeEdu WHERE EducationID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmpDetails WHERE DetailD = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM CostCompany WHERE CostID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("DELETE FROM JobInformation WHERE JobID = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public Gender GetGender()
        {
            var val = new Gender();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Count(Gender) from EmpDetails WHERE Gender = 'Male'", con))
                {
                    val.Male = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("SELECT Count(Gender) from EmpDetails WHERE Gender = 'Female'", con))
                {
                    val.Female = Convert.ToInt32(cmd.ExecuteScalar());
                }

                con.Close();
            }
            return val;


        }

        public Age GetAge()
        {
            var val = new Age();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select count(Age) from EmpDetails where Age <=20 and Age>0", con))
                {
                    val.less20 = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("select count(Age) from EmpDetails where Age <=30 and Age>20", con))
                {
                    val.less30 = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("select count(Age) from EmpDetails where Age <=40 and Age>30", con))
                {
                    val.less40 = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("select count(Age) from EmpDetails where Age <=50 and Age>40", con))
                {
                    val.less50 = Convert.ToInt32(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("select count(Age) from EmpDetails where Age > 50", con))
                {
                    val.great50 = Convert.ToInt32(cmd.ExecuteScalar());
                }

                con.Close();
            }
            return val;
        }

        public Costs GetCosts()
        {
            var val = new Costs();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT SUM(MonthlyRate) FROM CostCompany", con))
                {
                    val.PerMonth = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("SELECT SUM(DailyRate) FROM CostCompany", con))
                {
                    val.PerDay = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                using (SqlCommand cmd = new SqlCommand("SELECT SUM(HourlyRate) FROM CostCompany", con))
                {
                    val.PerHour = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return val;
        }
    }
}
            



