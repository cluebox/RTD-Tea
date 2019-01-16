using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpssLib.SpssDataset;
using SpssLib.DataReader;
using System.IO;

namespace RtdTeaParsing
{
    class RTDTea
    {
        static void Main(string[] args)
        {
            int SurveyID = 600512;
            //string SurveyPeriod = "2014-09-30";//survey period
            string SurveyPeriod = "2018-08-31";
            string country = "INDONESIA";//survey country
            DB_insertion_RTDTea iobj = new DB_insertion_RTDTea();
            string questions = "iobs,weightx,gender,j1,b1c,b2c,u1e,age,ses,s13,Period,b1a,city,b1b_3,b1b_1,b1b_4,b1b_5,b1b_6,b1b_7,b1b_8,b1b_16,b1b_17,b1b_18,b1b_2,b4a_3,b4a_1,b4a_4,b4a_5,b4a_6,b4a_7,b4a_8,b4a_16,b4a_17,b4a_18,b4a_2,b3h,b3j_3,b3j_1,b3j_4,b3j_5,b3j_6,b3j_7,b3j_8,b3j_16,b3j_17,b3j_18,b3j_2,b4b_3,b4b_1,b4b_4,b4b_5,b4b_6,b4b_7,b4b_8,b4b_16,b4b_17,b4b_18,b4b_2,b2a,b2b_3,b2b_1,b2b_4,b2b_5,b2b_6,b2b_7,b2b_8,b2b_16,b2b_17,b2b_18,b2b_2,u1a_3,u1a_1,u1a_4,u1a_5,u1a_6,u1a_7,u1a_8,u1a_16,u1a_17,u1a_18,u1a_2,u1b_3,u1b_1,u1b_4,u1b_5,u1b_6,u1b_7,u1b_8,u1b_16,u1b_17,u1b_18,u1b_2,u1c_3,u1c_1,u1c_4,u1c_5,u1c_6,u1c_7,u1c_8,u1c_16,u1c_17,u1c_18,u1c_2,u1d_3,u1d_1,u1d_4,u1d_5,u1d_6,u1d_7,u1d_8,u1d_16,u1d_17,u1d_18,u1d_2,u1h_3,u1h_1,u1h_4,u1h_5,u1h_6,u1h_7,u1h_8,u1h_16,u1h_17,u1h_18,u1h_2,u1g,s6a_3,s6a_1,s6a_4,s6a_5,s6a_6,s6a_7,s6a_8,s6a_16,s6a_17,s6a_18,s6a_2,s6b_3,s6b_1,s6b_4,s6b_5,s6b_6,s6b_7,s6b_8,s6b_16,s6b_17,s6b_18,s6b_2,s6c_3,s6c_1,s6c_4,s6c_5,s6c_6,s6c_7,s6c_8,s6c_16,s6c_17,s6c_18,s6c_2,s12_1,s12_2,s12_3,s12_4,s12_5,s12_9,C2x1_2,C2x1_19,C2x1_6,C2x1_1,C2x1_11,C2x2_2,C2x2_19,C2x2_6,C2x2_1,C2x2_11,C2x3_2,C2x3_19,C2x3_6,C2x3_1,C2x3_11,C2x4_2,C2x4_19,C2x4_6,C2x4_1,C2x4_11,C2x5_2,C2x5_19,C2x5_6,C2x5_1,C2x5_11,C2x6_2,C2x6_19,C2x6_6,C2x6_1,C2x6_11,c2x1_27,c2x2_27,c2x3_27,c2x4_27,c2x5_27,c2x6_27";// dashboard variable value
            //questions = "u1h_1,u1h_2,u1h_3,u1h_4,u1h_5,u1h_6,u1h_7,u1h_8,u1h_9,u1h_10,u1h_11,u1h_12,u1h_13,u1h_14,u1h_15,u1h_16,u1h_17,u1h_18,u1h_19,u1h_20,u1h_21";
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"D:\Mysql_to_Xl\RTD\Aug2018-RTD-TEA.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {
                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                                //iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SurveyID, country, BASE_VARIABLE_NAME, SurveyPeriod);
                            }
                        }
                    }
                }
                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string variable_name;
                    string UserEmail = "-- Not Available --";
                    string FirstName = "-- Not Available --";
                    string LastName = "-- Not Available --";
                    string UserStatus = "-- Not Available --";
                    string gender = "-- Not Available --";
                    string maritalStatus = "-- Not Available --";
                    string Education = "-- Not Available --";
                    string Race = "-- Not Available --";
                    string Religion = "-- Not Available --";
                    string PostCode = "-- Not Available --";
                    string Country = "-- Not Available --";
                    string city = "-- Not Available --";
                    string SubDistrict = "-- Not Available --";
                    string Village = "-- Not Available --";
                    string IncomeRange = "-- Not Available --";
                    string IndustryName = "-- Not Available --";
                    string Occupation = "-- Not Available --";
                    string AttendedOn = "-- Not Available --";
                    decimal weightage = 0;
                    string Fav_Br_RTD = "-- Not Available --";
                    string Fav_br_RTD_PET = "-- Not Available --";
                    string Bumo = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string Ses = "-- Not Available --";
                    string Period = "-- Not Available --";
                    string BrTom = "-- Not Available --";
                    string BrSpont_TPH = "-- Not Available --";
                    string BrSpont_Teh_Botol = "-- Not Available --";
                    string BrSpont_TPH_less_sugar = "-- Not Available --";
                    string BrSpont_NU_Green = "-- Not Available --";
                    string BrSpont_Teh_Kotak = "-- Not Available --";
                    string BrSpont_Fruit_Tea = "-- Not Available --";
                    string BrSpont_Mirai_Ocha = "-- Not Available --";
                    string BrSpont_Ichi_Ocha = "-- Not Available --";
                    string BrSpont_Teh_Gelas = "-- Not Available --";
                    string BrSpont_Teh_Javana = "-- Not Available --";
                    string BrSpont_Frestea = "-- Not Available --";
                    string BrAided_TPH = "-- Not Available --";
                    string BrAided_Teh_Botol = "-- Not Available --";
                    string BrAided_TPH_less_sugar = "-- Not Available --";
                    string BrAided_NU_Green = "-- Not Available --";
                    string BrAided_Teh_Kotak = "-- Not Available --";
                    string BrAided_Fruit_Tea = "-- Not Available --";
                    string BrAided_Mirai_Ocha = "-- Not Available --";
                    string BrAided_Ichi_Ocha = "-- Not Available --";
                    string BrAided_Teh_Gelas = "-- Not Available --";
                    string BrAided_Teh_Javana = "-- Not Available --";
                    string BrAided_Frestea = "-- Not Available --";
                    string AdTom = "-- Not Available --";
                    string AdSpont_TPH = "-- Not Available --";
                    string AdSpont_Teh_Botol = "-- Not Available --";
                    string AdSpont_TPH_less_sugar = "-- Not Available --";
                    string AdSpont_NU_Green = "-- Not Available --";
                    string AdSpont_Teh_Kotak = "-- Not Available --";
                    string AdSpont_Fruit_Tea = "-- Not Available --";
                    string AdSpont_Mirai_Ocha = "-- Not Available --";
                    string AdSpont_Ichi_Ocha = "-- Not Available --";
                    string AdSpont_Teh_Gelas = "-- Not Available --";
                    string AdSpont_Teh_Javana = "-- Not Available --";
                    string AdSpont_Frestea = "-- Not Available --";
                    string AdAided_TPH = "-- Not Available --";
                    string AdAided_Teh_Botol = "-- Not Available --";
                    string AdAided_TPH_less_sugar = "-- Not Available --";
                    string AdAided_NU_Green = "-- Not Available --";
                    string AdAided_Teh_Kotak = "-- Not Available --";
                    string AdAided_Fruit_Tea = "-- Not Available --";
                    string AdAided_Mirai_Ocha = "-- Not Available --";
                    string AdAided_Ichi_Ocha = "-- Not Available --";
                    string AdAided_Teh_Gelas = "-- Not Available --";
                    string AdAided_Teh_Javana = "-- Not Available --";
                    string AdAided_Frestea = "-- Not Available --";
                    string TomRTDpet = "-- Not Available --";
                    string SpontRTDPet_TPH = "-- Not Available --";
                    string SpontRTDPet_Teh_Botol = "-- Not Available --";
                    string SpontRTDPet_TPH_less_sugar = "-- Not Available --";
                    string SpontRTDPet_NU_Green = "-- Not Available --";
                    string SpontRTDPet_Teh_Kotak = "-- Not Available --";
                    string SpontRTDPet_Fruit_Tea = "-- Not Available --";
                    string SpontRTDPet_Mirai_Ocha = "-- Not Available --";
                    string SpontRTDPet_Ichi_Ocha = "-- Not Available --";
                    string SpontRTDPet_Teh_Gelas = "-- Not Available --";
                    string SpontRTDPet_Teh_Javana = "-- Not Available --";
                    string SpontRTDPet_Frestea = "-- Not Available --";
                    string Ever_tried_TPH = "-- Not Available --";
                    string Ever_tried_Teh_Botol = "-- Not Available --";
                    string Ever_tried_TPH_less_sugar = "-- Not Available --";
                    string Ever_tried_NU_Green = "-- Not Available --";
                    string Ever_tried_Teh_Kotak = "-- Not Available --";
                    string Ever_tried_Fruit_Tea = "-- Not Available --";
                    string Ever_tried_Mirai_Ocha = "-- Not Available --";
                    string Ever_tried_Ichi_Ocha = "-- Not Available --";
                    string Ever_tried_Teh_Gelas = "-- Not Available --";
                    string Ever_tried_Teh_Javana = "-- Not Available --";
                    string Ever_tried_Frestea = "-- Not Available --";
                    string Cons_L3M_TPH = "-- Not Available --";
                    string Cons_L3M_Teh_Botol = "-- Not Available --";
                    string Cons_L3M_TPH_less_sugar = "-- Not Available --";
                    string Cons_L3M_NU_Green = "-- Not Available --";
                    string Cons_L3M_Teh_Kotak = "-- Not Available --";
                    string Cons_L3M_Fruit_Tea = "-- Not Available --";
                    string Cons_L3M_Mirai_Ocha = "-- Not Available --";
                    string Cons_L3M_Ichi_Ocha = "-- Not Available --";
                    string Cons_L3M_Teh_Gelas = "-- Not Available --";
                    string Cons_L3M_Teh_Javana = "-- Not Available --";
                    string Cons_L3M_Frestea = "-- Not Available --";
                    string Cons_1M_TPH = "-- Not Available --";
                    string Cons_1M_Teh_Botol = "-- Not Available --";
                    string Cons_1M_TPH_less_sugar = "-- Not Available --";
                    string Cons_1M_NU_Green = "-- Not Available --";
                    string Cons_1M_Teh_Kotak = "-- Not Available --";
                    string Cons_1M_Fruit_Tea = "-- Not Available --";
                    string Cons_1M_Mirai_Ocha = "-- Not Available --";
                    string Cons_1M_Ichi_Ocha = "-- Not Available --";
                    string Cons_1M_Teh_Gelas = "-- Not Available --";
                    string Cons_1M_Teh_Javana = "-- Not Available --";
                    string Cons_1M_Frestea = "-- Not Available --";
                    string Cons_1W_TPH = "-- Not Available --";
                    string Cons_1W_Teh_Botol = "-- Not Available --";
                    string Cons_1W_TPH_less_sugar = "-- Not Available --";
                    string Cons_1W_NU_Green = "-- Not Available --";
                    string Cons_1W_Teh_Kotak = "-- Not Available --";
                    string Cons_1W_Fruit_Tea = "-- Not Available --";
                    string Cons_1W_Mirai_Ocha = "-- Not Available --";
                    string Cons_1W_Ichi_Ocha = "-- Not Available --";
                    string Cons_1W_Teh_Gelas = "-- Not Available --";
                    string Cons_1W_Teh_Javana = "-- Not Available --";
                    string Cons_1W_Frestea = "-- Not Available --";
                    string Current_Cons_TPH = "-- Not Available --";
                    string Current_Cons_Teh_Botol = "-- Not Available --";
                    string Current_Cons_TPH_less_sugar = "-- Not Available --";
                    string Current_Cons_NU_Green = "-- Not Available --";
                    string Current_Cons_Teh_Kotak = "-- Not Available --";
                    string Current_Cons_Fruit_Tea = "-- Not Available --";
                    string Current_Cons_Mirai_Ocha = "-- Not Available --";
                    string Current_Cons_Ichi_Ocha = "-- Not Available --";
                    string Current_Cons_Teh_Gelas = "-- Not Available --";
                    string Current_Cons_Teh_Javana = "-- Not Available --";
                    string Current_Cons_Frestea = "-- Not Available --";
                    string Pre_Bumo = "-- Not Available --";
                   
                    string BrCons_L3M_TPH = "-- Not Available --";
                    string BrCons_L3M_Teh_Botol = "-- Not Available --";
                    string BrCons_L3M_TPH_less_sugar = "-- Not Available --";
                    string BrCons_L3M_NU_Green = "-- Not Available --";
                    string BrCons_L3M_Teh_Kotak = "-- Not Available --";
                    string BrCons_L3M_Fruit_Tea = "-- Not Available --";
                    string BrCons_L3M_Mirai_Ocha = "-- Not Available --";
                    string BrCons_L3M_Ichi_Ocha = "-- Not Available --";
                    string BrCons_L3M_Teh_Gelas = "-- Not Available --";
                    string BrCons_L3M_Teh_Javana = "-- Not Available --";
                    string BrCons_L3M_Frestea = "-- Not Available --";
                    string BrCons_4W_TPH = "-- Not Available --";
                    string BrCons_4W_Teh_Botol = "-- Not Available --";
                    string BrCons_4W_TPH_less_sugar = "-- Not Available --";
                    string BrCons_4W_NU_Green = "-- Not Available --";
                    string BrCons_4W_Teh_Kotak = "-- Not Available --";
                    string BrCons_4W_Fruit_Tea = "-- Not Available --";
                    string BrCons_4W_Mirai_Ocha = "-- Not Available --";
                    string BrCons_4W_Ichi_Ocha = "-- Not Available --";
                    string BrCons_4W_Teh_Gelas = "-- Not Available --";
                    string BrCons_4W_Teh_Javana = "-- Not Available --";
                    string BrCons_4W_Frestea = "-- Not Available --";
                    string BrCons_1W_TPH = "-- Not Available --";
                    string BrCons_1W_Teh_Botol = "-- Not Available --";
                    string BrCons_1W_TPH_less_sugar = "-- Not Available --";
                    string BrCons_1W_NU_Green = "-- Not Available --";
                    string BrCons_1W_Teh_Kotak = "-- Not Available --";
                    string BrCons_1W_Fruit_Tea = "-- Not Available --";
                    string BrCons_1W_Mirai_Ocha = "-- Not Available --";
                    string BrCons_1W_Ichi_Ocha = "-- Not Available --";
                    string BrCons_1W_Teh_Gelas = "-- Not Available --";
                    string BrCons_1W_Teh_Javana = "-- Not Available --";
                    string BrCons_1W_Frestea = "-- Not Available --";
                    string s12_1 = "-- Not Available --";
                    string s12_2 = "-- Not Available --";
                    string s12_3 = "-- Not Available --";
                    string s12_4 = "-- Not Available --";
                    string s12_5 = "-- Not Available --";
                    string s12_9 = "-- Not Available --";
                    string s13 = "-- Not Available --";
                    string C2x1_2 = "-- Not Available --";
                    string C2x1_19 = "-- Not Available --";
                    string C2x1_6 = "-- Not Available --";
                    string C2x1_1 = "-- Not Available --";
                    string C2x1_11 = "-- Not Available --";
                    string C2x2_2 = "-- Not Available --";
                    string C2x2_19 = "-- Not Available --";
                    string C2x2_6 = "-- Not Available --";
                    string C2x2_1 = "-- Not Available --";
                    string C2x2_11 = "-- Not Available --";
                    string C2x3_2 = "-- Not Available --";
                    string C2x3_19 = "-- Not Available --";
                    string C2x3_6 = "-- Not Available --";
                    string C2x3_1 = "-- Not Available --";
                    string C2x3_11 = "-- Not Available --";
                    string C2x4_2 = "-- Not Available --";
                    string C2x4_19 = "-- Not Available --";
                    string C2x4_6 = "-- Not Available --";
                    string C2x4_1 = "-- Not Available --";
                    string C2x4_11 = "-- Not Available --";
                    string C2x5_2 = "-- Not Available --";
                    string C2x5_19 = "-- Not Available --";
                    string C2x5_6 = "-- Not Available --";
                    string C2x5_1 = "-- Not Available --";
                    string C2x5_11 = "-- Not Available --";
                    string C2x6_2 = "-- Not Available --";
                    string C2x6_19 = "-- Not Available --";
                    string C2x6_6 = "-- Not Available --";
                    string C2x6_1 = "-- Not Available --";
                    string C2x6_11 = "-- Not Available --";
                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;
                                switch (variable_name)
                                {
                                    case "iobs":
                                        {
                                            /* u_id = Convert.ToString(record.GetValue(variable));
                                             userID = find_UserId(SURVEY_ID, SURVEY_PERIOD, u_id);*/
                                            userID = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "weightx":
                                        {
                                            weightage = Convert.ToDecimal(record.GetValue(variable));
                                            break;
                                        }
                                    case "gender":
                                        {
                                            gender = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "j1":
                                        {
                                            maritalStatus = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "city":
                                        {
                                            city = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "age":
                                        {
                                            AgeGroup = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "ses":
                                        {
                                            Ses = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "Period":
                                        {
                                            Period = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1c":
                                        {
                                            Fav_Br_RTD = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2c":
                                        {
                                            Fav_br_RTD_PET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1e":
                                        {
                                            Bumo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1a":
                                        {
                                            BrTom = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_3":
                                        {
                                            BrSpont_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_1":
                                        {
                                            BrSpont_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_4":
                                        {
                                            BrSpont_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_5":
                                        {
                                            BrSpont_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_6":
                                        {
                                            BrSpont_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_7":
                                        {
                                            BrSpont_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_8":
                                        {
                                            BrSpont_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_16":
                                        {
                                            BrSpont_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_17":
                                        {
                                            BrSpont_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_18":
                                        {
                                            BrSpont_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b1b_2":
                                        {
                                            BrSpont_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_3":
                                        {
                                            BrAided_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_1":
                                        {
                                            BrAided_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_4":
                                        {
                                            BrAided_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_5":
                                        {
                                            BrAided_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_6":
                                        {
                                            BrAided_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_7":
                                        {
                                            BrAided_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_8":
                                        {
                                            BrAided_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_16":
                                        {
                                            BrAided_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_17":
                                        {
                                            BrAided_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_18":
                                        {
                                            BrAided_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4a_2":
                                        {
                                            BrAided_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3h":
                                        {
                                            AdTom = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_3":
                                        {
                                            AdSpont_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_1":
                                        {
                                            AdSpont_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_4":
                                        {
                                            AdSpont_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_5":
                                        {
                                            AdSpont_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_6":
                                        {
                                            AdSpont_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_7":
                                        {
                                            AdSpont_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_8":
                                        {
                                            AdSpont_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_16":
                                        {
                                            AdSpont_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_17":
                                        {
                                            AdSpont_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_18":
                                        {
                                            AdSpont_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b3j_2":
                                        {
                                            AdSpont_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_3":
                                        {
                                            AdAided_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_1":
                                        {
                                            AdAided_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_4":
                                        {
                                            AdAided_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_5":
                                        {
                                            AdAided_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_6":
                                        {
                                            AdAided_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_7":
                                        {
                                            AdAided_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_8":
                                        {
                                            AdAided_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_16":
                                        {
                                            AdAided_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_17":
                                        {
                                            AdAided_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_18":
                                        {
                                            AdAided_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b4b_2":
                                        {
                                            AdAided_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2a":
                                        {
                                            TomRTDpet = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_3":
                                        {
                                            SpontRTDPet_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_1":
                                        {
                                            SpontRTDPet_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_4":
                                        {
                                            SpontRTDPet_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_5":
                                        {
                                            SpontRTDPet_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_6":
                                        {
                                            SpontRTDPet_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_7":
                                        {
                                            SpontRTDPet_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_8":
                                        {
                                            SpontRTDPet_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_16":
                                        {
                                            SpontRTDPet_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_17":
                                        {
                                            SpontRTDPet_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_18":
                                        {
                                            SpontRTDPet_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "b2b_2":
                                        {
                                            SpontRTDPet_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_3":
                                        {
                                            Ever_tried_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_1":
                                        {
                                            Ever_tried_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_4":
                                        {
                                            Ever_tried_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_5":
                                        {
                                            Ever_tried_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_6":
                                        {
                                            Ever_tried_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_7":
                                        {
                                            Ever_tried_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_8":
                                        {
                                            Ever_tried_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_16":
                                        {
                                            Ever_tried_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_17":
                                        {
                                            Ever_tried_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_18":
                                        {
                                            Ever_tried_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1a_2":
                                        {
                                            Ever_tried_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_3":
                                        {
                                            Cons_L3M_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_1":
                                        {
                                            Cons_L3M_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_4":
                                        {
                                            Cons_L3M_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_5":
                                        {
                                            Cons_L3M_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_6":
                                        {
                                            Cons_L3M_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_7":
                                        {
                                            Cons_L3M_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_8":
                                        {
                                            Cons_L3M_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_16":
                                        {
                                            Cons_L3M_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_17":
                                        {
                                            Cons_L3M_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_18":
                                        {
                                            Cons_L3M_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1b_2":
                                        {
                                            Cons_L3M_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_3":
                                        {
                                            Cons_1M_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_1":
                                        {
                                            Cons_1M_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_4":
                                        {
                                            Cons_1M_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_5":
                                        {
                                            Cons_1M_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_6":
                                        {
                                            Cons_1M_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_7":
                                        {
                                            Cons_1M_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_8":
                                        {
                                            Cons_1M_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_16":
                                        {
                                            Cons_1M_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_17":
                                        {
                                            Cons_1M_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_18":
                                        {
                                            Cons_1M_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1c_2":
                                        {
                                            Cons_1M_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_3":
                                        {
                                            Cons_1W_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_1":
                                        {
                                            Cons_1W_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_4":
                                        {
                                            Cons_1W_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_5":
                                        {
                                            Cons_1W_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_6":
                                        {
                                            Cons_1W_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_7":
                                        {
                                            Cons_1W_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_8":
                                        {
                                            Cons_1W_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_16":
                                        {
                                            Cons_1W_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_17":
                                        {
                                            Cons_1W_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_18":
                                        {
                                            Cons_1W_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1d_2":
                                        {
                                            Cons_1W_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_3":
                                        {
                                            Current_Cons_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_1":
                                        {
                                            Current_Cons_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_4":
                                        {
                                            Current_Cons_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_5":
                                        {
                                            Current_Cons_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_6":
                                        {
                                            Current_Cons_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_7":
                                        {
                                            Current_Cons_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_8":
                                        {
                                            Current_Cons_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_16":
                                        {
                                            Current_Cons_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_17":
                                        {
                                            Current_Cons_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_18":
                                        {
                                            Current_Cons_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1h_2":
                                        {
                                            Current_Cons_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "u1g":
                                        {
                                            Pre_Bumo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    
                                    case "s6a_3":
                                        {
                                            BrCons_L3M_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_1":
                                        {
                                            BrCons_L3M_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_4":
                                        {
                                            BrCons_L3M_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_5":
                                        {
                                            BrCons_L3M_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_6":
                                        {
                                            BrCons_L3M_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_7":
                                        {
                                            BrCons_L3M_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_8":
                                        {
                                            BrCons_L3M_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_16":
                                        {
                                            BrCons_L3M_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_17":
                                        {
                                            BrCons_L3M_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_18":
                                        {
                                            BrCons_L3M_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6a_2":
                                        {
                                            BrCons_L3M_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_3":
                                        {
                                            BrCons_4W_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_1":
                                        {
                                            BrCons_4W_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_4":
                                        {
                                            BrCons_4W_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_5":
                                        {
                                            BrCons_4W_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_6":
                                        {
                                            BrCons_4W_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_7":
                                        {
                                            BrCons_4W_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_8":
                                        {
                                            BrCons_4W_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_16":
                                        {
                                            BrCons_4W_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_17":
                                        {
                                            BrCons_4W_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_18":
                                        {
                                            BrCons_4W_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6b_2":
                                        {
                                            BrCons_4W_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_3":
                                        {
                                            BrCons_1W_TPH = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_1":
                                        {
                                            BrCons_1W_Teh_Botol = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_4":
                                        {
                                            BrCons_1W_TPH_less_sugar = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_5":
                                        {
                                            BrCons_1W_NU_Green = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_6":
                                        {
                                            BrCons_1W_Teh_Kotak = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_7":
                                        {
                                            BrCons_1W_Fruit_Tea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_8":
                                        {
                                            BrCons_1W_Mirai_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_16":
                                        {
                                            BrCons_1W_Ichi_Ocha = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_17":
                                        {
                                            BrCons_1W_Teh_Gelas = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_18":
                                        {
                                            BrCons_1W_Teh_Javana = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s6c_2":
                                        {
                                            BrCons_1W_Frestea = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s12_1":
                                        {
                                            s12_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s12_2":
                                        {
                                            s12_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s12_3":
                                        {
                                            s12_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s12_4":
                                        {
                                            s12_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s12_5":
                                        {
                                            s12_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s12_9":
                                        {
                                            s12_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "s13":
                                        {
                                            s13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x1_2":
                                        {
                                            C2x1_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x1_19":
                                        {
                                            C2x1_19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "c2x1_27":
                                        {
                                            C2x1_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x1_1":
                                        {
                                            C2x1_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x1_11":
                                        {
                                            C2x1_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x2_2":
                                        {
                                            C2x2_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x2_19":
                                        {
                                            C2x2_19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "c2x2_27":
                                        {
                                            C2x2_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x2_1":
                                        {
                                            C2x2_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x2_11":
                                        {
                                            C2x2_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x3_2":
                                        {
                                            C2x3_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x3_19":
                                        {
                                            C2x3_19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "c2x3_27":
                                        {
                                            C2x3_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x3_1":
                                        {
                                            C2x3_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x3_11":
                                        {
                                            C2x3_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x4_2":
                                        {
                                            C2x4_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x4_19":
                                        {
                                            C2x4_19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x4_27":
                                        {
                                            C2x4_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x4_1":
                                        {
                                            C2x4_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x4_11":
                                        {
                                            C2x4_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x5_2":
                                        {
                                            C2x5_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x5_19":
                                        {
                                            C2x5_19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x5_27":
                                        {
                                            C2x5_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x5_1":
                                        {
                                            C2x5_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x5_11":
                                        {
                                            C2x5_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x6_2":
                                        {
                                            C2x6_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x6_19":
                                        {
                                            C2x6_19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x6_27":
                                        {
                                            C2x6_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x6_1":
                                        {
                                            C2x6_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "C2x6_11":
                                        {
                                            C2x6_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    if (userID != null && weightage != 0)
                    {
                        // Console.Write(userID + " " + userEmail + " " + firstName + " " + lastName + " " + UserStatus + " " + gender + " " + maritalStatus + " " + education + " " + race + " " + religion + " " + postCode + " " + country + " " + city + " " + subDistrict + " " + village + " " + incomeRange + " " + industryName + " " + occupation + " " + SURVEY_ID + " " + favouriteBrand + " " + bumo + " " + AdTom + " " + BrTom);

                        iobj.insert_Dashboard_values(userID, UserEmail, FirstName, LastName, UserStatus, gender, maritalStatus, Education, Race, Religion, PostCode, Country, city, SubDistrict, Village, IncomeRange, IndustryName, Occupation, SurveyID, weightage, SurveyPeriod, Fav_Br_RTD, Fav_br_RTD_PET, Bumo, AgeGroup, Ses, Period, BrTom, BrSpont_TPH, BrSpont_Teh_Botol, BrSpont_TPH_less_sugar, BrSpont_NU_Green, BrSpont_Teh_Kotak, BrSpont_Fruit_Tea, BrSpont_Mirai_Ocha, BrSpont_Ichi_Ocha, BrSpont_Teh_Gelas, BrSpont_Teh_Javana, BrSpont_Frestea, BrAided_TPH, BrAided_Teh_Botol, BrAided_TPH_less_sugar, BrAided_NU_Green, BrAided_Teh_Kotak, BrAided_Fruit_Tea, BrAided_Mirai_Ocha, BrAided_Ichi_Ocha, BrAided_Teh_Gelas, BrAided_Teh_Javana, BrAided_Frestea, AdTom, AdSpont_TPH, AdSpont_Teh_Botol, AdSpont_TPH_less_sugar, AdSpont_NU_Green, AdSpont_Teh_Kotak, AdSpont_Fruit_Tea, AdSpont_Mirai_Ocha, AdSpont_Ichi_Ocha, AdSpont_Teh_Gelas, AdSpont_Teh_Javana, AdSpont_Frestea, AdAided_TPH, AdAided_Teh_Botol, AdAided_TPH_less_sugar, AdAided_NU_Green, AdAided_Teh_Kotak, AdAided_Fruit_Tea, AdAided_Mirai_Ocha, AdAided_Ichi_Ocha, AdAided_Teh_Gelas, AdAided_Teh_Javana, AdAided_Frestea, TomRTDpet, SpontRTDPet_TPH, SpontRTDPet_Teh_Botol, SpontRTDPet_TPH_less_sugar, SpontRTDPet_NU_Green, SpontRTDPet_Teh_Kotak, SpontRTDPet_Fruit_Tea, SpontRTDPet_Mirai_Ocha, SpontRTDPet_Ichi_Ocha, SpontRTDPet_Teh_Gelas, SpontRTDPet_Teh_Javana, SpontRTDPet_Frestea, Ever_tried_TPH, Ever_tried_Teh_Botol, Ever_tried_TPH_less_sugar, Ever_tried_NU_Green, Ever_tried_Teh_Kotak, Ever_tried_Fruit_Tea, Ever_tried_Mirai_Ocha, Ever_tried_Ichi_Ocha, Ever_tried_Teh_Gelas, Ever_tried_Teh_Javana, Ever_tried_Frestea, Cons_L3M_TPH, Cons_L3M_Teh_Botol, Cons_L3M_TPH_less_sugar, Cons_L3M_NU_Green, Cons_L3M_Teh_Kotak, Cons_L3M_Fruit_Tea, Cons_L3M_Mirai_Ocha, Cons_L3M_Ichi_Ocha, Cons_L3M_Teh_Gelas, Cons_L3M_Teh_Javana, Cons_L3M_Frestea, Cons_1M_TPH, Cons_1M_Teh_Botol, Cons_1M_TPH_less_sugar, Cons_1M_NU_Green, Cons_1M_Teh_Kotak, Cons_1M_Fruit_Tea, Cons_1M_Mirai_Ocha, Cons_1M_Ichi_Ocha, Cons_1M_Teh_Gelas, Cons_1M_Teh_Javana, Cons_1M_Frestea, Cons_1W_TPH, Cons_1W_Teh_Botol, Cons_1W_TPH_less_sugar, Cons_1W_NU_Green, Cons_1W_Teh_Kotak, Cons_1W_Fruit_Tea, Cons_1W_Mirai_Ocha, Cons_1W_Ichi_Ocha, Cons_1W_Teh_Gelas, Cons_1W_Teh_Javana, Cons_1W_Frestea, Current_Cons_TPH, Current_Cons_Teh_Botol, Current_Cons_TPH_less_sugar, Current_Cons_NU_Green, Current_Cons_Teh_Kotak, Current_Cons_Fruit_Tea, Current_Cons_Mirai_Ocha, Current_Cons_Ichi_Ocha, Current_Cons_Teh_Gelas, Current_Cons_Teh_Javana, Current_Cons_Frestea, Pre_Bumo, BrCons_L3M_TPH, BrCons_L3M_Teh_Botol, BrCons_L3M_TPH_less_sugar, BrCons_L3M_NU_Green, BrCons_L3M_Teh_Kotak, BrCons_L3M_Fruit_Tea, BrCons_L3M_Mirai_Ocha, BrCons_L3M_Ichi_Ocha, BrCons_L3M_Teh_Gelas, BrCons_L3M_Teh_Javana, BrCons_L3M_Frestea, BrCons_4W_TPH, BrCons_4W_Teh_Botol, BrCons_4W_TPH_less_sugar, BrCons_4W_NU_Green, BrCons_4W_Teh_Kotak, BrCons_4W_Fruit_Tea, BrCons_4W_Mirai_Ocha, BrCons_4W_Ichi_Ocha, BrCons_4W_Teh_Gelas, BrCons_4W_Teh_Javana, BrCons_4W_Frestea, BrCons_1W_TPH, BrCons_1W_Teh_Botol, BrCons_1W_TPH_less_sugar, BrCons_1W_NU_Green, BrCons_1W_Teh_Kotak, BrCons_1W_Fruit_Tea, BrCons_1W_Mirai_Ocha, BrCons_1W_Ichi_Ocha, BrCons_1W_Teh_Gelas, BrCons_1W_Teh_Javana, BrCons_1W_Frestea, s12_1, s12_2, s12_3, s12_4, s12_5, s12_9, s13, C2x1_2, C2x1_19, C2x1_6, C2x1_1, C2x1_11, C2x2_2, C2x2_19, C2x2_6, C2x2_1, C2x2_11, C2x3_2, C2x3_19, C2x3_6, C2x3_1, C2x3_11, C2x4_2, C2x4_19, C2x4_6, C2x4_1, C2x4_11, C2x5_2, C2x5_19, C2x5_6, C2x5_1, C2x5_11, C2x6_2, C2x6_19, C2x6_6, C2x6_1, C2x6_11);
                        //Console.ReadKey();
                        //Console.ReadKey();
                        //Console.Write('\t');

                    }
                }
            }
        }
      
    }
}
