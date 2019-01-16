﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RtdTeaParsing
{
    class DB_insertion_RTDTea
    {

        SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
        internal void insert_Dashboard_variable_values(string VARIABLE_NAME, string VARIABLE_NAME_SUB_NAME, string VARIABLE_ID, string VARIABLE_VALUE, string VARIABLE_NAME_QUESTION, int SURVEY_ID, string country, string BASE_VARIABLE_NAME, string SURVEY_PERIOD)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardSPS_Variable_Values (VARIABLE_NAME,VARIABLE_NAME_SUB_NAME,VARIABLE_ID,VARIABLE_VALUE,VARIABLE_NAME_QUESTION,SURVEY_ID,SURVEY_COUNTRY,BASE_VARIABLE_NAME,SURVEY_PERIOD) " + "VALUES('" + VARIABLE_NAME + "','" + VARIABLE_NAME_SUB_NAME + "','" + VARIABLE_ID + "','" + VARIABLE_VALUE + "','" + VARIABLE_NAME_QUESTION + "','" + SURVEY_ID + "','" + country + "','" + BASE_VARIABLE_NAME + "','" + SURVEY_PERIOD + "')", connection);
            try
            {

                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Dashboard variable values inserted successfully");

                connection.Close();



            }
            catch (Exception)
            {

                Console.WriteLine("Exception occured");
                Console.ReadLine();
            }
        }

      
        internal void insert_Dashboard_values(string userID, string UserEmail, string FirstName, string LastName, string UserStatus, string gender, string maritalStatus, string Education, string Race, string Religion, string PostCode, string Country, string city, string SubDistrict, string Village, string IncomeRange, string IndustryName, string Occupation, int SurveyID, decimal weightage, string SurveyPeriod, string Fav_Br_RTD, string Fav_br_RTD_PET, string Bumo, string AgeGroup, string Ses, string Period, string BrTom, string BrSpont_TPH, string BrSpont_Teh_Botol, string BrSpont_TPH_less_sugar, string BrSpont_NU_Green, string BrSpont_Teh_Kotak, string BrSpont_Fruit_Tea, string BrSpont_Mirai_Ocha, string BrSpont_Ichi_Ocha, string BrSpont_Teh_Gelas, string BrSpont_Teh_Javana, string BrSpont_Frestea, string BrAided_TPH, string BrAided_Teh_Botol, string BrAided_TPH_less_sugar, string BrAided_NU_Green, string BrAided_Teh_Kotak, string BrAided_Fruit_Tea, string BrAided_Mirai_Ocha, string BrAided_Ichi_Ocha, string BrAided_Teh_Gelas, string BrAided_Teh_Javana, string BrAided_Frestea, string AdTom, string AdSpont_TPH, string AdSpont_Teh_Botol, string AdSpont_TPH_less_sugar, string AdSpont_NU_Green, string AdSpont_Teh_Kotak, string AdSpont_Fruit_Tea, string AdSpont_Mirai_Ocha, string AdSpont_Ichi_Ocha, string AdSpont_Teh_Gelas, string AdSpont_Teh_Javana, string AdSpont_Frestea, string AdAided_TPH, string AdAided_Teh_Botol, string AdAided_TPH_less_sugar, string AdAided_NU_Green, string AdAided_Teh_Kotak, string AdAided_Fruit_Tea, string AdAided_Mirai_Ocha, string AdAided_Ichi_Ocha, string AdAided_Teh_Gelas, string AdAided_Teh_Javana, string AdAided_Frestea, string TomRTDpet, string SpontRTDPet_TPH, string SpontRTDPet_Teh_Botol, string SpontRTDPet_TPH_less_sugar, string SpontRTDPet_NU_Green, string SpontRTDPet_Teh_Kotak, string SpontRTDPet_Fruit_Tea, string SpontRTDPet_Mirai_Ocha, string SpontRTDPet_Ichi_Ocha, string SpontRTDPet_Teh_Gelas, string SpontRTDPet_Teh_Javana, string SpontRTDPet_Frestea, string Ever_tried_TPH, string Ever_tried_Teh_Botol, string Ever_tried_TPH_less_sugar, string Ever_tried_NU_Green, string Ever_tried_Teh_Kotak, string Ever_tried_Fruit_Tea, string Ever_tried_Mirai_Ocha, string Ever_tried_Ichi_Ocha, string Ever_tried_Teh_Gelas, string Ever_tried_Teh_Javana, string Ever_tried_Frestea, string Cons_L3M_TPH, string Cons_L3M_Teh_Botol, string Cons_L3M_TPH_less_sugar, string Cons_L3M_NU_Green, string Cons_L3M_Teh_Kotak, string Cons_L3M_Fruit_Tea, string Cons_L3M_Mirai_Ocha, string Cons_L3M_Ichi_Ocha, string Cons_L3M_Teh_Gelas, string Cons_L3M_Teh_Javana, string Cons_L3M_Frestea, string Cons_1M_TPH, string Cons_1M_Teh_Botol, string Cons_1M_TPH_less_sugar, string Cons_1M_NU_Green, string Cons_1M_Teh_Kotak, string Cons_1M_Fruit_Tea, string Cons_1M_Mirai_Ocha, string Cons_1M_Ichi_Ocha, string Cons_1M_Teh_Gelas, string Cons_1M_Teh_Javana, string Cons_1M_Frestea, string Cons_1W_TPH, string Cons_1W_Teh_Botol, string Cons_1W_TPH_less_sugar, string Cons_1W_NU_Green, string Cons_1W_Teh_Kotak, string Cons_1W_Fruit_Tea, string Cons_1W_Mirai_Ocha, string Cons_1W_Ichi_Ocha, string Cons_1W_Teh_Gelas, string Cons_1W_Teh_Javana, string Cons_1W_Frestea, string Current_Cons_TPH, string Current_Cons_Teh_Botol, string Current_Cons_TPH_less_sugar, string Current_Cons_NU_Green, string Current_Cons_Teh_Kotak, string Current_Cons_Fruit_Tea, string Current_Cons_Mirai_Ocha, string Current_Cons_Ichi_Ocha, string Current_Cons_Teh_Gelas, string Current_Cons_Teh_Javana, string Current_Cons_Frestea, string Pre_Bumo, string BrCons_L3M_TPH, string BrCons_L3M_Teh_Botol, string BrCons_L3M_TPH_less_sugar, string BrCons_L3M_NU_Green, string BrCons_L3M_Teh_Kotak, string BrCons_L3M_Fruit_Tea, string BrCons_L3M_Mirai_Ocha, string BrCons_L3M_Ichi_Ocha, string BrCons_L3M_Teh_Gelas, string BrCons_L3M_Teh_Javana, string BrCons_L3M_Frestea, string BrCons_4W_TPH, string BrCons_4W_Teh_Botol, string BrCons_4W_TPH_less_sugar, string BrCons_4W_NU_Green, string BrCons_4W_Teh_Kotak, string BrCons_4W_Fruit_Tea, string BrCons_4W_Mirai_Ocha, string BrCons_4W_Ichi_Ocha, string BrCons_4W_Teh_Gelas, string BrCons_4W_Teh_Javana, string BrCons_4W_Frestea, string BrCons_1W_TPH, string BrCons_1W_Teh_Botol, string BrCons_1W_TPH_less_sugar, string BrCons_1W_NU_Green, string BrCons_1W_Teh_Kotak, string BrCons_1W_Fruit_Tea, string BrCons_1W_Mirai_Ocha, string BrCons_1W_Ichi_Ocha, string BrCons_1W_Teh_Gelas, string BrCons_1W_Teh_Javana, string BrCons_1W_Frestea, string s12_1, string s12_2, string s12_3, string s12_4, string s12_5, string s12_9, string s13, string C2x1_2, string C2x1_19, string C2x1_6, string C2x1_1, string C2x1_11, string C2x2_2, string C2x2_19, string C2x2_6, string C2x2_1, string C2x2_11, string C2x3_2, string C2x3_19, string C2x3_6, string C2x3_1, string C2x3_11, string C2x4_2, string C2x4_19, string C2x4_6, string C2x4_1, string C2x4_11, string C2x5_2, string C2x5_19, string C2x5_6, string C2x5_1, string C2x5_11, string C2x6_2, string C2x6_19, string C2x6_6, string C2x6_1, string C2x6_11)
        {
            int i;
            connection.Open();
            //SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardFlatTabJava_m2RTDTea_temp (UserID,Gender,MaritalStatus,Education,Country,City,SubDistrict,IncomeRange,Occupation,SurveyID,AttendedOn,Weight,SurveyPeriod,Fav_Br_RTD,Fav_br_RTD_PET,Bumo,AgeGroup,Ses,Period,BrTom,BrSpont_TPH,BrSpont_Teh_Botol,BrSpont_TPH_less_sugar,BrSpont_NU_Green,BrSpont_Teh_Kotak,BrSpont_Fruit_Tea,BrSpont_Mirai_Ocha,BrSpont_Ichi_Ocha,BrSpont_Teh_Gelas,BrSpont_Teh_Javana,BrSpont_Frestea,BrAided_TPH,BrAided_Teh_Botol,BrAided_TPH_less_sugar,BrAided_NU_Green,BrAided_Teh_Kotak,BrAided_Fruit_Tea,BrAided_Mirai_Ocha,BrAided_Ichi_Ocha,BrAided_Teh_Gelas,BrAided_Teh_Javana,BrAided_Frestea,AdTom,AdSpont_TPH,AdSpont_Teh_Botol,AdSpont_TPH_less_sugar,AdSpont_NU_Green,AdSpont_Teh_Kotak,AdSpont_Fruit_Tea,AdSpont_Mirai_Ocha,AdSpont_Ichi_Ocha,AdSpont_Teh_Gelas,AdSpont_Teh_Javana,AdSpont_Frestea,AdAided_TPH,AdAided_Teh_Botol,AdAided_TPH_less_sugar,AdAided_NU_Green,AdAided_Teh_Kotak,AdAided_Fruit_Tea,AdAided_Mirai_Ocha,AdAided_Ichi_Ocha,AdAided_Teh_Gelas,AdAided_Teh_Javana,AdAided_Frestea,TomRTDpet,SpontRTDPet_TPH,SpontRTDPet_Teh_Botol,SpontRTDPet_TPH_less_sugar,SpontRTDPet_NU_Green,SpontRTDPet_Teh_Kotak,SpontRTDPet_Fruit_Tea,SpontRTDPet_Mirai_Ocha,SpontRTDPet_Ichi_Ocha,SpontRTDPet_Teh_Gelas,SpontRTDPet_Teh_Javana,SpontRTDPet_Frestea,Ever_tried_TPH,Ever_tried_Teh_Botol,Ever_tried_TPH_less_sugar,Ever_tried_NU_Green,Ever_tried_Teh_Kotak,Ever_tried_Fruit_Tea,Ever_tried_Mirai_Ocha,Ever_tried_Ichi_Ocha,Ever_tried_Teh_Gelas,Ever_tried_Teh_Javana,Ever_tried_Frestea,Cons_L3M_TPH,Cons_L3M_Teh_Botol,Cons_L3M_TPH_less_sugar,Cons_L3M_NU_Green,Cons_L3M_Teh_Kotak,Cons_L3M_Fruit_Tea,Cons_L3M_Mirai_Ocha,Cons_L3M_Ichi_Ocha,Cons_L3M_Teh_Gelas,Cons_L3M_Teh_Javana,Cons_L3M_Frestea,Cons_1M_TPH,Cons_1M_Teh_Botol,Cons_1M_TPH_less_sugar,Cons_1M_NU_Green,Cons_1M_Teh_Kotak,Cons_1M_Fruit_Tea,Cons_1M_Mirai_Ocha,Cons_1M_Ichi_Ocha,Cons_1M_Teh_Gelas,Cons_1M_Teh_Javana,Cons_1M_Frestea,Cons_1W_TPH,Cons_1W_Teh_Botol,Cons_1W_TPH_less_sugar,Cons_1W_NU_Green,Cons_1W_Teh_Kotak,Cons_1W_Fruit_Tea,Cons_1W_Mirai_Ocha,Cons_1W_Ichi_Ocha,Cons_1W_Teh_Gelas,Cons_1W_Teh_Javana,Cons_1W_Frestea,Current_Cons_TPH,Current_Cons_Teh_Botol,Current_Cons_TPH_less_sugar,Current_Cons_NU_Green,Current_Cons_Teh_Kotak,Current_Cons_Fruit_Tea,Current_Cons_Mirai_Ocha,Current_Cons_Ichi_Ocha,Current_Cons_Teh_Gelas,Current_Cons_Teh_Javana,Current_Cons_Frestea,Pre_Bumo,BrCons_L3M_TPH,BrCons_L3M_Teh_Botol,BrCons_L3M_TPH_less_sugar,BrCons_L3M_NU_Green,BrCons_L3M_Teh_Kotak,BrCons_L3M_Fruit_Tea,BrCons_L3M_Mirai_Ocha,BrCons_L3M_Ichi_Ocha,BrCons_L3M_Teh_Gelas,BrCons_L3M_Teh_Javana,BrCons_L3M_Frestea,BrCons_4W_TPH,BrCons_4W_Teh_Botol,BrCons_4W_TPH_less_sugar,BrCons_4W_NU_Green,BrCons_4W_Teh_Kotak,BrCons_4W_Fruit_Tea,BrCons_4W_Mirai_Ocha,BrCons_4W_Ichi_Ocha,BrCons_4W_Teh_Gelas,BrCons_4W_Teh_Javana,BrCons_4W_Frestea,BrCons_1W_TPH,BrCons_1W_Teh_Botol,BrCons_1W_TPH_less_sugar,BrCons_1W_NU_Green,BrCons_1W_Teh_Kotak,BrCons_1W_Fruit_Tea,BrCons_1W_Mirai_Ocha,BrCons_1W_Ichi_Ocha,BrCons_1W_Teh_Gelas,BrCons_1W_Teh_Javana,BrCons_1W_Frestea,s12_1,s12_2,s12_3,s12_4,s12_5,s12_9,s13,C2x1_2,C2x1_19,C2x1_6,C2x1_1,C2x1_11,C2x2_2,C2x2_19,C2x2_6,C2x2_1,C2x2_11,C2x3_2,C2x3_19,C2x3_6,C2x3_1,C2x3_11,C2x4_2,C2x4_19,C2x4_6,C2x4_1,C2x4_11,C2x5_2,C2x5_19,C2x5_6,C2x5_1,C2x5_11,C2x6_2,C2x6_19,C2x6_6,C2x6_1,C2x6_11,BrTom_BK,AdTom_BK,Fav_RTD_BK,Fav2_Pet_BK,Bumo_BK,Pre_Bumo_Bk) " + "VALUES('" + userID + "','" + gender + "','" + maritalStatus + "','" + Education + "','" + Country + "','" + city + "','" + SubDistrict + "','" + IncomeRange + "','" + Occupation + "','" + SurveyID + "','" + SurveyPeriod + "','" + weightage + "','" + SurveyPeriod + "','" + Fav_Br_RTD + "','" + Fav_br_RTD_PET + "','" + Bumo + "','" + AgeGroup + "','" + Ses + "','" + Period + "','" + BrTom + "','" + BrSpont_TPH + "','" + BrSpont_Teh_Botol + "','" + BrSpont_TPH_less_sugar + "','" + BrSpont_NU_Green + "','" + BrSpont_Teh_Kotak + "','" + BrSpont_Fruit_Tea + "','" + BrSpont_Mirai_Ocha + "','" + BrSpont_Ichi_Ocha + "','" + BrSpont_Teh_Gelas + "','" + BrSpont_Teh_Javana + "','" + BrSpont_Frestea + "','" + BrAided_TPH + "','" + BrAided_Teh_Botol + "','" + BrAided_TPH_less_sugar + "','" + BrAided_NU_Green + "','" + BrAided_Teh_Kotak + "','" + BrAided_Fruit_Tea + "','" + BrAided_Mirai_Ocha + "','" + BrAided_Ichi_Ocha + "','" + BrAided_Teh_Gelas + "','" + BrAided_Teh_Javana + "','" + BrAided_Frestea + "','" + AdTom + "','" + AdSpont_TPH + "','" + AdSpont_Teh_Botol + "','" + AdSpont_TPH_less_sugar + "','" + AdSpont_NU_Green + "','" + AdSpont_Teh_Kotak + "','" + AdSpont_Fruit_Tea + "','" + AdSpont_Mirai_Ocha + "','" + AdSpont_Ichi_Ocha + "','" + AdSpont_Teh_Gelas + "','" + AdSpont_Teh_Javana + "','" + AdSpont_Frestea + "','" + AdAided_TPH + "','" + AdAided_Teh_Botol + "','" + AdAided_TPH_less_sugar + "','" + AdAided_NU_Green + "','" + AdAided_Teh_Kotak + "','" + AdAided_Fruit_Tea + "','" + AdAided_Mirai_Ocha + "','" + AdAided_Ichi_Ocha + "','" + AdAided_Teh_Gelas + "','" + AdAided_Teh_Javana + "','" + AdAided_Frestea + "','" + TomRTDpet + "','" + SpontRTDPet_TPH + "','" + SpontRTDPet_Teh_Botol + "','" + SpontRTDPet_TPH_less_sugar + "','" + SpontRTDPet_NU_Green + "','" + SpontRTDPet_Teh_Kotak + "','" + SpontRTDPet_Fruit_Tea + "','" + SpontRTDPet_Mirai_Ocha + "','" + SpontRTDPet_Ichi_Ocha + "','" + SpontRTDPet_Teh_Gelas + "','" + SpontRTDPet_Teh_Javana + "','" + SpontRTDPet_Frestea + "','" + Ever_tried_TPH + "','" + Ever_tried_Teh_Botol + "','" + Ever_tried_TPH_less_sugar + "','" + Ever_tried_NU_Green + "','" + Ever_tried_Teh_Kotak + "','" + Ever_tried_Fruit_Tea + "','" + Ever_tried_Mirai_Ocha + "','" + Ever_tried_Ichi_Ocha + "','" + Ever_tried_Teh_Gelas + "','" + Ever_tried_Teh_Javana + "','" + Ever_tried_Frestea + "','" + Cons_L3M_TPH + "','" + Cons_L3M_Teh_Botol + "','" + Cons_L3M_TPH_less_sugar + "','" + Cons_L3M_NU_Green + "','" + Cons_L3M_Teh_Kotak + "','" + Cons_L3M_Fruit_Tea + "','" + Cons_L3M_Mirai_Ocha + "','" + Cons_L3M_Ichi_Ocha + "','" + Cons_L3M_Teh_Gelas + "','" + Cons_L3M_Teh_Javana + "','" + Cons_L3M_Frestea + "','" + Cons_1M_TPH + "','" + Cons_1M_Teh_Botol + "','" + Cons_1M_TPH_less_sugar + "','" + Cons_1M_NU_Green + "','" + Cons_1M_Teh_Kotak + "','" + Cons_1M_Fruit_Tea + "','" + Cons_1M_Mirai_Ocha + "','" + Cons_1M_Ichi_Ocha + "','" + Cons_1M_Teh_Gelas + "','" + Cons_1M_Teh_Javana + "','" + Cons_1M_Frestea + "','" + Cons_1W_TPH + "','" + Cons_1W_Teh_Botol + "','" + Cons_1W_TPH_less_sugar + "','" + Cons_1W_NU_Green + "','" + Cons_1W_Teh_Kotak + "','" + Cons_1W_Fruit_Tea + "','" + Cons_1W_Mirai_Ocha + "','" + Cons_1W_Ichi_Ocha + "','" + Cons_1W_Teh_Gelas + "','" + Cons_1W_Teh_Javana + "','" + Cons_1W_Frestea + "','" + Current_Cons_TPH + "','" + Current_Cons_Teh_Botol + "','" + Current_Cons_TPH_less_sugar + "','" + Current_Cons_NU_Green + "','" + Current_Cons_Teh_Kotak + "','" + Current_Cons_Fruit_Tea + "','" + Current_Cons_Mirai_Ocha + "','" + Current_Cons_Ichi_Ocha + "','" + Current_Cons_Teh_Gelas + "','" + Current_Cons_Teh_Javana + "','" + Current_Cons_Frestea + "','" + Pre_Bumo + "','" + BrCons_L3M_TPH + "','" + BrCons_L3M_Teh_Botol + "','" + BrCons_L3M_TPH_less_sugar + "','" + BrCons_L3M_NU_Green + "','" + BrCons_L3M_Teh_Kotak + "','" + BrCons_L3M_Fruit_Tea + "','" + BrCons_L3M_Mirai_Ocha + "','" + BrCons_L3M_Ichi_Ocha + "','" + BrCons_L3M_Teh_Gelas + "','" + BrCons_L3M_Teh_Javana + "','" + BrCons_L3M_Frestea + "','" + BrCons_4W_TPH + "','" + BrCons_4W_Teh_Botol + "','" + BrCons_4W_TPH_less_sugar + "','" + BrCons_4W_NU_Green + "','" + BrCons_4W_Teh_Kotak + "','" + BrCons_4W_Fruit_Tea + "','" + BrCons_4W_Mirai_Ocha + "','" + BrCons_4W_Ichi_Ocha + "','" + BrCons_4W_Teh_Gelas + "','" + BrCons_4W_Teh_Javana + "','" + BrCons_4W_Frestea + "','" + BrCons_1W_TPH + "','" + BrCons_1W_Teh_Botol + "','" + BrCons_1W_TPH_less_sugar + "','" + BrCons_1W_NU_Green + "','" + BrCons_1W_Teh_Kotak + "','" + BrCons_1W_Fruit_Tea + "','" + BrCons_1W_Mirai_Ocha + "','" + BrCons_1W_Ichi_Ocha + "','" + BrCons_1W_Teh_Gelas + "','" + BrCons_1W_Teh_Javana + "','" + BrCons_1W_Frestea + "','" + s12_1 + "','" + s12_2 + "','" + s12_3 + "','" + s12_4 + "','" + s12_5 + "','" + s12_9 + "','" + s13 + "','" + C2x1_2 + "','" + C2x1_19 + "','" + C2x1_6 + "','" + C2x1_1 + "','" + C2x1_11 + "','" + C2x2_2 + "','" + C2x2_19 + "','" + C2x2_6 + "','" + C2x2_1 + "','" + C2x2_11 + "','" + C2x3_2 + "','" + C2x3_19 + "','" + C2x3_6 + "','" + C2x3_1 + "','" + C2x3_11 + "','" + C2x4_2 + "','" + C2x4_19 + "','" + C2x4_6 + "','" + C2x4_1 + "','" + C2x4_11 + "','" + C2x5_2 + "','" + C2x5_19 + "','" + C2x5_6 + "','" + C2x5_1 + "','" + C2x5_11 + "','" + C2x6_2 + "','" + C2x6_19 + "','" + C2x6_6 + "','" + C2x6_1 + "','" + C2x6_11 + "','" + BrTom + "','" + AdTom + "','" + Fav_Br_RTD + "','" + Fav_br_RTD_PET + "','" + Bumo + "','" + Pre_Bumo + "' )", connection);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully");
                i = 1;
            }
            catch (Exception ex)
            {

                connection.Close();
                i = 0;
                Console.WriteLine("Exception occured" + ex.ToString());
                Console.WriteLine("Exception occured");

                Console.ReadLine();
            }
            connection.Close();
        }
    }
}
