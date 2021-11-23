using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1ConfigGenerator
{
    class DimmerCard : M1Card
    {
        // constructors
        public DimmerCard(int argInt)
        {
            //SetTestString(argInt);

            SetCardLetter(Convert.ToString(argInt));
            ChangeConfigName();
            // general
            ChangeAddress(m1ParameterNames);
            // dimmer-specific
            ChangeAddress(dimmerParameterNames);
            // channels
            ChangeAddress(dimmerChLockNames);
            ChangeAddress(dimmerChPwmFreqNames);
            ChangeAddress(dimmerChPwmDutyNames);
            ChangeAddress(dimmerChPwmEnableNames);
            ChangeAddress(dimmerChOverrideNames);
            ChangeAddress(dimmerChDirectionNames);
            ChangeAddress(dimmerChTimeoutNames);
            ChangeAddress(dimmerChTimeoutTimeNames);
            ChangeAddress(dimmerChMaxOnNames);
            ChangeAddress(dimmerChMaxDurRecoveryTimeNames);
            ChangeAddress(dimmerChOvercurrentAmpsNames);
            ChangeAddress(dimmerChUndercurrentAmpsNames);
            ChangeAddress(dimmerChOvercurrentTimeNames);
            ChangeAddress(dimmerChMeasCurTimeNames);
            ChangeAddress(dimmerChGroup0Names);
            ChangeAddress(dimmerChGroup1Names);
            ChangeAddress(dimmerChGroup2Names);
            ChangeAddress(dimmerChGroup3Names);
            SetNodeCfg();
        }

        // DimmerCard MyDimmerCard { get; set; } // ??

        public void CreateFile()
        {
            using (StreamWriter sw = File.AppendText(@GetConfigPath()))
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

                // dimmer specific
                for (int i = 0; i < 2; i++)
                {
                    sw.WriteLine("#define " + dimmerParameterNames[i] + tabs[4] + dimmerParameterValues[i]);
                }
                sw.WriteLine("");

                // dimmer channels
                for (int i = 0; i < 12; i++)
                {
                    sw.WriteLine("// ### CHANNEL " + Convert.ToString(i) + " ###");
                    sw.WriteLine("#define " + dimmerChLockNames[i] + tabs[7] + dimmerChLockValues[i]);
                    sw.WriteLine("#define " + dimmerChPwmFreqNames[i] + tabs[6] + dimmerChPwmFreqValues[i]);
                    sw.WriteLine("#define " + dimmerChPwmDutyNames[i] + tabs[6] + dimmerChPwmDutyValues[i]);
                    sw.WriteLine("#define " + dimmerChPwmEnableNames[i] + tabs[6] + dimmerChPwmEnableValues[i]);
                    sw.WriteLine("#define " + dimmerChOverrideNames[i] + tabs[4] + dimmerChOverrideValues[i]);
                    sw.WriteLine("#define " + dimmerChDirectionNames[i] + tabs[6] + dimmerChDirectionValues[i]);
                    sw.WriteLine("#define " + dimmerChTimeoutNames[i] + tabs[5] + dimmerChTimeoutValues[i]);
                    sw.WriteLine("#define " + dimmerChTimeoutTimeNames[i] + tabs[5] + dimmerChTimeoutTimeValues[i]);
                    sw.WriteLine("#define " + dimmerChMaxOnNames[i] + tabs[6] + dimmerChMaxOnValues[i]);
                    sw.WriteLine("#define " + dimmerChMaxDurRecoveryTimeNames[i] + tabs[4] + dimmerChMaxDurRecoveryTimeValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + dimmerChOvercurrentAmpsNames[i] + tabs[5] + dimmerChOvercurrentAmpsValues[i]);
                    sw.WriteLine("#define " + dimmerChUndercurrentAmpsNames[i] + tabs[5] + dimmerChUndercurrentAmpsValues[i]);
                    sw.WriteLine("#define " + dimmerChOvercurrentTimeNames[i] + tabs[4] + dimmerChOvercurrentTimeValues[i]);
                    sw.WriteLine("#define " + dimmerChMeasCurTimeNames[i] + tabs[4] + dimmerChMeasCurTimeValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + dimmerChGroup0Names[i] + tabs[5] + dimmerChGroup0Values[i]);
                    sw.WriteLine("#define " + dimmerChGroup1Names[i] + tabs[5] + dimmerChGroup1Values[i]);
                    sw.WriteLine("#define " + dimmerChGroup2Names[i] + tabs[5] + dimmerChGroup2Values[i]);
                    sw.WriteLine("#define " + dimmerChGroup3Names[i] + tabs[5] + dimmerChGroup3Values[i]);
                    sw.WriteLine("");
                }
            }
        }
        
        public void SetOCAmps(int argInt, string argString)
        {
            dimmerChOvercurrentAmpsValues[argInt] = argString;
        }

        public void SetOCTime(int argInt, string argString)
        {
            dimmerChOvercurrentTimeValues[argInt] = argString;
        }

        public void SetGroups(bool[] argArray, int argInt)
        {
            for (int i = 0; i < argArray.Length; i++)
            {

            }
        }
        public void SetGroup0(bool[] argArray, int argInt)
        {
            bool[] newArray = argArray;
            if (argArray.Length > 1)
            {
                newArray = newArray.Skip(1).ToArray();
            }

            if (argArray[0] == true)
            {
                switch (argArray.Length)
                {
                    case 4:
                        dimmerChGroup0Values[argInt] = "MASTER_GROUP_1";
                        SetGroup1(newArray, argInt);
                        break;
                    case 3:
                        dimmerChGroup0Values[argInt] = "MASTER_GROUP_2";
                        SetGroup1(newArray, argInt);
                        break;
                    case 2:
                        dimmerChGroup0Values[argInt] = "MASTER_GROUP_3";
                        SetGroup1(newArray, argInt);
                        break;
                    case 1:
                        dimmerChGroup0Values[argInt] = "MASTER_GROUP_4";
                        break;
                }
            }
            else if (argArray.Length > 1)
            {
                SetGroup0(newArray, argInt);
            }
        }
        public void SetGroup1(bool[] argArray, int argInt)
        {
            bool[] newArray = argArray;
            if (argArray.Length > 1)
            {
                newArray = newArray.Skip(1).ToArray();
            }

            if (argArray[0] == true)
            {
                switch (argArray.Length)
                {
                    case 3:
                        dimmerChGroup1Values[argInt] = "MASTER_GROUP_2";
                        SetGroup2(newArray, argInt);
                        break;
                    case 2:
                        dimmerChGroup1Values[argInt] = "MASTER_GROUP_3";
                        SetGroup2(newArray, argInt);
                        break;
                    case 1:
                        dimmerChGroup1Values[argInt] = "MASTER_GROUP_4";
                        break;
                }
            }
            else if (argArray.Length > 1)
            {
                SetGroup1(newArray, argInt);
            }
        }
        public void SetGroup2(bool[] argArray, int argInt)
        {
            bool[] newArray = argArray;
            if (argArray.Length > 1)
            {
                newArray = newArray.Skip(1).ToArray();

                if (argArray[0] == true)
                {
                    dimmerChGroup2Values[argInt] = "MASTER_GROUP_3";

                    SetGroup3(newArray, argInt);
                }
                else if (argArray[1] == true)
                {
                    dimmerChGroup2Values[argInt] = "MASTER_GROUP_4";
                }
                else
                {
                    SetGroup3(newArray, argInt);
                }
            }
            else if (argArray[0] == true)
            {
                dimmerChGroup2Values[argInt] = "MASTER_GROUP_4";
            }

        }
        public void SetGroup3(bool[] argArray, int argInt)
        {
            if (argArray[0] == true)
            {
                dimmerChGroup3Values[argInt] = "MASTER_GROUP_4";
            }
        }

        public string[] dimmerParameterNames =
        {
            "DEVICE_CURRENT_LIMIT_Z     ",
            "DEVICE_OVRCUR_SHUTDN_MSEC_Z"
        };

        public string[] dimmerParameterValues =
        {
            "45", // overall current limit
            "2000" // device overcurrent shutdown
        };

        public string[] dimmerChLockNames = { "LOCK_CHNL_Z0 ", "LOCK_CHNL_Z1 ", "LOCK_CHNL_Z2 ", "LOCK_CHNL_Z3 ", "LOCK_CHNL_Z4 ", "LOCK_CHNL_Z5 ",
                                                "LOCK_CHNL_Z6 ", "LOCK_CHNL_Z7 ", "LOCK_CHNL_Z8 ", "LOCK_CHNL_Z9 ", "LOCK_CHNL_Z10", "LOCK_CHNL_Z11" };
        public string[] dimmerChLockValues = { "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE" };
        //
        public string[] dimmerChPwmFreqNames = { "PWM_FREQ_CHNL_Z0 ", "PWM_FREQ_CHNL_Z1 ", "PWM_FREQ_CHNL_Z2 ", "PWM_FREQ_CHNL_Z3 ", "PWM_FREQ_CHNL_Z4 ", "PWM_FREQ_CHNL_Z5 ",
                                                "PWM_FREQ_CHNL_Z6 ", "PWM_FREQ_CHNL_Z7 ", "PWM_FREQ_CHNL_Z8 ", "PWM_FREQ_CHNL_Z9 ", "PWM_FREQ_CHNL_Z10", "PWM_FREQ_CHNL_Z11" };
        public string[] dimmerChPwmFreqValues = { "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ", "PWM_400HZ" };
        //
        public string[] dimmerChPwmDutyNames = { "PWM_DUTY_CHNL_Z0 ", "PWM_DUTY_CHNL_Z1 ", "PWM_DUTY_CHNL_Z2 ", "PWM_DUTY_CHNL_Z3 ", "PWM_DUTY_CHNL_Z4 ", "PWM_DUTY_CHNL_Z5 ",
                                                "PWM_DUTY_CHNL_Z6 ", "PWM_DUTY_CHNL_Z7 ", "PWM_DUTY_CHNL_Z8 ", "PWM_DUTY_CHNL_Z9 ", "PWM_DUTY_CHNL_Z10", "PWM_DUTY_CHNL_Z11" };
        public string[] dimmerChPwmDutyValues = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        //
        public string[] dimmerChPwmEnableNames = { "PWM_ENABLE_CHNL_Z0 ", "PWM_ENABLE_CHNL_Z1 ", "PWM_ENABLE_CHNL_Z2 ", "PWM_ENABLE_CHNL_Z3 ", "PWM_ENABLE_CHNL_Z4 ", "PWM_ENABLE_CHNL_Z5 ",
                                                "PWM_ENABLE_CHNL_Z6 ", "PWM_ENABLE_CHNL_Z7 ", "PWM_ENABLE_CHNL_Z8 ", "PWM_ENABLE_CHNL_Z9 ", "PWM_ENABLE_CHNL_Z10", "PWM_ENABLE_CHNL_Z11" };
        public string[] dimmerChPwmEnableValues = { "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE" };
        //
        public string[] dimmerChOverrideNames = { "OVERRIDE_ENABLE_CHNL_Z0 ", "OVERRIDE_ENABLE_CHNL_Z1 ", "OVERRIDE_ENABLE_CHNL_Z2 ", "OVERRIDE_ENABLE_CHNL_Z3 ", "OVERRIDE_ENABLE_CHNL_Z4 ", "OVERRIDE_ENABLE_CHNL_Z5 ",
                                                "OVERRIDE_ENABLE_CHNL_Z6 ", "OVERRIDE_ENABLE_CHNL_Z7 ", "OVERRIDE_ENABLE_CHNL_Z8 ", "OVERRIDE_ENABLE_CHNL_Z9 ", "OVERRIDE_ENABLE_CHNL_Z10", "OVERRIDE_ENABLE_CHNL_Z11" };
        public string[] dimmerChOverrideValues = { "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE" };
        //
        public string[] dimmerChDirectionNames = { "DIRECTION_CHNL_Z0 ", "DIRECTION_CHNL_Z1 ", "DIRECTION_CHNL_Z2 ", "DIRECTION_CHNL_Z3 ", "DIRECTION_CHNL_Z4 ", "DIRECTION_CHNL_Z5 ",
                                                "DIRECTION_CHNL_Z6 ", "DIRECTION_CHNL_Z7 ", "DIRECTION_CHNL_Z8 ", "DIRECTION_CHNL_Z9 ", "DIRECTION_CHNL_Z10", "DIRECTION_CHNL_Z11" };
        public string[] dimmerChDirectionValues = { "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF" };
        //
        public string[] dimmerChTimeoutNames = { "CMD_TIMEOUT_CHNL_Z0 ", "CMD_TIMEOUT_CHNL_Z1 ", "CMD_TIMEOUT_CHNL_Z2 ", "CMD_TIMEOUT_CHNL_Z3 ", "CMD_TIMEOUT_CHNL_Z4 ", "CMD_TIMEOUT_CHNL_Z5 ",
                                                "CMD_TIMEOUT_CHNL_Z6 ", "CMD_TIMEOUT_CHNL_Z7 ", "CMD_TIMEOUT_CHNL_Z8 ", "CMD_TIMEOUT_CHNL_Z9 ", "CMD_TIMEOUT_CHNL_Z10", "CMD_TIMEOUT_CHNL_Z11" };
        public string[] dimmerChTimeoutValues = { "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED" };
        //
        public string[] dimmerChTimeoutTimeNames = { "CMD_TIMEOUT_MS_CHNL_Z0 ", "CMD_TIMEOUT_MS_CHNL_Z1 ", "CMD_TIMEOUT_MS_CHNL_Z2 ", "CMD_TIMEOUT_MS_CHNL_Z3 ", "CMD_TIMEOUT_MS_CHNL_Z4 ", "CMD_TIMEOUT_MS_CHNL_Z5 ",
                                                "CMD_TIMEOUT_MS_CHNL_Z6 ", "CMD_TIMEOUT_MS_CHNL_Z7 ", "CMD_TIMEOUT_MS_CHNL_Z8 ", "CMD_TIMEOUT_MS_CHNL_Z9 ", "CMD_TIMEOUT_MS_CHNL_Z10", "CMD_TIMEOUT_MS_CHNL_Z11" };
        public string[] dimmerChTimeoutTimeValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] dimmerChMaxOnNames = { "MAX_ON_SEC_CHNL_Z0 ", "MAX_ON_SEC_CHNL_Z1 ", "MAX_ON_SEC_CHNL_Z2 ", "MAX_ON_SEC_CHNL_Z3 ", "MAX_ON_SEC_CHNL_Z4 ", "MAX_ON_SEC_CHNL_Z5 ",
                                                "MAX_ON_SEC_CHNL_Z6 ", "MAX_ON_SEC_CHNL_Z7 ", "MAX_ON_SEC_CHNL_Z8 ", "MAX_ON_SEC_CHNL_Z9 ", "MAX_ON_SEC_CHNL_Z10", "MAX_ON_SEC_CHNL_Z11" };
        public string[] dimmerChMaxOnValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] dimmerChMaxDurRecoveryTimeNames = { "MAX_DUR_RECOVERY_CHNL_Z0 ", "MAX_DUR_RECOVERY_CHNL_Z1 ", "MAX_DUR_RECOVERY_CHNL_Z2 ", "MAX_DUR_RECOVERY_CHNL_Z3 ", "MAX_DUR_RECOVERY_CHNL_Z4 ", "MAX_DUR_RECOVERY_CHNL_Z5 ",
                                                "MAX_DUR_RECOVERY_CHNL_Z6 ", "MAX_DUR_RECOVERY_CHNL_Z7 ", "MAX_DUR_RECOVERY_CHNL_Z8 ", "MAX_DUR_RECOVERY_CHNL_Z9 ", "MAX_DUR_RECOVERY_CHNL_Z10", "MAX_DUR_RECOVERY_CHNL_Z11" };
        public string[] dimmerChMaxDurRecoveryTimeValues = { "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5" };
        //
        public string[] dimmerChOvercurrentAmpsNames = { "OVERCUR_THRES_CHNL_Z0 ", "OVERCUR_THRES_CHNL_Z1 ", "OVERCUR_THRES_CHNL_Z2 ", "OVERCUR_THRES_CHNL_Z3 ", "OVERCUR_THRES_CHNL_Z4 ", "OVERCUR_THRES_CHNL_Z5 ",
                                                "OVERCUR_THRES_CHNL_Z6 ", "OVERCUR_THRES_CHNL_Z7 ", "OVERCUR_THRES_CHNL_Z8 ", "OVERCUR_THRES_CHNL_Z9 ", "OVERCUR_THRES_CHNL_Z10", "OVERCUR_THRES_CHNL_Z11" };
        public string[] dimmerChOvercurrentAmpsValues = { "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4" };
        //
        public string[] dimmerChUndercurrentAmpsNames = { "UNDERCUR_THRES_CHNL_Z0 ", "UNDERCUR_THRES_CHNL_Z1 ", "UNDERCUR_THRES_CHNL_Z2 ", "UNDERCUR_THRES_CHNL_Z3 ", "UNDERCUR_THRES_CHNL_Z4 ", "UNDERCUR_THRES_CHNL_Z5 ",
                                                "UNDERCUR_THRES_CHNL_Z6 ", "UNDERCUR_THRES_CHNL_Z7 ", "UNDERCUR_THRES_CHNL_Z8 ", "UNDERCUR_THRES_CHNL_Z9 ", "UNDERCUR_THRES_CHNL_Z10", "UNDERCUR_THRES_CHNL_Z11" };
        public string[] dimmerChUndercurrentAmpsValues = { "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1" };
        //
        public string[] dimmerChOvercurrentTimeNames = { "FAULT_CUR_TCONST_CHNL_Z0 ", "FAULT_CUR_TCONST_CHNL_Z1 ", "FAULT_CUR_TCONST_CHNL_Z2 ", "FAULT_CUR_TCONST_CHNL_Z3 ", "FAULT_CUR_TCONST_CHNL_Z4 ", "FAULT_CUR_TCONST_CHNL_Z5 ",
                                                "FAULT_CUR_TCONST_CHNL_Z6 ", "FAULT_CUR_TCONST_CHNL_Z7 ", "FAULT_CUR_TCONST_CHNL_Z8 ", "FAULT_CUR_TCONST_CHNL_Z9 ", "FAULT_CUR_TCONST_CHNL_Z10", "FAULT_CUR_TCONST_CHNL_Z11" };
        public string[] dimmerChOvercurrentTimeValues = { "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6" };
        //
        public string[] dimmerChMeasCurTimeNames = { "MEAS_CUR_TCONST_CHNL_Z0 ", "MEAS_CUR_TCONST_CHNL_Z1 ", "MEAS_CUR_TCONST_CHNL_Z2 ", "MEAS_CUR_TCONST_CHNL_Z3 ", "MEAS_CUR_TCONST_CHNL_Z4 ", "MEAS_CUR_TCONST_CHNL_Z5 ",
                                                "MEAS_CUR_TCONST_CHNL_Z6 ", "MEAS_CUR_TCONST_CHNL_Z7 ", "MEAS_CUR_TCONST_CHNL_Z8 ", "MEAS_CUR_TCONST_CHNL_Z9 ", "MEAS_CUR_TCONST_CHNL_Z10", "MEAS_CUR_TCONST_CHNL_Z11" };
        public string[] dimmerChMeasCurTimeValues = { "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8" };
        //
        public string[] dimmerChGroup0Names = { "GROUP_INDEX0_CHNL_Z0 ", "GROUP_INDEX0_CHNL_Z1 ", "GROUP_INDEX0_CHNL_Z2 ", "GROUP_INDEX0_CHNL_Z3 ", "GROUP_INDEX0_CHNL_Z4 ", "GROUP_INDEX0_CHNL_Z5 ",
                                                "GROUP_INDEX0_CHNL_Z6 ", "GROUP_INDEX0_CHNL_Z7 ", "GROUP_INDEX0_CHNL_Z8 ", "GROUP_INDEX0_CHNL_Z9 ", "GROUP_INDEX0_CHNL_Z10", "GROUP_INDEX0_CHNL_Z11" };
        public string[] dimmerChGroup0Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };
        //
        public string[] dimmerChGroup1Names = { "GROUP_INDEX1_CHNL_Z0 ", "GROUP_INDEX1_CHNL_Z1 ", "GROUP_INDEX1_CHNL_Z2 ", "GROUP_INDEX1_CHNL_Z3 ", "GROUP_INDEX1_CHNL_Z4 ", "GROUP_INDEX1_CHNL_Z5 ",
                                                "GROUP_INDEX1_CHNL_Z6 ", "GROUP_INDEX1_CHNL_Z7 ", "GROUP_INDEX1_CHNL_Z8 ", "GROUP_INDEX1_CHNL_Z9 ", "GROUP_INDEX1_CHNL_Z10", "GROUP_INDEX1_CHNL_Z11" };
        public string[] dimmerChGroup1Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };
        //
        public string[] dimmerChGroup2Names = { "GROUP_INDEX2_CHNL_Z0 ", "GROUP_INDEX2_CHNL_Z1 ", "GROUP_INDEX2_CHNL_Z2 ", "GROUP_INDEX2_CHNL_Z3 ", "GROUP_INDEX2_CHNL_Z4 ", "GROUP_INDEX2_CHNL_Z5 ",
                                                "GROUP_INDEX2_CHNL_Z6 ", "GROUP_INDEX2_CHNL_Z7 ", "GROUP_INDEX2_CHNL_Z8 ", "GROUP_INDEX2_CHNL_Z9 ", "GROUP_INDEX2_CHNL_Z10", "GROUP_INDEX2_CHNL_Z11" };
        public string[] dimmerChGroup2Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };
        //
        public string[] dimmerChGroup3Names = { "GROUP_INDEX3_CHNL_Z0 ", "GROUP_INDEX3_CHNL_Z1 ", "GROUP_INDEX3_CHNL_Z2 ", "GROUP_INDEX3_CHNL_Z3 ", "GROUP_INDEX3_CHNL_Z4 ", "GROUP_INDEX3_CHNL_Z5 ",
                                                "GROUP_INDEX3_CHNL_Z6 ", "GROUP_INDEX3_CHNL_Z7 ", "GROUP_INDEX3_CHNL_Z8 ", "GROUP_INDEX3_CHNL_Z9 ", "GROUP_INDEX3_CHNL_Z10", "GROUP_INDEX3_CHNL_Z11" };
        public string[] dimmerChGroup3Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };
    }
}
