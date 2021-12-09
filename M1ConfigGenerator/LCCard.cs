using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1ConfigGenerator
{
    class LCCard : M1Card
    {
        public LCCard(int argInt)
        {
            //SetTestString(argInt);

            SetCardLetter(Convert.ToString(argInt));
            ChangeConfigName();
            // general
            ChangeAddress(m1ParameterNames);
            // card-specific
            ChangeAddress(lcParameterNames);
            // channels
            ChangeAddress(lcChLockNames);
            ChangeAddress(lcChDirectionNames);
            ChangeAddress(lcChModeNames);
            ChangeAddress(lcChDeadtimeNames);
            ChangeAddress(lcChPairedNames);
            ChangeAddress(lcChPwmEnableNames);
            ChangeAddress(lcChPwmFreqNames);
            ChangeAddress(lcChTimeoutNames);
            ChangeAddress(lcChTimeoutTimeNames);
            ChangeAddress(lcChMaxOnNames);
            ChangeAddress(lcChMaxDurRecoveryTimeNames);
            ChangeAddress(cardChGroup0Names);
            ChangeAddress(cardChGroup1Names);
            ChangeAddress(cardChGroup2Names);
            ChangeAddress(cardChGroup3Names);
            ChangeAddress(lcChOvercurrentAmpsNames);
            ChangeAddress(lcChUndercurrentAmpsNames);
            ChangeAddress(lcChOvercurrentTimeNames);
            ChangeAddress(lcChMeasCurTimeNames);
            ChangeAddress(lcChOverrideReverseNames);
            ChangeAddress(lcChOverrideForwardNames);
            ChangeAddress(lcChIGNNames);
            ChangeAddress(lcChParkNames);
            SetNodeCfg();
        }

        public void CreateLCFile()
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

                // card specific
                for (int i = 0; i < 2; i++)
                {
                    sw.WriteLine("#define " + lcParameterNames[i] + tabs[4] + lcParameterValues[i]);
                }
                sw.WriteLine("");

                // card channels
                for (int i = 0; i < 16; i++)
                {
                    sw.WriteLine("// ### CHANNEL " + Convert.ToString(i) + " ###");
                    sw.WriteLine("#define " + lcChLockNames[i] + tabs[7] + lcChLockValues[i]);
                    sw.WriteLine("#define " + lcChDirectionNames[i] + tabs[6] + lcChDirectionValues[i]);
                    sw.WriteLine("#define " + lcChModeNames[i] + tabs[7] + lcChModeValues[i]);
                    sw.WriteLine("#define " + lcChDeadtimeNames[i] + tabs[6] + lcChDeadtimeValues[i]);
                    sw.WriteLine("#define " + lcChPairedNames[i] + tabs[5] + lcChPairedValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + lcChPwmEnableNames[i] + tabs[6] + lcChPwmEnableValues[i]);
                    sw.WriteLine("#define " + lcChPwmFreqNames[i] + tabs[6] + lcChPwmFreqValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + lcChTimeoutNames[i] + tabs[5] + lcChTimeoutValues[i]);
                    sw.WriteLine("#define " + lcChTimeoutTimeNames[i] + tabs[5] + lcChTimeoutTimeValues[i]);
                    sw.WriteLine("#define " + lcChMaxOnNames[i] + tabs[6] + lcChMaxOnValues[i]);
                    sw.WriteLine("#define " + lcChMaxDurRecoveryTimeNames[i] + tabs[4] + lcChMaxDurRecoveryTimeValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + cardChGroup0Names[i] + tabs[5] + cardChGroup0Values[i]);
                    sw.WriteLine("#define " + cardChGroup1Names[i] + tabs[5] + cardChGroup1Values[i]);
                    sw.WriteLine("#define " + cardChGroup2Names[i] + tabs[5] + cardChGroup2Values[i]);
                    sw.WriteLine("#define " + cardChGroup3Names[i] + tabs[5] + cardChGroup3Values[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + lcChOvercurrentAmpsNames[i] + tabs[5] + "CONVERT_AMPS_TO_ADC(" + lcChOvercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + lcChUndercurrentAmpsNames[i] + tabs[5] + "CONVERT_AMPS_TO_ADC(" + lcChUndercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + lcChOvercurrentTimeNames[i] + tabs[3] + lcChOvercurrentTimeValues[i]);
                    sw.WriteLine("#define " + lcChMeasCurTimeNames[i] + tabs[3] + lcChMeasCurTimeValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + lcChOverrideReverseNames[i] + tabs[3] + lcChOverrideReverseValues[i]);
                    sw.WriteLine("#define " + lcChOverrideForwardNames[i] + tabs[3] + lcChOverrideForwardValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + lcChIGNNames[i] + tabs[5] + lcChIGNValues[i]);
                    sw.WriteLine("#define " + lcChParkNames[i] + tabs[5] + lcChParkValues[i]);
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
            lcChOvercurrentAmpsValues[argInt] = argString;
        }

        public void SetOCTime(int argInt, string argString)
        {
            lcChOvercurrentTimeValues[argInt] = argString;
        }

        public void SetQuickPair(bool argBool, int argInt)
        {
            if (argBool == true)
            {
                lcChModeValues[argInt * 2] = "DRVR_TYPE_H_BRIDGE";
                lcChModeValues[(argInt * 2) + 1] = "DRVR_TYPE_SLAVE";
                string result1 = "PAIRED_TO_CHNL" + Convert.ToString((argInt * 2) + 1);
                lcChPairedValues[argInt * 2] = result1;
                string result2 = "PAIRED_TO_CHNL" + Convert.ToString(argInt * 2);
                lcChPairedValues[(argInt * 2) + 1] = result2;
            }
        }

        private string configPath = @"M1_DcDriver_Config\Src\M1_LC_Bridge\DeviceConfigs\";

        public string[] lcParameterNames =
        {
            "DEVICE_CURRENT_LIMIT_Z     ",
            "DEVICE_OVRCUR_SHUTDN_MSEC_Z"
        };

        public string[] lcParameterValues =
        {
            "17", // overall current limit
            "2000" // device overcurrent shutdown time
        };

        public string[] lcChLockNames = { "LOCK_CHNL_Z0 ", "LOCK_CHNL_Z1 ", "LOCK_CHNL_Z2 ", "LOCK_CHNL_Z3 ", "LOCK_CHNL_Z4 ", "LOCK_CHNL_Z5 ", "LOCK_CHNL_Z6 ", "LOCK_CHNL_Z7 ", 
                                          "LOCK_CHNL_Z8 ", "LOCK_CHNL_Z9 ", "LOCK_CHNL_Z10", "LOCK_CHNL_Z11", "LOCK_CHNL_Z12 ", "LOCK_CHNL_Z13 ", "LOCK_CHNL_Z14", "LOCK_CHNL_Z15" };
        public string[] lcChLockValues = { "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE" };
        //
        public string[] lcChDirectionNames = { "DIRECTION_CHNL_Z0 ", "DIRECTION_CHNL_Z1 ", "DIRECTION_CHNL_Z2 ", "DIRECTION_CHNL_Z3 ", "DIRECTION_CHNL_Z4 ", "DIRECTION_CHNL_Z5 ", "DIRECTION_CHNL_Z6 ", "DIRECTION_CHNL_Z7 ", 
                                             "DIRECTION_CHNL_Z8 ", "DIRECTION_CHNL_Z9 ", "DIRECTION_CHNL_Z10", "DIRECTION_CHNL_Z11", "DIRECTION_CHNL_Z12 ", "DIRECTION_CHNL_Z13 ", "DIRECTION_CHNL_Z14", "DIRECTION_CHNL_Z15" };
        public string[] lcChDirectionValues = { "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF" };
        //
        public string[] lcChModeNames = { "MODE_CHNL_Z0", "MODE_CHNL_Z1", "MODE_CHNL_Z2", "MODE_CHNL_Z3", "MODE_CHNL_Z4", "MODE_CHNL_Z5", "MODE_CHNL_Z6", "MODE_CHNL_Z7", 
                                        "MODE_CHNL_Z8", "MODE_CHNL_Z9", "MODE_CHNL_Z10", "MODE_CHNL_Z11", "MODE_CHNL_Z12", "MODE_CHNL_Z13", "MODE_CHNL_Z14", "MODE_CHNL_Z15" };
        public string[] lcChModeValues = { "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE" };
        //
        public string[] lcChDeadtimeNames = { "DEADTIME_CHNL_Z0", "DEADTIME_CHNL_Z1", "DEADTIME_CHNL_Z2", "DEADTIME_CHNL_Z3", "DEADTIME_CHNL_Z4", "DEADTIME_CHNL_Z5", "DEADTIME_CHNL_Z6", "DEADTIME_CHNL_Z7",
                                            "DEADTIME_CHNL_Z8", "DEADTIME_CHNL_Z9", "DEADTIME_CHNL_Z10", "DEADTIME_CHNL_Z11", "DEADTIME_CHNL_Z12", "DEADTIME_CHNL_Z13", "DEADTIME_CHNL_Z14", "DEADTIME_CHNL_Z15" };
        public string[] lcChDeadtimeValues = { "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500" };
        //
        public string[] lcChPairedNames = { "PAIRED_INDEX_CHNL_Z0", "PAIRED_INDEX_CHNL_Z1", "PAIRED_INDEX_CHNL_Z2", "PAIRED_INDEX_CHNL_Z3", "PAIRED_INDEX_CHNL_Z4", "PAIRED_INDEX_CHNL_Z5", "PAIRED_INDEX_CHNL_Z6", "PAIRED_INDEX_CHNL_Z7",
                                          "PAIRED_INDEX_CHNL_Z8", "PAIRED_INDEX_CHNL_Z9", "PAIRED_INDEX_CHNL_Z10", "PAIRED_INDEX_CHNL_Z11", "PAIRED_INDEX_CHNL_Z12", "PAIRED_INDEX_CHNL_Z13", "PAIRED_INDEX_CHNL_Z14", "PAIRED_INDEX_CHNL_Z15" };
        public string[] lcChPairedValues = { "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE" };
        //
        public string[] lcChPwmEnableNames = { "PWM_ENABLE_CHNL_Z0 ", "PWM_ENABLE_CHNL_Z1 ", "PWM_ENABLE_CHNL_Z2 ", "PWM_ENABLE_CHNL_Z3 ", "PWM_ENABLE_CHNL_Z4 ", "PWM_ENABLE_CHNL_Z5 ", "PWM_ENABLE_CHNL_Z6 ", "PWM_ENABLE_CHNL_Z7 ", 
                                               "PWM_ENABLE_CHNL_Z8 ", "PWM_ENABLE_CHNL_Z9 ", "PWM_ENABLE_CHNL_Z10", "PWM_ENABLE_CHNL_Z11", "PWM_ENABLE_CHNL_Z12 ", "PWM_ENABLE_CHNL_Z13 ", "PWM_ENABLE_CHNL_Z14", "PWM_ENABLE_CHNL_Z15" };
        public string[] lcChPwmEnableValues = { "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE" };
        //
        public string[] lcChPwmFreqNames = { "PWM_FREQ_CHNL_Z0 ", "PWM_FREQ_CHNL_Z1 ", "PWM_FREQ_CHNL_Z2 ", "PWM_FREQ_CHNL_Z3 ", "PWM_FREQ_CHNL_Z4 ", "PWM_FREQ_CHNL_Z5 ", "PWM_FREQ_CHNL_Z6 ", "PWM_FREQ_CHNL_Z7 ", 
                                             "PWM_FREQ_CHNL_Z8 ", "PWM_FREQ_CHNL_Z9 ", "PWM_FREQ_CHNL_Z10", "PWM_FREQ_CHNL_Z11", "PWM_FREQ_CHNL_Z12 ", "PWM_FREQ_CHNL_Z13 ", "PWM_FREQ_CHNL_Z14", "PWM_FREQ_CHNL_Z15" };
        public string[] lcChPwmFreqValues = { "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ", "TLE_FREQ_200HZ" };
        //
        public string[] lcChTimeoutNames = { "CMD_TIMEOUT_CHNL_Z0 ", "CMD_TIMEOUT_CHNL_Z1 ", "CMD_TIMEOUT_CHNL_Z2 ", "CMD_TIMEOUT_CHNL_Z3 ", "CMD_TIMEOUT_CHNL_Z4 ", "CMD_TIMEOUT_CHNL_Z5 ", "CMD_TIMEOUT_CHNL_Z6 ", "CMD_TIMEOUT_CHNL_Z7 ", 
                                             "CMD_TIMEOUT_CHNL_Z8 ", "CMD_TIMEOUT_CHNL_Z9 ", "CMD_TIMEOUT_CHNL_Z10", "CMD_TIMEOUT_CHNL_Z11", "CMD_TIMEOUT_CHNL_Z12 ", "CMD_TIMEOUT_CHNL_Z13 ", "CMD_TIMEOUT_CHNL_Z14", "CMD_TIMEOUT_CHNL_Z15" };
        public string[] lcChTimeoutValues = { "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED" };
        //
        public string[] lcChTimeoutTimeNames = { "CMD_TIMEOUT_MS_CHNL_Z0 ", "CMD_TIMEOUT_MS_CHNL_Z1 ", "CMD_TIMEOUT_MS_CHNL_Z2 ", "CMD_TIMEOUT_MS_CHNL_Z3 ", "CMD_TIMEOUT_MS_CHNL_Z4 ", "CMD_TIMEOUT_MS_CHNL_Z5 ", "CMD_TIMEOUT_MS_CHNL_Z6 ", "CMD_TIMEOUT_MS_CHNL_Z7 ", 
                                                 "CMD_TIMEOUT_MS_CHNL_Z8 ", "CMD_TIMEOUT_MS_CHNL_Z9 ", "CMD_TIMEOUT_MS_CHNL_Z10", "CMD_TIMEOUT_MS_CHNL_Z11", "CMD_TIMEOUT_MS_CHNL_Z12 ", "CMD_TIMEOUT_MS_CHNL_Z13 ", "CMD_TIMEOUT_MS_CHNL_Z14", "CMD_TIMEOUT_MS_CHNL_Z15" };
        public string[] lcChTimeoutTimeValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] lcChMaxOnNames = { "MAX_ON_SEC_CHNL_Z0 ", "MAX_ON_SEC_CHNL_Z1 ", "MAX_ON_SEC_CHNL_Z2 ", "MAX_ON_SEC_CHNL_Z3 ", "MAX_ON_SEC_CHNL_Z4 ", "MAX_ON_SEC_CHNL_Z5 ", "MAX_ON_SEC_CHNL_Z6 ", "MAX_ON_SEC_CHNL_Z7 ", 
                                           "MAX_ON_SEC_CHNL_Z8 ", "MAX_ON_SEC_CHNL_Z9 ", "MAX_ON_SEC_CHNL_Z10", "MAX_ON_SEC_CHNL_Z11", "MAX_ON_SEC_CHNL_Z12 ", "MAX_ON_SEC_CHNL_Z13 ", "MAX_ON_SEC_CHNL_Z14", "MAX_ON_SEC_CHNL_Z15" };
        public string[] lcChMaxOnValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] lcChMaxDurRecoveryTimeNames = { "MAX_DUR_RECOVERY_CHNL_Z0 ", "MAX_DUR_RECOVERY_CHNL_Z1 ", "MAX_DUR_RECOVERY_CHNL_Z2 ", "MAX_DUR_RECOVERY_CHNL_Z3 ", "MAX_DUR_RECOVERY_CHNL_Z4 ", "MAX_DUR_RECOVERY_CHNL_Z5 ", "MAX_DUR_RECOVERY_CHNL_Z6 ", "MAX_DUR_RECOVERY_CHNL_Z7 ", 
                                                        "MAX_DUR_RECOVERY_CHNL_Z8 ", "MAX_DUR_RECOVERY_CHNL_Z9 ", "MAX_DUR_RECOVERY_CHNL_Z10", "MAX_DUR_RECOVERY_CHNL_Z11", "MAX_DUR_RECOVERY_CHNL_Z12 ", "MAX_DUR_RECOVERY_CHNL_Z13 ", "MAX_DUR_RECOVERY_CHNL_Z14", "MAX_DUR_RECOVERY_CHNL_Z15" };
        public string[] lcChMaxDurRecoveryTimeValues = { "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5" };
        //
        public string[] lcChOvercurrentAmpsNames = { "OC_ADC_THRES_CHNL_Z0 ", "OC_ADC_THRES_CHNL_Z1 ", "OC_ADC_THRES_CHNL_Z2 ", "OC_ADC_THRES_CHNL_Z3 ", "OC_ADC_THRES_CHNL_Z4 ", "OC_ADC_THRES_CHNL_Z5 ", "OC_ADC_THRES_CHNL_Z6 ", "OC_ADC_THRES_CHNL_Z7 ", 
                                                     "OC_ADC_THRES_CHNL_Z8 ", "OC_ADC_THRES_CHNL_Z9 ", "OC_ADC_THRES_CHNL_Z10", "OC_ADC_THRES_CHNL_Z11", "OC_ADC_THRES_CHNL_Z12 ", "OC_ADC_THRES_CHNL_Z13 ", "OC_ADC_THRES_CHNL_Z14", "OC_ADC_THRES_CHNL_Z15" };
        public string[] lcChOvercurrentAmpsValues = { "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2" };
        //
        public string[] lcChUndercurrentAmpsNames = { "UC_ADC_THRES_CHNL_Z0 ", "UC_ADC_THRES_CHNL_Z1 ", "UC_ADC_THRES_CHNL_Z2 ", "UC_ADC_THRES_CHNL_Z3 ", "UC_ADC_THRES_CHNL_Z4 ", "UC_ADC_THRES_CHNL_Z5 ", "UC_ADC_THRES_CHNL_Z6 ", "UC_ADC_THRES_CHNL_Z7 ", 
                                                      "UC_ADC_THRES_CHNL_Z8 ", "UC_ADC_THRES_CHNL_Z9 ", "UC_ADC_THRES_CHNL_Z10", "UC_ADC_THRES_CHNL_Z11", "UC_ADC_THRES_CHNL_Z12 ", "UC_ADC_THRES_CHNL_Z13 ", "UC_ADC_THRES_CHNL_Z14", "UC_ADC_THRES_CHNL_Z15" };
        public string[] lcChUndercurrentAmpsValues = { "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1" };
        //
        public string[] lcChOvercurrentTimeNames = { "FAULT_CUR_TIME_CONST_CHNL_Z0 ", "FAULT_CUR_TIME_CONST_CHNL_Z1 ", "FAULT_CUR_TIME_CONST_CHNL_Z2 ", "FAULT_CUR_TIME_CONST_CHNL_Z3 ", "FAULT_CUR_TIME_CONST_CHNL_Z4 ", "FAULT_CUR_TIME_CONST_CHNL_Z5 ", "FAULT_CUR_TIME_CONST_CHNL_Z6 ", "FAULT_CUR_TIME_CONST_CHNL_Z7 ",
                                                     "FAULT_CUR_TIME_CONST_CHNL_Z8 ", "FAULT_CUR_TIME_CONST_CHNL_Z9 ", "FAULT_CUR_TIME_CONST_CHNL_Z10", "FAULT_CUR_TIME_CONST_CHNL_Z11", "FAULT_CUR_TIME_CONST_CHNL_Z12 ", "FAULT_CUR_TIME_CONST_CHNL_Z13 ", "FAULT_CUR_TIME_CONST_CHNL_Z14", "FAULT_CUR_TIME_CONST_CHNL_Z15" };
        public string[] lcChOvercurrentTimeValues = { "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6" };
        //
        public string[] lcChMeasCurTimeNames = { "MEAS_CUR_TIME_CONST_CHNL_Z0 ", "MEAS_CUR_TIME_CONST_CHNL_Z1 ", "MEAS_CUR_TIME_CONST_CHNL_Z2 ", "MEAS_CUR_TIME_CONST_CHNL_Z3 ", "MEAS_CUR_TIME_CONST_CHNL_Z4 ", "MEAS_CUR_TIME_CONST_CHNL_Z5 ", "MEAS_CUR_TIME_CONST_CHNL_Z6 ", "MEAS_CUR_TIME_CONST_CHNL_Z7 ",
                                                 "MEAS_CUR_TIME_CONST_CHNL_Z8 ", "MEAS_CUR_TIME_CONST_CHNL_Z9 ", "MEAS_CUR_TIME_CONST_CHNL_Z10", "MEAS_CUR_TIME_CONST_CHNL_Z11", "MEAS_CUR_TIME_CONST_CHNL_Z12 ", "MEAS_CUR_TIME_CONST_CHNL_Z13 ", "MEAS_CUR_TIME_CONST_CHNL_Z14", "MEAS_CUR_TIME_CONST_CHNL_Z15" };
        public string[] lcChMeasCurTimeValues = { "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8" };
        //
        public string[] lcChOverrideReverseNames = { "OVERRIDE_REVERSE_INPUT_CHNL_Z0 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z1 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z2 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z3 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z4 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z5 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z6 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z7 ",
                                                     "OVERRIDE_REVERSE_INPUT_CHNL_Z8 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z9 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z10", "OVERRIDE_REVERSE_INPUT_CHNL_Z11", "OVERRIDE_REVERSE_INPUT_CHNL_Z12 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z13 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z14", "OVERRIDE_REVERSE_INPUT_CHNL_Z15" };
        public string[] lcChOverrideReverseValues = { "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE" };
        //
        public string[] lcChOverrideForwardNames = { "OVERRIDE_FORWARD_INPUT_CHNL_Z0 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z1 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z2 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z3 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z4 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z5 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z6 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z7 ",
                                                     "OVERRIDE_FORWARD_INPUT_CHNL_Z8 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z9 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z10", "OVERRIDE_FORWARD_INPUT_CHNL_Z11", "OVERRIDE_FORWARD_INPUT_CHNL_Z12 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z13 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z14", "OVERRIDE_FORWARD_INPUT_CHNL_Z15" };
        public string[] lcChOverrideForwardValues = { "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE" };
        //
        public string[] lcChIGNNames = { "IGN_SAFETY_EN_CHNL_Z0 ", "IGN_SAFETY_EN_CHNL_Z1 ", "IGN_SAFETY_EN_CHNL_Z2 ", "IGN_SAFETY_EN_CHNL_Z3 ", "IGN_SAFETY_EN_CHNL_Z4 ", "IGN_SAFETY_EN_CHNL_Z5 ", "IGN_SAFETY_EN_CHNL_Z6 ", "IGN_SAFETY_EN_CHNL_Z7 ",
                                         "IGN_SAFETY_EN_CHNL_Z8 ", "IGN_SAFETY_EN_CHNL_Z9 ", "IGN_SAFETY_EN_CHNL_Z10", "IGN_SAFETY_EN_CHNL_Z11", "IGN_SAFETY_EN_CHNL_Z12 ", "IGN_SAFETY_EN_CHNL_Z13 ", "IGN_SAFETY_EN_CHNL_Z14", "IGN_SAFETY_EN_CHNL_Z15" };
        public string[] lcChIGNValues = { "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED" };
        //
        public string[] lcChParkNames = { "PARK_SAFETY_EN_CHNL_Z0 ", "PARK_SAFETY_EN_CHNL_Z1 ", "PARK_SAFETY_EN_CHNL_Z2 ", "PARK_SAFETY_EN_CHNL_Z3 ", "PARK_SAFETY_EN_CHNL_Z4 ", "PARK_SAFETY_EN_CHNL_Z5 ", "PARK_SAFETY_EN_CHNL_Z6 ", "PARK_SAFETY_EN_CHNL_Z7 ",
                                              "PARK_SAFETY_EN_CHNL_Z8 ", "PARK_SAFETY_EN_CHNL_Z9 ", "PARK_SAFETY_EN_CHNL_Z10", "PARK_SAFETY_EN_CHNL_Z11", "PARK_SAFETY_EN_CHNL_Z12 ", "PARK_SAFETY_EN_CHNL_Z13 ", "PARK_SAFETY_EN_CHNL_Z14", "PARK_SAFETY_EN_CHNL_Z15" };
        public string[] lcChParkValues = { "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED", "DRVR_SAFETY_DISABLED" };
    }
}
