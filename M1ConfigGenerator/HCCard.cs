using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1ConfigGenerator
{
    class HCCard : M1Card
    {
        public HCCard(int argInt)
        {
            // M1_SetCardLetter(Convert.ToString(argInt));
            M1_ChangeConfigName();
            // general
            M1_ChangeAddress(m1ParameterNames);
            M1_ChangeAddress(hcRGBName);
            // card-specific
            M1_ChangeAddress(hcParameterNames);
            // channels
            M1_ChangeAddress(hcChLockNames);
            M1_ChangeAddress(hcChPwmDutyNames);
            M1_ChangeAddress(hcChDirectionNames);
            M1_ChangeAddress(hcChModeNames);
            M1_ChangeAddress(hcChDeadtimeNames);
            M1_ChangeAddress(hcChPairedNames);
            M1_ChangeAddress(hcChPwmEnableNames);
            M1_ChangeAddress(hcChTimeoutNames);
            M1_ChangeAddress(hcChTimeoutTimeNames);
            M1_ChangeAddress(hcChMaxOnNames);
            M1_ChangeAddress(hcChMaxDurRecoveryTimeNames);
            M1_ChangeAddress(cardChGroup0Names);
            M1_ChangeAddress(cardChGroup1Names);
            M1_ChangeAddress(cardChGroup2Names);
            M1_ChangeAddress(cardChGroup3Names);
            M1_ChangeAddress(hcChOvercurrentAmpsNames);
            M1_ChangeAddress(hcChUndercurrentAmpsNames);
            M1_ChangeAddress(hcChOvercurrentTimeNames);
            M1_ChangeAddress(hcChMeasCurTimeNames);
            M1_ChangeAddress(hcChOverrideReverseNames);
            M1_ChangeAddress(hcChOverrideForwardNames);
            M1_SetNodeCfg();
        }

        public void CreateHCFile()
        {
            using (StreamWriter sw = File.CreateText(@HC_GetConfigPath() + M1_GetConfigName()))
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
                    else if (i == ENABLE_DC_DIMMER_CMD)
                    {
                        sw.WriteLine("#define " + hcRGBName[0] + tabs[3] + hcRGBValue[0]);
                    }
                }

                // card specific
                for (int i = 0; i < 3; i++)
                {
                    if (i == 2)
                    {
                        sw.WriteLine("");
                        sw.WriteLine("// ### TIMER PWM MODULE ###");
                        sw.WriteLine("#define " + hcParameterNames[i] + tabs[4] + hcParameterValues[i]);
                    }
                    else
                    {
                        sw.WriteLine("#define " + hcParameterNames[i] + tabs[4] + hcParameterValues[i]);
                    }
                }
                sw.WriteLine("");

                // card channels
                for (int i = 0; i < 12; i++)
                {
                    sw.WriteLine("// ### CHANNEL " + Convert.ToString(i) + " ###");
                    sw.WriteLine("#define " + hcChLockNames[i] + tabs[7] + hcChLockValues[i]);
                    sw.WriteLine("#define " + hcChPwmDutyNames[i] + tabs[6] + hcChPwmDutyValues[i]);
                    sw.WriteLine("#define " + hcChPwmEnableNames[i] + tabs[6] + hcChPwmEnableValues[i]);
                    sw.WriteLine("#define " + hcChDirectionNames[i] + tabs[6] + hcChDirectionValues[i]);
                    sw.WriteLine("#define " + hcChModeNames[i] + tabs[7] + hcChModeValues[i]);
                    sw.WriteLine("#define " + hcChDeadtimeNames[i] + tabs[6] + hcChDeadtimeValues[i]);
                    sw.WriteLine("#define " + hcChPairedNames[i] + tabs[5] + hcChPairedValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + hcChTimeoutNames[i] + tabs[5] + hcChTimeoutValues[i]);
                    sw.WriteLine("#define " + hcChTimeoutTimeNames[i] + tabs[5] + hcChTimeoutTimeValues[i]);
                    sw.WriteLine("#define " + hcChMaxOnNames[i] + tabs[6] + hcChMaxOnValues[i]);
                    sw.WriteLine("#define " + hcChMaxDurRecoveryTimeNames[i] + tabs[4] + hcChMaxDurRecoveryTimeValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + cardChGroup0Names[i] + tabs[5] + cardChGroup0Values[i]);
                    sw.WriteLine("#define " + cardChGroup1Names[i] + tabs[5] + cardChGroup1Values[i]);
                    sw.WriteLine("#define " + cardChGroup2Names[i] + tabs[5] + cardChGroup2Values[i]);
                    sw.WriteLine("#define " + cardChGroup3Names[i] + tabs[5] + cardChGroup3Values[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + hcChOvercurrentAmpsNames[i] + tabs[5] + "HC_CONVERT_AMPS_TO_ADC(" + hcChOvercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + hcChUndercurrentAmpsNames[i] + tabs[5] + "HC_CONVERT_AMPS_TO_ADC(" + hcChUndercurrentAmpsValues[i] + ")");
                    sw.WriteLine("#define " + hcChOvercurrentTimeNames[i] + tabs[3] + hcChOvercurrentTimeValues[i]);
                    sw.WriteLine("#define " + hcChMeasCurTimeNames[i] + tabs[3] + hcChMeasCurTimeValues[i]);
                    sw.WriteLine("");
                    sw.WriteLine("#define " + hcChOverrideReverseNames[i] + tabs[3] + hcChOverrideReverseValues[i]);
                    sw.WriteLine("#define " + hcChOverrideForwardNames[i] + tabs[3] + hcChOverrideForwardValues[i]);
                    sw.WriteLine("");
                }
            }
        }

        public string HC_GetConfigPath()
        {
            return configPath;
        }

        public void HC_SetRGB(bool enabled)
        {
            hcRGBValue[0] = enabled ? "TRUE" : "FALSE";
        }

        public void HC_SetLock(int argInt, bool argBool)
        {
            hcChLockValues[argInt] = argBool ? "TRUE" : "FALSE";
        }

        public void HC_SetPWMDuty(int argInt, string argString)
        {
            hcChPwmDutyValues[argInt] = argString;
        }
        
        public void HC_SetPWMEnable(int argInt, bool argBool)
        {
            hcChPwmEnableValues[argInt] = argBool ? "TRUE" : "FALSE";
        }

        public void HC_SetDirection(int argInt, string argString)
        {
            hcChDirectionValues[argInt] = "DRVR_STATE_" + argString.ToUpper();
        }

        public void HC_SetMode(int argInt, string argString)
        {
            if (argString == "High" || argString == "Low") { hcChModeValues[argInt] = "DRVR_TYPE_" + argString.ToUpper() + "_SIDE"; }
            else if (argString == "Half Br") { hcChModeValues[argInt] = "DRVR_TYPE_HALF_BRIDGE"; }
            else if (argString == "H Br") { hcChModeValues[argInt] = "DRVR_TYPE_H_BRIDGE"; }
            else { hcChModeValues[argInt] = "DRVR_TYPE_" + argString.ToUpper(); }
        }

        public void HC_SetDeadTime(int argInt, string argString)
        {
            hcChDeadtimeValues[argInt] = argString;
        }

        public void HC_SetPaired(int argInt, string argString)
        {
            if (argString == "None") { hcChPairedValues[argInt] = "NO_SLAVE"; }
            else { hcChPairedValues[argInt] = "PAIRED_TO_CHNL_" + argString.ToUpper(); }
        }

        public void HC_SetTimeout(int argInt, bool argBool)
        {
            hcChTimeoutValues[argInt] = argBool ? "DRVR_TIMEOUT_ENABLED" : "DRVR_TIMEOUT_DISABLED";
        }

        public void HC_SetTimeoutTime(int argInt, string argString)
        {
            hcChTimeoutTimeValues[argInt]= "0x" + argString;
        }

        public void HC_SetMaxOn(int argInt, string argString)
        {
            hcChMaxOnValues[argInt] = "0x" + argString;
        }

        public void HC_SetOCAmps(int argIndex, string argAmps)
        {
            // Values array only stores number, HC_CONVERT_AMPS_TO_ADC formatting added in print function
            hcChOvercurrentAmpsValues[argIndex] = argAmps; 
        }

        public void HC_SetMaxDurRec(int argInt, string argString)
        {
            hcChMaxDurRecoveryTimeValues[argInt] = argString;
        }

        public void HC_SetUndAmp(int argInt, string argString)
        {
            // Values array only stores number, HC_CONVERT_AMPS_TO_ADC formatting added in print function
            hcChUndercurrentAmpsValues[argInt] = argString;
        }

        public void HC_SetOCTime(int argIndex, string argString)
        {
            hcChOvercurrentTimeValues[argIndex] = argString;
        }

        public void HC_SetMeasCurTime(int argInt, string argString)
        {
            hcChMeasCurTimeValues[argInt] = argString;
        }

        // No setters for forward or reverse override at this time
        
        private string configPath = @"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\";

        public string[] hcRGBName = { "ENABLE_DC_DIMMER_RGB_CMD_ADDR_Z" };

        public string[] hcRGBValue = { "FALSE" };

        public string[] hcParameterNames =
        {
            "DEVICE_CURRENT_LIMIT_Z     ",
            "DEVICE_OVRCUR_SHUTDN_MSEC_Z",
            "TIMER_PWM_FREQ             "
        };

        public string[] hcParameterValues =
        {
            "60", // overall current limit
            "2000", // device overcurrent shutdown time
            "PWM_400HZ"
        };

        public string[] hcChLockNames = { "LOCK_CHNL_Z0 ", "LOCK_CHNL_Z1 ", "LOCK_CHNL_Z2 ", "LOCK_CHNL_Z3 ", "LOCK_CHNL_Z4 ", "LOCK_CHNL_Z5 ", "LOCK_CHNL_Z6 ", "LOCK_CHNL_Z7 ", "LOCK_CHNL_Z8 ", "LOCK_CHNL_Z9 ", "LOCK_CHNL_Z10", "LOCK_CHNL_Z11" };
        public string[] hcChLockValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChPwmDutyNames = { "PWM_DUTY_CHNL_Z0 ", "PWM_DUTY_CHNL_Z1 ", "PWM_DUTY_CHNL_Z2 ", "PWM_DUTY_CHNL_Z3 ", "PWM_DUTY_CHNL_Z4 ", "PWM_DUTY_CHNL_Z5 ", "PWM_DUTY_CHNL_Z6 ", "PWM_DUTY_CHNL_Z7 ", "PWM_DUTY_CHNL_Z8 ", "PWM_DUTY_CHNL_Z9 ", "PWM_DUTY_CHNL_Z10", "PWM_DUTY_CHNL_Z11" };
        public string[] hcChPwmDutyValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChPwmEnableNames = { "PWM_ENABLE_CHNL_Z0 ", "PWM_ENABLE_CHNL_Z1 ", "PWM_ENABLE_CHNL_Z2 ", "PWM_ENABLE_CHNL_Z3 ", "PWM_ENABLE_CHNL_Z4 ", "PWM_ENABLE_CHNL_Z5 ", "PWM_ENABLE_CHNL_Z6 ", "PWM_ENABLE_CHNL_Z7 ", "PWM_ENABLE_CHNL_Z8 ", "PWM_ENABLE_CHNL_Z9 ", "PWM_ENABLE_CHNL_Z10", "PWM_ENABLE_CHNL_Z11", "PWM_ENABLE_CHNL_Z12 ", "PWM_ENABLE_CHNL_Z13 ", "PWM_ENABLE_CHNL_Z14", "PWM_ENABLE_CHNL_Z15" };
        public string[] hcChPwmEnableValues = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChDirectionNames = { "DIRECTION_CHNL_Z0 ", "DIRECTION_CHNL_Z1 ", "DIRECTION_CHNL_Z2 ", "DIRECTION_CHNL_Z3 ", "DIRECTION_CHNL_Z4 ", "DIRECTION_CHNL_Z5 ", "DIRECTION_CHNL_Z6 ", "DIRECTION_CHNL_Z7 ", "DIRECTION_CHNL_Z8 ", "DIRECTION_CHNL_Z9 ", "DIRECTION_CHNL_Z10", "DIRECTION_CHNL_Z11" };
        public string[] hcChDirectionValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChModeNames = { "MODE_CHNL_Z0", "MODE_CHNL_Z1", "MODE_CHNL_Z2", "MODE_CHNL_Z3", "MODE_CHNL_Z4", "MODE_CHNL_Z5", "MODE_CHNL_Z6", "MODE_CHNL_Z7", "MODE_CHNL_Z8", "MODE_CHNL_Z9", "MODE_CHNL_Z10", "MODE_CHNL_Z11" };
        public string[] hcChModeValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChDeadtimeNames = { "DEADTIME_CHNL_Z0", "DEADTIME_CHNL_Z1", "DEADTIME_CHNL_Z2", "DEADTIME_CHNL_Z3", "DEADTIME_CHNL_Z4", "DEADTIME_CHNL_Z5", "DEADTIME_CHNL_Z6", "DEADTIME_CHNL_Z7", "DEADTIME_CHNL_Z8", "DEADTIME_CHNL_Z9", "DEADTIME_CHNL_Z10", "DEADTIME_CHNL_Z11" };
        public string[] hcChDeadtimeValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChPairedNames = { "PAIRED_INDEX_CHNL_Z0", "PAIRED_INDEX_CHNL_Z1", "PAIRED_INDEX_CHNL_Z2", "PAIRED_INDEX_CHNL_Z3", "PAIRED_INDEX_CHNL_Z4", "PAIRED_INDEX_CHNL_Z5", "PAIRED_INDEX_CHNL_Z6", "PAIRED_INDEX_CHNL_Z7", "PAIRED_INDEX_CHNL_Z8", "PAIRED_INDEX_CHNL_Z9", "PAIRED_INDEX_CHNL_Z10", "PAIRED_INDEX_CHNL_Z11" };
        public string[] hcChPairedValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChTimeoutNames = { "CMD_TIMEOUT_CHNL_Z0 ", "CMD_TIMEOUT_CHNL_Z1 ", "CMD_TIMEOUT_CHNL_Z2 ", "CMD_TIMEOUT_CHNL_Z3 ", "CMD_TIMEOUT_CHNL_Z4 ", "CMD_TIMEOUT_CHNL_Z5 ", "CMD_TIMEOUT_CHNL_Z6 ", "CMD_TIMEOUT_CHNL_Z7 ", "CMD_TIMEOUT_CHNL_Z8 ", "CMD_TIMEOUT_CHNL_Z9 ", "CMD_TIMEOUT_CHNL_Z10", "CMD_TIMEOUT_CHNL_Z11" };
        public string[] hcChTimeoutValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChTimeoutTimeNames = { "CMD_TIMEOUT_MS_CHNL_Z0 ", "CMD_TIMEOUT_MS_CHNL_Z1 ", "CMD_TIMEOUT_MS_CHNL_Z2 ", "CMD_TIMEOUT_MS_CHNL_Z3 ", "CMD_TIMEOUT_MS_CHNL_Z4 ", "CMD_TIMEOUT_MS_CHNL_Z5 ", "CMD_TIMEOUT_MS_CHNL_Z6 ", "CMD_TIMEOUT_MS_CHNL_Z7 ", "CMD_TIMEOUT_MS_CHNL_Z8 ", "CMD_TIMEOUT_MS_CHNL_Z9 ", "CMD_TIMEOUT_MS_CHNL_Z10", "CMD_TIMEOUT_MS_CHNL_Z11" };
        public string[] hcChTimeoutTimeValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChMaxOnNames = { "MAX_ON_SEC_CHNL_Z0 ", "MAX_ON_SEC_CHNL_Z1 ", "MAX_ON_SEC_CHNL_Z2 ", "MAX_ON_SEC_CHNL_Z3 ", "MAX_ON_SEC_CHNL_Z4 ", "MAX_ON_SEC_CHNL_Z5 ", "MAX_ON_SEC_CHNL_Z6 ", "MAX_ON_SEC_CHNL_Z7 ", "MAX_ON_SEC_CHNL_Z8 ", "MAX_ON_SEC_CHNL_Z9 ", "MAX_ON_SEC_CHNL_Z10", "MAX_ON_SEC_CHNL_Z11" };
        public string[] hcChMaxOnValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChMaxDurRecoveryTimeNames = { "MAX_DUR_RECOVERY_CHNL_Z0 ", "MAX_DUR_RECOVERY_CHNL_Z1 ", "MAX_DUR_RECOVERY_CHNL_Z2 ", "MAX_DUR_RECOVERY_CHNL_Z3 ", "MAX_DUR_RECOVERY_CHNL_Z4 ", "MAX_DUR_RECOVERY_CHNL_Z5 ", "MAX_DUR_RECOVERY_CHNL_Z6 ", "MAX_DUR_RECOVERY_CHNL_Z7 ", "MAX_DUR_RECOVERY_CHNL_Z8 ", "MAX_DUR_RECOVERY_CHNL_Z9 ", "MAX_DUR_RECOVERY_CHNL_Z10", "MAX_DUR_RECOVERY_CHNL_Z11" };
        public string[] hcChMaxDurRecoveryTimeValues = { "", "", "", "", "", "", "", "", "", "", "", "" };

        public string[] hcChOvercurrentAmpsNames = { "OC_ADC_THRESH_CHNL_Z0 ", "OC_ADC_THRESH_CHNL_Z1 ", "OC_ADC_THRESH_CHNL_Z2 ", "OC_ADC_THRESH_CHNL_Z3 ", "OC_ADC_THRESH_CHNL_Z4 ", "OC_ADC_THRESH_CHNL_Z5 ", "OC_ADC_THRESH_CHNL_Z6 ", "OC_ADC_THRESH_CHNL_Z7 ", "OC_ADC_THRESH_CHNL_Z8 ", "OC_ADC_THRESH_CHNL_Z9 ", "OC_ADC_THRESH_CHNL_Z10", "OC_ADC_THRESH_CHNL_Z11" };
        public string[] hcChOvercurrentAmpsValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChUndercurrentAmpsNames = { "UC_ADC_THRESH_CHNL_Z0 ", "UC_ADC_THRESH_CHNL_Z1 ", "UC_ADC_THRESH_CHNL_Z2 ", "UC_ADC_THRESH_CHNL_Z3 ", "UC_ADC_THRESH_CHNL_Z4 ", "UC_ADC_THRESH_CHNL_Z5 ", "UC_ADC_THRESH_CHNL_Z6 ", "UC_ADC_THRESH_CHNL_Z7 ", "UC_ADC_THRESH_CHNL_Z8 ", "UC_ADC_THRESH_CHNL_Z9 ", "UC_ADC_THRESH_CHNL_Z10", "UC_ADC_THRESH_CHNL_Z11" };
        public string[] hcChUndercurrentAmpsValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChOvercurrentTimeNames = { "FAULT_CUR_TIME_CONST_CHNL_Z0 ", "FAULT_CUR_TIME_CONST_CHNL_Z1 ", "FAULT_CUR_TIME_CONST_CHNL_Z2 ", "FAULT_CUR_TIME_CONST_CHNL_Z3 ", "FAULT_CUR_TIME_CONST_CHNL_Z4 ", "FAULT_CUR_TIME_CONST_CHNL_Z5 ", "FAULT_CUR_TIME_CONST_CHNL_Z6 ", "FAULT_CUR_TIME_CONST_CHNL_Z7 ", "FAULT_CUR_TIME_CONST_CHNL_Z8 ", "FAULT_CUR_TIME_CONST_CHNL_Z9 ", "FAULT_CUR_TIME_CONST_CHNL_Z10", "FAULT_CUR_TIME_CONST_CHNL_Z11" };
        public string[] hcChOvercurrentTimeValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChMeasCurTimeNames = { "MEAS_CUR_TIME_CONST_CHNL_Z0 ", "MEAS_CUR_TIME_CONST_CHNL_Z1 ", "MEAS_CUR_TIME_CONST_CHNL_Z2 ", "MEAS_CUR_TIME_CONST_CHNL_Z3 ", "MEAS_CUR_TIME_CONST_CHNL_Z4 ", "MEAS_CUR_TIME_CONST_CHNL_Z5 ", "MEAS_CUR_TIME_CONST_CHNL_Z6 ", "MEAS_CUR_TIME_CONST_CHNL_Z7 ", "MEAS_CUR_TIME_CONST_CHNL_Z8 ", "MEAS_CUR_TIME_CONST_CHNL_Z9 ", "MEAS_CUR_TIME_CONST_CHNL_Z10", "MEAS_CUR_TIME_CONST_CHNL_Z11" };
        public string[] hcChMeasCurTimeValues = { "", "", "", "", "", "", "", "", "", "", "", "" };
        //
        public string[] hcChOverrideReverseNames = { "OVERRIDE_REVERSE_INPUT_CHNL_Z0 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z1 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z2 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z3 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z4 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z5 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z6 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z7 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z8 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z9 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z10", "OVERRIDE_REVERSE_INPUT_CHNL_Z11" };
        public string[] hcChOverrideReverseValues = { "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE" };
        //
        public string[] hcChOverrideForwardNames = { "OVERRIDE_FORWARD_INPUT_CHNL_Z0 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z1 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z2 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z3 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z4 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z5 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z6 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z7 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z8 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z9 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z10", "OVERRIDE_FORWARD_INPUT_CHNL_Z11", "OVERRIDE_FORWARD_INPUT_CHNL_Z12 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z13 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z14", "OVERRIDE_FORWARD_INPUT_CHNL_Z15" };
        public string[] hcChOverrideForwardValues = { "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE" };
    }
}
