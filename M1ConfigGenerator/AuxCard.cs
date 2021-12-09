using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1ConfigGenerator
{
    class AuxCard : M1Card
    {
        public AuxCard(int argInt)
        {
            //SetTestString(argInt);

            SetCardLetter(Convert.ToString(argInt));
            ChangeConfigName();
            // general
            ChangeAddress(m1ParameterNames);
            // channels
            ChangeAddress(auxChLockNames);
            ChangeAddress(auxChDirectionNames);
            ChangeAddress(auxChDeadtimeNames);
            ChangeAddress(auxChPairedNames);
            ChangeAddress(auxChTimeoutNames);
            ChangeAddress(auxChTimeoutTimeNames);
            ChangeAddress(auxChMaxOnNames);
            ChangeAddress(auxChMaxDurRecoveryTimeNames);
            ChangeAddress(cardChGroup0Names);
            ChangeAddress(cardChGroup1Names);
            ChangeAddress(cardChGroup2Names);
            ChangeAddress(cardChGroup3Names);
            SetNodeCfg();
        }

        public void CreateAuxFile()
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

                // card channels
                for (int i = 0; i < 12; i++)
                {
                    sw.WriteLine("// ### CHANNEL " + Convert.ToString(i) + " ###");
                    sw.WriteLine("#define " + auxChLockNames[i] + tabs[7] + auxChLockValues[i]);
                    sw.WriteLine("#define " + auxChDirectionNames[i] + tabs[6] + auxChDirectionValues[i]);
                    sw.WriteLine("#define " + auxChDeadtimeNames[i] + tabs[6] + auxChDeadtimeValues[i]);
                    sw.WriteLine("#define " + auxChPairedNames[i] + tabs[5] + auxChPairedValues[i]);
                    sw.WriteLine("#define " + auxChTimeoutNames[i] + tabs[5] + auxChTimeoutValues[i]);
                    sw.WriteLine("#define " + auxChTimeoutTimeNames[i] + tabs[5] + auxChTimeoutTimeValues[i]);
                    sw.WriteLine("#define " + auxChMaxOnNames[i] + tabs[6] + auxChMaxOnValues[i]);
                    sw.WriteLine("#define " + auxChMaxDurRecoveryTimeNames[i] + tabs[4] + auxChMaxDurRecoveryTimeValues[i]);
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

        public void SetQuickPair(bool argBool, int argInt)
        {
            if (argBool == true)
            {
                string result1 = "PAIRED_TO_CHNL" + Convert.ToString((argInt * 2) + 1);
                auxChPairedValues[argInt * 2] = result1;
                string result2 = "PAIRED_TO_CHNL" + Convert.ToString(argInt * 2);
                auxChPairedValues[(argInt * 2) + 1] = result2;
            }
        }

        private string configPath = @"M1_DcDriver_Config\Src\M1_AuxCard\DeviceConfigs\";

        //
        public string[] auxChLockNames = { "LOCK_CHNL_Z0 ", "LOCK_CHNL_Z1 ", "LOCK_CHNL_Z2 ", "LOCK_CHNL_Z3 ", "LOCK_CHNL_Z4 ", "LOCK_CHNL_Z5 ", "LOCK_CHNL_Z6 ", "LOCK_CHNL_Z7 ", "LOCK_CHNL_Z8 ", "LOCK_CHNL_Z9 ", "LOCK_CHNL_Z10", "LOCK_CHNL_Z11" };
        public string[] auxChLockValues = { "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE", "FALSE" };
        //
        public string[] auxChDirectionNames = { "DIRECTION_CHNL_Z0 ", "DIRECTION_CHNL_Z1 ", "DIRECTION_CHNL_Z2 ", "DIRECTION_CHNL_Z3 ", "DIRECTION_CHNL_Z4 ", "DIRECTION_CHNL_Z5 ", "DIRECTION_CHNL_Z6 ", "DIRECTION_CHNL_Z7 ", "DIRECTION_CHNL_Z8 ", "DIRECTION_CHNL_Z9 ", "DIRECTION_CHNL_Z10", "DIRECTION_CHNL_Z11" };
        public string[] auxChDirectionValues = { "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF", "DRVR_STATE_OFF" };
        //
        public string[] auxChDeadtimeNames = { "DEADTIME_CHNL_Z0", "DEADTIME_CHNL_Z1", "DEADTIME_CHNL_Z2", "DEADTIME_CHNL_Z3", "DEADTIME_CHNL_Z4", "DEADTIME_CHNL_Z5", "DEADTIME_CHNL_Z6", "DEADTIME_CHNL_Z7", "DEADTIME_CHNL_Z8", "DEADTIME_CHNL_Z9", "DEADTIME_CHNL_Z10", "DEADTIME_CHNL_Z11" };
        public string[] auxChDeadtimeValues = { "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500", "500" };
        //
        public string[] auxChPairedNames = { "PAIRED_INDEX_CHNL_Z0", "PAIRED_INDEX_CHNL_Z1", "PAIRED_INDEX_CHNL_Z2", "PAIRED_INDEX_CHNL_Z3", "PAIRED_INDEX_CHNL_Z4", "PAIRED_INDEX_CHNL_Z5", "PAIRED_INDEX_CHNL_Z6", "PAIRED_INDEX_CHNL_Z7", "PAIRED_INDEX_CHNL_Z8", "PAIRED_INDEX_CHNL_Z9", "PAIRED_INDEX_CHNL_Z10", "PAIRED_INDEX_CHNL_Z11" };
        public string[] auxChPairedValues = { "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE", "NO_SLAVE" };
        //
        public string[] auxChTimeoutNames = { "CMD_TIMEOUT_CHNL_Z0 ", "CMD_TIMEOUT_CHNL_Z1 ", "CMD_TIMEOUT_CHNL_Z2 ", "CMD_TIMEOUT_CHNL_Z3 ", "CMD_TIMEOUT_CHNL_Z4 ", "CMD_TIMEOUT_CHNL_Z5 ", "CMD_TIMEOUT_CHNL_Z6 ", "CMD_TIMEOUT_CHNL_Z7 ", "CMD_TIMEOUT_CHNL_Z8 ", "CMD_TIMEOUT_CHNL_Z9 ", "CMD_TIMEOUT_CHNL_Z10", "CMD_TIMEOUT_CHNL_Z11" };
        public string[] auxChTimeoutValues = { "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED", "DRVR_TIMEOUT_DISABLED" };
        //
        public string[] auxChTimeoutTimeNames = { "CMD_TIMEOUT_MS_CHNL_Z0 ", "CMD_TIMEOUT_MS_CHNL_Z1 ", "CMD_TIMEOUT_MS_CHNL_Z2 ", "CMD_TIMEOUT_MS_CHNL_Z3 ", "CMD_TIMEOUT_MS_CHNL_Z4 ", "CMD_TIMEOUT_MS_CHNL_Z5 ", "CMD_TIMEOUT_MS_CHNL_Z6 ", "CMD_TIMEOUT_MS_CHNL_Z7 ", "CMD_TIMEOUT_MS_CHNL_Z8 ", "CMD_TIMEOUT_MS_CHNL_Z9 ", "CMD_TIMEOUT_MS_CHNL_Z10", "CMD_TIMEOUT_MS_CHNL_Z11" };
        public string[] auxChTimeoutTimeValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] auxChMaxOnNames = { "MAX_ON_SEC_CHNL_Z0 ", "MAX_ON_SEC_CHNL_Z1 ", "MAX_ON_SEC_CHNL_Z2 ", "MAX_ON_SEC_CHNL_Z3 ", "MAX_ON_SEC_CHNL_Z4 ", "MAX_ON_SEC_CHNL_Z5 ", "MAX_ON_SEC_CHNL_Z6 ", "MAX_ON_SEC_CHNL_Z7 ", "MAX_ON_SEC_CHNL_Z8 ", "MAX_ON_SEC_CHNL_Z9 ", "MAX_ON_SEC_CHNL_Z10", "MAX_ON_SEC_CHNL_Z11" };
        public string[] auxChMaxOnValues = { "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF", "0xFFFF" };
        //
        public string[] auxChMaxDurRecoveryTimeNames = { "MAX_DUR_RECOVERY_CHNL_Z0 ", "MAX_DUR_RECOVERY_CHNL_Z1 ", "MAX_DUR_RECOVERY_CHNL_Z2 ", "MAX_DUR_RECOVERY_CHNL_Z3 ", "MAX_DUR_RECOVERY_CHNL_Z4 ", "MAX_DUR_RECOVERY_CHNL_Z5 ", "MAX_DUR_RECOVERY_CHNL_Z6 ", "MAX_DUR_RECOVERY_CHNL_Z7 ", "MAX_DUR_RECOVERY_CHNL_Z8 ", "MAX_DUR_RECOVERY_CHNL_Z9 ", "MAX_DUR_RECOVERY_CHNL_Z10", "MAX_DUR_RECOVERY_CHNL_Z11" };
        public string[] auxChMaxDurRecoveryTimeValues = { "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5" };
    }
}
