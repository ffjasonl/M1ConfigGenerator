using System;
using System.Collections.Generic;
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
            SetCardLetter(Convert.ToString(argInt));
            ChangeConfigName();
            // general
            ChangeAddress(m1ParameterNames);
            // card-specific
            ChangeAddress(vinParameterNames);
            // channels
            ChangeAddress(breakerChDirectionNames);
            ChangeAddress(breakerChOvercurrentAmpsNames);
            ChangeAddress(breakerChUndercurrentAmpsNames);
            ChangeAddress(breakerChOvercurrentTimeNames);
            ChangeAddress(breakerChMeasCurTimeNames);
            ChangeAddress(breakerChModeNames);
            ChangeAddress(breakerChPairedNames);
            ChangeAddress(breakerChIGNNames);
            ChangeAddress(breakerChParkNames);
            ChangeAddress(cardChGroup0Names);
            ChangeAddress(cardChGroup1Names);
            ChangeAddress(cardChGroup2Names);
            ChangeAddress(cardChGroup3Names);
            SetNodeCfg();
        }

        public void CreateBreakerFile()
        {
            using (StreamWriter sw = File.CreateText(@GetConfigPath() + GetConfigName()))
            {
                DateTime currentDateTime = DateTime.Now;
                sw.WriteLine(commentBox);
                sw.WriteLine(commentBox);
                sw.WriteLine(commentBox);
                sw.WriteLine("//");
                sw.WriteLine("//  DEVICE ADDRESS " + GetCardLetter() + " CONFIG");
                sw.WriteLine("//");
                sw.WriteLine("//  This file was auto-generated using the Firefly M1 Config Generator version " + GetVerRev() + " on " + currentDateTime);
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
                    sw.WriteLine("#define " + breakerChOvercurrentAmpsNames[i] + tabs[4] + "BRKR_CONVERT_AMPS_TO_ADC(" + breakerChOvercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + breakerChUndercurrentAmpsNames[i] + tabs[4] + "BRKR_CONVERT_AMPS_TO_ADC(" + breakerChUndercurrentAmpsValues[i] + ")");
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

        public string GetConfigPath()
        {
            return configPath;
        }

        public void SetOCAmps(int argInt, string argString)
        {
            breakerChOvercurrentAmpsValues[argInt] = argString;
        }

        public void SetOCTime(int argInt, string argString)
        {
            breakerChOvercurrentTimeValues[argInt] = argString;
        }

        public void SetInterrupt(int argInt, string argString)
        {
            cardChGroup0Values[argInt] = argString;
        }

        public void SetVINInterrupt(string argString)
        {
            vinParameterValues[4] = argString; // VIN interrupter index
            vinParameterValues[9] = argString; // VIN interrupt group, set to same as index
        }

        public void SetVINOCAmps(string argString)
        {
            vinParameterValues[0] = argString;
        }

        public void SetVINOCTime(string argString)
        {
            vinParameterValues[2] = argString; // average time
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
