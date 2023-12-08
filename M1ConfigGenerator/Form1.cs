using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace M1ConfigGenerator
{
    public partial class Form1 : Form
    {
        // create global arrays
        Button[] auxBtnArray; Button[] brkBtnArray; Button[] dimBtnArray; Button[] hcBtnArray; Button[] hrBtnArray; Button[] lcBtnArray;

        List<AuxCard> auxObjects = new List<AuxCard>();
        int AuxCardActive;
        ComboBox[] auxCardNum;
        ComboBox[] auxPanelNum;
        TextBox[] auxConfigRev;
        TextBox[] auxConfigType;
        CheckBox[] auxDCDimmer; CheckBox[] auxDCMotor; CheckBox[] auxShade; CheckBox[] auxForce;
        TextBox[] auxBaseInstance;
        bool[] aux1Group00; bool[] aux1Group01; bool[] aux1Group02; bool[] aux1Group03; bool[] aux1Group04; bool[] aux1Group05;
        bool[] aux1Group06; bool[] aux1Group07; bool[] aux1Group08; bool[] aux1Group09; bool[] aux1Group10; bool[] aux1Group11;
        bool[][] aux1Groups;
        bool[] aux1QuickPair; 
        bool[][] auxQuickPairGroups;
        ComboBox[] auxDirections;
        ComboBox[] auxDeadTimes;
        ComboBox[] auxPairedTimes;
        CheckBox[] auxTimeouts;
        TextBox[] auxTimeoutTimes;
        TextBox[] auxMaxOns;
        TextBox[] auxMaxDurRecs;
        
        List<BreakerCard> breakerObjects = new List<BreakerCard>();
        int BrkCardActive;
        ComboBox[] breakerCardNum;
        ComboBox[] breakerPanelNum;
        TextBox[] breakerConfigRev;
        TextBox[] breakerConfigType;
        TextBox[] breakerBaseInstance;
        ComboBox[] breakerVINOCAmps;
        ComboBox[] breakerVINOCTime;
        ComboBox[] breakerVINInterrupt;
        ComboBox[] breakerOCAmps;
        ComboBox[] breakerOCTime;
        ComboBox[] breakerInterrupts;
        ComboBox[] breakerDirections;
        TextBox[] breakerUndercurrents;
        ComboBox[] breakerMeasCurRecs;
        ComboBox[] breakerModes;
        ComboBox[] breakerPairedTimes;
        ComboBox[] breakerIGNs;
        ComboBox[] breakerParks;

        List<DimmerCard> dimmerObjects = new List<DimmerCard>();
        int DimCardActive;
        ComboBox[] dimCardNum;
        ComboBox[] dimPanelNum;
        TextBox[] dimConfigRev;
        TextBox[] dimConfigType;
        CheckBox[] dimDCMotor; CheckBox[] dimShade; CheckBox[] dimForce;
        TextBox[] dimBaseInstance;
        ComboBox[] dimmerOCAmps;
        ComboBox[] dimmerOCTime;
        bool[] dim1Group00; bool[] dim1Group01; bool[] dim1Group02; bool[] dim1Group03; bool[] dim1Group04; bool[] dim1Group05;
        bool[] dim1Group06; bool[] dim1Group07; bool[] dim1Group08; bool[] dim1Group09; bool[] dim1Group10; bool[] dim1Group11;
        bool[][] dim1Groups;
        CheckBox[] dimmerLocks;
        ComboBox[] dimmerPWMFreq;
        TextBox[] dimmerPWMDuties;
        CheckBox[] dimmerPWMEnables;
        CheckBox[] dimmerOverrides;
        ComboBox[] dimmerDirections;
        CheckBox[] dimmerTimeouts;
        TextBox[] dimmerTimeoutTimes;
        TextBox[] dimmerMaxOns;
        TextBox[] dimmerMaxDurRecs;
        TextBox[] dimmerUCAmps;
        ComboBox[] dimmerMeasCurTimes;


        List<HCCard> hcObjects = new List<HCCard>();
        int HCCardActive;
        bool[] hc1Group00; bool[] hc1Group01; bool[] hc1Group02; bool[] hc1Group03; bool[] hc1Group04; bool[] hc1Group05; bool[] hc1Group06; bool[] hc1Group07; bool[] hc1Group08; bool[] hc1Group09; bool[] hc1Group10; bool[] hc1Group11;
        bool[][] hc1Groups;
        ComboBox[] hc1OCAmpsQuick; TextBox[] hcOCAmps; ComboBox[] hcOCTime; ComboBox[] hcModesQuick; ComboBox[] hcStartupQuick; 
        CheckBox[] hcLock; TextBox[] hcPWMDuties; CheckBox[] hcPWMEnables; ComboBox[] hcDirections; ComboBox[] hcModeParam; ComboBox[] hcDeadTimes;
        ComboBox[] hcPaired; CheckBox[] hcTimeouts; TextBox[] hcTimeoutTimes; TextBox[] hcMaxOns; TextBox[] hcMaxDurRec; TextBox[] hcUndAmps; ComboBox[] hcMeasCurTimes;

        List<LCCard> lcObjects = new List<LCCard>();
        int LCCardActive;
        bool[] lc1Group00; bool[] lc1Group01; bool[] lc1Group02; bool[] lc1Group03; bool[] lc1Group04; bool[] lc1Group05; bool[] lc1Group06; bool[] lc1Group07;
        bool[] lc1Group08; bool[] lc1Group09; bool[] lc1Group10; bool[] lc1Group11; bool[] lc1Group12; bool[] lc1Group13; bool[] lc1Group14; bool[] lc1Group15;
        bool[][] lc1Groups;
        ComboBox[] lcCardNum;
        ComboBox[] lcPanelNum;
        TextBox[] lcConfigRev;
        TextBox[] lcConfigType;
        CheckBox[] lcStandalone; CheckBox[] lcDCDimmer; CheckBox[] lcDCMotor; CheckBox[] lcShade; CheckBox[] lcForce; TextBox[] lcBaseInstance;
        ComboBox[] lcOCAmps; ComboBox[] lcOCTime; ComboBox[] lcModes; CheckBox[] lcLocks; ComboBox[] lcDirections; 
        TextBox[] lcTimeoutTimes; TextBox[] lcMaxOns; TextBox[] lcMaxDurRecoveries; TextBox[] lcUCAmps; ComboBox[] lcMeasCurTimes;


        public Form1()
        {
            InitializeComponent();

            Load += new EventHandler(Form1_Load);

            int[] AuxColor = { 83, 52, 129 };
            int[] BreakerColor = { 217, 58, 78 };
            int[] DimmerColor = { 27, 161, 119 };
            int[] HCColor = { 24, 80, 135 };
            int[] LCColor = { 208, 110, 152 };
            HCCardActive = 0;
            PopulateArrays();
        }

        // @Menu --------------------------------------------------------- Menu
        private void HideNavButtons()
        {
            btnMenuAux.Visible = false;
            btnMenuBreaker.Visible = false;
            btnMenuDimmer.Visible = false;
            btnMenuHC.Visible = false;
            btnMenuLC.Visible = false;
        }

        private void ShowNavButton(Button argButton, int aIndex)
        {
            if (aIndex > 0)
            {
                argButton.Visible = true;
            }
        }

        private void btnMenuNew_Click(object sender, EventArgs e)
        {
            ResetStartTab();
            tabControlMain.SelectedIndex = 1;
        }

        private void btnMenuLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuAux_Click(object sender, EventArgs e)
        {
            SetMenuColors(0);
            tabControlMain.SelectedIndex = 2;
            //Aux_GetAll(AuxCardActive);
            AuxCardNavColor(auxBtnArray[AuxCardActive]);
            ShowAuxNav(cmbStartAux.SelectedIndex);
        }

        private void btnMenuBreaker_Click(object sender, EventArgs e)
        {
            SetMenuColors(1);
            tabControlMain.SelectedIndex = 3;
            //Brk_GetAll(BrkCardActive);
            BreakerCardNavColor(brkBtnArray[BrkCardActive]);
            ShowBreakerNav(cmbStartBreaker.SelectedIndex);
        }

        private void btnMenuDimmer_Click(object sender, EventArgs e)
        {
            SetMenuColors(2);
            tabControlMain.SelectedIndex = 4;
            //Dim_GetAll(DimCardActive);
            DimmerCardNavColor(dimBtnArray[DimCardActive]);
            ShowDimmerNav(cmbStartDimmer.SelectedIndex);
        }

        private void btnMenuHC_Click(object sender, EventArgs e)
        {
            SetMenuColors(3);
            tabControlMain.SelectedIndex = 5;
            HC_GetAll(HCCardActive);
            HCCardNavColor(hcBtnArray[HCCardActive]);
            ShowHCNav(cmbStartHC.SelectedIndex);
        }

        private void btnMenuLC_Click(object sender, EventArgs e)
        {
            SetMenuColors(4);
            tabControlMain.SelectedIndex = 6;
            //LC_GetAll(LCCardActive);
            LCCardNavColor(lcBtnArray[LCCardActive]);
            ShowLCNav(cmbStartLC.SelectedIndex);
        }



        private void SetMenuColors(int ButtonNum)
        {
            btnMenuAux.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuBreaker.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuDimmer.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuHC.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuLC.BackColor = Color.FromArgb(255, 20, 20, 20);
;
            switch (ButtonNum)
            {
                case 0:
                    btnMenuAux.BackColor = Color.FromArgb(255, 83, 52, 129);
                    break;

                case 1:
                    btnMenuBreaker.BackColor = Color.FromArgb(255, 217, 58, 78);
                    break;

                case 2:
                    btnMenuDimmer.BackColor = Color.FromArgb(255, 27, 161, 119);
                    break;

                case 3:
                    btnMenuHC.BackColor = Color.FromArgb(255, 24, 80, 135);
                    break;

                case 4:
                    btnMenuLC.BackColor = Color.FromArgb(255, 208, 110, 152);
                    break;
            }
        }

        // @Start Page ------------------------------------------------------------- Start Page
        private void btnStartClose_Click(object sender, EventArgs e)
        {
            HideNavButtons();
            ResetStartTab();
            //auxObjects.RemoveAll(CardExists);
        }

        // trying to figure out some way to delete existing cards, this didn't work
        private static bool CardExists(AuxCard argAuxCard)
        {
            bool cardExists = argAuxCard != null;
            return cardExists;
        }

        private void btnStartCreate_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
            HideNavButtons();
            // for some reason, had to put these in opposite order so they appear correctly in nav bar
            ShowNavButton(btnMenuLC, cmbStartLC.SelectedIndex);
            ShowNavButton(btnMenuHC, cmbStartHC.SelectedIndex);
            ShowNavButton(btnMenuDimmer, cmbStartDimmer.SelectedIndex);
            ShowNavButton(btnMenuBreaker, cmbStartBreaker.SelectedIndex);
            ShowNavButton(btnMenuAux, cmbStartAux.SelectedIndex);

            // create card objects
            for (int i = 0; i < cmbStartAux.SelectedIndex; i++)
            {
                auxObjects.Add(new AuxCard(i + 1));
            }

            for (int i = 0; i < cmbStartBreaker.SelectedIndex; i++)
            {
                breakerObjects.Add(new BreakerCard(i + 1));
            }

            for (int i = 0; i < cmbStartDimmer.SelectedIndex; i++)
            {
                dimmerObjects.Add(new DimmerCard(i + 1));
            }

            for (int i = 0; i < cmbStartHC.SelectedIndex; i++)
            {
                hcObjects.Add(new HCCard(i + 1));
            }

            for (int i = 0; i < cmbStartLC.SelectedIndex; i++)
            {
                lcObjects.Add(new LCCard(i + 1));
            }

            //foreach (TextBox t in auxConfigType) { t.Text = tbxStartCfgType.Text; }

            //foreach (TextBox t in breakerConfigType) { t.Text = tbxStartCfgType.Text; }

            //foreach (TextBox t in dimConfigType) { t.Text = tbxStartCfgType.Text; }

            tbxHC1CfgType.Text = tbxStartCfgType.Text;

            //foreach (TextBox t in lcConfigType) { t.Text = tbxStartCfgType.Text; }
        }

        private void ResetStartTab()
        {
            cmbStartAux.SelectedIndex = 0;
            cmbStartBreaker.SelectedIndex = 0;
            cmbStartDimmer.SelectedIndex = 0;
            cmbStartHC.SelectedIndex = 0;
            cmbStartLC.SelectedIndex = 0;
        }

        private string ChangeChannelLabel(string argString, int argInt)
        {
            string result;
            if (argString == "")
            {
                result = Convert.ToString(argInt);
            }
            else
            {
                result = Convert.ToString(Convert.ToInt16(argString) + argInt);
            }
            return result;
        }

        private void HideComboBox(ComboBox[] argComboBox)
        {
            foreach (ComboBox i in argComboBox)
            {
                i.Visible = false;
            }
        }

        private void ShowComboBox(ComboBox[] argComboBox)
        {
            foreach (ComboBox i in argComboBox)
            {
                i.Visible = true;
            }
        }

        private void tbxStartCfgType_TextChanged(object sender, EventArgs e)
        {
            if (ValidateConfigType(tbxStartCfgType.Text)) { btnStartCreate.Visible = true; }
            else { btnStartCreate.Visible = false; }
        }

        private bool ValidateConfigType(string argString)
        {
            byte[] asciiValue = Encoding.ASCII.GetBytes(argString.ToUpper());
            int total = 0;
            int characters = 0;

            foreach (byte b in asciiValue)
            {
                if ((b >= 48 && b <= 57) || (b >= 65 && b <= 70)) { total += b; } // validates that only legitimate hexadecimal characters are being used
                characters++;
            }

            return ((characters == 4 && total >= 192 && total < 280) ? true : false); // must be 4 digit hex number, but 0xFFFF is not valid
        }


        //   ###    ##     ## ##     ## 
        //  ## ##   ##     ##  ##   ##  
        // ##   ##  ##     ##   ## ##   
        //##     ## ##     ##    ###    
        //######### ##     ##   ## ##   
        //##     ## ##     ##  ##   ##  
        //##     ##  #######  ##     ## 
        //@Aux


        private void btnAuxGenerate_Click(object sender, EventArgs e)
        {
            aux1Group00 = new bool[] { chkAux1MG1Ch00.Checked, chkAux1MG2Ch00.Checked, chkAux1MG3Ch00.Checked, chkAux1MG4Ch00.Checked };
            aux1Group01 = new bool[] { chkAux1MG1Ch01.Checked, chkAux1MG2Ch01.Checked, chkAux1MG3Ch01.Checked, chkAux1MG4Ch01.Checked };
            aux1Group02 = new bool[] { chkAux1MG1Ch02.Checked, chkAux1MG2Ch02.Checked, chkAux1MG3Ch02.Checked, chkAux1MG4Ch02.Checked };
            aux1Group03 = new bool[] { chkAux1MG1Ch03.Checked, chkAux1MG2Ch03.Checked, chkAux1MG3Ch03.Checked, chkAux1MG4Ch03.Checked };
            aux1Group04 = new bool[] { chkAux1MG1Ch04.Checked, chkAux1MG2Ch04.Checked, chkAux1MG3Ch04.Checked, chkAux1MG4Ch04.Checked };
            aux1Group05 = new bool[] { chkAux1MG1Ch05.Checked, chkAux1MG2Ch05.Checked, chkAux1MG3Ch05.Checked, chkAux1MG4Ch05.Checked };
            aux1Group06 = new bool[] { chkAux1MG1Ch06.Checked, chkAux1MG2Ch06.Checked, chkAux1MG3Ch06.Checked, chkAux1MG4Ch06.Checked };
            aux1Group07 = new bool[] { chkAux1MG1Ch07.Checked, chkAux1MG2Ch07.Checked, chkAux1MG3Ch07.Checked, chkAux1MG4Ch07.Checked };
            aux1Group08 = new bool[] { chkAux1MG1Ch08.Checked, chkAux1MG2Ch08.Checked, chkAux1MG3Ch08.Checked, chkAux1MG4Ch08.Checked };
            aux1Group09 = new bool[] { chkAux1MG1Ch09.Checked, chkAux1MG2Ch09.Checked, chkAux1MG3Ch09.Checked, chkAux1MG4Ch09.Checked };
            aux1Group10 = new bool[] { chkAux1MG1Ch10.Checked, chkAux1MG2Ch10.Checked, chkAux1MG3Ch10.Checked, chkAux1MG4Ch10.Checked };
            aux1Group11 = new bool[] { chkAux1MG1Ch11.Checked, chkAux1MG2Ch11.Checked, chkAux1MG3Ch11.Checked, chkAux1MG4Ch11.Checked };
            aux1Groups = new bool[][] { aux1Group00, aux1Group01, aux1Group02, aux1Group03, aux1Group04, aux1Group05, aux1Group06, aux1Group07, aux1Group08, aux1Group09, aux1Group10, aux1Group11 };


            List<bool[][]> auxGroups = new List<bool[][]>();
            auxGroups.Add(aux1Groups);

            aux1QuickPair = new bool[] { chkAux1QuickPair0001.Checked, chkAux1QuickPair0203.Checked, chkAux1QuickPair0405.Checked, chkAux1QuickPair0607.Checked, chkAux1QuickPair0809.Checked, chkAux1QuickPair1011.Checked };
            auxQuickPairGroups = new bool[][] { aux1QuickPair };

            // Aux cards
            for (int card = 0; card < Convert.ToInt16(cmbStartAux.Text); card++)
            {
                //auxObjects[card].M1_SetDevAddr(auxCardNum[card].SelectedIndex, auxPanelNum[card].SelectedIndex);
                auxObjects[card].M1_SetCfgRev(auxConfigRev[card].Text);
                auxObjects[card].M1_SetCfgType(auxConfigType[card].Text);
                auxObjects[card].M1_SetDCDimmer(true); // hard coding for aux card
                auxObjects[card].M1_SetDCMotor(auxDCMotor[card].Checked);
                auxObjects[card].M1_SetShade(auxShade[card].Checked);
                auxObjects[card].M1_SetForce(auxForce[card].Checked);
                auxObjects[card].M1_SetBaseIndex(auxBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    auxObjects[card].M1_SetGroup0(auxGroups[card][channel], channel); // takes care of all 4 groups
                    auxObjects[card].SetDirection(channel, auxDirections[channel].Text);
                    auxObjects[card].SetDeadTime(channel, auxDeadTimes[channel].Text);
                    auxObjects[card].SetPaired(channel, auxPairedTimes[channel].Text);
                    auxObjects[card].SetTimeout(channel, auxTimeouts[channel].Checked);
                    auxObjects[card].SetTimeoutTime(channel, auxTimeoutTimes[channel].Text);
                    auxObjects[card].SetMaxOn(channel, auxMaxOns[channel].Text);
                    auxObjects[card].SetMaxDurRec(channel, auxMaxDurRecs[channel].Text);
                }
            }

            auxObjects.ForEach(auxObjects => auxObjects.CreateAuxFile());
            CreateAuxReferenceFile();
            AuxCardNavColor(btnAuxGenerate);
            tabControlAux.SelectedIndex = 3;
            string[] auxFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_AuxCard\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxAuxGenerated.Lines = auxFiles;
        }

        private void CreateAuxReferenceFile() // card-specific because of the path, which is stored in each card object but isn't related to the Start tab combo box for that card type
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h", "DevAddrE.h", "DevAddrF.h" };

            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_AuxCard\DeviceConfigs\DevAddrConfigs.h"))
            {
                for (int i = 0; i < Convert.ToInt16(cmbStartAux.Text); i++)
                {
                    sw.WriteLine("#include \"" + configNamesReference[i] + "\"");
                }
            }
        }

        private void CheckAuxGenerate()
        {   
            int checkCounter = 0;
            int numAuxCards = Convert.ToInt16(cmbStartAux.Text);

            bool[] checkAux = new bool[] { CheckAux1() };

            for (int i = 0; i < numAuxCards; i++)
            {
                if (checkAux[i] == true)
                {
                    checkCounter++;
                }
            }

            if (checkCounter == numAuxCards)
            {
                btnAuxGenerate.Visible = true;
            }
            else
            {
                btnAuxGenerate.Visible = false;
            }
        }

        private bool CheckAux1()
        {
            return ((cmbAux1CardNum.Text != "") && (cmbAux1PanelNum.Text != "") && (tbxAux1BaseIndex.Text != ""));
        }

        private void btnAuxCard1_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard1);
            tabControlAux.SelectedIndex = 1;
            tabControlAux1QF.SelectedIndex = 0;
        }

        private void btnAuxCard2_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard2);
            tabControlAux.SelectedIndex = 2;
            tabControlAux1QF.SelectedIndex = 0;
        }

        private void btnAuxCard3_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard3);
        }

        private void btnAuxCard4_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard4);
        }

        private void btnAuxCard5_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard5);
        }

        private void btnAuxCard6_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard6);
        }

        private void ShowAuxNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                auxBtnArray[i].Visible = true;
            }
        }

        private void AuxCardNavColor(Button argButton)
        {
            btnAuxCard1.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnAuxCard2.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnAuxCard3.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnAuxCard4.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnAuxCard5.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnAuxCard6.BackColor = Color.FromArgb(255, 20, 20, 20);
            argButton.BackColor = Color.FromArgb(255, 83, 52, 129);
        }

        private void cmbAux1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAuxGenerate();
        }

        private void cmbAux1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAuxGenerate();
        }

        private void cmbAux2CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAuxGenerate();
        }

        private void cmbAux2PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAuxGenerate();
        }

        private void tbxAux1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblAux1Ch00.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 0);
            lblAux1Ch01.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 1);
            lblAux1Ch02.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 2);
            lblAux1Ch03.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 3);
            lblAux1Ch04.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 4);
            lblAux1Ch05.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 5);
            lblAux1Ch06.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 6);
            lblAux1Ch07.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 7);
            lblAux1Ch08.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 8);
            lblAux1Ch09.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 9);
            lblAux1Ch10.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 10);
            lblAux1Ch11.Text = ChangeChannelLabel(tbxAux1BaseIndex.Text, 11);
            CheckAuxGenerate();
        }


        //########  ########  ########    ###    ##    ## ######## ########  
        //##     ## ##     ## ##         ## ##   ##   ##  ##       ##     ## 
        //##     ## ##     ## ##        ##   ##  ##  ##   ##       ##     ## 
        //########  ########  ######   ##     ## #####    ######   ########  
        //##     ## ##   ##   ##       ######### ##  ##   ##       ##   ##   
        //##     ## ##    ##  ##       ##     ## ##   ##  ##       ##    ##  
        //########  ##     ## ######## ##     ## ##    ## ######## ##     ## 
        //@Breaker

        private void btnBreakerGenerate_Click(object sender, EventArgs e)
        {
            for (int card = 0; card < Convert.ToInt16(cmbStartBreaker.Text); card++)
            {
                //breakerObjects[card].M1_SetDevAddr(breakerCardNum[card].SelectedIndex, breakerPanelNum[card].SelectedIndex);
                breakerObjects[card].M1_SetCfgRev(breakerConfigRev[card].Text);
                breakerObjects[card].M1_SetCfgType(breakerConfigType[card].Text);
                breakerObjects[card].M1_SetDCDriver(true); // hard-coded because these commands are needed for overcurrent reset
                breakerObjects[card].M1_SetForce(true); // hard-coded in case we want to use the interrupt commands (I think)
                breakerObjects[card].M1_SetBaseIndex(breakerBaseInstance[card].Text);
                breakerObjects[card].SetVINOCAmps(breakerVINOCAmps[card].Text);
                breakerObjects[card].SetVINOCTime(breakerVINOCTime[card].Text);
                breakerObjects[card].SetVINInterrupt(breakerVINInterrupt[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    breakerObjects[card].SetOCAmps(channel, breakerOCAmps[channel].Text);
                    breakerObjects[card].SetOCTime(channel, breakerOCTime[channel].Text);
                    breakerObjects[card].SetInterrupt(channel, breakerInterrupts[channel].Text); 
                }
            }

            breakerObjects.ForEach(breakerObjects => breakerObjects.CreateBreakerFile());
            CreateBreakerReferenceFile();
            BreakerCardNavColor(btnBreakerGenerate);
            tabControlBreaker.SelectedIndex = 5;
            string[] breakerFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_Breaker\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxBreakerGenerated.Lines = breakerFiles;
        }

        private void CreateBreakerReferenceFile() // card-specific because of the path, which is stored in each card object but isn't related to the Start tab combo box for that card type
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h" };

            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_Breaker\DeviceConfigs\DevAddrConfigs.h"))
            {
                for (int i = 0; i < Convert.ToInt16(cmbStartBreaker.Text); i++)
                {
                    sw.WriteLine("#include \"" + configNamesReference[i] + "\"");
                }
            }
        }

        private void chkBreaker1MatchVIN_CheckStateChanged(object sender, EventArgs e)
        {
            //foreach (ComboBox i in breaker1Interrupt)
            //{
            //    i.SelectedIndex = cmbBreaker1InterruptVIN.SelectedIndex;
            //}
        }

        private void CheckBreakerGenerate()
        {
            int checkCounter = 0;
            int numBreakerCards = Convert.ToInt16(cmbStartBreaker.Text);

            bool[] checkBreaker = new bool[] { CheckBreaker1() };

            for (int i = 0; i < numBreakerCards; i++)
            {
                if (checkBreaker[i] == true)
                {
                    checkCounter++;
                }
            }

            if (checkCounter == numBreakerCards)
            {
                btnBreakerGenerate.Visible = true;
            }
            else
            {
                btnBreakerGenerate.Visible = false;
            }
        }

        private bool CheckBreaker1()
        {
            return ((cmbBreaker1CardNum.Text != "") && (cmbBreaker1PanelNum.Text != "") && (tbxBreaker1BaseIndex.Text != ""));
        }

        private void btnBreakerCard1_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard1);
            tabControlBreaker.SelectedIndex = 1;/*
            tabControlBreaker1QF.SelectedIndex = 0;*/
        }

        private void btnBreakerCard2_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard2);
            tabControlBreaker.SelectedIndex = 2;
        }

        private void btnBreakerCard3_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard3);
            tabControlBreaker.SelectedIndex = 3;
        }

        private void btnBreakerCard4_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard4);
            tabControlBreaker.SelectedIndex = 4;
        }

        private void btnBreakerCard5_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard5);
        }

        private void btnBreakerCard6_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard6);
        }

        private void ShowBreakerNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                brkBtnArray[i].Visible = true;
            }
        }

        private void BreakerCardNavColor(Button argButton)
        {
            btnBreakerCard1.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnBreakerCard2.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnBreakerCard3.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnBreakerCard4.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnBreakerCard5.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnBreakerCard6.BackColor = Color.FromArgb(255, 20, 20, 20);
            argButton.BackColor = Color.FromArgb(255, 217, 58, 78);
        }

        private void cmbBreaker1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker2CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker2PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker3CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker3PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker4CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }

        private void cmbBreaker4PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBreakerGenerate();
        }
        private void tbxBreaker1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblBreaker1Ch00.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 0);
            lblBreaker1Ch01.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 1);
            lblBreaker1Ch02.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 2);
            lblBreaker1Ch03.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 3);
            lblBreaker1Ch04.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 4);
            lblBreaker1Ch05.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 5);
            lblBreaker1Ch06.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 6);
            lblBreaker1Ch07.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 7);
            lblBreaker1Ch08.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 8);
            lblBreaker1Ch09.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 9);
            lblBreaker1Ch10.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 10);
            lblBreaker1Ch11.Text = ChangeChannelLabel(tbxBreaker1BaseIndex.Text, 11);
            CheckBreakerGenerate();
        }



        //########  #### ##     ## ##     ## ######## ########  
        //##     ##  ##  ###   ### ###   ### ##       ##     ## 
        //##     ##  ##  #### #### #### #### ##       ##     ## 
        //##     ##  ##  ## ### ## ## ### ## ######   ########  
        //##     ##  ##  ##     ## ##     ## ##       ##   ##   
        //##     ##  ##  ##     ## ##     ## ##       ##    ##  
        //########  #### ##     ## ##     ## ######## ##     ## 
        //@Dimmer 

        private void btnDimmerGenerate_Click(object sender, EventArgs e)
        {
            dim1Group00 = new bool[] { chkDimmer1MG1Ch00.Checked, chkDimmer1MG2Ch00.Checked, chkDimmer1MG3Ch00.Checked, chkDimmer1MG4Ch00.Checked };
            dim1Group01 = new bool[] { chkDimmer1MG1Ch01.Checked, chkDimmer1MG2Ch01.Checked, chkDimmer1MG3Ch01.Checked, chkDimmer1MG4Ch01.Checked };
            dim1Group02 = new bool[] { chkDimmer1MG1Ch02.Checked, chkDimmer1MG2Ch02.Checked, chkDimmer1MG3Ch02.Checked, chkDimmer1MG4Ch02.Checked };
            dim1Group03 = new bool[] { chkDimmer1MG1Ch03.Checked, chkDimmer1MG2Ch03.Checked, chkDimmer1MG3Ch03.Checked, chkDimmer1MG4Ch03.Checked };
            dim1Group04 = new bool[] { chkDimmer1MG1Ch04.Checked, chkDimmer1MG2Ch04.Checked, chkDimmer1MG3Ch04.Checked, chkDimmer1MG4Ch04.Checked };
            dim1Group05 = new bool[] { chkDimmer1MG1Ch05.Checked, chkDimmer1MG2Ch05.Checked, chkDimmer1MG3Ch05.Checked, chkDimmer1MG4Ch05.Checked };
            dim1Group06 = new bool[] { chkDimmer1MG1Ch06.Checked, chkDimmer1MG2Ch06.Checked, chkDimmer1MG3Ch06.Checked, chkDimmer1MG4Ch06.Checked };
            dim1Group07 = new bool[] { chkDimmer1MG1Ch07.Checked, chkDimmer1MG2Ch07.Checked, chkDimmer1MG3Ch07.Checked, chkDimmer1MG4Ch07.Checked };
            dim1Group08 = new bool[] { chkDimmer1MG1Ch08.Checked, chkDimmer1MG2Ch08.Checked, chkDimmer1MG3Ch08.Checked, chkDimmer1MG4Ch08.Checked };
            dim1Group09 = new bool[] { chkDimmer1MG1Ch09.Checked, chkDimmer1MG2Ch09.Checked, chkDimmer1MG3Ch09.Checked, chkDimmer1MG4Ch09.Checked };
            dim1Group10 = new bool[] { chkDimmer1MG1Ch10.Checked, chkDimmer1MG2Ch10.Checked, chkDimmer1MG3Ch10.Checked, chkDimmer1MG4Ch10.Checked };
            dim1Group11 = new bool[] { chkDimmer1MG1Ch11.Checked, chkDimmer1MG2Ch11.Checked, chkDimmer1MG3Ch11.Checked, chkDimmer1MG4Ch11.Checked };
            dim1Groups = new bool[][] { dim1Group00, dim1Group01, dim1Group02, dim1Group03, dim1Group04, dim1Group05, dim1Group06, dim1Group07, dim1Group08, dim1Group09, dim1Group10, dim1Group11 };

            List<bool[][]> dimGroups = new List<bool[][]>();
            dimGroups.Add(dim1Groups);

            // Dimmer cards
            for (int card = 0; card < Convert.ToInt16(cmbStartDimmer.Text); card++)
            {
                //dimmerObjects[card].M1_SetDevAddr(dimCardNum[card].SelectedIndex, dimPanelNum[card].SelectedIndex);
                dimmerObjects[card].M1_SetCfgRev(dimConfigRev[card].Text);
                dimmerObjects[card].M1_SetCfgType(dimConfigType[card].Text);
                dimmerObjects[card].M1_SetDCDimmer(true); // hard coding for dimmer card
                dimmerObjects[card].M1_SetDCMotor(dimDCMotor[card].Checked);
                dimmerObjects[card].M1_SetShade(dimShade[card].Checked);
                dimmerObjects[card].M1_SetForce(dimForce[card].Checked);
                dimmerObjects[card].M1_SetBaseIndex(dimBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    dimmerObjects[card].SetOCAmps(channel, dimmerOCAmps[channel].Text);
                    dimmerObjects[card].SetOCTime(channel, dimmerOCTime[channel].Text);
                    dimmerObjects[card].M1_SetGroup0(dimGroups[card][channel], channel); // takes care of all 4 groups
                    dimmerObjects[card].SetLock(channel, dimmerLocks[channel].Checked);
                    dimmerObjects[card].SetPWMFreq(channel, dimmerPWMFreq[channel].Text);
                    dimmerObjects[card].SetPWMDuty(channel, dimmerPWMDuties[channel].Text);
                    dimmerObjects[card].SetPWMEnable(channel, dimmerPWMEnables[channel].Checked);
                    dimmerObjects[card].SetOverride(channel, dimmerOverrides[channel].Checked);
                    dimmerObjects[card].SetTimeout(channel, dimmerTimeouts[channel].Checked);
                    dimmerObjects[card].SetDirection(channel, dimmerDirections[channel].Text);
                    dimmerObjects[card].SetTimeoutTime(channel, dimmerTimeoutTimes[channel].Text);
                    dimmerObjects[card].SetMaxOn(channel, dimmerMaxOns[channel].Text);
                    dimmerObjects[card].SetMaxDurRec(channel, dimmerMaxDurRecs[channel].Text);
                }
            }

            dimmerObjects.ForEach(dimmerObjects => dimmerObjects.CreateDimmerFile());
            CreateDimmerReferenceFile();
            DimmerCardNavColor(btnDimmerGenerate);
            tabControlDimmer.SelectedIndex = 7;
            string[] dimmerFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_Dimmer\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxDimmerGenerated.Lines = dimmerFiles;
        }

        private void CreateDimmerReferenceFile() // card-specific because of the path, which is stored in each card object but isn't related to the Start tab combo box for that card type
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h", "DevAddrE.h", "DevAddrF.h" };

            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_Dimmer\DeviceConfigs\DevAddrConfigs.h"))
            {
                for (int i = 0; i < Convert.ToInt16(cmbStartDimmer.Text); i++)
                {
                    sw.WriteLine("#include \"" + configNamesReference[i] + "\"");
                }
            }
        }

        private void CheckDimGenerate()
        {   //cmbStartDimmer.Text
            int checkCounter = 0;
            int numDimCards = Convert.ToInt16(cmbStartDimmer.Text);

            bool[] checkDimmer = new bool[] { CheckDimmer1() };

            for (int i = 0; i < numDimCards; i++)
            {
                if (checkDimmer[i] == true)
                {
                    checkCounter++;
                }
            }

            if ( checkCounter == numDimCards )
            {
                btnDimmerGenerate.Visible = true;
            }
            else
            {
                btnDimmerGenerate.Visible = false;
            }
        }

        private bool CheckDimmer1()
        {
            return ((cmbDimmer1CardNum.Text != "") && (cmbDimmer1PanelNum.Text != "") && (tbxDimmer1BaseIndex.Text != ""));
        }

        private void btnDimmerCard1_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard1);
            tabControlDimmer.SelectedIndex = 1;
            if (cmbStartDimmer.Text == "Full") tabControlDimmer1QF.SelectedIndex = 1;
            else tabControlDimmer1QF.SelectedIndex = 0;
            tabControlDimmer1QF.SelectedIndex = 0;
        }

        private void btnDimmerCard2_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard2);
            tabControlDimmer.SelectedIndex = 2;
        }

        private void btnDimmerCard3_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard3);
            tabControlDimmer.SelectedIndex = 3;
        }

        private void btnDimmerCard4_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard4);
            tabControlDimmer.SelectedIndex = 4;
        }

        private void btnDimmerCard5_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard5);
            tabControlDimmer.SelectedIndex = 5;
        }

        private void btnDimmerCard6_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard6);
            tabControlDimmer.SelectedIndex = 6;
        }

        private void ShowDimmerNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
               dimBtnArray[i].Visible = true;
            }
        }

        private void DimmerCardNavColor(Button argButton)
        {
            btnDimmerCard1.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnDimmerCard2.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnDimmerCard3.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnDimmerCard4.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnDimmerCard5.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnDimmerCard6.BackColor = Color.FromArgb(255, 20, 20, 20);
            argButton.BackColor = Color.FromArgb(255, 27, 161, 119);
        }

        private void cmbDimmer1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer2CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer2PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer3CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer3PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer4CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer4PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer5CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer5PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer6CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }

        private void cmbDimmer6PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDimGenerate();
        }


        private void tbxDimmer1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblDimmer1Ch00.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 0);
            lblDimmer1Ch01.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 1);
            lblDimmer1Ch02.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 2);
            lblDimmer1Ch03.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 3);
            lblDimmer1Ch04.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 4);
            lblDimmer1Ch05.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 5);
            lblDimmer1Ch06.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 6);
            lblDimmer1Ch07.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 7);
            lblDimmer1Ch08.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 8);
            lblDimmer1Ch09.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 9);
            lblDimmer1Ch10.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 10);
            lblDimmer1Ch11.Text = ChangeChannelLabel(tbxDimmer1BaseIndex.Text, 11);
            CheckDimGenerate();
        }

        // ##     ##  ######  
        // ##     ## ##    ## 
        // ##     ## ##       
        // ######### ##       
        // ##     ## ##       
        // ##     ## ##    ## 
        // ##     ##  ######  
        //@HC


        public void HC_SetAll(int card)
        {
            // When generate is clicked, load necessary checkbox states into arrays to be used to set parameters on each card
            hc1Group00 = new bool[] { chkHC1MG1Ch00.Checked, chkHC1MG2Ch00.Checked, chkHC1MG3Ch00.Checked, chkHC1MG4Ch00.Checked };
            hc1Group01 = new bool[] { chkHC1MG1Ch01.Checked, chkHC1MG2Ch01.Checked, chkHC1MG3Ch01.Checked, chkHC1MG4Ch01.Checked };
            hc1Group02 = new bool[] { chkHC1MG1Ch02.Checked, chkHC1MG2Ch02.Checked, chkHC1MG3Ch02.Checked, chkHC1MG4Ch02.Checked };
            hc1Group03 = new bool[] { chkHC1MG1Ch03.Checked, chkHC1MG2Ch03.Checked, chkHC1MG3Ch03.Checked, chkHC1MG4Ch03.Checked };
            hc1Group04 = new bool[] { chkHC1MG1Ch04.Checked, chkHC1MG2Ch04.Checked, chkHC1MG3Ch04.Checked, chkHC1MG4Ch04.Checked };
            hc1Group05 = new bool[] { chkHC1MG1Ch05.Checked, chkHC1MG2Ch05.Checked, chkHC1MG3Ch05.Checked, chkHC1MG4Ch05.Checked };
            hc1Group06 = new bool[] { chkHC1MG1Ch06.Checked, chkHC1MG2Ch06.Checked, chkHC1MG3Ch06.Checked, chkHC1MG4Ch06.Checked };
            hc1Group07 = new bool[] { chkHC1MG1Ch07.Checked, chkHC1MG2Ch07.Checked, chkHC1MG3Ch07.Checked, chkHC1MG4Ch07.Checked };
            hc1Group08 = new bool[] { chkHC1MG1Ch08.Checked, chkHC1MG2Ch08.Checked, chkHC1MG3Ch08.Checked, chkHC1MG4Ch08.Checked };
            hc1Group09 = new bool[] { chkHC1MG1Ch09.Checked, chkHC1MG2Ch09.Checked, chkHC1MG3Ch09.Checked, chkHC1MG4Ch09.Checked };
            hc1Group10 = new bool[] { chkHC1MG1Ch10.Checked, chkHC1MG2Ch10.Checked, chkHC1MG3Ch10.Checked, chkHC1MG4Ch10.Checked };
            hc1Group11 = new bool[] { chkHC1MG1Ch11.Checked, chkHC1MG2Ch11.Checked, chkHC1MG3Ch11.Checked, chkHC1MG4Ch11.Checked };
            hc1Groups = new bool[][] { hc1Group00, hc1Group01, hc1Group02, hc1Group03, hc1Group04, hc1Group05, hc1Group06, hc1Group07, hc1Group08, hc1Group09, hc1Group10, hc1Group11 };

            // needed to make a list of multidimensional arrays to pass to the group allocation function
            List<bool[][]> hcGroups = new List<bool[][]>();
            hcGroups.Add(hc1Groups);
            //hcGroups.Add(hc2Groups);
            //hcGroups.Add(hc3Groups);
            //hcGroups.Add(hc4Groups);
            //hcGroups.Add(hc5Groups);
            //hcGroups.Add(hc6Groups);

            hcObjects[card].M1_SetCardNumber(cmbHC1CardNum.Text);
            hcObjects[card].M1_SetPanelNumber(cmbHC1PanelNum.Text);
            hcObjects[card].M1_SetDevAddr();
            hcObjects[card].M1_SetCardLetter(tbxHC1CardLetter.Text);
            hcObjects[card].M1_ChangeConfigName();
            hcObjects[card].HC_ChangeAddress();
            hcObjects[card].M1_SetCfgRev(tbxHC1CfgRev.Text);
            hcObjects[card].M1_SetCfgType(tbxHC1CfgType.Text);
            hcObjects[card].M1_SetDCDimmer(chkHC1DCDimmer.Checked);
            hcObjects[card].M1_SetDCMotor(chkHC1DCMotor.Checked);
            hcObjects[card].M1_SetShade(chkHC1Shade.Checked);
            hcObjects[card].HC_SetRGB(chkHC1RGB.Checked);
            hcObjects[card].M1_SetForce(chkHC1Force.Checked);
            hcObjects[card].M1_SetBaseIndex(tbxHC1BaseIndex.Text);
            for (int channel = 0; channel < 12; channel++)
            {
                hcObjects[card].HC_SetLock(channel, hcLock[channel].Checked);
                hcObjects[card].HC_SetPWMDuty(channel, hcPWMDuties[channel].Text);
                hcObjects[card].HC_SetPWMEnable(channel, hcPWMEnables[channel].Checked);
                hcObjects[card].HC_SetDirection(channel, hcDirections[channel].Text);
                hcObjects[card].HC_SetMode(channel, hcModeParam[channel].Text);
                hcObjects[card].HC_SetDeadTime(channel, hcDeadTimes[channel].Text);
                hcObjects[card].HC_SetPaired(channel, hcPaired[channel].Text);
                hcObjects[card].HC_SetTimeout(channel, hcTimeouts[channel].Checked);
                hcObjects[card].HC_SetTimeoutTime(channel, hcTimeoutTimes[channel].Text);
                hcObjects[card].HC_SetMaxOn(channel, hcMaxOns[channel].Text);
                hcObjects[card].HC_SetMaxDurRec(channel, hcMaxDurRec[channel].Text);
                //hcObjects[card].M1_SetGroup0(hcGroups[card][channel], channel); // takes care of all 4 groups
                hcObjects[card].HC_SetOCAmps(channel, hcOCAmps[channel].Text);
                hcObjects[card].HC_SetUndAmp(channel, hcUndAmps[channel].Text);
                hcObjects[card].HC_SetOCTime(channel, hcOCTime[channel].Text);
                hcObjects[card].HC_SetMeasCurTime(channel, hcMeasCurTimes[channel].Text);
            }
        }

        public void HC_GetAll(int card)
        {
            if (hcObjects[card].M1_GetCardNumber() == "") 
            { 
                // sets combobox to blank
                cmbHC1CardNum.ResetText();
                cmbHC1CardNum.SelectedIndex = -1;
            } 
            else { cmbHC1CardNum.Text = hcObjects[card].M1_GetCardNumber(); }
            if (hcObjects[card].M1_GetPanelNumber() == "") 
            { 
                // sets combobox to blank
                cmbHC1PanelNum.ResetText();
                cmbHC1PanelNum.SelectedIndex = -1;
            } 
            else { cmbHC1PanelNum.Text = hcObjects[card].M1_GetPanelNumber(); }
            tbxHC1CfgRev.Text = hcObjects[card].M1_GetCfgRev();
            tbxHC1CardLetter.Text = hcObjects[card].M1_GetCardLetter();
            chkHC1DCDimmer.Checked = hcObjects[card].M1_GetDCDimmer();
            chkHC1DCMotor.Checked = hcObjects[card].M1_GetDCMotor();
            chkHC1Shade.Checked = hcObjects[card].M1_GetShade();
            chkHC1RGB.Checked = hcObjects[card].HC_GetRGB();
            chkHC1Force.Checked = hcObjects[card].M1_GetForce();
            tbxHC1BaseIndex.Text = hcObjects[card].M1_GetBaseIndex();
            for (int channel = 0; channel < 12; channel++)
            {
                hc1OCAmpsQuick[channel].Text = hcObjects[card].HC_GetQuickOCAmps(channel);
                hcLock[channel].Checked = hcObjects[card].HC_GetLock(channel);
                hcPWMDuties[channel].Text = hcObjects[card].HC_GetPWMDuty(channel);
                hcPWMEnables[channel].Checked = hcObjects[card].HC_GetPWMEnable(channel);
                hcDirections[channel].Text = hcObjects[card].HC_GetDirection(channel);
                hcModeParam[channel].Text = hcObjects[card].HC_GetMode(channel);
                hcDeadTimes[channel].Text = hcObjects[card].HC_GetDeadTime(channel);
                hcPaired[channel].Text = hcObjects[card].HC_GetPaired(channel);
                hcTimeouts[channel].Checked = hcObjects[card].HC_GetTimeout(channel);
                hcTimeoutTimes[channel].Text = hcObjects[card].HC_GetTimeoutTime(channel);
                hcMaxOns[channel].Text = hcObjects[card].HC_GetMaxOn(channel);
                hcMaxDurRec[channel].Text = hcObjects[card].HC_GetMaxDurRec(channel);
                // groups
                hcOCAmps[channel].Text = hcObjects[card].HC_GetOCAmps(channel);
                hcUndAmps[channel].Text = hcObjects[card].HC_GetUndAmp(channel);
                hcOCTime[channel].Text = hcObjects[card].HC_GetOCTime(channel);
                hcMeasCurTimes[channel].Text = hcObjects[card].HC_GetMeasCurTime(channel);
            }
        }

        private void btnHCGenerate_Click(object sender, EventArgs e)
        {
            // HC cards

            hcObjects.ForEach(hcObjects => hcObjects.CreateHCFile());
            //CreateHCReferenceFile(hcCardLetter);
            HCCardNavColor(btnHCGenerate);
            tabControlHC.SelectedIndex = 7;
            string[] hcFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxHCGenerated.Lines = hcFiles;
        }

        private void CreateHCReferenceFile(TextBox[] argTextBox)
        {
            using (StreamWriter sw = File.AppendText(@"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\DevAddrConfigs.h"))
            {
                for (int i = 0; i < Convert.ToInt16(cmbStartHC.Text); i++)
                {
                    sw.WriteLine("#include \"DevAddr" + argTextBox[i].Text + ".h\"");
                }
            }
        }

        private void CheckHCGenerate()
        {
            int checkCounter = 0;
            int numHCCards = Convert.ToInt16(cmbStartHC.Text);

            for (int i = 0; i < numHCCards; i++)
            {
                if (hcObjects[i].M1_GetCardNumber() != "" && hcObjects[i].M1_GetPanelNumber() != "" && hcObjects[i].M1_GetBaseIndex() != "")
                {
                    checkCounter++;
                }
            }

            if (checkCounter == numHCCards)
            {
                btnHCGenerate.Visible = true;
            }
            else
            {
                btnHCGenerate.Visible = false;
            }
        }

        private void btnHCCard1_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard1);
            tabControlHC.SelectedIndex = 0;
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
            HC_SetAll(HCCardActive);
            HCCardActive = 0;
            HC_GetAll(HCCardActive);
        }

        private void btnHCCard2_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard2);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = 1;
            HC_GetAll(HCCardActive);
        }

        private void btnHCCard3_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard3);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = 2;
            HC_GetAll(HCCardActive);
        }

        private void btnHCCard4_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard4);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = 3;
            HC_GetAll(HCCardActive);
        }

        private void btnHCCard5_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard5);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = 4;
            HC_GetAll(HCCardActive);
        }

        private void btnHCCard6_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard6);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = 5;
            HC_GetAll(HCCardActive);
        }

        private void ShowHCNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                hcBtnArray[i].Visible = true;
            }
        }

        private void HCCardNavColor(Button argButton)
        {
            btnHCCard1.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnHCCard2.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnHCCard3.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnHCCard4.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnHCCard5.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnHCCard6.BackColor = Color.FromArgb(255, 20, 20, 20);
            argButton.BackColor = Color.FromArgb(255, 24, 80, 135);
        }

        private void cmbHC1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            hcObjects[HCCardActive].M1_SetCardNumber(cmbHC1CardNum.Text);
            CheckHCGenerate();
        }

        private void cmbHC1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            hcObjects[HCCardActive].M1_SetPanelNumber(cmbHC1PanelNum.Text);
            CheckHCGenerate();
        }

        private void chkHC1DCDimmer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHC1DCDimmer.Checked == true)
            {
                chkHC1PWMEnableCh00.Checked = true;
                chkHC1PWMEnableCh01.Checked = true;
                chkHC1PWMEnableCh02.Checked = true;
                chkHC1PWMEnableCh03.Checked = true;
                chkHC1PWMEnableCh04.Checked = true;
                chkHC1PWMEnableCh05.Checked = true;
                chkHC1PWMEnableCh06.Checked = true;
                chkHC1PWMEnableCh07.Checked = true;
                chkHC1PWMEnableCh08.Checked = true;
                chkHC1PWMEnableCh09.Checked = true;
                chkHC1PWMEnableCh10.Checked = true;
                chkHC1PWMEnableCh11.Checked = true;
            }
            else
            {
                chkHC1PWMEnableCh00.Checked = false;
                chkHC1PWMEnableCh01.Checked = false;
                chkHC1PWMEnableCh02.Checked = false;
                chkHC1PWMEnableCh03.Checked = false;
                chkHC1PWMEnableCh04.Checked = false;
                chkHC1PWMEnableCh05.Checked = false;
                chkHC1PWMEnableCh06.Checked = false;
                chkHC1PWMEnableCh07.Checked = false;
                chkHC1PWMEnableCh08.Checked = false;
                chkHC1PWMEnableCh09.Checked = false;
                chkHC1PWMEnableCh10.Checked = false;
                chkHC1PWMEnableCh11.Checked = false;
            }
        }

        private void tbxHC1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            hcObjects[HCCardActive].M1_SetBaseIndex(tbxHC1BaseIndex.Text);
            lblHC1Ch00.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 0);
            lblHC1Ch01.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 1);
            lblHC1Ch02.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 2);
            lblHC1Ch03.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 3);
            lblHC1Ch04.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 4);
            lblHC1Ch05.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 5);
            lblHC1Ch06.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 6);
            lblHC1Ch07.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 7);
            lblHC1Ch08.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 8);
            lblHC1Ch09.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 9);
            lblHC1Ch10.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 10);
            lblHC1Ch11.Text = ChangeChannelLabel(tbxHC1BaseIndex.Text, 11);
            CheckHCGenerate();
        }

        private void ckbTabVisHC1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTabVisHC1.Checked == true)
            {
                this.tabControlHC1QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlHC1QF.SelectedIndex = 0;
            }
        }

        // Quick Amps events
        private void cmbHC1OCAmps00_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh00.Text = cmbHC1OCAmps00.Text;
        }

        private void cmbHC1OCAmps01_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh01.Text = cmbHC1OCAmps01.Text;
        }

        private void cmbHC1OCAmps02_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh02.Text = cmbHC1OCAmps02.Text;
        }

        private void cmbHC1OCAmps03_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh03.Text = cmbHC1OCAmps03.Text;
        }

        private void cmbHC1OCAmps04_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh04.Text = cmbHC1OCAmps04.Text;
        }

        private void cmbHC1OCAmps05_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh05.Text = cmbHC1OCAmps05.Text;
        }

        private void cmbHC1OCAmps06_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh06.Text = cmbHC1OCAmps06.Text;
        }

        private void cmbHC1OCAmps07_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh07.Text = cmbHC1OCAmps07.Text;
        }

        private void cmbHC1OCAmps08_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh08.Text = cmbHC1OCAmps08.Text;
        }

        private void cmbHC1OCAmps09_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh09.Text = cmbHC1OCAmps09.Text;
        }

        private void cmbHC1OCAmps10_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh10.Text = cmbHC1OCAmps10.Text;
        }

        private void cmbHC1OCAmps11_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHC1OCAmpsParamCh11.Text = cmbHC1OCAmps11.Text;
        }

        // Quick Mode events
        private void cmbHC1Mode00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode00.Text == "12V+")
            {
                cmbHC1ModeParamCh00.Text = "High";
                cmbHC1DeadTimeCh00.Text = "0";
                cmbHC1PairedCh00.Text = "None";
            }
            else if (cmbHC1Mode00.Text == "Ground")
            {
                cmbHC1ModeParamCh00.Text = "Low";
                cmbHC1DeadTimeCh00.Text = "0";
                cmbHC1PairedCh00.Text = "None";
            }
            else if (cmbHC1Mode00.Text == "RP UP")
            {
                cmbHC1ModeParamCh00.Text = "H Br";
                cmbHC1DeadTimeCh00.Text = "500";
                cmbHC1PairedCh00.Text = "1";
                chkHC1PWMEnableCh00.Checked = false;
            }

            if (cmbHC1Startup00.Text == "High" || cmbHC1Startup00.Text == "Low") { cmbHC1DirectionCh00.Text = cmbHC1ModeParamCh00.Text; }
            if (cmbHC1DirectionCh00.Text != "Off" && (cmbHC1ModeParamCh00.Text == "High" || cmbHC1ModeParamCh00.Text == "Low")) { cmbHC1DirectionCh00.Text = cmbHC1ModeParamCh00.Text; }
        }

        private void cmbHC1Mode01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode01.Text == "12V+")
            {
                cmbHC1ModeParamCh01.Text = "High";
                cmbHC1DeadTimeCh01.Text = "0";
                cmbHC1PairedCh01.Text = "None";
            }
            else if (cmbHC1Mode01.Text == "Ground")
            {
                cmbHC1ModeParamCh01.Text = "Low";
                cmbHC1DeadTimeCh01.Text = "0";
                cmbHC1PairedCh01.Text = "None";
            }
            else if (cmbHC1Mode01.Text == "RP UP")
            {
                cmbHC1ModeParamCh01.Text = "H Br";
                cmbHC1DeadTimeCh01.Text = "500";
                cmbHC1PairedCh01.Text = "2";
                chkHC1PWMEnableCh01.Checked = false;
            }
            else if (cmbHC1Mode01.Text == "RP DN")
            {
                cmbHC1ModeParamCh01.Text = "Slave";
                cmbHC1DeadTimeCh01.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh01.Text = "0";
                chkHC1PWMEnableCh01.Checked = false;
            }

            if (cmbHC1Startup01.Text == "High" || cmbHC1Startup01.Text == "Low") { cmbHC1DirectionCh01.Text = cmbHC1ModeParamCh01.Text; }
            if (cmbHC1DirectionCh01.Text != "Off" && (cmbHC1ModeParamCh01.Text == "High" || cmbHC1ModeParamCh01.Text == "Low")) { cmbHC1DirectionCh01.Text = cmbHC1ModeParamCh01.Text; }
        }

        private void cmbHC1Mode02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode02.Text == "12V+")
            {
                cmbHC1ModeParamCh02.Text = "High";
                cmbHC1DeadTimeCh02.Text = "0";
                cmbHC1PairedCh02.Text = "None";
            }
            else if (cmbHC1Mode02.Text == "Ground")
            {
                cmbHC1ModeParamCh02.Text = "Low";
                cmbHC1DeadTimeCh02.Text = "0";
                cmbHC1PairedCh02.Text = "None";
            }
            else if (cmbHC1Mode02.Text == "RP UP")
            {
                cmbHC1ModeParamCh02.Text = "H Br";
                cmbHC1DeadTimeCh02.Text = "500";
                cmbHC1PairedCh02.Text = "3";
                chkHC1PWMEnableCh02.Checked = false;
            }
            else if (cmbHC1Mode02.Text == "RP DN")
            {
                cmbHC1ModeParamCh02.Text = "Slave";
                cmbHC1DeadTimeCh02.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh02.Text = "1";
                chkHC1PWMEnableCh02.Checked = false;
            }

            if (cmbHC1Startup02.Text == "High" || cmbHC1Startup02.Text == "Low") { cmbHC1DirectionCh02.Text = cmbHC1ModeParamCh02.Text; }
            if (cmbHC1DirectionCh02.Text != "Off" && (cmbHC1ModeParamCh02.Text == "High" || cmbHC1ModeParamCh02.Text == "Low")) { cmbHC1DirectionCh02.Text = cmbHC1ModeParamCh02.Text; }
        }

        private void cmbHC1Mode03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode03.Text == "12V+")
            {
                cmbHC1ModeParamCh03.Text = "High";
                cmbHC1DeadTimeCh03.Text = "0";
                cmbHC1PairedCh03.Text = "None";
            }
            else if (cmbHC1Mode03.Text == "Ground")
            {
                cmbHC1ModeParamCh03.Text = "Low";
                cmbHC1DeadTimeCh03.Text = "0";
                cmbHC1PairedCh03.Text = "None";
            }
            else if (cmbHC1Mode03.Text == "RP UP")
            {
                cmbHC1ModeParamCh03.Text = "H Br";
                cmbHC1DeadTimeCh03.Text = "500";
                cmbHC1PairedCh03.Text = "4";
                chkHC1PWMEnableCh03.Checked = false;
            }
            else if (cmbHC1Mode03.Text == "RP DN")
            {
                cmbHC1ModeParamCh03.Text = "Slave";
                cmbHC1DeadTimeCh03.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh03.Text = "2";
                chkHC1PWMEnableCh03.Checked = false;
            }

            if (cmbHC1Startup03.Text == "High" || cmbHC1Startup03.Text == "Low") { cmbHC1DirectionCh03.Text = cmbHC1ModeParamCh03.Text; }
            if (cmbHC1DirectionCh03.Text != "Off" && (cmbHC1ModeParamCh03.Text == "High" || cmbHC1ModeParamCh03.Text == "Low")) { cmbHC1DirectionCh03.Text = cmbHC1ModeParamCh03.Text; }
        }

        private void cmbHC1Mode04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode04.Text == "12V+")
            {
                cmbHC1ModeParamCh04.Text = "High";
                cmbHC1DeadTimeCh04.Text = "0";
                cmbHC1PairedCh04.Text = "None";
            }
            else if (cmbHC1Mode04.Text == "Ground")
            {
                cmbHC1ModeParamCh04.Text = "Low";
                cmbHC1DeadTimeCh04.Text = "0";
                cmbHC1PairedCh04.Text = "None";
            }
            else if (cmbHC1Mode04.Text == "RP UP")
            {
                cmbHC1ModeParamCh04.Text = "H Br";
                cmbHC1DeadTimeCh04.Text = "500";
                cmbHC1PairedCh04.Text = "5";
                chkHC1PWMEnableCh04.Checked = false;
            }
            else if (cmbHC1Mode04.Text == "RP DN")
            {
                cmbHC1ModeParamCh04.Text = "Slave";
                cmbHC1DeadTimeCh04.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh04.Text = "3";
                chkHC1PWMEnableCh04.Checked = false;
            }

            if (cmbHC1Startup04.Text == "High" || cmbHC1Startup04.Text == "Low") { cmbHC1DirectionCh04.Text = cmbHC1ModeParamCh04.Text; }
            if (cmbHC1DirectionCh04.Text != "Off" && (cmbHC1ModeParamCh04.Text == "High" || cmbHC1ModeParamCh04.Text == "Low")) { cmbHC1DirectionCh04.Text = cmbHC1ModeParamCh04.Text; }
        }

        private void cmbHC1Mode05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode05.Text == "12V+")
            {
                cmbHC1ModeParamCh05.Text = "High";
                cmbHC1DeadTimeCh05.Text = "0";
                cmbHC1PairedCh05.Text = "None";
            }
            else if (cmbHC1Mode05.Text == "Ground")
            {
                cmbHC1ModeParamCh05.Text = "Low";
                cmbHC1DeadTimeCh05.Text = "0";
                cmbHC1PairedCh05.Text = "None";
            }
            else if (cmbHC1Mode05.Text == "RP UP")
            {
                cmbHC1ModeParamCh05.Text = "H Br";
                cmbHC1DeadTimeCh05.Text = "500";
                cmbHC1PairedCh05.Text = "6";
                chkHC1PWMEnableCh05.Checked = false;
            }
            else if (cmbHC1Mode05.Text == "RP DN")
            {
                cmbHC1ModeParamCh05.Text = "Slave";
                cmbHC1DeadTimeCh05.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh05.Text = "4";
                chkHC1PWMEnableCh05.Checked = false;
            }

            if (cmbHC1Startup05.Text == "High" || cmbHC1Startup05.Text == "Low") { cmbHC1DirectionCh05.Text = cmbHC1ModeParamCh05.Text; }
            if (cmbHC1DirectionCh05.Text != "Off" && (cmbHC1ModeParamCh05.Text == "High" || cmbHC1ModeParamCh05.Text == "Low")) { cmbHC1DirectionCh05.Text = cmbHC1ModeParamCh05.Text; }
        }

        private void cmbHC1Mode06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode06.Text == "12V+")
            {
                cmbHC1ModeParamCh06.Text = "High";
                cmbHC1DeadTimeCh06.Text = "0";
                cmbHC1PairedCh06.Text = "None";
            }
            else if (cmbHC1Mode06.Text == "Ground")
            {
                cmbHC1ModeParamCh06.Text = "Low";
                cmbHC1DeadTimeCh06.Text = "0";
                cmbHC1PairedCh06.Text = "None";
            }
            else if (cmbHC1Mode06.Text == "RP UP")
            {
                cmbHC1ModeParamCh06.Text = "H Br";
                cmbHC1DeadTimeCh06.Text = "500";
                cmbHC1PairedCh06.Text = "7";
                chkHC1PWMEnableCh06.Checked = false;
            }
            else if (cmbHC1Mode06.Text == "RP DN")
            {
                cmbHC1ModeParamCh06.Text = "Slave";
                cmbHC1DeadTimeCh06.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh06.Text = "5";
                chkHC1PWMEnableCh06.Checked = false;
            }

            if (cmbHC1Startup06.Text == "High" || cmbHC1Startup06.Text == "Low") { cmbHC1DirectionCh06.Text = cmbHC1ModeParamCh06.Text; }
            if (cmbHC1DirectionCh06.Text != "Off" && (cmbHC1ModeParamCh06.Text == "High" || cmbHC1ModeParamCh06.Text == "Low")) { cmbHC1DirectionCh06.Text = cmbHC1ModeParamCh06.Text; }
        }

        private void cmbHC1Mode07_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode07.Text == "12V+")
            {
                cmbHC1ModeParamCh07.Text = "High";
                cmbHC1DeadTimeCh07.Text = "0";
                cmbHC1PairedCh07.Text = "None";
            }
            else if (cmbHC1Mode07.Text == "Ground")
            {
                cmbHC1ModeParamCh07.Text = "Low";
                cmbHC1DeadTimeCh07.Text = "0";
                cmbHC1PairedCh07.Text = "None";
            }
            else if (cmbHC1Mode07.Text == "RP UP")
            {
                cmbHC1ModeParamCh07.Text = "H Br";
                cmbHC1DeadTimeCh07.Text = "500";
                cmbHC1PairedCh07.Text = "8";
                chkHC1PWMEnableCh07.Checked = false;
            }
            else if (cmbHC1Mode07.Text == "RP DN")
            {
                cmbHC1ModeParamCh07.Text = "Slave";
                cmbHC1DeadTimeCh07.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh07.Text = "6";
                chkHC1PWMEnableCh07.Checked = false;
            }

            if (cmbHC1Startup07.Text == "High" || cmbHC1Startup07.Text == "Low") { cmbHC1DirectionCh07.Text = cmbHC1ModeParamCh07.Text; }
            if (cmbHC1DirectionCh07.Text != "Off" && (cmbHC1ModeParamCh07.Text == "High" || cmbHC1ModeParamCh07.Text == "Low")) { cmbHC1DirectionCh07.Text = cmbHC1ModeParamCh07.Text; }
        }

        private void cmbHC1Mode08_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode08.Text == "12V+")
            {
                cmbHC1ModeParamCh08.Text = "High";
                cmbHC1DeadTimeCh08.Text = "0";
                cmbHC1PairedCh08.Text = "None";
            }
            else if (cmbHC1Mode08.Text == "Ground")
            {
                cmbHC1ModeParamCh08.Text = "Low";
                cmbHC1DeadTimeCh08.Text = "0";
                cmbHC1PairedCh08.Text = "None";
            }
            else if (cmbHC1Mode08.Text == "RP UP")
            {
                cmbHC1ModeParamCh08.Text = "H Br";
                cmbHC1DeadTimeCh08.Text = "500";
                cmbHC1PairedCh08.Text = "9";
                chkHC1PWMEnableCh08.Checked = false;
            }
            else if (cmbHC1Mode08.Text == "RP DN")
            {
                cmbHC1ModeParamCh08.Text = "Slave";
                cmbHC1DeadTimeCh08.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh08.Text = "7";
                chkHC1PWMEnableCh08.Checked = false;
            }

            if (cmbHC1Startup08.Text == "High" || cmbHC1Startup08.Text == "Low") { cmbHC1DirectionCh08.Text = cmbHC1ModeParamCh08.Text; }
            if (cmbHC1DirectionCh08.Text != "Off" && (cmbHC1ModeParamCh08.Text == "High" || cmbHC1ModeParamCh08.Text == "Low")) { cmbHC1DirectionCh08.Text = cmbHC1ModeParamCh08.Text; }
        }

        private void cmbHC1Mode09_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode09.Text == "12V+")
            {
                cmbHC1ModeParamCh09.Text = "High";
                cmbHC1DeadTimeCh09.Text = "0";
                cmbHC1PairedCh09.Text = "None";
            }
            else if (cmbHC1Mode09.Text == "Ground")
            {
                cmbHC1ModeParamCh09.Text = "Low";
                cmbHC1DeadTimeCh09.Text = "0";
                cmbHC1PairedCh09.Text = "None";
            }
            else if (cmbHC1Mode09.Text == "RP UP")
            {
                cmbHC1ModeParamCh09.Text = "H Br";
                cmbHC1DeadTimeCh09.Text = "500";
                cmbHC1PairedCh09.Text = "10";
                chkHC1PWMEnableCh09.Checked = false;
            }
            else if (cmbHC1Mode09.Text == "RP DN")
            {
                cmbHC1ModeParamCh09.Text = "Slave";
                cmbHC1DeadTimeCh09.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh09.Text = "8";
                chkHC1PWMEnableCh09.Checked = false;
            }

            if (cmbHC1Startup09.Text == "High" || cmbHC1Startup09.Text == "Low") { cmbHC1DirectionCh09.Text = cmbHC1ModeParamCh09.Text; }
            if (cmbHC1DirectionCh09.Text != "Off" && (cmbHC1ModeParamCh09.Text == "High" || cmbHC1ModeParamCh09.Text == "Low")) { cmbHC1DirectionCh09.Text = cmbHC1ModeParamCh09.Text; }
        }

        private void cmbHC1Mode10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode10.Text == "12V+")
            {
                cmbHC1ModeParamCh10.Text = "High";
                cmbHC1DeadTimeCh10.Text = "0";
                cmbHC1PairedCh10.Text = "None";
            }
            else if (cmbHC1Mode10.Text == "Ground")
            {
                cmbHC1ModeParamCh10.Text = "Low";
                cmbHC1DeadTimeCh10.Text = "0";
                cmbHC1PairedCh10.Text = "None";
            }
            else if (cmbHC1Mode10.Text == "RP UP")
            {
                cmbHC1ModeParamCh10.Text = "H Br";
                cmbHC1DeadTimeCh10.Text = "500";
                cmbHC1PairedCh10.Text = "11";
                chkHC1PWMEnableCh10.Checked = false;
            }
            else if (cmbHC1Mode10.Text == "RP DN")
            {
                cmbHC1ModeParamCh10.Text = "Slave";
                cmbHC1DeadTimeCh10.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh10.Text = "9";
                chkHC1PWMEnableCh10.Checked = false;
            }

            if (cmbHC1Startup10.Text == "High" || cmbHC1Startup10.Text == "Low") { cmbHC1DirectionCh10.Text = cmbHC1ModeParamCh10.Text; }
            if (cmbHC1DirectionCh10.Text != "Off" && (cmbHC1ModeParamCh10.Text == "High" || cmbHC1ModeParamCh10.Text == "Low")) { cmbHC1DirectionCh10.Text = cmbHC1ModeParamCh10.Text; }
        }

        private void cmbHC1Mode11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Mode11.Text == "12V+")
            {
                cmbHC1ModeParamCh11.Text = "High";
                cmbHC1DeadTimeCh11.Text = "0";
                cmbHC1PairedCh11.Text = "None";
            }
            else if (cmbHC1Mode11.Text == "Ground")
            {
                cmbHC1ModeParamCh11.Text = "Low";
                cmbHC1DeadTimeCh11.Text = "0";
                cmbHC1PairedCh11.Text = "None";
            }
            else if (cmbHC1Mode11.Text == "RP DN")
            {
                cmbHC1ModeParamCh11.Text = "Slave";
                cmbHC1DeadTimeCh11.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh11.Text = "10";
                chkHC1PWMEnableCh11.Checked = false;
            }

            if (cmbHC1Startup11.Text == "High" || cmbHC1Startup11.Text == "Low") { cmbHC1DirectionCh11.Text = cmbHC1ModeParamCh11.Text; }
            if (cmbHC1DirectionCh11.Text != "Off" && (cmbHC1ModeParamCh11.Text == "High" || cmbHC1ModeParamCh11.Text == "Low")) { cmbHC1DirectionCh11.Text = cmbHC1ModeParamCh11.Text; }
        }

        // Quick Startup events
        private void cmbHC1Startup00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup00.Text == "Latch")
            {
                chkHC1Lock00.Checked = false;
                txtbHC1PWMDutyCh00.Text = "200";
                cmbHC1DirectionCh00.Text = (cmbHC1ModeParamCh00.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup00.Text == "Constant")
            {
                chkHC1Lock00.Checked = true;
                txtbHC1PWMDutyCh00.Text = "200";
                cmbHC1DirectionCh00.Text = (cmbHC1ModeParamCh00.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock00.Checked = false;
                txtbHC1PWMDutyCh00.Text = "0";
                cmbHC1DirectionCh00.Text = "Off";
            }
        }

        private void cmbHC1Startup01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup01.Text == "Latch")
            {
                chkHC1Lock01.Checked = false;
                txtbHC1PWMDutyCh01.Text = "200";
                cmbHC1DirectionCh01.Text = (cmbHC1ModeParamCh01.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup01.Text == "Constant")
            {
                chkHC1Lock01.Checked = true;
                txtbHC1PWMDutyCh01.Text = "200";
                cmbHC1DirectionCh01.Text = (cmbHC1ModeParamCh01.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock01.Checked = false;
                txtbHC1PWMDutyCh01.Text = "0";
                cmbHC1DirectionCh01.Text = "Off";
            }
        }

        private void cmbHC1Startup02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup02.Text == "Latch")
            {
                chkHC1Lock02.Checked = false;
                txtbHC1PWMDutyCh02.Text = "200";
                cmbHC1DirectionCh02.Text = (cmbHC1ModeParamCh02.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup02.Text == "Constant")
            {
                chkHC1Lock02.Checked = true;
                txtbHC1PWMDutyCh02.Text = "200";
                cmbHC1DirectionCh02.Text = (cmbHC1ModeParamCh02.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock02.Checked = false;
                txtbHC1PWMDutyCh02.Text = "0";
                cmbHC1DirectionCh02.Text = "Off";
            }
        }

        private void cmbHC1Startup03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup03.Text == "Latch")
            {
                chkHC1Lock03.Checked = false;
                txtbHC1PWMDutyCh03.Text = "200";
                cmbHC1DirectionCh03.Text = (cmbHC1ModeParamCh03.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup03.Text == "Constant")
            {
                chkHC1Lock03.Checked = true;
                txtbHC1PWMDutyCh03.Text = "200";
                cmbHC1DirectionCh03.Text = (cmbHC1ModeParamCh03.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock03.Checked = false;
                txtbHC1PWMDutyCh03.Text = "0";
                cmbHC1DirectionCh03.Text = "Off";
            }
        }

        private void cmbHC1Startup04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup04.Text == "Latch")
            {
                chkHC1Lock04.Checked = false;
                txtbHC1PWMDutyCh04.Text = "200";
                cmbHC1DirectionCh04.Text = (cmbHC1ModeParamCh04.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup04.Text == "Constant")
            {
                chkHC1Lock04.Checked = true;
                txtbHC1PWMDutyCh04.Text = "200";
                cmbHC1DirectionCh04.Text = (cmbHC1ModeParamCh04.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock04.Checked = false;
                txtbHC1PWMDutyCh04.Text = "0";
                cmbHC1DirectionCh04.Text = "Off";
            }
        }

        private void cmbHC1Startup05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup05.Text == "Latch")
            {
                chkHC1Lock05.Checked = false;
                txtbHC1PWMDutyCh05.Text = "200";
                cmbHC1DirectionCh05.Text = (cmbHC1ModeParamCh05.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup05.Text == "Constant")
            {
                chkHC1Lock05.Checked = true;
                txtbHC1PWMDutyCh05.Text = "200";
                cmbHC1DirectionCh05.Text = (cmbHC1ModeParamCh05.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock05.Checked = false;
                txtbHC1PWMDutyCh05.Text = "0";
                cmbHC1DirectionCh05.Text = "Off";
            }
        }

        private void cmbHC1Startup06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup06.Text == "Latch")
            {
                chkHC1Lock06.Checked = false;
                txtbHC1PWMDutyCh06.Text = "200";
                cmbHC1DirectionCh06.Text = (cmbHC1ModeParamCh06.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup06.Text == "Constant")
            {
                chkHC1Lock06.Checked = true;
                txtbHC1PWMDutyCh06.Text = "200";
                cmbHC1DirectionCh06.Text = (cmbHC1ModeParamCh06.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock06.Checked = false;
                txtbHC1PWMDutyCh06.Text = "0";
                cmbHC1DirectionCh06.Text = "Off";
            }
        }

        private void cmbHC1Startup07_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup07.Text == "Latch")
            {
                chkHC1Lock07.Checked = false;
                txtbHC1PWMDutyCh07.Text = "200";
                cmbHC1DirectionCh07.Text = (cmbHC1ModeParamCh07.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup07.Text == "Constant")
            {
                chkHC1Lock07.Checked = true;
                txtbHC1PWMDutyCh07.Text = "200";
                cmbHC1DirectionCh07.Text = (cmbHC1ModeParamCh07.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock07.Checked = false;
                txtbHC1PWMDutyCh07.Text = "0";
                cmbHC1DirectionCh07.Text = "Off";
            }
        }

        private void cmbHC1Startup08_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup08.Text == "Latch")
            {
                chkHC1Lock08.Checked = false;
                txtbHC1PWMDutyCh08.Text = "200";
                cmbHC1DirectionCh08.Text = (cmbHC1ModeParamCh08.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup08.Text == "Constant")
            {
                chkHC1Lock08.Checked = true;
                txtbHC1PWMDutyCh08.Text = "200";
                cmbHC1DirectionCh08.Text = (cmbHC1ModeParamCh08.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock08.Checked = false;
                txtbHC1PWMDutyCh08.Text = "0";
                cmbHC1DirectionCh08.Text = "Off";
            }
        }

        private void cmbHC1Startup09_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup09.Text == "Latch")
            {
                chkHC1Lock09.Checked = false;
                txtbHC1PWMDutyCh09.Text = "200";
                cmbHC1DirectionCh09.Text = (cmbHC1ModeParamCh09.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup09.Text == "Constant")
            {
                chkHC1Lock09.Checked = true;
                txtbHC1PWMDutyCh09.Text = "200";
                cmbHC1DirectionCh09.Text = (cmbHC1ModeParamCh09.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock09.Checked = false;
                txtbHC1PWMDutyCh09.Text = "0";
                cmbHC1DirectionCh09.Text = "Off";
            }
        }

        private void cmbHC1Startup10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup10.Text == "Latch")
            {
                chkHC1Lock10.Checked = false;
                txtbHC1PWMDutyCh10.Text = "200";
                cmbHC1DirectionCh10.Text = (cmbHC1ModeParamCh10.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup10.Text == "Constant")
            {
                chkHC1Lock10.Checked = true;
                txtbHC1PWMDutyCh10.Text = "200";
                cmbHC1DirectionCh10.Text = (cmbHC1ModeParamCh10.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock10.Checked = false;
                txtbHC1PWMDutyCh10.Text = "0";
                cmbHC1DirectionCh10.Text = "Off";
            }
        }

        private void cmbHC1Startup11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup11.Text == "Latch")
            {
                chkHC1Lock11.Checked = false;
                txtbHC1PWMDutyCh11.Text = "200";
                cmbHC1DirectionCh11.Text = (cmbHC1ModeParamCh11.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHC1Startup11.Text == "Constant")
            {
                chkHC1Lock11.Checked = true;
                txtbHC1PWMDutyCh11.Text = "200";
                cmbHC1DirectionCh11.Text = (cmbHC1ModeParamCh11.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock11.Checked = false;
                txtbHC1PWMDutyCh11.Text = "0";
                cmbHC1DirectionCh11.Text = "Off";
            }
        }


        // Mode Parameter events
        private void cmbHC1ModeParamCh00_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh00.Text == "Slave") { lblHC1Ch00.Visible = false; }
            else { lblHC1Ch00.Visible = true; }
        }

        private void cmbHC1ModeParamCh01_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh01.Text == "Slave") { lblHC1Ch01.Visible = false; }
            else { lblHC1Ch01.Visible = true; }
        }

        private void cmbHC1ModeParamCh02_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh02.Text == "Slave") { lblHC1Ch02.Visible = false; }
            else { lblHC1Ch02.Visible = true; }
        }

        private void cmbHC1ModeParamCh03_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh03.Text == "Slave") { lblHC1Ch03.Visible = false; }
            else { lblHC1Ch03.Visible = true; }
        }

        private void cmbHC1ModeParamCh04_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh04.Text == "Slave") { lblHC1Ch04.Visible = false; }
            else { lblHC1Ch04.Visible = true; }
        }

        private void cmbHC1ModeParamCh05_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh05.Text == "Slave") { lblHC1Ch05.Visible = false; }
            else { lblHC1Ch05.Visible = true; }
        }

        private void cmbHC1ModeParamCh06_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh06.Text == "Slave") { lblHC1Ch06.Visible = false; }
            else { lblHC1Ch06.Visible = true; }
        }

        private void cmbHC1ModeParamCh07_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh07.Text == "Slave") { lblHC1Ch07.Visible = false; }
            else { lblHC1Ch07.Visible = true; }
        }

        private void cmbHC1ModeParamCh08_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh08.Text == "Slave") { lblHC1Ch08.Visible = false; }
            else { lblHC1Ch08.Visible = true; }
        }

        private void cmbHC1ModeParamCh09_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh09.Text == "Slave") { lblHC1Ch09.Visible = false; }
            else { lblHC1Ch09.Visible = true; }
        }

        private void cmbHC1ModeParamCh10_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh10.Text == "Slave") { lblHC1Ch10.Visible = false; }
            else { lblHC1Ch10.Visible = true; }
        }

        private void cmbHC1ModeParamCh11_TextChanged(object sender, EventArgs e)
        {
            if (cmbHC1ModeParamCh11.Text == "Slave") { lblHC1Ch11.Visible = false; }
            else { lblHC1Ch11.Visible = true; }
        }




        //##        ######  
        //##       ##    ## 
        //##       ##       
        //##       ##       
        //##       ##       
        //##       ##    ## 
        //########  ######  
        //@LC 

        private void btnLCGenerate_Click(object sender, EventArgs e)
        {
            lc1Group00 = new bool[] { chkLC1MG1Ch00.Checked, chkLC1MG2Ch00.Checked, chkLC1MG3Ch00.Checked, chkLC1MG4Ch00.Checked };
            lc1Group01 = new bool[] { chkLC1MG1Ch01.Checked, chkLC1MG2Ch01.Checked, chkLC1MG3Ch01.Checked, chkLC1MG4Ch01.Checked };
            lc1Group02 = new bool[] { chkLC1MG1Ch02.Checked, chkLC1MG2Ch02.Checked, chkLC1MG3Ch02.Checked, chkLC1MG4Ch02.Checked };
            lc1Group03 = new bool[] { chkLC1MG1Ch03.Checked, chkLC1MG2Ch03.Checked, chkLC1MG3Ch03.Checked, chkLC1MG4Ch03.Checked };
            lc1Group04 = new bool[] { chkLC1MG1Ch04.Checked, chkLC1MG2Ch04.Checked, chkLC1MG3Ch04.Checked, chkLC1MG4Ch04.Checked };
            lc1Group05 = new bool[] { chkLC1MG1Ch05.Checked, chkLC1MG2Ch05.Checked, chkLC1MG3Ch05.Checked, chkLC1MG4Ch05.Checked };
            lc1Group06 = new bool[] { chkLC1MG1Ch06.Checked, chkLC1MG2Ch06.Checked, chkLC1MG3Ch06.Checked, chkLC1MG4Ch06.Checked };
            lc1Group07 = new bool[] { chkLC1MG1Ch07.Checked, chkLC1MG2Ch07.Checked, chkLC1MG3Ch07.Checked, chkLC1MG4Ch07.Checked };
            lc1Group08 = new bool[] { chkLC1MG1Ch08.Checked, chkLC1MG2Ch08.Checked, chkLC1MG3Ch08.Checked, chkLC1MG4Ch08.Checked };
            lc1Group09 = new bool[] { chkLC1MG1Ch09.Checked, chkLC1MG2Ch09.Checked, chkLC1MG3Ch09.Checked, chkLC1MG4Ch09.Checked };
            lc1Group10 = new bool[] { chkLC1MG1Ch10.Checked, chkLC1MG2Ch10.Checked, chkLC1MG3Ch10.Checked, chkLC1MG4Ch10.Checked };
            lc1Group11 = new bool[] { chkLC1MG1Ch11.Checked, chkLC1MG2Ch11.Checked, chkLC1MG3Ch11.Checked, chkLC1MG4Ch11.Checked };
            lc1Group12 = new bool[] { chkLC1MG1Ch12.Checked, chkLC1MG2Ch12.Checked, chkLC1MG3Ch12.Checked, chkLC1MG4Ch12.Checked };
            lc1Group13 = new bool[] { chkLC1MG1Ch13.Checked, chkLC1MG2Ch13.Checked, chkLC1MG3Ch13.Checked, chkLC1MG4Ch13.Checked };
            lc1Group14 = new bool[] { chkLC1MG1Ch14.Checked, chkLC1MG2Ch14.Checked, chkLC1MG3Ch14.Checked, chkLC1MG4Ch14.Checked };
            lc1Group15 = new bool[] { chkLC1MG1Ch15.Checked, chkLC1MG2Ch15.Checked, chkLC1MG3Ch15.Checked, chkLC1MG4Ch15.Checked };
            lc1Groups = new bool[][] { lc1Group00, lc1Group01, lc1Group02, lc1Group03, lc1Group04, lc1Group05, lc1Group06, lc1Group07, lc1Group08, lc1Group09, lc1Group10, lc1Group11, lc1Group12, lc1Group13, lc1Group14, lc1Group15 };


            List<bool[][]> lcGroups = new List<bool[][]>();
            lcGroups.Add(lc1Groups);
            //lcGroups.Add(lc2Groups);
            //lcGroups.Add(lc3Groups);
            //lcGroups.Add(lc4Groups);
            //lcGroups.Add(lc5Groups);
            //lcGroups.Add(lc6Groups);

            // LC cards
            for (int card = 0; card < Convert.ToInt16(cmbStartLC.Text); card++)
            {
                //lcObjects[card].M1_SetDevAddr(lcCardNum[card].SelectedIndex, lcPanelNum[card].SelectedIndex);
                lcObjects[card].M1_SetCfgRev(lcConfigRev[card].Text);
                lcObjects[card].M1_SetCfgType(lcConfigType[card].Text);
                lcObjects[card].M1_SetDCDimmer(lcDCDimmer[card].Checked);
                lcObjects[card].M1_SetDCMotor(lcDCMotor[card].Checked);
                lcObjects[card].M1_SetShade(lcShade[card].Checked);
                lcObjects[card].M1_SetForce(lcForce[card].Checked);
                lcObjects[card].M1_SetBaseIndex(lcBaseInstance[card].Text);
                for (int channel = 0; channel < 16; channel++)
                {
                    if (lcStandalone[card].Checked == false) // only set overcurrent parameters if it's not a standalone card
                    {
                        lcObjects[card].SetOCAmps(channel, lcOCAmps[channel].Text);
                        lcObjects[card].SetOCTime(channel, lcOCTime[channel].Text);
                    }
                    lcObjects[card].M1_SetGroup0(lcGroups[card][channel], channel); // takes care of all 4 groups
                    lcObjects[card].SetLock(lcLocks[channel].Checked, channel);
                    lcObjects[card].SetDirection(lcDirections[channel].Text, channel);
                    lcObjects[card].SetTimeoutTimes(lcTimeoutTimes[channel].Text, channel);
                    lcObjects[card].SetMaxOn(lcMaxOns[channel].Text, channel);
                    lcObjects[card].SetMaxDurRecovery(lcMaxDurRecoveries[channel].Text, channel);
                    lcObjects[card].SetUCAmp(lcUCAmps[channel].Text, channel);
                    lcObjects[card].SetMeasCurTime(lcMeasCurTimes[channel].Text, channel);
                }
            }

            lcObjects.ForEach(lcObjects => lcObjects.CreateLCFile());
            CreateLCReferenceFile();
            LCCardNavColor(btnLCGenerate);
            tabControlLC.SelectedIndex = 7;
            string[] lcFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_LC_Bridge\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxLCGenerated.Lines = lcFiles;
        }

        private void CreateLCReferenceFile()
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h", "DevAddrE.h", "DevAddrF.h" };

            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_LC_Bridge\DeviceConfigs\DevAddrConfigs.h"))
            {
                for (int i = 0; i < Convert.ToInt16(cmbStartLC.Text); i++)
                {
                    sw.WriteLine("#include \"" + configNamesReference[i] + "\"");
                }
            }
        }

        private void CheckLCGenerate()
        {   
            int checkCounter = 0;
            int numLCCards = Convert.ToInt16(cmbStartLC.Text);

            bool[] checkLC = new bool[] { CheckLC1() };

            for (int i = 0; i < numLCCards; i++)
            {
                if (checkLC[i] == true)
                {
                    checkCounter++;
                }
            }

            if (checkCounter == numLCCards)
            {
                btnLCGenerate.Visible = true;
            }
            else
            {
                btnLCGenerate.Visible = false;
            }
        }

        private bool CheckLC1()
        {
            return ((cmbLC1CardNum.Text != "") && (cmbLC1PanelNum.Text != "") && (tbxLC1BaseIndex.Text != ""));
        }

       private void btnLCCard1_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard1);
            tabControlLC.SelectedIndex = 1;
            tabControlLC1QF.SelectedIndex = 0;

        }

        private void btnLCCard2_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard2);
            tabControlLC.SelectedIndex = 2;
        }

        private void btnLCCard3_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard3);
            tabControlLC.SelectedIndex = 3;
        }

        private void btnLCCard4_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard4);
            tabControlLC.SelectedIndex = 4;
        }

        private void btnLCCard5_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard5);
            tabControlLC.SelectedIndex = 5;
        }

        private void btnLCCard6_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard6);
            tabControlLC.SelectedIndex = 6;
        }

        private void ShowLCNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                lcBtnArray[i].Visible = true;
            }
        }

        private void LCCardNavColor(Button argButton)
        {
            btnLCCard1.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnLCCard2.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnLCCard3.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnLCCard4.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnLCCard5.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnLCCard6.BackColor = Color.FromArgb(255, 20, 20, 20);
            argButton.BackColor = Color.FromArgb(255, 208, 110, 152);
        }

        private void cmbLC1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC2CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC2PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC3CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC3PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC4CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC4PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC5CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC5PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC6CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC6PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void tbxLC1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblLC1Ch00.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 0);
            lblLC1Ch01.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 1);
            lblLC1Ch02.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 2);
            lblLC1Ch03.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 3);
            lblLC1Ch04.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 4);
            lblLC1Ch05.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 5);
            lblLC1Ch06.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 6);
            lblLC1Ch07.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 7);
            lblLC1Ch08.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 8);
            lblLC1Ch09.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 9);
            lblLC1Ch10.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 10);
            lblLC1Ch11.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 11);
            lblLC1Ch12.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 12);
            lblLC1Ch13.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 13);
            lblLC1Ch14.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 14);
            lblLC1Ch15.Text = ChangeChannelLabel(tbxLC1BaseIndex.Text, 15);
            CheckLCGenerate();
        }

        private void chkLC1Standalone_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkLC1Standalone.Checked)
            //{
            //    HideComboBox(lc1OCAmps);
            //    HideComboBox(lc1OCTime);
            //}
            //else
            //{
            //    ShowComboBox(lc1OCAmps);
            //    ShowComboBox(lc1OCTime);
            //}
        }




        // ######  ##       #### ########  ######## 
        //##    ## ##        ##  ##     ## ##       
        //##       ##        ##  ##     ## ##       
        // ######  ##        ##  ##     ## ######   
        //      ## ##        ##  ##     ## ##       
        //##    ## ##        ##  ##     ## ##       
        // ######  ######## #### ########  ######## 
        //@Slide

        

        //@Load -----------------------------------------------------------------------Load
        private void SetSelectedIndex(ComboBox[] argComboBox, int argIndex)
        {
            foreach (ComboBox i in argComboBox)
            {
                i.SelectedIndex = argIndex;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HideNavButtons();
            cmbBreaker1OCAmpsVIN.SelectedIndex = 0; cmbBreaker1OCTimeVIN.SelectedIndex = 3; cmbBreaker1InterruptVIN.SelectedIndex = 1;
        }

        private void PopulateArrays()
        {
            auxBtnArray = new Button[] { btnAuxCard1, btnAuxCard2, btnAuxCard3, btnAuxCard4, btnAuxCard5, btnAuxCard6 };
            brkBtnArray = new Button[] { btnBreakerCard1, btnBreakerCard2, btnBreakerCard3, btnBreakerCard4, btnBreakerCard5, btnBreakerCard6 };
            dimBtnArray = new Button[] { btnDimmerCard1, btnDimmerCard2, btnDimmerCard3, btnDimmerCard4, btnDimmerCard5, btnDimmerCard6 };
            hcBtnArray = new Button[] { btnHCCard1, btnHCCard2, btnHCCard3, btnHCCard4, btnHCCard5, btnHCCard6 };
            //hrBtnArray = new Button[] { btnHRCard1, btnHRCard2, btnHCRard3, btnHRCard4, btnHRCard5, btnHRCard6 };
            lcBtnArray = new Button[] { btnLCCard1, btnLCCard2, btnLCCard3, btnLCCard4, btnLCCard5, btnLCCard6 };

            auxCardNum = new ComboBox[] { cmbAux1CardNum };
            auxPanelNum = new ComboBox[] { cmbAux1PanelNum };
            auxConfigRev = new TextBox[] { tbxAux1CfgRev };
            auxConfigType = new TextBox[] { tbxAux1CfgType };
            auxDCDimmer = new CheckBox[] { chkAux1DCDimmer };
            auxDCMotor = new CheckBox[] { chkAux1DCMotor };
            auxShade = new CheckBox[] { chkAux1Shade };
            auxForce = new CheckBox[] { chkAux1Force };
            auxBaseInstance = new TextBox[] { tbxAux1BaseIndex };
            auxDirections = new ComboBox[] { cmbAux1DirectionCh00, cmbAux1DirectionCh01, cmbAux1DirectionCh02, cmbAux1DirectionCh03, cmbAux1DirectionCh04, cmbAux1DirectionCh05, cmbAux1DirectionCh06, cmbAux1DirectionCh07, cmbAux1DirectionCh08, cmbAux1DirectionCh09, cmbAux1DirectionCh10, cmbAux1DirectionCh11 };
            auxDeadTimes = new ComboBox[] { cmbAux1DeadTimeCh00, cmbAux1DeadTimeCh01, cmbAux1DeadTimeCh02, cmbAux1DeadTimeCh03, cmbAux1DeadTimeCh04, cmbAux1DeadTimeCh05, cmbAux1DeadTimeCh06, cmbAux1DeadTimeCh07, cmbAux1DeadTimeCh08, cmbAux1DeadTimeCh09, cmbAux1DeadTimeCh10, cmbAux1DeadTimeCh11 };
            auxPairedTimes = new ComboBox[] { cmbAux1PairedCh00, cmbAux1PairedCh01, cmbAux1PairedCh02, cmbAux1PairedCh03, cmbAux1PairedCh04, cmbAux1PairedCh05, cmbAux1PairedCh06, cmbAux1PairedCh07, cmbAux1PairedCh08, cmbAux1PairedCh09, cmbAux1PairedCh10, cmbAux1PairedCh11 };
            auxTimeouts = new CheckBox[] { chkAux1TimeoutCh00, chkAux1TimeoutCh01, chkAux1TimeoutCh02, chkAux1TimeoutCh03, chkAux1TimeoutCh04, chkAux1TimeoutCh05, chkAux1TimeoutCh06, chkAux1TimeoutCh07, chkAux1TimeoutCh08, chkAux1TimeoutCh09, chkAux1TimeoutCh10, chkAux1TimeoutCh11 };
            auxTimeoutTimes = new TextBox[] { txtbAux1TimeoutTimeCh00, txtbAux1TimeoutTimeCh01, txtbAux1TimeoutTimeCh02, txtbAux1TimeoutTimeCh03, txtbAux1TimeoutTimeCh04, txtbAux1TimeoutTimeCh05, txtbAux1TimeoutTimeCh06, txtbAux1TimeoutTimeCh07, txtbAux1TimeoutTimeCh08, txtbAux1TimeoutTimeCh09, txtbAux1TimeoutTimeCh10, txtbAux1TimeoutTimeCh11 };
            auxMaxOns = new TextBox[] { txtbAux1MaxOnCh00, txtbAux1MaxOnCh01, txtbAux1MaxOnCh02, txtbAux1MaxOnCh03, txtbAux1MaxOnCh04, txtbAux1MaxOnCh05, txtbAux1MaxOnCh06, txtbAux1MaxOnCh07, txtbAux1MaxOnCh08, txtbAux1MaxOnCh09, txtbAux1MaxOnCh10, txtbAux1MaxOnCh11 };
            auxMaxDurRecs = new TextBox[] { txtbAux1MaxDurRecCh00, txtbAux1MaxDurRecCh01, txtbAux1MaxDurRecCh02, txtbAux1MaxDurRecCh03, txtbAux1MaxDurRecCh04, txtbAux1MaxDurRecCh05, txtbAux1MaxDurRecCh06, txtbAux1MaxDurRecCh07, txtbAux1MaxDurRecCh08, txtbAux1MaxDurRecCh09, txtbAux1MaxDurRecCh10, txtbAux1MaxDurRecCh11 };

            breakerCardNum = new ComboBox[] { cmbBreaker1CardNum };
            breakerPanelNum = new ComboBox[] { cmbBreaker1PanelNum };
            breakerConfigRev = new TextBox[] { tbxBreaker1CfgRev };
            breakerConfigType = new TextBox[] { tbxBreaker1CfgType };
            breakerBaseInstance = new TextBox[] { tbxBreaker1BaseIndex };
            breakerVINOCAmps = new ComboBox[] { cmbBreaker1OCAmpsVIN };
            breakerVINOCTime = new ComboBox[] { cmbBreaker1OCTimeVIN };
            breakerVINInterrupt = new ComboBox[] { cmbBreaker1InterruptVIN };
            breakerOCAmps = new ComboBox[] { cmbBreaker1OCAmps00, cmbBreaker1OCAmps01, cmbBreaker1OCAmps02, cmbBreaker1OCAmps03, cmbBreaker1OCAmps04, cmbBreaker1OCAmps05, cmbBreaker1OCAmps06, cmbBreaker1OCAmps07, cmbBreaker1OCAmps08, cmbBreaker1OCAmps09, cmbBreaker1OCAmps10, cmbBreaker1OCAmps11 };
            breakerOCTime = new ComboBox[] { cmbBreaker1OCTime00, cmbBreaker1OCTime01, cmbBreaker1OCTime02, cmbBreaker1OCTime03, cmbBreaker1OCTime04, cmbBreaker1OCTime05, cmbBreaker1OCTime06, cmbBreaker1OCTime07, cmbBreaker1OCTime08, cmbBreaker1OCTime09, cmbBreaker1OCTime10, cmbBreaker1OCTime11 };
            breakerInterrupts = new ComboBox[] { cmbBreaker1Interrupt00, cmbBreaker1Interrupt01, cmbBreaker1Interrupt02, cmbBreaker1Interrupt03, cmbBreaker1Interrupt04, cmbBreaker1Interrupt05, cmbBreaker1Interrupt06, cmbBreaker1Interrupt07, cmbBreaker1Interrupt08, cmbBreaker1Interrupt09, cmbBreaker1Interrupt10, cmbBreaker1Interrupt11 };
            breakerDirections = new ComboBox[] { cmbBreak1DirectionCh00, cmbBreak1DirectionCh01, cmbBreak1DirectionCh02, cmbBreak1DirectionCh03, cmbBreak1DirectionCh04, cmbBreak1DirectionCh05, cmbBreak1DirectionCh06, cmbBreak1DirectionCh07, cmbBreak1DirectionCh08, cmbBreak1DirectionCh09, cmbBreak1DirectionCh10, cmbBreak1DirectionCh11 };
            breakerUndercurrents = new TextBox[] { txtbBreak1UCAmpsCh00, txtbBreak1UCAmpsCh01, txtbBreak1UCAmpsCh02, txtbBreak1UCAmpsCh03, txtbBreak1UCAmpsCh04, txtbBreak1UCAmpsCh05, txtbBreak1UCAmpsCh06, txtbBreak1UCAmpsCh07, txtbBreak1UCAmpsCh08, txtbBreak1UCAmpsCh09, txtbBreak1UCAmpsCh10, txtbBreak1UCAmpsCh11 };
            breakerMeasCurRecs = new ComboBox[] { cmbBreak1MeasCurRecCh00, cmbBreak1MeasCurRecCh01, cmbBreak1MeasCurRecCh02, cmbBreak1MeasCurRecCh03, cmbBreak1MeasCurRecCh04, cmbBreak1MeasCurRecCh05, cmbBreak1MeasCurRecCh06, cmbBreak1MeasCurRecCh07, cmbBreak1MeasCurRecCh08, cmbBreak1MeasCurRecCh09, cmbBreak1MeasCurRecCh10, cmbBreak1MeasCurRecCh11 };
            breakerModes = new ComboBox[] { cmbBreak1ModeCh00, cmbBreak1ModeCh01, cmbBreak1ModeCh02, cmbBreak1ModeCh03, cmbBreak1ModeCh04, cmbBreak1ModeCh05, cmbBreak1ModeCh06, cmbBreak1ModeCh07, cmbBreak1ModeCh08, cmbBreak1ModeCh09, cmbBreak1ModeCh10, cmbBreak1ModeCh11 };
            breakerPairedTimes = new ComboBox[] { cmbBreak1PairedCh00, cmbBreak1PairedCh01, cmbBreak1PairedCh02, cmbBreak1PairedCh03, cmbBreak1PairedCh04, cmbBreak1PairedCh05, cmbBreak1PairedCh06, cmbBreak1PairedCh07, cmbBreak1PairedCh08, cmbBreak1PairedCh09, cmbBreak1PairedCh10, cmbBreak1PairedCh11 };
            breakerIGNs = new ComboBox[] { cmbBreak1IGNCh00, cmbBreak1IGNCh01, cmbBreak1IGNCh02, cmbBreak1IGNCh03, cmbBreak1IGNCh04, cmbBreak1IGNCh05, cmbBreak1IGNCh06, cmbBreak1IGNCh07, cmbBreak1IGNCh08, cmbBreak1IGNCh09, cmbBreak1IGNCh10, cmbBreak1IGNCh11 };
            breakerParks = new ComboBox[] { cmbBreak1ParkCh00, cmbBreak1ParkCh01,  cmbBreak1ParkCh02, cmbBreak1ParkCh03, cmbBreak1ParkCh04, cmbBreak1ParkCh05, cmbBreak1ParkCh06, cmbBreak1ParkCh07, cmbBreak1ParkCh08, cmbBreak1ParkCh09, cmbBreak1ParkCh10, cmbBreak1ParkCh11 };

            dimCardNum = new ComboBox[] { cmbDimmer1CardNum };
            dimPanelNum = new ComboBox[] { cmbDimmer1PanelNum };
            dimConfigRev = new TextBox[] { tbxDimmer1CfgRev };
            dimConfigType = new TextBox[] { tbxDimmer1CfgType };
            dimDCMotor = new CheckBox[] { chkDimmer1DCMotor };
            dimShade = new CheckBox[] { chkDimmer1Shade };
            dimForce = new CheckBox[] { chkDimmer1Force };
            dimBaseInstance = new TextBox[] { tbxDimmer1BaseIndex };
            dimmerOCAmps = new ComboBox[] { cmbDimmer1OCAmps00, cmbDimmer1OCAmps01, cmbDimmer1OCAmps02, cmbDimmer1OCAmps03, cmbDimmer1OCAmps04, cmbDimmer1OCAmps05, cmbDimmer1OCAmps06, cmbDimmer1OCAmps07, cmbDimmer1OCAmps08, cmbDimmer1OCAmps09, cmbDimmer1OCAmps10, cmbDimmer1OCAmps11 };
            dimmerOCTime = new ComboBox[] { cmbDimmer1OCTime00, cmbDimmer1OCTime01, cmbDimmer1OCTime02, cmbDimmer1OCTime03, cmbDimmer1OCTime04, cmbDimmer1OCTime05, cmbDimmer1OCTime06, cmbDimmer1OCTime07, cmbDimmer1OCTime08, cmbDimmer1OCTime09, cmbDimmer1OCTime10, cmbDimmer1OCTime11 };
            dimmerLocks = new CheckBox[] { chkDimmer1Lock00, chkDimmer1Lock01, chkDimmer1Lock02, chkDimmer1Lock03, chkDimmer1Lock04, chkDimmer1Lock05, chkDimmer1Lock06, chkDimmer1Lock07, chkDimmer1Lock08, chkDimmer1Lock09, chkDimmer1Lock10, chkDimmer1Lock11};
            dimmerPWMFreq = new ComboBox[] { cmbDimmer1PWMFreqCh00, cmbDimmer1PWMFreqCh01, cmbDimmer1PWMFreqCh02, cmbDimmer1PWMFreqCh03, cmbDimmer1PWMFreqCh04, cmbDimmer1PWMFreqCh04, cmbDimmer1PWMFreqCh05, cmbDimmer1PWMFreqCh06, cmbDimmer1PWMFreqCh07, cmbDimmer1PWMFreqCh08, cmbDimmer1PWMFreqCh09, cmbDimmer1PWMFreqCh10, cmbDimmer1PWMFreqCh11 };
            dimmerPWMDuties = new TextBox[] { txtbDimmer1PWMDutyCh00, txtbDimmer1PWMDutyCh01, txtbDimmer1PWMDutyCh02, txtbDimmer1PWMDutyCh03, txtbDimmer1PWMDutyCh04, txtbDimmer1PWMDutyCh05, txtbDimmer1PWMDutyCh06, txtbDimmer1PWMDutyCh07, txtbDimmer1PWMDutyCh08, txtbDimmer1PWMDutyCh09, txtbDimmer1PWMDutyCh10, txtbDimmer1PWMDutyCh11 };
            dimmerPWMEnables = new CheckBox[] { chkDimmer1PWMEnableCh00, chkDimmer1PWMEnableCh01, chkDimmer1PWMEnableCh02, chkDimmer1PWMEnableCh03, chkDimmer1PWMEnableCh04, chkDimmer1PWMEnableCh05, chkDimmer1PWMEnableCh06, chkDimmer1PWMEnableCh07, chkDimmer1PWMEnableCh08, chkDimmer1PWMEnableCh09, chkDimmer1PWMEnableCh10, chkDimmer1PWMEnableCh11 };
            dimmerOverrides = new CheckBox[] { chkDimmer1OverrideCh00, chkDimmer1OverrideCh01, chkDimmer1OverrideCh02, chkDimmer1OverrideCh03, chkDimmer1OverrideCh04, chkDimmer1OverrideCh05, chkDimmer1OverrideCh06, chkDimmer1OverrideCh07, chkDimmer1OverrideCh08, chkDimmer1OverrideCh09, chkDimmer1OverrideCh10, chkDimmer1OverrideCh11 };
            dimmerDirections = new ComboBox[] { cmbDimmer1DirectionCh00, cmbDimmer1DirectionCh01, cmbDimmer1DirectionCh02, cmbDimmer1DirectionCh03, cmbDimmer1DirectionCh04, cmbDimmer1DirectionCh05, cmbDimmer1DirectionCh06, cmbDimmer1DirectionCh07, cmbDimmer1DirectionCh08, cmbDimmer1DirectionCh09, cmbDimmer1DirectionCh10, cmbDimmer1DirectionCh11 };
            dimmerTimeouts = new CheckBox[] { chkDimmer1TimeoutCh00, chkDimmer1TimeoutCh01, chkDimmer1TimeoutCh02, chkDimmer1TimeoutCh03, chkDimmer1TimeoutCh04, chkDimmer1TimeoutCh05, chkDimmer1TimeoutCh06, chkDimmer1TimeoutCh07, chkDimmer1TimeoutCh08, chkDimmer1TimeoutCh09, chkDimmer1TimeoutCh10, chkDimmer1TimeoutCh11 };
            dimmerTimeoutTimes = new TextBox[] { txtbDimmer1TimeoutTimeCh00, txtbDimmer1TimeoutTimeCh01, txtbDimmer1TimeoutTimeCh02, txtbDimmer1TimeoutTimeCh03, txtbDimmer1TimeoutTimeCh04, txtbDimmer1TimeoutTimeCh05, txtbDimmer1TimeoutTimeCh06, txtbDimmer1TimeoutTimeCh07, txtbDimmer1TimeoutTimeCh08, txtbDimmer1TimeoutTimeCh09, txtbDimmer1TimeoutTimeCh10, txtbDimmer1TimeoutTimeCh11 };
            dimmerMaxOns = new TextBox[] { txtbDimmer1MaxOnCh00, txtbDimmer1MaxOnCh01, txtbDimmer1MaxOnCh02, txtbDimmer1MaxOnCh03, txtbDimmer1MaxOnCh04, txtbDimmer1MaxOnCh05, txtbDimmer1MaxOnCh06, txtbDimmer1MaxOnCh07, txtbDimmer1MaxOnCh08, txtbDimmer1MaxOnCh09, txtbDimmer1MaxOnCh10, txtbDimmer1MaxOnCh11 };
            dimmerMaxDurRecs = new TextBox[] { txtbDimmer1MaxDurRecCh00, txtbDimmer1MaxDurRecCh01, txtbDimmer1MaxDurRecCh02, txtbDimmer1MaxDurRecCh03, txtbDimmer1MaxDurRecCh04, txtbDimmer1MaxDurRecCh05, txtbDimmer1MaxDurRecCh06, txtbDimmer1MaxDurRecCh07, txtbDimmer1MaxDurRecCh08, txtbDimmer1MaxDurRecCh09, txtbDimmer1MaxDurRecCh10, txtbDimmer1MaxDurRecCh11 };
            dimmerUCAmps = new TextBox[] { txtbDimmer1UCAmpsCh00, txtbDimmer1UCAmpsCh01, txtbDimmer1UCAmpsCh02, txtbDimmer1UCAmpsCh03, txtbDimmer1UCAmpsCh04, txtbDimmer1UCAmpsCh05, txtbDimmer1UCAmpsCh06, txtbDimmer1UCAmpsCh07, txtbDimmer1UCAmpsCh08, txtbDimmer1UCAmpsCh09, txtbDimmer1UCAmpsCh10, txtbDimmer1UCAmpsCh11 };
            dimmerMeasCurTimes = new ComboBox[] { cmbDimmer1MeasCurTimeCh00, cmbDimmer1MeasCurTimeCh01, cmbDimmer1MeasCurTimeCh02, cmbDimmer1MeasCurTimeCh03, cmbDimmer1MeasCurTimeCh04, cmbDimmer1MeasCurTimeCh05, cmbDimmer1MeasCurTimeCh06, cmbDimmer1MeasCurTimeCh07, cmbDimmer1MeasCurTimeCh08, cmbDimmer1MeasCurTimeCh09, cmbDimmer1MeasCurTimeCh10, cmbDimmer1MeasCurTimeCh11 }; 

            hc1OCAmpsQuick = new ComboBox[] { cmbHC1OCAmps00, cmbHC1OCAmps01, cmbHC1OCAmps02, cmbHC1OCAmps03, cmbHC1OCAmps04, cmbHC1OCAmps05, cmbHC1OCAmps06, cmbHC1OCAmps07, cmbHC1OCAmps08, cmbHC1OCAmps09, cmbHC1OCAmps10, cmbHC1OCAmps11 };
            hcOCAmps = new TextBox[] { tbxHC1OCAmpsParamCh00, tbxHC1OCAmpsParamCh01, tbxHC1OCAmpsParamCh02, tbxHC1OCAmpsParamCh03, tbxHC1OCAmpsParamCh04, tbxHC1OCAmpsParamCh05, tbxHC1OCAmpsParamCh06, tbxHC1OCAmpsParamCh07, tbxHC1OCAmpsParamCh08, tbxHC1OCAmpsParamCh09, tbxHC1OCAmpsParamCh10, tbxHC1OCAmpsParamCh11 };
            hcOCTime = new ComboBox[] { cmbHC1OCTime00, cmbHC1OCTime01, cmbHC1OCTime02, cmbHC1OCTime03, cmbHC1OCTime04, cmbHC1OCTime05, cmbHC1OCTime06, cmbHC1OCTime07, cmbHC1OCTime08, cmbHC1OCTime09, cmbHC1OCTime10, cmbHC1OCTime11 };
            hcModesQuick = new ComboBox[] { cmbHC1Mode00, cmbHC1Mode01, cmbHC1Mode02, cmbHC1Mode03, cmbHC1Mode04, cmbHC1Mode05, cmbHC1Mode06, cmbHC1Mode07, cmbHC1Mode08, cmbHC1Mode09, cmbHC1Mode10, cmbHC1Mode11 };
            hcStartupQuick = new ComboBox[] { cmbHC1Startup00, cmbHC1Startup01, cmbHC1Startup02, cmbHC1Startup03, cmbHC1Startup04, cmbHC1Startup05, cmbHC1Startup06, cmbHC1Startup07, cmbHC1Startup08, cmbHC1Startup09, cmbHC1Startup10, cmbHC1Startup11 };
            hcLock = new CheckBox[] { chkHC1Lock00, chkHC1Lock01, chkHC1Lock02, chkHC1Lock03, chkHC1Lock04, chkHC1Lock05, chkHC1Lock06, chkHC1Lock07, chkHC1Lock08, chkHC1Lock09, chkHC1Lock10, chkHC1Lock11 };
            hcPWMDuties = new TextBox[] { txtbHC1PWMDutyCh00, txtbHC1PWMDutyCh01, txtbHC1PWMDutyCh02, txtbHC1PWMDutyCh03, txtbHC1PWMDutyCh04, txtbHC1PWMDutyCh05, txtbHC1PWMDutyCh06, txtbHC1PWMDutyCh07, txtbHC1PWMDutyCh08, txtbHC1PWMDutyCh09, txtbHC1PWMDutyCh10, txtbHC1PWMDutyCh11 };
            hcPWMEnables = new CheckBox[] { chkHC1PWMEnableCh00, chkHC1PWMEnableCh01, chkHC1PWMEnableCh02, chkHC1PWMEnableCh03, chkHC1PWMEnableCh04, chkHC1PWMEnableCh05, chkHC1PWMEnableCh06, chkHC1PWMEnableCh07, chkHC1PWMEnableCh08, chkHC1PWMEnableCh09, chkHC1PWMEnableCh10, chkHC1PWMEnableCh11 };
            hcDirections = new ComboBox[] { cmbHC1DirectionCh00, cmbHC1DirectionCh01, cmbHC1DirectionCh02, cmbHC1DirectionCh03, cmbHC1DirectionCh04, cmbHC1DirectionCh05, cmbHC1DirectionCh06, cmbHC1DirectionCh07, cmbHC1DirectionCh08, cmbHC1DirectionCh09, cmbHC1DirectionCh10, cmbHC1DirectionCh11 };
            hcModeParam = new ComboBox[] { cmbHC1ModeParamCh00, cmbHC1ModeParamCh01, cmbHC1ModeParamCh02, cmbHC1ModeParamCh03, cmbHC1ModeParamCh04, cmbHC1ModeParamCh05, cmbHC1ModeParamCh06, cmbHC1ModeParamCh07, cmbHC1ModeParamCh08, cmbHC1ModeParamCh09, cmbHC1ModeParamCh10, cmbHC1ModeParamCh11 };
            hcDeadTimes = new ComboBox[] { cmbHC1DeadTimeCh00, cmbHC1DeadTimeCh01, cmbHC1DeadTimeCh02, cmbHC1DeadTimeCh03, cmbHC1DeadTimeCh04, cmbHC1DeadTimeCh05, cmbHC1DeadTimeCh06, cmbHC1DeadTimeCh07, cmbHC1DeadTimeCh08, cmbHC1DeadTimeCh09, cmbHC1DeadTimeCh10, cmbHC1DeadTimeCh11 };
            hcPaired = new ComboBox[] { cmbHC1PairedCh00, cmbHC1PairedCh01, cmbHC1PairedCh02, cmbHC1PairedCh03, cmbHC1PairedCh04, cmbHC1PairedCh05, cmbHC1PairedCh06, cmbHC1PairedCh07, cmbHC1PairedCh08, cmbHC1PairedCh09, cmbHC1PairedCh10, cmbHC1PairedCh11 };
            hcTimeouts = new CheckBox[] { chkHC1TimeoutCh00, chkHC1TimeoutCh01, chkHC1TimeoutCh02, chkHC1TimeoutCh03, chkHC1TimeoutCh04, chkHC1TimeoutCh05, chkHC1TimeoutCh06, chkHC1TimeoutCh07, chkHC1TimeoutCh08, chkHC1TimeoutCh09, chkHC1TimeoutCh10, chkHC1TimeoutCh11 };
            hcTimeoutTimes = new TextBox[] { txtbHC1TimeoutTimeCh00, txtbHC1TimeoutTimeCh01, txtbHC1TimeoutTimeCh02, txtbHC1TimeoutTimeCh03, txtbHC1TimeoutTimeCh04, txtbHC1TimeoutTimeCh05, txtbHC1TimeoutTimeCh06, txtbHC1TimeoutTimeCh07, txtbHC1TimeoutTimeCh08, txtbHC1TimeoutTimeCh09, txtbHC1TimeoutTimeCh10, txtbHC1TimeoutTimeCh11 };
            hcMaxOns = new TextBox[] { txtbHC1MaxOnCh00, txtbHC1MaxOnCh01, txtbHC1MaxOnCh02, txtbHC1MaxOnCh03, txtbHC1MaxOnCh04, txtbHC1MaxOnCh05, txtbHC1MaxOnCh06, txtbHC1MaxOnCh07, txtbHC1MaxOnCh08, txtbHC1MaxOnCh09, txtbHC1MaxOnCh10, txtbHC1MaxOnCh11 };
            hcMaxDurRec = new TextBox[] { txtbHC1MaxDurRecCh00, txtbHC1MaxDurRecCh01, txtbHC1MaxDurRecCh02, txtbHC1MaxDurRecCh03, txtbHC1MaxDurRecCh04, txtbHC1MaxDurRecCh05, txtbHC1MaxDurRecCh06, txtbHC1MaxDurRecCh07, txtbHC1MaxDurRecCh08, txtbHC1MaxDurRecCh09, txtbHC1MaxDurRecCh10, txtbHC1MaxDurRecCh11 };
            hcUndAmps = new TextBox[] { txtbHC1UndAmpCh00, txtbHC1UndAmpCh01, txtbHC1UndAmpCh02, txtbHC1UndAmpCh03, txtbHC1UndAmpCh04, txtbHC1UndAmpCh05, txtbHC1UndAmpCh06, txtbHC1UndAmpCh07, txtbHC1UndAmpCh08, txtbHC1UndAmpCh09, txtbHC1UndAmpCh10, txtbHC1UndAmpCh11 };
            hcMeasCurTimes = new ComboBox[] { cmbHC1MeasCurTimeCh00, cmbHC1MeasCurTimeCh01, cmbHC1MeasCurTimeCh02, cmbHC1MeasCurTimeCh03, cmbHC1MeasCurTimeCh04, cmbHC1MeasCurTimeCh05, cmbHC1MeasCurTimeCh06, cmbHC1MeasCurTimeCh07, cmbHC1MeasCurTimeCh08, cmbHC1MeasCurTimeCh09, cmbHC1MeasCurTimeCh10, cmbHC1MeasCurTimeCh11 };

            lcOCAmps = new ComboBox[] { cmbLC1OCAmps00, cmbLC1OCAmps01, cmbLC1OCAmps02, cmbLC1OCAmps03, cmbLC1OCAmps04, cmbLC1OCAmps05, cmbLC1OCAmps06, cmbLC1OCAmps07, cmbLC1OCAmps08, cmbLC1OCAmps09, cmbLC1OCAmps10, cmbLC1OCAmps11, cmbLC1OCAmps12, cmbLC1OCAmps13, cmbLC1OCAmps14, cmbLC1OCAmps15 };
            lcOCTime = new ComboBox[] { cmbLC1OCTime00, cmbLC1OCTime01, cmbLC1OCTime02, cmbLC1OCTime03, cmbLC1OCTime04, cmbLC1OCTime05, cmbLC1OCTime06, cmbLC1OCTime07, cmbLC1OCTime08, cmbLC1OCTime09, cmbLC1OCTime10, cmbLC1OCTime11, cmbLC1OCTime12, cmbLC1OCTime13, cmbLC1OCTime14, cmbLC1OCTime15 };
            lcModes = new ComboBox[] { cmbLC1Mode00, cmbLC1Mode01, cmbLC1Mode02, cmbLC1Mode03, cmbLC1Mode04, cmbLC1Mode05, cmbLC1Mode06, cmbLC1Mode07, cmbLC1Mode08, cmbLC1Mode09, cmbLC1Mode10, cmbLC1Mode11, cmbLC1Mode12, cmbLC1Mode13, cmbLC1Mode14, cmbLC1Mode15 };
            lcLocks = new CheckBox[] { chkLC1LockCh00, chkLC1LockCh01, chkLC1LockCh02, chkLC1LockCh03, chkLC1LockCh04, chkLC1LockCh05, chkLC1LockCh06, chkLC1LockCh07, chkLC1LockCh08, chkLC1LockCh09, chkLC1LockCh10, chkLC1LockCh11, chkLC1LockCh12, chkLC1LockCh13, chkLC1LockCh14, chkLC1LockCh15 };
            lcDirections = new ComboBox[] { cmbLC1DirectionCh00, cmbLC1DirectionCh01, cmbLC1DirectionCh02, cmbLC1DirectionCh03, cmbLC1DirectionCh04, cmbLC1DirectionCh05, cmbLC1DirectionCh06, cmbLC1DirectionCh07, cmbLC1DirectionCh08, cmbLC1DirectionCh09, cmbLC1DirectionCh10, cmbLC1DirectionCh11, cmbLC1DirectionCh12, cmbLC1DirectionCh13, cmbLC1DirectionCh14, cmbLC1DirectionCh15 };
            lcTimeoutTimes = new TextBox[] { txtLC1TimoutTimeCh00, txtLC1TimoutTimeCh01, txtLC1TimoutTimeCh02, txtLC1TimoutTimeCh03, txtLC1TimoutTimeCh04, txtLC1TimoutTimeCh05, txtLC1TimoutTimeCh06, txtLC1TimoutTimeCh07, txtLC1TimoutTimeCh08, txtLC1TimoutTimeCh09, txtLC1TimoutTimeCh10, txtLC1TimoutTimeCh11, txtLC1TimoutTimeCh12, txtLC1TimoutTimeCh13, txtLC1TimoutTimeCh14, txtLC1TimoutTimeCh15 };
            lcMaxOns = new TextBox[] { txtbLC1MaxOnCh00, txtbLC1MaxOnCh01, txtbLC1MaxOnCh02, txtbLC1MaxOnCh03, txtbLC1MaxOnCh04, txtbLC1MaxOnCh05, txtbLC1MaxOnCh06, txtbLC1MaxOnCh07, txtbLC1MaxOnCh08, txtbLC1MaxOnCh09, txtbLC1MaxOnCh10, txtbLC1MaxOnCh11, txtbLC1MaxOnCh12, txtbLC1MaxOnCh13, txtbLC1MaxOnCh14, txtbLC1MaxOnCh15 };
            lcMaxDurRecoveries = new TextBox[] { txtbLC1MaxDurRecoveryCh00, txtbLC1MaxDurRecoveryCh01, txtbLC1MaxDurRecoveryCh02, txtbLC1MaxDurRecoveryCh03, txtbLC1MaxDurRecoveryCh04, txtbLC1MaxDurRecoveryCh05, txtbLC1MaxDurRecoveryCh06, txtbLC1MaxDurRecoveryCh07, txtbLC1MaxDurRecoveryCh08, txtbLC1MaxDurRecoveryCh09, txtbLC1MaxDurRecoveryCh10, txtbLC1MaxDurRecoveryCh11, txtbLC1MaxDurRecoveryCh12, txtbLC1MaxDurRecoveryCh13, txtbLC1MaxDurRecoveryCh14, txtbLC1MaxDurRecoveryCh15 };
            lcUCAmps = new TextBox[] { txtbLC1UndercurrentAmpsCh00, txtbLC1UndercurrentAmpsCh01, txtbLC1UndercurrentAmpsCh02, txtbLC1UndercurrentAmpsCh03, txtbLC1UndercurrentAmpsCh04, txtbLC1UndercurrentAmpsCh05, txtbLC1UndercurrentAmpsCh06, txtbLC1UndercurrentAmpsCh07, txtbLC1UndercurrentAmpsCh08, txtbLC1UndercurrentAmpsCh09, txtbLC1UndercurrentAmpsCh10, txtbLC1UndercurrentAmpsCh11, txtbLC1UndercurrentAmpsCh12, txtbLC1UndercurrentAmpsCh13, txtbLC1UndercurrentAmpsCh14, txtbLC1UndercurrentAmpsCh15 };
            lcMeasCurTimes = new ComboBox[] { cmbLC1MeasCurTimeCh00, cmbLC1MeasCurTimeCh01, cmbLC1MeasCurTimeCh02, cmbLC1MeasCurTimeCh03, cmbLC1MeasCurTimeCh04, cmbLC1MeasCurTimeCh05, cmbLC1MeasCurTimeCh06, cmbLC1MeasCurTimeCh07, cmbLC1MeasCurTimeCh08, cmbLC1MeasCurTimeCh09, cmbLC1MeasCurTimeCh10, cmbLC1MeasCurTimeCh11, cmbLC1MeasCurTimeCh12, cmbLC1MeasCurTimeCh13, cmbLC1MeasCurTimeCh14, cmbLC1MeasCurTimeCh15 };

        }

        private void ckbTabVisAux1_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbTabVisAux1.Checked == true)
            {
                this.tabControlAux1QF.SelectedIndex = 1;
            } 
            else
            {
                this.tabControlAux1QF.SelectedIndex = 0;
            }
        }

        private void ckbTabVisBreaker1_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbTabVisBreaker1.Checked == true)
            {
                this.tablessControl3.SelectedIndex = 1;
            } 
            else
            {
                this.tablessControl3.SelectedIndex = 0;
            }
        }

        private void ckbTabVisDimmer1_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbTabVisDimmer1.Checked == true)
            {
                this.tabControlDimmer1QF.SelectedIndex = 1;
            } 
            else
            {
                this.tabControlDimmer1QF.SelectedIndex = 0;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                this.tabControlLC1QF.SelectedIndex = 1;
            } 
            else
            {
                this.tabControlLC1QF.SelectedIndex = 0;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabLC3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox522_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
