using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SACUI
{
    public struct ResponseMessage{
        public bool response;
        public string message;
    }
    public static class InputValidation
    {
         private static ResponseMessage rm = new ResponseMessage();
         private static string mEx="";
         private static string m1="";
         private static string m2="";


         public static ResponseMessage IsInt(string p_value){
             int l_value;
             if(string.IsNullOrEmpty(p_value)){
                 rm.response = false;
                 m1 = "this field cannot be empty!";
             }else{
                if(Int32.TryParse(p_value,out l_value)){
                    rm.response = true;
                    m2 = "";
                }else{
                    rm.response = false;
                    m2 = "this field must be a digit (integer)!";
                }                
             }
             rm.message = m1+m2;
             return rm;
         }
         public static ResponseMessage IsDouble(string p_value){
             double l_value;
             if(string.IsNullOrEmpty(p_value)){
                 rm.response = false;
                 m1 = "this field cannot be empty!";
             }else{
                if(Double.TryParse(p_value,out l_value)){
                    rm.response = true;
                    m2 = "";
                }else{
                    rm.response = false;
                    m2 = " this field must be a digit (decimal)! ";
                }
             }
             rm.message = m1+m2;
             return rm;
         }
         public static ResponseMessage IsNotNull(string p_value, int p_maxChar){
             if(string.IsNullOrEmpty(p_value)){
                 rm.response = false;
                  rm.message = " this field cannot be empty! ";
             }else{
                 if(p_value.Length>p_maxChar){
                     rm.response = false;
                     rm.message = $" Number of character must not be greater than {p_maxChar}";
                 }else{
                     rm.message = "";
                      rm.response = true;
                 }                
             }
             return rm;
         }
         public static ResponseMessage IsEmail(string p_value){
            string email = p_value;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if(!string.IsNullOrEmpty(email)){
                if (match.Success){
                    rm.response = true;
                    rm.message = "";
                } else{
                    rm.response = false;
                    rm.message = " invalid email! (example@domain.tld)";
                } 
            }           
            return rm;   
            // Return true if strIn is in valid e-mail format.
            //return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");             
        }
        public static ResponseMessage IsPhone(string p_value){
            string phone = p_value;
            Regex regex = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
            Match match = regex.Match(phone);
             if (!string.IsNullOrEmpty(phone)){
                 if(match.Success){
                     rm.response = true;
                     rm.message = "";
                 }else{
                     rm.response = false;
                     rm.message = " invalid Phone! (Phone must be 10 digit) ";
                 }
             }
            return rm;
        }
        public static ResponseMessage IsInRangeInt(string p_value, int p_minValue, int p_maxValue){
            int p_valueConverted;
            if(string.IsNullOrEmpty(p_value)){
                rm.response =false;
                m1 = " Your choice cannot be empty! ";
            }else{
                try{
                    if(Int32.TryParse(p_value,out p_valueConverted)&&(p_valueConverted>=p_minValue && p_valueConverted<= p_maxValue)){
                    rm.response = true;
                    m2 = "";
                }else{
                    rm.response =false;
                    m2 = $" Your choice must be a digit in the range of {p_minValue} to {p_maxValue} ! ";
                }
                }catch(Exception ex){
                    mEx = ex.Message;
                }
                
            }
            rm.message = m1+m2+mEx;
            return rm; 
        }
        public static ResponseMessage IsInRangeDouble(string p_value, int p_minValue, int p_maxValue){
            double p_valueConverted;
            if(string.IsNullOrEmpty(p_value)){
                rm.response =false;
                m1 = " Your choice cannot be empty! ";
            }else{
                try{
                    if(Double.TryParse(p_value,out p_valueConverted)&&(p_valueConverted>=p_minValue && p_valueConverted<= p_maxValue)){
                    rm.response = true;
                    m2 = "";
                }else{
                    rm.response =false;
                    m2 = $" Your choice must be a digit in the range of {p_minValue} to {p_maxValue} ! ";
                }
                }catch(Exception ex){
                    mEx = ex.Message;
                }
                
            }
            rm.message = m1+m2+mEx;
            return rm; 
        }
        public static ResponseMessage IsInList(List<int> p_listInt, string p_value){
            int p_valueConverted;
            if(string.IsNullOrEmpty(p_value)){
                rm.response =false;
                m1 = " Your choice cannot be empty! ";
            }else{
                try{
                    if(int.TryParse(p_value,out p_valueConverted)){
                        foreach(int i in p_listInt)
                            if(p_valueConverted == i){
                                rm.response = true;
                                rm.message="";
                            }else{
                                rm.response = false;
                                rm.message=" Your choice is not in the list! ";
                            }
                    }else{
                        rm.response =false;
                        m2 = " Your choice must be a digit ! ";
                    }
                }catch(Exception ex){
                    mEx = ex.Message;
                }
                
            }
            rm.message = m1+m2+mEx;
            return rm;
        }
    }
}