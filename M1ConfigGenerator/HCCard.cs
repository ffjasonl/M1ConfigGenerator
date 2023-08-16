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
            SetCardLetter(Convert.ToString(argInt));
            ChangeConfigName();
            // general
            ChangeAddress(m1ParameterNames);
            ChangeAddress(hcRGBName);
            // card-specific
            ChangeAddress(hcParameterNames);
            // channels
            ChangeAddress(hcChLockNames);
            ChangeAddress(hcChPwmDutyNames);
            ChangeAddress(hcChDirectionNames);
            ChangeAddress(hcChModeNames);
            ChangeAddress(hcChDeadtimeNames);
            ChangeAddress(hcChPairedNames);
            ChangeAddress(hcChPwmEnableNames);
            ChangeAddress(hcChTimeoutNames);
            ChangeAddress(hcChTimeoutTimeNames);
            ChangeAddress(hcChMaxOnNames);
            ChangeAddress(hcChMaxDurRecoveryTimeNames);
            ChangeAddress(cardChGroup0Names);
            ChangeAddress(cardChGroup1Names);
            ChangeAddress(cardChGroup2Names);
            ChangeAddress(cardChGroup3Names);
            ChangeAddress(hcChOvercurrentAmpsNames);
            ChangeAddress(hcChUndercurrentAmpsNames);
            ChangeAddress(hcChOvercurrentTimeNames);
            ChangeAddress(hcChMeasCurTimeNames);
            ChangeAddress(hcChOverrideReverseNames);
            ChangeAddress(hcChOverrideForwardNames);
            SetNodeCfg();
        }

        public void CreateHCFile()
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

        public string GetConfigPath()
        {
            return configPath;
        }

        public void SetRGB(bool enabled)
        {
            hcRGBValue[0] = enabled ? "TRUE" : "FALSE";
        }
        public void SetOCAmps(int argIndex, string argAmps)
        {
            hcChOvercurrentAmpsValues[argIndex] = argAmps;
        }

        public void SetOCTime(int argIndex, string argConstant)
        {
            hcChOvercurrentTimeValues[argIndex] = argConstant;
        }

        public void SetPWMDuty(int argInt, string argString)
        {
            hcChPwmDutyValues[argInt] = argString;
        }
        
        public void SetPWMEnable(int argInt, bool argBool)
        {
            hcChPwmEnableValues[argInt] = argBool ? "TRUE" : "FALSE";
        }

        public void SetDirection(int argInt, string argString)
        {
            hcChDirectionValues[argInt] = argString;
        }

        public void SetDeadTime(int argInt, string argString)
        {
            hcChDeadtimeValues[argInt]=argString;
        }

        public void SetPaired(int argInt, string argString)
        {
            hcChPairedValues[argInt]= argString;
        }

        public void SetTimeout(int argInt, bool argBool)
        {
            hcChTimeoutValues[argInt] = argBool ? "TRUE" : "FALSE";
        }

        public void SetTimeoutTime(int argInt, string argString)
        {
            hcChTimeoutTimeValues[argInt]= argString;
        }

        public void SetMaxOn(int argInt, string argString)
        {
            hcChMaxOnValues[argInt] = argString;
        }

        public void SetMaxDurRec(int argInt, string argString)
        {
            hcChMaxDurRecoveryTimeValues[argInt] = argString;
        }

        public void SetUndAmp(int argInt, string argString)
        {
            hcChUndercurrentAmpsValues[argInt] = argString;
        }

        public void SetMeasCurTime(int argInt, string argString)
        {
            hcChMeasCurTimeValues[argInt] = argString;
        }
        

        public void SetModeAndPairing(int argIndex, string argMode, bool argStartup)
        {
            if (argMode == "Ground")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_LOW_SIDE";

                if (argStartup == true)
                {
                    hcChDirectionValues[argIndex] = "DRVR_STATE_LOW";
                }
            }
            else if (argMode == "RP UP")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_H_BRIDGE";
                hcChPairedValues[argIndex] = "PAIRED_TO_CHNL" + Convert.ToString(argIndex + 1);
            }
            else if (argMode == "RP DN")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_SLAVE";
                hcChPairedValues[argIndex] = "PAIRED_TO_CHNL" + Convert.ToString(argIndex - 1);
            }
            else if (argMode == "RGB P")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_RGB";
            }
            else if (argMode == "RGBW P")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_RGBW";
            }
            else if (argMode == "RGB R")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_SLAVE";
                hcChPairedValues[argIndex] = "PAIRED_TO_CHNL" + Convert.ToString(argIndex - 1);
            }
            else if (argMode == "RGB G")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_SLAVE";
                hcChPairedValues[argIndex] = "PAIRED_TO_CHNL" + Convert.ToString(argIndex - 2);
            }
            else if (argMode == "RGB B")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_SLAVE";
                hcChPairedValues[argIndex] = "PAIRED_TO_CHNL" + Convert.ToString(argIndex - 3);
            }
            else if (argMode == "RGB W")
            {
                hcChModeValues[argIndex] = "DRVR_TYPE_SLAVE";
                hcChPairedValues[argIndex] = "PAIRED_TO_CHNL" + Convert.ToString(argIndex - 4);
            }
            else // 12V+
            {
                if (argStartup == true)
                {
                    hcChDirectionValues[argIndex] = "DRVR_STATE_HIGH";
                }

            }
        }

        private void EnablePWM(int argIndex)
        {
            hcChPwmEnableValues[argIndex] = "TRUE";
        }

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
        public string[] hcChLockValues = { "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE" };
        //
        public string[] hcChPwmDutyNames = { "PWM_DUTY_CHNL_Z0 ", "PWM_DUTY_CHNL_Z1 ", "PWM_DUTY_CHNL_Z2 ", "PWM_DUTY_CHNL_Z3 ", "PWM_DUTY_CHNL_Z4 ", "PWM_DUTY_CHNL_Z5 ", "PWM_DUTY_CHNL_Z6 ", "PWM_DUTY_CHNL_Z7 ", "PWM_DUTY_CHNL_Z8 ", "PWM_DUTY_CHNL_Z9 ", "PWM_DUTY_CHNL_Z10", "PWM_DUTY_CHNL_Z11" };
        public string[] hcChPwmDutyValues = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        //
        public string[] hcChPwmEnableNames = { "PWM_ENABLE_CHNL_Z0 ", "PWM_ENABLE_CHNL_Z1 ", "PWM_ENABLE_CHNL_Z2 ", "PWM_ENABLE_CHNL_Z3 ", "PWM_ENABLE_CHNL_Z4 ", "PWM_ENABLE_CHNL_Z5 ", "PWM_ENABLE_CHNL_Z6 ", "PWM_ENABLE_CHNL_Z7 ", "PWM_ENABLE_CHNL_Z8 ", "PWM_ENABLE_CHNL_Z9 ", "PWM_ENABLE_CHNL_Z10", "PWM_ENABLE_CHNL_Z11", "PWM_ENABLE_CHNL_Z12 ", "PWM_ENABLE_CHNL_Z13 ", "PWM_ENABLE_CHNL_Z14", "PWM_ENABLE_CHNL_Z15" };
        public string[] hcChPwmEnableValues = { "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE", "TRUE" };
        //
        public string[] hcChDirectionNames = { "DIRECTION_CHNL_Z0 ", "DIRECTION_CHNL_Z1 ", "DIRECTION_CHNL_Z2 ", "DIRECTION_CHNL_Z3 ", "DIRECTION_CHNL_Z4 ", "DIRECTION_CHNL_Z5 ", "DIRECTION_CHNL_Z6 ", "DIRECTION_CHNL_Z7 ", "DIRECTION_CHNL_Z8 ", "DIRECTION_CHNL_Z9 ", "DIRECTION_CHNL_Z10", "DIRECTION_CHNL_Z11" };
        public string[] hcChDirectionValues = { "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF" };
        //
        public string[] hcChModeNames = { "MODE_CHNL_Z0", "MODE_CHNL_Z1", "MODE_CHNL_Z2", "MODE_CHNL_Z3", "MODE_CHNL_Z4", "MODE_CHNL_Z5", "MODE_CHNL_Z6", "MODE_CHNL_Z7", "MODE_CHNL_Z8", "MODE_CHNL_Z9", "MODE_CHNL_Z10", "MODE_CHNL_Z11" };
        public string[] hcChModeValues = { "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE", "DRVR_TYPE_HIGH_SIDE" };
        //
        public string[] hcChDeadtimeNames = { "DEADTIME_CHNL_Z0", "DEADTIME_CHNL_Z1", "DEADTIME_CHNL_Z2", "DEADTIME_CHNL_Z3", "DEADTIME_CHNL_Z4", "DEADTIME_CHNL_Z5", "DEADTIME_CHNL_Z6", "DEADTIME_CHNL_Z7", "DEADTIME_CHNL_Z8", "DEADTIME_CHNL_Z9", "DEADTIME_CHNL_Z10", "DEADTIME_CHNL_Z11" };
        public string[] hcChDeadtimeValues = { "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500" };
        //
        public string[] hcChPairedNames = { "PAIRED_INDEX_CHNL_Z0", "PAIRED_INDEX_CHNL_Z1", "PAIRED_INDEX_CHNL_Z2", "PAIRED_INDEX_CHNL_Z3", "PAIRED_INDEX_CHNL_Z4", "PAIRED_INDEX_CHNL_Z5", "PAIRED_INDEX_CHNL_Z6", "PAIRED_INDEX_CHNL_Z7", "PAIRED_INDEX_CHNL_Z8", "PAIRED_INDEX_CHNL_Z9", "PAIRED_INDEX_CHNL_Z10", "PAIRED_INDEX_CHNL_Z11" };
        public string[] hcChPairedValues = { "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE" };
        //
        public string[] hcChTimeoutNames = { "CMD_TIMEOUT_CHNL_Z0 ", "CMD_TIMEOUT_CHNL_Z1 ", "CMD_TIMEOUT_CHNL_Z2 ", "CMD_TIMEOUT_CHNL_Z3 ", "CMD_TIMEOUT_CHNL_Z4 ", "CMD_TIMEOUT_CHNL_Z5 ", "CMD_TIMEOUT_CHNL_Z6 ", "CMD_TIMEOUT_CHNL_Z7 ", "CMD_TIMEOUT_CHNL_Z8 ", "CMD_TIMEOUT_CHNL_Z9 ", "CMD_TIMEOUT_CHNL_Z10", "CMD_TIMEOUT_CHNL_Z11" };
        public string[] hcChTimeoutValues = { "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED" };
        //
        public string[] hcChTimeoutTimeNames = { "CMD_TIMEOUT_MS_CHNL_Z0 ", "CMD_TIMEOUT_MS_CHNL_Z1 ", "CMD_TIMEOUT_MS_CHNL_Z2 ", "CMD_TIMEOUT_MS_CHNL_Z3 ", "CMD_TIMEOUT_MS_CHNL_Z4 ", "CMD_TIMEOUT_MS_CHNL_Z5 ", "CMD_TIMEOUT_MS_CHNL_Z6 ", "CMD_TIMEOUT_MS_CHNL_Z7 ", "CMD_TIMEOUT_MS_CHNL_Z8 ", "CMD_TIMEOUT_MS_CHNL_Z9 ", "CMD_TIMEOUT_MS_CHNL_Z10", "CMD_TIMEOUT_MS_CHNL_Z11" };
        public string[] hcChTimeoutTimeValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] hcChMaxOnNames = { "MAX_ON_SEC_CHNL_Z0 ", "MAX_ON_SEC_CHNL_Z1 ", "MAX_ON_SEC_CHNL_Z2 ", "MAX_ON_SEC_CHNL_Z3 ", "MAX_ON_SEC_CHNL_Z4 ", "MAX_ON_SEC_CHNL_Z5 ", "MAX_ON_SEC_CHNL_Z6 ", "MAX_ON_SEC_CHNL_Z7 ", "MAX_ON_SEC_CHNL_Z8 ", "MAX_ON_SEC_CHNL_Z9 ", "MAX_ON_SEC_CHNL_Z10", "MAX_ON_SEC_CHNL_Z11" };
        public string[] hcChMaxOnValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", };
        //
        public string[] hcChMaxDurRecoveryTimeNames = { "MAX_DUR_RECOVERY_CHNL_Z0 ", "MAX_DUR_RECOVERY_CHNL_Z1 ", "MAX_DUR_RECOVERY_CHNL_Z2 ", "MAX_DUR_RECOVERY_CHNL_Z3 ", "MAX_DUR_RECOVERY_CHNL_Z4 ", "MAX_DUR_RECOVERY_CHNL_Z5 ", "MAX_DUR_RECOVERY_CHNL_Z6 ", "MAX_DUR_RECOVERY_CHNL_Z7 ", "MAX_DUR_RECOVERY_CHNL_Z8 ", "MAX_DUR_RECOVERY_CHNL_Z9 ", "MAX_DUR_RECOVERY_CHNL_Z10", "MAX_DUR_RECOVERY_CHNL_Z11" };
        public string[] hcChMaxDurRecoveryTimeValues = { "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5" };
        //
        public string[] hcChOvercurrentAmpsNames = { "OC_ADC_THRESH_CHNL_Z0 ", "OC_ADC_THRESH_CHNL_Z1 ", "OC_ADC_THRESH_CHNL_Z2 ", "OC_ADC_THRESH_CHNL_Z3 ", "OC_ADC_THRESH_CHNL_Z4 ", "OC_ADC_THRESH_CHNL_Z5 ", "OC_ADC_THRESH_CHNL_Z6 ", "OC_ADC_THRESH_CHNL_Z7 ", "OC_ADC_THRESH_CHNL_Z8 ", "OC_ADC_THRESH_CHNL_Z9 ", "OC_ADC_THRESH_CHNL_Z10", "OC_ADC_THRESH_CHNL_Z11" };
        public string[] hcChOvercurrentAmpsValues = { "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10", "10" };
        //
        public string[] hcChUndercurrentAmpsNames = { "UC_ADC_THRESH_CHNL_Z0 ", "UC_ADC_THRESH_CHNL_Z1 ", "UC_ADC_THRESH_CHNL_Z2 ", "UC_ADC_THRESH_CHNL_Z3 ", "UC_ADC_THRESH_CHNL_Z4 ", "UC_ADC_THRESH_CHNL_Z5 ", "UC_ADC_THRESH_CHNL_Z6 ", "UC_ADC_THRESH_CHNL_Z7 ", "UC_ADC_THRESH_CHNL_Z8 ", "UC_ADC_THRESH_CHNL_Z9 ", "UC_ADC_THRESH_CHNL_Z10", "UC_ADC_THRESH_CHNL_Z11" };
        public string[] hcChUndercurrentAmpsValues = { "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1", "0.1" };
        //
        public string[] hcChOvercurrentTimeNames = { "FAULT_CUR_TIME_CONST_CHNL_Z0 ", "FAULT_CUR_TIME_CONST_CHNL_Z1 ", "FAULT_CUR_TIME_CONST_CHNL_Z2 ", "FAULT_CUR_TIME_CONST_CHNL_Z3 ", "FAULT_CUR_TIME_CONST_CHNL_Z4 ", "FAULT_CUR_TIME_CONST_CHNL_Z5 ", "FAULT_CUR_TIME_CONST_CHNL_Z6 ", "FAULT_CUR_TIME_CONST_CHNL_Z7 ", "FAULT_CUR_TIME_CONST_CHNL_Z8 ", "FAULT_CUR_TIME_CONST_CHNL_Z9 ", "FAULT_CUR_TIME_CONST_CHNL_Z10", "FAULT_CUR_TIME_CONST_CHNL_Z11" };
        public string[] hcChOvercurrentTimeValues = { "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6", "6" };
        //
        public string[] hcChMeasCurTimeNames = { "MEAS_CUR_TIME_CONST_CHNL_Z0 ", "MEAS_CUR_TIME_CONST_CHNL_Z1 ", "MEAS_CUR_TIME_CONST_CHNL_Z2 ", "MEAS_CUR_TIME_CONST_CHNL_Z3 ", "MEAS_CUR_TIME_CONST_CHNL_Z4 ", "MEAS_CUR_TIME_CONST_CHNL_Z5 ", "MEAS_CUR_TIME_CONST_CHNL_Z6 ", "MEAS_CUR_TIME_CONST_CHNL_Z7 ", "MEAS_CUR_TIME_CONST_CHNL_Z8 ", "MEAS_CUR_TIME_CONST_CHNL_Z9 ", "MEAS_CUR_TIME_CONST_CHNL_Z10", "MEAS_CUR_TIME_CONST_CHNL_Z11" };
        public string[] hcChMeasCurTimeValues = { "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8", "8" };
        //
        public string[] hcChOverrideReverseNames = { "OVERRIDE_REVERSE_INPUT_CHNL_Z0 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z1 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z2 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z3 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z4 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z5 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z6 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z7 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z8 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z9 ", "OVERRIDE_REVERSE_INPUT_CHNL_Z10", "OVERRIDE_REVERSE_INPUT_CHNL_Z11" };
        public string[] hcChOverrideReverseValues = { "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE" };
        //
        public string[] hcChOverrideForwardNames = { "OVERRIDE_FORWARD_INPUT_CHNL_Z0 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z1 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z2 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z3 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z4 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z5 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z6 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z7 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z8 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z9 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z10", "OVERRIDE_FORWARD_INPUT_CHNL_Z11", "OVERRIDE_FORWARD_INPUT_CHNL_Z12 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z13 ", "OVERRIDE_FORWARD_INPUT_CHNL_Z14", "OVERRIDE_FORWARD_INPUT_CHNL_Z15" };
        public string[] hcChOverrideForwardValues = { "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE", "DISABLE_OVERRIDE" };
    }
}
