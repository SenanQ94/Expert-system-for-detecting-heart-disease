using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AnalysisServices.AdomdClient;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void id3(object sender, EventArgs e)
    {
        //الاتصال بقاعدة البيانات
        AdomdConnection con = new AdomdConnection(

            "Data Source=SENAN\\SINANQ; Catalog=MyProject"
            );
        con.Open();
        AdomdCommand com = new AdomdCommand();
        com.Connection = con;

        string age = ageBox.Text;              //عمر الشخص المدخل
        int intAge = Convert.ToInt32(age);
        string bloodPressure = prBox.Text;              //ضغط الدم
        int intBloodPressure = Convert.ToInt32(bloodPressure);
        string heartRate = beatBox.Text;              //نبض القلب
        int intHeartRate = Convert.ToInt32(heartRate);

        //DMX statement
        string s = @"select disease from HeartMMM
                        natural prediction join
                        (select '" + intAge + @"' as [Age],
                         '" + DropDownList5.SelectedValue + @"' as [Chest Pain Type],
                         '" + intBloodPressure + @"' as [Rest Blood Pressure],
                         '" + DropDownList6.SelectedValue + @"' as [Blood Sugar],
                         '" + DropDownList7.SelectedValue + @"' as [Rest Electro],
                         '" + intHeartRate + @"' as [Max Heart Rate],
                         '" + DropDownList8.SelectedValue + @"' as [Exercice Angina]) as t";

        com.CommandText = s;
        Label2.Text = s;
        AdomdDataReader dr = com.ExecuteReader(); // execute DMX statement
        if (dr.Read())// read returned values from SQL Server
        {
            if (dr[0] != null)
                Label1.Text = dr[0].ToString();
            if (dr[0].ToString() == "negative")
            {

                Label9.Text = "غير مصاب بمرض القلب";
            }
            else if (dr[0].ToString() == "positive")
            {
                Label9.Text = "مصاب بمرض القلب";

            }
        }
        dr.Close();
        con.Close();
    }//end of button


    protected void bayes(object sender, EventArgs e)
    {
        //الاتصال بقاعدة البيانات
        AdomdConnection con = new AdomdConnection(
            "Data Source=SENAN\\SINANQ; Catalog=MyProject"
            );
        con.Open();
        AdomdCommand com = new AdomdCommand();
        com.Connection = con;


        string age = ageBox.Text;              //عمر الشخص المدخل
        int intAge = Convert.ToInt32(age);
        string bloodPressure = prBox.Text;              //ضغط الدم
        int intBloodPressure = Convert.ToInt32(bloodPressure);
        string heartRate = beatBox.Text;              //نبض القلب
        int intHeartRate = Convert.ToInt32(heartRate);

        // DMX statement
        string s = @"  select flattened
                    predicthistogram(Disease)
                     from HeartBBMM
                    natural prediction join
                    (select '" + intAge + @"' as [Age],
                         '" + DropDownList5.SelectedValue + @"' as [Chest Pain Type],
                         '" + intBloodPressure + @"' as [Rest Blood Pressure],
                         '" + DropDownList6.SelectedValue + @"' as [Blood Sugar],
                         '" + DropDownList7.SelectedValue + @"' as [Rest Electro],
                         '" + intHeartRate + @"' as [Max Heart Rate],
                         '" + DropDownList8.SelectedValue + @"' as [Exercice Angina]) as t";

        com.CommandText = s;
        AdomdDataReader dr = com.ExecuteReader(); // execute DMX statement
        Label3.Text = "";
        Label4.Text = s;
        while (dr.Read()) // read returned values from sql server
        {
            if (dr[0] != null)
            {
                double x1 = Convert.ToDouble(dr[2]) * 100;
                Label3.Text += dr[0].ToString() + ":  " + x1.ToString() + " % ";
                Label3.Text += "</br>";
                if (dr[0].ToString() == "negative")
                {
                    Label8.Text = "مصاب بمرض القلب";

                }
                else if (dr[0].ToString() == "positive")
                {
                    Label8.Text = "غير مصاب بمرض القلب";
                }
                
            }
         
        }
        dr.Close();
        con.Close();
    }//end of button


    protected void my_bayes(object sender, EventArgs e)
    {


        SqlConnection sqlcon = new SqlConnection("Data Source=SQL5005.site4now.net;Initial Catalog=DB_A62560_sinanq;User Id=DB_A62560_sinanq_admin;Password=Nancy@115533");
        sqlcon.Open();

        //========المتوسط الحسابي للعمر========

        // في الحالات المريضة
        string sqlPAgeAVG = "SELECT AVG(age) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='positive'";
        SqlCommand cmd1 = new SqlCommand(sqlPAgeAVG, sqlcon);
        double PAgeAvg = Convert.ToDouble(cmd1.ExecuteScalar().ToString());


        //في الحالات السليمة
        string sqlNAgeAVG = "SELECT AVG(age) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='negative'";
        SqlCommand cmd2 = new SqlCommand(sqlNAgeAVG, sqlcon);
        double NAgeAvg = Convert.ToDouble(cmd2.ExecuteScalar().ToString());

        //========الانحراف المعياري للعمر========

        // في الحالات المريضة
        string sqlPAgeSTDEV = "SELECT STDEV(age) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='positive'";
        SqlCommand cmd3 = new SqlCommand(sqlPAgeSTDEV, sqlcon);
        double PAgeSTDEV = Convert.ToDouble(cmd3.ExecuteScalar().ToString());


        //في الحالات السليمة
        string sqlNAgeSTDEV = "SELECT STDEV(age) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='negative'";
        SqlCommand cmd4 = new SqlCommand(sqlNAgeSTDEV, sqlcon);
        double NAgeSTDEV = Convert.ToDouble(cmd4.ExecuteScalar().ToString());

        // ========المتوسط الحسابي لضغط الدم الانبساطي========

        // في الحالات المريضة
        string sqlPPressureAVG = "SELECT AVG(rest_blood_pressure) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='positive'";
        SqlCommand cmd5 = new SqlCommand(sqlPPressureAVG, sqlcon);
        double PPressureAVG = Convert.ToDouble(cmd5.ExecuteScalar().ToString());

        //في الحالات السليمة
        string sqlNPressureAVG = "SELECT AVG(rest_blood_pressure) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='negative'";
        SqlCommand cmd6 = new SqlCommand(sqlNPressureAVG, sqlcon);
        double NPressureAVG = Convert.ToDouble(cmd6.ExecuteScalar().ToString());

        // ========الانحراف المعياري لضغط الدم الانبساطي ========

        // في الحالات المريضة
        string sqlPPressureSTDEV = "SELECT STDEV(rest_blood_pressure) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='positive'";
        SqlCommand cmd7 = new SqlCommand(sqlPPressureSTDEV, sqlcon);
        double PPressureSTDEV = Convert.ToDouble(cmd7.ExecuteScalar().ToString());

        //في الحالات السليمة
        string sqlNPressureSTDEV = "SELECT STDEV(rest_blood_pressure) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='negative'";
        SqlCommand cmd8 = new SqlCommand(sqlNPressureSTDEV, sqlcon);
        double NPressureSTDEV = Convert.ToDouble(cmd8.ExecuteScalar().ToString());

        //========المتوسط الحسابي لنبض القلب الأعظمي========

        // في الحالات المريضة
        string sqlPBeatAVG = "SELECT AVG(max_heart_rate) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='positive'";
        SqlCommand cmd9 = new SqlCommand(sqlPBeatAVG, sqlcon);
        double PBeatAVG = Convert.ToDouble(cmd9.ExecuteScalar().ToString());

        //في الحالات السليمة
        string sqlNBeatAVG = "SELECT AVG(max_heart_rate) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='negative'";
        SqlCommand cmd10 = new SqlCommand(sqlNBeatAVG, sqlcon);
        double NBeatAVG = Convert.ToDouble(cmd10.ExecuteScalar().ToString());

        //========الانحراف المعياري لنبض القلب الأعظمي========

        // في الحالات المريضة
        string sqlPBeatSTDEV = "SELECT STDEV(max_heart_rate) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='positive'";
        SqlCommand cmd11 = new SqlCommand(sqlPBeatSTDEV, sqlcon);
        double PBeatSTDEV = Convert.ToDouble(cmd11.ExecuteScalar().ToString());

        //في الحالات السليمة
        string sqlNBeatSTDEV = "SELECT STDEV(max_heart_rate) FROM [DB_A62560_sinanq].[dbo].[HeartTable] WHERE [disease] ='negative'";
        SqlCommand cmd12 = new SqlCommand(sqlNBeatSTDEV, sqlcon);
        double NBeatSTDEV = Convert.ToDouble(cmd12.ExecuteScalar().ToString());

        sqlcon.Close();


        string age = ageBox.Text;              //عمر الشخص المدخل
        int intAge = Convert.ToInt32(age);
        string bloodPressure = prBox.Text;              //ضغط الدم
        int intBloodPressure = Convert.ToInt32(bloodPressure);
        string heartRate = beatBox.Text;              //نبض القلب
        int intHeartRate = Convert.ToInt32(heartRate);


        string chestPain = DropDownList5.SelectedValue;  //نوع ألم الصدر
        string bloodSugar = DropDownList6.SelectedValue;  // سكر الدم
        string restElectro = DropDownList7.SelectedValue;  //تخطيط القلب
        string exerciceAngina = DropDownList8.SelectedValue; // ألم أثناء التمرين

        //العمر

        //حساب تابع الكثافة للعمر 
        double prAgePos = (1 / (Math.Sqrt(2 * Math.PI) * PAgeSTDEV)) * (Math.Pow(Math.E, -((Math.Pow((intAge - PAgeAvg), 2)) / (2 * PAgeSTDEV * PAgeSTDEV)))); //اذا كان الشحص مصاب
        double prAgeNeg = (1 / (Math.Sqrt(2 * Math.PI) * NAgeSTDEV)) * (Math.Pow(Math.E, -((Math.Pow((intAge - NAgeAvg), 2)) / (2 * NAgeSTDEV * NAgeSTDEV)))); // اذا كان الشخص غير مصاب
        //Label7.Text = prAgePos.ToString();

        //ألم الصدر
        double prChestPos = 0.0, prChestNeg = 0.0;    //احتمال أن يكون مصاباً أو غير مصاب حسب نوع ألم الصدر

        if (chestPain == ("asympt"))   //كل احتمال تم حسابه من الداتاسيت
        {
            prChestPos = 75.0 / 92.0; prChestNeg = 27.0 / 117.0;
        }
        else if (chestPain == ("atyp_angina"))
        {
            prChestPos = 6.0 / 92.0; prChestNeg = 59.0 / 117.0;
        }
        else if (chestPain == ("non_anginal"))
        {
            prChestPos = 7.0 / 92.0; prChestNeg = 29.0 / 117.0;
        }
        else if (chestPain == ("typ_angina"))
        {
            prChestPos = 4.0 / 92.0; prChestNeg = 2.0 / 117.0;

        }


        //الضغط

        //حساب تابع الكثافة للضغط
        double prPressurePos = (1 / (Math.Sqrt(2 * Math.PI) * PPressureSTDEV)) * (Math.Pow(Math.E, -((Math.Pow((intBloodPressure - PPressureAVG), 2)) / (2 * PPressureSTDEV * PPressureSTDEV)))); //اذا كان الشحص مصاب
        double prPressureNeg = (1 / (Math.Sqrt(2 * Math.PI) * NPressureSTDEV)) * (Math.Pow(Math.E, -((Math.Pow((intBloodPressure - NPressureAVG), 2)) / (2 * NPressureSTDEV * NPressureSTDEV)))); // اذا كان الشخص غير مصاب


        //سكر الدم
        double prSugarPos = 0.0, prSugarNeg = 0.0;    //احتمال أن يكون مصاباً أو غير مصاب حسب سكر الدم
        if (bloodSugar == "True")     //كل احتمال تم حسابه من الداتاسيت
        {
            prSugarPos = 11.0 / 92.0; prSugarNeg = 5.0 / 117.0;
        }
        else if (bloodSugar == "False")
        {
            prSugarPos = 81.0 / 92.0; prSugarNeg = 112.0 / 117.0;
        }


        //تخطيط القلب
        double prHeartDrawPos = 0.0, prHeartDrawNeg = 0.0;    //احتمال أن يكون مصاباً أو غير مصاب حسب تخطيط القلب
        if (restElectro == "normal")   //كل احتمال تم حسابه من الداتاسيت
        {
            prHeartDrawPos = 74.0 / 92.0; prHeartDrawNeg = 100.0 / 117.0;
        }
        else if (restElectro == "left_vent_hyper")
        {
            prHeartDrawPos = 1.0 / 92.0; prHeartDrawNeg = 4.0 / 117.0;
        }
        else if (restElectro == "st_t_wave_abnormality")
        {
            prHeartDrawPos = 17.0 / 92.0; prHeartDrawNeg = 13.0 / 117.0;
        }

        //دقات القلب العظمى

        //حساب تابع الكثافة لدقات القلب العظمى
        double prHeartBeatsPos = (1 / (Math.Sqrt(2 * Math.PI) * PBeatSTDEV)) * (Math.Pow(Math.E, -((Math.Pow((intHeartRate - PBeatAVG), 2)) / (2 * PBeatSTDEV * PBeatSTDEV)))); //اذا كان الشحص مصاب
        double prHeartBeatsNeg = (1 / (Math.Sqrt(2 * Math.PI) * NBeatSTDEV)) * (Math.Pow(Math.E, -((Math.Pow((intHeartRate - NBeatAVG), 2)) / (2 * NBeatSTDEV * NBeatSTDEV)))); // اذا كان الشخص غير مصاب



        //الألم عند التمرين
        double prExHurtPos = 0.0, prExHurtNeg = 0.0;    //احتمال أن يكون مصاباً أو غير مصاب حسب الألم عند التمرين
        if (exerciceAngina == "yes")    //كل احتمال تم حسابه من الداتاسيت
        {
            prExHurtPos = 60.0 / 92.0; prExHurtNeg = 12.0 / 117.0;
        }
        else if (exerciceAngina == "no")
        {
            prExHurtPos = 32.0 / 92.0; prExHurtNeg = 105.0 / 117.0;
        }

        //النتائج

        double pos = prAgePos * prChestPos * prPressurePos * prSugarPos * prHeartDrawPos * prHeartBeatsPos * prExHurtPos * (92.0 / 209.0); //احتمال أن يكون مصاب  
        double neg = prAgeNeg * prChestNeg * prPressureNeg * prSugarNeg * prHeartDrawNeg * prHeartBeatsNeg * prExHurtNeg * (117.0 / 209.0);//احتمال أن يكون غير مصاب  
        double ppos = (pos / (pos + neg)) * 100; // normalization
        double pneg = (neg / (pos + neg)) * 100; // normalization        


        if (ppos >= pneg)
        {
            Label6.Text = "positive: " + ppos.ToString() + "%";
            Label7.Text = "negative: " + pneg.ToString() + "%";

            Label5.Text = "مصاب بمرض القلب";
        }
        else if (ppos < pneg)
        {
            Label7.Text = "positive: " + ppos.ToString() + "%";
            Label6.Text = "negative: " + pneg.ToString() + "%";
            Label5.Text = "غير مصاب بمرض القلب";
        }

    } //end of button


    protected void my_id3(object sender, EventArgs e)
    {
        //تنفيذ كود الجافا
        Process p = new Process();
        p.StartInfo.FileName = "D:\\Id3.jar";
        p.Start();
        p.WaitForExit();

        // التحقق من المدخلات حسب الشجرة الناتجة من الكود السابق
        string age = ageBox.Text;              //عمر الشخص المدخل
        int intAge = Convert.ToInt32(age);
        string bloodPressure = prBox.Text;              //ضغط الدم
        int intBloodPressure = Convert.ToInt32(bloodPressure);
        string heartRate = beatBox.Text;              //نبض القلب
        int intHeartRate = Convert.ToInt32(heartRate);
        string chestPain = DropDownList5.SelectedValue;  //نوع ألم الصدر
        string bloodSugar = DropDownList6.SelectedValue;  // سكر الدم
        string restElectro = DropDownList7.SelectedValue;  //تخطيط القلب
        string exerciceAngina = DropDownList8.SelectedValue; // ألم أثناء التمرين

        if (chestPain == "asympt")
        {
            if (exerciceAngina == "yes")
            {
                if (restElectro == "normal")
                {
                    Label10.Text = "غير مصاب بمرض القلب";
                }
                else if (restElectro == "left_vent_hyper")
                {
                    Label10.Text = "غير مصاب بمرض القلب";
                }
                else if (restElectro == "st_t_wave_abnormality")
                {
                    Label10.Text = "مصاب بمرض القلب";
                }
            }
            else if (exerciceAngina == "no")
            {
                Label10.Text = "غير مصاب بمرض القلب";
            }

        }
        else if (chestPain == "non_anginal")
        {
            if (intAge >= 48)
            {
                Label10.Text = "مصاب بمرض القلب";
            }
            else if (intAge < 48)
            {
                Label10.Text = "غير مصاب بمرض القلب";
            }
        }

        else if (chestPain == "atyp_angina")
        {
            if (intHeartRate >= 138)
            {
                Label10.Text = "غير مصاب بمرض القلب";
            }
            else if (intAge < 138)
            {
                Label10.Text = "مصاب بمرض القلب";
            }
        }
        else if (chestPain == "typ_angina")
        {
            if (bloodSugar == "False")
            {
                Label10.Text = "غير مصاب بمرض القلب";
            }
            else if (bloodSugar == "True")
            {
                Label10.Text = "مصاب بمرض القلب";
            }
        }


    }
}