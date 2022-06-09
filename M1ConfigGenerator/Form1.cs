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
        List<AuxCard> auxObjects = new List<AuxCard>();
        ComboBox[] auxCardNum;
        ComboBox[] auxPanelNum;
        TextBox[] auxConfigRev;
        TextBox[] auxConfigType;
        CheckBox[] auxDCDimmer; CheckBox[] auxDCMotor; CheckBox[] auxShade; CheckBox[] auxForce;
        TextBox[] auxBaseInstance;
        bool[] aux1Group00; bool[] aux1Group01; bool[] aux1Group02; bool[] aux1Group03; bool[] aux1Group04; bool[] aux1Group05;
        bool[] aux1Group06; bool[] aux1Group07; bool[] aux1Group08; bool[] aux1Group09; bool[] aux1Group10; bool[] aux1Group11;
        bool[][] aux1Groups;
        bool[] aux2Group00; bool[] aux2Group01; bool[] aux2Group02; bool[] aux2Group03; bool[] aux2Group04; bool[] aux2Group05;
        bool[] aux2Group06; bool[] aux2Group07; bool[] aux2Group08; bool[] aux2Group09; bool[] aux2Group10; bool[] aux2Group11;
        bool[][] aux2Groups;
        bool[] aux1QuickPair; bool[] aux2QuickPair;
        bool[][] auxQuickPairGroups;

        List<BreakerCard> breakerObjects = new List<BreakerCard>();
        ComboBox[] breakerCardNum;
        ComboBox[] breakerPanelNum;
        TextBox[] breakerConfigRev;
        TextBox[] breakerConfigType;
        TextBox[] breakerBaseInstance;
        ComboBox[] breakerVINOCAmps;
        ComboBox[] breakerVINOCTime;
        ComboBox[] breakerVINInterrupt;
        ComboBox[] breaker1OCAmps; ComboBox[] breaker2OCAmps; ComboBox[] breaker3OCAmps; ComboBox[] breaker4OCAmps;
        ComboBox[][] breakerOCAmps;
        ComboBox[] breaker1OCTime; ComboBox[] breaker2OCTime; ComboBox[] breaker3OCTime; ComboBox[] breaker4OCTime;
        ComboBox[][] breakerOCTime;
        ComboBox[] breaker1Interrupt; ComboBox[] breaker2Interrupt; ComboBox[] breaker3Interrupt; ComboBox[] breaker4Interrupt;
        ComboBox[][] breakerInterrupts;

        List<DimmerCard> dimmerObjects = new List<DimmerCard>();
        ComboBox[] dimCardNum;
        ComboBox[] dimPanelNum;
        TextBox[] dimConfigRev;
        TextBox[] dimConfigType;
        CheckBox[] dimDCMotor; CheckBox[] dimShade; CheckBox[] dimForce;
        TextBox[] dimBaseInstance;
        ComboBox[] dim1OCAmps; ComboBox[] dim2OCAmps; ComboBox[] dim3OCAmps; ComboBox[] dim4OCAmps; ComboBox[] dim5OCAmps; ComboBox[] dim6OCAmps;
        ComboBox[][] dimmerOCAmps;
        ComboBox[] dim1OCTime; ComboBox[] dim2OCTime; ComboBox[] dim3OCTime; ComboBox[] dim4OCTime; ComboBox[] dim5OCTime; ComboBox[] dim6OCTime;
        ComboBox[][] dimmerOCTime;
        bool[] dim1Group00; bool[] dim1Group01; bool[] dim1Group02; bool[] dim1Group03; bool[] dim1Group04; bool[] dim1Group05; 
        bool[] dim1Group06; bool[] dim1Group07; bool[] dim1Group08; bool[] dim1Group09; bool[] dim1Group10; bool[] dim1Group11;
        bool[][] dim1Groups;
        bool[] dim2Group00; bool[] dim2Group01; bool[] dim2Group02; bool[] dim2Group03; bool[] dim2Group04; bool[] dim2Group05; 
        bool[] dim2Group06; bool[] dim2Group07; bool[] dim2Group08; bool[] dim2Group09; bool[] dim2Group10; bool[] dim2Group11;
        bool[][] dim2Groups;
        bool[] dim3Group00; bool[] dim3Group01; bool[] dim3Group02; bool[] dim3Group03; bool[] dim3Group04; bool[] dim3Group05; 
        bool[] dim3Group06; bool[] dim3Group07; bool[] dim3Group08; bool[] dim3Group09; bool[] dim3Group10; bool[] dim3Group11;
        bool[][] dim3Groups;
        bool[] dim4Group00; bool[] dim4Group01; bool[] dim4Group02; bool[] dim4Group03; bool[] dim4Group04; bool[] dim4Group05; 
        bool[] dim4Group06; bool[] dim4Group07; bool[] dim4Group08; bool[] dim4Group09; bool[] dim4Group10; bool[] dim4Group11;
        bool[][] dim4Groups;
        bool[] dim5Group00; bool[] dim5Group01; bool[] dim5Group02; bool[] dim5Group03; bool[] dim5Group04; bool[] dim5Group05; 
        bool[] dim5Group06; bool[] dim5Group07; bool[] dim5Group08; bool[] dim5Group09; bool[] dim5Group10; bool[] dim5Group11;
        bool[][] dim5Groups;
        bool[] dim6Group00; bool[] dim6Group01; bool[] dim6Group02; bool[] dim6Group03; bool[] dim6Group04; bool[] dim6Group05; 
        bool[] dim6Group06; bool[] dim6Group07; bool[] dim6Group08; bool[] dim6Group09; bool[] dim6Group10; bool[] dim6Group11;
        bool[][] dim6Groups;

        List<HCCard> hcObjects = new List<HCCard>();
        ComboBox[] hcCardNum;
        ComboBox[] hcPanelNum;
        TextBox[] hcConfigRev;
        TextBox[] hcConfigType;
        CheckBox[] hcDCDimmer; CheckBox[] hcDCMotor; CheckBox[] hcShade; CheckBox[] hcForce; CheckBox[] hcRGB;
        TextBox[] hcBaseInstance;
        ComboBox[] hc1OCAmps; ComboBox[] hc2OCAmps; ComboBox[] hc3OCAmps; ComboBox[] hc4OCAmps; ComboBox[] hc5OCAmps; ComboBox[] hc6OCAmps;
        ComboBox[][] hcOCAmps;
        ComboBox[] hc1OCTime; ComboBox[] hc2OCTime; ComboBox[] hc3OCTime; ComboBox[] hc4OCTime; ComboBox[] hc5OCTime; ComboBox[] hc6OCTime;
        ComboBox[][] hcOCTime;
        bool[] hc1Group00; bool[] hc1Group01; bool[] hc1Group02; bool[] hc1Group03; bool[] hc1Group04; bool[] hc1Group05; bool[] hc1Group06; bool[] hc1Group07; bool[] hc1Group08; bool[] hc1Group09; bool[] hc1Group10; bool[] hc1Group11;
        bool[][] hc1Groups;
        bool[] hc2Group00; bool[] hc2Group01; bool[] hc2Group02; bool[] hc2Group03; bool[] hc2Group04; bool[] hc2Group05; bool[] hc2Group06; bool[] hc2Group07; bool[] hc2Group08; bool[] hc2Group09; bool[] hc2Group10; bool[] hc2Group11;
        bool[][] hc2Groups;
        bool[] hc3Group00; bool[] hc3Group01; bool[] hc3Group02; bool[] hc3Group03; bool[] hc3Group04; bool[] hc3Group05; bool[] hc3Group06; bool[] hc3Group07; bool[] hc3Group08; bool[] hc3Group09; bool[] hc3Group10; bool[] hc3Group11;
        bool[][] hc3Groups;
        bool[] hc4Group00; bool[] hc4Group01; bool[] hc4Group02; bool[] hc4Group03; bool[] hc4Group04; bool[] hc4Group05; bool[] hc4Group06; bool[] hc4Group07; bool[] hc4Group08; bool[] hc4Group09; bool[] hc4Group10; bool[] hc4Group11;
        bool[][] hc4Groups;
        bool[] hc5Group00; bool[] hc5Group01; bool[] hc5Group02; bool[] hc5Group03; bool[] hc5Group04; bool[] hc5Group05; bool[] hc5Group06; bool[] hc5Group07; bool[] hc5Group08; bool[] hc5Group09; bool[] hc5Group10; bool[] hc5Group11;
        bool[][] hc5Groups;
        bool[] hc6Group00; bool[] hc6Group01; bool[] hc6Group02; bool[] hc6Group03; bool[] hc6Group04; bool[] hc6Group05; bool[] hc6Group06; bool[] hc6Group07; bool[] hc6Group08; bool[] hc6Group09; bool[] hc6Group10; bool[] hc6Group11;
        bool[][] hc6Groups;
        ComboBox[] hc1Mode; ComboBox[] hc2Mode; ComboBox[] hc3Mode; ComboBox[] hc4Mode; ComboBox[] hc5Mode; ComboBox[] hc6Mode;
        ComboBox[][] hcModes;
        bool[] hc1Startup; bool[] hc2Startup; bool[] hc3Startup; bool[] hc4Startup; bool[] hc5Startup; bool[] hc6Startup;
        bool[][] hcStartup;

        List<LCCard> lcObjects = new List<LCCard>();
        ComboBox[] lcCardNum;
        ComboBox[] lcPanelNum;
        TextBox[] lcConfigRev;
        TextBox[] lcConfigType;
        CheckBox[] lcStandalone; CheckBox[] lcDCDimmer; CheckBox[] lcDCMotor; CheckBox[] lcShade; CheckBox[] lcForce;
        TextBox[] lcBaseInstance;
        ComboBox[] lc1OCAmps; ComboBox[] lc2OCAmps; ComboBox[] lc3OCAmps; ComboBox[] lc4OCAmps; ComboBox[] lc5OCAmps; ComboBox[] lc6OCAmps;
        ComboBox[][] lcOCAmps;
        ComboBox[] lc1OCTime; ComboBox[] lc2OCTime; ComboBox[] lc3OCTime; ComboBox[] lc4OCTime; ComboBox[] lc5OCTime; ComboBox[] lc6OCTime;
        ComboBox[][] lcOCTime;
        bool[] lc1Group00; bool[] lc1Group01; bool[] lc1Group02; bool[] lc1Group03; bool[] lc1Group04; bool[] lc1Group05; bool[] lc1Group06; bool[] lc1Group07; 
        bool[] lc1Group08; bool[] lc1Group09; bool[] lc1Group10; bool[] lc1Group11; bool[] lc1Group12; bool[] lc1Group13; bool[] lc1Group14; bool[] lc1Group15;
        bool[][] lc1Groups;
        bool[] lc2Group00; bool[] lc2Group01; bool[] lc2Group02; bool[] lc2Group03; bool[] lc2Group04; bool[] lc2Group05; bool[] lc2Group06; bool[] lc2Group07; 
        bool[] lc2Group08; bool[] lc2Group09; bool[] lc2Group10; bool[] lc2Group11; bool[] lc2Group12; bool[] lc2Group13; bool[] lc2Group14; bool[] lc2Group15;
        bool[][] lc2Groups;
        bool[] lc3Group00; bool[] lc3Group01; bool[] lc3Group02; bool[] lc3Group03; bool[] lc3Group04; bool[] lc3Group05; bool[] lc3Group06; bool[] lc3Group07; 
        bool[] lc3Group08; bool[] lc3Group09; bool[] lc3Group10; bool[] lc3Group11; bool[] lc3Group12; bool[] lc3Group13; bool[] lc3Group14; bool[] lc3Group15;
        bool[][] lc3Groups;
        bool[] lc4Group00; bool[] lc4Group01; bool[] lc4Group02; bool[] lc4Group03; bool[] lc4Group04; bool[] lc4Group05; bool[] lc4Group06; bool[] lc4Group07; 
        bool[] lc4Group08; bool[] lc4Group09; bool[] lc4Group10; bool[] lc4Group11; bool[] lc4Group12; bool[] lc4Group13; bool[] lc4Group14; bool[] lc4Group15;
        bool[][] lc4Groups;
        bool[] lc5Group00; bool[] lc5Group01; bool[] lc5Group02; bool[] lc5Group03; bool[] lc5Group04; bool[] lc5Group05; bool[] lc5Group06; bool[] lc5Group07; 
        bool[] lc5Group08; bool[] lc5Group09; bool[] lc5Group10; bool[] lc5Group11; bool[] lc5Group12; bool[] lc5Group13; bool[] lc5Group14; bool[] lc5Group15;
        bool[][] lc5Groups;
        bool[] lc6Group00; bool[] lc6Group01; bool[] lc6Group02; bool[] lc6Group03; bool[] lc6Group04; bool[] lc6Group05; bool[] lc6Group06; bool[] lc6Group07; 
        bool[] lc6Group08; bool[] lc6Group09; bool[] lc6Group10; bool[] lc6Group11; bool[] lc6Group12; bool[] lc6Group13; bool[] lc6Group14; bool[] lc6Group15;
        bool[][] lc6Groups;
        ComboBox[] lc1Mode; ComboBox[] lc2Mode; ComboBox[] lc3Mode; ComboBox[] lc4Mode; ComboBox[] lc5Mode; ComboBox[] lc6Mode;
        ComboBox[][] lcModes;


        public Form1()
        {
            InitializeComponent();

            Load += new EventHandler(Form1_Load);

            int[] AuxColor = { 83, 52, 129 };
            int[] BreakerColor = { 217, 58, 78 };
            int[] DimmerColor = { 27, 161, 119 };
            int[] HCColor = { 24, 80, 135 };
            int[] LCColor = { 208, 110, 152 };
            int[] SlideColor = { 178, 214, 241 };

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
            btnMenuSlide.Visible = false;
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
            ShowAuxNav(Convert.ToInt16(cmbStartAux.SelectedItem.ToString()));
        }

        private void btnMenuBreaker_Click(object sender, EventArgs e)
        {
            SetMenuColors(1);
            tabControlMain.SelectedIndex = 3;
            ShowBreakerNav(Convert.ToInt16(cmbStartBreaker.SelectedItem.ToString()));
        }

        private void btnMenuDimmer_Click(object sender, EventArgs e)
        {
            SetMenuColors(2);
            tabControlMain.SelectedIndex = 4;
            ShowDimmerNav(Convert.ToInt16(cmbStartDimmer.SelectedItem.ToString()));
        }

        private void btnMenuHC_Click(object sender, EventArgs e)
        {
            SetMenuColors(3);
            tabControlMain.SelectedIndex = 5;
            ShowHCNav(Convert.ToInt16(cmbStartHC.SelectedItem.ToString()));
        }

        private void btnMenuLC_Click(object sender, EventArgs e)
        {
            SetMenuColors(4);
            tabControlMain.SelectedIndex = 6;
            ShowLCNav(Convert.ToInt16(cmbStartLC.SelectedItem.ToString()));
        }

        private void btnMenuSlide_Click(object sender, EventArgs e)
        {
            SetMenuColors(5);
            tabControlMain.SelectedIndex = 7;
            ShowSlideNav(Convert.ToInt16(cmbStartSlide.SelectedItem.ToString()));
        }


        private void SetMenuColors(int ButtonNum)
        {
            btnMenuAux.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuBreaker.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuDimmer.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuHC.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuLC.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuSlide.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnMenuSlide.ForeColor = SystemColors.Control;

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
                    btnMenuSlide.BackColor = Color.FromArgb(255, 178, 214, 241);
                    btnMenuSlide.ForeColor = Color.FromArgb(255, 20, 20, 20);
                    break;
            }
        }

        // @Start Page ------------------------------------------------------------- Start Page
        private void btnStartClose_Click(object sender, EventArgs e)
        {
            HideNavButtons();
            ResetStartTab();
        }

        private void btnStartCreate_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
            HideNavButtons();
            // for some reason, had to put these in opposite order so they appear correctly in nav bar
            ShowNavButton(btnMenuSlide, cmbStartSlide.SelectedIndex);
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
        }

        private void ResetStartTab()
        {
            cmbStartAux.SelectedIndex = 0;
            cmbStartBreaker.SelectedIndex = 0;
            cmbStartDimmer.SelectedIndex = 0;
            cmbStartHC.SelectedIndex = 0;
            cmbStartLC.SelectedIndex = 0;
            cmbStartSlide.SelectedIndex = 0;
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

            aux2Group00 = new bool[] { chkAux2MG1Ch00.Checked, chkAux2MG2Ch00.Checked, chkAux2MG3Ch00.Checked, chkAux2MG4Ch00.Checked };
            aux2Group01 = new bool[] { chkAux2MG1Ch01.Checked, chkAux2MG2Ch01.Checked, chkAux2MG3Ch01.Checked, chkAux2MG4Ch01.Checked };
            aux2Group02 = new bool[] { chkAux2MG1Ch02.Checked, chkAux2MG2Ch02.Checked, chkAux2MG3Ch02.Checked, chkAux2MG4Ch02.Checked };
            aux2Group03 = new bool[] { chkAux2MG1Ch03.Checked, chkAux2MG2Ch03.Checked, chkAux2MG3Ch03.Checked, chkAux2MG4Ch03.Checked };
            aux2Group04 = new bool[] { chkAux2MG1Ch04.Checked, chkAux2MG2Ch04.Checked, chkAux2MG3Ch04.Checked, chkAux2MG4Ch04.Checked };
            aux2Group05 = new bool[] { chkAux2MG1Ch05.Checked, chkAux2MG2Ch05.Checked, chkAux2MG3Ch05.Checked, chkAux2MG4Ch05.Checked };
            aux2Group06 = new bool[] { chkAux2MG1Ch06.Checked, chkAux2MG2Ch06.Checked, chkAux2MG3Ch06.Checked, chkAux2MG4Ch06.Checked };
            aux2Group07 = new bool[] { chkAux2MG1Ch07.Checked, chkAux2MG2Ch07.Checked, chkAux2MG3Ch07.Checked, chkAux2MG4Ch07.Checked };
            aux2Group08 = new bool[] { chkAux2MG1Ch08.Checked, chkAux2MG2Ch08.Checked, chkAux2MG3Ch08.Checked, chkAux2MG4Ch08.Checked };
            aux2Group09 = new bool[] { chkAux2MG1Ch09.Checked, chkAux2MG2Ch09.Checked, chkAux2MG3Ch09.Checked, chkAux2MG4Ch09.Checked };
            aux2Group10 = new bool[] { chkAux2MG1Ch10.Checked, chkAux2MG2Ch10.Checked, chkAux2MG3Ch10.Checked, chkAux2MG4Ch10.Checked };
            aux2Group11 = new bool[] { chkAux2MG1Ch11.Checked, chkAux2MG2Ch11.Checked, chkAux2MG3Ch11.Checked, chkAux2MG4Ch11.Checked };
            aux2Groups = new bool[][] { aux2Group00, aux2Group01, aux2Group02, aux2Group03, aux2Group04, aux2Group05, aux2Group06, aux2Group07, aux2Group08, aux2Group09, aux2Group10, aux2Group11 };

            List<bool[][]> auxGroups = new List<bool[][]>();
            auxGroups.Add(aux1Groups);
            auxGroups.Add(aux2Groups);

            aux1QuickPair = new bool[] { chkAux1QuickPair0001.Checked, chkAux1QuickPair0203.Checked, chkAux1QuickPair0405.Checked, chkAux1QuickPair0607.Checked, chkAux1QuickPair0809.Checked, chkAux1QuickPair1011.Checked };
            aux2QuickPair = new bool[] { chkAux2QuickPair0001.Checked, chkAux2QuickPair0203.Checked, chkAux2QuickPair0405.Checked, chkAux2QuickPair0607.Checked, chkAux2QuickPair0809.Checked, chkAux2QuickPair1011.Checked };
            auxQuickPairGroups = new bool[][] { aux1QuickPair, aux2QuickPair };

            // Aux cards
            for (int card = 0; card < Convert.ToInt16(cmbStartAux.Text); card++)
            {
                auxObjects[card].SetDevAddr(auxCardNum[card].SelectedIndex, auxPanelNum[card].SelectedIndex);
                auxObjects[card].SetCfgRev(auxConfigRev[card].Text);
                auxObjects[card].SetCfgType(auxConfigType[card].Text);
                auxObjects[card].SetDCDimmer(true); // hard coding for aux card
                auxObjects[card].SetDCMotor(auxDCMotor[card].Checked);
                auxObjects[card].SetShade(auxShade[card].Checked);
                auxObjects[card].SetForce(auxForce[card].Checked);
                auxObjects[card].SetBaseIndex(auxBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    auxObjects[card].SetGroup0(auxGroups[card][channel], channel); // takes care of all 4 groups
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

            bool[] checkAux = new bool[] { CheckAux1(), CheckAux2()};

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

        private bool CheckAux2()
        {
            return ((cmbAux2CardNum.Text != "") && (cmbAux2PanelNum.Text != "") && (tbxAux2BaseIndex.Text != ""));
        }

        private void btnAuxCard1_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard1);
            tabControlAux.SelectedIndex = 1;
        }

        private void btnAuxCard2_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard2);
            tabControlAux.SelectedIndex = 2;
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
            Button[] btnArray = { btnAuxCard1, btnAuxCard2, btnAuxCard3, btnAuxCard4, btnAuxCard5, btnAuxCard6 };

            for (int i = 0; i < argInt; i++)
            {
                btnArray[i].Visible = true;
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

        private void tbxAux2BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblAux2Ch00.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 0);
            lblAux2Ch01.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 1);
            lblAux2Ch02.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 2);
            lblAux2Ch03.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 3);
            lblAux2Ch04.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 4);
            lblAux2Ch05.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 5);
            lblAux2Ch06.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 6);
            lblAux2Ch07.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 7);
            lblAux2Ch08.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 8);
            lblAux2Ch09.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 9);
            lblAux2Ch10.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 10);
            lblAux2Ch11.Text = ChangeChannelLabel(tbxAux2BaseIndex.Text, 11);
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
                breakerObjects[card].SetDevAddr(breakerCardNum[card].SelectedIndex, breakerPanelNum[card].SelectedIndex);
                breakerObjects[card].SetCfgRev(breakerConfigRev[card].Text);
                breakerObjects[card].SetCfgType(breakerConfigType[card].Text);
                breakerObjects[card].SetDCDriver(true); // hard-coded because these commands are needed for overcurrent reset
                breakerObjects[card].SetForce(true); // hard-coded in case we want to use the interrupt commands (I think)
                breakerObjects[card].SetBaseIndex(breakerBaseInstance[card].Text);
                breakerObjects[card].SetVINOCAmps(breakerVINOCAmps[card].Text);
                breakerObjects[card].SetVINOCTime(breakerVINOCTime[card].Text);
                breakerObjects[card].SetVINInterrupt(breakerVINInterrupt[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    breakerObjects[card].SetOCAmps(channel, breakerOCAmps[card][channel].Text);
                    breakerObjects[card].SetOCTime(channel, breakerOCTime[card][channel].Text);
                    breakerObjects[card].SetInterrupt(channel, breakerInterrupts[card][channel].Text); 
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
            foreach (ComboBox i in breaker1Interrupt)
            {
                i.SelectedIndex = cmbBreaker1InterruptVIN.SelectedIndex;
            }
        }

        private void chkBreaker2MatchVIN_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (ComboBox i in breaker2Interrupt)
            {
                i.SelectedIndex = cmbBreaker2InterruptVIN.SelectedIndex;
            }
        }

        private void chkBreaker3MatchVIN_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (ComboBox i in breaker3Interrupt)
            {
                i.SelectedIndex = cmbBreaker3InterruptVIN.SelectedIndex;
            }
        }

        private void chkBreaker4MatchVIN_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (ComboBox i in breaker4Interrupt)
            {
                i.SelectedIndex = cmbBreaker4InterruptVIN.SelectedIndex;
            }
        }

        private void CheckBreakerGenerate()
        {
            int checkCounter = 0;
            int numBreakerCards = Convert.ToInt16(cmbStartBreaker.Text);

            bool[] checkBreaker = new bool[] { CheckBreaker1(), CheckBreaker2(), CheckBreaker3(), CheckBreaker4() };

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

        private bool CheckBreaker2()
        {
            return ((cmbBreaker2CardNum.Text != "") && (cmbBreaker2PanelNum.Text != "") && (tbxBreaker2BaseIndex.Text != ""));
        }

        private bool CheckBreaker3()
        {
            return ((cmbBreaker3CardNum.Text != "") && (cmbBreaker3PanelNum.Text != "") && (tbxBreaker3BaseIndex.Text != ""));
        }

        private bool CheckBreaker4()
        {
            return ((cmbBreaker4CardNum.Text != "") && (cmbBreaker4PanelNum.Text != "") && (tbxBreaker4BaseIndex.Text != ""));
        }

        private void btnBreakerCard1_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard1);
            tabControlBreaker.SelectedIndex = 1;
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
            Button[] btnArray = { btnBreakerCard1, btnBreakerCard2, btnBreakerCard3, btnBreakerCard4, btnBreakerCard5, btnBreakerCard6 };

            for (int i = 0; i < argInt; i++)
            {
                btnArray[i].Visible = true;
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

        private void tbxBreaker2BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblBreaker2Ch00.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 0);
            lblBreaker2Ch01.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 1);
            lblBreaker2Ch02.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 2);
            lblBreaker2Ch03.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 3);
            lblBreaker2Ch04.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 4);
            lblBreaker2Ch05.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 5);
            lblBreaker2Ch06.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 6);
            lblBreaker2Ch07.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 7);
            lblBreaker2Ch08.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 8);
            lblBreaker2Ch09.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 9);
            lblBreaker2Ch10.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 10);
            lblBreaker2Ch11.Text = ChangeChannelLabel(tbxBreaker2BaseIndex.Text, 11);
            CheckBreakerGenerate();
        }

        private void tbxBreaker3BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblBreaker3Ch00.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 0);
            lblBreaker3Ch01.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 1);
            lblBreaker3Ch02.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 2);
            lblBreaker3Ch03.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 3);
            lblBreaker3Ch04.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 4);
            lblBreaker3Ch05.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 5);
            lblBreaker3Ch06.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 6);
            lblBreaker3Ch07.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 7);
            lblBreaker3Ch08.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 8);
            lblBreaker3Ch09.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 9);
            lblBreaker3Ch10.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 10);
            lblBreaker3Ch11.Text = ChangeChannelLabel(tbxBreaker3BaseIndex.Text, 11);
            CheckBreakerGenerate();
        }

        private void tbxBreaker4BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblBreaker4Ch00.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 0);
            lblBreaker4Ch01.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 1);
            lblBreaker4Ch02.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 2);
            lblBreaker4Ch03.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 3);
            lblBreaker4Ch04.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 4);
            lblBreaker4Ch05.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 5);
            lblBreaker4Ch06.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 6);
            lblBreaker4Ch07.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 7);
            lblBreaker4Ch08.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 8);
            lblBreaker4Ch09.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 9);
            lblBreaker4Ch10.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 10);
            lblBreaker4Ch11.Text = ChangeChannelLabel(tbxBreaker4BaseIndex.Text, 11);
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

            dim2Group00 = new bool[] { chkDimmer2MG1Ch00.Checked, chkDimmer2MG2Ch00.Checked, chkDimmer2MG3Ch00.Checked, chkDimmer2MG4Ch00.Checked };
            dim2Group01 = new bool[] { chkDimmer2MG1Ch01.Checked, chkDimmer2MG2Ch01.Checked, chkDimmer2MG3Ch01.Checked, chkDimmer2MG4Ch01.Checked };
            dim2Group02 = new bool[] { chkDimmer2MG1Ch02.Checked, chkDimmer2MG2Ch02.Checked, chkDimmer2MG3Ch02.Checked, chkDimmer2MG4Ch02.Checked };
            dim2Group03 = new bool[] { chkDimmer2MG1Ch03.Checked, chkDimmer2MG2Ch03.Checked, chkDimmer2MG3Ch03.Checked, chkDimmer2MG4Ch03.Checked };
            dim2Group04 = new bool[] { chkDimmer2MG1Ch04.Checked, chkDimmer2MG2Ch04.Checked, chkDimmer2MG3Ch04.Checked, chkDimmer2MG4Ch04.Checked };
            dim2Group05 = new bool[] { chkDimmer2MG1Ch05.Checked, chkDimmer2MG2Ch05.Checked, chkDimmer2MG3Ch05.Checked, chkDimmer2MG4Ch05.Checked };
            dim2Group06 = new bool[] { chkDimmer2MG1Ch06.Checked, chkDimmer2MG2Ch06.Checked, chkDimmer2MG3Ch06.Checked, chkDimmer2MG4Ch06.Checked };
            dim2Group07 = new bool[] { chkDimmer2MG1Ch07.Checked, chkDimmer2MG2Ch07.Checked, chkDimmer2MG3Ch07.Checked, chkDimmer2MG4Ch07.Checked };
            dim2Group08 = new bool[] { chkDimmer2MG1Ch08.Checked, chkDimmer2MG2Ch08.Checked, chkDimmer2MG3Ch08.Checked, chkDimmer2MG4Ch08.Checked };
            dim2Group09 = new bool[] { chkDimmer2MG1Ch09.Checked, chkDimmer2MG2Ch09.Checked, chkDimmer2MG3Ch09.Checked, chkDimmer2MG4Ch09.Checked };
            dim2Group10 = new bool[] { chkDimmer2MG1Ch10.Checked, chkDimmer2MG2Ch10.Checked, chkDimmer2MG3Ch10.Checked, chkDimmer2MG4Ch10.Checked };
            dim2Group11 = new bool[] { chkDimmer2MG1Ch11.Checked, chkDimmer2MG2Ch11.Checked, chkDimmer2MG3Ch11.Checked, chkDimmer2MG4Ch11.Checked };
            dim2Groups = new bool[][] { dim2Group00, dim2Group01, dim2Group02, dim2Group03, dim2Group04, dim2Group05, dim2Group06, dim2Group07, dim2Group08, dim2Group09, dim2Group10, dim2Group11 };

            dim3Group00 = new bool[] { chkDimmer3MG1Ch00.Checked, chkDimmer3MG2Ch00.Checked, chkDimmer3MG3Ch00.Checked, chkDimmer3MG4Ch00.Checked };
            dim3Group01 = new bool[] { chkDimmer3MG1Ch01.Checked, chkDimmer3MG2Ch01.Checked, chkDimmer3MG3Ch01.Checked, chkDimmer3MG4Ch01.Checked };
            dim3Group02 = new bool[] { chkDimmer3MG1Ch02.Checked, chkDimmer3MG2Ch02.Checked, chkDimmer3MG3Ch02.Checked, chkDimmer3MG4Ch02.Checked };
            dim3Group03 = new bool[] { chkDimmer3MG1Ch03.Checked, chkDimmer3MG2Ch03.Checked, chkDimmer3MG3Ch03.Checked, chkDimmer3MG4Ch03.Checked };
            dim3Group04 = new bool[] { chkDimmer3MG1Ch04.Checked, chkDimmer3MG2Ch04.Checked, chkDimmer3MG3Ch04.Checked, chkDimmer3MG4Ch04.Checked };
            dim3Group05 = new bool[] { chkDimmer3MG1Ch05.Checked, chkDimmer3MG2Ch05.Checked, chkDimmer3MG3Ch05.Checked, chkDimmer3MG4Ch05.Checked };
            dim3Group06 = new bool[] { chkDimmer3MG1Ch06.Checked, chkDimmer3MG2Ch06.Checked, chkDimmer3MG3Ch06.Checked, chkDimmer3MG4Ch06.Checked };
            dim3Group07 = new bool[] { chkDimmer3MG1Ch07.Checked, chkDimmer3MG2Ch07.Checked, chkDimmer3MG3Ch07.Checked, chkDimmer3MG4Ch07.Checked };
            dim3Group08 = new bool[] { chkDimmer3MG1Ch08.Checked, chkDimmer3MG2Ch08.Checked, chkDimmer3MG3Ch08.Checked, chkDimmer3MG4Ch08.Checked };
            dim3Group09 = new bool[] { chkDimmer3MG1Ch09.Checked, chkDimmer3MG2Ch09.Checked, chkDimmer3MG3Ch09.Checked, chkDimmer3MG4Ch09.Checked };
            dim3Group10 = new bool[] { chkDimmer3MG1Ch10.Checked, chkDimmer3MG2Ch10.Checked, chkDimmer3MG3Ch10.Checked, chkDimmer3MG4Ch10.Checked };
            dim3Group11 = new bool[] { chkDimmer3MG1Ch11.Checked, chkDimmer3MG2Ch11.Checked, chkDimmer3MG3Ch11.Checked, chkDimmer3MG4Ch11.Checked };
            dim3Groups = new bool[][] { dim3Group00, dim3Group01, dim3Group02, dim3Group03, dim3Group04, dim3Group05, dim3Group06, dim3Group07, dim3Group08, dim3Group09, dim3Group10, dim3Group11 };

            dim4Group00 = new bool[] { chkDimmer4MG1Ch00.Checked, chkDimmer4MG2Ch00.Checked, chkDimmer4MG3Ch00.Checked, chkDimmer4MG4Ch00.Checked };
            dim4Group01 = new bool[] { chkDimmer4MG1Ch01.Checked, chkDimmer4MG2Ch01.Checked, chkDimmer4MG3Ch01.Checked, chkDimmer4MG4Ch01.Checked };
            dim4Group02 = new bool[] { chkDimmer4MG1Ch02.Checked, chkDimmer4MG2Ch02.Checked, chkDimmer4MG3Ch02.Checked, chkDimmer4MG4Ch02.Checked };
            dim4Group03 = new bool[] { chkDimmer4MG1Ch03.Checked, chkDimmer4MG2Ch03.Checked, chkDimmer4MG3Ch03.Checked, chkDimmer4MG4Ch03.Checked };
            dim4Group04 = new bool[] { chkDimmer4MG1Ch04.Checked, chkDimmer4MG2Ch04.Checked, chkDimmer4MG3Ch04.Checked, chkDimmer4MG4Ch04.Checked };
            dim4Group05 = new bool[] { chkDimmer4MG1Ch05.Checked, chkDimmer4MG2Ch05.Checked, chkDimmer4MG3Ch05.Checked, chkDimmer4MG4Ch05.Checked };
            dim4Group06 = new bool[] { chkDimmer4MG1Ch06.Checked, chkDimmer4MG2Ch06.Checked, chkDimmer4MG3Ch06.Checked, chkDimmer4MG4Ch06.Checked };
            dim4Group07 = new bool[] { chkDimmer4MG1Ch07.Checked, chkDimmer4MG2Ch07.Checked, chkDimmer4MG3Ch07.Checked, chkDimmer4MG4Ch07.Checked };
            dim4Group08 = new bool[] { chkDimmer4MG1Ch08.Checked, chkDimmer4MG2Ch08.Checked, chkDimmer4MG3Ch08.Checked, chkDimmer4MG4Ch08.Checked };
            dim4Group09 = new bool[] { chkDimmer4MG1Ch09.Checked, chkDimmer4MG2Ch09.Checked, chkDimmer4MG3Ch09.Checked, chkDimmer4MG4Ch09.Checked };
            dim4Group10 = new bool[] { chkDimmer4MG1Ch10.Checked, chkDimmer4MG2Ch10.Checked, chkDimmer4MG3Ch10.Checked, chkDimmer4MG4Ch10.Checked };
            dim4Group11 = new bool[] { chkDimmer4MG1Ch11.Checked, chkDimmer4MG2Ch11.Checked, chkDimmer4MG3Ch11.Checked, chkDimmer4MG4Ch11.Checked };
            dim4Groups = new bool[][] { dim4Group00, dim4Group01, dim4Group02, dim4Group03, dim4Group04, dim4Group05, dim4Group06, dim4Group07, dim4Group08, dim4Group09, dim4Group10, dim4Group11 };

            dim5Group00 = new bool[] { chkDimmer5MG1Ch00.Checked, chkDimmer5MG2Ch00.Checked, chkDimmer5MG3Ch00.Checked, chkDimmer5MG4Ch00.Checked };
            dim5Group01 = new bool[] { chkDimmer5MG1Ch01.Checked, chkDimmer5MG2Ch01.Checked, chkDimmer5MG3Ch01.Checked, chkDimmer5MG4Ch01.Checked };
            dim5Group02 = new bool[] { chkDimmer5MG1Ch02.Checked, chkDimmer5MG2Ch02.Checked, chkDimmer5MG3Ch02.Checked, chkDimmer5MG4Ch02.Checked };
            dim5Group03 = new bool[] { chkDimmer5MG1Ch03.Checked, chkDimmer5MG2Ch03.Checked, chkDimmer5MG3Ch03.Checked, chkDimmer5MG4Ch03.Checked };
            dim5Group04 = new bool[] { chkDimmer5MG1Ch04.Checked, chkDimmer5MG2Ch04.Checked, chkDimmer5MG3Ch04.Checked, chkDimmer5MG4Ch04.Checked };
            dim5Group05 = new bool[] { chkDimmer5MG1Ch05.Checked, chkDimmer5MG2Ch05.Checked, chkDimmer5MG3Ch05.Checked, chkDimmer5MG4Ch05.Checked };
            dim5Group06 = new bool[] { chkDimmer5MG1Ch06.Checked, chkDimmer5MG2Ch06.Checked, chkDimmer5MG3Ch06.Checked, chkDimmer5MG4Ch06.Checked };
            dim5Group07 = new bool[] { chkDimmer5MG1Ch07.Checked, chkDimmer5MG2Ch07.Checked, chkDimmer5MG3Ch07.Checked, chkDimmer5MG4Ch07.Checked };
            dim5Group08 = new bool[] { chkDimmer5MG1Ch08.Checked, chkDimmer5MG2Ch08.Checked, chkDimmer5MG3Ch08.Checked, chkDimmer5MG4Ch08.Checked };
            dim5Group09 = new bool[] { chkDimmer5MG1Ch09.Checked, chkDimmer5MG2Ch09.Checked, chkDimmer5MG3Ch09.Checked, chkDimmer5MG4Ch09.Checked };
            dim5Group10 = new bool[] { chkDimmer5MG1Ch10.Checked, chkDimmer5MG2Ch10.Checked, chkDimmer5MG3Ch10.Checked, chkDimmer5MG4Ch10.Checked };
            dim5Group11 = new bool[] { chkDimmer5MG1Ch11.Checked, chkDimmer5MG2Ch11.Checked, chkDimmer5MG3Ch11.Checked, chkDimmer5MG4Ch11.Checked };
            dim5Groups = new bool[][] { dim5Group00, dim5Group01, dim5Group02, dim5Group03, dim5Group04, dim5Group05, dim5Group06, dim5Group07, dim5Group08, dim5Group09, dim5Group10, dim5Group11 };

            dim6Group00 = new bool[] { chkDimmer6MG1Ch00.Checked, chkDimmer6MG2Ch00.Checked, chkDimmer6MG3Ch00.Checked, chkDimmer6MG4Ch00.Checked };
            dim6Group01 = new bool[] { chkDimmer6MG1Ch01.Checked, chkDimmer6MG2Ch01.Checked, chkDimmer6MG3Ch01.Checked, chkDimmer6MG4Ch01.Checked };
            dim6Group02 = new bool[] { chkDimmer6MG1Ch02.Checked, chkDimmer6MG2Ch02.Checked, chkDimmer6MG3Ch02.Checked, chkDimmer6MG4Ch02.Checked };
            dim6Group03 = new bool[] { chkDimmer6MG1Ch03.Checked, chkDimmer6MG2Ch03.Checked, chkDimmer6MG3Ch03.Checked, chkDimmer6MG4Ch03.Checked };
            dim6Group04 = new bool[] { chkDimmer6MG1Ch04.Checked, chkDimmer6MG2Ch04.Checked, chkDimmer6MG3Ch04.Checked, chkDimmer6MG4Ch04.Checked };
            dim6Group05 = new bool[] { chkDimmer6MG1Ch05.Checked, chkDimmer6MG2Ch05.Checked, chkDimmer6MG3Ch05.Checked, chkDimmer6MG4Ch05.Checked };
            dim6Group06 = new bool[] { chkDimmer6MG1Ch06.Checked, chkDimmer6MG2Ch06.Checked, chkDimmer6MG3Ch06.Checked, chkDimmer6MG4Ch06.Checked };
            dim6Group07 = new bool[] { chkDimmer6MG1Ch07.Checked, chkDimmer6MG2Ch07.Checked, chkDimmer6MG3Ch07.Checked, chkDimmer6MG4Ch07.Checked };
            dim6Group08 = new bool[] { chkDimmer6MG1Ch08.Checked, chkDimmer6MG2Ch08.Checked, chkDimmer6MG3Ch08.Checked, chkDimmer6MG4Ch08.Checked };
            dim6Group09 = new bool[] { chkDimmer6MG1Ch09.Checked, chkDimmer6MG2Ch09.Checked, chkDimmer6MG3Ch09.Checked, chkDimmer6MG4Ch09.Checked };
            dim6Group10 = new bool[] { chkDimmer6MG1Ch10.Checked, chkDimmer6MG2Ch10.Checked, chkDimmer6MG3Ch10.Checked, chkDimmer6MG4Ch10.Checked };
            dim6Group11 = new bool[] { chkDimmer6MG1Ch11.Checked, chkDimmer6MG2Ch11.Checked, chkDimmer6MG3Ch11.Checked, chkDimmer6MG4Ch11.Checked };
            dim6Groups = new bool[][] { dim6Group00, dim6Group01, dim6Group02, dim6Group03, dim6Group04, dim6Group05, dim6Group06, dim6Group07, dim6Group08, dim6Group09, dim6Group10, dim6Group11 };

            List<bool[][]> dimGroups = new List<bool[][]>();
            dimGroups.Add(dim1Groups);
            dimGroups.Add(dim2Groups);
            dimGroups.Add(dim3Groups);
            dimGroups.Add(dim4Groups);
            dimGroups.Add(dim5Groups);
            dimGroups.Add(dim6Groups);

            // Dimmer cards
            for (int card = 0; card < Convert.ToInt16(cmbStartDimmer.Text); card++)
            {
                dimmerObjects[card].SetDevAddr(dimCardNum[card].SelectedIndex, dimPanelNum[card].SelectedIndex);
                dimmerObjects[card].SetCfgRev(dimConfigRev[card].Text);
                dimmerObjects[card].SetCfgType(dimConfigType[card].Text);
                dimmerObjects[card].SetDCDimmer(true); // hard coding for dimmer card
                dimmerObjects[card].SetDCMotor(dimDCMotor[card].Checked);
                dimmerObjects[card].SetShade(dimShade[card].Checked);
                dimmerObjects[card].SetForce(dimForce[card].Checked);
                dimmerObjects[card].SetBaseIndex(dimBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    dimmerObjects[card].SetOCAmps(channel, dimmerOCAmps[card][channel].Text);
                    dimmerObjects[card].SetOCTime(channel, dimmerOCTime[card][channel].Text);
                    dimmerObjects[card].SetGroup0(dimGroups[card][channel], channel); // takes care of all 4 groups
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

            bool[] checkDimmer = new bool[] { CheckDimmer1(), CheckDimmer2(), CheckDimmer3(), CheckDimmer4(), CheckDimmer5(), CheckDimmer6() };

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

        private bool CheckDimmer2()
        {
            return ((cmbDimmer2CardNum.Text != "") && (cmbDimmer2PanelNum.Text != "") && (tbxDimmer2BaseIndex.Text != ""));
        }

        private bool CheckDimmer3()
        {
            return ((cmbDimmer3CardNum.Text != "") && (cmbDimmer3PanelNum.Text != "") && (tbxDimmer3BaseIndex.Text != ""));
        }

        private bool CheckDimmer4()
        {
            return ((cmbDimmer4CardNum.Text != "") && (cmbDimmer4PanelNum.Text != "") && (tbxDimmer4BaseIndex.Text != ""));
        }

        private bool CheckDimmer5()
        {
            return ((cmbDimmer5CardNum.Text != "") && (cmbDimmer5PanelNum.Text != "") && (tbxDimmer5BaseIndex.Text != ""));
        }

        private bool CheckDimmer6()
        {
            return ((cmbDimmer6CardNum.Text != "") && (cmbDimmer6PanelNum.Text != "") && (tbxDimmer6BaseIndex.Text != ""));
        }

        private void btnDimmerCard1_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard1);
            tabControlDimmer.SelectedIndex = 1;
            if (cmbStartDimmer.Text == "Full") tabControlDimmer1QF.SelectedIndex = 1;
            else tabControlDimmer1QF.SelectedIndex = 0;
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
            Button[] btnArray = { btnDimmerCard1, btnDimmerCard2, btnDimmerCard3, btnDimmerCard4, btnDimmerCard5, btnDimmerCard6 };

            for (int i = 0; i < argInt; i++)
            {
                btnArray[i].Visible = true;
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

        private void tbxDimmer2BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblDimmer2Ch00.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 0);
            lblDimmer2Ch01.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 1);
            lblDimmer2Ch02.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 2);
            lblDimmer2Ch03.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 3);
            lblDimmer2Ch04.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 4);
            lblDimmer2Ch05.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 5);
            lblDimmer2Ch06.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 6);
            lblDimmer2Ch07.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 7);
            lblDimmer2Ch08.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 8);
            lblDimmer2Ch09.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 9);
            lblDimmer2Ch10.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 10);
            lblDimmer2Ch11.Text = ChangeChannelLabel(tbxDimmer2BaseIndex.Text, 11);
            CheckDimGenerate();
        }

        private void tbxDimmer3BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblDimmer3Ch00.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 0);
            lblDimmer3Ch01.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 1);
            lblDimmer3Ch02.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 2);
            lblDimmer3Ch03.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 3);
            lblDimmer3Ch04.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 4);
            lblDimmer3Ch05.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 5);
            lblDimmer3Ch06.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 6);
            lblDimmer3Ch07.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 7);
            lblDimmer3Ch08.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 8);
            lblDimmer3Ch09.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 9);
            lblDimmer3Ch10.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 10);
            lblDimmer3Ch11.Text = ChangeChannelLabel(tbxDimmer3BaseIndex.Text, 11);
            CheckDimGenerate();
        }

        private void tbxDimmer4BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblDimmer4Ch00.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 0);
            lblDimmer4Ch01.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 1);
            lblDimmer4Ch02.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 2);
            lblDimmer4Ch03.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 3);
            lblDimmer4Ch04.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 4);
            lblDimmer4Ch05.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 5);
            lblDimmer4Ch06.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 6);
            lblDimmer4Ch07.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 7);
            lblDimmer4Ch08.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 8);
            lblDimmer4Ch09.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 9);
            lblDimmer4Ch10.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 10);
            lblDimmer4Ch11.Text = ChangeChannelLabel(tbxDimmer4BaseIndex.Text, 11);
            CheckDimGenerate();
        }

        private void tbxDimmer5BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblDimmer5Ch00.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 0);
            lblDimmer5Ch01.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 1);
            lblDimmer5Ch02.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 2);
            lblDimmer5Ch03.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 3);
            lblDimmer5Ch04.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 4);
            lblDimmer5Ch05.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 5);
            lblDimmer5Ch06.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 6);
            lblDimmer5Ch07.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 7);
            lblDimmer5Ch08.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 8);
            lblDimmer5Ch09.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 9);
            lblDimmer5Ch10.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 10);
            lblDimmer5Ch11.Text = ChangeChannelLabel(tbxDimmer5BaseIndex.Text, 11);
            CheckDimGenerate();
        }

        private void tbxDimmer6BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblDimmer6Ch00.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 0);
            lblDimmer6Ch01.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 1);
            lblDimmer6Ch02.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 2);
            lblDimmer6Ch03.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 3);
            lblDimmer6Ch04.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 4);
            lblDimmer6Ch05.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 5);
            lblDimmer6Ch06.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 6);
            lblDimmer6Ch07.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 7);
            lblDimmer6Ch08.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 8);
            lblDimmer6Ch09.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 9);
            lblDimmer6Ch10.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 10);
            lblDimmer6Ch11.Text = ChangeChannelLabel(tbxDimmer6BaseIndex.Text, 11);
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

        private void btnHCGenerate_Click(object sender, EventArgs e)
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

            hc2Group00 = new bool[] { chkHC2MG1Ch00.Checked, chkHC2MG2Ch00.Checked, chkHC2MG3Ch00.Checked, chkHC2MG4Ch00.Checked };
            hc2Group01 = new bool[] { chkHC2MG1Ch01.Checked, chkHC2MG2Ch01.Checked, chkHC2MG3Ch01.Checked, chkHC2MG4Ch01.Checked };
            hc2Group02 = new bool[] { chkHC2MG1Ch02.Checked, chkHC2MG2Ch02.Checked, chkHC2MG3Ch02.Checked, chkHC2MG4Ch02.Checked };
            hc2Group03 = new bool[] { chkHC2MG1Ch03.Checked, chkHC2MG2Ch03.Checked, chkHC2MG3Ch03.Checked, chkHC2MG4Ch03.Checked };
            hc2Group04 = new bool[] { chkHC2MG1Ch04.Checked, chkHC2MG2Ch04.Checked, chkHC2MG3Ch04.Checked, chkHC2MG4Ch04.Checked };
            hc2Group05 = new bool[] { chkHC2MG1Ch05.Checked, chkHC2MG2Ch05.Checked, chkHC2MG3Ch05.Checked, chkHC2MG4Ch05.Checked };
            hc2Group06 = new bool[] { chkHC2MG1Ch06.Checked, chkHC2MG2Ch06.Checked, chkHC2MG3Ch06.Checked, chkHC2MG4Ch06.Checked };
            hc2Group07 = new bool[] { chkHC2MG1Ch07.Checked, chkHC2MG2Ch07.Checked, chkHC2MG3Ch07.Checked, chkHC2MG4Ch07.Checked };
            hc2Group08 = new bool[] { chkHC2MG1Ch08.Checked, chkHC2MG2Ch08.Checked, chkHC2MG3Ch08.Checked, chkHC2MG4Ch08.Checked };
            hc2Group09 = new bool[] { chkHC2MG1Ch09.Checked, chkHC2MG2Ch09.Checked, chkHC2MG3Ch09.Checked, chkHC2MG4Ch09.Checked };
            hc2Group10 = new bool[] { chkHC2MG1Ch10.Checked, chkHC2MG2Ch10.Checked, chkHC2MG3Ch10.Checked, chkHC2MG4Ch10.Checked };
            hc2Group11 = new bool[] { chkHC2MG1Ch11.Checked, chkHC2MG2Ch11.Checked, chkHC2MG3Ch11.Checked, chkHC2MG4Ch11.Checked };
            hc2Groups = new bool[][] { hc2Group00, hc2Group01, hc2Group02, hc2Group03, hc2Group04, hc2Group05, hc2Group06, hc2Group07, hc2Group08, hc2Group09, hc2Group10, hc2Group11 };

            hc3Group00 = new bool[] { chkHC3MG1Ch00.Checked, chkHC3MG2Ch00.Checked, chkHC3MG3Ch00.Checked, chkHC3MG4Ch00.Checked };
            hc3Group01 = new bool[] { chkHC3MG1Ch01.Checked, chkHC3MG2Ch01.Checked, chkHC3MG3Ch01.Checked, chkHC3MG4Ch01.Checked };
            hc3Group02 = new bool[] { chkHC3MG1Ch02.Checked, chkHC3MG2Ch02.Checked, chkHC3MG3Ch02.Checked, chkHC3MG4Ch02.Checked };
            hc3Group03 = new bool[] { chkHC3MG1Ch03.Checked, chkHC3MG2Ch03.Checked, chkHC3MG3Ch03.Checked, chkHC3MG4Ch03.Checked };
            hc3Group04 = new bool[] { chkHC3MG1Ch04.Checked, chkHC3MG2Ch04.Checked, chkHC3MG3Ch04.Checked, chkHC3MG4Ch04.Checked };
            hc3Group05 = new bool[] { chkHC3MG1Ch05.Checked, chkHC3MG2Ch05.Checked, chkHC3MG3Ch05.Checked, chkHC3MG4Ch05.Checked };
            hc3Group06 = new bool[] { chkHC3MG1Ch06.Checked, chkHC3MG2Ch06.Checked, chkHC3MG3Ch06.Checked, chkHC3MG4Ch06.Checked };
            hc3Group07 = new bool[] { chkHC3MG1Ch07.Checked, chkHC3MG2Ch07.Checked, chkHC3MG3Ch07.Checked, chkHC3MG4Ch07.Checked };
            hc3Group08 = new bool[] { chkHC3MG1Ch08.Checked, chkHC3MG2Ch08.Checked, chkHC3MG3Ch08.Checked, chkHC3MG4Ch08.Checked };
            hc3Group09 = new bool[] { chkHC3MG1Ch09.Checked, chkHC3MG2Ch09.Checked, chkHC3MG3Ch09.Checked, chkHC3MG4Ch09.Checked };
            hc3Group10 = new bool[] { chkHC3MG1Ch10.Checked, chkHC3MG2Ch10.Checked, chkHC3MG3Ch10.Checked, chkHC3MG4Ch10.Checked };
            hc3Group11 = new bool[] { chkHC3MG1Ch11.Checked, chkHC3MG2Ch11.Checked, chkHC3MG3Ch11.Checked, chkHC3MG4Ch11.Checked };
            hc3Groups = new bool[][] { hc3Group00, hc3Group01, hc3Group02, hc3Group03, hc3Group04, hc3Group05, hc3Group06, hc3Group07, hc3Group08, hc3Group09, hc3Group10, hc3Group11 };

            hc4Group00 = new bool[] { chkHC4MG1Ch00.Checked, chkHC4MG2Ch00.Checked, chkHC4MG3Ch00.Checked, chkHC4MG4Ch00.Checked };
            hc4Group01 = new bool[] { chkHC4MG1Ch01.Checked, chkHC4MG2Ch01.Checked, chkHC4MG3Ch01.Checked, chkHC4MG4Ch01.Checked };
            hc4Group02 = new bool[] { chkHC4MG1Ch02.Checked, chkHC4MG2Ch02.Checked, chkHC4MG3Ch02.Checked, chkHC4MG4Ch02.Checked };
            hc4Group03 = new bool[] { chkHC4MG1Ch03.Checked, chkHC4MG2Ch03.Checked, chkHC4MG3Ch03.Checked, chkHC4MG4Ch03.Checked };
            hc4Group04 = new bool[] { chkHC4MG1Ch04.Checked, chkHC4MG2Ch04.Checked, chkHC4MG3Ch04.Checked, chkHC4MG4Ch04.Checked };
            hc4Group05 = new bool[] { chkHC4MG1Ch05.Checked, chkHC4MG2Ch05.Checked, chkHC4MG3Ch05.Checked, chkHC4MG4Ch05.Checked };
            hc4Group06 = new bool[] { chkHC4MG1Ch06.Checked, chkHC4MG2Ch06.Checked, chkHC4MG3Ch06.Checked, chkHC4MG4Ch06.Checked };
            hc4Group07 = new bool[] { chkHC4MG1Ch07.Checked, chkHC4MG2Ch07.Checked, chkHC4MG3Ch07.Checked, chkHC4MG4Ch07.Checked };
            hc4Group08 = new bool[] { chkHC4MG1Ch08.Checked, chkHC4MG2Ch08.Checked, chkHC4MG3Ch08.Checked, chkHC4MG4Ch08.Checked };
            hc4Group09 = new bool[] { chkHC4MG1Ch09.Checked, chkHC4MG2Ch09.Checked, chkHC4MG3Ch09.Checked, chkHC4MG4Ch09.Checked };
            hc4Group10 = new bool[] { chkHC4MG1Ch10.Checked, chkHC4MG2Ch10.Checked, chkHC4MG3Ch10.Checked, chkHC4MG4Ch10.Checked };
            hc4Group11 = new bool[] { chkHC4MG1Ch11.Checked, chkHC4MG2Ch11.Checked, chkHC4MG3Ch11.Checked, chkHC4MG4Ch11.Checked };
            hc4Groups = new bool[][] { hc4Group00, hc4Group01, hc4Group02, hc4Group03, hc4Group04, hc4Group05, hc4Group06, hc4Group07, hc4Group08, hc4Group09, hc4Group10, hc4Group11 };

            hc5Group00 = new bool[] { chkHC5MG1Ch00.Checked, chkHC5MG2Ch00.Checked, chkHC5MG3Ch00.Checked, chkHC5MG4Ch00.Checked };
            hc5Group01 = new bool[] { chkHC5MG1Ch01.Checked, chkHC5MG2Ch01.Checked, chkHC5MG3Ch01.Checked, chkHC5MG4Ch01.Checked };
            hc5Group02 = new bool[] { chkHC5MG1Ch02.Checked, chkHC5MG2Ch02.Checked, chkHC5MG3Ch02.Checked, chkHC5MG4Ch02.Checked };
            hc5Group03 = new bool[] { chkHC5MG1Ch03.Checked, chkHC5MG2Ch03.Checked, chkHC5MG3Ch03.Checked, chkHC5MG4Ch03.Checked };
            hc5Group04 = new bool[] { chkHC5MG1Ch04.Checked, chkHC5MG2Ch04.Checked, chkHC5MG3Ch04.Checked, chkHC5MG4Ch04.Checked };
            hc5Group05 = new bool[] { chkHC5MG1Ch05.Checked, chkHC5MG2Ch05.Checked, chkHC5MG3Ch05.Checked, chkHC5MG4Ch05.Checked };
            hc5Group06 = new bool[] { chkHC5MG1Ch06.Checked, chkHC5MG2Ch06.Checked, chkHC5MG3Ch06.Checked, chkHC5MG4Ch06.Checked };
            hc5Group07 = new bool[] { chkHC5MG1Ch07.Checked, chkHC5MG2Ch07.Checked, chkHC5MG3Ch07.Checked, chkHC5MG4Ch07.Checked };
            hc5Group08 = new bool[] { chkHC5MG1Ch08.Checked, chkHC5MG2Ch08.Checked, chkHC5MG3Ch08.Checked, chkHC5MG4Ch08.Checked };
            hc5Group09 = new bool[] { chkHC5MG1Ch09.Checked, chkHC5MG2Ch09.Checked, chkHC5MG3Ch09.Checked, chkHC5MG4Ch09.Checked };
            hc5Group10 = new bool[] { chkHC5MG1Ch10.Checked, chkHC5MG2Ch10.Checked, chkHC5MG3Ch10.Checked, chkHC5MG4Ch10.Checked };
            hc5Group11 = new bool[] { chkHC5MG1Ch11.Checked, chkHC5MG2Ch11.Checked, chkHC5MG3Ch11.Checked, chkHC5MG4Ch11.Checked };
            hc5Groups = new bool[][] { hc5Group00, hc5Group01, hc5Group02, hc5Group03, hc5Group04, hc5Group05, hc5Group06, hc5Group07, hc5Group08, hc5Group09, hc5Group10, hc5Group11 };

            hc6Group00 = new bool[] { chkHC6MG1Ch00.Checked, chkHC6MG2Ch00.Checked, chkHC6MG3Ch00.Checked, chkHC6MG4Ch00.Checked };
            hc6Group01 = new bool[] { chkHC6MG1Ch01.Checked, chkHC6MG2Ch01.Checked, chkHC6MG3Ch01.Checked, chkHC6MG4Ch01.Checked };
            hc6Group02 = new bool[] { chkHC6MG1Ch02.Checked, chkHC6MG2Ch02.Checked, chkHC6MG3Ch02.Checked, chkHC6MG4Ch02.Checked };
            hc6Group03 = new bool[] { chkHC6MG1Ch03.Checked, chkHC6MG2Ch03.Checked, chkHC6MG3Ch03.Checked, chkHC6MG4Ch03.Checked };
            hc6Group04 = new bool[] { chkHC6MG1Ch04.Checked, chkHC6MG2Ch04.Checked, chkHC6MG3Ch04.Checked, chkHC6MG4Ch04.Checked };
            hc6Group05 = new bool[] { chkHC6MG1Ch05.Checked, chkHC6MG2Ch05.Checked, chkHC6MG3Ch05.Checked, chkHC6MG4Ch05.Checked };
            hc6Group06 = new bool[] { chkHC6MG1Ch06.Checked, chkHC6MG2Ch06.Checked, chkHC6MG3Ch06.Checked, chkHC6MG4Ch06.Checked };
            hc6Group07 = new bool[] { chkHC6MG1Ch07.Checked, chkHC6MG2Ch07.Checked, chkHC6MG3Ch07.Checked, chkHC6MG4Ch07.Checked };
            hc6Group08 = new bool[] { chkHC6MG1Ch08.Checked, chkHC6MG2Ch08.Checked, chkHC6MG3Ch08.Checked, chkHC6MG4Ch08.Checked };
            hc6Group09 = new bool[] { chkHC6MG1Ch09.Checked, chkHC6MG2Ch09.Checked, chkHC6MG3Ch09.Checked, chkHC6MG4Ch09.Checked };
            hc6Group10 = new bool[] { chkHC6MG1Ch10.Checked, chkHC6MG2Ch10.Checked, chkHC6MG3Ch10.Checked, chkHC6MG4Ch10.Checked };
            hc6Group11 = new bool[] { chkHC6MG1Ch11.Checked, chkHC6MG2Ch11.Checked, chkHC6MG3Ch11.Checked, chkHC6MG4Ch11.Checked };
            hc6Groups = new bool[][] { hc6Group00, hc6Group01, hc6Group02, hc6Group03, hc6Group04, hc6Group05, hc6Group06, hc6Group07, hc6Group08, hc6Group09, hc6Group10, hc6Group11 };

            // needed to make a list of multidimensional arrays to pass to the group allocation function
            List<bool[][]> hcGroups = new List<bool[][]>();
            hcGroups.Add(hc1Groups);
            hcGroups.Add(hc2Groups);
            hcGroups.Add(hc3Groups);
            hcGroups.Add(hc4Groups);
            hcGroups.Add(hc5Groups);
            hcGroups.Add(hc6Groups);

            hc1Startup = new bool[] { chkHC1Startup00.Checked, chkHC1Startup01.Checked, chkHC1Startup02.Checked, chkHC1Startup03.Checked, chkHC1Startup04.Checked, chkHC1Startup05.Checked, chkHC1Startup06.Checked, chkHC1Startup07.Checked, chkHC1Startup08.Checked, chkHC1Startup09.Checked, chkHC1Startup10.Checked, chkHC1Startup11.Checked };
            hc2Startup = new bool[] { chkHC2Startup00.Checked, chkHC2Startup01.Checked, chkHC2Startup02.Checked, chkHC2Startup03.Checked, chkHC2Startup04.Checked, chkHC2Startup05.Checked, chkHC2Startup06.Checked, chkHC2Startup07.Checked, chkHC2Startup08.Checked, chkHC2Startup09.Checked, chkHC2Startup10.Checked, chkHC2Startup11.Checked };
            hc3Startup = new bool[] { chkHC3Startup00.Checked, chkHC3Startup01.Checked, chkHC3Startup02.Checked, chkHC3Startup03.Checked, chkHC3Startup04.Checked, chkHC3Startup05.Checked, chkHC3Startup06.Checked, chkHC3Startup07.Checked, chkHC3Startup08.Checked, chkHC3Startup09.Checked, chkHC3Startup10.Checked, chkHC3Startup11.Checked };
            hc4Startup = new bool[] { chkHC4Startup00.Checked, chkHC4Startup01.Checked, chkHC4Startup02.Checked, chkHC4Startup03.Checked, chkHC4Startup04.Checked, chkHC4Startup05.Checked, chkHC4Startup06.Checked, chkHC4Startup07.Checked, chkHC4Startup08.Checked, chkHC4Startup09.Checked, chkHC4Startup10.Checked, chkHC4Startup11.Checked };
            hc5Startup = new bool[] { chkHC5Startup00.Checked, chkHC5Startup01.Checked, chkHC5Startup02.Checked, chkHC5Startup03.Checked, chkHC5Startup04.Checked, chkHC5Startup05.Checked, chkHC5Startup06.Checked, chkHC5Startup07.Checked, chkHC5Startup08.Checked, chkHC5Startup09.Checked, chkHC5Startup10.Checked, chkHC5Startup11.Checked };
            hc6Startup = new bool[] { chkHC6Startup00.Checked, chkHC6Startup01.Checked, chkHC6Startup02.Checked, chkHC6Startup03.Checked, chkHC6Startup04.Checked, chkHC6Startup05.Checked, chkHC6Startup06.Checked, chkHC6Startup07.Checked, chkHC6Startup08.Checked, chkHC6Startup09.Checked, chkHC6Startup10.Checked, chkHC6Startup11.Checked };
            hcStartup = new bool[][] { hc1Startup, hc2Startup, hc3Startup, hc4Startup, hc5Startup, hc6Startup };

            // HC cards
            for (int card = 0; card < Convert.ToInt16(cmbStartHC.Text); card++)
            {
                hcObjects[card].SetDevAddr(hcCardNum[card].SelectedIndex, hcPanelNum[card].SelectedIndex);
                hcObjects[card].SetCfgRev(hcConfigRev[card].Text);
                hcObjects[card].SetCfgType(hcConfigType[card].Text);
                hcObjects[card].SetDCDimmer(hcDCDimmer[card].Checked);
                hcObjects[card].SetRGB(hcRGB[card].Checked);
                hcObjects[card].SetDCMotor(hcDCMotor[card].Checked);
                hcObjects[card].SetShade(hcShade[card].Checked);
                hcObjects[card].SetForce(hcForce[card].Checked);
                hcObjects[card].SetBaseIndex(hcBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    hcObjects[card].SetOCAmps(channel, hcOCAmps[card][channel].Text);
                    hcObjects[card].SetOCTime(channel, hcOCTime[card][channel].Text);
                    hcObjects[card].SetGroup0(hcGroups[card][channel], channel); // takes care of all 4 groups
                    hcObjects[card].SetModeAndPairing(channel, hcModes[card][channel].Text, hcStartup[card][channel]); // mode, pairing, and direction (startup)
                }
            }

            hcObjects.ForEach(hcObjects => hcObjects.CreateHCFile());
            CreateHCReferenceFile();
            HCCardNavColor(btnHCGenerate);
            tabControlHC.SelectedIndex = 7;
            string[] hcFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxHCGenerated.Lines = hcFiles;
        }

        private void CreateHCReferenceFile()
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h", "DevAddrE.h", "DevAddrF.h" };

            using (StreamWriter sw = File.CreateText(@"M1_DcDriver_Config\Src\M1_HC_Bridge\DeviceConfigs\DevAddrConfigs.h"))
            {
                for (int i = 0; i < Convert.ToInt16(cmbStartHC.Text); i++)
                {
                    sw.WriteLine("#include \"" + configNamesReference[i] + "\"");
                }
            }
        }

        private void CheckHCGenerate()
        {
            int checkCounter = 0;
            int numHCCards = Convert.ToInt16(cmbStartHC.Text);

            bool[] checkHC = new bool[] { CheckHC1(), CheckHC2(), CheckHC3(), CheckHC4(), CheckHC5(), CheckHC6(), };

            for (int i = 0; i < numHCCards; i++)
            {
                if (checkHC[i] == true)
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

        private bool CheckHC1()
        {
            return ((cmbHC1CardNum.Text != "") && (cmbHC1PanelNum.Text != "") && (tbxHC1BaseIndex.Text != ""));
        }

        private bool CheckHC2()
        {
            return ((cmbHC2CardNum.Text != "") && (cmbHC2PanelNum.Text != "") && (tbxHC2BaseIndex.Text != ""));
        }

        private bool CheckHC3()
        {
            return ((cmbHC3CardNum.Text != "") && (cmbHC3PanelNum.Text != "") && (tbxHC3BaseIndex.Text != ""));
        }

        private bool CheckHC4()
        {
            return ((cmbHC4CardNum.Text != "") && (cmbHC4PanelNum.Text != "") && (tbxHC4BaseIndex.Text != ""));
        }

        private bool CheckHC5()
        {
            return ((cmbHC5CardNum.Text != "") && (cmbHC5PanelNum.Text != "") && (tbxHC5BaseIndex.Text != ""));
        }

        private bool CheckHC6()
        {
            return ((cmbHC6CardNum.Text != "") && (cmbHC6PanelNum.Text != "") && (tbxHC6BaseIndex.Text != ""));
        }

        private void btnHCCard1_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard1);
            tabControlHC.SelectedIndex = 1;
        }

        private void btnHCCard2_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard2);
            tabControlHC.SelectedIndex = 2;
        }

        private void btnHCCard3_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard3);
            tabControlHC.SelectedIndex = 3;
        }

        private void btnHCCard4_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard4);
            tabControlHC.SelectedIndex = 4;
        }

        private void btnHCCard5_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard5);
            tabControlHC.SelectedIndex = 5;
        }

        private void btnHCCard6_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard6);
            tabControlHC.SelectedIndex = 6;
        }

        private void ShowHCNav(int argInt)
        {
            Button[] btnArray = { btnHCCard1, btnHCCard2, btnHCCard3, btnHCCard4, btnHCCard5, btnHCCard6 };

            for (int i = 0; i < argInt; i++)
            {
                btnArray[i].Visible = true;
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
            CheckHCGenerate();
        }

        private void cmbHC1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }


        private void cmbHC2CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC2PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC3CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC3PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC4CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC4PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC5CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC5PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC6CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void cmbHC6PanelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHCGenerate();
        }

        private void tbxHC1BaseIndex_TextChanged(object sender, EventArgs e)
        {
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

        private void tbxHC2BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblHC2Ch00.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 0);
            lblHC2Ch01.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 1);
            lblHC2Ch02.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 2);
            lblHC2Ch03.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 3);
            lblHC2Ch04.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 4);
            lblHC2Ch05.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 5);
            lblHC2Ch06.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 6);
            lblHC2Ch07.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 7);
            lblHC2Ch08.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 8);
            lblHC2Ch09.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 9);
            lblHC2Ch10.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 10);
            lblHC2Ch11.Text = ChangeChannelLabel(tbxHC2BaseIndex.Text, 11);
            CheckHCGenerate();
        }

        private void tbxHC3BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblHC3Ch00.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 0);
            lblHC3Ch01.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 1);
            lblHC3Ch02.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 2);
            lblHC3Ch03.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 3);
            lblHC3Ch04.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 4);
            lblHC3Ch05.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 5);
            lblHC3Ch06.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 6);
            lblHC3Ch07.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 7);
            lblHC3Ch08.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 8);
            lblHC3Ch09.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 9);
            lblHC3Ch10.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 10);
            lblHC3Ch11.Text = ChangeChannelLabel(tbxHC3BaseIndex.Text, 11);
            CheckHCGenerate();
        }

        private void tbxHC4BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblHC4Ch00.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 0);
            lblHC4Ch01.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 1);
            lblHC4Ch02.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 2);
            lblHC4Ch03.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 3);
            lblHC4Ch04.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 4);
            lblHC4Ch05.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 5);
            lblHC4Ch06.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 6);
            lblHC4Ch07.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 7);
            lblHC4Ch08.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 8);
            lblHC4Ch09.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 9);
            lblHC4Ch10.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 10);
            lblHC4Ch11.Text = ChangeChannelLabel(tbxHC4BaseIndex.Text, 11);
            CheckHCGenerate();
        }

        private void tbxHC5BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblHC5Ch00.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 0);
            lblHC5Ch01.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 1);
            lblHC5Ch02.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 2);
            lblHC5Ch03.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 3);
            lblHC5Ch04.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 4);
            lblHC5Ch05.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 5);
            lblHC5Ch06.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 6);
            lblHC5Ch07.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 7);
            lblHC5Ch08.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 8);
            lblHC5Ch09.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 9);
            lblHC5Ch10.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 10);
            lblHC5Ch11.Text = ChangeChannelLabel(tbxHC5BaseIndex.Text, 11);
            CheckHCGenerate();
        }

        private void tbxHC6BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblHC6Ch00.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 0);
            lblHC6Ch01.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 1);
            lblHC6Ch02.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 2);
            lblHC6Ch03.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 3);
            lblHC6Ch04.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 4);
            lblHC6Ch05.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 5);
            lblHC6Ch06.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 6);
            lblHC6Ch07.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 7);
            lblHC6Ch08.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 8);
            lblHC6Ch09.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 9);
            lblHC6Ch10.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 10);
            lblHC6Ch11.Text = ChangeChannelLabel(tbxHC6BaseIndex.Text, 11);
            CheckHCGenerate();
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

            lc2Group00 = new bool[] { chkLC2MG1Ch00.Checked, chkLC2MG2Ch00.Checked, chkLC2MG3Ch00.Checked, chkLC2MG4Ch00.Checked };
            lc2Group01 = new bool[] { chkLC2MG1Ch01.Checked, chkLC2MG2Ch01.Checked, chkLC2MG3Ch01.Checked, chkLC2MG4Ch01.Checked };
            lc2Group02 = new bool[] { chkLC2MG1Ch02.Checked, chkLC2MG2Ch02.Checked, chkLC2MG3Ch02.Checked, chkLC2MG4Ch02.Checked };
            lc2Group03 = new bool[] { chkLC2MG1Ch03.Checked, chkLC2MG2Ch03.Checked, chkLC2MG3Ch03.Checked, chkLC2MG4Ch03.Checked };
            lc2Group04 = new bool[] { chkLC2MG1Ch04.Checked, chkLC2MG2Ch04.Checked, chkLC2MG3Ch04.Checked, chkLC2MG4Ch04.Checked };
            lc2Group05 = new bool[] { chkLC2MG1Ch05.Checked, chkLC2MG2Ch05.Checked, chkLC2MG3Ch05.Checked, chkLC2MG4Ch05.Checked };
            lc2Group06 = new bool[] { chkLC2MG1Ch06.Checked, chkLC2MG2Ch06.Checked, chkLC2MG3Ch06.Checked, chkLC2MG4Ch06.Checked };
            lc2Group07 = new bool[] { chkLC2MG1Ch07.Checked, chkLC2MG2Ch07.Checked, chkLC2MG3Ch07.Checked, chkLC2MG4Ch07.Checked };
            lc2Group08 = new bool[] { chkLC2MG1Ch08.Checked, chkLC2MG2Ch08.Checked, chkLC2MG3Ch08.Checked, chkLC2MG4Ch08.Checked };
            lc2Group09 = new bool[] { chkLC2MG1Ch09.Checked, chkLC2MG2Ch09.Checked, chkLC2MG3Ch09.Checked, chkLC2MG4Ch09.Checked };
            lc2Group10 = new bool[] { chkLC2MG1Ch10.Checked, chkLC2MG2Ch10.Checked, chkLC2MG3Ch10.Checked, chkLC2MG4Ch10.Checked };
            lc2Group11 = new bool[] { chkLC2MG1Ch11.Checked, chkLC2MG2Ch11.Checked, chkLC2MG3Ch11.Checked, chkLC2MG4Ch11.Checked };
            lc2Group12 = new bool[] { chkLC2MG1Ch12.Checked, chkLC2MG2Ch12.Checked, chkLC2MG3Ch12.Checked, chkLC2MG4Ch12.Checked };
            lc2Group13 = new bool[] { chkLC2MG1Ch13.Checked, chkLC2MG2Ch13.Checked, chkLC2MG3Ch13.Checked, chkLC2MG4Ch13.Checked };
            lc2Group14 = new bool[] { chkLC2MG1Ch14.Checked, chkLC2MG2Ch14.Checked, chkLC2MG3Ch14.Checked, chkLC2MG4Ch14.Checked };
            lc2Group15 = new bool[] { chkLC2MG1Ch15.Checked, chkLC2MG2Ch15.Checked, chkLC2MG3Ch15.Checked, chkLC2MG4Ch15.Checked };
            lc2Groups = new bool[][] { lc2Group00, lc2Group01, lc2Group02, lc2Group03, lc2Group04, lc2Group05, lc2Group06, lc2Group07, lc2Group08, lc2Group09, lc2Group10, lc2Group11, lc2Group12, lc2Group13, lc2Group14, lc2Group15 };

            lc3Group00 = new bool[] { chkLC3MG1Ch00.Checked, chkLC3MG2Ch00.Checked, chkLC3MG3Ch00.Checked, chkLC3MG4Ch00.Checked };
            lc3Group01 = new bool[] { chkLC3MG1Ch01.Checked, chkLC3MG2Ch01.Checked, chkLC3MG3Ch01.Checked, chkLC3MG4Ch01.Checked };
            lc3Group02 = new bool[] { chkLC3MG1Ch02.Checked, chkLC3MG2Ch02.Checked, chkLC3MG3Ch02.Checked, chkLC3MG4Ch02.Checked };
            lc3Group03 = new bool[] { chkLC3MG1Ch03.Checked, chkLC3MG2Ch03.Checked, chkLC3MG3Ch03.Checked, chkLC3MG4Ch03.Checked };
            lc3Group04 = new bool[] { chkLC3MG1Ch04.Checked, chkLC3MG2Ch04.Checked, chkLC3MG3Ch04.Checked, chkLC3MG4Ch04.Checked };
            lc3Group05 = new bool[] { chkLC3MG1Ch05.Checked, chkLC3MG2Ch05.Checked, chkLC3MG3Ch05.Checked, chkLC3MG4Ch05.Checked };
            lc3Group06 = new bool[] { chkLC3MG1Ch06.Checked, chkLC3MG2Ch06.Checked, chkLC3MG3Ch06.Checked, chkLC3MG4Ch06.Checked };
            lc3Group07 = new bool[] { chkLC3MG1Ch07.Checked, chkLC3MG2Ch07.Checked, chkLC3MG3Ch07.Checked, chkLC3MG4Ch07.Checked };
            lc3Group08 = new bool[] { chkLC3MG1Ch08.Checked, chkLC3MG2Ch08.Checked, chkLC3MG3Ch08.Checked, chkLC3MG4Ch08.Checked };
            lc3Group09 = new bool[] { chkLC3MG1Ch09.Checked, chkLC3MG2Ch09.Checked, chkLC3MG3Ch09.Checked, chkLC3MG4Ch09.Checked };
            lc3Group10 = new bool[] { chkLC3MG1Ch10.Checked, chkLC3MG2Ch10.Checked, chkLC3MG3Ch10.Checked, chkLC3MG4Ch10.Checked };
            lc3Group11 = new bool[] { chkLC3MG1Ch11.Checked, chkLC3MG2Ch11.Checked, chkLC3MG3Ch11.Checked, chkLC3MG4Ch11.Checked };
            lc3Group12 = new bool[] { chkLC3MG1Ch12.Checked, chkLC3MG2Ch12.Checked, chkLC3MG3Ch12.Checked, chkLC3MG4Ch12.Checked };
            lc3Group13 = new bool[] { chkLC3MG1Ch13.Checked, chkLC3MG2Ch13.Checked, chkLC3MG3Ch13.Checked, chkLC3MG4Ch13.Checked };
            lc3Group14 = new bool[] { chkLC3MG1Ch14.Checked, chkLC3MG2Ch14.Checked, chkLC3MG3Ch14.Checked, chkLC3MG4Ch14.Checked };
            lc3Group15 = new bool[] { chkLC3MG1Ch15.Checked, chkLC3MG2Ch15.Checked, chkLC3MG3Ch15.Checked, chkLC3MG4Ch15.Checked };
            lc3Groups = new bool[][] { lc3Group00, lc3Group01, lc3Group02, lc3Group03, lc3Group04, lc3Group05, lc3Group06, lc3Group07, lc3Group08, lc3Group09, lc3Group10, lc3Group11, lc3Group12, lc3Group13, lc3Group14, lc3Group15 };

            lc4Group00 = new bool[] { chkLC4MG1Ch00.Checked, chkLC4MG2Ch00.Checked, chkLC4MG3Ch00.Checked, chkLC4MG4Ch00.Checked };
            lc4Group01 = new bool[] { chkLC4MG1Ch01.Checked, chkLC4MG2Ch01.Checked, chkLC4MG3Ch01.Checked, chkLC4MG4Ch01.Checked };
            lc4Group02 = new bool[] { chkLC4MG1Ch02.Checked, chkLC4MG2Ch02.Checked, chkLC4MG3Ch02.Checked, chkLC4MG4Ch02.Checked };
            lc4Group03 = new bool[] { chkLC4MG1Ch03.Checked, chkLC4MG2Ch03.Checked, chkLC4MG3Ch03.Checked, chkLC4MG4Ch03.Checked };
            lc4Group04 = new bool[] { chkLC4MG1Ch04.Checked, chkLC4MG2Ch04.Checked, chkLC4MG3Ch04.Checked, chkLC4MG4Ch04.Checked };
            lc4Group05 = new bool[] { chkLC4MG1Ch05.Checked, chkLC4MG2Ch05.Checked, chkLC4MG3Ch05.Checked, chkLC4MG4Ch05.Checked };
            lc4Group06 = new bool[] { chkLC4MG1Ch06.Checked, chkLC4MG2Ch06.Checked, chkLC4MG3Ch06.Checked, chkLC4MG4Ch06.Checked };
            lc4Group07 = new bool[] { chkLC4MG1Ch07.Checked, chkLC4MG2Ch07.Checked, chkLC4MG3Ch07.Checked, chkLC4MG4Ch07.Checked };
            lc4Group08 = new bool[] { chkLC4MG1Ch08.Checked, chkLC4MG2Ch08.Checked, chkLC4MG3Ch08.Checked, chkLC4MG4Ch08.Checked };
            lc4Group09 = new bool[] { chkLC4MG1Ch09.Checked, chkLC4MG2Ch09.Checked, chkLC4MG3Ch09.Checked, chkLC4MG4Ch09.Checked };
            lc4Group10 = new bool[] { chkLC4MG1Ch10.Checked, chkLC4MG2Ch10.Checked, chkLC4MG3Ch10.Checked, chkLC4MG4Ch10.Checked };
            lc4Group11 = new bool[] { chkLC4MG1Ch11.Checked, chkLC4MG2Ch11.Checked, chkLC4MG3Ch11.Checked, chkLC4MG4Ch11.Checked };
            lc4Group12 = new bool[] { chkLC4MG1Ch12.Checked, chkLC4MG2Ch12.Checked, chkLC4MG3Ch12.Checked, chkLC4MG4Ch12.Checked };
            lc4Group13 = new bool[] { chkLC4MG1Ch13.Checked, chkLC4MG2Ch13.Checked, chkLC4MG3Ch13.Checked, chkLC4MG4Ch13.Checked };
            lc4Group14 = new bool[] { chkLC4MG1Ch14.Checked, chkLC4MG2Ch14.Checked, chkLC4MG3Ch14.Checked, chkLC4MG4Ch14.Checked };
            lc4Group15 = new bool[] { chkLC4MG1Ch15.Checked, chkLC4MG2Ch15.Checked, chkLC4MG3Ch15.Checked, chkLC4MG4Ch15.Checked };
            lc4Groups = new bool[][] { lc4Group00, lc4Group01, lc4Group02, lc4Group03, lc4Group04, lc4Group05, lc4Group06, lc4Group07, lc4Group08, lc4Group09, lc4Group10, lc4Group11, lc4Group12, lc4Group13, lc4Group14, lc4Group15 };

            lc5Group00 = new bool[] { chkLC5MG1Ch00.Checked, chkLC5MG2Ch00.Checked, chkLC5MG3Ch00.Checked, chkLC5MG4Ch00.Checked };
            lc5Group01 = new bool[] { chkLC5MG1Ch01.Checked, chkLC5MG2Ch01.Checked, chkLC5MG3Ch01.Checked, chkLC5MG4Ch01.Checked };
            lc5Group02 = new bool[] { chkLC5MG1Ch02.Checked, chkLC5MG2Ch02.Checked, chkLC5MG3Ch02.Checked, chkLC5MG4Ch02.Checked };
            lc5Group03 = new bool[] { chkLC5MG1Ch03.Checked, chkLC5MG2Ch03.Checked, chkLC5MG3Ch03.Checked, chkLC5MG4Ch03.Checked };
            lc5Group04 = new bool[] { chkLC5MG1Ch04.Checked, chkLC5MG2Ch04.Checked, chkLC5MG3Ch04.Checked, chkLC5MG4Ch04.Checked };
            lc5Group05 = new bool[] { chkLC5MG1Ch05.Checked, chkLC5MG2Ch05.Checked, chkLC5MG3Ch05.Checked, chkLC5MG4Ch05.Checked };
            lc5Group06 = new bool[] { chkLC5MG1Ch06.Checked, chkLC5MG2Ch06.Checked, chkLC5MG3Ch06.Checked, chkLC5MG4Ch06.Checked };
            lc5Group07 = new bool[] { chkLC5MG1Ch07.Checked, chkLC5MG2Ch07.Checked, chkLC5MG3Ch07.Checked, chkLC5MG4Ch07.Checked };
            lc5Group08 = new bool[] { chkLC5MG1Ch08.Checked, chkLC5MG2Ch08.Checked, chkLC5MG3Ch08.Checked, chkLC5MG4Ch08.Checked };
            lc5Group09 = new bool[] { chkLC5MG1Ch09.Checked, chkLC5MG2Ch09.Checked, chkLC5MG3Ch09.Checked, chkLC5MG4Ch09.Checked };
            lc5Group10 = new bool[] { chkLC5MG1Ch10.Checked, chkLC5MG2Ch10.Checked, chkLC5MG3Ch10.Checked, chkLC5MG4Ch10.Checked };
            lc5Group11 = new bool[] { chkLC5MG1Ch11.Checked, chkLC5MG2Ch11.Checked, chkLC5MG3Ch11.Checked, chkLC5MG4Ch11.Checked };
            lc5Group12 = new bool[] { chkLC5MG1Ch12.Checked, chkLC5MG2Ch12.Checked, chkLC5MG3Ch12.Checked, chkLC5MG4Ch12.Checked };
            lc5Group13 = new bool[] { chkLC5MG1Ch13.Checked, chkLC5MG2Ch13.Checked, chkLC5MG3Ch13.Checked, chkLC5MG4Ch13.Checked };
            lc5Group14 = new bool[] { chkLC5MG1Ch14.Checked, chkLC5MG2Ch14.Checked, chkLC5MG3Ch14.Checked, chkLC5MG4Ch14.Checked };
            lc5Group15 = new bool[] { chkLC5MG1Ch15.Checked, chkLC5MG2Ch15.Checked, chkLC5MG3Ch15.Checked, chkLC5MG4Ch15.Checked };
            lc5Groups = new bool[][] { lc5Group00, lc5Group01, lc5Group02, lc5Group03, lc5Group04, lc5Group05, lc5Group06, lc5Group07, lc5Group08, lc5Group09, lc5Group10, lc5Group11, lc5Group12, lc5Group13, lc5Group14, lc5Group15 };

            lc6Group00 = new bool[] { chkLC6MG1Ch00.Checked, chkLC6MG2Ch00.Checked, chkLC6MG3Ch00.Checked, chkLC6MG4Ch00.Checked };
            lc6Group01 = new bool[] { chkLC6MG1Ch01.Checked, chkLC6MG2Ch01.Checked, chkLC6MG3Ch01.Checked, chkLC6MG4Ch01.Checked };
            lc6Group02 = new bool[] { chkLC6MG1Ch02.Checked, chkLC6MG2Ch02.Checked, chkLC6MG3Ch02.Checked, chkLC6MG4Ch02.Checked };
            lc6Group03 = new bool[] { chkLC6MG1Ch03.Checked, chkLC6MG2Ch03.Checked, chkLC6MG3Ch03.Checked, chkLC6MG4Ch03.Checked };
            lc6Group04 = new bool[] { chkLC6MG1Ch04.Checked, chkLC6MG2Ch04.Checked, chkLC6MG3Ch04.Checked, chkLC6MG4Ch04.Checked };
            lc6Group05 = new bool[] { chkLC6MG1Ch05.Checked, chkLC6MG2Ch05.Checked, chkLC6MG3Ch05.Checked, chkLC6MG4Ch05.Checked };
            lc6Group06 = new bool[] { chkLC6MG1Ch06.Checked, chkLC6MG2Ch06.Checked, chkLC6MG3Ch06.Checked, chkLC6MG4Ch06.Checked };
            lc6Group07 = new bool[] { chkLC6MG1Ch07.Checked, chkLC6MG2Ch07.Checked, chkLC6MG3Ch07.Checked, chkLC6MG4Ch07.Checked };
            lc6Group08 = new bool[] { chkLC6MG1Ch08.Checked, chkLC6MG2Ch08.Checked, chkLC6MG3Ch08.Checked, chkLC6MG4Ch08.Checked };
            lc6Group09 = new bool[] { chkLC6MG1Ch09.Checked, chkLC6MG2Ch09.Checked, chkLC6MG3Ch09.Checked, chkLC6MG4Ch09.Checked };
            lc6Group10 = new bool[] { chkLC6MG1Ch10.Checked, chkLC6MG2Ch10.Checked, chkLC6MG3Ch10.Checked, chkLC6MG4Ch10.Checked };
            lc6Group11 = new bool[] { chkLC6MG1Ch11.Checked, chkLC6MG2Ch11.Checked, chkLC6MG3Ch11.Checked, chkLC6MG4Ch11.Checked };
            lc6Group12 = new bool[] { chkLC6MG1Ch12.Checked, chkLC6MG2Ch12.Checked, chkLC6MG3Ch12.Checked, chkLC6MG4Ch12.Checked };
            lc6Group13 = new bool[] { chkLC6MG1Ch13.Checked, chkLC6MG2Ch13.Checked, chkLC6MG3Ch13.Checked, chkLC6MG4Ch13.Checked };
            lc6Group14 = new bool[] { chkLC6MG1Ch14.Checked, chkLC6MG2Ch14.Checked, chkLC6MG3Ch14.Checked, chkLC6MG4Ch14.Checked };
            lc6Group15 = new bool[] { chkLC6MG1Ch15.Checked, chkLC6MG2Ch15.Checked, chkLC6MG3Ch15.Checked, chkLC6MG4Ch15.Checked };
            lc6Groups = new bool[][] { lc6Group00, lc6Group01, lc6Group02, lc6Group03, lc6Group04, lc6Group05, lc6Group06, lc6Group07, lc6Group08, lc6Group09, lc6Group10, lc6Group11, lc6Group12, lc6Group13, lc6Group14, lc6Group15 };

            List<bool[][]> lcGroups = new List<bool[][]>();
            lcGroups.Add(lc1Groups);
            lcGroups.Add(lc2Groups);
            lcGroups.Add(lc3Groups);
            lcGroups.Add(lc4Groups);
            lcGroups.Add(lc5Groups);
            lcGroups.Add(lc6Groups);

            // LC cards
            for (int card = 0; card < Convert.ToInt16(cmbStartLC.Text); card++)
            {
                lcObjects[card].SetDevAddr(lcCardNum[card].SelectedIndex, lcPanelNum[card].SelectedIndex);
                lcObjects[card].SetCfgRev(lcConfigRev[card].Text);
                lcObjects[card].SetCfgType(lcConfigType[card].Text);
                lcObjects[card].SetDCDimmer(lcDCDimmer[card].Checked);
                lcObjects[card].SetDCMotor(lcDCMotor[card].Checked);
                lcObjects[card].SetShade(lcShade[card].Checked);
                lcObjects[card].SetForce(lcForce[card].Checked);
                lcObjects[card].SetBaseIndex(lcBaseInstance[card].Text);
                for (int channel = 0; channel < 16; channel++)
                {
                    if (lcStandalone[card].Checked == false) // only set overcurrent parameters if it's not a standalone card
                    {
                        lcObjects[card].SetOCAmps(channel, lcOCAmps[card][channel].Text);
                        lcObjects[card].SetOCTime(channel, lcOCTime[card][channel].Text);
                    }
                    lcObjects[card].SetGroup0(lcGroups[card][channel], channel); // takes care of all 4 groups
                    lcObjects[card].SetModeAndPairingLC(channel, lcModes[card][channel].Text, false);
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

            bool[] checkLC = new bool[] { CheckLC1(), CheckLC2(), CheckLC3(), CheckLC4(), CheckLC5(), CheckLC6() };

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

        private bool CheckLC2()
        {
            return ((cmbLC2CardNum.Text != "") && (cmbLC2PanelNum.Text != "") && (tbxLC2BaseIndex.Text != ""));
        }

        private bool CheckLC3()
        {
            return ((cmbLC3CardNum.Text != "") && (cmbLC3PanelNum.Text != "") && (tbxLC3BaseIndex.Text != ""));
        }

        private bool CheckLC4()
        {
            return ((cmbLC4CardNum.Text != "") && (cmbLC4PanelNum.Text != "") && (tbxLC4BaseIndex.Text != ""));
        }

        private bool CheckLC5()
        {
            return ((cmbLC5CardNum.Text != "") && (cmbLC5PanelNum.Text != "") && (tbxLC5BaseIndex.Text != ""));
        }

        private bool CheckLC6()
        {
            return ((cmbLC6CardNum.Text != "") && (cmbLC6PanelNum.Text != "") && (tbxLC6BaseIndex.Text != ""));
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
            tabControlLC2QF.SelectedIndex = 0;
        }

        private void btnLCCard3_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard3);
            tabControlLC.SelectedIndex = 3;
            tabControlLC3QF.SelectedIndex = 0;
        }

        private void btnLCCard4_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard4);
            tabControlLC.SelectedIndex = 4;
            tabControlLC4QF.SelectedIndex = 0;
        }

        private void btnLCCard5_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard5);
            tabControlLC.SelectedIndex = 5;
            tabControlLC5QF.SelectedIndex = 0;
        }

        private void btnLCCard6_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard6);
            tabControlLC.SelectedIndex = 6;
            tabControlLC6QF.SelectedIndex = 0;
        }

        private void ShowLCNav(int argInt)
        {
            Button[] btnArray = { btnLCCard1, btnLCCard2, btnLCCard3, btnLCCard4, btnLCCard5, btnLCCard6 };

            for (int i = 0; i < argInt; i++)
            {
                btnArray[i].Visible = true;
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

        private void tbxLC2BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblLC2Ch00.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 0);
            lblLC2Ch01.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 1);
            lblLC2Ch02.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 2);
            lblLC2Ch03.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 3);
            lblLC2Ch04.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 4);
            lblLC2Ch05.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 5);
            lblLC2Ch06.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 6);
            lblLC2Ch07.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 7);
            lblLC2Ch08.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 8);
            lblLC2Ch09.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 9);
            lblLC2Ch10.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 10);
            lblLC2Ch11.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 11);
            lblLC2Ch12.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 12);
            lblLC2Ch13.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 13);
            lblLC2Ch14.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 14);
            lblLC2Ch15.Text = ChangeChannelLabel(tbxLC2BaseIndex.Text, 15);
            CheckLCGenerate();
        }

        private void tbxLC3BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblLC3Ch00.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 0);
            lblLC3Ch01.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 1);
            lblLC3Ch02.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 2);
            lblLC3Ch03.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 3);
            lblLC3Ch04.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 4);
            lblLC3Ch05.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 5);
            lblLC3Ch06.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 6);
            lblLC3Ch07.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 7);
            lblLC3Ch08.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 8);
            lblLC3Ch09.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 9);
            lblLC3Ch10.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 10);
            lblLC3Ch11.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 11);
            lblLC3Ch12.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 12);
            lblLC3Ch13.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 13);
            lblLC3Ch14.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 14);
            lblLC3Ch15.Text = ChangeChannelLabel(tbxLC3BaseIndex.Text, 15);
            CheckLCGenerate();
        }

        private void tbxLC4BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblLC4Ch00.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 0);
            lblLC4Ch01.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 1);
            lblLC4Ch02.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 2);
            lblLC4Ch03.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 3);
            lblLC4Ch04.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 4);
            lblLC4Ch05.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 5);
            lblLC4Ch06.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 6);
            lblLC4Ch07.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 7);
            lblLC4Ch08.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 8);
            lblLC4Ch09.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 9);
            lblLC4Ch10.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 10);
            lblLC4Ch11.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 11);
            lblLC4Ch12.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 12);
            lblLC4Ch13.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 13);
            lblLC4Ch14.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 14);
            lblLC4Ch15.Text = ChangeChannelLabel(tbxLC4BaseIndex.Text, 15);
            CheckLCGenerate();
        }

        private void tbxLC5BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblLC5Ch00.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 0);
            lblLC5Ch01.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 1);
            lblLC5Ch02.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 2);
            lblLC5Ch03.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 3);
            lblLC5Ch04.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 4);
            lblLC5Ch05.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 5);
            lblLC5Ch06.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 6);
            lblLC5Ch07.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 7);
            lblLC5Ch08.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 8);
            lblLC5Ch09.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 9);
            lblLC5Ch10.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 10);
            lblLC5Ch11.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 11);
            lblLC5Ch12.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 12);
            lblLC5Ch13.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 13);
            lblLC5Ch14.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 14);
            lblLC5Ch15.Text = ChangeChannelLabel(tbxLC5BaseIndex.Text, 15);
            CheckLCGenerate();
        }

        private void tbxLC6BaseIndex_TextChanged(object sender, EventArgs e)
        {
            lblLC6Ch00.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 0);
            lblLC6Ch01.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 1);
            lblLC6Ch02.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 2);
            lblLC6Ch03.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 3);
            lblLC6Ch04.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 4);
            lblLC6Ch05.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 5);
            lblLC6Ch06.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 6);
            lblLC6Ch07.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 7);
            lblLC6Ch08.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 8);
            lblLC6Ch09.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 9);
            lblLC6Ch10.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 10);
            lblLC6Ch11.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 11);
            lblLC6Ch12.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 12);
            lblLC6Ch13.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 13);
            lblLC6Ch14.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 14);
            lblLC6Ch15.Text = ChangeChannelLabel(tbxLC6BaseIndex.Text, 15);
            CheckLCGenerate();
        }

        private void chkLC1Standalone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLC1Standalone.Checked)
            {
                HideComboBox(lc1OCAmps);
                HideComboBox(lc1OCTime);
            }
            else
            {
                ShowComboBox(lc1OCAmps);
                ShowComboBox(lc1OCTime);
            }
        }

        private void chkLC2Standalone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLC2Standalone.Checked)
            {
                HideComboBox(lc2OCAmps);
                HideComboBox(lc2OCTime);
            }
            else
            {
                ShowComboBox(lc2OCAmps);
                ShowComboBox(lc2OCTime);
            }
        }

        private void chkLC3Standalone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLC3Standalone.Checked)
            {
                HideComboBox(lc3OCAmps);
                HideComboBox(lc3OCTime);
            }
            else
            {
                ShowComboBox(lc3OCAmps);
                ShowComboBox(lc3OCTime);
            }
        }

        private void chkLC4Standalone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLC4Standalone.Checked)
            {
                HideComboBox(lc4OCAmps);
                HideComboBox(lc4OCTime);
            }
            else
            {
                ShowComboBox(lc4OCAmps);
                ShowComboBox(lc4OCTime);
            }
        }

        private void chkLC5Standalone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLC5Standalone.Checked)
            {
                HideComboBox(lc5OCAmps);
                HideComboBox(lc5OCTime);
            }
            else
            {
                ShowComboBox(lc5OCAmps);
                ShowComboBox(lc5OCTime);
            }
        }

        private void chkLC6Standalone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLC6Standalone.Checked)
            {
                HideComboBox(lc6OCAmps);
                HideComboBox(lc6OCTime);
            }
            else
            {
                ShowComboBox(lc6OCAmps);
                ShowComboBox(lc6OCTime);
            }
        }




        // ######  ##       #### ########  ######## 
        //##    ## ##        ##  ##     ## ##       
        //##       ##        ##  ##     ## ##       
        // ######  ##        ##  ##     ## ######   
        //      ## ##        ##  ##     ## ##       
        //##    ## ##        ##  ##     ## ##       
        // ######  ######## #### ########  ######## 
        //@Slide

        private void btnSlideGenerate_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideGenerate);
            tabControlSlide.SelectedIndex = 3;
            string[] slideFiles = Directory.GetFiles(@"M1_DcDriver_Config\Src\M1_SlideCard\DeviceConfigs\", "*.*", SearchOption.TopDirectoryOnly);
            tbxSlideGenerated.Lines = slideFiles;
        }

        private void btnSlideCard1_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard1);
            tabControlSlide.SelectedIndex = 1;
        }

        private void btnSlideCard2_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard2);
            tabControlSlide.SelectedIndex = 2;
        }

        private void btnSlideCard3_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard3);
        }

        private void btnSlideCard4_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard4);
        }

        private void btnSlideCard5_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard5);
        }

        private void btnSlideCard6_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard6);
        }

        private void ShowSlideNav(int argInt)
        {
            Button[] btnArray = { btnSlideCard1, btnSlideCard2, btnSlideCard3, btnSlideCard4, btnSlideCard5, btnSlideCard6 };

            for (int i = 0; i < argInt; i++)
            {
                btnArray[i].Visible = true;
            }
        }

        private void SlideCardNavColor(Button argButton)
        {
            btnSlideCard1.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnSlideCard1.ForeColor = SystemColors.Control;
            btnSlideCard2.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnSlideCard2.ForeColor = SystemColors.Control;
            btnSlideCard3.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnSlideCard3.ForeColor = SystemColors.Control;
            btnSlideCard4.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnSlideCard4.ForeColor = SystemColors.Control;
            btnSlideCard5.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnSlideCard5.ForeColor = SystemColors.Control;
            btnSlideCard6.BackColor = Color.FromArgb(255, 20, 20, 20);
            btnSlideCard6.ForeColor = SystemColors.Control;
            argButton.BackColor = Color.FromArgb(255, 178, 214, 241);
            argButton.ForeColor = Color.FromArgb(255, 20, 20, 20);
        }

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
            // set dropdown boxes to defaults because they are DropDownList
            cmbBreaker1OCAmpsVIN.SelectedIndex = 0; cmbBreaker1OCTimeVIN.SelectedIndex = 3; cmbBreaker1InterruptVIN.SelectedIndex = 1;
            cmbBreaker2OCAmpsVIN.SelectedIndex = 0; cmbBreaker2OCTimeVIN.SelectedIndex = 3; cmbBreaker2InterruptVIN.SelectedIndex = 2;
            cmbBreaker3OCAmpsVIN.SelectedIndex = 0; cmbBreaker3OCTimeVIN.SelectedIndex = 3; cmbBreaker3InterruptVIN.SelectedIndex = 3;
            cmbBreaker4OCAmpsVIN.SelectedIndex = 0; cmbBreaker4OCTimeVIN.SelectedIndex = 3; cmbBreaker4InterruptVIN.SelectedIndex = 4;
            SetSelectedIndex(breaker1OCAmps, 5); SetSelectedIndex(breaker2OCAmps, 5); SetSelectedIndex(breaker3OCAmps, 5); SetSelectedIndex(breaker4OCAmps, 5);
            SetSelectedIndex(breaker1OCTime, 3); SetSelectedIndex(breaker2OCTime, 3); SetSelectedIndex(breaker3OCTime, 3); SetSelectedIndex(breaker4OCTime, 3);
            SetSelectedIndex(breaker1Interrupt, 1); SetSelectedIndex(breaker2Interrupt, 2); SetSelectedIndex(breaker3Interrupt, 3); SetSelectedIndex(breaker4Interrupt, 4);
            SetSelectedIndex(dim1OCAmps, 3); SetSelectedIndex(dim2OCAmps, 3); SetSelectedIndex(dim3OCAmps, 3); SetSelectedIndex(dim4OCAmps, 3); SetSelectedIndex(dim5OCAmps, 3); SetSelectedIndex(dim6OCAmps, 3);
            SetSelectedIndex(dim1OCTime, 1); SetSelectedIndex(dim2OCTime, 1); SetSelectedIndex(dim3OCTime, 1); SetSelectedIndex(dim4OCTime, 1); SetSelectedIndex(dim5OCTime, 1); SetSelectedIndex(dim6OCTime, 1); 
            SetSelectedIndex(hc1OCAmps, 5); SetSelectedIndex(hc2OCAmps, 5); SetSelectedIndex(hc3OCAmps, 5); SetSelectedIndex(hc4OCAmps, 5); SetSelectedIndex(hc5OCAmps, 5); SetSelectedIndex(hc6OCAmps, 5);
            SetSelectedIndex(hc1OCTime, 1); SetSelectedIndex(hc2OCTime, 1); SetSelectedIndex(hc3OCTime, 1); SetSelectedIndex(hc4OCTime, 1); SetSelectedIndex(hc5OCTime, 1); SetSelectedIndex(hc6OCTime, 1);
            SetSelectedIndex(hc1Mode, 0); SetSelectedIndex(hc2Mode, 0); SetSelectedIndex(hc3Mode, 0); SetSelectedIndex(hc4Mode, 0); SetSelectedIndex(hc5Mode, 0); SetSelectedIndex(hc6Mode, 0);
            SetSelectedIndex(lc1OCAmps, 1); SetSelectedIndex(lc2OCAmps, 1); SetSelectedIndex(lc3OCAmps, 1); SetSelectedIndex(lc4OCAmps, 1); SetSelectedIndex(lc5OCAmps, 1); SetSelectedIndex(lc6OCAmps, 1); 
            SetSelectedIndex(lc1OCTime, 1); SetSelectedIndex(lc2OCTime, 1); SetSelectedIndex(lc3OCTime, 1); SetSelectedIndex(lc4OCTime, 1); SetSelectedIndex(lc5OCTime, 1); SetSelectedIndex(lc6OCTime, 1);
            SetSelectedIndex(lc1Mode, 0); SetSelectedIndex(lc2Mode, 0); SetSelectedIndex(lc3Mode, 0); SetSelectedIndex(lc4Mode, 0); SetSelectedIndex(lc5Mode, 0); SetSelectedIndex(lc6Mode, 0);
        }

        private void PopulateArrays()
        {
            auxCardNum = new ComboBox[] { cmbAux1CardNum, cmbAux2CardNum };
            auxPanelNum = new ComboBox[] { cmbAux1PanelNum, cmbAux2PanelNum };
            auxConfigRev = new TextBox[] { tbxAux1CfgRev, tbxAux2CfgRev };
            auxConfigType = new TextBox[] { tbxAux1CfgType, tbxAux2CfgType };
            auxDCDimmer = new CheckBox[] { chkAux1DCDimmer, chkAux2DCDimmer };
            auxDCMotor = new CheckBox[] { chkAux1DCMotor, chkAux2DCMotor };
            auxShade = new CheckBox[] { chkAux1Shade, chkAux2Shade };
            auxForce = new CheckBox[] { chkAux1Force, chkAux2Force };
            auxBaseInstance = new TextBox[] { tbxAux1BaseIndex, tbxAux2BaseIndex };

            breakerCardNum = new ComboBox[] { cmbBreaker1CardNum, cmbBreaker2CardNum, cmbBreaker3CardNum, cmbBreaker4CardNum };
            breakerPanelNum = new ComboBox[] { cmbBreaker1PanelNum, cmbBreaker2PanelNum, cmbBreaker3PanelNum, cmbBreaker4PanelNum };
            breakerConfigRev = new TextBox[] { tbxBreaker1CfgRev, tbxBreaker2CfgRev, tbxBreaker3CfgRev, tbxBreaker4CfgRev };
            breakerConfigType = new TextBox[] { tbxBreaker1CfgType, tbxBreaker2CfgType, tbxBreaker3CfgType, tbxBreaker4CfgType };
            breakerBaseInstance = new TextBox[] { tbxBreaker1BaseIndex, tbxBreaker2BaseIndex, tbxBreaker3BaseIndex, tbxBreaker4BaseIndex };
            breakerVINOCAmps = new ComboBox[] { cmbBreaker1OCAmpsVIN, cmbBreaker2OCAmpsVIN, cmbBreaker3OCAmpsVIN, cmbBreaker4OCAmpsVIN };
            breakerVINOCTime = new ComboBox[] { cmbBreaker1OCTimeVIN, cmbBreaker2OCTimeVIN, cmbBreaker3OCTimeVIN, cmbBreaker4OCTimeVIN };
            breakerVINInterrupt = new ComboBox[] { cmbBreaker1InterruptVIN, cmbBreaker2InterruptVIN, cmbBreaker3InterruptVIN, cmbBreaker4InterruptVIN };
            breaker1OCAmps = new ComboBox[] { cmbBreaker1OCAmps00, cmbBreaker1OCAmps01, cmbBreaker1OCAmps02, cmbBreaker1OCAmps03, cmbBreaker1OCAmps04, cmbBreaker1OCAmps05, cmbBreaker1OCAmps06, cmbBreaker1OCAmps07, cmbBreaker1OCAmps08, cmbBreaker1OCAmps09, cmbBreaker1OCAmps10, cmbBreaker1OCAmps11 };
            breaker2OCAmps = new ComboBox[] { cmbBreaker2OCAmps00, cmbBreaker2OCAmps01, cmbBreaker2OCAmps02, cmbBreaker2OCAmps03, cmbBreaker2OCAmps04, cmbBreaker2OCAmps05, cmbBreaker2OCAmps06, cmbBreaker2OCAmps07, cmbBreaker2OCAmps08, cmbBreaker2OCAmps09, cmbBreaker2OCAmps10, cmbBreaker2OCAmps11 };
            breaker3OCAmps = new ComboBox[] { cmbBreaker3OCAmps00, cmbBreaker3OCAmps01, cmbBreaker3OCAmps02, cmbBreaker3OCAmps03, cmbBreaker3OCAmps04, cmbBreaker3OCAmps05, cmbBreaker3OCAmps06, cmbBreaker3OCAmps07, cmbBreaker3OCAmps08, cmbBreaker3OCAmps09, cmbBreaker3OCAmps10, cmbBreaker3OCAmps11 };
            breaker4OCAmps = new ComboBox[] { cmbBreaker4OCAmps00, cmbBreaker4OCAmps01, cmbBreaker4OCAmps02, cmbBreaker4OCAmps03, cmbBreaker4OCAmps04, cmbBreaker4OCAmps05, cmbBreaker4OCAmps06, cmbBreaker4OCAmps07, cmbBreaker4OCAmps08, cmbBreaker4OCAmps09, cmbBreaker4OCAmps10, cmbBreaker4OCAmps11 };
            breakerOCAmps = new ComboBox[][] { breaker1OCAmps, breaker2OCAmps, breaker3OCAmps, breaker4OCAmps };
            breaker1OCTime = new ComboBox[] { cmbBreaker1OCTime00, cmbBreaker1OCTime01, cmbBreaker1OCTime02, cmbBreaker1OCTime03, cmbBreaker1OCTime04, cmbBreaker1OCTime05, cmbBreaker1OCTime06, cmbBreaker1OCTime07, cmbBreaker1OCTime08, cmbBreaker1OCTime09, cmbBreaker1OCTime10, cmbBreaker1OCTime11 };
            breaker2OCTime = new ComboBox[] { cmbBreaker2OCTime00, cmbBreaker2OCTime01, cmbBreaker2OCTime02, cmbBreaker2OCTime03, cmbBreaker2OCTime04, cmbBreaker2OCTime05, cmbBreaker2OCTime06, cmbBreaker2OCTime07, cmbBreaker2OCTime08, cmbBreaker2OCTime09, cmbBreaker2OCTime10, cmbBreaker2OCTime11 };
            breaker3OCTime = new ComboBox[] { cmbBreaker3OCTime00, cmbBreaker3OCTime01, cmbBreaker3OCTime02, cmbBreaker3OCTime03, cmbBreaker3OCTime04, cmbBreaker3OCTime05, cmbBreaker3OCTime06, cmbBreaker3OCTime07, cmbBreaker3OCTime08, cmbBreaker3OCTime09, cmbBreaker3OCTime10, cmbBreaker3OCTime11 };
            breaker4OCTime = new ComboBox[] { cmbBreaker4OCTime00, cmbBreaker4OCTime01, cmbBreaker4OCTime02, cmbBreaker4OCTime03, cmbBreaker4OCTime04, cmbBreaker4OCTime05, cmbBreaker4OCTime06, cmbBreaker4OCTime07, cmbBreaker4OCTime08, cmbBreaker4OCTime09, cmbBreaker4OCTime10, cmbBreaker4OCTime11 };
            breakerOCTime = new ComboBox[][] { breaker1OCTime, breaker2OCTime, breaker3OCTime, breaker4OCTime };
            breaker1Interrupt = new ComboBox[] { cmbBreaker1Interrupt00, cmbBreaker1Interrupt01, cmbBreaker1Interrupt02, cmbBreaker1Interrupt03, cmbBreaker1Interrupt04, cmbBreaker1Interrupt05, cmbBreaker1Interrupt06, cmbBreaker1Interrupt07, cmbBreaker1Interrupt08, cmbBreaker1Interrupt09, cmbBreaker1Interrupt10, cmbBreaker1Interrupt11 };
            breaker2Interrupt = new ComboBox[] { cmbBreaker2Interrupt00, cmbBreaker2Interrupt01, cmbBreaker2Interrupt02, cmbBreaker2Interrupt03, cmbBreaker2Interrupt04, cmbBreaker2Interrupt05, cmbBreaker2Interrupt06, cmbBreaker2Interrupt07, cmbBreaker2Interrupt08, cmbBreaker2Interrupt09, cmbBreaker2Interrupt10, cmbBreaker2Interrupt11 };
            breaker3Interrupt = new ComboBox[] { cmbBreaker3Interrupt00, cmbBreaker3Interrupt01, cmbBreaker3Interrupt02, cmbBreaker3Interrupt03, cmbBreaker3Interrupt04, cmbBreaker3Interrupt05, cmbBreaker3Interrupt06, cmbBreaker3Interrupt07, cmbBreaker3Interrupt08, cmbBreaker3Interrupt09, cmbBreaker3Interrupt10, cmbBreaker3Interrupt11 };
            breaker4Interrupt = new ComboBox[] { cmbBreaker4Interrupt00, cmbBreaker4Interrupt01, cmbBreaker4Interrupt02, cmbBreaker4Interrupt03, cmbBreaker4Interrupt04, cmbBreaker4Interrupt05, cmbBreaker4Interrupt06, cmbBreaker4Interrupt07, cmbBreaker4Interrupt08, cmbBreaker4Interrupt09, cmbBreaker4Interrupt10, cmbBreaker4Interrupt11 };
            breakerInterrupts = new ComboBox[][] { breaker1Interrupt, breaker2Interrupt, breaker3Interrupt, breaker4Interrupt };
            dimCardNum = new ComboBox[] { cmbDimmer1CardNum, cmbDimmer2CardNum, cmbDimmer3CardNum, cmbDimmer4CardNum, cmbDimmer5CardNum, cmbDimmer6CardNum };
            dimPanelNum = new ComboBox[] { cmbDimmer1PanelNum, cmbDimmer2PanelNum, cmbDimmer3PanelNum, cmbDimmer4PanelNum, cmbDimmer5PanelNum, cmbDimmer6PanelNum };
            dimConfigRev = new TextBox[] { tbxDimmer1CfgRev, tbxDimmer2CfgRev, tbxDimmer3CfgRev, tbxDimmer4CfgRev, tbxDimmer5CfgRev, tbxDimmer6CfgRev };
            dimConfigType = new TextBox[] { tbxDimmer1CfgType, tbxDimmer2CfgType, tbxDimmer3CfgType, tbxDimmer4CfgType, tbxDimmer5CfgType, tbxDimmer6CfgType };
            dimDCMotor = new CheckBox[] { chkDimmer1DCMotor, chkDimmer2DCMotor, chkDimmer3DCMotor, chkDimmer4DCMotor, chkDimmer5DCMotor, chkDimmer6DCMotor };
            dimShade = new CheckBox[] { chkDimmer1Shade, chkDimmer2Shade, chkDimmer3Shade, chkDimmer4Shade, chkDimmer5Shade, chkDimmer6Shade };
            dimForce = new CheckBox[] { chkDimmer1Force, chkDimmer2Force, chkDimmer3Force, chkDimmer4Force, chkDimmer5Force, chkDimmer6Force };
            dimBaseInstance = new TextBox[] { tbxDimmer1BaseIndex, tbxDimmer2BaseIndex, tbxDimmer3BaseIndex, tbxDimmer4BaseIndex, tbxDimmer5BaseIndex, tbxDimmer6BaseIndex };
            dim1OCAmps = new ComboBox[] { cmbDimmer1OCAmps00, cmbDimmer1OCAmps01, cmbDimmer1OCAmps02, cmbDimmer1OCAmps03, cmbDimmer1OCAmps04, cmbDimmer1OCAmps05, cmbDimmer1OCAmps06, cmbDimmer1OCAmps07, cmbDimmer1OCAmps08, cmbDimmer1OCAmps09, cmbDimmer1OCAmps10, cmbDimmer1OCAmps11 };
            dim2OCAmps = new ComboBox[] { cmbDimmer2OCAmps00, cmbDimmer2OCAmps01, cmbDimmer2OCAmps02, cmbDimmer2OCAmps03, cmbDimmer2OCAmps04, cmbDimmer2OCAmps05, cmbDimmer2OCAmps06, cmbDimmer2OCAmps07, cmbDimmer2OCAmps08, cmbDimmer2OCAmps09, cmbDimmer2OCAmps10, cmbDimmer2OCAmps11 };
            dim3OCAmps = new ComboBox[] { cmbDimmer3OCAmps00, cmbDimmer3OCAmps01, cmbDimmer3OCAmps02, cmbDimmer3OCAmps03, cmbDimmer3OCAmps04, cmbDimmer3OCAmps05, cmbDimmer3OCAmps06, cmbDimmer3OCAmps07, cmbDimmer3OCAmps08, cmbDimmer3OCAmps09, cmbDimmer3OCAmps10, cmbDimmer3OCAmps11 };
            dim4OCAmps = new ComboBox[] { cmbDimmer4OCAmps00, cmbDimmer4OCAmps01, cmbDimmer4OCAmps02, cmbDimmer4OCAmps03, cmbDimmer4OCAmps04, cmbDimmer4OCAmps05, cmbDimmer4OCAmps06, cmbDimmer4OCAmps07, cmbDimmer4OCAmps08, cmbDimmer4OCAmps09, cmbDimmer4OCAmps10, cmbDimmer4OCAmps11 };
            dim5OCAmps = new ComboBox[] { cmbDimmer5OCAmps00, cmbDimmer5OCAmps01, cmbDimmer5OCAmps02, cmbDimmer5OCAmps03, cmbDimmer5OCAmps04, cmbDimmer5OCAmps05, cmbDimmer5OCAmps06, cmbDimmer5OCAmps07, cmbDimmer5OCAmps08, cmbDimmer5OCAmps09, cmbDimmer5OCAmps10, cmbDimmer5OCAmps11 };
            dim6OCAmps = new ComboBox[] { cmbDimmer6OCAmps00, cmbDimmer6OCAmps01, cmbDimmer6OCAmps02, cmbDimmer6OCAmps03, cmbDimmer6OCAmps04, cmbDimmer6OCAmps05, cmbDimmer6OCAmps06, cmbDimmer6OCAmps07, cmbDimmer6OCAmps08, cmbDimmer6OCAmps09, cmbDimmer6OCAmps10, cmbDimmer6OCAmps11 };
            dimmerOCAmps = new ComboBox[][] { dim1OCAmps, dim2OCAmps, dim3OCAmps, dim4OCAmps, dim5OCAmps, dim6OCAmps };
            dim1OCTime = new ComboBox[] { cmbDimmer1OCTime00, cmbDimmer1OCTime01, cmbDimmer1OCTime02, cmbDimmer1OCTime03, cmbDimmer1OCTime04, cmbDimmer1OCTime05, cmbDimmer1OCTime06, cmbDimmer1OCTime07, cmbDimmer1OCTime08, cmbDimmer1OCTime09, cmbDimmer1OCTime10, cmbDimmer1OCTime11 };
            dim2OCTime = new ComboBox[] { cmbDimmer2OCTime00, cmbDimmer2OCTime01, cmbDimmer2OCTime02, cmbDimmer2OCTime03, cmbDimmer2OCTime04, cmbDimmer2OCTime05, cmbDimmer2OCTime06, cmbDimmer2OCTime07, cmbDimmer2OCTime08, cmbDimmer2OCTime09, cmbDimmer2OCTime10, cmbDimmer2OCTime11 };
            dim3OCTime = new ComboBox[] { cmbDimmer3OCTime00, cmbDimmer3OCTime01, cmbDimmer3OCTime02, cmbDimmer3OCTime03, cmbDimmer3OCTime04, cmbDimmer3OCTime05, cmbDimmer3OCTime06, cmbDimmer3OCTime07, cmbDimmer3OCTime08, cmbDimmer3OCTime09, cmbDimmer3OCTime10, cmbDimmer3OCTime11 };
            dim4OCTime = new ComboBox[] { cmbDimmer4OCTime00, cmbDimmer4OCTime01, cmbDimmer4OCTime02, cmbDimmer4OCTime03, cmbDimmer4OCTime04, cmbDimmer4OCTime05, cmbDimmer4OCTime06, cmbDimmer4OCTime07, cmbDimmer4OCTime08, cmbDimmer4OCTime09, cmbDimmer4OCTime10, cmbDimmer4OCTime11 };
            dim5OCTime = new ComboBox[] { cmbDimmer5OCTime00, cmbDimmer5OCTime01, cmbDimmer5OCTime02, cmbDimmer5OCTime03, cmbDimmer5OCTime04, cmbDimmer5OCTime05, cmbDimmer5OCTime06, cmbDimmer5OCTime07, cmbDimmer5OCTime08, cmbDimmer5OCTime09, cmbDimmer5OCTime10, cmbDimmer5OCTime11 };
            dim6OCTime = new ComboBox[] { cmbDimmer6OCTime00, cmbDimmer6OCTime01, cmbDimmer6OCTime02, cmbDimmer6OCTime03, cmbDimmer6OCTime04, cmbDimmer6OCTime05, cmbDimmer6OCTime06, cmbDimmer6OCTime07, cmbDimmer6OCTime08, cmbDimmer6OCTime09, cmbDimmer6OCTime10, cmbDimmer6OCTime11 };
            dimmerOCTime = new ComboBox[][] { dim1OCTime, dim2OCTime, dim3OCTime, dim4OCTime, dim5OCTime, dim6OCTime };

            hcCardNum = new ComboBox[] { cmbHC1CardNum, cmbHC2CardNum, cmbHC3CardNum, cmbHC4CardNum, cmbHC5CardNum, cmbHC6CardNum };
            hcPanelNum = new ComboBox[] { cmbHC1PanelNum, cmbHC2PanelNum, cmbHC3PanelNum, cmbHC4PanelNum, cmbHC5PanelNum, cmbHC6PanelNum };
            hcConfigRev = new TextBox[] { tbxHC1CfgRev, tbxHC2CfgRev, tbxHC3CfgRev, tbxHC4CfgRev, tbxHC5CfgRev, tbxHC6CfgRev };
            hcConfigType = new TextBox[] { tbxHC1CfgType, tbxHC2CfgType, tbxHC3CfgType, tbxHC4CfgType, tbxHC5CfgType, tbxHC6CfgType };
            hcDCDimmer = new CheckBox[] { chkHC1DCDimmer, chkHC2DCDimmer, chkHC3DCDimmer, chkHC4DCDimmer, chkHC5DCDimmer, chkHC6DCDimmer };
            hcRGB = new CheckBox[] { chkHC1RGB, chkHC2RGB, chkHC3RGB, chkHC4RGB, chkHC5RGB, chkHC6RGB };
            hcDCMotor = new CheckBox[] { chkHC1DCMotor, chkHC2DCMotor, chkHC3DCMotor, chkHC4DCMotor, chkHC5DCMotor, chkHC6DCMotor };
            hcShade = new CheckBox[] { chkHC1Shade, chkHC2Shade, chkHC3Shade, chkHC4Shade, chkHC5Shade, chkHC6Shade };
            hcForce = new CheckBox[] { chkHC1Force, chkHC2Force, chkHC3Force, chkHC4Force, chkHC5Force, chkHC6Force };
            hcBaseInstance = new TextBox[] { tbxHC1BaseIndex, tbxHC2BaseIndex, tbxHC3BaseIndex, tbxHC4BaseIndex, tbxHC5BaseIndex, tbxHC6BaseIndex };
            hc1OCAmps = new ComboBox[] { cmbHC1OCAmps00, cmbHC1OCAmps01, cmbHC1OCAmps02, cmbHC1OCAmps03, cmbHC1OCAmps04, cmbHC1OCAmps05, cmbHC1OCAmps06, cmbHC1OCAmps07, cmbHC1OCAmps08, cmbHC1OCAmps09, cmbHC1OCAmps10, cmbHC1OCAmps11 };
            hc2OCAmps = new ComboBox[] { cmbHC2OCAmps00, cmbHC2OCAmps01, cmbHC2OCAmps02, cmbHC2OCAmps03, cmbHC2OCAmps04, cmbHC2OCAmps05, cmbHC2OCAmps06, cmbHC2OCAmps07, cmbHC2OCAmps08, cmbHC2OCAmps09, cmbHC2OCAmps10, cmbHC2OCAmps11 };
            hc3OCAmps = new ComboBox[] { cmbHC3OCAmps00, cmbHC3OCAmps01, cmbHC3OCAmps02, cmbHC3OCAmps03, cmbHC3OCAmps04, cmbHC3OCAmps05, cmbHC3OCAmps06, cmbHC3OCAmps07, cmbHC3OCAmps08, cmbHC3OCAmps09, cmbHC3OCAmps10, cmbHC3OCAmps11 };
            hc4OCAmps = new ComboBox[] { cmbHC4OCAmps00, cmbHC4OCAmps01, cmbHC4OCAmps02, cmbHC4OCAmps03, cmbHC4OCAmps04, cmbHC4OCAmps05, cmbHC4OCAmps06, cmbHC4OCAmps07, cmbHC4OCAmps08, cmbHC4OCAmps09, cmbHC4OCAmps10, cmbHC4OCAmps11 };
            hc5OCAmps = new ComboBox[] { cmbHC5OCAmps00, cmbHC5OCAmps01, cmbHC5OCAmps02, cmbHC5OCAmps03, cmbHC5OCAmps04, cmbHC5OCAmps05, cmbHC5OCAmps06, cmbHC5OCAmps07, cmbHC5OCAmps08, cmbHC5OCAmps09, cmbHC5OCAmps10, cmbHC5OCAmps11 };
            hc6OCAmps = new ComboBox[] { cmbHC6OCAmps00, cmbHC6OCAmps01, cmbHC6OCAmps02, cmbHC6OCAmps03, cmbHC6OCAmps04, cmbHC6OCAmps05, cmbHC6OCAmps06, cmbHC6OCAmps07, cmbHC6OCAmps08, cmbHC6OCAmps09, cmbHC6OCAmps10, cmbHC6OCAmps11 };
            hcOCAmps = new ComboBox[][] { hc1OCAmps, hc2OCAmps, hc3OCAmps, hc4OCAmps, hc5OCAmps, hc6OCAmps };
            hc1OCTime = new ComboBox[] { cmbHC1OCTime00, cmbHC1OCTime01, cmbHC1OCTime02, cmbHC1OCTime03, cmbHC1OCTime04, cmbHC1OCTime05, cmbHC1OCTime06, cmbHC1OCTime07, cmbHC1OCTime08, cmbHC1OCTime09, cmbHC1OCTime10, cmbHC1OCTime11 };
            hc2OCTime = new ComboBox[] { cmbHC2OCTime00, cmbHC2OCTime01, cmbHC2OCTime02, cmbHC2OCTime03, cmbHC2OCTime04, cmbHC2OCTime05, cmbHC2OCTime06, cmbHC2OCTime07, cmbHC2OCTime08, cmbHC2OCTime09, cmbHC2OCTime10, cmbHC2OCTime11 };
            hc3OCTime = new ComboBox[] { cmbHC3OCTime00, cmbHC3OCTime01, cmbHC3OCTime02, cmbHC3OCTime03, cmbHC3OCTime04, cmbHC3OCTime05, cmbHC3OCTime06, cmbHC3OCTime07, cmbHC3OCTime08, cmbHC3OCTime09, cmbHC3OCTime10, cmbHC3OCTime11 };
            hc4OCTime = new ComboBox[] { cmbHC4OCTime00, cmbHC4OCTime01, cmbHC4OCTime02, cmbHC4OCTime03, cmbHC4OCTime04, cmbHC4OCTime05, cmbHC4OCTime06, cmbHC4OCTime07, cmbHC4OCTime08, cmbHC4OCTime09, cmbHC4OCTime10, cmbHC4OCTime11 };
            hc5OCTime = new ComboBox[] { cmbHC5OCTime00, cmbHC5OCTime01, cmbHC5OCTime02, cmbHC5OCTime03, cmbHC5OCTime04, cmbHC5OCTime05, cmbHC5OCTime06, cmbHC5OCTime07, cmbHC5OCTime08, cmbHC5OCTime09, cmbHC5OCTime10, cmbHC5OCTime11 };
            hc6OCTime = new ComboBox[] { cmbHC6OCTime00, cmbHC6OCTime01, cmbHC6OCTime02, cmbHC6OCTime03, cmbHC6OCTime04, cmbHC6OCTime05, cmbHC6OCTime06, cmbHC6OCTime07, cmbHC6OCTime08, cmbHC6OCTime09, cmbHC6OCTime10, cmbHC6OCTime11 };
            hcOCTime = new ComboBox[][] { hc1OCTime, hc2OCTime, hc3OCTime, hc4OCTime, hc5OCTime, hc6OCTime };
            hc1Mode = new ComboBox[] { cmbHC1Mode00, cmbHC1Mode01, cmbHC1Mode02, cmbHC1Mode03, cmbHC1Mode04, cmbHC1Mode05, cmbHC1Mode06, cmbHC1Mode07, cmbHC1Mode08, cmbHC1Mode09, cmbHC1Mode10, cmbHC1Mode11 };
            hc2Mode = new ComboBox[] { cmbHC2Mode00, cmbHC2Mode01, cmbHC2Mode02, cmbHC2Mode03, cmbHC2Mode04, cmbHC2Mode05, cmbHC2Mode06, cmbHC2Mode07, cmbHC2Mode08, cmbHC2Mode09, cmbHC2Mode10, cmbHC2Mode11 };
            hc3Mode = new ComboBox[] { cmbHC3Mode00, cmbHC3Mode01, cmbHC3Mode02, cmbHC3Mode03, cmbHC3Mode04, cmbHC3Mode05, cmbHC3Mode06, cmbHC3Mode07, cmbHC3Mode08, cmbHC3Mode09, cmbHC3Mode10, cmbHC3Mode11 };
            hc4Mode = new ComboBox[] { cmbHC4Mode00, cmbHC4Mode01, cmbHC4Mode02, cmbHC4Mode03, cmbHC4Mode04, cmbHC4Mode05, cmbHC4Mode06, cmbHC4Mode07, cmbHC4Mode08, cmbHC4Mode09, cmbHC4Mode10, cmbHC4Mode11 };
            hc5Mode = new ComboBox[] { cmbHC5Mode00, cmbHC5Mode01, cmbHC5Mode02, cmbHC5Mode03, cmbHC5Mode04, cmbHC5Mode05, cmbHC5Mode06, cmbHC5Mode07, cmbHC5Mode08, cmbHC5Mode09, cmbHC5Mode10, cmbHC5Mode11 };
            hc6Mode = new ComboBox[] { cmbHC6Mode00, cmbHC6Mode01, cmbHC6Mode02, cmbHC6Mode03, cmbHC6Mode04, cmbHC6Mode05, cmbHC6Mode06, cmbHC6Mode07, cmbHC6Mode08, cmbHC6Mode09, cmbHC6Mode10, cmbHC6Mode11 };
            hcModes = new ComboBox[][] { hc1Mode, hc2Mode, hc3Mode, hc4Mode, hc5Mode, hc6Mode };

            lcCardNum = new ComboBox[] { cmbLC1CardNum, cmbLC2CardNum, cmbLC3CardNum, cmbLC4CardNum, cmbLC5CardNum, cmbLC6CardNum };
            lcPanelNum = new ComboBox[] { cmbLC1PanelNum, cmbLC2PanelNum, cmbLC3PanelNum, cmbLC4PanelNum, cmbLC5PanelNum, cmbLC6PanelNum };
            lcConfigRev = new TextBox[] { tbxLC1CfgRev, tbxLC2CfgRev, tbxLC3CfgRev, tbxLC4CfgRev, tbxLC5CfgRev, tbxLC6CfgRev };
            lcConfigType = new TextBox[] { tbxLC1CfgType, tbxLC2CfgType, tbxLC3CfgType, tbxLC4CfgType, tbxLC5CfgType, tbxLC6CfgType };
            lcStandalone = new CheckBox[] { chkLC1Standalone, chkLC2Standalone, chkLC3Standalone, chkLC4Standalone, chkLC5Standalone, chkLC6Standalone };
            lcDCDimmer = new CheckBox[] { chkLC1DCDimmer, chkLC2DCDimmer, chkLC3DCDimmer, chkLC4DCDimmer, chkLC5DCDimmer, chkLC6DCDimmer };
            lcDCMotor = new CheckBox[] { chkLC1DCMotor, chkLC2DCMotor, chkLC3DCMotor, chkLC4DCMotor, chkLC5DCMotor, chkLC6DCMotor };
            lcShade = new CheckBox[] { chkLC1Shade, chkLC2Shade, chkLC3Shade, chkLC4Shade, chkLC5Shade, chkLC6Shade };
            lcForce = new CheckBox[] { chkLC1Force, chkLC2Force, chkLC3Force, chkLC4Force, chkLC5Force, chkLC6Force };
            lcBaseInstance = new TextBox[] { tbxLC1BaseIndex, tbxLC2BaseIndex, tbxLC3BaseIndex, tbxLC4BaseIndex, tbxLC5BaseIndex, tbxLC6BaseIndex };
            lc1OCAmps = new ComboBox[] { cmbLC1OCAmps00, cmbLC1OCAmps01, cmbLC1OCAmps02, cmbLC1OCAmps03, cmbLC1OCAmps04, cmbLC1OCAmps05, cmbLC1OCAmps06, cmbLC1OCAmps07, cmbLC1OCAmps08, cmbLC1OCAmps09, cmbLC1OCAmps10, cmbLC1OCAmps11, cmbLC1OCAmps12, cmbLC1OCAmps13, cmbLC1OCAmps14, cmbLC1OCAmps15 };
            lc2OCAmps = new ComboBox[] { cmbLC2OCAmps00, cmbLC2OCAmps01, cmbLC2OCAmps02, cmbLC2OCAmps03, cmbLC2OCAmps04, cmbLC2OCAmps05, cmbLC2OCAmps06, cmbLC2OCAmps07, cmbLC2OCAmps08, cmbLC2OCAmps09, cmbLC2OCAmps10, cmbLC2OCAmps11, cmbLC2OCAmps12, cmbLC2OCAmps13, cmbLC2OCAmps14, cmbLC2OCAmps15 };
            lc3OCAmps = new ComboBox[] { cmbLC3OCAmps00, cmbLC3OCAmps01, cmbLC3OCAmps02, cmbLC3OCAmps03, cmbLC3OCAmps04, cmbLC3OCAmps05, cmbLC3OCAmps06, cmbLC3OCAmps07, cmbLC3OCAmps08, cmbLC3OCAmps09, cmbLC3OCAmps10, cmbLC3OCAmps11, cmbLC3OCAmps12, cmbLC3OCAmps13, cmbLC3OCAmps14, cmbLC3OCAmps15 };
            lc4OCAmps = new ComboBox[] { cmbLC4OCAmps00, cmbLC4OCAmps01, cmbLC4OCAmps02, cmbLC4OCAmps03, cmbLC4OCAmps04, cmbLC4OCAmps05, cmbLC4OCAmps06, cmbLC4OCAmps07, cmbLC4OCAmps08, cmbLC4OCAmps09, cmbLC4OCAmps10, cmbLC4OCAmps11, cmbLC4OCAmps12, cmbLC4OCAmps13, cmbLC4OCAmps14, cmbLC4OCAmps15 };
            lc5OCAmps = new ComboBox[] { cmbLC5OCAmps00, cmbLC5OCAmps01, cmbLC5OCAmps02, cmbLC5OCAmps03, cmbLC5OCAmps04, cmbLC5OCAmps05, cmbLC5OCAmps06, cmbLC5OCAmps07, cmbLC5OCAmps08, cmbLC5OCAmps09, cmbLC5OCAmps10, cmbLC5OCAmps11, cmbLC5OCAmps12, cmbLC5OCAmps13, cmbLC5OCAmps14, cmbLC5OCAmps15 };
            lc6OCAmps = new ComboBox[] { cmbLC6OCAmps00, cmbLC6OCAmps01, cmbLC6OCAmps02, cmbLC6OCAmps03, cmbLC6OCAmps04, cmbLC6OCAmps05, cmbLC6OCAmps06, cmbLC6OCAmps07, cmbLC6OCAmps08, cmbLC6OCAmps09, cmbLC6OCAmps10, cmbLC6OCAmps11, cmbLC6OCAmps12, cmbLC6OCAmps13, cmbLC6OCAmps14, cmbLC6OCAmps15 };
            lcOCAmps = new ComboBox[][] { lc1OCAmps, lc2OCAmps, lc3OCAmps, lc4OCAmps, lc5OCAmps, lc6OCAmps };
            lc1OCTime = new ComboBox[] { cmbLC1OCTime00, cmbLC1OCTime01, cmbLC1OCTime02, cmbLC1OCTime03, cmbLC1OCTime04, cmbLC1OCTime05, cmbLC1OCTime06, cmbLC1OCTime07, cmbLC1OCTime08, cmbLC1OCTime09, cmbLC1OCTime10, cmbLC1OCTime11, cmbLC1OCTime12, cmbLC1OCTime13, cmbLC1OCTime14, cmbLC1OCTime15 };
            lc2OCTime = new ComboBox[] { cmbLC2OCTime00, cmbLC2OCTime01, cmbLC2OCTime02, cmbLC2OCTime03, cmbLC2OCTime04, cmbLC2OCTime05, cmbLC2OCTime06, cmbLC2OCTime07, cmbLC2OCTime08, cmbLC2OCTime09, cmbLC2OCTime10, cmbLC2OCTime11, cmbLC2OCTime12, cmbLC2OCTime13, cmbLC2OCTime14, cmbLC2OCTime15 };
            lc3OCTime = new ComboBox[] { cmbLC3OCTime00, cmbLC3OCTime01, cmbLC3OCTime02, cmbLC3OCTime03, cmbLC3OCTime04, cmbLC3OCTime05, cmbLC3OCTime06, cmbLC3OCTime07, cmbLC3OCTime08, cmbLC3OCTime09, cmbLC3OCTime10, cmbLC3OCTime11, cmbLC3OCTime12, cmbLC3OCTime13, cmbLC3OCTime14, cmbLC3OCTime15 };
            lc4OCTime = new ComboBox[] { cmbLC4OCTime00, cmbLC4OCTime01, cmbLC4OCTime02, cmbLC4OCTime03, cmbLC4OCTime04, cmbLC4OCTime05, cmbLC4OCTime06, cmbLC4OCTime07, cmbLC4OCTime08, cmbLC4OCTime09, cmbLC4OCTime10, cmbLC4OCTime11, cmbLC4OCTime12, cmbLC4OCTime13, cmbLC4OCTime14, cmbLC4OCTime15 };
            lc5OCTime = new ComboBox[] { cmbLC5OCTime00, cmbLC5OCTime01, cmbLC5OCTime02, cmbLC5OCTime03, cmbLC5OCTime04, cmbLC5OCTime05, cmbLC5OCTime06, cmbLC5OCTime07, cmbLC5OCTime08, cmbLC5OCTime09, cmbLC5OCTime10, cmbLC5OCTime11, cmbLC5OCTime12, cmbLC5OCTime13, cmbLC5OCTime14, cmbLC5OCTime15 };
            lc6OCTime = new ComboBox[] { cmbLC6OCTime00, cmbLC6OCTime01, cmbLC6OCTime02, cmbLC6OCTime03, cmbLC6OCTime04, cmbLC6OCTime05, cmbLC6OCTime06, cmbLC6OCTime07, cmbLC6OCTime08, cmbLC6OCTime09, cmbLC6OCTime10, cmbLC6OCTime11, cmbLC6OCTime12, cmbLC6OCTime13, cmbLC6OCTime14, cmbLC6OCTime15 };
            lcOCTime = new ComboBox[][] { lc1OCTime, lc2OCTime, lc3OCTime, lc4OCTime, lc5OCTime, lc6OCTime };
            lc1Mode = new ComboBox[] { cmbLC1Mode00, cmbLC1Mode01, cmbLC1Mode02, cmbLC1Mode03, cmbLC1Mode04, cmbLC1Mode05, cmbLC1Mode06, cmbLC1Mode07, cmbLC1Mode08, cmbLC1Mode09, cmbLC1Mode10, cmbLC1Mode11, cmbLC1Mode12, cmbLC1Mode13, cmbLC1Mode14, cmbLC1Mode15 };
            lc2Mode = new ComboBox[] { cmbLC2Mode00, cmbLC2Mode01, cmbLC2Mode02, cmbLC2Mode03, cmbLC2Mode04, cmbLC2Mode05, cmbLC2Mode06, cmbLC2Mode07, cmbLC2Mode08, cmbLC2Mode09, cmbLC2Mode10, cmbLC2Mode11, cmbLC2Mode12, cmbLC2Mode13, cmbLC2Mode14, cmbLC2Mode15 };
            lc3Mode = new ComboBox[] { cmbLC3Mode00, cmbLC3Mode01, cmbLC3Mode02, cmbLC3Mode03, cmbLC3Mode04, cmbLC3Mode05, cmbLC3Mode06, cmbLC3Mode07, cmbLC3Mode08, cmbLC3Mode09, cmbLC3Mode10, cmbLC3Mode11, cmbLC3Mode12, cmbLC3Mode13, cmbLC3Mode14, cmbLC3Mode15 };
            lc4Mode = new ComboBox[] { cmbLC4Mode00, cmbLC4Mode01, cmbLC4Mode02, cmbLC4Mode03, cmbLC4Mode04, cmbLC4Mode05, cmbLC4Mode06, cmbLC4Mode07, cmbLC4Mode08, cmbLC4Mode09, cmbLC4Mode10, cmbLC4Mode11, cmbLC4Mode12, cmbLC4Mode13, cmbLC4Mode14, cmbLC4Mode15 };
            lc5Mode = new ComboBox[] { cmbLC5Mode00, cmbLC5Mode01, cmbLC5Mode02, cmbLC5Mode03, cmbLC5Mode04, cmbLC5Mode05, cmbLC5Mode06, cmbLC5Mode07, cmbLC5Mode08, cmbLC5Mode09, cmbLC5Mode10, cmbLC5Mode11, cmbLC5Mode12, cmbLC5Mode13, cmbLC5Mode14, cmbLC5Mode15 };
            lc6Mode = new ComboBox[] { cmbLC6Mode00, cmbLC6Mode01, cmbLC6Mode02, cmbLC6Mode03, cmbLC6Mode04, cmbLC6Mode05, cmbLC6Mode06, cmbLC6Mode07, cmbLC6Mode08, cmbLC6Mode09, cmbLC6Mode10, cmbLC6Mode11, cmbLC6Mode12, cmbLC6Mode13, cmbLC6Mode14, cmbLC6Mode15 };
            lcModes = new ComboBox[][] { lc1Mode, lc2Mode, lc3Mode, lc4Mode, lc5Mode, lc6Mode };
        }

        private void cmbHC1Mode00_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode01_SelectedIndexChanged(object sender, EventArgs e)
        {
            // commenting this out until I have time to do all the other mode buttons, and should look into making this into functions

            //if (cmbHC1Mode01.Text == "RGB P")
            //{
            //    lblHC1Ch02.Visible = false;
            //    lblHC1Ch03.Visible = false;
            //    lblHC1Ch04.Visible = false;
            //    cmbHC1Mode02.SelectedIndex = 6; // R
            //    cmbHC1Mode03.SelectedIndex = 6; // G
            //    cmbHC1Mode04.SelectedIndex = 8; // B
            //}
            //else if (cmbHC1Mode01.Text == "RGBW P")
            //{
            //    lblHC1Ch02.Visible = false;
            //    lblHC1Ch03.Visible = false;
            //    lblHC1Ch04.Visible = false;
            //    lblHC1Ch05.Visible = false;
            //    cmbHC1Mode02.SelectedIndex = 6; // R
            //    cmbHC1Mode03.SelectedIndex = 6; // G
            //    cmbHC1Mode04.SelectedIndex = 8; // B
            //    cmbHC1Mode05.SelectedIndex = 9; // W
            //}
            //else if (cmbHC1Mode01.Text == "RP UP")
            //{
            //    lblHC1Ch02.Visible = false;
            //    cmbHC1Mode02.SelectedIndex = 3; // RP DN
            //}
            //else
            //{
            //    lblHC1Ch02.Visible = true;
            //    lblHC1Ch03.Visible = true;
            //    lblHC1Ch04.Visible = true;
            //    lblHC1Ch05.Visible = true;
            //}
        }

        private void cmbHC1Mode02_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode03_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode04_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode05_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode06_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode07_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode08_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode09_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC1Mode11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode01_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode02_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode03_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode04_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode05_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode06_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode07_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode08_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode09_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHC2Mode11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
