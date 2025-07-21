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
        enum MainTab { Start, Blank, Aux, Breaker, Dimmer, HC, LC, HCRelay }
        enum CardNum { Card1, Card2, Card3, Card4, Card5, Card6, Card7, Card8 }

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
        ComboBox[] dimmerOCAmps;
        ComboBox[] dimmerOCTime;
        bool[] dimGroup00; bool[] dimGroup01; bool[] dimGroup02; bool[] dimGroup03; bool[] dimGroup04; bool[] dimGroup05;
        bool[] dimGroup06; bool[] dimGroup07; bool[] dimGroup08; bool[] dimGroup09; bool[] dimGroup10; bool[] dimGroup11;
        bool[][] dimGroups;
        CheckBox[] dimGetGroup00; CheckBox[] dimGetGroup01; CheckBox[] dimGetGroup02; CheckBox[] dimGetGroup03; CheckBox[] dimGetGroup04; CheckBox[] dimGetGroup05;
        CheckBox[] dimGetGroup06; CheckBox[] dimGetGroup07; CheckBox[] dimGetGroup08; CheckBox[] dimGetGroup09; CheckBox[] dimGetGroup10; CheckBox[] dimGetGroup11;
        CheckBox[][] dimGetGroups;
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
        bool[] hcGroup00; bool[] hcGroup01; bool[] hcGroup02; bool[] hcGroup03; bool[] hcGroup04; bool[] hcGroup05;
        bool[] hcGroup06; bool[] hcGroup07; bool[] hcGroup08; bool[] hcGroup09; bool[] hcGroup10; bool[] hcGroup11;
        bool[][] hcGroups;
        CheckBox[] hcGetGroup00; CheckBox[] hcGetGroup01; CheckBox[] hcGetGroup02; CheckBox[] hcGetGroup03; CheckBox[] hcGetGroup04; CheckBox[] hcGetGroup05;
        CheckBox[] hcGetGroup06; CheckBox[] hcGetGroup07; CheckBox[] hcGetGroup08; CheckBox[] hcGetGroup09; CheckBox[] hcGetGroup10; CheckBox[] hcGetGroup11;
        CheckBox[][] hcGetGroups;
        ComboBox[] hc1OCAmpsQuick; TextBox[] hcOCAmps; ComboBox[] hcOCTime; ComboBox[] hcModesQuick; ComboBox[] hcStartupQuick; 
        CheckBox[] hcLock; TextBox[] hcPWMDuties; CheckBox[] hcPWMEnables; ComboBox[] hcDirections; ComboBox[] hcModeParam; ComboBox[] hcDeadTimes;
        ComboBox[] hcPaired; CheckBox[] hcTimeouts; TextBox[] hcTimeoutTimes; TextBox[] hcMaxOns; TextBox[] hcMaxDurRec; TextBox[] hcUndAmps; ComboBox[] hcMeasCurTimes;

        List<HCCard> hrObjects = new List<HCCard>();
        int HRCardActive;
        bool[] hrGroup00; bool[] hrGroup01; bool[] hrGroup02; bool[] hrGroup03; bool[] hrGroup04; bool[] hrGroup05; 
        bool[] hrGroup06; bool[] hrGroup07; bool[] hrGroup08; bool[] hrGroup09; bool[] hrGroup10; bool[] hrGroup11;
        bool[][] hrMasterGroups;
        CheckBox[] hrGetGroup00; CheckBox[] hrGetGroup01; CheckBox[] hrGetGroup02; CheckBox[] hrGetGroup03; CheckBox[] hrGetGroup04; CheckBox[] hrGetGroup05;
        CheckBox[] hrGetGroup06; CheckBox[] hrGetGroup07; CheckBox[] hrGetGroup08; CheckBox[] hrGetGroup09; CheckBox[] hrGetGroup10; CheckBox[] hrGetGroup11;
        CheckBox[][] hrGetGroups;
        Label[] hrChannelLabels;
        ComboBox[] hrOCAmpsQuick; TextBox[] hrOCAmps; ComboBox[] hrOCTime; ComboBox[] hrModesQuick; ComboBox[] hrStartupQuick;
        CheckBox[] hrLock; TextBox[] hrPWMDuties; ComboBox[] hrDirections; ComboBox[] hrModeParam; ComboBox[] hrDeadTimes;
        ComboBox[] hrPaired; CheckBox[] hrTimeouts; TextBox[] hrTimeoutTimes; TextBox[] hrMaxOns; TextBox[] hrMaxDurRec; TextBox[] hrUndAmps; ComboBox[] hrMeasCurTimes;

        List<LCCard> lcObjects = new List<LCCard>();
        int LCCardActive;
        bool[] lcGroup00; bool[] lcGroup01; bool[] lcGroup02; bool[] lcGroup03; bool[] lcGroup04; bool[] lcGroup05; bool[] lcGroup06; bool[] lcGroup07;
        bool[] lcGroup08; bool[] lcGroup09; bool[] lcGroup10; bool[] lcGroup11; bool[] lcGroup12; bool[] lcGroup13; bool[] lcGroup14; bool[] lcGroup15;
        bool[][] lcGroups;
        CheckBox[] lcGetGroup00; CheckBox[] lcGetGroup01; CheckBox[] lcGetGroup02; CheckBox[] lcGetGroup03; CheckBox[] lcGetGroup04; CheckBox[] lcGetGroup05; CheckBox[] lcGetGroup06; CheckBox[] lcGetGroup07;
        CheckBox[] lcGetGroup08; CheckBox[] lcGetGroup09; CheckBox[] lcGetGroup10; CheckBox[] lcGetGroup11; CheckBox[] lcGetGroup12; CheckBox[] lcGetGroup13; CheckBox[] lcGetGroup14; CheckBox[] lcGetGroup15;
        CheckBox[][] lcGetGroups;
        ComboBox[] lcOCAmps; ComboBox[] lcOCTime; ComboBox[] lcModesQuick; ComboBox[] lcIGNSafety; ComboBox[] lcParkSafety; ComboBox[] lcModeParam;
        ComboBox[] lcPairedTo; ComboBox[] lcDeadTime; ComboBox[] lcOverrideReverse; ComboBox[] lcOverrideForward; CheckBox[] lcLocks; ComboBox[] lcDirections; CheckBox[] lcAllowTimeout;
        TextBox[] lcTimeoutTimes; TextBox[] lcMaxOns; TextBox[] lcMaxDurRecoveries; TextBox[] lcUCAmps; ComboBox[] lcMeasCurTimes; CheckBox[] lcPWMEnable; ComboBox[] lcPWMFrequency;


        public Form1()
        {
            InitializeComponent();

            Load += new EventHandler(Form1_Load);

            int[] AuxColor = { 83, 52, 129 };
            int[] BreakerColor = { 217, 58, 78 };
            int[] DimmerColor = { 27, 161, 119 };
            int[] HCColor = { 24, 80, 135 };
            int[] LCColor = { 208, 110, 152 };
            AuxCardActive = 0;
            BrkCardActive = 0;
            DimCardActive = 0;
            HCCardActive = 0;
            HRCardActive = 0;
            LCCardActive = 0;
            PopulateArrays();
        }

        // @Utility ------------------------------------------------------ Utility

        private void BlankComboBox(ComboBox argComboBox)
        {
            argComboBox.ResetText();
            argComboBox.SelectedIndex = -1;
        }

        // @Menu --------------------------------------------------------- Menu
        private void HideNavButtons()
        {
            btnMenuAux.Visible = false;
            btnMenuBreaker.Visible = false;
            btnMenuDimmer.Visible = false;
            btnMenuHC.Visible = false;
            btnMenuHR.Visible = false;
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
            // currently just the program version number
            //ResetStartTab();
            //tabControlMain.SelectedIndex = (int) MainTab.Start;
        }

        private void btnMenuLoad_Click(object sender, EventArgs e)
        {
            // probably never going to get to the point where it can load files
        }

        private void btnMenuAux_Click(object sender, EventArgs e)
        {
            SetMenuColors(0);
            tabControlMain.SelectedIndex = (int) MainTab.Aux;
            //Aux_GetAll(AuxCardActive);
            AuxCardNavColor(auxBtnArray, auxBtnArray[AuxCardActive]);
            ShowAuxNav(cmbStartAux.SelectedIndex);
        }

        private void btnMenuBreaker_Click(object sender, EventArgs e)
        {
            SetMenuColors(1);
            tabControlMain.SelectedIndex = (int) MainTab.Breaker;
            //Brk_GetAll(BrkCardActive);
            BreakerCardNavColor(brkBtnArray, brkBtnArray[BrkCardActive]);
            ShowBreakerNav(cmbStartBreaker.SelectedIndex);
        }

        private void btnMenuDimmer_Click(object sender, EventArgs e)
        {
            SetMenuColors(2);
            tabControlMain.SelectedIndex = (int) MainTab.Dimmer;
            Dim_GetAll(DimCardActive);
            DimmerCardNavColor(dimBtnArray, dimBtnArray[DimCardActive]);
            ShowDimmerNav(cmbStartDimmer.SelectedIndex);
        }

        private void btnMenuHC_Click(object sender, EventArgs e)
        {
            SetMenuColors(3);
            tabControlMain.SelectedIndex = (int) MainTab.HC;
            HC_GetAll(HCCardActive);
            HCCardNavColor(hcBtnArray, hcBtnArray[HCCardActive]);
            ShowHCNav(cmbStartHC.SelectedIndex);
        }

        private void btnMenuHR_Click(object sender, EventArgs e)
        {
            SetMenuColors(5);
            tabControlMain.SelectedIndex = (int) MainTab.HCRelay;
            HR_GetAll(HRCardActive);
            HCCardNavColor(hrBtnArray, hrBtnArray[HRCardActive]);
            ShowHRNav(cmbStartHR.SelectedIndex);
        }

        private void btnMenuLC_Click(object sender, EventArgs e)
        {
            SetMenuColors(4);
            tabControlMain.SelectedIndex = (int) MainTab.LC;
            LC_GetAll(LCCardActive);
            LCCardNavColor(lcBtnArray, lcBtnArray[LCCardActive]);
            ShowLCNav(cmbStartLC.SelectedIndex);
        }

        private void SetMenuColors(int ButtonNum)
        {
            btnMenuAux.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuBreaker.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuDimmer.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuHC.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuHR.BackColor = Color.FromArgb(255, 20, 20, 20);
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

                case 5:
                    btnMenuHR.BackColor = Color.FromArgb(255, 24, 80, 135);
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
            tabControlMain.SelectedIndex = (int) MainTab.Blank;
            HideNavButtons();
            // had to put these in opposite order so they appear correctly in nav bar, I think because of top anchor
            ShowNavButton(btnMenuLC, cmbStartLC.SelectedIndex);
            ShowNavButton(btnMenuHR, cmbStartHR.SelectedIndex);
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
                dimmerObjects[i].M1_SetCfgRev(tbxStartDimCfgRev.Text);
            }

            for (int i = 0; i < cmbStartHC.SelectedIndex; i++)
            {
                hcObjects.Add(new HCCard(i + 1));
                hcObjects[i].M1_SetCfgRev(tbxStartHCCfgRev.Text);
            }

            for (int i = 0; i < cmbStartHR.SelectedIndex; i++)
            {
                hrObjects.Add(new HCCard(i + 1));
                hrObjects[i].M1_SetCfgRev(tbxStartHRCfgRev.Text);
            }

            for (int i = 0; i < cmbStartLC.SelectedIndex; i++)
            {
                lcObjects.Add(new LCCard(i + 1));
                lcObjects[i].M1_SetCfgRev(tbxStartLCCfgRev.Text);
            }

            // set Config Type here, don't need to mess with Get that adds "0x"
            //tbxAux1CfgType.Text = tbxStartCfgType.Text;
            //tbxBreaker1CfgType.Text = tbxStartCfgType.Text;
            tbxDimmer1CfgType.Text = tbxStartCfgType.Text;
            tbxHC1CfgType.Text = tbxStartCfgType.Text;
            tbxHRCfgType.Text = tbxStartCfgType.Text;
            tbxLC1CfgType.Text = tbxStartCfgType.Text;
            
        }

        private void ResetStartTab()
        {
            cmbStartAux.SelectedIndex = 0;
            cmbStartBreaker.SelectedIndex = 0;
            cmbStartDimmer.SelectedIndex = 0;
            cmbStartHC.SelectedIndex = 0;
            cmbStartHR.SelectedIndex = 0;
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

        private void ChangeChannelLabels(Label[] argLblArray, string baseIndexText)
        {
            int i = 0;
            foreach (Label label in argLblArray)
            {
                label.Text = ChangeChannelLabel(baseIndexText, i);
                i++;
            }
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
            CheckStartCreate();
        }

        private void cmbStartDimmer_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void tbxStartDimCfgRev_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void cmbStartHC_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void tbxStartHCCfgRev_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void cmbStartHR_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void tbxStartHRCfgRev_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void cmbStartLC_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void tbxStartLCCfgRev_TextChanged(object sender, EventArgs e)
        {
            CheckStartCreate();
        }

        private void CheckStartCreate()
        {
            int checkCount = 0;
            int numCards = 0;

            // Aux

            // Breaker

            // Dimmer
            if (cmbStartDimmer.Text != "0" && cmbStartDimmer.Text != "") { numCards++; }
            if (ValidateConfigRev(tbxStartDimCfgRev.Text)) { checkCount++; }

            // HC
            if (cmbStartHC.Text != "0" && cmbStartHC.Text != "") { numCards++; }
            if (ValidateConfigRev(tbxStartHCCfgRev.Text)) { checkCount++; }

            // HR
            if (cmbStartHR.Text != "0" && cmbStartHR.Text != "") { numCards++; }
            if (ValidateConfigRev(tbxStartHRCfgRev.Text)) { checkCount++; }

            // LC
            if (cmbStartLC.Text != "0" && cmbStartLC.Text != "") { numCards++; }
            if (ValidateConfigRev(tbxStartLCCfgRev.Text)) { checkCount++; }

            if (ValidateConfigType(tbxStartCfgType.Text) && checkCount == numCards && numCards != 0) { btnStartCreate.Visible = true; }
            else { btnStartCreate.Visible = false; }
        }

        private bool ValidateConfigRev(string argString)
        {
            byte[] asciiValue = Encoding.ASCII.GetBytes(argString);

            return asciiValue[0] >= 49 && asciiValue[0] < 58; // validates config rev first digit
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

            return characters == 4 && total >= 192 && total < 280; // must be 4 digit hex number, but 0xFFFF is not valid
        }

        private void ClearCardButtonColor(Button[] argBtnArray)
        {
            foreach (Button btn in argBtnArray)
            {
                btn.BackColor = Color.FromArgb(255, 20, 20, 20);
            }
        }


        /*         ###    ##     ## ##     ## 
                  ## ##   ##     ##  ##   ##  
                 ##   ##  ##     ##   ## ##   
                ##     ## ##     ##    ###    
                ######### ##     ##   ## ##   
                ##     ## ##     ##  ##   ##  
                ##     ##  #######  ##     ##          @Aux*/     

        private void btnAuxGenerate_Click(object sender, EventArgs e)
        {
            // need to set by channel but get by group
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
                    //auxObjects[card].M1_SetGroup0(auxGroups[card][channel], channel); // takes care of all 4 groups
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
            AuxCardNavColor(auxBtnArray, btnAuxGenerate);
            tabControlAux.SelectedIndex = 2;
            // prints the file context of the folder
            string[] auxFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_AuxCard\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxAuxGenerated.Lines = auxFiles;
        }

        private void CreateAuxReferenceFile() // card-specific because of the path, which is stored in each card object but isn't related to the Start tab combo box for that card type
        {
            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_AuxCard\DeviceConfigs\DevAddrConfigs.h"))
            {
                foreach (AuxCard card in auxObjects)
                {
                    sw.WriteLine("#include \"DevAddr" + card.M1_GetCardLetter() + ".h\"");
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
            AuxCardNavColor(auxBtnArray, btnAuxCard1);
            tabControlAux.SelectedIndex = 0;
            tabControlAux1QF.SelectedIndex = 0;
        }

        private void btnAuxCard2_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(auxBtnArray, btnAuxCard2);
            tabControlAux.SelectedIndex = 0;
            tabControlAux1QF.SelectedIndex = 0;
        }

        private void btnAuxCard3_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(auxBtnArray, btnAuxCard3);
        }

        private void btnAuxCard4_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(auxBtnArray, btnAuxCard4);
        }

        private void btnAuxCard5_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(auxBtnArray, btnAuxCard5);
        }

        private void btnAuxCard6_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(auxBtnArray, btnAuxCard6);
        }

        private void ShowAuxNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                auxBtnArray[i].Visible = true;
            }
        }

        private void AuxCardNavColor(Button[] argBtnArray, Button argButton)
        {
            ClearCardButtonColor(argBtnArray);
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

        private void chkTabVisAux1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTabVisAux1.Checked == true)
            {
                this.tabControlAux1QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlAux1QF.SelectedIndex = 0;
            }
        }


        // ########  ########  ########    ###    ##    ## ######## ########  
        // ##     ## ##     ## ##         ## ##   ##   ##  ##       ##     ## 
        // ##     ## ##     ## ##        ##   ##  ##  ##   ##       ##     ## 
        // ########  ########  ######   ##     ## #####    ######   ########  
        // ##     ## ##   ##   ##       ######### ##  ##   ##       ##   ##   
        // ##     ## ##    ##  ##       ##     ## ##   ##  ##       ##    ##  
        // ########  ##     ## ######## ##     ## ##    ## ######## ##     ## 
        // @Breaker

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
            BreakerCardNavColor(brkBtnArray, btnBreakerGenerate);
            tabControlBreaker.SelectedIndex = 5;
            // prints the file context of the folder
            string[] breakerFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_Breaker\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxBreakerGenerated.Lines = breakerFiles;
        }

        private void CreateBreakerReferenceFile() // card-specific because of the path, which is stored in each card object but isn't related to the Start tab combo box for that card type
        {
            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_Breaker\DeviceConfigs\DevAddrConfigs.h"))
            {
                foreach (BreakerCard card in breakerObjects)
                {
                    sw.WriteLine("#include \"DevAddr" + card.M1_GetCardLetter() + ".h\"");
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
            BreakerCardNavColor(brkBtnArray, btnBreakerCard1);
            tabControlBreaker.SelectedIndex = 1;/*
            tabControlBreaker1QF.SelectedIndex = 0;*/
        }

        private void btnBreakerCard2_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(brkBtnArray, btnBreakerCard2);
            tabControlBreaker.SelectedIndex = 2;
        }

        private void btnBreakerCard3_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(brkBtnArray, btnBreakerCard3);
            tabControlBreaker.SelectedIndex = 3;
        }

        private void btnBreakerCard4_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(brkBtnArray, btnBreakerCard4);
            tabControlBreaker.SelectedIndex = 4;
        }

        private void btnBreakerCard5_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(brkBtnArray, btnBreakerCard5);
        }

        private void btnBreakerCard6_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(brkBtnArray, btnBreakerCard6);
        }

        private void ShowBreakerNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                brkBtnArray[i].Visible = true;
            }
        }

        private void BreakerCardNavColor(Button[] argBtnArray, Button argButton)
        {
            ClearCardButtonColor(argBtnArray);
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

        private void chkTabVisBreaker1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTabVisBreaker1.Checked == true)
            {
                this.tabControlBreaker1QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlBreaker1QF.SelectedIndex = 0;
            }
        }



        /*      ########  #### ##     ## ##     ## ######## ########  
                ##     ##  ##  ###   ### ###   ### ##       ##     ## 
                ##     ##  ##  #### #### #### #### ##       ##     ## 
                ##     ##  ##  ## ### ## ## ### ## ######   ########  
                ##     ##  ##  ##     ## ##     ## ##       ##   ##   
                ##     ##  ##  ##     ## ##     ## ##       ##    ##  
                ########  #### ##     ## ##     ## ######## ##     ##       @Dimmer  */


        public void Dim_SetAll(int card)
        {
            // need to set by channel but get by group
            dimGroup00 = new bool[] { chkDimmer1MG1Ch00.Checked, chkDimmer1MG2Ch00.Checked, chkDimmer1MG3Ch00.Checked, chkDimmer1MG4Ch00.Checked };
            dimGroup01 = new bool[] { chkDimmer1MG1Ch01.Checked, chkDimmer1MG2Ch01.Checked, chkDimmer1MG3Ch01.Checked, chkDimmer1MG4Ch01.Checked };
            dimGroup02 = new bool[] { chkDimmer1MG1Ch02.Checked, chkDimmer1MG2Ch02.Checked, chkDimmer1MG3Ch02.Checked, chkDimmer1MG4Ch02.Checked };
            dimGroup03 = new bool[] { chkDimmer1MG1Ch03.Checked, chkDimmer1MG2Ch03.Checked, chkDimmer1MG3Ch03.Checked, chkDimmer1MG4Ch03.Checked };
            dimGroup04 = new bool[] { chkDimmer1MG1Ch04.Checked, chkDimmer1MG2Ch04.Checked, chkDimmer1MG3Ch04.Checked, chkDimmer1MG4Ch04.Checked };
            dimGroup05 = new bool[] { chkDimmer1MG1Ch05.Checked, chkDimmer1MG2Ch05.Checked, chkDimmer1MG3Ch05.Checked, chkDimmer1MG4Ch05.Checked };
            dimGroup06 = new bool[] { chkDimmer1MG1Ch06.Checked, chkDimmer1MG2Ch06.Checked, chkDimmer1MG3Ch06.Checked, chkDimmer1MG4Ch06.Checked };
            dimGroup07 = new bool[] { chkDimmer1MG1Ch07.Checked, chkDimmer1MG2Ch07.Checked, chkDimmer1MG3Ch07.Checked, chkDimmer1MG4Ch07.Checked };
            dimGroup08 = new bool[] { chkDimmer1MG1Ch08.Checked, chkDimmer1MG2Ch08.Checked, chkDimmer1MG3Ch08.Checked, chkDimmer1MG4Ch08.Checked };
            dimGroup09 = new bool[] { chkDimmer1MG1Ch09.Checked, chkDimmer1MG2Ch09.Checked, chkDimmer1MG3Ch09.Checked, chkDimmer1MG4Ch09.Checked };
            dimGroup10 = new bool[] { chkDimmer1MG1Ch10.Checked, chkDimmer1MG2Ch10.Checked, chkDimmer1MG3Ch10.Checked, chkDimmer1MG4Ch10.Checked };
            dimGroup11 = new bool[] { chkDimmer1MG1Ch11.Checked, chkDimmer1MG2Ch11.Checked, chkDimmer1MG3Ch11.Checked, chkDimmer1MG4Ch11.Checked };
            dimGroups = new bool[][] { dimGroup00, dimGroup01, dimGroup02, dimGroup03, dimGroup04, dimGroup05, dimGroup06, dimGroup07, dimGroup08, dimGroup09, dimGroup10, dimGroup11 };

            dimmerObjects[card].M1_SetVerRev(btnMenuNew.Text);
            dimmerObjects[card].M1_SetFullSetup(chkTabVisDimmer1.Checked);
            dimmerObjects[card].M1_SetCardNumber(cmbDimmer1CardNum.Text);
            dimmerObjects[card].M1_SetPanelNumber(cmbDimmer1PanelNum.Text);
            dimmerObjects[card].M1_SetDevAddr();
            dimmerObjects[card].M1_SetCardLetter(tbxDimmer1CardLetter.Text);
            dimmerObjects[card].M1_ChangeConfigName();
            dimmerObjects[card].Dimmer_ChangeAddress();
            dimmerObjects[card].M1_SetCfgRev(tbxDimmer1CfgRev.Text);
            dimmerObjects[card].M1_SetCfgType(tbxDimmer1CfgType.Text);
            dimmerObjects[card].M1_SetDCDimmer(true); // hard coding for dimmer card
            dimmerObjects[card].M1_SetDCMotor(chkDimmer1DCMotor.Checked);
            dimmerObjects[card].M1_SetShade(chkDimmer1Shade.Checked);
            dimmerObjects[card].M1_SetForce(chkDimmer1Force.Checked);
            dimmerObjects[card].M1_SetBaseIndex(tbxDimmer1BaseIndex.Text);
            for (int channel = 0; channel < 12; channel++)
            {
                dimmerObjects[card].Dimmer_SetOCAmps(channel, dimmerOCAmps[channel].Text);
                dimmerObjects[card].Dimmer_SetOCTime(channel, dimmerOCTime[channel].Text);
                dimmerObjects[card].M1_SetGroup0(dimGroups[channel], channel); // takes care of all 4 groups
                dimmerObjects[card].Dimmer_SetLock(channel, dimmerLocks[channel].Checked);
                dimmerObjects[card].Dimmer_SetPWMFreq(channel, dimmerPWMFreq[channel].Text);
                dimmerObjects[card].Dimmer_SetPWMDuty(channel, dimmerPWMDuties[channel].Text);
                dimmerObjects[card].Dimmer_SetPWMEnable(channel, dimmerPWMEnables[channel].Checked);
                dimmerObjects[card].Dimmer_SetOverride(channel, dimmerOverrides[channel].Checked);
                dimmerObjects[card].Dimmer_SetTimeout(channel, dimmerTimeouts[channel].Checked);
                dimmerObjects[card].Dimmer_SetDirection(channel, dimmerDirections[channel].Text);
                dimmerObjects[card].Dimmer_SetTimeoutTime(channel, dimmerTimeoutTimes[channel].Text);
                dimmerObjects[card].Dimmer_SetMaxOn(channel, dimmerMaxOns[channel].Text);
                dimmerObjects[card].Dimmer_SetMaxDurRec(channel, dimmerMaxDurRecs[channel].Text);
                dimmerObjects[card].Dimmer_SetMeasuredCurrTimeConst(channel, dimmerMeasCurTimes[channel].Text);
                dimmerObjects[card].Dimmer_SetUCAmps(channel, dimmerUCAmps[channel].Text);
            }
        }

        public void Dim_GetAll(int card)
        {
            chkTabVisDimmer1.Checked    = dimmerObjects[card].M1_GetFullSetup();
            if (dimmerObjects[card].M1_GetCardNumber() == "") { BlankComboBox(cmbDimmer1CardNum); }
            else { cmbDimmer1CardNum.Text = dimmerObjects[card].M1_GetCardNumber(); }
            if (dimmerObjects[card].M1_GetPanelNumber() == "") { BlankComboBox(cmbDimmer1PanelNum); }
            else { cmbDimmer1PanelNum.Text = dimmerObjects[card].M1_GetPanelNumber(); }
            tbxDimmer1CfgRev.Text       = dimmerObjects[card].M1_GetCfgRev();
            tbxDimmer1CardLetter.Text   = dimmerObjects[card].M1_GetCardLetter();
            chkDimmer1DCMotor.Checked   = dimmerObjects[card].M1_GetDCMotor();
            chkDimmer1Shade.Checked     = dimmerObjects[card].M1_GetShade();
            chkDimmer1Force.Checked     = dimmerObjects[card].M1_GetForce();
            tbxDimmer1BaseIndex.Text    = dimmerObjects[card].M1_GetBaseIndex();
            for (int channel = 0; channel < 12; channel++)
            {
                dimmerOCAmps[channel].Text          = dimmerObjects[card].Dimmer_GetOCAmps(channel);
                dimmerOCTime[channel].Text          = dimmerObjects[card].Dimmer_GetOCTime(channel);
                dimGetGroups[channel][0].Checked    = dimmerObjects[card].M1_GetGroup0(channel);
                dimGetGroups[channel][1].Checked    = dimmerObjects[card].M1_GetGroup1(channel);
                dimGetGroups[channel][2].Checked    = dimmerObjects[card].M1_GetGroup2(channel);
                dimGetGroups[channel][3].Checked    = dimmerObjects[card].M1_GetGroup3(channel);
                dimmerLocks[channel].Checked        = dimmerObjects[card].Dimmer_GetLock(channel);
                dimmerPWMFreq[channel].Text         = dimmerObjects[card].Dimmer_GetPWMFreq(channel);
                dimmerPWMDuties[channel].Text       = dimmerObjects[card].Dimmer_GetPWMDuty(channel);
                dimmerPWMEnables[channel].Checked   = dimmerObjects[card].Dimmer_GetPWMEnable(channel);
                dimmerOverrides[channel].Checked    = dimmerObjects[card].Dimmer_GetOverride(channel);
                dimmerTimeouts[channel].Checked     = dimmerObjects[card].Dimmer_GetTimeout(channel);
                dimmerDirections[channel].Text      = dimmerObjects[card].Dimmer_GetDirection(channel);
                dimmerTimeoutTimes[channel].Text    = dimmerObjects[card].Dimmer_GetTimeoutTime(channel);
                dimmerMaxOns[channel].Text          = dimmerObjects[card].Dimmer_GetMaxOn(channel);
                dimmerMaxDurRecs[channel].Text      = dimmerObjects[card].Dimmer_GetMaxDurRec(channel);
                dimmerMeasCurTimes[channel].Text    = dimmerObjects[card].Dimmer_GetMeasuredCurrTimeConst(channel);
                dimmerUCAmps[channel].Text          = dimmerObjects[card].Dimmer_GetUCAmps(channel);
            }
        }

        private void btnDimmerGenerate_Click(object sender, EventArgs e)
        {
            Dim_SetAll(DimCardActive);
            dimmerObjects.ForEach(dimmerObjects => dimmerObjects.Dimmer_CreateFile());
            CreateDimmerReferenceFile();
            DimmerCardNavColor(dimBtnArray, btnDimmerGenerate);
            tabControlDimmer.SelectedIndex = 1;
            // prints the file context of the folder
            string[] dimmerFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_Dimmer\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxDimmerGenerated.Lines = dimmerFiles;
        }

        private void CreateDimmerReferenceFile() // card-specific because of the path, which is stored in each card object but isn't related to the Start tab combo box for that card type
        {
            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_Dimmer\DeviceConfigs\DevAddrConfigs.h"))
            {
                foreach (DimmerCard card in dimmerObjects)
                {
                    sw.WriteLine("#include \"DevAddr" + card.M1_GetCardLetter() + ".h\"");
                }
            }
        }

        private void CheckDimGenerate()
        {   
            int checkCounter = 0;
            int numDimCards = Convert.ToInt16(cmbStartDimmer.Text);

            for (int i = 0; i < numDimCards; i++)
            {
                if (dimmerObjects[i].M1_GetCardNumber() != "" && dimmerObjects[i].M1_GetPanelNumber() != "" && dimmerObjects[i].M1_GetBaseIndex() != "") 
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

        private void btnDimmerCard1_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard1);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card1;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1: 0);
        }

        private void btnDimmerCard2_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard2);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card2;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void btnDimmerCard3_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard3);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card3;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void btnDimmerCard4_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard4);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card4;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void btnDimmerCard5_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard5);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card5;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void btnDimmerCard6_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard6);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card6;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void btnDimmerCard7_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard7);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card7;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void btnDimmerCard8_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(dimBtnArray, btnDimmerCard8);
            tabControlDimmer.SelectedIndex = 0;
            Dim_SetAll(DimCardActive);
            DimCardActive = (int) CardNum.Card8;
            Dim_GetAll(DimCardActive);
            tabControlDimmer1QF.SelectedIndex = (chkTabVisDimmer1.Checked == true ? 1 : 0);
        }

        private void ShowDimmerNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
               dimBtnArray[i].Visible = true;
            }
        }

        private void DimmerCardNavColor(Button[] argBtnArray, Button argButton)
        {
            ClearCardButtonColor(argBtnArray);
            argButton.BackColor = Color.FromArgb(255, 27, 161, 119);
        }

        private void cmbDimmer1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            dimmerObjects[DimCardActive].M1_SetCardNumber(cmbDimmer1CardNum.Text);
            CheckDimGenerate();
        }

        private void cmbDimmer1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            dimmerObjects[DimCardActive].M1_SetPanelNumber(cmbDimmer1PanelNum.Text);
            CheckDimGenerate();
        }


        private void tbxDimmer1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            dimmerObjects[DimCardActive].M1_SetBaseIndex(tbxDimmer1BaseIndex.Text);
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

        private void chkTabVisDimmer1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTabVisDimmer1.Checked == true)
            {
                this.tabControlDimmer1QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlDimmer1QF.SelectedIndex = 0;
            }
        }



        /*      ##     ##  ######  
                ##     ## ##    ## 
                ##     ## ##       
                ######### ##       
                ##     ## ##       
                ##     ## ##    ## 
                ##     ##  ######     @HC */



        public void HC_SetAll(int card)
        {
            // When generate is clicked, load necessary checkbox states into arrays to be used to set parameters on each card
            hcGroup00 = new bool[] { chkHC1MG1Ch00.Checked, chkHC1MG2Ch00.Checked, chkHC1MG3Ch00.Checked, chkHC1MG4Ch00.Checked };
            hcGroup01 = new bool[] { chkHC1MG1Ch01.Checked, chkHC1MG2Ch01.Checked, chkHC1MG3Ch01.Checked, chkHC1MG4Ch01.Checked };
            hcGroup02 = new bool[] { chkHC1MG1Ch02.Checked, chkHC1MG2Ch02.Checked, chkHC1MG3Ch02.Checked, chkHC1MG4Ch02.Checked };
            hcGroup03 = new bool[] { chkHC1MG1Ch03.Checked, chkHC1MG2Ch03.Checked, chkHC1MG3Ch03.Checked, chkHC1MG4Ch03.Checked };
            hcGroup04 = new bool[] { chkHC1MG1Ch04.Checked, chkHC1MG2Ch04.Checked, chkHC1MG3Ch04.Checked, chkHC1MG4Ch04.Checked };
            hcGroup05 = new bool[] { chkHC1MG1Ch05.Checked, chkHC1MG2Ch05.Checked, chkHC1MG3Ch05.Checked, chkHC1MG4Ch05.Checked };
            hcGroup06 = new bool[] { chkHC1MG1Ch06.Checked, chkHC1MG2Ch06.Checked, chkHC1MG3Ch06.Checked, chkHC1MG4Ch06.Checked };
            hcGroup07 = new bool[] { chkHC1MG1Ch07.Checked, chkHC1MG2Ch07.Checked, chkHC1MG3Ch07.Checked, chkHC1MG4Ch07.Checked };
            hcGroup08 = new bool[] { chkHC1MG1Ch08.Checked, chkHC1MG2Ch08.Checked, chkHC1MG3Ch08.Checked, chkHC1MG4Ch08.Checked };
            hcGroup09 = new bool[] { chkHC1MG1Ch09.Checked, chkHC1MG2Ch09.Checked, chkHC1MG3Ch09.Checked, chkHC1MG4Ch09.Checked };
            hcGroup10 = new bool[] { chkHC1MG1Ch10.Checked, chkHC1MG2Ch10.Checked, chkHC1MG3Ch10.Checked, chkHC1MG4Ch10.Checked };
            hcGroup11 = new bool[] { chkHC1MG1Ch11.Checked, chkHC1MG2Ch11.Checked, chkHC1MG3Ch11.Checked, chkHC1MG4Ch11.Checked };
            hcGroups = new bool[][] { hcGroup00, hcGroup01, hcGroup02, hcGroup03, hcGroup04, hcGroup05, hcGroup06, hcGroup07, hcGroup08, hcGroup09, hcGroup10, hcGroup11 };
            hcObjects[card].M1_SetVerRev(btnMenuNew.Text);
            hcObjects[card].M1_SetFullSetup(chkTabVisHC1.Checked);
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
                hcObjects[card].HC_SetQuickMode(channel, hcModesQuick[channel].Text);
                hcObjects[card].HC_SetQuickStartup(channel, hcStartupQuick[channel].Text);
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
                hcObjects[card].M1_SetGroup0(hcGroups[channel], channel); // takes care of all 4 groups
                hcObjects[card].HC_SetOCAmps(channel, hcOCAmps[channel].Text);
                hcObjects[card].HC_SetUndAmp(channel, hcUndAmps[channel].Text);
                hcObjects[card].HC_SetOCTime(channel, hcOCTime[channel].Text);
                hcObjects[card].HC_SetMeasCurTime(channel, hcMeasCurTimes[channel].Text);
            }
        }

        public void HC_GetAll(int card)
        {
            chkTabVisHC1.Checked = hcObjects[card].M1_GetFullSetup();
            if (hcObjects[card].M1_GetCardNumber() == "") 
            {
                BlankComboBox(cmbHC1CardNum);
            } 
            else { cmbHC1CardNum.Text = hcObjects[card].M1_GetCardNumber(); }
            if (hcObjects[card].M1_GetPanelNumber() == "") 
            {
                BlankComboBox(cmbHC1PanelNum);
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
                if (hcObjects[card].HC_GetQuickOCAmps(channel) == "")
                {
                    BlankComboBox(hc1OCAmpsQuick[channel]);
                }
                else { hc1OCAmpsQuick[channel].Text = hcObjects[card].HC_GetQuickOCAmps(channel); }
                if (hcObjects[card].HC_GetQuickMode(channel) == "")
                {
                    BlankComboBox(hcModesQuick[channel]);
                }
                else { hcModesQuick[channel].Text = hcObjects[card].HC_GetQuickMode(channel); }
                if (hcObjects[card].HC_GetQuickStartup(channel) == "")
                {
                    BlankComboBox(hcStartupQuick[channel]);
                }
                else { hcStartupQuick[channel].Text = hcObjects[card].HC_GetQuickStartup(channel); }
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
                hcOCAmps[channel].Text = hcObjects[card].HC_GetOCAmps(channel);
                hcUndAmps[channel].Text = hcObjects[card].HC_GetUndAmp(channel);
                hcOCTime[channel].Text = hcObjects[card].HC_GetOCTime(channel);
                hcMeasCurTimes[channel].Text = hcObjects[card].HC_GetMeasCurTime(channel);
                hcGetGroups[channel][0].Checked = hcObjects[card].M1_GetGroup0(channel);
                hcGetGroups[channel][1].Checked = hcObjects[card].M1_GetGroup1(channel);
                hcGetGroups[channel][2].Checked = hcObjects[card].M1_GetGroup2(channel);
                hcGetGroups[channel][3].Checked = hcObjects[card].M1_GetGroup3(channel);
            }
        }

        private void btnHCGenerate_Click(object sender, EventArgs e)
        {
            // HC cards
            HC_SetAll(HCCardActive);
            hcObjects.ForEach(hcObjects => hcObjects.HC_CreateFile());
            CreateHCReferenceFile();
            HCCardNavColor(hcBtnArray, btnHCGenerate);
            tabControlHC.SelectedIndex = 1;
            // prints the file context of the folder
            string[] hcFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxHCGenerated.Lines = hcFiles;
        }

        private void CreateHCReferenceFile()
        {
            using (StreamWriter sw = File.AppendText(@"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\DevAddrConfigs.h"))
            {
                foreach (HCCard card in hcObjects)
                {
                    sw.WriteLine("#include \"DevAddr" + card.M1_GetCardLetter() + ".h\"");
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
            HCCardNavColor(hcBtnArray, btnHCCard1);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card1;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void btnHCCard2_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard2);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card2;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void btnHCCard3_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard3);
            tabControlHC.SelectedIndex = 0;
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card3;
            HC_GetAll(HCCardActive);
        }

        private void btnHCCard4_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard4);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card4;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void btnHCCard5_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard5);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card5;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void btnHCCard6_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard6);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card6;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void btnHCCard7_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard7);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card7;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void btnHCCard8_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hcBtnArray, btnHCCard8);
            tabControlHC.SelectedIndex = 0;
            HC_SetAll(HCCardActive);
            HCCardActive = (int) CardNum.Card8;
            HC_GetAll(HCCardActive);
            tabControlHC1QF.SelectedIndex = (chkTabVisHC1.Checked == true ? 1 : 0);
        }

        private void ShowHCNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                hcBtnArray[i].Visible = true;
            }
        }

        private void HCCardNavColor(Button[] argBtnArray, Button argButton)
        {
            ClearCardButtonColor(argBtnArray);
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
                cmbHC1DeadTimeCh01.Text = "500"; 
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
                cmbHC1DeadTimeCh02.Text = "500"; 
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
                cmbHC1DeadTimeCh03.Text = "500"; 
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
                cmbHC1DeadTimeCh04.Text = "500"; 
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
                cmbHC1DeadTimeCh05.Text = "500"; 
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
                cmbHC1DeadTimeCh06.Text = "500"; 
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
                cmbHC1DeadTimeCh07.Text = "500"; 
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
                cmbHC1DeadTimeCh08.Text = "500"; 
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
                cmbHC1DeadTimeCh09.Text = "500"; 
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
                cmbHC1DeadTimeCh10.Text = "500"; 
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
                cmbHC1DeadTimeCh11.Text = "500"; 
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



        /*      ##     ##  ######     ########  ######## ##          ###    ##    ## 
                ##     ## ##    ##    ##     ## ##       ##         ## ##    ##  ##  
                ##     ## ##          ##     ## ##       ##        ##   ##    ####   
                ######### ##          ########  ######   ##       ##     ##    ##    
                ##     ## ##          ##   ##   ##       ##       #########    ##    
                ##     ## ##    ##    ##    ##  ##       ##       ##     ##    ##    
                ##     ##  ######     ##     ## ######## ######## ##     ##    ##    @HR */

        public void HR_SetAll(int card)
        {
            // When generate is clicked, load necessary checkbox states into arrays to be used to set parameters on each card
            hrGroup00 = new bool[] { chkHRMG1Ch00.Checked, chkHRMG2Ch00.Checked, chkHRMG3Ch00.Checked, chkHRMG4Ch00.Checked };
            hrGroup01 = new bool[] { chkHRMG1Ch01.Checked, chkHRMG2Ch01.Checked, chkHRMG3Ch01.Checked, chkHRMG4Ch01.Checked };
            hrGroup02 = new bool[] { chkHRMG1Ch02.Checked, chkHRMG2Ch02.Checked, chkHRMG3Ch02.Checked, chkHRMG4Ch02.Checked };
            hrGroup03 = new bool[] { chkHRMG1Ch03.Checked, chkHRMG2Ch03.Checked, chkHRMG3Ch03.Checked, chkHRMG4Ch03.Checked };
            hrGroup04 = new bool[] { chkHRMG1Ch04.Checked, chkHRMG2Ch04.Checked, chkHRMG3Ch04.Checked, chkHRMG4Ch04.Checked };
            hrGroup05 = new bool[] { chkHRMG1Ch05.Checked, chkHRMG2Ch05.Checked, chkHRMG3Ch05.Checked, chkHRMG4Ch05.Checked };
            hrGroup06 = new bool[] { chkHRMG1Ch06.Checked, chkHRMG2Ch06.Checked, chkHRMG3Ch06.Checked, chkHRMG4Ch06.Checked };
            hrGroup07 = new bool[] { chkHRMG1Ch07.Checked, chkHRMG2Ch07.Checked, chkHRMG3Ch07.Checked, chkHRMG4Ch07.Checked };
            hrGroup08 = new bool[] { chkHRMG1Ch08.Checked, chkHRMG2Ch08.Checked, chkHRMG3Ch08.Checked, chkHRMG4Ch08.Checked };
            hrGroup09 = new bool[] { chkHRMG1Ch09.Checked, chkHRMG2Ch09.Checked, chkHRMG3Ch09.Checked, chkHRMG4Ch09.Checked };
            hrGroup10 = new bool[] { chkHRMG1Ch10.Checked, chkHRMG2Ch10.Checked, chkHRMG3Ch10.Checked, chkHRMG4Ch10.Checked };
            hrGroup11 = new bool[] { chkHRMG1Ch11.Checked, chkHRMG2Ch11.Checked, chkHRMG3Ch11.Checked, chkHRMG4Ch11.Checked };
            hrMasterGroups = new bool[][] { hrGroup00, hrGroup01, hrGroup02, hrGroup03, hrGroup04, hrGroup05, hrGroup06, hrGroup07, hrGroup08, hrGroup09, hrGroup10, hrGroup11 };
            hrObjects[card].M1_SetVerRev(btnMenuNew.Text);
            hrObjects[card].M1_SetFullSetup(chkHRTabVis.Checked);
            hrObjects[card].M1_SetCardNumber(cmbHRCardNum.Text);
            hrObjects[card].M1_SetPanelNumber(cmbHRPanelNum.Text);
            hrObjects[card].M1_SetDevAddr();
            hrObjects[card].M1_SetCardLetter(tbxHRCardLetter.Text);
            hrObjects[card].M1_ChangeConfigName();
            hrObjects[card].HC_ChangeAddress();
            hrObjects[card].M1_SetCfgRev(tbxHRCfgRev.Text);
            hrObjects[card].M1_SetCfgType(tbxHRCfgType.Text);
            hrObjects[card].M1_SetDCMotor(chkHRDCMotor.Checked);
            hrObjects[card].M1_SetDCDimmer(chkHRDCDimmer.Checked);
            hrObjects[card].M1_SetShade(chkHRShade.Checked);
            hrObjects[card].M1_SetForce(chkHRForce.Checked);
            hrObjects[card].M1_SetBaseIndex(tbxHRBaseInstance.Text);
            for (int channel = 0; channel < 12; channel++)
            {
                hrObjects[card].HC_SetQuickMode(channel, hrModesQuick[channel].Text);
                hrObjects[card].HC_SetQuickStartup(channel, hrStartupQuick[channel].Text);
                hrObjects[card].HC_SetLock(channel, hrLock[channel].Checked);
                hrObjects[card].HC_SetPWMDuty(channel, hrPWMDuties[channel].Text);
                hrObjects[card].HC_SetDirection(channel, hrDirections[channel].Text);
                hrObjects[card].HC_SetMode(channel, hrModeParam[channel].Text);
                hrObjects[card].HC_SetDeadTime(channel, hrDeadTimes[channel].Text);
                hrObjects[card].HC_SetPaired(channel, hrPaired[channel].Text);
                hrObjects[card].HC_SetTimeout(channel, hrTimeouts[channel].Checked);
                hrObjects[card].HC_SetTimeoutTime(channel, hrTimeoutTimes[channel].Text);
                hrObjects[card].HC_SetMaxOn(channel, hrMaxOns[channel].Text);
                hrObjects[card].HC_SetMaxDurRec(channel, hrMaxDurRec[channel].Text);
                hrObjects[card].M1_SetGroup0(hrMasterGroups[channel], channel); // takes care of all 4 groups
                hrObjects[card].HC_SetOCAmps(channel, hrOCAmps[channel].Text);
                hrObjects[card].HC_SetUndAmp(channel, hrUndAmps[channel].Text);
                hrObjects[card].HC_SetOCTime(channel, hrOCTime[channel].Text);
                hrObjects[card].HC_SetMeasCurTime(channel, hrMeasCurTimes[channel].Text);
            }
        }

        public void HR_GetAll(int card)
        {
            chkHRTabVis.Checked = hrObjects[card].M1_GetFullSetup();
            if (hrObjects[card].M1_GetCardNumber() == "")
            {
                BlankComboBox(cmbHRCardNum);
            }
            else { cmbHRCardNum.Text = hrObjects[card].M1_GetCardNumber(); }
            if (hrObjects[card].M1_GetPanelNumber() == "")
            {
                BlankComboBox(cmbHRPanelNum);
            }
            else { cmbHRPanelNum.Text = hrObjects[card].M1_GetPanelNumber(); }
            tbxHRCfgRev.Text = hrObjects[card].M1_GetCfgRev();
            tbxHRCardLetter.Text = hrObjects[card].M1_GetCardLetter();
            chkHRDCMotor.Checked = hrObjects[card].M1_GetDCMotor();
            chkHRDCDimmer.Checked = hrObjects[card].M1_GetDCDimmer();
            chkHRShade.Checked = hrObjects[card].M1_GetShade();
            chkHRForce.Checked = hrObjects[card].M1_GetForce();
            tbxHRBaseInstance.Text = hrObjects[card].M1_GetBaseIndex();
            for (int channel = 0; channel < 12; channel++)
            {
                if (hrObjects[card].HC_GetQuickOCAmps(channel) == "")
                {
                    BlankComboBox(hrOCAmpsQuick[channel]);
                }
                else { hrOCAmpsQuick[channel].Text = hrObjects[card].HC_GetQuickOCAmps(channel); }
                if (hrObjects[card].HC_GetQuickMode(channel) == "")
                {
                    BlankComboBox(hrModesQuick[channel]);
                }
                else { hrModesQuick[channel].Text = hrObjects[card].HC_GetQuickMode(channel); }
                if (hrObjects[card].HC_GetQuickStartup(channel) == "")
                {
                    BlankComboBox(hrStartupQuick[channel]);
                }
                else { hrStartupQuick[channel].Text = hrObjects[card].HC_GetQuickStartup(channel); }
                hrLock[channel].Checked = hrObjects[card].HC_GetLock(channel);
                hrPWMDuties[channel].Text = hrObjects[card].HC_GetPWMDuty(channel);
                hrDirections[channel].Text = hrObjects[card].HC_GetDirection(channel);
                hrModeParam[channel].Text = hrObjects[card].HC_GetMode(channel);
                hrDeadTimes[channel].Text = hrObjects[card].HC_GetDeadTime(channel);
                hrPaired[channel].Text = hrObjects[card].HC_GetPaired(channel);
                hrTimeouts[channel].Checked = hrObjects[card].HC_GetTimeout(channel);
                hrTimeoutTimes[channel].Text = hrObjects[card].HC_GetTimeoutTime(channel);
                hrMaxOns[channel].Text = hrObjects[card].HC_GetMaxOn(channel);
                hrMaxDurRec[channel].Text = hrObjects[card].HC_GetMaxDurRec(channel);
                hrOCAmps[channel].Text = hrObjects[card].HC_GetOCAmps(channel);
                hrUndAmps[channel].Text = hrObjects[card].HC_GetUndAmp(channel);
                hrOCTime[channel].Text = hrObjects[card].HC_GetOCTime(channel);
                hrMeasCurTimes[channel].Text = hrObjects[card].HC_GetMeasCurTime(channel);
                hrGetGroups[channel][0].Checked = hrObjects[card].M1_GetGroup0(channel);
                hrGetGroups[channel][1].Checked = hrObjects[card].M1_GetGroup1(channel);
                hrGetGroups[channel][2].Checked = hrObjects[card].M1_GetGroup2(channel);
                hrGetGroups[channel][3].Checked = hrObjects[card].M1_GetGroup3(channel);
            }
        }

        private void CreateHRReferenceFile()
        {
            using (StreamWriter sw = File.AppendText(@"M1_DcDriver_Config\Src\M1_HC_Relay\DeviceConfigs\DevAddrConfigs.h"))
            {
                foreach (HCCard card in hrObjects)
                {
                    sw.WriteLine("#include \"DevAddr" + card.M1_GetCardLetter() + ".h\"");
                }
            }
        }

        private void CheckHRGenerate()
        {
            int checkCounter = 0;
            int numHRCards = Convert.ToInt16(cmbStartHR.Text);

            for (int i = 0; i < numHRCards; i++)
            {
                if (hrObjects[i].M1_GetCardNumber() != "" && hrObjects[i].M1_GetPanelNumber() != "" && hrObjects[i].M1_GetBaseIndex() != "")
                {
                    checkCounter++;
                }
            }

            if (checkCounter == numHRCards)
            {
                btnHRGenerate.Visible = true;
            }
            else
            {
                btnHRGenerate.Visible = false;
            }
        }

        private void btnHRCard1_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard1);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card1;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard2_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard2);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card2;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard3_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard3);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card3;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard4_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard4);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card4;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard5_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard5);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card5;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard6_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard6);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card6;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard7_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard7);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card7;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRCard8_Click(object sender, EventArgs e)
        {
            HCCardNavColor(hrBtnArray, btnHRCard8);
            tabControlHR.SelectedIndex = 0;
            HR_SetAll(HRCardActive);
            HRCardActive = (int)CardNum.Card8;
            HR_GetAll(HRCardActive);
            tabControlHRQF.SelectedIndex = (chkHRTabVis.Checked == true ? 1 : 0);
        }

        private void btnHRGenerate_Click(object sender, EventArgs e)
        {
            HR_SetAll(HRCardActive);
            hrObjects.ForEach(hrObjects => hrObjects.HR_CreateFile());
            CreateHRReferenceFile();
            HCCardNavColor(hrBtnArray, btnHRGenerate);
            tabControlHR.SelectedIndex = 1;
            // prints the file context of the folder
            string[] hrFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_HC_Relay\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxHRGenerated.Lines = hrFiles;
        }

        private void ShowHRNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                hrBtnArray[i].Visible = true;
            }
        }

        private void cmbHRCardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            hrObjects[HRCardActive].M1_SetCardNumber(cmbHRCardNum.Text);
            CheckHRGenerate();
        }

        private void cmbHRPanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            hrObjects[HRCardActive].M1_SetPanelNumber(cmbHRCardNum.Text);
            CheckHRGenerate();
        }

        private void tbxHRBaseInstance_TextChanged(object sender, EventArgs e)
        {
            hrObjects[HRCardActive].M1_SetBaseIndex(tbxHRBaseInstance.Text);
            ChangeChannelLabels(hrChannelLabels, tbxHRBaseInstance.Text);
            CheckHRGenerate();
        }

        private void chkHRTabVis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHRTabVis.Checked == true)
            {
                this.tabControlHRQF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlHRQF.SelectedIndex = 0;
            }
        }

        private void cmbHRQuickOCAmpsCh00_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh00.Text = cmbHRQuickOCAmpsCh00.Text;
        }

        private void cmbHRQuickOCAmpsCh01_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh01.Text = cmbHRQuickOCAmpsCh01.Text;
        }

        private void cmbHRQuickOCAmpsCh02_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh02.Text = cmbHRQuickOCAmpsCh02.Text;
        }

        private void cmbHRQuickOCAmpsCh03_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh03.Text = cmbHRQuickOCAmpsCh03.Text;
        }

        private void cmbHRQuickOCAmpsCh04_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh04.Text = cmbHRQuickOCAmpsCh04.Text;
        }

        private void cmbHRQuickOCAmpsCh05_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh05.Text = cmbHRQuickOCAmpsCh05.Text;
        }

        private void cmbHRQuickOCAmpsCh06_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh06.Text = cmbHRQuickOCAmpsCh06.Text;
        }

        private void cmbHRQuickOCAmpsCh07_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh07.Text = cmbHRQuickOCAmpsCh07.Text;
        }

        private void cmbHRQuickOCAmpsCh08_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh08.Text = cmbHRQuickOCAmpsCh08.Text;
        }

        private void cmbHRQuickOCAmpsCh09_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh09.Text = cmbHRQuickOCAmpsCh09.Text;
        }

        private void cmbHRQuickOCAmpsCh10_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh10.Text = cmbHRQuickOCAmpsCh10.Text;
        }

        private void cmbHRQuickOCAmpsCh11_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxHROCAmpsCh11.Text = cmbHRQuickOCAmpsCh11.Text;
        }

        private void cmbHRQuickModeCh00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh00.Text == "12V+")
            {
                cmbHRModeParamCh00.Text = "High";
                cmbHRDeadTimeCh00.Text = "0";
                cmbHRPairedCh00.Text = "None";
            }
            else if (cmbHRQuickModeCh00.Text == "Ground")
            {
                cmbHRModeParamCh00.Text = "Low";
                cmbHRDeadTimeCh00.Text = "0";
                cmbHRPairedCh00.Text = "None";
            }
            else if (cmbHRQuickModeCh00.Text == "RP UP")
            {
                cmbHRModeParamCh00.Text = "H Br";
                cmbHRDeadTimeCh00.Text = "500";
                cmbHRPairedCh00.Text = "1";
            }

            if (cmbHRQuickStartupCh00.Text == "High" || cmbHRQuickStartupCh00.Text == "Low") { cmbHRDirectionCh00.Text = cmbHRModeParamCh00.Text; }
            if (cmbHRDirectionCh00.Text != "Off" && (cmbHRModeParamCh00.Text == "High" || cmbHRModeParamCh00.Text == "Low")) { cmbHRDirectionCh00.Text = cmbHRModeParamCh00.Text; }
        }

        private void cmbHRQuickModeCh01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh01.Text == "12V+")
            {
                cmbHRModeParamCh01.Text = "High";
                cmbHRDeadTimeCh01.Text = "0";
                cmbHRPairedCh01.Text = "None";
            }
            else if (cmbHRQuickModeCh01.Text == "Ground")
            {
                cmbHRModeParamCh01.Text = "Low";
                cmbHRDeadTimeCh01.Text = "0";
                cmbHRPairedCh01.Text = "None";
            }
            else if (cmbHRQuickModeCh01.Text == "RP UP")
            {
                cmbHRModeParamCh01.Text = "H Br";
                cmbHRDeadTimeCh01.Text = "500";
                cmbHRPairedCh01.Text = "2";
            }
            else if (cmbHRQuickModeCh01.Text == "RP DN")
            {
                cmbHRModeParamCh01.Text = "Slave";
                cmbHRDeadTimeCh01.Text = "500";
                cmbHRPairedCh01.Text = "0";
            }

            if (cmbHRQuickStartupCh01.Text == "High" || cmbHRQuickStartupCh01.Text == "Low") { cmbHRDirectionCh01.Text = cmbHRModeParamCh01.Text; }
            if (cmbHRDirectionCh01.Text != "Off" && (cmbHRModeParamCh01.Text == "High" || cmbHRModeParamCh01.Text == "Low")) { cmbHRDirectionCh01.Text = cmbHRModeParamCh01.Text; }
        }

        private void cmbHRQuickModeCh02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh02.Text == "12V+")
            {
                cmbHRModeParamCh02.Text = "High";
                cmbHRDeadTimeCh02.Text = "0";
                cmbHRPairedCh02.Text = "None";
            }
            else if (cmbHRQuickModeCh02.Text == "Ground")
            {
                cmbHRModeParamCh02.Text = "Low";
                cmbHRDeadTimeCh02.Text = "0";
                cmbHRPairedCh02.Text = "None";
            }
            else if (cmbHRQuickModeCh02.Text == "RP UP")
            {
                cmbHRModeParamCh02.Text = "H Br";
                cmbHRDeadTimeCh02.Text = "500";
                cmbHRPairedCh02.Text = "3";
            }
            else if (cmbHRQuickModeCh02.Text == "RP DN")
            {
                cmbHRModeParamCh02.Text = "Slave";
                cmbHRDeadTimeCh02.Text = "500";
                cmbHRPairedCh02.Text = "1";
            }

            if (cmbHRQuickStartupCh02.Text == "High" || cmbHRQuickStartupCh02.Text == "Low") { cmbHRDirectionCh02.Text = cmbHRModeParamCh02.Text; }
            if (cmbHRDirectionCh02.Text != "Off" && (cmbHRModeParamCh02.Text == "High" || cmbHRModeParamCh02.Text == "Low")) { cmbHRDirectionCh02.Text = cmbHRModeParamCh02.Text; }
        }

        private void cmbHRQuickModeCh03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh03.Text == "12V+")
            {
                cmbHRModeParamCh03.Text = "High";
                cmbHRDeadTimeCh03.Text = "0";
                cmbHRPairedCh03.Text = "None";
            }
            else if (cmbHRQuickModeCh03.Text == "Ground")
            {
                cmbHRModeParamCh03.Text = "Low";
                cmbHRDeadTimeCh03.Text = "0";
                cmbHRPairedCh03.Text = "None";
            }
            else if (cmbHRQuickModeCh03.Text == "RP UP")
            {
                cmbHRModeParamCh03.Text = "H Br";
                cmbHRDeadTimeCh03.Text = "500";
                cmbHRPairedCh03.Text = "4";
            }
            else if (cmbHRQuickModeCh03.Text == "RP DN")
            {
                cmbHRModeParamCh03.Text = "Slave";
                cmbHRDeadTimeCh03.Text = "500";
                cmbHRPairedCh03.Text = "2";
            }

            if (cmbHRQuickStartupCh03.Text == "High" || cmbHRQuickStartupCh03.Text == "Low") { cmbHRDirectionCh03.Text = cmbHRModeParamCh03.Text; }
            if (cmbHRDirectionCh03.Text != "Off" && (cmbHRModeParamCh03.Text == "High" || cmbHRModeParamCh03.Text == "Low")) { cmbHRDirectionCh03.Text = cmbHRModeParamCh03.Text; }
        }

        private void cmbHRQuickModeCh04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh04.Text == "12V+")
            {
                cmbHRModeParamCh04.Text = "High";
                cmbHRDeadTimeCh04.Text = "0";
                cmbHRPairedCh04.Text = "None";
            }
            else if (cmbHRQuickModeCh04.Text == "Ground")
            {
                cmbHRModeParamCh04.Text = "Low";
                cmbHRDeadTimeCh04.Text = "0";
                cmbHRPairedCh04.Text = "None";
            }
            else if (cmbHRQuickModeCh04.Text == "RP UP")
            {
                cmbHRModeParamCh04.Text = "H Br";
                cmbHRDeadTimeCh04.Text = "500";
                cmbHRPairedCh04.Text = "5";
            }
            else if (cmbHRQuickModeCh01.Text == "RP DN")
            {
                cmbHRModeParamCh04.Text = "Slave";
                cmbHRDeadTimeCh04.Text = "500";
                cmbHRPairedCh04.Text = "3";
            }

            if (cmbHRQuickStartupCh04.Text == "High" || cmbHRQuickStartupCh04.Text == "Low") { cmbHRDirectionCh04.Text = cmbHRModeParamCh04.Text; }
            if (cmbHRDirectionCh04.Text != "Off" && (cmbHRModeParamCh04.Text == "High" || cmbHRModeParamCh04.Text == "Low")) { cmbHRDirectionCh04.Text = cmbHRModeParamCh04.Text; }
        }

        private void cmbHRQuickModeCh05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh05.Text == "12V+")
            {
                cmbHRModeParamCh05.Text = "High";
                cmbHRDeadTimeCh05.Text = "0";
                cmbHRPairedCh05.Text = "None";
            }
            else if (cmbHRQuickModeCh05.Text == "Ground")
            {
                cmbHRModeParamCh05.Text = "Low";
                cmbHRDeadTimeCh05.Text = "0";
                cmbHRPairedCh05.Text = "None";
            }
            else if (cmbHRQuickModeCh05.Text == "RP UP")
            {
                cmbHRModeParamCh05.Text = "H Br";
                cmbHRDeadTimeCh05.Text = "500";
                cmbHRPairedCh05.Text = "6";
            }
            else if (cmbHRQuickModeCh05.Text == "RP DN")
            {
                cmbHRModeParamCh05.Text = "Slave";
                cmbHRDeadTimeCh05.Text = "500";
                cmbHRPairedCh05.Text = "4";
            }

            if (cmbHRQuickStartupCh05.Text == "High" || cmbHRQuickStartupCh05.Text == "Low") { cmbHRDirectionCh05.Text = cmbHRModeParamCh05.Text; }
            if (cmbHRDirectionCh05.Text != "Off" && (cmbHRModeParamCh05.Text == "High" || cmbHRModeParamCh05.Text == "Low")) { cmbHRDirectionCh05.Text = cmbHRModeParamCh05.Text; }
        }

        private void cmbHRQuickModeCh06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh06.Text == "12V+")
            {
                cmbHRModeParamCh06.Text = "High";
                cmbHRDeadTimeCh06.Text = "0";
                cmbHRPairedCh06.Text = "None";
            }
            else if (cmbHRQuickModeCh06.Text == "Ground")
            {
                cmbHRModeParamCh06.Text = "Low";
                cmbHRDeadTimeCh06.Text = "0";
                cmbHRPairedCh06.Text = "None";
            }
            else if (cmbHRQuickModeCh06.Text == "RP UP")
            {
                cmbHRModeParamCh06.Text = "H Br";
                cmbHRDeadTimeCh06.Text = "500";
                cmbHRPairedCh06.Text = "7";
            }
            else if (cmbHRQuickModeCh06.Text == "RP DN")
            {
                cmbHRModeParamCh06.Text = "Slave";
                cmbHRDeadTimeCh06.Text = "500";
                cmbHRPairedCh06.Text = "5";
            }

            if (cmbHRQuickStartupCh06.Text == "High" || cmbHRQuickStartupCh06.Text == "Low") { cmbHRDirectionCh06.Text = cmbHRModeParamCh06.Text; }
            if (cmbHRDirectionCh06.Text != "Off" && (cmbHRModeParamCh06.Text == "High" || cmbHRModeParamCh06.Text == "Low")) { cmbHRDirectionCh06.Text = cmbHRModeParamCh06.Text; }
        }

        private void cmbHRQuickModeCh07_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh07.Text == "12V+")
            {
                cmbHRModeParamCh07.Text = "High";
                cmbHRDeadTimeCh07.Text = "0";
                cmbHRPairedCh07.Text = "None";
            }
            else if (cmbHRQuickModeCh07.Text == "Ground")
            {
                cmbHRModeParamCh07.Text = "Low";
                cmbHRDeadTimeCh07.Text = "0";
                cmbHRPairedCh07.Text = "None";
            }
            else if (cmbHRQuickModeCh07.Text == "RP UP")
            {
                cmbHRModeParamCh07.Text = "H Br";
                cmbHRDeadTimeCh07.Text = "500";
                cmbHRPairedCh07.Text = "8";
            }
            else if (cmbHRQuickModeCh07.Text == "RP DN")
            {
                cmbHRModeParamCh07.Text = "Slave";
                cmbHRDeadTimeCh07.Text = "500";
                cmbHRPairedCh07.Text = "6";
            }

            if (cmbHRQuickStartupCh07.Text == "High" || cmbHRQuickStartupCh07.Text == "Low") { cmbHRDirectionCh07.Text = cmbHRModeParamCh07.Text; }
            if (cmbHRDirectionCh07.Text != "Off" && (cmbHRModeParamCh07.Text == "High" || cmbHRModeParamCh07.Text == "Low")) { cmbHRDirectionCh07.Text = cmbHRModeParamCh07.Text; }
        }

        private void cmbHRQuickModeCh08_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh08.Text == "12V+")
            {
                cmbHRModeParamCh08.Text = "High";
                cmbHRDeadTimeCh08.Text = "0";
                cmbHRPairedCh08.Text = "None";
            }
            else if (cmbHRQuickModeCh08.Text == "Ground")
            {
                cmbHRModeParamCh08.Text = "Low";
                cmbHRDeadTimeCh08.Text = "0";
                cmbHRPairedCh08.Text = "None";
            }
            else if (cmbHRQuickModeCh08.Text == "RP UP")
            {
                cmbHRModeParamCh08.Text = "H Br";
                cmbHRDeadTimeCh08.Text = "500";
                cmbHRPairedCh08.Text = "9";
            }
            else if (cmbHRQuickModeCh08.Text == "RP DN")
            {
                cmbHRModeParamCh08.Text = "Slave";
                cmbHRDeadTimeCh08.Text = "500";
                cmbHRPairedCh08.Text = "7";
            }

            if (cmbHRQuickStartupCh08.Text == "High" || cmbHRQuickStartupCh08.Text == "Low") { cmbHRDirectionCh08.Text = cmbHRModeParamCh08.Text; }
            if (cmbHRDirectionCh08.Text != "Off" && (cmbHRModeParamCh08.Text == "High" || cmbHRModeParamCh08.Text == "Low")) { cmbHRDirectionCh08.Text = cmbHRModeParamCh08.Text; }
        }

        private void cmbHRQuickModeCh09_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh09.Text == "12V+")
            {
                cmbHRModeParamCh09.Text = "High";
                cmbHRDeadTimeCh09.Text = "0";
                cmbHRPairedCh09.Text = "None";
            }
            else if (cmbHRQuickModeCh09.Text == "Ground")
            {
                cmbHRModeParamCh09.Text = "Low";
                cmbHRDeadTimeCh09.Text = "0";
                cmbHRPairedCh09.Text = "None";
            }
            else if (cmbHRQuickModeCh09.Text == "RP UP")
            {
                cmbHRModeParamCh09.Text = "H Br";
                cmbHRDeadTimeCh09.Text = "500";
                cmbHRPairedCh09.Text = "10";
            }
            else if (cmbHRQuickModeCh09.Text == "RP DN")
            {
                cmbHRModeParamCh09.Text = "Slave";
                cmbHRDeadTimeCh09.Text = "500";
                cmbHRPairedCh09.Text = "8";
            }

            if (cmbHRQuickStartupCh09.Text == "High" || cmbHRQuickStartupCh09.Text == "Low") { cmbHRDirectionCh09.Text = cmbHRModeParamCh09.Text; }
            if (cmbHRDirectionCh09.Text != "Off" && (cmbHRModeParamCh09.Text == "High" || cmbHRModeParamCh09.Text == "Low")) { cmbHRDirectionCh09.Text = cmbHRModeParamCh09.Text; }
        }

        private void cmbHRQuickModeCh10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh10.Text == "12V+")
            {
                cmbHRModeParamCh10.Text = "High";
                cmbHRDeadTimeCh10.Text = "0";
                cmbHRPairedCh10.Text = "None";
            }
            else if (cmbHRQuickModeCh10.Text == "Ground")
            {
                cmbHRModeParamCh10.Text = "Low";
                cmbHRDeadTimeCh10.Text = "0";
                cmbHRPairedCh10.Text = "None";
            }
            else if (cmbHRQuickModeCh10.Text == "RP UP")
            {
                cmbHRModeParamCh10.Text = "H Br";
                cmbHRDeadTimeCh10.Text = "500";
                cmbHRPairedCh10.Text = "11";
            }
            else if (cmbHRQuickModeCh10.Text == "RP DN")
            {
                cmbHRModeParamCh10.Text = "Slave";
                cmbHRDeadTimeCh10.Text = "500";
                cmbHRPairedCh10.Text = "9";
            }

            if (cmbHRQuickStartupCh10.Text == "High" || cmbHRQuickStartupCh10.Text == "Low") { cmbHRDirectionCh10.Text = cmbHRModeParamCh10.Text; }
            if (cmbHRDirectionCh10.Text != "Off" && (cmbHRModeParamCh10.Text == "High" || cmbHRModeParamCh10.Text == "Low")) { cmbHRDirectionCh10.Text = cmbHRModeParamCh10.Text; }
        }

        private void cmbHRQuickModeCh11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickModeCh11.Text == "12V+")
            {
                cmbHRModeParamCh11.Text = "High";
                cmbHRDeadTimeCh11.Text = "0";
                cmbHRPairedCh11.Text = "None";
            }
            else if (cmbHRQuickModeCh11.Text == "Ground")
            {
                cmbHRModeParamCh11.Text = "Low";
                cmbHRDeadTimeCh11.Text = "0";
                cmbHRPairedCh11.Text = "None";
            }
            else if (cmbHRQuickModeCh11.Text == "RP DN")
            {
                cmbHRModeParamCh11.Text = "Slave";
                cmbHRDeadTimeCh11.Text = "500";
                cmbHRPairedCh11.Text = "10";
            }

            if (cmbHRQuickStartupCh11.Text == "High" || cmbHRQuickStartupCh11.Text == "Low") { cmbHRDirectionCh11.Text = cmbHRModeParamCh11.Text; }
            if (cmbHRDirectionCh11.Text != "Off" && (cmbHRModeParamCh11.Text == "High" || cmbHRModeParamCh11.Text == "Low")) { cmbHRDirectionCh11.Text = cmbHRModeParamCh11.Text; }
        }

        private void cmbHRQuickStartupCh00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh00.Text == "Latch")
            {
                chkHRLockCh00.Checked = false;
                tbxHRPWMDutyCh00.Text = "200";
                cmbHRDirectionCh00.Text = (cmbHRModeParamCh00.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh00.Text == "Constant")
            {
                chkHRLockCh00.Checked = true;
                tbxHRPWMDutyCh00.Text = "200";
                cmbHRDirectionCh00.Text = (cmbHRModeParamCh00.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh00.Checked = false;
                tbxHRPWMDutyCh00.Text = "0";
                cmbHRDirectionCh00.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh01.Text == "Latch")
            {
                chkHRLockCh01.Checked = false;
                tbxHRPWMDutyCh01.Text = "200";
                cmbHRDirectionCh01.Text = (cmbHRModeParamCh01.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh01.Text == "Constant")
            {
                chkHRLockCh01.Checked = true;
                tbxHRPWMDutyCh01.Text = "200";
                cmbHRDirectionCh01.Text = (cmbHRModeParamCh01.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh01.Checked = false;
                tbxHRPWMDutyCh01.Text = "0";
                cmbHRDirectionCh01.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh02.Text == "Latch")
            {
                chkHRLockCh02.Checked = false;
                tbxHRPWMDutyCh02.Text = "200";
                cmbHRDirectionCh02.Text = (cmbHRModeParamCh02.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh02.Text == "Constant")
            {
                chkHRLockCh02.Checked = true;
                tbxHRPWMDutyCh02.Text = "200";
                cmbHRDirectionCh02.Text = (cmbHRModeParamCh02.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh02.Checked = false;
                tbxHRPWMDutyCh02.Text = "0";
                cmbHRDirectionCh02.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh03.Text == "Latch")
            {
                chkHRLockCh03.Checked = false;
                tbxHRPWMDutyCh03.Text = "200";
                cmbHRDirectionCh03.Text = (cmbHRModeParamCh03.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh03.Text == "Constant")
            {
                chkHRLockCh03.Checked = true;
                tbxHRPWMDutyCh03.Text = "200";
                cmbHRDirectionCh03.Text = (cmbHRModeParamCh03.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh03.Checked = false;
                tbxHRPWMDutyCh03.Text = "0";
                cmbHRDirectionCh03.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh04.Text == "Latch")
            {
                chkHRLockCh04.Checked = false;
                tbxHRPWMDutyCh04.Text = "200";
                cmbHRDirectionCh04.Text = (cmbHRModeParamCh04.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh04.Text == "Constant")
            {
                chkHRLockCh04.Checked = true;
                tbxHRPWMDutyCh04.Text = "200";
                cmbHRDirectionCh04.Text = (cmbHRModeParamCh04.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh04.Checked = false;
                tbxHRPWMDutyCh04.Text = "0";
                cmbHRDirectionCh04.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh05.Text == "Latch")
            {
                chkHRLockCh05.Checked = false;
                tbxHRPWMDutyCh05.Text = "200";
                cmbHRDirectionCh05.Text = (cmbHRModeParamCh05.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh05.Text == "Constant")
            {
                chkHRLockCh05.Checked = true;
                tbxHRPWMDutyCh05.Text = "200";
                cmbHRDirectionCh05.Text = (cmbHRModeParamCh05.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh05.Checked = false;
                tbxHRPWMDutyCh05.Text = "0";
                cmbHRDirectionCh05.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh06.Text == "Latch")
            {
                chkHRLockCh06.Checked = false;
                tbxHRPWMDutyCh06.Text = "200";
                cmbHRDirectionCh06.Text = (cmbHRModeParamCh06.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh06.Text == "Constant")
            {
                chkHRLockCh06.Checked = true;
                tbxHRPWMDutyCh06.Text = "200";
                cmbHRDirectionCh06.Text = (cmbHRModeParamCh06.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh06.Checked = false;
                tbxHRPWMDutyCh06.Text = "0";
                cmbHRDirectionCh06.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh07_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh07.Text == "Latch")
            {
                chkHRLockCh07.Checked = false;
                tbxHRPWMDutyCh07.Text = "200";
                cmbHRDirectionCh07.Text = (cmbHRModeParamCh07.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh07.Text == "Constant")
            {
                chkHRLockCh07.Checked = true;
                tbxHRPWMDutyCh07.Text = "200";
                cmbHRDirectionCh07.Text = (cmbHRModeParamCh07.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh07.Checked = false;
                tbxHRPWMDutyCh07.Text = "0";
                cmbHRDirectionCh07.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh08_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh08.Text == "Latch")
            {
                chkHRLockCh08.Checked = false;
                tbxHRPWMDutyCh08.Text = "200";
                cmbHRDirectionCh08.Text = (cmbHRModeParamCh08.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh08.Text == "Constant")
            {
                chkHRLockCh08.Checked = true;
                tbxHRPWMDutyCh08.Text = "200";
                cmbHRDirectionCh08.Text = (cmbHRModeParamCh08.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh08.Checked = false;
                tbxHRPWMDutyCh08.Text = "0";
                cmbHRDirectionCh08.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh09_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh09.Text == "Latch")
            {
                chkHRLockCh09.Checked = false;
                tbxHRPWMDutyCh09.Text = "200";
                cmbHRDirectionCh09.Text = (cmbHRModeParamCh09.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh09.Text == "Constant")
            {
                chkHRLockCh09.Checked = true;
                tbxHRPWMDutyCh09.Text = "200";
                cmbHRDirectionCh09.Text = (cmbHRModeParamCh09.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh09.Checked = false;
                tbxHRPWMDutyCh09.Text = "0";
                cmbHRDirectionCh09.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh10.Text == "Latch")
            {
                chkHRLockCh10.Checked = false;
                tbxHRPWMDutyCh10.Text = "200";
                cmbHRDirectionCh10.Text = (cmbHRModeParamCh10.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh10.Text == "Constant")
            {
                chkHRLockCh10.Checked = true;
                tbxHRPWMDutyCh10.Text = "200";
                cmbHRDirectionCh10.Text = (cmbHRModeParamCh10.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh10.Checked = false;
                tbxHRPWMDutyCh10.Text = "0";
                cmbHRDirectionCh10.Text = "Off";
            }
        }

        private void cmbHRQuickStartupCh11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHRQuickStartupCh11.Text == "Latch")
            {
                chkHRLockCh11.Checked = false;
                tbxHRPWMDutyCh11.Text = "200";
                cmbHRDirectionCh11.Text = (cmbHRModeParamCh11.Text == "Low" ? "Low" : "High");
            }
            else if (cmbHRQuickStartupCh11.Text == "Constant")
            {
                chkHRLockCh11.Checked = true;
                tbxHRPWMDutyCh11.Text = "200";
                cmbHRDirectionCh11.Text = (cmbHRModeParamCh11.Text == "Low" ? "Low" : "High");
            }
            else // off
            {
                chkHRLockCh11.Checked = false;
                tbxHRPWMDutyCh11.Text = "0";
                cmbHRDirectionCh11.Text = "Off";
            }
        }

        // Mode Parameter events
        private void cmbHRModeParamCh00_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh00.Text == "Slave") { lblHRCh00.Visible = false; }
            else { lblHRCh00.Visible = true; }
        }

        private void cmbHRModeParamCh01_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh01.Text == "Slave") { lblHRCh01.Visible = false; }
            else { lblHRCh01.Visible = true; }
        }

        private void cmbHRModeParamCh02_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh02.Text == "Slave") { lblHRCh02.Visible = false; }
            else { lblHRCh02.Visible = true; }
        }

        private void cmbHRModeParamCh03_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh03.Text == "Slave") { lblHRCh03.Visible = false; }
            else { lblHRCh03.Visible = true; }
        }

        private void cmbHRModeParamCh04_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh04.Text == "Slave") { lblHRCh04.Visible = false; }
            else { lblHRCh04.Visible = true; }
        }

        private void cmbHRModeParamCh05_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh05.Text == "Slave") { lblHRCh05.Visible = false; }
            else { lblHRCh05.Visible = true; }
        }

        private void cmbHRModeParamCh06_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh06.Text == "Slave") { lblHRCh06.Visible = false; }
            else { lblHRCh06.Visible = true; }
        }

        private void cmbHRModeParamCh07_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh07.Text == "Slave") { lblHRCh07.Visible = false; }
            else { lblHRCh07.Visible = true; }
        }

        private void cmbHRModeParamCh08_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh08.Text == "Slave") { lblHRCh08.Visible = false; }
            else { lblHRCh08.Visible = true; }
        }

        private void cmbHRModeParamCh09_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh09.Text == "Slave") { lblHRCh09.Visible = false; }
            else { lblHRCh09.Visible = true; }
        }

        private void cmbHRModeParamCh10_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh10.Text == "Slave") { lblHRCh10.Visible = false; }
            else { lblHRCh10.Visible = true; }
        }

        private void cmbHRModeParamCh11_TextChanged(object sender, EventArgs e)
        {
            if (cmbHRModeParamCh11.Text == "Slave") { lblHRCh11.Visible = false; }
            else { lblHRCh11.Visible = true; }
        }


        /*      ##        ######  
                ##       ##    ## 
                ##       ##       
                ##       ##       
                ##       ##       
                ##       ##    ## 
                ########  ######         @LC */

        enum LC_QuickMode { Positive, Ground, ShadeUp, ShadeDown }

        enum LC_ModeParam { High, Low, HalfBridge, HBridge, Slave, Unused }

        public void LC_SetAll(int card)
        {
            // need to set by channel but get by group
            lcGroup00 = new bool[] { chkLC1MG1Ch00.Checked, chkLC1MG2Ch00.Checked, chkLC1MG3Ch00.Checked, chkLC1MG4Ch00.Checked };
            lcGroup01 = new bool[] { chkLC1MG1Ch01.Checked, chkLC1MG2Ch01.Checked, chkLC1MG3Ch01.Checked, chkLC1MG4Ch01.Checked };
            lcGroup02 = new bool[] { chkLC1MG1Ch02.Checked, chkLC1MG2Ch02.Checked, chkLC1MG3Ch02.Checked, chkLC1MG4Ch02.Checked };
            lcGroup03 = new bool[] { chkLC1MG1Ch03.Checked, chkLC1MG2Ch03.Checked, chkLC1MG3Ch03.Checked, chkLC1MG4Ch03.Checked };
            lcGroup04 = new bool[] { chkLC1MG1Ch04.Checked, chkLC1MG2Ch04.Checked, chkLC1MG3Ch04.Checked, chkLC1MG4Ch04.Checked };
            lcGroup05 = new bool[] { chkLC1MG1Ch05.Checked, chkLC1MG2Ch05.Checked, chkLC1MG3Ch05.Checked, chkLC1MG4Ch05.Checked };
            lcGroup06 = new bool[] { chkLC1MG1Ch06.Checked, chkLC1MG2Ch06.Checked, chkLC1MG3Ch06.Checked, chkLC1MG4Ch06.Checked };
            lcGroup07 = new bool[] { chkLC1MG1Ch07.Checked, chkLC1MG2Ch07.Checked, chkLC1MG3Ch07.Checked, chkLC1MG4Ch07.Checked };
            lcGroup08 = new bool[] { chkLC1MG1Ch08.Checked, chkLC1MG2Ch08.Checked, chkLC1MG3Ch08.Checked, chkLC1MG4Ch08.Checked };
            lcGroup09 = new bool[] { chkLC1MG1Ch09.Checked, chkLC1MG2Ch09.Checked, chkLC1MG3Ch09.Checked, chkLC1MG4Ch09.Checked };
            lcGroup10 = new bool[] { chkLC1MG1Ch10.Checked, chkLC1MG2Ch10.Checked, chkLC1MG3Ch10.Checked, chkLC1MG4Ch10.Checked };
            lcGroup11 = new bool[] { chkLC1MG1Ch11.Checked, chkLC1MG2Ch11.Checked, chkLC1MG3Ch11.Checked, chkLC1MG4Ch11.Checked };
            lcGroup12 = new bool[] { chkLC1MG1Ch12.Checked, chkLC1MG2Ch12.Checked, chkLC1MG3Ch12.Checked, chkLC1MG4Ch12.Checked };
            lcGroup13 = new bool[] { chkLC1MG1Ch13.Checked, chkLC1MG2Ch13.Checked, chkLC1MG3Ch13.Checked, chkLC1MG4Ch13.Checked };
            lcGroup14 = new bool[] { chkLC1MG1Ch14.Checked, chkLC1MG2Ch14.Checked, chkLC1MG3Ch14.Checked, chkLC1MG4Ch14.Checked };
            lcGroup15 = new bool[] { chkLC1MG1Ch15.Checked, chkLC1MG2Ch15.Checked, chkLC1MG3Ch15.Checked, chkLC1MG4Ch15.Checked };
            lcGroups = new bool[][] { lcGroup00, lcGroup01, lcGroup02, lcGroup03, lcGroup04, lcGroup05, lcGroup06, lcGroup07, lcGroup08, lcGroup09, lcGroup10, lcGroup11, lcGroup12, lcGroup13, lcGroup14, lcGroup15 };
            lcObjects[card].M1_SetVerRev(btnMenuNew.Text);
            lcObjects[card].M1_SetFullSetup(chkTabVisLC1.Checked);
            lcObjects[card].M1_SetStandalone(chkLC1Standalone.Checked);
            lcObjects[card].M1_SetCardNumber(cmbLC1CardNum.Text);
            lcObjects[card].M1_SetPanelNumber(cmbLC1PanelNum.Text);
            lcObjects[card].M1_SetDevAddr();
            lcObjects[card].M1_SetCardLetter(tbxLC1CardLetter.Text);
            lcObjects[card].M1_ChangeConfigName();
            lcObjects[card].LC_ChangeAddress();
            lcObjects[card].M1_SetCfgRev(tbxLC1CfgRev.Text);
            lcObjects[card].M1_SetCfgType(tbxLC1CfgType.Text);
            lcObjects[card].M1_SetDCDimmer(chkLC1DCDimmer.Checked);
            lcObjects[card].M1_SetDCMotor(chkLC1DCMotor.Checked);
            lcObjects[card].M1_SetShade(chkLC1Shade.Checked);
            lcObjects[card].M1_SetForce(chkLC1Force.Checked);
            lcObjects[card].M1_SetBaseIndex(tbxLC1BaseIndex.Text);
            for (int channel = 0; channel < 16; channel++)
            {
                if (chkLC1Standalone.Checked == false) // only set overcurrent parameters if it's not a standalone card
                {
                    lcObjects[card].LC_SetOCAmps(channel, lcOCAmps[channel].Text);
                    lcObjects[card].LC_SetOCTime(channel, lcOCTime[channel].Text);
                }
                lcObjects[card].M1_SetGroup0(lcGroups[channel], channel); // takes care of all 4 groups
                lcObjects[card].LC_SetQuickmode(lcModesQuick[channel].Text, channel);
                lcObjects[card].LC_SetIGNSafety(lcIGNSafety[channel].Text, channel);
                lcObjects[card].LC_SetParkSafety(lcParkSafety[channel].Text, channel);
                lcObjects[card].LC_SetModeParameter(lcModeParam[channel].Text, channel);
                lcObjects[card].LC_SetPairedTo(lcPairedTo[channel].Text, channel);
                lcObjects[card].LC_SetDeadTime(lcDeadTime[channel].Text, channel);
                lcObjects[card].LC_SetOverrideReverse(lcOverrideReverse[channel].Text, channel);
                lcObjects[card].LC_SetOverrideForward(lcOverrideForward[channel].Text, channel);
                lcObjects[card].LC_SetLock(lcLocks[channel].Checked, channel);
                lcObjects[card].LC_SetDirection(lcDirections[channel].Text, channel);
                lcObjects[card].LC_SetAllowTImeout(lcAllowTimeout[channel].Checked, channel);
                lcObjects[card].LC_SetTimeoutTimes(lcTimeoutTimes[channel].Text, channel);
                lcObjects[card].LC_SetMaxOn(lcMaxOns[channel].Text, channel);
                lcObjects[card].LC_SetMaxDurRecovery(lcMaxDurRecoveries[channel].Text, channel);
                lcObjects[card].LC_SetUCAmp(lcUCAmps[channel].Text, channel);
                lcObjects[card].LC_SetMeasCurTime(lcMeasCurTimes[channel].Text, channel);
                lcObjects[card].LC_SetPWMEnable(lcPWMEnable[channel].Checked, channel);
                lcObjects[card].LC_SetPWMFrequency(lcPWMFrequency[channel].Text, channel);
            }

        }

        public void LC_GetAll(int card)
        {
            chkTabVisLC1.Checked = lcObjects[card].M1_GetFullSetup();
            chkLC1Standalone.Checked = lcObjects[card].M1_GetStandalone();
            if (lcObjects[card].M1_GetCardNumber() == "")   { BlankComboBox(cmbLC1CardNum); }
            else                                            { cmbLC1CardNum.Text = lcObjects[card].M1_GetCardNumber(); }
            if (lcObjects[card].M1_GetPanelNumber() == "")  { BlankComboBox(cmbLC1PanelNum); }
            else                                            { cmbLC1PanelNum.Text = lcObjects[card].M1_GetPanelNumber(); }
            tbxLC1CfgRev.Text       = lcObjects[card].M1_GetCfgRev();
            tbxLC1CardLetter.Text   = lcObjects[card].M1_GetCardLetter();
            chkLC1DCDimmer.Checked  = lcObjects[card].M1_GetDCDimmer();
            chkLC1DCMotor.Checked   = lcObjects[card].M1_GetDCMotor();
            chkLC1Force.Checked     = lcObjects[card].M1_GetForce();
            tbxLC1BaseIndex.Text    = lcObjects[card].M1_GetBaseIndex();
            for (int channel = 0; channel < 16; channel++)
            {
                lcOCAmps[channel].Text = lcObjects[card].LC_GetOCAmps(channel);
                lcOCTime[channel].Text = lcObjects[card].LC_GetOCTime(channel);
                lcGetGroups[channel][0].Checked = lcObjects[card].M1_GetGroup0(channel);
                lcGetGroups[channel][1].Checked = lcObjects[card].M1_GetGroup1(channel);
                lcGetGroups[channel][2].Checked = lcObjects[card].M1_GetGroup2(channel);
                lcGetGroups[channel][3].Checked = lcObjects[card].M1_GetGroup3(channel);
                lcModesQuick[channel].Text = lcObjects[card].LC_GetQuickMode(channel);
                lcIGNSafety[channel].Text = lcObjects[card].LC_GetIGNSafety(channel);
                lcParkSafety[channel].Text = lcObjects[card].LC_GetParkSafety(channel);
                lcModeParam[channel].Text = lcObjects[card].LC_GetModeParameter(channel);
                lcPairedTo[channel].Text = lcObjects[card].LC_GetPairedTo(channel);
                lcDeadTime[channel].Text = lcObjects[card].LC_GetDeadTime(channel);
                lcOverrideReverse[channel].Text = lcObjects[card].LC_GetOverrideReverse(channel);
                lcOverrideForward[channel].Text = lcObjects[card].LC_GetOverrideForward(channel);
                lcLocks[channel].Checked = lcObjects[card].LC_GetLock(channel);
                lcDirections[channel].Text = lcObjects[card].LC_GetDirection(channel);
                lcAllowTimeout[channel].Checked = lcObjects[card].LC_GetAllowTimeout(channel);
                lcTimeoutTimes[channel].Text = lcObjects[card].LC_GetTimeoutTime(channel);
                lcMaxOns[channel].Text = lcObjects[card].LC_GetMaxOn(channel);
                lcMaxDurRecoveries[channel].Text = lcObjects[card].LC_GetMaxDurRecovery(channel);
                lcUCAmps[channel].Text = lcObjects[card].LC_GetUCAmp(channel);
                lcMeasCurTimes[channel].Text = lcObjects[card].LC_GetMeasCurTime(channel);
                lcPWMEnable[channel].Checked = lcObjects[card].LC_GetPWMEnable(channel);
                lcPWMFrequency[channel].Text = lcObjects[card].LC_GetPWMFrequency(channel);
            }
        }

        private void btnLCGenerate_Click(object sender, EventArgs e)
        {
            LC_SetAll(LCCardActive);
            lcObjects.ForEach(lcObjects => lcObjects.LC_CreateFile());
            CreateLCReferenceFile();
            LCCardNavColor(lcBtnArray, btnLCGenerate);
            tabControlLC.SelectedIndex = 1;
            // prints the file context of the folder
            string[] lcFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_LC_Bridge\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxLCGenerated.Lines = lcFiles;
        }

        private void CreateLCReferenceFile()
        {
            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_LC_Bridge\DeviceConfigs\DevAddrConfigs.h"))
            {
                foreach (LCCard card in lcObjects)
                {
                    sw.WriteLine("#include \"DevAddr" + card.M1_GetCardLetter() + ".h\"");
                }
            }
        }

        private void CheckLCGenerate()
        {   
            int checkCounter = 0;
            int numLCCards = Convert.ToInt16(cmbStartLC.Text);

            for (int i = 0; i < numLCCards; i++)
            {
                if (lcObjects[i].M1_GetCardNumber() != "" && lcObjects[i].M1_GetPanelNumber() != "" && lcObjects[i].M1_GetBaseIndex() != "")
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

        private void btnLCCard1_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard1);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card1;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1: 0);
        }

        private void btnLCCard2_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard2);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card2;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void btnLCCard3_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard3);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card3;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void btnLCCard4_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard4);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card4;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void btnLCCard5_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard5);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card5;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void btnLCCard6_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard6);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card6;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void btnLCCard7_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard7);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card7;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void btnLCCard8_Click(object sender, EventArgs e)
        {
            LCCardNavColor(lcBtnArray, btnLCCard8);
            tabControlLC.SelectedIndex = 0;
            LC_SetAll(LCCardActive);
            LCCardActive = (int)CardNum.Card8;
            LC_GetAll(LCCardActive);
            tabControlLC1QF.SelectedIndex = (chkTabVisLC1.Checked == true ? 1 : 0);
        }

        private void ShowLCNav(int argInt)
        {
            for (int i = 0; i < argInt; i++)
            {
                lcBtnArray[i].Visible = true;
            }
        }

        private void LCCardNavColor(Button[] argBtnArray, Button argButton)
        {
            ClearCardButtonColor(argBtnArray);
            argButton.BackColor = Color.FromArgb(255, 208, 110, 152);
        }

        private void cmbLC1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcObjects[LCCardActive].M1_SetCardNumber(cmbLC1CardNum.Text);
            CheckLCGenerate();
        }

        private void cmbLC1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcObjects[LCCardActive].M1_SetPanelNumber(cmbLC1PanelNum.Text);
            CheckLCGenerate();
        }
        private void tbxLC1BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lcObjects[LCCardActive].M1_SetBaseIndex(tbxLC1BaseIndex.Text);
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
            if (chkLC1Standalone.Checked)
            {
                HideComboBox(lcOCAmps);
                HideComboBox(lcOCTime);
                lblLCOCAmps.Text = "Overcurrent Amps (Disabled)";
                chkLC1Shade.Checked = true;
                cmbLC1PanelNum.SelectedIndex = 7; // set panel 8
            }
            else
            {
                ShowComboBox(lcOCAmps);
                ShowComboBox(lcOCTime);
                lblLCOCAmps.Text = "Overcurrent Amps";
                chkLC1Shade.Checked = false;
            }
        }

        private void chkTabVisLC1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTabVisLC1.Checked == true)   { this.tabControlLC1QF.SelectedIndex = 1; } // full visible
            else                                { this.tabControlLC1QF.SelectedIndex = 0; } // full hidden
        }

        private void cmbLC1Mode00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode00.Text == "12V+") 
            {
                cmbLCModeParamCh00.SelectedIndex = (int) LC_ModeParam.High;
                lblLC1Ch01.Visible = true;
            }
            else if (cmbLC1Mode00.Text == "Ground")
            {
                cmbLCModeParamCh00.SelectedIndex = (int) LC_ModeParam.Low;
                lblLC1Ch01.Visible = true;
            }
            else if (cmbLC1Mode00.Text == "RP UP")
            {
                cmbLCModeParamCh00.SelectedIndex = (int) LC_ModeParam.HBridge;
                cmbLCPairedToCh00.SelectedIndex = 1;
                cmbLCDeadTimeCh00.SelectedIndex = 1; // 500 ms

                cmbLC1Mode01.SelectedIndex = (int) LC_QuickMode.ShadeDown;
                cmbLCModeParamCh01.SelectedIndex = (int) LC_ModeParam.Slave;
                cmbLCPairedToCh01.SelectedIndex = 1;
                cmbLCDeadTimeCh01.SelectedIndex = 1; // 500 ms
                lblLC1Ch01.Visible = false;
            }
        }

        private void cmbLC1Mode01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode01.Text == "12V+")
            {
                cmbLCModeParamCh01.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch01.Visible = true;
            }
            else if (cmbLC1Mode01.Text == "Ground")
            {
                cmbLCModeParamCh01.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch01.Visible = true;
            }
            else if (cmbLC1Mode01.Text == "RP UP")
            {
                cmbLCModeParamCh01.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh01.SelectedIndex = 2;
                cmbLCDeadTimeCh01.SelectedIndex = 1; // 500 ms

                cmbLC1Mode02.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh02.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh02.SelectedIndex = 2;
                cmbLCDeadTimeCh02.SelectedIndex = 1; // 500 ms
                lblLC1Ch02.Visible = false;
            }
            else if (cmbLC1Mode01.Text == "RP DN")
            {
                cmbLC1Mode00.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh00.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh00.SelectedIndex = 1;
                cmbLCDeadTimeCh00.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh01.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh01.SelectedIndex = 1;
                cmbLCDeadTimeCh01.SelectedIndex = 1; // 500 ms
                lblLC1Ch01.Visible = false;
            }
        }

        private void cmbLC1Mode02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode02.Text == "12V+")
            {
                cmbLCModeParamCh02.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch02.Visible = true;
            }
            else if (cmbLC1Mode02.Text == "Ground")
            {
                cmbLCModeParamCh02.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch02.Visible = true;
            }
            else if (cmbLC1Mode02.Text == "RP UP")
            {
                cmbLCModeParamCh02.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh02.SelectedIndex = 2;
                cmbLCDeadTimeCh02.SelectedIndex = 1; // 500 ms

                cmbLC1Mode03.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh03.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh03.SelectedIndex = 2;
                cmbLCDeadTimeCh03.SelectedIndex = 1; // 500 ms
                lblLC1Ch03.Visible = false;
            }
            else if (cmbLC1Mode02.Text == "RP DN")
            {
                cmbLC1Mode01.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh01.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh01.SelectedIndex = 1;
                cmbLCDeadTimeCh01.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh02.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh02.SelectedIndex = 1;
                cmbLCDeadTimeCh02.SelectedIndex = 1; // 500 ms
                lblLC1Ch02.Visible = false;
            }
        }

        private void cmbLC1Mode03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode03.Text == "12V+")
            {
                cmbLCModeParamCh03.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch03.Visible = true;
            }
            else if (cmbLC1Mode03.Text == "Ground")
            {
                cmbLCModeParamCh03.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch03.Visible = true;
            }
            else if (cmbLC1Mode03.Text == "RP UP")
            {
                cmbLCModeParamCh03.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh03.SelectedIndex = 2;
                cmbLCDeadTimeCh03.SelectedIndex = 1; // 500 ms

                cmbLC1Mode04.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh04.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh04.SelectedIndex = 2;
                cmbLCDeadTimeCh04.SelectedIndex = 1; // 500 ms
                lblLC1Ch04.Visible = false;
            }
            else if (cmbLC1Mode03.Text == "RP DN")
            {
                cmbLC1Mode02.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh02.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh02.SelectedIndex = 1;
                cmbLCDeadTimeCh02.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh03.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh03.SelectedIndex = 1;
                cmbLCDeadTimeCh03.SelectedIndex = 1; // 500 ms
                lblLC1Ch03.Visible = false;
            }
        }

        private void cmbLC1Mode04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode04.Text == "12V+")
            {
                cmbLCModeParamCh04.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch04.Visible = true;
            }
            else if (cmbLC1Mode04.Text == "Ground")
            {
                cmbLCModeParamCh04.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch04.Visible = true;
            }
            else if (cmbLC1Mode04.Text == "RP UP")
            {
                cmbLCModeParamCh04.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh04.SelectedIndex = 2;
                cmbLCDeadTimeCh04.SelectedIndex = 1; // 500 ms

                cmbLC1Mode05.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh05.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh05.SelectedIndex = 2;
                cmbLCDeadTimeCh05.SelectedIndex = 1; // 500 ms
                lblLC1Ch05.Visible = false;
            }
            else if (cmbLC1Mode04.Text == "RP DN")
            {
                cmbLC1Mode03.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh03.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh03.SelectedIndex = 1;
                cmbLCDeadTimeCh03.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh04.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh04.SelectedIndex = 1;
                cmbLCDeadTimeCh04.SelectedIndex = 1; // 500 ms
                lblLC1Ch04.Visible = false;
            }
        }

        private void cmbLC1Mode05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode05.Text == "12V+")
            {
                cmbLCModeParamCh05.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch05.Visible = true;
            }
            else if (cmbLC1Mode05.Text == "Ground")
            {
                cmbLCModeParamCh05.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch05.Visible = true;
            }
            else if (cmbLC1Mode05.Text == "RP UP")
            {
                cmbLCModeParamCh05.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh05.SelectedIndex = 2;
                cmbLCDeadTimeCh05.SelectedIndex = 1; // 500 ms

                cmbLC1Mode06.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh06.SelectedIndex = 2;
                cmbLCDeadTimeCh06.SelectedIndex = 1; // 500 ms
                lblLC1Ch06.Visible = false;
            }
            else if (cmbLC1Mode06.Text == "RP DN")
            {
                cmbLC1Mode05.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh05.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh05.SelectedIndex = 1;
                cmbLCDeadTimeCh05.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh06.SelectedIndex = 1;
                cmbLCDeadTimeCh06.SelectedIndex = 1; // 500 ms
                lblLC1Ch06.Visible = false;
            }
        }

        private void cmbLC1Mode06_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode06.Text == "12V+")
            {
                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch06.Visible = true;
            }
            else if (cmbLC1Mode06.Text == "Ground")
            {
                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch06.Visible = true;
            }
            else if (cmbLC1Mode06.Text == "RP UP")
            {
                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh06.SelectedIndex = 2;
                cmbLCDeadTimeCh06.SelectedIndex = 1; // 500 ms

                cmbLC1Mode02.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh07.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh07.SelectedIndex = 2;
                cmbLCDeadTimeCh07.SelectedIndex = 1; // 500 ms
                lblLC1Ch07.Visible = false;
            }
            else if (cmbLC1Mode06.Text == "RP DN")
            {
                cmbLC1Mode00.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh05.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh05.SelectedIndex = 1;
                cmbLCDeadTimeCh05.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh06.SelectedIndex = 1;
                cmbLCDeadTimeCh06.SelectedIndex = 1; // 500 ms
                lblLC1Ch06.Visible = false;
            }
        }

        private void cmbLC1Mode07_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode07.Text == "12V+")
            {
                cmbLCModeParamCh07.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch07.Visible = true;
            }
            else if (cmbLC1Mode07.Text == "Ground")
            {
                cmbLCModeParamCh07.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch07.Visible = true;
            }
            else if (cmbLC1Mode07.Text == "RP UP")
            {
                cmbLCModeParamCh07.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh07.SelectedIndex = 2;
                cmbLCDeadTimeCh07.SelectedIndex = 1; // 500 ms

                cmbLC1Mode08.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh08.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh08.SelectedIndex = 2;
                cmbLCDeadTimeCh08.SelectedIndex = 1; // 500 ms
                lblLC1Ch08.Visible = false;
            }
            else if (cmbLC1Mode07.Text == "RP DN")
            {
                cmbLC1Mode06.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh06.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh06.SelectedIndex = 1;
                cmbLCDeadTimeCh06.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh07.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh07.SelectedIndex = 1;
                cmbLCDeadTimeCh07.SelectedIndex = 1; // 500 ms
                lblLC1Ch07.Visible = false;
            }
        }

        private void cmbLC1Mode08_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode08.Text == "12V+")
            {
                cmbLCModeParamCh08.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch08.Visible = true;
            }
            else if (cmbLC1Mode08.Text == "Ground")
            {
                cmbLCModeParamCh08.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch08.Visible = true;
            }
            else if (cmbLC1Mode08.Text == "RP UP")
            {
                cmbLCModeParamCh08.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh08.SelectedIndex = 2;
                cmbLCDeadTimeCh08.SelectedIndex = 1; // 500 ms

                cmbLC1Mode09.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh09.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh09.SelectedIndex = 2;
                cmbLCDeadTimeCh09.SelectedIndex = 1; // 500 ms
                lblLC1Ch09.Visible = false;
            }
            else if (cmbLC1Mode08.Text == "RP DN")
            {
                cmbLC1Mode07.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh07.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh07.SelectedIndex = 1;
                cmbLCDeadTimeCh07.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh08.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh08.SelectedIndex = 1;
                cmbLCDeadTimeCh08.SelectedIndex = 1; // 500 ms
                lblLC1Ch08.Visible = false;
            }
        }

        private void cmbLC1Mode09_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode09.Text == "12V+")
            {
                cmbLCModeParamCh09.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch09.Visible = true;
            }
            else if (cmbLC1Mode09.Text == "Ground")
            {
                cmbLCModeParamCh09.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch09.Visible = true;
            }
            else if (cmbLC1Mode09.Text == "RP UP")
            {
                cmbLCModeParamCh09.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh09.SelectedIndex = 2;
                cmbLCDeadTimeCh09.SelectedIndex = 1; // 500 ms

                cmbLC1Mode10.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh10.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh10.SelectedIndex = 2;
                cmbLCDeadTimeCh10.SelectedIndex = 1; // 500 ms
                lblLC1Ch10.Visible = false;
            }
            else if (cmbLC1Mode09.Text == "RP DN")
            {
                cmbLC1Mode08.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh08.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh08.SelectedIndex = 1;
                cmbLCDeadTimeCh08.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh09.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh09.SelectedIndex = 1;
                cmbLCDeadTimeCh09.SelectedIndex = 1; // 500 ms
                lblLC1Ch09.Visible = false;
            }
        }

        private void cmbLC1Mode10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode10.Text == "12V+")
            {
                cmbLCModeParamCh10.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch10.Visible = true;
            }
            else if (cmbLC1Mode10.Text == "Ground")
            {
                cmbLCModeParamCh10.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch10.Visible = true;
            }
            else if (cmbLC1Mode10.Text == "RP UP")
            {
                cmbLCModeParamCh10.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh10.SelectedIndex = 2;
                cmbLCDeadTimeCh10.SelectedIndex = 1; // 500 ms

                cmbLC1Mode11.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh11.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh11.SelectedIndex = 2;
                cmbLCDeadTimeCh11.SelectedIndex = 1; // 500 ms
                lblLC1Ch11.Visible = false;
            }
            else if (cmbLC1Mode10.Text == "RP DN")
            {
                cmbLC1Mode09.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh09.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh09.SelectedIndex = 1;
                cmbLCDeadTimeCh09.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh10.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh10.SelectedIndex = 1;
                cmbLCDeadTimeCh10.SelectedIndex = 1; // 500 ms
                lblLC1Ch10.Visible = false;
            }
        }

        private void cmbLC1Mode11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode11.Text == "12V+")
            {
                cmbLCModeParamCh11.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch11.Visible = true;
            }
            else if (cmbLC1Mode11.Text == "Ground")
            {
                cmbLCModeParamCh11.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch11.Visible = true;
            }
            else if (cmbLC1Mode11.Text == "RP UP")
            {
                cmbLCModeParamCh11.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh11.SelectedIndex = 2;
                cmbLCDeadTimeCh11.SelectedIndex = 1; // 500 ms

                cmbLC1Mode12.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh12.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh12.SelectedIndex = 2;
                cmbLCDeadTimeCh12.SelectedIndex = 1; // 500 ms
                lblLC1Ch12.Visible = false;
            }
            else if (cmbLC1Mode11.Text == "RP DN")
            {
                cmbLC1Mode10.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh10.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh10.SelectedIndex = 1;
                cmbLCDeadTimeCh10.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh11.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh11.SelectedIndex = 1;
                cmbLCDeadTimeCh11.SelectedIndex = 1; // 500 ms
                lblLC1Ch11.Visible = false;
            }
        }

        private void cmbLC1Mode12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode12.Text == "12V+")
            {
                cmbLCModeParamCh12.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch12.Visible = true;
            }
            else if (cmbLC1Mode12.Text == "Ground")
            {
                cmbLCModeParamCh12.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch12.Visible = true;
            }
            else if (cmbLC1Mode12.Text == "RP UP")
            {
                cmbLCModeParamCh12.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh12.SelectedIndex = 2;
                cmbLCDeadTimeCh12.SelectedIndex = 1; // 500 ms

                cmbLC1Mode13.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh13.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh13.SelectedIndex = 2;
                cmbLCDeadTimeCh13.SelectedIndex = 1; // 500 ms
                lblLC1Ch13.Visible = false;
            }
            else if (cmbLC1Mode12.Text == "RP DN")
            {
                cmbLC1Mode11.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh11.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh11.SelectedIndex = 1;
                cmbLCDeadTimeCh11.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh12.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh12.SelectedIndex = 1;
                cmbLCDeadTimeCh12.SelectedIndex = 1; // 500 ms
                lblLC1Ch12.Visible = false;
            }
        }

        private void cmbLC1Mode13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode13.Text == "12V+")
            {
                cmbLCModeParamCh13.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch13.Visible = true;
            }
            else if (cmbLC1Mode13.Text == "Ground")
            {
                cmbLCModeParamCh13.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch13.Visible = true;
            }
            else if (cmbLC1Mode13.Text == "RP UP")
            {
                cmbLCModeParamCh13.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh13.SelectedIndex = 2;
                cmbLCDeadTimeCh13.SelectedIndex = 1; // 500 ms

                cmbLC1Mode14.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh14.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh14.SelectedIndex = 2;
                cmbLCDeadTimeCh14.SelectedIndex = 1; // 500 ms
                lblLC1Ch14.Visible = false;
            }
            else if (cmbLC1Mode13.Text == "RP DN")
            {
                cmbLC1Mode12.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh12.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh12.SelectedIndex = 1;
                cmbLCDeadTimeCh12.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh13.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh13.SelectedIndex = 1;
                cmbLCDeadTimeCh13.SelectedIndex = 1; // 500 ms
                lblLC1Ch13.Visible = false;
            }
        }

        private void cmbLC1Mode14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode14.Text == "12V+")
            {
                cmbLCModeParamCh14.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch14.Visible = true;
            }
            else if (cmbLC1Mode14.Text == "Ground")
            {
                cmbLCModeParamCh14.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch14.Visible = true;
            }
            else if (cmbLC1Mode14.Text == "RP UP")
            {
                cmbLCModeParamCh14.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh14.SelectedIndex = 2;
                cmbLCDeadTimeCh14.SelectedIndex = 1; // 500 ms

                cmbLC1Mode15.SelectedIndex = (int)LC_QuickMode.ShadeDown;
                cmbLCModeParamCh15.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh15.SelectedIndex = 2;
                cmbLCDeadTimeCh15.SelectedIndex = 1; // 500 ms
                lblLC1Ch15.Visible = false;
            }
            else if (cmbLC1Mode14.Text == "RP DN")
            {
                cmbLC1Mode13.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh13.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh13.SelectedIndex = 1;
                cmbLCDeadTimeCh13.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh14.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh14.SelectedIndex = 1;
                cmbLCDeadTimeCh14.SelectedIndex = 1; // 500 ms
                lblLC1Ch14.Visible = false;
            }
        }

        private void cmbLC1Mode15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLC1Mode15.Text == "12V+")
            {
                cmbLCModeParamCh15.SelectedIndex = (int)LC_ModeParam.High;
                lblLC1Ch15.Visible = true;
            }
            else if (cmbLC1Mode15.Text == "Ground")
            {
                cmbLCModeParamCh15.SelectedIndex = (int)LC_ModeParam.Low;
                lblLC1Ch15.Visible = true;
            }
            else if (cmbLC1Mode15.Text == "RP DN")
            {
                cmbLC1Mode14.SelectedIndex = (int)LC_QuickMode.ShadeUp;
                cmbLCModeParamCh14.SelectedIndex = (int)LC_ModeParam.HBridge;
                cmbLCPairedToCh14.SelectedIndex = 1;
                cmbLCDeadTimeCh14.SelectedIndex = 1; // 500 ms

                cmbLCModeParamCh15.SelectedIndex = (int)LC_ModeParam.Slave;
                cmbLCPairedToCh15.SelectedIndex = 1;
                cmbLCDeadTimeCh15.SelectedIndex = 1; // 500 ms
                lblLC1Ch15.Visible = false;
            }
        }




        /*       ######  ##       #### ########  ######## 
                ##    ## ##        ##  ##     ## ##       
                ##       ##        ##  ##     ## ##       
                 ######  ##        ##  ##     ## ######   
                      ## ##        ##  ##     ## ##       
                ##    ## ##        ##  ##     ## ##       
                 ######  ######## #### ########  ########      @Slide*/

        // currently no plans to use slide card ... may add once everything else is done just so it's there

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
            auxBtnArray = new Button[] { btnAuxCard1, btnAuxCard2, btnAuxCard3, btnAuxCard4, btnAuxCard5, btnAuxCard6, btnAuxCard7, btnAuxCard8 };
            brkBtnArray = new Button[] { btnBreakerCard1, btnBreakerCard2, btnBreakerCard3, btnBreakerCard4, btnBreakerCard5, btnBreakerCard6, btnBreakerCard7, btnBreakerCard8 };
            dimBtnArray = new Button[] { btnDimmerCard1, btnDimmerCard2, btnDimmerCard3, btnDimmerCard4, btnDimmerCard5, btnDimmerCard6, btnDimmerCard7, btnDimmerCard8 };
            hcBtnArray = new Button[] { btnHCCard1, btnHCCard2, btnHCCard3, btnHCCard4, btnHCCard5, btnHCCard6, btnHCCard7, btnHCCard8 };
            hrBtnArray = new Button[] { btnHRCard1, btnHRCard2, btnHRCard3, btnHRCard4, btnHRCard5, btnHRCard6, btnHRCard7, btnHRCard8 };
            lcBtnArray = new Button[] { btnLCCard1, btnLCCard2, btnLCCard3, btnLCCard4, btnLCCard5, btnLCCard6, btnLCCard7, btnLCCard8 };

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

            dimGetGroup00 = new CheckBox[] { chkDimmer1MG1Ch00, chkDimmer1MG2Ch00, chkDimmer1MG3Ch00, chkDimmer1MG4Ch00 };
            dimGetGroup01 = new CheckBox[] { chkDimmer1MG1Ch01, chkDimmer1MG2Ch01, chkDimmer1MG3Ch01, chkDimmer1MG4Ch01 };
            dimGetGroup02 = new CheckBox[] { chkDimmer1MG1Ch02, chkDimmer1MG2Ch02, chkDimmer1MG3Ch02, chkDimmer1MG4Ch02 };
            dimGetGroup03 = new CheckBox[] { chkDimmer1MG1Ch03, chkDimmer1MG2Ch03, chkDimmer1MG3Ch03, chkDimmer1MG4Ch03 };
            dimGetGroup04 = new CheckBox[] { chkDimmer1MG1Ch04, chkDimmer1MG2Ch04, chkDimmer1MG3Ch04, chkDimmer1MG4Ch04 };
            dimGetGroup05 = new CheckBox[] { chkDimmer1MG1Ch05, chkDimmer1MG2Ch05, chkDimmer1MG3Ch05, chkDimmer1MG4Ch05 };
            dimGetGroup06 = new CheckBox[] { chkDimmer1MG1Ch06, chkDimmer1MG2Ch06, chkDimmer1MG3Ch06, chkDimmer1MG4Ch06 };
            dimGetGroup07 = new CheckBox[] { chkDimmer1MG1Ch07, chkDimmer1MG2Ch07, chkDimmer1MG3Ch07, chkDimmer1MG4Ch07 };
            dimGetGroup08 = new CheckBox[] { chkDimmer1MG1Ch08, chkDimmer1MG2Ch08, chkDimmer1MG3Ch08, chkDimmer1MG4Ch08 };
            dimGetGroup09 = new CheckBox[] { chkDimmer1MG1Ch09, chkDimmer1MG2Ch09, chkDimmer1MG3Ch09, chkDimmer1MG4Ch09 };
            dimGetGroup10 = new CheckBox[] { chkDimmer1MG1Ch10, chkDimmer1MG2Ch10, chkDimmer1MG3Ch10, chkDimmer1MG4Ch10 };
            dimGetGroup11 = new CheckBox[] { chkDimmer1MG1Ch11, chkDimmer1MG2Ch11, chkDimmer1MG3Ch11, chkDimmer1MG4Ch11 };
            dimGetGroups = new CheckBox[][] { dimGetGroup00, dimGetGroup01, dimGetGroup02, dimGetGroup03, dimGetGroup04, dimGetGroup05, dimGetGroup06, dimGetGroup07, dimGetGroup08, dimGetGroup09, dimGetGroup10, dimGetGroup11 };
            dimmerOCAmps = new ComboBox[] { cmbDimmer1OCAmps00, cmbDimmer1OCAmps01, cmbDimmer1OCAmps02, cmbDimmer1OCAmps03, cmbDimmer1OCAmps04, cmbDimmer1OCAmps05, cmbDimmer1OCAmps06, cmbDimmer1OCAmps07, cmbDimmer1OCAmps08, cmbDimmer1OCAmps09, cmbDimmer1OCAmps10, cmbDimmer1OCAmps11 };
            dimmerOCTime = new ComboBox[] { cmbDimmer1OCTime00, cmbDimmer1OCTime01, cmbDimmer1OCTime02, cmbDimmer1OCTime03, cmbDimmer1OCTime04, cmbDimmer1OCTime05, cmbDimmer1OCTime06, cmbDimmer1OCTime07, cmbDimmer1OCTime08, cmbDimmer1OCTime09, cmbDimmer1OCTime10, cmbDimmer1OCTime11 };
            dimmerLocks = new CheckBox[] { chkDimmer1Lock00, chkDimmer1Lock01, chkDimmer1Lock02, chkDimmer1Lock03, chkDimmer1Lock04, chkDimmer1Lock05, chkDimmer1Lock06, chkDimmer1Lock07, chkDimmer1Lock08, chkDimmer1Lock09, chkDimmer1Lock10, chkDimmer1Lock11};
            dimmerPWMFreq = new ComboBox[] { cmbDimmer1PWMFreqCh00, cmbDimmer1PWMFreqCh01, cmbDimmer1PWMFreqCh02, cmbDimmer1PWMFreqCh03, cmbDimmer1PWMFreqCh04, cmbDimmer1PWMFreqCh05, cmbDimmer1PWMFreqCh06, cmbDimmer1PWMFreqCh07, cmbDimmer1PWMFreqCh08, cmbDimmer1PWMFreqCh09, cmbDimmer1PWMFreqCh10, cmbDimmer1PWMFreqCh11 };
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

            hcGetGroup00 = new CheckBox[] { chkHC1MG1Ch00, chkHC1MG2Ch00, chkHC1MG3Ch00, chkHC1MG4Ch00 };
            hcGetGroup01 = new CheckBox[] { chkHC1MG1Ch01, chkHC1MG2Ch01, chkHC1MG3Ch01, chkHC1MG4Ch01 };
            hcGetGroup02 = new CheckBox[] { chkHC1MG1Ch02, chkHC1MG2Ch02, chkHC1MG3Ch02, chkHC1MG4Ch02 };
            hcGetGroup03 = new CheckBox[] { chkHC1MG1Ch03, chkHC1MG2Ch03, chkHC1MG3Ch03, chkHC1MG4Ch03 };
            hcGetGroup04 = new CheckBox[] { chkHC1MG1Ch04, chkHC1MG2Ch04, chkHC1MG3Ch04, chkHC1MG4Ch04 };
            hcGetGroup05 = new CheckBox[] { chkHC1MG1Ch05, chkHC1MG2Ch05, chkHC1MG3Ch05, chkHC1MG4Ch05 };
            hcGetGroup06 = new CheckBox[] { chkHC1MG1Ch06, chkHC1MG2Ch06, chkHC1MG3Ch06, chkHC1MG4Ch06 };
            hcGetGroup07 = new CheckBox[] { chkHC1MG1Ch07, chkHC1MG2Ch07, chkHC1MG3Ch07, chkHC1MG4Ch07 };
            hcGetGroup08 = new CheckBox[] { chkHC1MG1Ch08, chkHC1MG2Ch08, chkHC1MG3Ch08, chkHC1MG4Ch08 };
            hcGetGroup09 = new CheckBox[] { chkHC1MG1Ch09, chkHC1MG2Ch09, chkHC1MG3Ch09, chkHC1MG4Ch09 };
            hcGetGroup10 = new CheckBox[] { chkHC1MG1Ch10, chkHC1MG2Ch10, chkHC1MG3Ch10, chkHC1MG4Ch10 };
            hcGetGroup11 = new CheckBox[] { chkHC1MG1Ch11, chkHC1MG2Ch11, chkHC1MG3Ch11, chkHC1MG4Ch11 };
            hcGetGroups = new CheckBox[][] { hcGetGroup00, hcGetGroup01, hcGetGroup02, hcGetGroup03, hcGetGroup04, hcGetGroup05, hcGetGroup06, hcGetGroup07, hcGetGroup08, hcGetGroup09, hcGetGroup10, hcGetGroup11 };
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

            hrGetGroup00 = new CheckBox[] { chkHRMG1Ch00, chkHRMG2Ch00, chkHRMG3Ch00, chkHRMG4Ch00 };
            hrGetGroup01 = new CheckBox[] { chkHRMG1Ch01, chkHRMG2Ch01, chkHRMG3Ch01, chkHRMG4Ch01 };
            hrGetGroup02 = new CheckBox[] { chkHRMG1Ch02, chkHRMG2Ch02, chkHRMG3Ch02, chkHRMG4Ch02 };
            hrGetGroup03 = new CheckBox[] { chkHRMG1Ch03, chkHRMG2Ch03, chkHRMG3Ch03, chkHRMG4Ch03 };
            hrGetGroup04 = new CheckBox[] { chkHRMG1Ch04, chkHRMG2Ch04, chkHRMG3Ch04, chkHRMG4Ch04 };
            hrGetGroup05 = new CheckBox[] { chkHRMG1Ch05, chkHRMG2Ch05, chkHRMG3Ch05, chkHRMG4Ch05 };
            hrGetGroup06 = new CheckBox[] { chkHRMG1Ch06, chkHRMG2Ch06, chkHRMG3Ch06, chkHRMG4Ch06 };
            hrGetGroup07 = new CheckBox[] { chkHRMG1Ch07, chkHRMG2Ch07, chkHRMG3Ch07, chkHRMG4Ch07 };
            hrGetGroup08 = new CheckBox[] { chkHRMG1Ch08, chkHRMG2Ch08, chkHRMG3Ch08, chkHRMG4Ch08 };
            hrGetGroup09 = new CheckBox[] { chkHRMG1Ch09, chkHRMG2Ch09, chkHRMG3Ch09, chkHRMG4Ch09 };
            hrGetGroup10 = new CheckBox[] { chkHRMG1Ch10, chkHRMG2Ch10, chkHRMG3Ch10, chkHRMG4Ch10 };
            hrGetGroup11 = new CheckBox[] { chkHRMG1Ch11, chkHRMG2Ch11, chkHRMG3Ch11, chkHRMG4Ch11 };
            hrGetGroups = new CheckBox[][] { hrGetGroup00, hrGetGroup01, hrGetGroup02, hrGetGroup03, hrGetGroup04, hrGetGroup05, hrGetGroup06, hrGetGroup07, hrGetGroup08, hrGetGroup09, hrGetGroup10, hrGetGroup11 };
            hrChannelLabels = new Label[] { lblHRCh00, lblHRCh01, lblHRCh02, lblHRCh03, lblHRCh04, lblHRCh05, lblHRCh06, lblHRCh07, lblHRCh08, lblHRCh09, lblHRCh10, lblHRCh11 };
            hrOCAmpsQuick = new ComboBox[] { cmbHRQuickOCAmpsCh00, cmbHRQuickOCAmpsCh01, cmbHRQuickOCAmpsCh02, cmbHRQuickOCAmpsCh03, cmbHRQuickOCAmpsCh04, cmbHRQuickOCAmpsCh05, cmbHRQuickOCAmpsCh06, cmbHRQuickOCAmpsCh07, cmbHRQuickOCAmpsCh08, cmbHRQuickOCAmpsCh09, cmbHRQuickOCAmpsCh10, cmbHRQuickOCAmpsCh11 };
            hrOCAmps = new TextBox[] { tbxHROCAmpsCh00, tbxHROCAmpsCh01, tbxHROCAmpsCh02, tbxHROCAmpsCh03, tbxHROCAmpsCh04, tbxHROCAmpsCh05, tbxHROCAmpsCh06, tbxHROCAmpsCh07, tbxHROCAmpsCh08, tbxHROCAmpsCh09, tbxHROCAmpsCh10, tbxHROCAmpsCh11 };
            hrOCTime = new ComboBox[] { cmbHROCTimeCh00, cmbHROCTimeCh01, cmbHROCTimeCh02, cmbHROCTimeCh03, cmbHROCTimeCh04, cmbHROCTimeCh05, cmbHROCTimeCh06, cmbHROCTimeCh07, cmbHROCTimeCh08, cmbHROCTimeCh09, cmbHROCTimeCh10, cmbHROCTimeCh11 };
            hrModesQuick = new ComboBox[] { cmbHRQuickModeCh00, cmbHRQuickModeCh01, cmbHRQuickModeCh02, cmbHRQuickModeCh03, cmbHRQuickModeCh04, cmbHRQuickModeCh05, cmbHRQuickModeCh06, cmbHRQuickModeCh07, cmbHRQuickModeCh08, cmbHRQuickModeCh09, cmbHRQuickModeCh10, cmbHRQuickModeCh11 };
            hrStartupQuick = new ComboBox[] { cmbHRQuickStartupCh00, cmbHRQuickStartupCh01, cmbHRQuickStartupCh02, cmbHRQuickStartupCh03, cmbHRQuickStartupCh04, cmbHRQuickStartupCh05, cmbHRQuickStartupCh06, cmbHRQuickStartupCh07, cmbHRQuickStartupCh08, cmbHRQuickStartupCh09, cmbHRQuickStartupCh10, cmbHRQuickStartupCh11 };
            hrLock = new CheckBox[] { chkHRLockCh00, chkHRLockCh01, chkHRLockCh02, chkHRLockCh03, chkHRLockCh04, chkHRLockCh05, chkHRLockCh06, chkHRLockCh07, chkHRLockCh08, chkHRLockCh09, chkHRLockCh10, chkHRLockCh11 };
            hrPWMDuties = new TextBox[] { tbxHRPWMDutyCh00, tbxHRPWMDutyCh01, tbxHRPWMDutyCh02, tbxHRPWMDutyCh03, tbxHRPWMDutyCh04, tbxHRPWMDutyCh05, tbxHRPWMDutyCh06, tbxHRPWMDutyCh07, tbxHRPWMDutyCh08, tbxHRPWMDutyCh09, tbxHRPWMDutyCh10, tbxHRPWMDutyCh11 };
            hrDirections = new ComboBox[] { cmbHRDirectionCh00, cmbHRDirectionCh01, cmbHRDirectionCh02, cmbHRDirectionCh03, cmbHRDirectionCh04, cmbHRDirectionCh05, cmbHRDirectionCh06, cmbHRDirectionCh07, cmbHRDirectionCh08, cmbHRDirectionCh09, cmbHRDirectionCh10, cmbHRDirectionCh11 };
            hrModeParam = new ComboBox[] { cmbHRModeParamCh00, cmbHRModeParamCh01, cmbHRModeParamCh02, cmbHRModeParamCh03, cmbHRModeParamCh04, cmbHRModeParamCh05, cmbHRModeParamCh06, cmbHRModeParamCh07, cmbHRModeParamCh08, cmbHRModeParamCh09, cmbHRModeParamCh10, cmbHRModeParamCh11 };
            hrDeadTimes = new ComboBox[] { cmbHRDeadTimeCh00, cmbHRDeadTimeCh01, cmbHRDeadTimeCh02, cmbHRDeadTimeCh03, cmbHRDeadTimeCh04, cmbHRDeadTimeCh05, cmbHRDeadTimeCh06, cmbHRDeadTimeCh07, cmbHRDeadTimeCh08, cmbHRDeadTimeCh09, cmbHRDeadTimeCh10, cmbHRDeadTimeCh11 };
            hrPaired = new ComboBox[] { cmbHRPairedCh00, cmbHRPairedCh01, cmbHRPairedCh02, cmbHRPairedCh03, cmbHRPairedCh04, cmbHRPairedCh05, cmbHRPairedCh06, cmbHRPairedCh07, cmbHRPairedCh08, cmbHRPairedCh09, cmbHRPairedCh10, cmbHRPairedCh11 };
            hrTimeouts = new CheckBox[] { chkHRTimeoutCh00, chkHRTimeoutCh01, chkHRTimeoutCh02, chkHRTimeoutCh03, chkHRTimeoutCh04, chkHRTimeoutCh05, chkHRTimeoutCh06, chkHRTimeoutCh07, chkHRTimeoutCh08, chkHRTimeoutCh09, chkHRTimeoutCh10, chkHRTimeoutCh11 };
            hrTimeoutTimes = new TextBox[] { tbxHRTimeoutTimeCh00, tbxHRTimeoutTimeCh01, tbxHRTimeoutTimeCh02, tbxHRTimeoutTimeCh03, tbxHRTimeoutTimeCh04, tbxHRTimeoutTimeCh05, tbxHRTimeoutTimeCh06, tbxHRTimeoutTimeCh07, tbxHRTimeoutTimeCh08, tbxHRTimeoutTimeCh09, tbxHRTimeoutTimeCh10, tbxHRTimeoutTimeCh11 };
            hrMaxOns = new TextBox[] { tbxHRMaxOnCh00, tbxHRMaxOnCh01, tbxHRMaxOnCh02, tbxHRMaxOnCh03, tbxHRMaxOnCh04, tbxHRMaxOnCh05, tbxHRMaxOnCh06, tbxHRMaxOnCh07, tbxHRMaxOnCh08, tbxHRMaxOnCh09, tbxHRMaxOnCh10, tbxHRMaxOnCh11 };
            hrMaxDurRec = new TextBox[] { tbxHRMaxDurRecCh00, tbxHRMaxDurRecCh01, tbxHRMaxDurRecCh02, tbxHRMaxDurRecCh03, tbxHRMaxDurRecCh04, tbxHRMaxDurRecCh05, tbxHRMaxDurRecCh06, tbxHRMaxDurRecCh07, tbxHRMaxDurRecCh08, tbxHRMaxDurRecCh09, tbxHRMaxDurRecCh10, tbxHRMaxDurRecCh11 };
            hrUndAmps = new TextBox[] { tbxHRUndAmpsCh00, tbxHRUndAmpsCh01, tbxHRUndAmpsCh02, tbxHRUndAmpsCh03, tbxHRUndAmpsCh04, tbxHRUndAmpsCh05, tbxHRUndAmpsCh06, tbxHRUndAmpsCh07, tbxHRUndAmpsCh08, tbxHRUndAmpsCh09, tbxHRUndAmpsCh10, tbxHRUndAmpsCh11 };
            hrMeasCurTimes = new ComboBox[] { cmbHRMeasCurTimeCh00, cmbHRMeasCurTimeCh01, cmbHRMeasCurTimeCh02, cmbHRMeasCurTimeCh03, cmbHRMeasCurTimeCh04, cmbHRMeasCurTimeCh05, cmbHRMeasCurTimeCh06, cmbHRMeasCurTimeCh07, cmbHRMeasCurTimeCh08, cmbHRMeasCurTimeCh09, cmbHRMeasCurTimeCh10, cmbHRMeasCurTimeCh11 };

            lcGetGroup00 = new CheckBox[] { chkLC1MG1Ch00, chkLC1MG2Ch00, chkLC1MG3Ch00, chkLC1MG4Ch00 };
            lcGetGroup01 = new CheckBox[] { chkLC1MG1Ch01, chkLC1MG2Ch01, chkLC1MG3Ch01, chkLC1MG4Ch01 };
            lcGetGroup02 = new CheckBox[] { chkLC1MG1Ch02, chkLC1MG2Ch02, chkLC1MG3Ch02, chkLC1MG4Ch02 };
            lcGetGroup03 = new CheckBox[] { chkLC1MG1Ch03, chkLC1MG2Ch03, chkLC1MG3Ch03, chkLC1MG4Ch03 };
            lcGetGroup04 = new CheckBox[] { chkLC1MG1Ch04, chkLC1MG2Ch04, chkLC1MG3Ch04, chkLC1MG4Ch04 };
            lcGetGroup05 = new CheckBox[] { chkLC1MG1Ch05, chkLC1MG2Ch05, chkLC1MG3Ch05, chkLC1MG4Ch05 };
            lcGetGroup06 = new CheckBox[] { chkLC1MG1Ch06, chkLC1MG2Ch06, chkLC1MG3Ch06, chkLC1MG4Ch06 };
            lcGetGroup07 = new CheckBox[] { chkLC1MG1Ch07, chkLC1MG2Ch07, chkLC1MG3Ch07, chkLC1MG4Ch07 };
            lcGetGroup08 = new CheckBox[] { chkLC1MG1Ch08, chkLC1MG2Ch08, chkLC1MG3Ch08, chkLC1MG4Ch08 };
            lcGetGroup09 = new CheckBox[] { chkLC1MG1Ch09, chkLC1MG2Ch09, chkLC1MG3Ch09, chkLC1MG4Ch09 };
            lcGetGroup10 = new CheckBox[] { chkLC1MG1Ch10, chkLC1MG2Ch10, chkLC1MG3Ch10, chkLC1MG4Ch10 };
            lcGetGroup11 = new CheckBox[] { chkLC1MG1Ch11, chkLC1MG2Ch11, chkLC1MG3Ch11, chkLC1MG4Ch11 };
            lcGetGroup12 = new CheckBox[] { chkLC1MG1Ch12, chkLC1MG2Ch12, chkLC1MG3Ch12, chkLC1MG4Ch12 };
            lcGetGroup13 = new CheckBox[] { chkLC1MG1Ch13, chkLC1MG2Ch13, chkLC1MG3Ch13, chkLC1MG4Ch13 };
            lcGetGroup14 = new CheckBox[] { chkLC1MG1Ch14, chkLC1MG2Ch14, chkLC1MG3Ch14, chkLC1MG4Ch14 };
            lcGetGroup15 = new CheckBox[] { chkLC1MG1Ch15, chkLC1MG2Ch15, chkLC1MG3Ch15, chkLC1MG4Ch15 };
            lcGetGroups = new CheckBox[][] { lcGetGroup00, lcGetGroup01, lcGetGroup02, lcGetGroup03, lcGetGroup04, lcGetGroup05, lcGetGroup06, lcGetGroup07, lcGetGroup08, lcGetGroup09, lcGetGroup10, lcGetGroup11, lcGetGroup12, lcGetGroup13, lcGetGroup14, lcGetGroup15 };
            lcOCAmps = new ComboBox[] { cmbLC1OCAmps00, cmbLC1OCAmps01, cmbLC1OCAmps02, cmbLC1OCAmps03, cmbLC1OCAmps04, cmbLC1OCAmps05, cmbLC1OCAmps06, cmbLC1OCAmps07, cmbLC1OCAmps08, cmbLC1OCAmps09, cmbLC1OCAmps10, cmbLC1OCAmps11, cmbLC1OCAmps12, cmbLC1OCAmps13, cmbLC1OCAmps14, cmbLC1OCAmps15 };
            lcOCTime = new ComboBox[] { cmbLC1OCTime00, cmbLC1OCTime01, cmbLC1OCTime02, cmbLC1OCTime03, cmbLC1OCTime04, cmbLC1OCTime05, cmbLC1OCTime06, cmbLC1OCTime07, cmbLC1OCTime08, cmbLC1OCTime09, cmbLC1OCTime10, cmbLC1OCTime11, cmbLC1OCTime12, cmbLC1OCTime13, cmbLC1OCTime14, cmbLC1OCTime15 };
            lcModesQuick = new ComboBox[] { cmbLC1Mode00, cmbLC1Mode01, cmbLC1Mode02, cmbLC1Mode03, cmbLC1Mode04, cmbLC1Mode05, cmbLC1Mode06, cmbLC1Mode07, cmbLC1Mode08, cmbLC1Mode09, cmbLC1Mode10, cmbLC1Mode11, cmbLC1Mode12, cmbLC1Mode13, cmbLC1Mode14, cmbLC1Mode15 };
            lcIGNSafety = new ComboBox[] { cmbLCIGNSafetyCh00, cmbLCIGNSafetyCh01, cmbLCIGNSafetyCh02, cmbLCIGNSafetyCh03, cmbLCIGNSafetyCh04, cmbLCIGNSafetyCh05, cmbLCIGNSafetyCh06, cmbLCIGNSafetyCh07, cmbLCIGNSafetyCh08, cmbLCIGNSafetyCh09, cmbLCIGNSafetyCh10, cmbLCIGNSafetyCh11, cmbLCIGNSafetyCh12, cmbLCIGNSafetyCh13, cmbLCIGNSafetyCh14, cmbLCIGNSafetyCh15 };
            lcParkSafety = new ComboBox[] { cmbLCParkSafetyCh00, cmbLCParkSafetyCh01, cmbLCParkSafetyCh02, cmbLCParkSafetyCh03, cmbLCParkSafetyCh04, cmbLCParkSafetyCh05, cmbLCParkSafetyCh06, cmbLCParkSafetyCh07, cmbLCParkSafetyCh08, cmbLCParkSafetyCh09, cmbLCParkSafetyCh10, cmbLCParkSafetyCh11, cmbLCParkSafetyCh12, cmbLCParkSafetyCh13, cmbLCParkSafetyCh14, cmbLCParkSafetyCh15 };
            lcModeParam = new ComboBox[] { cmbLCModeParamCh00, cmbLCModeParamCh01, cmbLCModeParamCh02, cmbLCModeParamCh03, cmbLCModeParamCh04, cmbLCModeParamCh05, cmbLCModeParamCh06, cmbLCModeParamCh07, cmbLCModeParamCh08, cmbLCModeParamCh09, cmbLCModeParamCh10, cmbLCModeParamCh11, cmbLCModeParamCh12, cmbLCModeParamCh13, cmbLCModeParamCh14, cmbLCModeParamCh15 };
            lcPairedTo = new ComboBox[] { cmbLCPairedToCh00, cmbLCPairedToCh01, cmbLCPairedToCh02, cmbLCPairedToCh03, cmbLCPairedToCh04, cmbLCPairedToCh05, cmbLCPairedToCh06, cmbLCPairedToCh07, cmbLCPairedToCh08, cmbLCPairedToCh09, cmbLCPairedToCh10, cmbLCPairedToCh11, cmbLCPairedToCh12, cmbLCPairedToCh13, cmbLCPairedToCh14, cmbLCPairedToCh15 };
            lcDeadTime = new ComboBox[] { cmbLCDeadTimeCh00, cmbLCDeadTimeCh01, cmbLCDeadTimeCh02, cmbLCDeadTimeCh03, cmbLCDeadTimeCh04, cmbLCDeadTimeCh05, cmbLCDeadTimeCh06, cmbLCDeadTimeCh07, cmbLCDeadTimeCh08, cmbLCDeadTimeCh09, cmbLCDeadTimeCh10, cmbLCDeadTimeCh11, cmbLCDeadTimeCh12, cmbLCDeadTimeCh13, cmbLCDeadTimeCh14, cmbLCDeadTimeCh15 };
            lcOverrideReverse = new ComboBox[] { cmbLCOverrideInputReverseCh00, cmbLCOverrideInputReverseCh01, cmbLCOverrideInputReverseCh02, cmbLCOverrideInputReverseCh03, cmbLCOverrideInputReverseCh04, cmbLCOverrideInputReverseCh05, cmbLCOverrideInputReverseCh06, cmbLCOverrideInputReverseCh07, cmbLCOverrideInputReverseCh08, cmbLCOverrideInputReverseCh09, cmbLCOverrideInputReverseCh10, cmbLCOverrideInputReverseCh11, cmbLCOverrideInputReverseCh12, cmbLCOverrideInputReverseCh13, cmbLCOverrideInputReverseCh14, cmbLCOverrideInputReverseCh15 };
            lcOverrideForward = new ComboBox[] { cmbLCOverrideInputForwardCh00, cmbLCOverrideInputForwardCh01, cmbLCOverrideInputForwardCh02, cmbLCOverrideInputForwardCh03, cmbLCOverrideInputForwardCh04, cmbLCOverrideInputForwardCh05, cmbLCOverrideInputForwardCh06, cmbLCOverrideInputForwardCh07, cmbLCOverrideInputForwardCh08, cmbLCOverrideInputForwardCh09, cmbLCOverrideInputForwardCh10, cmbLCOverrideInputForwardCh11, cmbLCOverrideInputForwardCh12, cmbLCOverrideInputForwardCh13, cmbLCOverrideInputForwardCh14, cmbLCOverrideInputForwardCh15 };
            lcLocks = new CheckBox[] { chkLC1LockCh00, chkLC1LockCh01, chkLC1LockCh02, chkLC1LockCh03, chkLC1LockCh04, chkLC1LockCh05, chkLC1LockCh06, chkLC1LockCh07, chkLC1LockCh08, chkLC1LockCh09, chkLC1LockCh10, chkLC1LockCh11, chkLC1LockCh12, chkLC1LockCh13, chkLC1LockCh14, chkLC1LockCh15 };
            lcDirections = new ComboBox[] { cmbLC1DirectionCh00, cmbLC1DirectionCh01, cmbLC1DirectionCh02, cmbLC1DirectionCh03, cmbLC1DirectionCh04, cmbLC1DirectionCh05, cmbLC1DirectionCh06, cmbLC1DirectionCh07, cmbLC1DirectionCh08, cmbLC1DirectionCh09, cmbLC1DirectionCh10, cmbLC1DirectionCh11, cmbLC1DirectionCh12, cmbLC1DirectionCh13, cmbLC1DirectionCh14, cmbLC1DirectionCh15 };
            lcAllowTimeout = new CheckBox[] { chkLC1AllowComTimeCh00, chkLC1AllowComTimeCh01, chkLC1AllowComTimeCh02, chkLC1AllowComTimeCh03, chkLC1AllowComTimeCh04, chkLC1AllowComTimeCh05, chkLC1AllowComTimeCh06, chkLC1AllowComTimeCh07, chkLC1AllowComTimeCh08, chkLC1AllowComTimeCh09, chkLC1AllowComTimeCh10, chkLC1AllowComTimeCh11, chkLC1AllowComTimeCh12, chkLC1AllowComTimeCh13, chkLC1AllowComTimeCh14, chkLC1AllowComTimeCh15 };
            lcTimeoutTimes = new TextBox[] { tbxLCTimeoutTimeCh00, tbxLCTimeoutTimeCh01, tbxLCTimeoutTimeCh02, tbxLCTimeoutTimeCh03, tbxLCTimeoutTimeCh04, tbxLCTimeoutTimeCh05, tbxLCTimeoutTimeCh06, tbxLCTimeoutTimeCh07, tbxLCTimeoutTimeCh08, tbxLCTimeoutTimeCh09, tbxLCTimeoutTimeCh10, tbxLCTimeoutTimeCh11, tbxLCTimeoutTimeCh12, tbxLCTimeoutTimeCh13, tbxLCTimeoutTimeCh14, tbxLCTimeoutTimeCh15 };
            lcMaxOns = new TextBox[] { tbxLCMaxOnCh00, tbxLCMaxOnCh01, tbxLCMaxOnCh02, tbxLCMaxOnCh03, tbxLCMaxOnCh04, tbxLCMaxOnCh05, tbxLCMaxOnCh06, tbxLCMaxOnCh07, tbxLCMaxOnCh08, tbxLCMaxOnCh09, tbxLCMaxOnCh10, tbxLCMaxOnCh11, tbxLCMaxOnCh12, tbxLCMaxOnCh13, tbxLCMaxOnCh14, tbxLCMaxOnCh15 };
            lcMaxDurRecoveries = new TextBox[] { tbxLCMaxDurRecoveryCh00, tbxLCMaxDurRecoveryCh01, tbxLCMaxDurRecoveryCh02, tbxLCMaxDurRecoveryCh03, tbxLCMaxDurRecoveryCh04, tbxLCMaxDurRecoveryCh05, tbxLCMaxDurRecoveryCh06, tbxLCMaxDurRecoveryCh07, tbxLCMaxDurRecoveryCh08, tbxLCMaxDurRecoveryCh09, tbxLCMaxDurRecoveryCh10, tbxLCMaxDurRecoveryCh11, tbxLCMaxDurRecoveryCh12, tbxLCMaxDurRecoveryCh13, tbxLCMaxDurRecoveryCh14, tbxLCMaxDurRecoveryCh15 };
            lcUCAmps = new TextBox[] { tbxLCUCAmpsCh00, tbxLCUCAmpsCh01, tbxLCUCAmpsCh02, tbxLCUCAmpsCh03, tbxLCUCAmpsCh04, tbxLCUCAmpsCh05, tbxLCUCAmpsCh06, tbxLCUCAmpsCh07, tbxLCUCAmpsCh08, tbxLCUCAmpsCh09, tbxLCUCAmpsCh10, tbxLCUCAmpsCh11, tbxLCUCAmpsCh12, tbxLCUCAmpsCh13, tbxLCUCAmpsCh14, tbxLCUCAmpsCh15 };
            lcMeasCurTimes = new ComboBox[] { cmbLC1MeasCurTimeCh00, cmbLC1MeasCurTimeCh01, cmbLC1MeasCurTimeCh02, cmbLC1MeasCurTimeCh03, cmbLC1MeasCurTimeCh04, cmbLC1MeasCurTimeCh05, cmbLC1MeasCurTimeCh06, cmbLC1MeasCurTimeCh07, cmbLC1MeasCurTimeCh08, cmbLC1MeasCurTimeCh09, cmbLC1MeasCurTimeCh10, cmbLC1MeasCurTimeCh11, cmbLC1MeasCurTimeCh12, cmbLC1MeasCurTimeCh13, cmbLC1MeasCurTimeCh14, cmbLC1MeasCurTimeCh15 };
            lcPWMEnable = new CheckBox[] { chkLCPWMEnableCh00, chkLCPWMEnableCh01, chkLCPWMEnableCh02, chkLCPWMEnableCh03, chkLCPWMEnableCh04, chkLCPWMEnableCh05, chkLCPWMEnableCh06, chkLCPWMEnableCh07, chkLCPWMEnableCh08, chkLCPWMEnableCh09, chkLCPWMEnableCh10, chkLCPWMEnableCh11, chkLCPWMEnableCh12, chkLCPWMEnableCh13, chkLCPWMEnableCh14, chkLCPWMEnableCh15 };
            lcPWMFrequency = new ComboBox[] { cmbLCPWMFreqCh00, cmbLCPWMFreqCh01, cmbLCPWMFreqCh02, cmbLCPWMFreqCh03, cmbLCPWMFreqCh04, cmbLCPWMFreqCh05, cmbLCPWMFreqCh06, cmbLCPWMFreqCh07, cmbLCPWMFreqCh08, cmbLCPWMFreqCh09, cmbLCPWMFreqCh10, cmbLCPWMFreqCh11, cmbLCPWMFreqCh12, cmbLCPWMFreqCh13, cmbLCPWMFreqCh14, cmbLCPWMFreqCh15 };

        }
    }
}
