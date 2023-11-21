using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1ConfigGenerator
{
    class M1Card
    {
        private char cardLetter = 'Z';

        private string configName = "DevAddrZ.h";
        private string progVerRev = "1v2d.0BETA";

        public const int DEVICE_HEADER_CONFIGURATION_VERSION    = 0;
        public const int DEV_ADDR                               = 1;
        public const int DEV_ADDR_CFG_REV                       = 2;
        public const int DEV_ADDR_NODE_CFG                      = 3;
        public const int DEV_ADDR_CFG_TYPE                      = 4;
        public const int ENABLE_DC_COMP_DRVR_CMD                = 5;
        public const int ENABLE_DC_DIMMER_CMD                   = 6;
        public const int ENABLE_DC_LOAD_CMD                     = 7;
        public const int ENABLE_DC_MOTOR_CMD                    = 8;
        public const int ENABLE_WINDOW_SHADE_CMD                = 9;
        public const int ENABLE_FORCE_CMDS                      = 10;
        public const int DSA_ADDR                               = 11;
        public const int DRIVER_DEVICE_INSTANCE                 = 12;
        public const int BASE_DRIVER_INDEX                      = 13;

        public string[] tabs = { "", "\t", "\t\t", "\t\t\t", "\t\t\t\t", "\t\t\t\t\t", "\t\t\t\t\t\t", "\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t", "\t\t\t\t\t\t\t\t\t" };

        public string commentBox = "//****************************************************************************************************************************************";

        public string[] m1ParameterNames =
        {
            "DEVICE_HEADER_CONFIGURATION_VERSION", // 0
            "DEV_ADDR_Z                         ", // 1
            "DEV_ADDR_Z_CFG_REV                 ", // 2
            "DEV_ADDR_Z_NODE_CFG                ", // 3
            "DEV_ADDR_Z_CFG_TYPE                ", // 4
            "ENABLE_DC_COMP_DRVR_CMD_ADDR_Z     ", // 5
            "ENABLE_DC_DIMMER_CMD_ADDR_Z        ", // 6
            "ENABLE_DC_LOAD_CMD_ADDR_Z          ", // 7
            "ENABLE_DC_MOTOR_CMD_ADDR_Z         ", // 8
            "ENABLE_WINDOW_SHADE_CMD_ADDR_Z     ", // 9
            "ENABLE_FORCE_CMDS_ADDR_Z           ", // 10
            "DSA_ADDR_Z                         ", // 11
            "DRIVER_DEVICE_INSTANCE_ADDR_Z      ", // 12
            "BASE_DRIVER_INDEX_ADDR_Z           ", // 13
        };

        public string[] m1ParameterValues =
        {
            "0V1A", // firmware level, should not be changed by program
            "", // card and panel, do not set default
            "", // config rev
            "", // config node (will be auto-filled with parametername[1] value
            "", // config type
            "TRUE", // DC Driver; enabled by default for overcurrent reset and possibly other overrides
            "FALSE", // DC Dimmer
            "TRUE", // enable DC Load command; using this status is standard, so must always be true
            "FALSE", // DC Motor
            "FALSE", // Shade
            "FALSE", // force commands
            "0x92", // set to DC Load DSA; using this status is standard so defaults to 0x92
            "0xFF", // driver device instance
            "", // base driver instance, do not default
        };

        public string[] cardChGroup0Names = { "GROUP_INDEX0_CHNL_Z0 ", "GROUP_INDEX0_CHNL_Z1 ", "GROUP_INDEX0_CHNL_Z2 ", "GROUP_INDEX0_CHNL_Z3 ", "GROUP_INDEX0_CHNL_Z4 ", "GROUP_INDEX0_CHNL_Z5 ", "GROUP_INDEX0_CHNL_Z6 ", "GROUP_INDEX0_CHNL_Z7 ", 
                                              "GROUP_INDEX0_CHNL_Z8 ", "GROUP_INDEX0_CHNL_Z9 ", "GROUP_INDEX0_CHNL_Z10", "GROUP_INDEX0_CHNL_Z11", "GROUP_INDEX0_CHNL_Z12", "GROUP_INDEX0_CHNL_Z13", "GROUP_INDEX0_CHNL_Z14", "GROUP_INDEX0_CHNL_Z15" };
        public string[] cardChGroup0Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };

        public string[] cardChGroup1Names = { "GROUP_INDEX1_CHNL_Z0 ", "GROUP_INDEX1_CHNL_Z1 ", "GROUP_INDEX1_CHNL_Z2 ", "GROUP_INDEX1_CHNL_Z3 ", "GROUP_INDEX1_CHNL_Z4 ", "GROUP_INDEX1_CHNL_Z5 ", "GROUP_INDEX1_CHNL_Z6 ", "GROUP_INDEX1_CHNL_Z7 ", 
                                              "GROUP_INDEX1_CHNL_Z8 ", "GROUP_INDEX1_CHNL_Z9 ", "GROUP_INDEX1_CHNL_Z10", "GROUP_INDEX1_CHNL_Z11", "GROUP_INDEX1_CHNL_Z12", "GROUP_INDEX1_CHNL_Z13", "GROUP_INDEX1_CHNL_Z14", "GROUP_INDEX1_CHNL_Z15" };
        public string[] cardChGroup1Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };

        public string[] cardChGroup2Names = { "GROUP_INDEX2_CHNL_Z0 ", "GROUP_INDEX2_CHNL_Z1 ", "GROUP_INDEX2_CHNL_Z2 ", "GROUP_INDEX2_CHNL_Z3 ", "GROUP_INDEX2_CHNL_Z4 ", "GROUP_INDEX2_CHNL_Z5 ", "GROUP_INDEX2_CHNL_Z6 ", "GROUP_INDEX2_CHNL_Z7 ", 
                                              "GROUP_INDEX2_CHNL_Z8 ", "GROUP_INDEX2_CHNL_Z9 ", "GROUP_INDEX2_CHNL_Z10", "GROUP_INDEX2_CHNL_Z11", "GROUP_INDEX2_CHNL_Z12", "GROUP_INDEX2_CHNL_Z13", "GROUP_INDEX2_CHNL_Z14", "GROUP_INDEX2_CHNL_Z15" };
        public string[] cardChGroup2Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };

        public string[] cardChGroup3Names = { "GROUP_INDEX3_CHNL_Z0 ", "GROUP_INDEX3_CHNL_Z1 ", "GROUP_INDEX3_CHNL_Z2 ", "GROUP_INDEX3_CHNL_Z3 ", "GROUP_INDEX3_CHNL_Z4 ", "GROUP_INDEX3_CHNL_Z5 ", "GROUP_INDEX3_CHNL_Z6 ", "GROUP_INDEX3_CHNL_Z7 ", 
                                              "GROUP_INDEX3_CHNL_Z8 ", "GROUP_INDEX3_CHNL_Z9 ", "GROUP_INDEX3_CHNL_Z10", "GROUP_INDEX3_CHNL_Z11", "GROUP_INDEX3_CHNL_Z12", "GROUP_INDEX3_CHNL_Z13", "GROUP_INDEX3_CHNL_Z14", "GROUP_INDEX3_CHNL_Z15" };
        public string[] cardChGroup3Values = { "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP", "DISABLE_GROUP" };

        public string M1_GetConfigName()
        {
            return configName;
        }
        public string M1_GetVerRev()
        {
            return progVerRev;
        }
        public char M1_GetCardLetter()
        {
            return cardLetter;
        }
        public void M1_SetCardLetter(string argString)
        {
            cardLetter = argString[0];
        }
        public void M1_OldSetCardLetter(string argString)
        {
            byte[] asciiValue = Encoding.ASCII.GetBytes(argString); // changes string to array of ASCII value numbers
            char character = (char)(asciiValue[0] += 16); // this changes '1' to 'A', '2' to 'B', etc.
            cardLetter = character;
        }
        public void M1_ChangeAddress(string[] argStringArray)
        {
            for (int i = 0; i < argStringArray.Length; i++)
            {
                argStringArray[i] = argStringArray[i].Replace('Z', cardLetter);
            }
        }
        public void M1_ChangeConfigName()
        {
            configName = configName.Replace('Z', cardLetter);
        }
        public string M1_GetDevAddr()
        {
            return m1ParameterNames[DEV_ADDR];
        }
        public void M1_SetDevAddr(int cardIndex, int panelIndex)
        {
            string trueCard = Convert.ToString(cardIndex);
            string truePanel = Convert.ToString(panelIndex);
            m1ParameterValues[DEV_ADDR] = "(" + trueCard + " + (" + truePanel + " << 3))";
        }
        public void M1_SetCfgRev(string revision)
        {
            m1ParameterValues[DEV_ADDR_CFG_REV] = revision;
        }
        public void M1_SetNodeCfg()
        {
            m1ParameterValues[DEV_ADDR_NODE_CFG] = M1_GetDevAddr();
        }
        public void M1_SetCfgType(string configtype)
        {
            m1ParameterValues[DEV_ADDR_CFG_TYPE] = "0x" + configtype;
        }
        public void M1_SetBaseIndex(string index)
        {
            m1ParameterValues[BASE_DRIVER_INDEX] = index;
        }
        public void M1_SetDCDriver(bool enabled)
        {
            m1ParameterValues[ENABLE_DC_COMP_DRVR_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void M1_SetDCDimmer(bool enabled)
        {
            m1ParameterValues[ENABLE_DC_DIMMER_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void M1_SetDCMotor(bool enabled)
        {
            m1ParameterValues[ENABLE_DC_MOTOR_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void M1_SetShade(bool enabled)
        {
            m1ParameterValues[ENABLE_WINDOW_SHADE_CMD] = enabled ? "TRUE" : "FALSE";
        }
        
        public void M1_SetForce(bool enabled)
        {
            m1ParameterValues[ENABLE_FORCE_CMDS] = enabled ? "TRUE" : "FALSE";
        }
        public void M1_SetGroup0(bool[] argArray, int argInt)
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
                        cardChGroup0Values[argInt] = "MASTER_GROUP_1";
                        M1_SetGroup1(newArray, argInt);
                        break;
                    case 3:
                        cardChGroup0Values[argInt] = "MASTER_GROUP_2";
                        M1_SetGroup1(newArray, argInt);
                        break;
                    case 2:
                        cardChGroup0Values[argInt] = "MASTER_GROUP_3";
                        M1_SetGroup1(newArray, argInt);
                        break;
                    case 1:
                        cardChGroup0Values[argInt] = "MASTER_GROUP_4";
                        break;
                }
            }
            else if (argArray.Length > 1)
            {
                M1_SetGroup0(newArray, argInt);
            }
        }
        public void M1_SetGroup1(bool[] argArray, int argInt)
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
                        cardChGroup1Values[argInt] = "MASTER_GROUP_2";
                        M1_SetGroup2(newArray, argInt);
                        break;
                    case 2:
                        cardChGroup1Values[argInt] = "MASTER_GROUP_3";
                        M1_SetGroup2(newArray, argInt);
                        break;
                    case 1:
                        cardChGroup1Values[argInt] = "MASTER_GROUP_4";
                        break;
                }
            }
            else if (argArray.Length > 1)
            {
                M1_SetGroup1(newArray, argInt);
            }
        }
        public void M1_SetGroup2(bool[] argArray, int argInt)
        {
            bool[] newArray = argArray;
            if (argArray.Length > 1)
            {
                newArray = newArray.Skip(1).ToArray();

                if (argArray[0] == true)
                {
                    cardChGroup2Values[argInt] = "MASTER_GROUP_3";

                    M1_SetGroup3(newArray, argInt);
                }
                else if (argArray[1] == true)
                {
                    cardChGroup2Values[argInt] = "MASTER_GROUP_4";
                }
                else
                {
                    M1_SetGroup3(newArray, argInt);
                }
            }
            else if (argArray[0] == true)
            {
                cardChGroup2Values[argInt] = "MASTER_GROUP_4";
            }

        }
        public void M1_SetGroup3(bool[] argArray, int argInt)
        {
            if (argArray[0] == true)
            {
                cardChGroup3Values[argInt] = "MASTER_GROUP_4";
            }
        }

    }
}
