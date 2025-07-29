using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1ConfigGenerator
{
    class BreakerCard : M1Card
    {
        public BreakerCard(int argInt)
        {
            M1_SetCardLetterOnCreation(Convert.ToString(argInt));
        }

        public void Brk_ChangeAddress()
        {
            // general
            M1_ChangeAddress(m1ParameterNames);
            // card-specific
            M1_ChangeAddress(vinParameterNames);
            // channels
            M1_ChangeAddress(breakerChDirectionNames);
            M1_ChangeAddress(breakerChOvercurrentAmpsNames);
            M1_ChangeAddress(breakerChUndercurrentAmpsNames);
            M1_ChangeAddress(breakerChOvercurrentTimeNames);
            M1_ChangeAddress(breakerChMeasCurTimeNames);
            M1_ChangeAddress(breakerChModeNames);
            M1_ChangeAddress(breakerChPairedNames);
            M1_ChangeAddress(breakerChIGNNames);
            M1_ChangeAddress(breakerChParkNames);
            M1_ChangeAddress(cardChGroup0Names);
            M1_ChangeAddress(cardChGroup1Names);
            M1_ChangeAddress(cardChGroup2Names);
            M1_ChangeAddress(cardChGroup3Names);
            M1_SetNodeCfg();
        }

        public void CreateBreakerFile()
        {
            using (StreamWriter sw = File.CreateText(@Brk_GetConfigPath() + M1_GetConfigName()))
            {
                DateTime currentDateTime = DateTime.Now;
                sw.WriteLine(commentBox);
                sw.WriteLine(commentBox);
                sw.WriteLine(commentBox);
                sw.WriteLine("//");
                sw.WriteLine("//  DEVICE ADDRESS " + M1_GetCardLetter() + " CONFIG");
                sw.WriteLine("//");
                sw.WriteLine("//  This file was auto-generated using the Firefly M1 Config Generator version " + M1_GetVerRev() + " on " + currentDateTime);
                sw.WriteLine("//");
                sw.WriteLine(commentBox);
                sw.WriteLine(commentBox);
                sw.WriteLine(commentBox);
                sw.WriteLine("");
                sw.WriteLine("");

                // inherited M1 parameters              
                for (int i = 0; i <= BASE_DRIVER_INDEX; i++)
                {
                    sw.WriteLine("#define " + m1ParameterNames[i] + tabs[2] + m1ParameterValues[i]);

                    if (i == DEVICE_HEADER_CONFIGURATION_VERSION)
                    {
                        sw.WriteLine("");
                        sw.WriteLine("// ### DC DRIVER PARAMETERS ###");
                    }
                    else if (i == DEV_ADDR || i == DEV_ADDR_CFG_TYPE || i == ENABLE_FORCE_CMDS || i == DSA_ADDR || i == BASE_DRIVER_INDEX)
                    {
                        sw.WriteLine("");
                    }
                }

                // VIN breaker
                sw.WriteLine("// ### VIN BREAKER SETTINGS ###");
                for (int i = 0; i < 13; i++)
                {
                    if (i == 0)
                    {
                        sw.WriteLine("#define " + vinParameterNames[i] + tabs[2] + "VIN_CONVERT_AMPS_TO_ADC(" + vinParameterValues[i] + ")");
                    }
                    else
                    {
                        sw.WriteLine("#define " + vinParameterNames[i] + tabs[2] + vinParameterValues[i]);
                    }

                    if (i == 6 || i == 8)
                    {
                        sw.WriteLine("");
                    }
                }
                sw.WriteLine("");

                // card channels
                for (int i = 0; i < 12; i++)
                {
                    sw.WriteLine("// ### CHANNEL " + Convert.ToString(i) + " ###");
                    sw.WriteLine("#define " + breakerChDirectionNames[i] + tabs[6] + breakerChDirectionValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + breakerChOvercurrentAmpsNames[i] + tabs[4] + "BRKR_CONVERT_AMPS_TO_ADC_MARGIN(" + breakerChOvercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + breakerChUndercurrentAmpsNames[i] + tabs[4] + "BRKR_CONVERT_AMPS_TO_ADC_MARGIN(" + breakerChUndercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + breakerChOvercurrentTimeNames[i] + tabs[3] + breakerChOvercurrentTimeValues[i]);
                    sw.WriteLine("#define " + breakerChMeasCurTimeNames[i] + tabs[3] + breakerChMeasCurTimeValues[i]);
                    sw.WriteLine("#define " + breakerChModeNames[i] + tabs[7] + breakerChModeValues[i]);
                    sw.WriteLine("#define " + breakerChPairedNames[i] + tabs[5] + breakerChPairedValues[i]);
                    sw.WriteLine("#define " + breakerChIGNNames[i] + tabs[5] + breakerChIGNValues[i]);
                    sw.WriteLine("#define " + breakerChParkNames[i] + tabs[5] + breakerChParkValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + cardChGroup0Names[i] + tabs[5] + cardChGroup0Values[i]);
                    sw.WriteLine("#define " + cardChGroup1Names[i] + tabs[5] + cardChGroup1Values[i]);
                    sw.WriteLine("#define " + cardChGroup2Names[i] + tabs[5] + cardChGroup2Values[i]);
                    sw.WriteLine("#define " + cardChGroup3Names[i] + tabs[5] + cardChGroup3Values[i]);
                    sw.WriteLine("");
                }
            }
        }

        public string Brk_GetConfigPath()
        {
            return configPath;
        }

        public void Brk_SetOCAmps(int argInt, string argString)
        {
            breakerChOvercurrentAmpsValues[argInt] = argString;
        }

        public string Brk_GetOCAmps(int argInt)
        {
            return breakerChOvercurrentAmpsValues[argInt];
        }

        public void Brk_SetOCTime(int argInt, string argString)
        {
            breakerChOvercurrentTimeValues[argInt] = argString;
        }

        public string Brk_GetOCTime(int argInt)
        {
            return breakerChOvercurrentTimeValues[argInt];
        }

        public void Brk_SetInterrupt(int argInt, string argString)
        {
            if (argString == "None")    { cardChGroup0Values[argInt] = "DISABLE_GROUP"; }
            else                        { cardChGroup0Values[argInt] = argString; }
        }

        public string Brk_GetInterrupt(int argInt)
        {
            if (cardChGroup0Values[argInt] == "DISABLE_GROUP")  { return "None"; }
            else                                                { return cardChGroup0Values[argInt]; }
        }

        public void Brk_SetVINInterrupt(string argString)
        {
            vinParameterValues[4] = argString; // VIN interrupter index
            vinParameterValues[9] = argString; // VIN interrupt group, set to same as index
        }

        public string Brk_GetVINInterrupt()
        {
            return vinParameterValues[4];
        }

        public void Brk_SetVINOCAmps(string argString)
        {
            vinParameterValues[0] = argString;
        }

        public string Brk_GetVINOCAmps()
        {
            return vinParameterValues[0];
        }

        public void Brk_SetVINOCTime(string argString)
        {
            vinParameterValues[2] = argString; // average time
        }

        public string Brk_GetVINOCTime()
        {
            return vinParameterValues[2];
        }

        public void Brk_SetDirection(int argInt, string argString)
        {
            breakerChDirectionValues[argInt] = "DRVR_STATE_" + argString.ToUpper();
        }

        public string Brk_GetDirection(int argInt)
        {
            if (breakerChDirectionValues[argInt] == "DRVR_STATE_HIGH") { return "High"; }
            else if (breakerChDirectionValues[argInt] == "DRVR_STATE_LOW") { return "Low"; }
            else if (breakerChDirectionValues[argInt] == "DRVR_STATE_REVERSE") { return "Reverse"; }
            else if (breakerChDirectionValues[argInt] == "DRVR_STATE_FORWARD") { return "Forward"; }
            else if (breakerChDirectionValues[argInt] == "DRVR_STATE_UP") { return "Up"; }
            else if (breakerChDirectionValues[argInt] == "DRVR_STATE_DOWN") { return "Down"; }
            else { return "Off"; }
        }

        public void Brk_SetUndAmp(int argInt, string argString)
        {
            // Values array only stores number, HC_CONVERT_AMPS_TO_ADC formatting added in print function
            breakerChUndercurrentAmpsValues[argInt] = "0x" + argString;
        }

        public string Brk_GetUndAmp(int argInt)
        {
            return breakerChUndercurrentAmpsValues[argInt].Substring(2); // removes "0x"
        }

        public void Brk_SetMeasCurTime(int argInt, string argString)
        {
            breakerChMeasCurTimeValues[argInt] = argString;
        }

        public string Brk_GetMeasCurTime(int argInt)
        {
            return breakerChMeasCurTimeValues[argInt];
        }

        public void Brk_SetMode(int argInt, string argString)
        {
            breakerChModeValues[argInt] = "DRVR_TYPE_" + argString.ToUpper();
        }

        public string Brk_GetMode(int argInt)
        {
            if (breakerChModeValues[argInt] == "DRVR_TYPE_SLAVE") { return "Slave"; }
            else if (breakerChModeValues[argInt] == "DRVR_TYPE_UNUSED") { return "Unused"; }
            else { return "Breaker"; }
        }

        public void Brk_SetPaired(int argInt, string argString)
        {
            if (argString == "None") { breakerChPairedValues[argInt] = "NO_SLAVE"; }
            else { breakerChPairedValues[argInt] = "PAIRED_TO_CHNL" + argString; }
        }

        public string Brk_GetPaired(int argInt)
        {
            return (breakerChPairedValues[argInt] == "NO_SLAVE" ? "None" : breakerChPairedValues[argInt].Substring(14)); // returns number from PAIRED_TO_CHNL#
        }

        public void Brk_SetIGNSafety(int argInt,string argString )
        {
            if (argString == "Active") { breakerChIGNValues[argInt] = "DRVR_ENABLED_SAFETY_ACTIVE"; }
            else if (argString == "Inactive") { breakerChIGNValues[argInt] = "DRVR_ENABLED_SAFETY_INACTIVE"; }
            else { breakerChIGNValues[argInt] = "DRVR_SAFETY_DISABLED"; }
        }

        public string Brk_GetIGNSafety(int argInt)
        {
            if (breakerChIGNValues[argInt] == "DRVR_ENABLED_SAFETY_ACTIVE") { return "Active"; }
            else if (breakerChIGNValues[argInt] == "DRVR_ENABLED_SAFETY_INACTIVE") { return "Inactive"; }
            else { return "Always"; }
        }

        public void Brk_SetParkSafety(int argInt, string argString)
        {
            if (argString == "Active") { breakerChParkValues[argInt] = "DRVR_ENABLED_SAFETY_ACTIVE"; }
            else if (argString == "Inactive") { breakerChParkValues[argInt] = "DRVR_ENABLED_SAFETY_INACTIVE"; }
            else { breakerChParkValues[argInt] = "DRVR_SAFETY_DISABLED"; }
        }

        public string Brk_GetParkSafety(int argInt)
        {
            if (breakerChParkValues[argInt] == "DRVR_ENABLED_SAFETY_ACTIVE") { return "Active"; }
            else if (breakerChParkValues[argInt] == "DRVR_ENABLED_SAFETY_INACTIVE") { return "Inactive"; }
            else { return "Always"; }
        }

        private string configPath = @"M1_DcDriver_Config\Src\M1_Breaker\DeviceConfigs\";

        public string[] vinParameterNames =
        {
            "HARD_LIMIT_CURRENT_THRESH_Z        ", // 0
            "HARD_LIMIT_TIME_CONST_Z            ", // 1
            "AVG_TIME_CONST_Z                   ", // 2
            "TRIP_MILLIS_Z                      ", // 3
            "INTERRUPTER_INDEX_ADDR_Z           ", // 4
            "LOAD_CONTRIBUTION_FIXED_MARGIN_Z   ", // 5
            "LOAD_CONTRIBUTION_SCALED_MARGIN_Z  ", // 6
            "IGN_SAFETY_EN_CHNL_Z12             ", // 7
            "PARK_SAFETY_EN_CHNL_Z12            ", // 8
            "GROUP_INDEX0_CHNL_Z12              ", // 9
            "GROUP_INDEX1_CHNL_Z12              ", // 10
            "GROUP_INDEX2_CHNL_Z12              ", // 11
            "GROUP_INDEX3_CHNL_Z12              ", // 12
        };

        public string[] vinParameterValues =
        {
            "60",                               // 0
            "8",                                // 1
            "8",                                // 2
            "1000",                             // 3
            "DISABLE_GROUP",                    // 4
            "0.5",                              // 5
            "1.15",                             // 6
            "DRVR_SAFETY_DISABLED",             // 7
            "DRVR_SAFETY_DISABLED",             // 8
            "DISABLE_GROUP",                    // 9
            "DISABLE_GROUP",                    // 10
            "DISABLE_GROUP",                    // 11
            "DISABLE_GROUP",                    // 12
        };

        //
        public string[] breakerChDirectionNames = { "DIRECTION_CHNL_Z0 ", "DIRECTION_CHNL_Z1 ", "DIRECTION_CHNL_Z2 ", "DIRECTION_CHNL_Z3 ", "DIRECTION_CHNL_Z4 ", "DIRECTION_CHNL_Z5 ", "DIRECTION_CHNL_Z6 ", "DIRECTION_CHNL_Z7 ", "DIRECTION_CHNL_Z8 ", "DIRECTION_CHNL_Z9 ", "DIRECTION_CHNL_Z10", "DIRECTION_CHNL_Z11" };
        public string[] breakerChDirectionValues = { "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH", "DRVR_STATE_HIGH" };
        //
        public string[] breakerChOvercurrentAmpsNames = { "BRKR_OC_ADC_THRESH_CHNL_Z0 ", "BRKR_OC_ADC_THRESH_CHNL_Z1 ", "BRKR_OC_ADC_THRESH_CHNL_Z2 ", "BRKR_OC_ADC_THRESH_CHNL_Z3 ", "BRKR_OC_ADC_THRESH_CHNL_Z4 ", "BRKR_OC_ADC_THRESH_CHNL_Z5 ", "BRKR_OC_ADC_THRESH_CHNL_Z6 ", "BRKR_OC_ADC_THRESH_CHNL_Z7 ", "BRKR_OC_ADC_THRESH_CHNL_Z8 ", "BRKR_OC_ADC_THRESH_CHNL_Z9 ", "BRKR_OC_ADC_THRESH_CHNL_Z10", "BRKR_OC_ADC_THRESH_CHNL_Z11" };
        public string[] breakerChOvercurrentAmpsValues = { "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10" };
        //
        public string[] breakerChUndercurrentAmpsNames = { "BRKR_UC_ADC_THRESH_CHNL_Z0 ", "BRKR_UC_ADC_THRESH_CHNL_Z1 ", "BRKR_UC_ADC_THRESH_CHNL_Z2 ", "BRKR_UC_ADC_THRESH_CHNL_Z3 ", "BRKR_UC_ADC_THRESH_CHNL_Z4 ", "BRKR_UC_ADC_THRESH_CHNL_Z5 ", "BRKR_UC_ADC_THRESH_CHNL_Z6 ", "BRKR_UC_ADC_THRESH_CHNL_Z7 ", "BRKR_UC_ADC_THRESH_CHNL_Z8 ", "BRKR_UC_ADC_THRESH_CHNL_Z9 ", "BRKR_UC_ADC_THRESH_CHNL_Z10", "BRKR_UC_ADC_THRESH_CHNL_Z11" };
        public string[] breakerChUndercurrentAmpsValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] breakerChOvercurrentTimeNames = { "FAULT_CUR_TIME_CONST_CHNL_Z0 ", "FAULT_CUR_TIME_CONST_CHNL_Z1 ", "FAULT_CUR_TIME_CONST_CHNL_Z2 ", "FAULT_CUR_TIME_CONST_CHNL_Z3 ", "FAULT_CUR_TIME_CONST_CHNL_Z4 ", "FAULT_CUR_TIME_CONST_CHNL_Z5 ", "FAULT_CUR_TIME_CONST_CHNL_Z6 ", "FAULT_CUR_TIME_CONST_CHNL_Z7 ", "FAULT_CUR_TIME_CONST_CHNL_Z8 ", "FAULT_CUR_TIME_CONST_CHNL_Z9 ", "FAULT_CUR_TIME_CONST_CHNL_Z10", "FAULT_CUR_TIME_CONST_CHNL_Z11" };
        public string[] breakerChOvercurrentTimeValues = { "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8" };
        //
        public string[] breakerChMeasCurTimeNames = { "MEAS_CUR_TIME_CONST_CHNL_Z0 ", "MEAS_CUR_TIME_CONST_CHNL_Z1 ", "MEAS_CUR_TIME_CONST_CHNL_Z2 ", "MEAS_CUR_TIME_CONST_CHNL_Z3 ", "MEAS_CUR_TIME_CONST_CHNL_Z4 ", "MEAS_CUR_TIME_CONST_CHNL_Z5 ", "MEAS_CUR_TIME_CONST_CHNL_Z6 ", "MEAS_CUR_TIME_CONST_CHNL_Z7 ", "MEAS_CUR_TIME_CONST_CHNL_Z8 ", "MEAS_CUR_TIME_CONST_CHNL_Z9 ", "MEAS_CUR_TIME_CONST_CHNL_Z10", "MEAS_CUR_TIME_CONST_CHNL_Z11" };
        public string[] breakerChMeasCurTimeValues = { "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8" };
        //
        public string[] breakerChModeNames = { "MODE_CHNL_Z0", "MODE_CHNL_Z1", "MODE_CHNL_Z2", "MODE_CHNL_Z3", "MODE_CHNL_Z4", "MODE_CHNL_Z5", "MODE_CHNL_Z6", "MODE_CHNL_Z7", "MODE_CHNL_Z8", "MODE_CHNL_Z9", "MODE_CHNL_Z10", "MODE_CHNL_Z11" };
        public string[] breakerChModeValues = { "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER", "DRVR_TYPE_BREAKER" };
        //
        public string[] breakerChPairedNames = { "PAIRED_INDEX_CHNL_Z0", "PAIRED_INDEX_CHNL_Z1", "PAIRED_INDEX_CHNL_Z2", "PAIRED_INDEX_CHNL_Z3", "PAIRED_INDEX_CHNL_Z4", "PAIRED_INDEX_CHNL_Z5", "PAIRED_INDEX_CHNL_Z6", "PAIRED_INDEX_CHNL_Z7", "PAIRED_INDEX_CHNL_Z8", "PAIRED_INDEX_CHNL_Z9", "PAIRED_INDEX_CHNL_Z10", "PAIRED_INDEX_CHNL_Z11" };
        public string[] breakerChPairedValues = { "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE" };
        //
        public string[] breakerChIGNNames = { "IGN_SAFETY_EN_CHNL_Z0 ", "IGN_SAFETY_EN_CHNL_Z1 ", "IGN_SAFETY_EN_CHNL_Z2 ", "IGN_SAFETY_EN_CHNL_Z3 ", "IGN_SAFETY_EN_CHNL_Z4 ", "IGN_SAFETY_EN_CHNL_Z5 ", "IGN_SAFETY_EN_CHNL_Z6 ", "IGN_SAFETY_EN_CHNL_Z7 ", "IGN_SAFETY_EN_CHNL_Z8 ", "IGN_SAFETY_EN_CHNL_Z9 ", "IGN_SAFETY_EN_CHNL_Z10", "IGN_SAFETY_EN_CHNL_Z11" };
        public string[] breakerChIGNValues = { "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED" };
        //
        public string[] breakerChParkNames = { "PARK_SAFETY_EN_CHNL_Z0 ", "PARK_SAFETY_EN_CHNL_Z1 ", "PARK_SAFETY_EN_CHNL_Z2 ", "PARK_SAFETY_EN_CHNL_Z3 ", "PARK_SAFETY_EN_CHNL_Z4 ", "PARK_SAFETY_EN_CHNL_Z5 ", "PARK_SAFETY_EN_CHNL_Z6 ", "PARK_SAFETY_EN_CHNL_Z7 ", "PARK_SAFETY_EN_CHNL_Z8 ", "PARK_SAFETY_EN_CHNL_Z9 ", "PARK_SAFETY_EN_CHNL_Z10", "PARK_SAFETY_EN_CHNL_Z11" };
        public string[] breakerChParkValues = { "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED" };
    }
}
