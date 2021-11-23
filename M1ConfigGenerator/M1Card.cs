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

        private string configPath = @"M1_DcDriver_Config\Src\M1_Dimmer\DeviceConfigs\";
        private string configName = "DevAddrZ.h";
        private string progVerRev = "1v2d.1";

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
            "BASE_DRIVER_INDEX_ADDR_Z           "  // 13
        };

        public string[] m1ParameterValues =
        {
            "0V1A", // firmware level, should not be changed by program
            "", // card and panel, do not set default
            "", // config rev
            "", // config node (will be auto-filled with parametername[1] value
            "", // config type
            "FALSE", // DC Driver
            "FALSE", // DC Dimmer
            "TRUE", // enable DC Load command; using this status is standard, so must always be true
            "FALSE", // DC Motor
            "FALSE", // Shade
            "FALSE", // force commands
            "0x92", // set to DC Load DSA; using this status is standard so defaults to 0x92
            "0xFF", // driver device instance
            "" // base driver instance, do not default
        };


        // Setters and Getters
        public string GetVerRev()
        {
            return progVerRev;
        }
        public char GetCardLetter()
        {
            return cardLetter;
        }
        public void SetCardLetter(string argString)
        {
            byte[] asciiValue = Encoding.ASCII.GetBytes(argString); // changes string to array of ASCII value numbers
            char character = (char)(asciiValue[0] += 16); // this changes '1' to 'A', '2' to 'B', etc.
            cardLetter = character;
        }
        public void ChangeAddress(string[] argStringArray)
        {
            for (int i = 0; i < argStringArray.Length; i++)
            {
                argStringArray[i] = argStringArray[i].Replace('Z', cardLetter);
            }
        }
        public void ChangeConfigName()
        {
            configName = configName.Replace('Z', cardLetter);
        }
        public string GetConfigPath()
        {
            return configPath + configName;
        }
        public string GetDevAddr()
        {
            return m1ParameterNames[DEV_ADDR];
        }
        public void SetDevAddr(int cardIndex, int panelIndex)
        {
            string trueCard = Convert.ToString(cardIndex);
            string truePanel = Convert.ToString(panelIndex);
            m1ParameterValues[DEV_ADDR] = "(" + trueCard + " + (" + truePanel + " << 3))";
        }
        public void SetCfgRev(string revision)
        {
            m1ParameterValues[DEV_ADDR_CFG_REV] = revision;
        }
        public void SetNodeCfg()
        {
            m1ParameterValues[DEV_ADDR_NODE_CFG] = GetDevAddr();
        }
        public void SetCfgType(string configtype)
        {
            m1ParameterValues[DEV_ADDR_CFG_TYPE] = configtype;
        }
        public void SetBaseIndex(string index)
        {
            m1ParameterValues[BASE_DRIVER_INDEX] = index;
        }
        public void SetDCDriver(bool enabled)
        {
            m1ParameterValues[ENABLE_DC_COMP_DRVR_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void SetDCDimmer(bool enabled)
        {
            m1ParameterValues[ENABLE_DC_DIMMER_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void SetDCMotor(bool enabled)
        {
            m1ParameterValues[ENABLE_DC_MOTOR_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void SetShade(bool enabled)
        {
            m1ParameterValues[ENABLE_WINDOW_SHADE_CMD] = enabled ? "TRUE" : "FALSE";
        }
        public void SetForce(bool enabled)
        {
            m1ParameterValues[ENABLE_FORCE_CMDS] = enabled ? "TRUE" : "FALSE";
        }
    }
}
