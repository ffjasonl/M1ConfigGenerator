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
        ComboBox[] Aux1Direction; ComboBox[] Aux2Direction;
        ComboBox[][] auxDirections;
        ComboBox[] Aux1DeadTime; ComboBox[] Aux2DeadTime;
        ComboBox[][] auxDeadTimes;
        ComboBox[] Aux1Paired; ComboBox[] Aux2Paired;
        ComboBox[][] auxPairedTimes;
        CheckBox[] Aux1Timeout; CheckBox[] Aux2Timeout;
        CheckBox[][] auxTimeouts;
        TextBox[] Aux1TimeoutTime; TextBox[] Aux2TimeoutTime;
        TextBox[][] auxTimeoutTimes;
        TextBox[] Aux1MaxOn; TextBox[] Aux2MaxOn;
        TextBox[][] auxMaxOns;
        TextBox[] Aux1MaxDurRec; TextBox[] Aux2MaxDurRec;
        TextBox[][] auxMaxDurRecs;
        
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
        ComboBox[] breaker1Direction; ComboBox[] breaker2Direction; ComboBox[] breaker3Direction; ComboBox[] breaker4Direction;
        ComboBox[][] breakerDirections;
        TextBox[] breaker1Undercurrent; TextBox[] breaker2Undercurrent; TextBox[] breaker3Undercurrent; TextBox[] breaker4Undercurrent;
        TextBox[][] breakerUndercurrents;
        ComboBox[] breaker1MeasCurRec; ComboBox[] breaker2MeasCurRec; ComboBox[] breaker3MeasCurRec; ComboBox[] breaker4MeasCurRec;
        ComboBox[][] breakerMeasCurRecs;
        ComboBox[] breaker1Mode; ComboBox[] breaker2Mode; ComboBox[] breaker3Mode; ComboBox[] breaker4Mode;
        ComboBox[][] breakerModes;
        ComboBox[] breaker1Paired; ComboBox[] breaker2Paired; ComboBox[] breaker3Paired; ComboBox[] breaker4Paired;
        ComboBox[][] breakerPairedTimes;
        ComboBox[] breaker1IGN; ComboBox[] breaker2IGN; ComboBox[] breaker3IGN; ComboBox[] breaker4IGN;
        ComboBox[][] breakerIGNs;
        ComboBox[] breaker1Park; ComboBox[] breaker2Park; ComboBox[] breaker3Park; ComboBox[] breaker4Park;
        ComboBox[][] breakerParks;

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
        CheckBox[] Dimmer1Lock; CheckBox[] Dimmer2Lock; CheckBox[] Dimmer3Lock; CheckBox[] Dimmer4Lock; CheckBox[] Dimmer5Lock; CheckBox[] Dimmer6Lock;
        CheckBox[][] dimmerLocks;
        ComboBox[] Dimmer1PWMFreq; ComboBox[] Dimmer2PWMFreq; ComboBox[] Dimmer3PWMFreq; ComboBox[] Dimmer4PWMFreq; ComboBox[] Dimmer5PWMFreq; ComboBox[] Dimmer6PWMFreq;
        ComboBox[][] dimmerPWMFreq;
        TextBox[] Dimmer1PWMDuty; TextBox[] Dimmer2PWMDuty; TextBox[] Dimmer3PWMDuty; TextBox[] Dimmer4PWMDuty; TextBox[] Dimmer5PWMDuty; TextBox[] Dimmer6PWMDuty;
        TextBox[][] dimmerPWMDuties;
        CheckBox[] Dimmer1PWMEnable; CheckBox[] Dimmer2PWMEnable; CheckBox[] Dimmer3PWMEnable; CheckBox[] Dimmer4PWMEnable; CheckBox[] Dimmer5PWMEnable; CheckBox[] Dimmer6PWMEnable;
        CheckBox[][] dimmerPWMEnables;
        CheckBox[] Dimmer1Override; CheckBox[] Dimmer2Override; CheckBox[] Dimmer3Override; CheckBox[] Dimmer4Override; CheckBox[] Dimmer5Override; CheckBox[] Dimmer6Override;
        CheckBox[][] dimmerOverrides;
        ComboBox[] Dimmer1Direction; ComboBox[] Dimmer2Direction; ComboBox[] Dimmer3Direction; ComboBox[] Dimmer4Direction; ComboBox[] Dimmer5Direction; ComboBox[] Dimmer6Direction;
        ComboBox[][] dimmerDirections;
        CheckBox[] Dimmer1Timeout; CheckBox[] Dimmer2Timeout; CheckBox[] Dimmer3Timeout; CheckBox[] Dimmer4Timeout; CheckBox[] Dimmer5Timeout; CheckBox[] Dimmer6Timeout;
        CheckBox[][] dimmerTimeouts;
        TextBox[] Dimmer1TimeoutTime; TextBox[] Dimmer2TimeoutTime; TextBox[] Dimmer3TimeoutTime; TextBox[] Dimmer4TimeoutTime; TextBox[] Dimmer5TimeoutTime; TextBox[] Dimmer6TimeoutTime;
        TextBox[][] dimmerTimeoutTimes;
        TextBox[] Dimmer1MaxOn; TextBox[] Dimmer2MaxOn; TextBox[] Dimmer3MaxOn; TextBox[] Dimmer4MaxOn; TextBox[] Dimmer5MaxOn; TextBox[] Dimmer6MaxOn;
        TextBox[][] dimmerMaxOns;
        TextBox[] Dimmer1MaxDurRec; TextBox[] Dimmer2MaxDurRec; TextBox[] Dimmer3MaxDurRec; TextBox[] Dimmer4MaxDurRec; TextBox[] Dimmer5MaxDurRec; TextBox[] Dimmer6MaxDurRec;
        TextBox[][] dimmerMaxDurRecs;
        TextBox[] Dimmer1UCAmps; TextBox[] Dimmer2UCAmps; TextBox[] Dimmer3UCAmps; TextBox[] Dimmer4UCAmps; TextBox[] Dimmer5UCAmps; TextBox[] Dimmer6UCAmps;
        TextBox[][] dimmerUCAmps;
        ComboBox[] Dimmer1MeasCurTime; ComboBox[] Dimmer2MeasCurTime; ComboBox[] Dimmer3MeasCurTime; ComboBox[] Dimmer4MeasCurTime; ComboBox[] Dimmer5MeasCurTime; ComboBox[] Dimmer6MeasCurTime;
        ComboBox[][] dimmerMeasCurTimes;


        List<HCCard> hcObjects = new List<HCCard>();
        ComboBox[] hcCardNum;
        ComboBox[] hcPanelNum;
        TextBox[] hcConfigRev;
        TextBox[] hcConfigType;
        CheckBox[] hcDCDimmer; CheckBox[] hcDCMotor; CheckBox[] hcShade; CheckBox[] hcForce; CheckBox[] hcRGB;
        TextBox[] hcBaseInstance;
        ComboBox[] hc1OCAmpsQuick; ComboBox[] hc2OCAmpsQuick; ComboBox[] hc3OCAmpsQuick; ComboBox[] hc4OCAmpsQuick; ComboBox[] hc5OCAmpsQuick; ComboBox[] hc6OCAmpsQuick;
        TextBox[] hc1OCAmps; TextBox[] hc2OCAmps; TextBox[] hc3OCAmps; TextBox[] hc4OCAmps; TextBox[] hc5OCAmps; TextBox[] hc6OCAmps;
        TextBox[][] hcOCAmps;
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
        ComboBox[] hc1Startup; ComboBox[] hc2Startup; ComboBox[] hc3Startup; ComboBox[] hc4Startup; ComboBox[] hc5Startup; ComboBox[] hc6Startup;
        ComboBox[][] hcStartup;
        CheckBox[] hc1Lock; CheckBox[] hc2Lock; CheckBox[] hc3Lock; CheckBox[] hc4Lock; CheckBox[] hc5Lock; CheckBox[] hc6Lock;
        CheckBox[][] hcLock;
        TextBox[] HC1PWMDuty; TextBox[] HC2PWMDuty; TextBox[] HC3PWMDuty; TextBox[] HC4PWMDuty; TextBox[] HC5PWMDuty; TextBox[] HC6PWMDuty;
        TextBox[][] hcPWMDuties;
        CheckBox[] HC1PWMEnable; CheckBox[] HC2PWMEnable; CheckBox[] HC3PWMEnable; CheckBox[] HC4PWMEnable; CheckBox[] HC5PWMEnable; CheckBox[] HC6PWMEnable;
        CheckBox[][] hcPWMEnables;
        ComboBox[] HC1Direction; ComboBox[] HC2Direction; ComboBox[] HC3Direction; ComboBox[] HC4Direction; ComboBox[] HC5Direction; ComboBox[] HC6Direction;
        ComboBox[][] hcDirections;
        ComboBox[] HC1ModeParam; ComboBox[] HC2ModeParam; ComboBox[] HC3ModeParam; ComboBox[] HC4ModeParam; ComboBox[] HC5ModeParam; ComboBox[] HC6ModeParam;
        ComboBox[][] hcModeParam;
        ComboBox[] HC1DeadTime; ComboBox[] HC2DeadTime; ComboBox[] HC3DeadTime; ComboBox[] HC4DeadTime; ComboBox[] HC5DeadTime; ComboBox[] HC6DeadTime;
        ComboBox[][] hcDeadTimes;
        ComboBox[] HC1Paired; ComboBox[] HC2Paired; ComboBox[] HC3Paired; ComboBox[] HC4Paired; ComboBox[] HC5Paired; ComboBox[] HC6Paired; 
        ComboBox[][] hcPaired;
        CheckBox[] HC1Timeout; CheckBox[] HC2Timeout; CheckBox[] HC3Timeout; CheckBox[] HC4Timeout; CheckBox[] HC5Timeout; CheckBox[] HC6Timeout;
        CheckBox[][] hcTimeouts;
        TextBox[] HC1TimeoutTime; TextBox[] HC2TimeoutTime; TextBox[] HC3TimeoutTime; TextBox[] HC4TimeoutTime; TextBox[] HC5TimeoutTime; TextBox[] HC6TimeoutTime;
        TextBox[][] hcTimeoutTimes;
        TextBox[] HC1MaxOn; TextBox[] HC2MaxOn; TextBox[] HC3MaxOn; TextBox[] HC4MaxOn; TextBox[] HC5MaxOn; TextBox[] HC6MaxOn;
        TextBox[][] hcMaxOns;
        TextBox[] HC1MaxDurRec; TextBox[] HC2MaxDurRec; TextBox[] HC3MaxDurRec; TextBox[] HC4MaxDurRec; TextBox[] HC5MaxDurRec; TextBox[] HC6MaxDurRec;
        TextBox[][] hcMaxDurRec;
        TextBox[] HC1UndAmp; TextBox[] HC2UndAmp; TextBox[] HC3UndAmp; TextBox[] HC4UndAmp; TextBox[] HC5UndAmp; TextBox[] HC6UndAmp;
        TextBox[][] hcUndAmps;
        ComboBox[] HC1MeasCurTime; ComboBox[] HC2MeasCurTime; ComboBox[] HC3MeasCurTime; ComboBox[] HC4MeasCurTime; ComboBox[] HC5MeasCurTime; ComboBox[] HC6MeasCurTime;
        ComboBox[][] hcMeasCurTimes;

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
        CheckBox[] lc1Lock; CheckBox[] lc2Lock; CheckBox[] lc3Lock; CheckBox[] lc4Lock; CheckBox[] lc5Lock; CheckBox[] lc6Lock;
        CheckBox[][] lcLocks;
        ComboBox[] lc1Direction; ComboBox[] lc2Direction; ComboBox[] lc3Direction; ComboBox[] lc4Direction; ComboBox[] lc5Direction; ComboBox[] lc6Direction;
        ComboBox[][] lcDirections;
        TextBox[] lc1TimeoutTime; TextBox[] lc2TimeoutTime; TextBox[] lc3TimeoutTime; TextBox[] lc4TimeoutTime; TextBox[] lc5TimeoutTime; TextBox[] lc6TimeoutTime;
        TextBox[][] lcTimeoutTimes;
        TextBox[] lc1MaxOn; TextBox[] lc2MaxOn; TextBox[] lc3MaxOn; TextBox[] lc4MaxOn; TextBox[] lc5MaxOn; TextBox[] lc6MaxOn;
        TextBox[][] lcMaxOns;
        TextBox[] lc1MaxDurRecovery; TextBox[] lc2MaxDurRecovery; TextBox[] lc3MaxDurRecovery; TextBox[] lc4MaxDurRecovery; TextBox[] lc5MaxDurRecovery; TextBox[] lc6MaxDurRecovery;
        TextBox[][] lcMaxDurRecoveries;
        TextBox[] lc1UCAmp; TextBox[] lc2UCAmp; TextBox[] lc3UCAmp; TextBox[] lc4UCAmp; TextBox[] lc5UCAmp; TextBox[] lc6UCAmp;
        TextBox[][] lcUCAmps;
        ComboBox[] lc1MeasCurTime; ComboBox[] lc2MeasCurTime; ComboBox[] lc3MeasCurTime; ComboBox[] lc4MeasCurTime; ComboBox[] lc5MeasCurTime; ComboBox[] lc6MeasCurTime;
        ComboBox[][] lcMeasCurTimes;


        public Form1()
        {
            InitializeComponent();

            Load += new EventHandler(Form1_Load);

            int[] AuxColor = { 83, 52, 129 };
            int[] BreakerColor = { 217, 58, 78 };
            int[] DimmerColor = { 27, 161, 119 };
            int[] HCColor = { 24, 80, 135 };
            int[] LCColor = { 208, 110, 152 };
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
                auxObjects[card].M1_SetDevAddr(auxCardNum[card].SelectedIndex, auxPanelNum[card].SelectedIndex);
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
                    auxObjects[card].SetDirection(channel, auxDirections[card][channel].Text);
                    auxObjects[card].SetDeadTime(channel, auxDeadTimes[card][channel].Text);
                    auxObjects[card].SetPaired(channel, auxPairedTimes[card][channel].Text);
                    auxObjects[card].SetTimeout(channel, auxTimeouts[card][channel].Checked);
                    auxObjects[card].SetTimeoutTime(channel, auxTimeoutTimes[card][channel].Text);
                    auxObjects[card].SetMaxOn(channel, auxMaxOns[card][channel].Text);
                    auxObjects[card].SetMaxDurRec(channel, auxMaxDurRecs[card][channel].Text);
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
                breakerObjects[card].M1_SetDevAddr(breakerCardNum[card].SelectedIndex, breakerPanelNum[card].SelectedIndex);
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
            tabControlBreaker.SelectedIndex = 1;/*
            tabControlBreaker1QF.SelectedIndex = 0;*/
        }

        private void btnBreakerCard2_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard2);
            tabControlBreaker.SelectedIndex = 2;
            tablessControl4.SelectedIndex = 0;
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
                dimmerObjects[card].M1_SetDevAddr(dimCardNum[card].SelectedIndex, dimPanelNum[card].SelectedIndex);
                dimmerObjects[card].M1_SetCfgRev(dimConfigRev[card].Text);
                dimmerObjects[card].M1_SetCfgType(dimConfigType[card].Text);
                dimmerObjects[card].M1_SetDCDimmer(true); // hard coding for dimmer card
                dimmerObjects[card].M1_SetDCMotor(dimDCMotor[card].Checked);
                dimmerObjects[card].M1_SetShade(dimShade[card].Checked);
                dimmerObjects[card].M1_SetForce(dimForce[card].Checked);
                dimmerObjects[card].M1_SetBaseIndex(dimBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    dimmerObjects[card].SetOCAmps(channel, dimmerOCAmps[card][channel].Text);
                    dimmerObjects[card].SetOCTime(channel, dimmerOCTime[card][channel].Text);
                    dimmerObjects[card].M1_SetGroup0(dimGroups[card][channel], channel); // takes care of all 4 groups
                    dimmerObjects[card].SetLock(channel, dimmerLocks[card][channel].Checked);
                    dimmerObjects[card].SetPWMFreq(channel, dimmerPWMFreq[card][channel].Text);
                    dimmerObjects[card].SetPWMDuty(channel, dimmerPWMDuties[card][channel].Text);
                    dimmerObjects[card].SetPWMEnable(channel, dimmerPWMEnables[card][channel].Checked);
                    dimmerObjects[card].SetOverride(channel, dimmerOverrides[card][channel].Checked);
                    dimmerObjects[card].SetTimeout(channel, dimmerTimeouts[card][channel].Checked);
                    dimmerObjects[card].SetDirection(channel, dimmerDirections[card][channel].Text);
                    dimmerObjects[card].SetTimeoutTime(channel, dimmerTimeoutTimes[card][channel].Text);
                    dimmerObjects[card].SetMaxOn(channel, dimmerMaxOns[card][channel].Text);
                    dimmerObjects[card].SetMaxDurRec(channel, dimmerMaxDurRecs[card][channel].Text);
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
            tabControlDimmer1QF.SelectedIndex = 0;
        }

        private void btnDimmerCard2_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard2);
            tabControlDimmer.SelectedIndex = 2;
            tabControlDimmer2QF.SelectedIndex = 1;
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

            //hc1Startup = new bool[] { chkHC1Startup00.Checked, chkHC1Startup01.Checked, chkHC1Startup02.Checked, chkHC1Startup03.Checked, chkHC1Startup04.Checked, chkHC1Startup05.Checked, chkHC1Startup06.Checked, chkHC1Startup07.Checked, chkHC1Startup08.Checked, chkHC1Startup09.Checked, chkHC1Startup10.Checked, chkHC1Startup11.Checked };
            //hc2Startup = new bool[] { chkHC2Startup00.Checked, chkHC2Startup01.Checked, chkHC2Startup02.Checked, chkHC2Startup03.Checked, chkHC2Startup04.Checked, chkHC2Startup05.Checked, chkHC2Startup06.Checked, chkHC2Startup07.Checked, chkHC2Startup08.Checked, chkHC2Startup09.Checked, chkHC2Startup10.Checked, chkHC2Startup11.Checked };
            //hc3Startup = new bool[] { chkHC3Startup00.Checked, chkHC3Startup01.Checked, chkHC3Startup02.Checked, chkHC3Startup03.Checked, chkHC3Startup04.Checked, chkHC3Startup05.Checked, chkHC3Startup06.Checked, chkHC3Startup07.Checked, chkHC3Startup08.Checked, chkHC3Startup09.Checked, chkHC3Startup10.Checked, chkHC3Startup11.Checked };
            //hc4Startup = new bool[] { chkHC4Startup00.Checked, chkHC4Startup01.Checked, chkHC4Startup02.Checked, chkHC4Startup03.Checked, chkHC4Startup04.Checked, chkHC4Startup05.Checked, chkHC4Startup06.Checked, chkHC4Startup07.Checked, chkHC4Startup08.Checked, chkHC4Startup09.Checked, chkHC4Startup10.Checked, chkHC4Startup11.Checked };
            //hc5Startup = new bool[] { chkHC5Startup00.Checked, chkHC5Startup01.Checked, chkHC5Startup02.Checked, chkHC5Startup03.Checked, chkHC5Startup04.Checked, chkHC5Startup05.Checked, chkHC5Startup06.Checked, chkHC5Startup07.Checked, chkHC5Startup08.Checked, chkHC5Startup09.Checked, chkHC5Startup10.Checked, chkHC5Startup11.Checked };
            //hc6Startup = new bool[] { chkHC6Startup00.Checked, chkHC6Startup01.Checked, chkHC6Startup02.Checked, chkHC6Startup03.Checked, chkHC6Startup04.Checked, chkHC6Startup05.Checked, chkHC6Startup06.Checked, chkHC6Startup07.Checked, chkHC6Startup08.Checked, chkHC6Startup09.Checked, chkHC6Startup10.Checked, chkHC6Startup11.Checked };
            //hcStartup = new bool[][] { hc1Startup, hc2Startup, hc3Startup, hc4Startup, hc5Startup, hc6Startup };

            // needed to make a list of multidimensional arrays to pass to the group allocation function
            List<bool[][]> hcGroups = new List<bool[][]>();
            hcGroups.Add(hc1Groups);
            hcGroups.Add(hc2Groups);
            hcGroups.Add(hc3Groups);
            hcGroups.Add(hc4Groups);
            hcGroups.Add(hc5Groups);
            hcGroups.Add(hc6Groups);


            // HC cards
            for (int card = 0; card < Convert.ToInt16(cmbStartHC.Text); card++)
            {
                hcObjects[card].M1_SetDevAddr(hcCardNum[card].SelectedIndex, hcPanelNum[card].SelectedIndex);
                hcObjects[card].M1_SetCfgRev(hcConfigRev[card].Text);
                hcObjects[card].M1_SetCfgType(hcConfigType[card].Text);
                hcObjects[card].M1_SetDCDimmer(hcDCDimmer[card].Checked);
                hcObjects[card].HC_SetRGB(hcRGB[card].Checked);
                hcObjects[card].M1_SetDCMotor(hcDCMotor[card].Checked);
                hcObjects[card].M1_SetShade(hcShade[card].Checked);
                hcObjects[card].M1_SetForce(hcForce[card].Checked);
                hcObjects[card].M1_SetBaseIndex(hcBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    hcObjects[card].HC_SetLock(channel, hcLock[0][channel].Checked);
                    hcObjects[card].HC_SetPWMDuty(channel, hcPWMDuties[card][channel].Text);
                    hcObjects[card].HC_SetPWMEnable(channel, hcPWMEnables[card][channel].Checked);
                    hcObjects[card].HC_SetDirection(channel, hcDirections[card][channel].Text);
                    hcObjects[card].HC_SetMode(channel, hcModeParam[card][channel].Text);
                    hcObjects[card].HC_SetDeadTime(channel, hcDeadTimes[card][channel].Text);
                    hcObjects[card].HC_SetPaired(channel, hcPaired[card][channel].Text);
                    hcObjects[card].HC_SetTimeout(channel, hcTimeouts[card][channel].Checked);
                    hcObjects[card].HC_SetTimeoutTime(channel, hcTimeoutTimes[card][channel].Text);
                    hcObjects[card].HC_SetMaxOn(channel, hcMaxOns[card][channel].Text);
                    hcObjects[card].HC_SetMaxDurRec(channel, hcMaxDurRec[card][channel].Text);
                    hcObjects[card].M1_SetGroup0(hcGroups[card][channel], channel); // takes care of all 4 groups
                    hcObjects[card].HC_SetOCAmps(channel, hcOCAmps[card][channel].Text);
                    hcObjects[card].HC_SetUndAmp(channel, hcUndAmps[card][channel].Text);
                    hcObjects[card].HC_SetOCTime(channel, hcOCTime[card][channel].Text);
                    hcObjects[card].HC_SetMeasCurTime(channel, hcMeasCurTimes[card][channel].Text);
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
            tabControlHC1QF. SelectedIndex = 0;
        }

        private void btnHCCard2_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard2);
            tabControlHC.SelectedIndex = 2;
            tabControlHC2QF.SelectedIndex = 0;
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
        private void cmbHC1Startup00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHC1Startup00.Text == "Latch")
            {
                chkHC1Lock00.Checked = false;
                txtbHC1PWMDutyCh00.Text = "200";
                cmbHC1DirectionCh00.Text = (cmbHC1Mode00.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup00.Text == "Constant")
            {
                chkHC1Lock00.Checked = true;
                txtbHC1PWMDutyCh00.Text = "200";
                cmbHC1DirectionCh00.Text = (cmbHC1Mode00.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh01.Text = (cmbHC1Mode01.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup01.Text == "Constant")
            {
                chkHC1Lock01.Checked = true;
                txtbHC1PWMDutyCh01.Text = "200";
                cmbHC1DirectionCh01.Text = (cmbHC1Mode01.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh02.Text = (cmbHC1Mode02.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup02.Text == "Constant")
            {
                chkHC1Lock02.Checked = true;
                txtbHC1PWMDutyCh02.Text = "200";
                cmbHC1DirectionCh02.Text = (cmbHC1Mode02.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh03.Text = (cmbHC1Mode03.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup03.Text == "Constant")
            {
                chkHC1Lock03.Checked = true;
                txtbHC1PWMDutyCh03.Text = "200";
                cmbHC1DirectionCh03.Text = (cmbHC1Mode03.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh04.Text = (cmbHC1Mode04.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup04.Text == "Constant")
            {
                chkHC1Lock04.Checked = true;
                txtbHC1PWMDutyCh04.Text = "200";
                cmbHC1DirectionCh04.Text = (cmbHC1Mode04.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh05.Text = (cmbHC1Mode05.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup05.Text == "Constant")
            {
                chkHC1Lock05.Checked = true;
                txtbHC1PWMDutyCh05.Text = "200";
                cmbHC1DirectionCh05.Text = (cmbHC1Mode05.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh06.Text = (cmbHC1Mode06.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup06.Text == "Constant")
            {
                chkHC1Lock06.Checked = true;
                txtbHC1PWMDutyCh06.Text = "200";
                cmbHC1DirectionCh06.Text = (cmbHC1Mode06.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh07.Text = (cmbHC1Mode07.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup07.Text == "Constant")
            {
                chkHC1Lock07.Checked = true;
                txtbHC1PWMDutyCh07.Text = "200";
                cmbHC1DirectionCh07.Text = (cmbHC1Mode07.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh08.Text = (cmbHC1Mode08.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup08.Text == "Constant")
            {
                chkHC1Lock08.Checked = true;
                txtbHC1PWMDutyCh08.Text = "200";
                cmbHC1DirectionCh08.Text = (cmbHC1Mode08.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh09.Text = (cmbHC1Mode09.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup09.Text == "Constant")
            {
                chkHC1Lock09.Checked = true;
                txtbHC1PWMDutyCh09.Text = "200";
                cmbHC1DirectionCh09.Text = (cmbHC1Mode09.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh10.Text = (cmbHC1Mode10.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup10.Text == "Constant")
            {
                chkHC1Lock10.Checked = true;
                txtbHC1PWMDutyCh10.Text = "200";
                cmbHC1DirectionCh10.Text = (cmbHC1Mode10.Text == "Ground" ? "Low" : "High");
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
                cmbHC1DirectionCh11.Text = (cmbHC1Mode11.Text == "Ground" ? "Low" : "High");
            }
            else if (cmbHC1Startup11.Text == "Constant")
            {
                chkHC1Lock11.Checked = true;
                txtbHC1PWMDutyCh11.Text = "200";
                cmbHC1DirectionCh11.Text = (cmbHC1Mode11.Text == "Ground" ? "Low" : "High");
            }
            else // off
            {
                chkHC1Lock11.Checked = false;
                txtbHC1PWMDutyCh11.Text = "0";
                cmbHC1DirectionCh11.Text = "Off";
            }
        }

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
            }
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
            }
            else if (cmbHC1Mode01.Text == "RP DN")
            {
                cmbHC1ModeParamCh01.Text = "Slave";
                cmbHC1DeadTimeCh01.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh01.Text = "0";
            }
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
            }
            else if (cmbHC1Mode02.Text == "RP DN")
            {
                cmbHC1ModeParamCh02.Text = "Slave";
                cmbHC1DeadTimeCh02.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh02.Text = "1";
            }
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
            }
            else if (cmbHC1Mode03.Text == "RP DN")
            {
                cmbHC1ModeParamCh03.Text = "Slave";
                cmbHC1DeadTimeCh03.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh03.Text = "2";
            }
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
            }
            else if (cmbHC1Mode04.Text == "RP DN")
            {
                cmbHC1ModeParamCh04.Text = "Slave";
                cmbHC1DeadTimeCh04.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh04.Text = "3";
            }
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
            }
            else if (cmbHC1Mode05.Text == "RP DN")
            {
                cmbHC1ModeParamCh05.Text = "Slave";
                cmbHC1DeadTimeCh05.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh05.Text = "4";
            }
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
            }
            else if (cmbHC1Mode06.Text == "RP DN")
            {
                cmbHC1ModeParamCh06.Text = "Slave";
                cmbHC1DeadTimeCh06.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh06.Text = "5";
            }
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
            }
            else if (cmbHC1Mode07.Text == "RP DN")
            {
                cmbHC1ModeParamCh07.Text = "Slave";
                cmbHC1DeadTimeCh07.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh07.Text = "6";
            }
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
            }
            else if (cmbHC1Mode08.Text == "RP DN")
            {
                cmbHC1ModeParamCh08.Text = "Slave";
                cmbHC1DeadTimeCh08.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh08.Text = "7";
            }
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
            }
            else if (cmbHC1Mode09.Text == "RP DN")
            {
                cmbHC1ModeParamCh09.Text = "Slave";
                cmbHC1DeadTimeCh09.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh09.Text = "8";
            }
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
            }
            else if (cmbHC1Mode10.Text == "RP DN")
            {
                cmbHC1ModeParamCh10.Text = "Slave";
                cmbHC1DeadTimeCh10.Text = "500"; // probably not needed, just in case
                cmbHC1PairedCh10.Text = "9";
            }
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
            }
        }

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
                lcObjects[card].M1_SetDevAddr(lcCardNum[card].SelectedIndex, lcPanelNum[card].SelectedIndex);
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
                        lcObjects[card].SetOCAmps(channel, lcOCAmps[card][channel].Text);
                        lcObjects[card].SetOCTime(channel, lcOCTime[card][channel].Text);
                    }
                    lcObjects[card].M1_SetGroup0(lcGroups[card][channel], channel); // takes care of all 4 groups
                    lcObjects[card].SetLock(lcLocks[card][channel].Checked, channel);
                    lcObjects[card].SetDirection(lcDirections[card][channel].Text, channel);
                    lcObjects[card].SetTimeoutTimes(lcTimeoutTimes[card][channel].Text, channel);
                    lcObjects[card].SetMaxOn(lcMaxOns[card][channel].Text, channel);
                    lcObjects[card].SetMaxDurRecovery(lcMaxDurRecoveries[card][channel].Text, channel);
                    lcObjects[card].SetUCAmp(lcUCAmps[card][channel].Text, channel);
                    lcObjects[card].SetMeasCurTime(lcMeasCurTimes[card][channel].Text, channel);
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
            tabControlLC2QF.SelectedIndex = 0 ;
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
            SetSelectedIndex(hc1OCAmpsQuick, 5); SetSelectedIndex(hc2OCAmpsQuick, 5); SetSelectedIndex(hc3OCAmpsQuick, 5); SetSelectedIndex(hc4OCAmpsQuick, 5); SetSelectedIndex(hc5OCAmpsQuick, 5); SetSelectedIndex(hc6OCAmpsQuick, 5);
            SetSelectedIndex(hc1OCTime, 1); SetSelectedIndex(hc2OCTime, 1); SetSelectedIndex(hc3OCTime, 1); SetSelectedIndex(hc4OCTime, 1); SetSelectedIndex(hc5OCTime, 1); SetSelectedIndex(hc6OCTime, 1);
            SetSelectedIndex(hc1Mode, 0); SetSelectedIndex(hc2Mode, 0); SetSelectedIndex(hc3Mode, 0); SetSelectedIndex(hc4Mode, 0); SetSelectedIndex(hc5Mode, 0); SetSelectedIndex(hc6Mode, 0);
            SetSelectedIndex(hc1Startup, 0);
            SetSelectedIndex(HC1ModeParam, 0);
            SetSelectedIndex(HC1DeadTime, 0);
            SetSelectedIndex(HC1Paired, 0);
            SetSelectedIndex(HC1MeasCurTime, 3);
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
            Aux1Direction = new ComboBox[] { cmbAux1DirectionCh00, cmbAux1DirectionCh01, cmbAux1DirectionCh02, cmbAux1DirectionCh03, cmbAux1DirectionCh04, cmbAux1DirectionCh05, cmbAux1DirectionCh06, cmbAux1DirectionCh07, cmbAux1DirectionCh08, cmbAux1DirectionCh09, cmbAux1DirectionCh10, cmbAux1DirectionCh11 };
            Aux2Direction = new ComboBox[] { cmbAux2DirectionCh00, cmbAux2DirectionCh01, cmbAux2DirectionCh02, cmbAux2DirectionCh03, cmbAux2DirectionCh04, cmbAux2DirectionCh05, cmbAux2DirectionCh06, cmbAux2DirectionCh07, cmbAux2DirectionCh08, cmbAux2DirectionCh09, cmbAux2DirectionCh10, cmbAux2DirectionCh11 }; 
            auxDirections = new ComboBox[][] { Aux1Direction, Aux2Direction };
            Aux1DeadTime = new ComboBox[] { cmbAux1DeadTimeCh00, cmbAux1DeadTimeCh01, cmbAux1DeadTimeCh02, cmbAux1DeadTimeCh03, cmbAux1DeadTimeCh04, cmbAux1DeadTimeCh05, cmbAux1DeadTimeCh06, cmbAux1DeadTimeCh07, cmbAux1DeadTimeCh08, cmbAux1DeadTimeCh09, cmbAux1DeadTimeCh10, cmbAux1DeadTimeCh11 }; 
            Aux2DeadTime = new ComboBox[] { cmbAux2DeadTimeCh00, cmbAux2DeadTimeCh01, cmbAux2DeadTimeCh02, cmbAux2DeadTimeCh03, cmbAux2DeadTimeCh04, cmbAux2DeadTimeCh05, cmbAux2DeadTimeCh06, cmbAux2DeadTimeCh07, cmbAux2DeadTimeCh08, cmbAux2DeadTimeCh09, cmbAux2DeadTimeCh10, cmbAux2DeadTimeCh11 };
            auxDeadTimes = new ComboBox[][] { Aux1DeadTime, Aux2DeadTime };
            Aux1Paired = new ComboBox[] { cmbAux1PairedCh00, cmbAux1PairedCh01, cmbAux1PairedCh02, cmbAux1PairedCh03, cmbAux1PairedCh04, cmbAux1PairedCh05, cmbAux1PairedCh06, cmbAux1PairedCh07, cmbAux1PairedCh08, cmbAux1PairedCh09, cmbAux1PairedCh10, cmbAux1PairedCh11 };
            Aux2Paired = new ComboBox[] { cmbAux2PairedCh00, cmbAux2PairedCh01, cmbAux2PairedCh02, cmbAux2PairedCh03, cmbAux2PairedCh04, cmbAux2PairedCh05, cmbAux2PairedCh06, cmbAux2PairedCh07, cmbAux2PairedCh08, cmbAux2PairedCh09, cmbAux2PairedCh10, cmbAux2PairedCh11 };
            auxPairedTimes = new ComboBox[][] { Aux1Paired, Aux2Paired };
            Aux1Timeout = new CheckBox[] { chkAux1TimeoutCh00, chkAux1TimeoutCh01, chkAux1TimeoutCh02, chkAux1TimeoutCh03, chkAux1TimeoutCh04, chkAux1TimeoutCh05, chkAux1TimeoutCh06, chkAux1TimeoutCh07, chkAux1TimeoutCh08, chkAux1TimeoutCh09, chkAux1TimeoutCh10, chkAux1TimeoutCh11 };
            Aux2Timeout = new CheckBox[] { chkAux2TimeoutCh00, chkAux2TimeoutCh01, chkAux2TimeoutCh02, chkAux2TimeoutCh03, chkAux2TimeoutCh04, chkAux2TimeoutCh05, chkAux2TimeoutCh06, chkAux2TimeoutCh07, chkAux2TimeoutCh08, chkAux2TimeoutCh09, chkAux2TimeoutCh10, chkAux2TimeoutCh11 };
            auxTimeouts = new CheckBox[][] { Aux1Timeout, Aux2Timeout };
            Aux1TimeoutTime = new TextBox[] { txtbAux1TimeoutTimeCh00, txtbAux1TimeoutTimeCh01, txtbAux1TimeoutTimeCh02, txtbAux1TimeoutTimeCh03, txtbAux1TimeoutTimeCh04, txtbAux1TimeoutTimeCh05, txtbAux1TimeoutTimeCh06, txtbAux1TimeoutTimeCh07, txtbAux1TimeoutTimeCh08, txtbAux1TimeoutTimeCh09, txtbAux1TimeoutTimeCh10, txtbAux1TimeoutTimeCh11 };
            Aux2TimeoutTime = new TextBox[] { txtbAux2TimeoutTimeCh00, txtbAux2TimeoutTimeCh01, txtbAux2TimeoutTimeCh02, txtbAux2TimeoutTimeCh03, txtbAux2TimeoutTimeCh04, txtbAux2TimeoutTimeCh05, txtbAux2TimeoutTimeCh06, txtbAux2TimeoutTimeCh07, txtbAux2TimeoutTimeCh08, txtbAux2TimeoutTimeCh09, txtbAux2TimeoutTimeCh10, txtbAux2TimeoutTimeCh11 };
            auxTimeoutTimes = new TextBox[][] { Aux1TimeoutTime, Aux2TimeoutTime }; 
            Aux1MaxOn = new TextBox[] { txtbAux1MaxOnCh00, txtbAux1MaxOnCh01, txtbAux1MaxOnCh02, txtbAux1MaxOnCh03, txtbAux1MaxOnCh04, txtbAux1MaxOnCh05, txtbAux1MaxOnCh06, txtbAux1MaxOnCh07, txtbAux1MaxOnCh08, txtbAux1MaxOnCh09, txtbAux1MaxOnCh10, txtbAux1MaxOnCh11 };
            Aux2MaxOn = new TextBox[] { txtbAux2MaxOnCh00, txtbAux2MaxOnCh01, txtbAux2MaxOnCh02, txtbAux2MaxOnCh03, txtbAux2MaxOnCh04, txtbAux2MaxOnCh05, txtbAux2MaxOnCh06, txtbAux2MaxOnCh07, txtbAux2MaxOnCh08, txtbAux2MaxOnCh09, txtbAux2MaxOnCh10, txtbAux2MaxOnCh11 };
            auxMaxOns = new TextBox[][] { Aux1MaxOn, Aux2MaxOn };
            Aux1MaxDurRec = new TextBox[] { txtbAux1MaxDurRecCh00, txtbAux1MaxDurRecCh01, txtbAux1MaxDurRecCh02, txtbAux1MaxDurRecCh03, txtbAux1MaxDurRecCh04, txtbAux1MaxDurRecCh05, txtbAux1MaxDurRecCh06, txtbAux1MaxDurRecCh07, txtbAux1MaxDurRecCh08, txtbAux1MaxDurRecCh09, txtbAux1MaxDurRecCh10, txtbAux1MaxDurRecCh11 };
            Aux2MaxDurRec = new TextBox[] { txtbAux2MaxDurRecCh00, txtbAux2MaxDurRecCh01, txtbAux2MaxDurRecCh02, txtbAux2MaxDurRecCh03, txtbAux2MaxDurRecCh04, txtbAux2MaxDurRecCh05, txtbAux2MaxDurRecCh06, txtbAux2MaxDurRecCh07, txtbAux2MaxDurRecCh08, txtbAux2MaxDurRecCh09, txtbAux2MaxDurRecCh10, txtbAux2MaxDurRecCh11 };
            auxMaxDurRecs = new TextBox[][] { Aux1MaxDurRec, Aux2MaxDurRec };

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
            breaker1Direction = new ComboBox[] { cmbBreak1DirectionCh00, cmbBreak1DirectionCh01, cmbBreak1DirectionCh02, cmbBreak1DirectionCh03, cmbBreak1DirectionCh04, cmbBreak1DirectionCh05, cmbBreak1DirectionCh06, cmbBreak1DirectionCh07, cmbBreak1DirectionCh08, cmbBreak1DirectionCh09, cmbBreak1DirectionCh10, cmbBreak1DirectionCh11 };
            breaker2Direction = new ComboBox[] { cmbBreak2DirectionCh00, cmbBreak2DirectionCh01, cmbBreak2DirectionCh02, cmbBreak2DirectionCh03, cmbBreak2DirectionCh04, cmbBreak2DirectionCh05, cmbBreak2DirectionCh06, cmbBreak2DirectionCh07, cmbBreak2DirectionCh08, cmbBreak2DirectionCh09, cmbBreak2DirectionCh10, cmbBreak2DirectionCh11 };
            breaker3Direction = new ComboBox[] { cmbBreak3DirectionCh00, cmbBreak3DirectionCh01, cmbBreak3DirectionCh02, cmbBreak3DirectionCh03, cmbBreak3DirectionCh04, cmbBreak3DirectionCh05, cmbBreak3DirectionCh06, cmbBreak3DirectionCh07, cmbBreak3DirectionCh08, cmbBreak3DirectionCh09, cmbBreak3DirectionCh10, cmbBreak3DirectionCh11 };
            breaker4Direction = new ComboBox[] { cmbBreak4DirectionCh00, cmbBreak4DirectionCh01, cmbBreak4DirectionCh02, cmbBreak4DirectionCh03, cmbBreak4DirectionCh04, cmbBreak4DirectionCh05, cmbBreak4DirectionCh06, cmbBreak4DirectionCh07, cmbBreak4DirectionCh08, cmbBreak4DirectionCh09, cmbBreak4DirectionCh10, cmbBreak4DirectionCh11 };
            breakerDirections = new ComboBox[][] { breaker1Direction, breaker2Direction, breaker3Direction, breaker4Direction };
            breaker1Undercurrent = new TextBox[] { txtbBreak1UCAmpsCh00, txtbBreak1UCAmpsCh01, txtbBreak1UCAmpsCh02, txtbBreak1UCAmpsCh03, txtbBreak1UCAmpsCh04, txtbBreak1UCAmpsCh05, txtbBreak1UCAmpsCh06, txtbBreak1UCAmpsCh07, txtbBreak1UCAmpsCh08, txtbBreak1UCAmpsCh09, txtbBreak1UCAmpsCh10, txtbBreak1UCAmpsCh11 };
            breaker2Undercurrent = new TextBox[] { txtbBreak2UCAmpsCh00, txtbBreak2UCAmpsCh01, txtbBreak2UCAmpsCh02, txtbBreak2UCAmpsCh03, txtbBreak2UCAmpsCh04, txtbBreak2UCAmpsCh05, txtbBreak2UCAmpsCh06, txtbBreak2UCAmpsCh07, txtbBreak2UCAmpsCh08, txtbBreak2UCAmpsCh09, txtbBreak2UCAmpsCh10, txtbBreak2UCAmpsCh11 };
            breaker3Undercurrent = new TextBox[] { txtbBreak3UCAmpsCh00, textBox111, txtbBreak3UCAmpsCh02, txtbBreak3UCAmpsCh03, txtbBreak3UCAmpsCh04, txtbBreak3UCAmpsCh05, txtbBreak3UCAmpsCh06, txtbBreak3UCAmpsCh07, txtbBreak3UCAmpsCh08, txtbBreak3UCAmpsCh09, txtbBreak3UCAmpsC10, txtbBreak3UCAmpsCh11 };
            breaker4Undercurrent = new TextBox[] { txtbBreak4UCAmpsCh00, txtbBreak4UCAmpsCh01, txtbBreak4UCAmpsCh02, txtbBreak4UCAmpsCh03, txtbBreak4UCAmpsCh04, txtbBreak4UCAmpsCh05, txtbBreak4UCAmpsCh06, txtbBreak4UCAmpsCh07, txtbBreak4UCAmpsCh08, txtbBreak4UCAmpsCh09, txtbBreak4UCAmpsCh10, txtbBreak4UCAmpsCh11 };
            breakerUndercurrents = new TextBox[][] { breaker1Undercurrent, breaker2Undercurrent, breaker3Undercurrent, breaker4Undercurrent };
            breaker1MeasCurRec = new ComboBox[] { cmbBreak1MeasCurRecCh00, cmbBreak1MeasCurRecCh01, cmbBreak1MeasCurRecCh02, cmbBreak1MeasCurRecCh03, cmbBreak1MeasCurRecCh04, cmbBreak1MeasCurRecCh05, cmbBreak1MeasCurRecCh06, cmbBreak1MeasCurRecCh07, cmbBreak1MeasCurRecCh08, cmbBreak1MeasCurRecCh09, cmbBreak1MeasCurRecCh10, cmbBreak1MeasCurRecCh11 };
            breaker2MeasCurRec = new ComboBox[] { cmbBreak2MeasCurRecCh00, cmbBreak2MeasCurRecCh01, cmbBreak2MeasCurRecCh02, cmbBreak2MeasCurRecCh03, cmbBreak2MeasCurRecCh04, cmbBreak2MeasCurRecCh05, cmbBreak2MeasCurRecCh06, cmbBreak2MeasCurRecCh07, cmbBreak2MeasCurRecCh08, cmbBreak2MeasCurRecCh09, cmbBreak2MeasCurRecCh10, cmbBreak2MeasCurRecCh11 };
            breaker3MeasCurRec = new ComboBox[] { cmbBreak3MeasCurRecCh00, cmbBreak3MeasCurRecCh01, cmbBreak3MeasCurRecCh02, cmbBreak3MeasCurRecCh03, cmbBreak3MeasCurRecCh04, cmbBreak3MeasCurRecCh05, cmbBreak3MeasCurRecCh06, cmbBreak3MeasCurRecCh07, cmbBreak3MeasCurRecCh08, cmbBreak3MeasCurRecCh09, cmbBreak3MeasCurRecCh10, cmbBreak3MeasCurRecCh11 };
            breaker4MeasCurRec = new ComboBox[] { cmbBreak4MeasCurRecCh00, cmbBreak4MeasCurRecCh01, cmbBreak4MeasCurRecCh02, cmbBreak4MeasCurRecCh03, cmbBreak4MeasCurRecCh04, cmbBreak4MeasCurRecCh05, cmbBreak4MeasCurRecCh06, cmbBreak4MeasCurRecCh07, cmbBreak4MeasCurRecCh08, cmbBreak4MeasCurRecCh09, cmbBreak4MeasCurRecCh10, cmbBreak4MeasCurRecCh11 };
            breakerMeasCurRecs = new ComboBox[][] { breaker1MeasCurRec, breaker2MeasCurRec, breaker3MeasCurRec, breaker4MeasCurRec };
            breaker1Mode = new ComboBox[] { cmbBreak1ModeCh00, cmbBreak1ModeCh01, cmbBreak1ModeCh02, cmbBreak1ModeCh03, cmbBreak1ModeCh04, cmbBreak1ModeCh05, cmbBreak1ModeCh06, cmbBreak1ModeCh07, cmbBreak1ModeCh08, cmbBreak1ModeCh09, cmbBreak1ModeCh10, cmbBreak1ModeCh11 };
            breaker2Mode = new ComboBox[] { cmbBreak2ModeCh00, cmbBreak2ModeCh01, cmbBreak2ModeCh02, cmbBreak2ModeCh03, cmbBreak2ModeCh04, cmbBreak2ModeCh05, cmbBreak2ModeCh06, cmbBreak2ModeCh07, cmbBreak2ModeCh08, cmbBreak2ModeCh09, cmbBreak2ModeCh10, cmbBreak2ModeCh11 };
            breaker3Mode = new ComboBox[] { cmbBreak3ModeCh00, cmbBreak3ModeCh01, cmbBreak3ModeCh02, cmbBreak3ModeCh03, cmbBreak3ModeCh04, cmbBreak3ModeCh05, cmbBreak3ModeCh06, cmbBreak3ModeCh07, cmbBreak3ModeCh08, cmbBreak3ModeCh09, cmbBreak3ModeCh10, cmbBreak3ModeCh11 };
            breaker4Mode = new ComboBox[] { cmbBreak4ModeCh00, cmbBreak4ModeCh01, cmbBreak4ModeCh02, cmbBreak4ModeCh03, cmbBreak4ModeCh04, cmbBreak4ModeCh05, cmbBreak4ModeCh06, cmbBreak4ModeCh07, cmbBreak4ModeCh08, cmbBreak4ModeCh09, cmbBreak4ModeCh10, cmbBreak4ModeCh11 };
            breakerModes = new ComboBox[][] { breaker1Mode, breaker2Mode, breaker3Mode, breaker4Mode };
            breaker1Paired = new ComboBox[] { cmbBreak1PairedCh00, cmbBreak1PairedCh01, cmbBreak1PairedCh02, cmbBreak1PairedCh03, cmbBreak1PairedCh04, cmbBreak1PairedCh05, cmbBreak1PairedCh06, cmbBreak1PairedCh07, cmbBreak1PairedCh08, cmbBreak1PairedCh09, cmbBreak1PairedCh10, cmbBreak1PairedCh11 };
            breaker2Paired = new ComboBox[] { cmbBreak2PairedCh00, cmbBreak2PairedCh01, cmbBreak2PairedCh02, cmbBreak2PairedCh03, cmbBreak2PairedCh04, cmbBreak2PairedCh05, cmbBreak2PairedCh06, cmbBreak2PairedCh07, cmbBreak2PairedCh08, cmbBreak2PairedCh09, cmbBreak2PairedCh10, cmbBreak2PairedCh11 };
            breaker3Paired = new ComboBox[] { cmbBreak3PairedCh00, cmbBreak3PairedCh01, cmbBreak3PairedCh02, cmbBreak3PairedCh03, cmbBreak3PairedCh04, cmbBreak3PairedCh05, cmbBreak3PairedCh06, cmbBreak3PairedCh07, cmbBreak3PairedCh08, cmbBreak3PairedCh09, cmbBreak3PairedCh10, cmbBreak3PairedCh11 };
            breaker4Paired = new ComboBox[] { cmbBreak4PairedCh00, cmbBreak4PairedCh01, cmbBreak4PairedCh02, cmbBreak4PairedCh03, cmbBreak4PairedCh04, cmbBreak4PairedCh05, cmbBreak4PairedCh06, cmbBreak4PairedCh07, cmbBreak4PairedCh08, cmbBreak4PairedCh09, cmbBreak4PairedCh10, cmbBreak4PairedCh11 };
            breakerPairedTimes = new ComboBox[][] { breaker1Paired, breaker2Paired, breaker3Paired, breaker4Paired };
            breaker1IGN = new ComboBox[] { cmbBreak1IGNCh00, cmbBreak1IGNCh01, cmbBreak1IGNCh02, cmbBreak1IGNCh03, cmbBreak1IGNCh04, cmbBreak1IGNCh05, cmbBreak1IGNCh06, cmbBreak1IGNCh07, cmbBreak1IGNCh08, cmbBreak1IGNCh09, cmbBreak1IGNCh10, cmbBreak1IGNCh11 }; 
            breaker2IGN = new ComboBox[] { cmbBreak2IGNCh00, cmbBreak2IGNCh01, cmbBreak2IGNCh02, cmbBreak2IGNCh03, cmbBreak2IGNCh04, cmbBreak2IGNCh05, cmbBreak2IGNCh06, cmbBreak2IGNCh07, cmbBreak2IGNCh08, cmbBreak2IGNCh09, cmbBreak2IGNCh10, cmbBreak2IGNCh11 };
            breaker3IGN = new ComboBox [] { cmbBreak3IGNCh00, cmbBreak3IGNCh01, cmbBreak3IGNCh02, cmbBreak3IGNCh03, cmbBreak3IGNCh04, cmbBreak3IGNCh05, cmbBreak3IGNCh06, cmbBreak3IGNCh07, cmbBreak3IGNCh08, cmbBreak3IGNCh09, cmbBreak3IGNCh10, cmbBreak3IGNCh11 };
            breaker4IGN = new ComboBox[] { cmbBreak4IGNCh00, cmbBreak4IGNCh01, cmbBreak4IGNCh02, cmbBreak4IGNCh03, cmbBreak4IGNCh04, cmbBreak4IGNCh05, cmbBreak4IGNCh06, cmbBreak4IGNCh07, cmbBreak4IGNCh08, cmbBreak4IGNCh09, cmbBreak4IGNCh10, cmbBreak4IGNCh11 };
            breakerIGNs = new ComboBox[][] { breaker1IGN, breaker2IGN, breaker3IGN, breaker4IGN };
            breaker1Park = new ComboBox[] { cmbBreak1ParkCh00, cmbBreak1ParkCh01,  cmbBreak1ParkCh02, cmbBreak1ParkCh03, cmbBreak1ParkCh04, cmbBreak1ParkCh05, cmbBreak1ParkCh06, cmbBreak1ParkCh07, cmbBreak1ParkCh08, cmbBreak1ParkCh09, cmbBreak1ParkCh10, cmbBreak1ParkCh11 };
            breaker2Park = new ComboBox[] { cmbBreak2ParkCh00, cmbBreak2ParkCh01, cmbBreak2ParkCh02, cmbBreak2ParkCh03, cmbBreak2ParkCh04, cmbBreak2ParkCh05, cmbBreak2ParkCh06, cmbBreak2ParkCh07, cmbBreak2ParkCh08, cmbBreak2ParkCh09, cmbBreak2ParkCh10, cmbBreak2ParkCh11 };
            breaker3Park = new ComboBox[] { cmbBreak3ParkCh00, cmbBreak3ParkCh01, cmbBreak3ParkCh02, cmbBreak3ParkCh03, cmbBreak3ParkCh04, cmbBreak3ParkCh05, cmbBreak3ParkCh06, cmbBreak3ParkCh07, cmbBreak3ParkCh08, cmbBreak3ParkCh09, cmbBreak3ParkCh10, cmbBreak3ParkCh11 };
            breaker4Park = new ComboBox [] { cmbBreak4ParkCh00, cmbBreak4ParkCh01, cmbBreak4ParkCh02, cmbBreak4ParkCh03, cmbBreak3ParkCh04, cmbBreak4ParkCh05, cmbBreak4ParkCh06, cmbBreak4ParkCh07, cmbBreak4ParkCh08, cmbBreak4ParkCh09, cmbBreak4ParkCh10, cmbBreak4ParkCh11 };
            breakerParks = new ComboBox[][] { breaker1Park, breaker2Park, breaker3Park, breaker4Park };

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
            Dimmer1Lock = new CheckBox[] { chkDimmer1Lock00, chkDimmer1Lock01, chkDimmer1Lock02, chkDimmer1Lock03, chkDimmer1Lock04, chkDimmer1Lock05, chkDimmer1Lock06, chkDimmer1Lock07, chkDimmer1Lock08, chkDimmer1Lock09, chkDimmer1Lock10, chkDimmer1Lock11};
            Dimmer2Lock = new CheckBox[] { chkDimmer2Lock00, chkDimmer2Lock01, chkDimmer2Lock02, chkDimmer2Lock03, chkDimmer2Lock04, chkDimmer2Lock05, chkDimmer2Lock06, chkDimmer2Lock07, chkDimmer2Lock08, chkDimmer2Lock09, chkDimmer2Lock10, chkDimmer2Lock11};
            Dimmer3Lock = new CheckBox[] { chkDimmer3Lock00, chkDimmer3Lock01, chkDimmer3Lock02, chkDimmer3Lock03, chkDimmer3Lock04, chkDimmer3Lock05, chkDimmer3Lock06, chkDimmer3Lock07, chkDimmer3Lock08, chkDimmer3Lock09, chkDimmer3Lock10, chkDimmer3Lock11}; 
            Dimmer4Lock = new CheckBox[] { chkDimmer4Lock00, chkDimmer4Lock01, chkDimmer4Lock02, chkDimmer4Lock03, chkDimmer4Lock04, chkDimmer4Lock05, chkDimmer4Lock06, chkDimmer4Lock07, chkDimmer4Lock08, chkDimmer4Lock09, chkDimmer4Lock10, chkDimmer4Lock11};
            Dimmer5Lock = new CheckBox[] { chkDimmer5Lock00, chkDimmer5Lock01, chkDimmer5Lock02, chkDimmer5Lock03, chkDimmer5Lock04, chkDimmer5Lock05, chkDimmer5Lock06, chkDimmer5Lock07, chkDimmer5Lock08, chkDimmer5Lock09, chkDimmer5Lock10, chkDimmer5Lock11};
            Dimmer6Lock = new CheckBox[] { chkDimmer6Lock00, chkDimmer6Lock01, chkDimmer6Lock02, chkDimmer6Lock03, chkDimmer6Lock04, chkDimmer6Lock05, chkDimmer6Lock06, chkDimmer6Lock07, chkDimmer6Lock08, chkDimmer6Lock09, chkDimmer6Lock10, checkBox198 };
            dimmerLocks = new CheckBox[][] { Dimmer1Lock, Dimmer2Lock, Dimmer3Lock, Dimmer4Lock, Dimmer5Lock, Dimmer6Lock };
            Dimmer1PWMFreq = new ComboBox[] { cmbDimmer1PWMFreqCh00, cmbDimmer1PWMFreqCh01, cmbDimmer1PWMFreqCh02, cmbDimmer1PWMFreqCh03, cmbDimmer1PWMFreqCh04, cmbDimmer1PWMFreqCh04, cmbDimmer1PWMFreqCh05, cmbDimmer1PWMFreqCh06, cmbDimmer1PWMFreqCh07, cmbDimmer1PWMFreqCh08, cmbDimmer1PWMFreqCh09, cmbDimmer1PWMFreqCh10, cmbDimmer1PWMFreqCh11 };
            Dimmer2PWMFreq = new ComboBox[] { cmbDimmer2PWMFreqCh00, cmbDimmer2PWMFreqCh01, cmbDimmer2PWMFreqCh02, cmbDimmer2PWMFreqCh03, cmbDimmer2PWMFreqCh04, cmbDimmer2PWMFreqCh05, cmbDimmer2PWMFreqCh06, cmbDimmer2PWMFreqCh07, cmbDimmer2PWMFreqCh08, cmbDimmer2PWMFreqCh09, cmbDimmer2PWMFreqCh10, cmbDimmer2PWMFreqCh11 };
            Dimmer3PWMFreq = new ComboBox[] { cmbDimmer3PWMFreqCh00, cmbDimmer3PWMFreqCh01, cmbDimmer3PWMFreqCh02, cmbDimmer3PWMFreqCh03, cmbDimmer3PWMFreqCh04, cmbDimmer3PWMFreqCh05, cmbDimmer3PWMFreqCh06, cmbDimmer3PWMFreqCh07, cmbDimmer3PWMFreqCh08, cmbDimmer3PWMFreqCh09, cmbDimmer3PWMFreqCh10, cmbDimmer3PWMFreqCh11 };
            Dimmer4PWMFreq = new ComboBox[] { cmbDimmer4PWMFreqCh00, cmbDimmer4PWMFreqCh01, cmbDimmer4PWMFreqCh02, cmbDimmer4PWMFreqCh03, cmbDimmer4PWMFreqCh04, cmbDimmer4PWMFreqCh05, cmbDimmer4PWMFreqCh06, cmbDimmer4PWMFreqCh07, cmbDimmer4PWMFreqCh08, cmbDimmer4PWMFreqCh09, cmbDimmer4PWMFreqCh10, cmbDimmer4PWMFreqCh11 };
            Dimmer5PWMFreq = new ComboBox[] { cmbDimmer5PWMFreqCh00, cmbDimmer5PWMFreqCh01, cmbDimmer5PWMFreqCh02, cmbDimmer5PWMFreqCh03, cmbDimmer5PWMFreqCh04, cmbDimmer5PWMFreqCh05, cmbDimmer5PWMFreqCh06, cmbDimmer5PWMFreqCh07, cmbDimmer5PWMFreqCh08, cmbDimmer5PWMFreqCh09, cmbDimmer5PWMFreqCh10, cmbDimmer5PWMFreqCh11 };
            Dimmer6PWMFreq = new ComboBox[] { cmbDimmer6PWMFreqCh00, cmbDimmer6PWMFreqCh01, cmbDimmer6PWMFreqCh02, cmbDimmer6PWMFreqCh03, cmbDimmer6PWMFreqCh04, cmbDimmer6PWMFreqCh05, cmbDimmer6PWMFreqCh06, cmbDimmer6PWMFreqCh07, cmbDimmer6PWMFreqCh08, cmbDimmer6PWMFreqCh09, cmbDimmer6PWMFreqCh10, cmbDimmer6PWMFreqCh11 };
            dimmerPWMFreq = new ComboBox[][] { Dimmer1PWMFreq, Dimmer2PWMFreq, Dimmer3PWMFreq, Dimmer4PWMFreq, Dimmer4PWMFreq, Dimmer5PWMFreq, Dimmer6PWMFreq };
            Dimmer1PWMDuty = new TextBox[] { txtbDimmer1PWMDutyCh00, txtbDimmer1PWMDutyCh01, txtbDimmer1PWMDutyCh02, txtbDimmer1PWMDutyCh03, txtbDimmer1PWMDutyCh04, txtbDimmer1PWMDutyCh05, txtbDimmer1PWMDutyCh06, txtbDimmer1PWMDutyCh07, txtbDimmer1PWMDutyCh08, txtbDimmer1PWMDutyCh09, txtbDimmer1PWMDutyCh10, txtbDimmer1PWMDutyCh11 };
            Dimmer2PWMDuty = new TextBox[] { txtbDimmer2PWMDutyCh00, txtbDimmer2PWMDutyCh01, txtbDimmer2PWMDutyCh02, txtbDimmer2PWMDutyCh03, txtbDimmer2PWMDutyCh04, txtbDimmer2PWMDutyCh05, txtbDimmer2PWMDutyCh06, txtbDimmer2PWMDutyCh07, txtbDimmer2PWMDutyCh08, txtbDimmer2PWMDutyCh09, txtbDimmer2PWMDutyCh10, txtbDimmer2PWMDutyCh11 };
            Dimmer3PWMDuty = new TextBox[] { txtbDimmer3PWMDutyCh00, txtbDimmer3PWMDutyCh01, txtbDimmer3PWMDutyCh02, txtbDimmer3PWMDutyCh03, txtbDimmer3PWMDutyCh04, txtbDimmer3PWMDutyCh05, txtbDimmer3PWMDutyCh06, txtbDimmer3PWMDutyCh07, txtbDimmer3PWMDutyCh08, txtbDimmer3PWMDutyCh09, txtbDimmer3PWMDutyCh10, txtbDimmer3PWMDutyCh11 };
            Dimmer4PWMDuty = new TextBox[] { txtbDimmer4PWMDutyCh00, txtbDimmer4PWMDutyCh01, txtbDimmer4PWMDutyCh02, txtbDimmer4PWMDutyCh03, txtbDimmer4PWMDutyCh04, txtbDimmer4PWMDutyCh05, txtbDimmer4PWMDutyCh06, txtbDimmer4PWMDutyCh07, txtbDimmer4PWMDutyCh08, txtbDimmer4PWMDutyCh09, txtbDimmer4PWMDutyCh10, txtbDimmer4PWMDutyCh11 };
            Dimmer5PWMDuty = new TextBox[] { txtbDimmer5PWMDutyCh00, txtbDimmer5PWMDutyCh01, txtbDimmer5PWMDutyCh02, txtbDimmer5PWMDutyCh03, txtbDimmer5PWMDutyCh04, txtbDimmer5PWMDutyCh05, txtbDimmer5PWMDutyCh06, txtbDimmer5PWMDutyCh07, txtbDimmer5PWMDutyCh08, txtbDimmer5PWMDutyCh09, txtbDimmer5PWMDutyCh10, txtbDimmer5PWMDutyCh11 };
            Dimmer6PWMDuty = new TextBox[] { txtbDimmer6PWMDutyCh00, txtbDimmer6PWMDutyCh01, txtbDimmer6PWMDutyCh02, txtbDimmer6PWMDutyCh03, txtbDimmer6PWMDutyCh04, txtbDimmer6PWMDutyCh05, txtbDimmer6PWMDutyCh06, txtbDimmer6PWMDutyCh07, txtbDimmer6PWMDutyCh08, txtbDimmer6PWMDutyCh09, txtbDimmer6PWMDutyCh10, txtbDimmer6PWMDutyCh11 };
            dimmerPWMDuties = new TextBox[][] { Dimmer1PWMDuty, Dimmer2PWMDuty, Dimmer3PWMDuty, Dimmer4PWMDuty, Dimmer5PWMDuty, Dimmer6PWMDuty };
            Dimmer1PWMEnable = new CheckBox[] { chkDimmer1PWMEnableCh00, chkDimmer1PWMEnableCh01, chkDimmer1PWMEnableCh02, chkDimmer1PWMEnableCh03, chkDimmer1PWMEnableCh04, chkDimmer1PWMEnableCh05, chkDimmer1PWMEnableCh06, chkDimmer1PWMEnableCh07, chkDimmer1PWMEnableCh08, chkDimmer1PWMEnableCh09, chkDimmer1PWMEnableCh10, chkDimmer1PWMEnableCh11 };
            Dimmer2PWMEnable = new CheckBox[] { chkDimmer2PWMEnableCh00, chkDimmer2PWMEnableCh01, chkDimmer2PWMEnableCh02, chkDimmer2PWMEnableCh03, chkDimmer2PWMEnableCh04, chkDimmer2PWMEnableCh05, chkDimmer2PWMEnableCh06, chkDimmer2PWMEnableCh07, chkDimmer2PWMEnableCh08, chkDimmer2PWMEnableCh09, chkDimmer2PWMEnableCh10, chkDimmer2PWMEnableCh11 };
            Dimmer3PWMEnable = new CheckBox[] { chkDimmer3PWMEnableCh00, chkDimmer3PWMEnableCh01, chkDimmer3PWMEnableCh02, chkDimmer3PWMEnableCh03, chkDimmer3PWMEnableCh04, chkDimmer3PWMEnableCh05, chkDimmer3PWMEnableCh06, chkDimmer3PWMEnableCh07, chkDimmer3PWMEnableCh08, chkDimmer3PWMEnableCh09, chkDimmer3PWMEnableCh10, chkDimmer3PWMEnableCh11 };
            Dimmer4PWMEnable = new CheckBox[] { chkDimmer4PWMEnableCh00, chkDimmer4PWMEnableCh01, chkDimmer4PWMEnableCh02, chkDimmer4PWMEnableCh03, chkDimmer4PWMEnableCh04, chkDimmer4PWMEnableCh05, chkDimmer4PWMEnableCh06, chkDimmer4PWMEnableCh07, chkDimmer4PWMEnableCh08, chkDimmer4PWMEnableCh09, chkDimmer4PWMEnableCh10, chkDimmer4PWMEnableCh11 };
            Dimmer5PWMEnable = new CheckBox[] { chkDimmer5PWMEnableCh00, chkDimmer5PWMEnableCh01, chkDimmer5PWMEnableCh02, chkDimmer5PWMEnableCh03, chkDimmer5PWMEnableCh04, chkDimmer5PWMEnableCh05, chkDimmer5PWMEnableCh06, chkDimmer5PWMEnableCh07, chkDimmer5PWMEnableCh08, chkDimmer5PWMEnableCh09, chkDimmer5PWMEnableCh10, chkDimmer5PWMEnableCh11 };
            Dimmer6PWMEnable = new CheckBox[] { chkDimmer6PWMEnableCh00, chkDimmer6PWMEnableCh01, chkDimmer6PWMEnableCh02, chkDimmer6PWMEnableCh03, chkDimmer6PWMEnableCh04, chkDimmer6PWMEnableCh05, chkDimmer6PWMEnableCh06, chkDimmer6PWMEnableCh07, chkDimmer6PWMEnableCh08, chkDimmer6PWMEnableCh09, chkDimmer6PWMEnableCh10, chkDimmer6PWMEnableCh11 };
            dimmerPWMEnables = new CheckBox[][] { Dimmer1PWMEnable, Dimmer2PWMEnable, Dimmer3PWMEnable, Dimmer4PWMEnable, Dimmer5PWMEnable, Dimmer6PWMEnable };
            Dimmer1Override = new CheckBox[] { chkDimmer1OverrideCh00, chkDimmer1OverrideCh01, chkDimmer1OverrideCh02, chkDimmer1OverrideCh03, chkDimmer1OverrideCh04, chkDimmer1OverrideCh05, chkDimmer1OverrideCh06, chkDimmer1OverrideCh07, chkDimmer1OverrideCh08, chkDimmer1OverrideCh09, chkDimmer1OverrideCh10, chkDimmer1OverrideCh11 };
            Dimmer2Override = new CheckBox[] { chkDimmer2OverrideCh00, chkDimmer2OverrideCh01, chkDimmer2OverrideCh02, chkDimmer2OverrideCh03, chkDimmer2OverrideCh04, chkDimmer2OverrideCh05, chkDimmer2OverrideCh06, chkDimmer2OverrideCh07, chkDimmer2OverrideCh08, chkDimmer2OverrideCh09, chkDimmer2OverrideCh10, chkDimmer2OverrideCh11 };
            Dimmer3Override = new CheckBox[] { chkDimmer3OverrideCh00, chkDimmer3OverrideCh01, chkDimmer3OverrideCh02, chkDimmer3OverrideCh03, chkDimmer3OverrideCh04, chkDimmer3OverrideCh05, chkDimmer3OverrideCh06, chkDimmer3OverrideCh07, chkDimmer3OverrideCh08, chkDimmer3OverrideCh09, chkDimmer6OverrideCh10, chkDimmer6OverrideCh11 };
            Dimmer4Override = new CheckBox[] { chkDimmer4OverrideCh00, chkDimmer4OverrideCh01, chkDimmer4OverrideCh02, chkDimmer4OverrideCh03,  chkDimmer4OverrideCh04, chkDimmer4OverrideCh05, chkDimmer4OverrideCh06, chkDimmer4OverrideCh07, chkDimmer4OverrideCh08, chkDimmer4OverrideCh09, chkDimmer4OverrideCh10, chkDimmer4OverrideCh11 };
            Dimmer5Override = new CheckBox[] { chkDimmer5OverrideCh00, chkDimmer5OverrideCh01, chkDimmer5OverrideCh02, chkDimmer5OverrideCh03, chkDimmer5OverrideCh04, chkDimmer5OverrideCh05, chkDimmer5OverrideCh06, chkDimmer5OverrideCh07, chkDimmer5OverrideCh08, chkDimmer5OverrideCh09, chkDimmer5OverrideCh10, chkDimmer5OverrideCh11 };
            Dimmer6Override = new CheckBox[] { chkDimmer6OverrideCh00, chkDimmer6OverrideCh01, chkDimmer6OverrideCh02, chkDimmer6OverrideCh03, chkDimmer6OverrideCh04, chkDimmer6OverrideCh05, chkDimmer6OverrideCh06, chkDimmer6OverrideCh07, chkDimmer6OverrideCh08, chkDimmer6OverrideCh09, chkDimmer6OverrideCh10, chkDimmer6OverrideCh11 };
            dimmerOverrides = new CheckBox[][] { Dimmer1Override, Dimmer2Override, Dimmer3Override, Dimmer4Override, Dimmer5Override, Dimmer6Override };
            Dimmer1Direction = new ComboBox[] { cmbDimmer1DirectionCh00, cmbDimmer1DirectionCh01, cmbDimmer1DirectionCh02, cmbDimmer1DirectionCh03, cmbDimmer1DirectionCh04, cmbDimmer1DirectionCh05, cmbDimmer1DirectionCh06, cmbDimmer1DirectionCh07, cmbDimmer1DirectionCh08, cmbDimmer1DirectionCh09, cmbDimmer1DirectionCh10, cmbDimmer1DirectionCh11 };
            Dimmer2Direction = new ComboBox[] { cmbDimmer2DirectionCh00, cmbDimmer2DirectionCh01, cmbDimmer2DirectionCh02, cmbDimmer2DirectionCh03, cmbDimmer2DirectionCh04, cmbDimmer2DirectionCh05, cmbDimmer2DirectionCh06, cmbDimmer2DirectionCh07, cmbDimmer2DirectionCh08, cmbDimmer2DirectionCh09, cmbDimmer2DirectionCh10, cmbDimmer2DirectionCh11 };
            Dimmer3Direction = new ComboBox[] { cmbDimmer3DirectionCh00, cmbDimmer3DirectionCh01, cmbDimmer3DirectionCh02, cmbDimmer3DirectionCh03, cmbDimmer3DirectionCh04, cmbDimmer3DirectionCh05, cmbDimmer3DirectionCh06, cmbDimmer3DirectionCh07, cmbDimmer3DirectionCh08, cmbDimmer3DirectionCh09, cmbDimmer3DirectionCh10, cmbDimmer3DirectionCh11 };
            Dimmer4Direction = new ComboBox[] { cmbDimmer4DirectionCh00, cmbDimmer4DirectionCh01, cmbDimmer4DirectionCh02, cmbDimmer4DirectionCh03, cmbDimmer4DirectionCh04, cmbDimmer4DirectionCh05, cmbDimmer4DirectionCh06, cmbDimmer4DirectionCh07, cmbDimmer4DirectionCh08, cmbDimmer4DirectionCh09, cmbDimmer4DirectionCh10, cmbDimmer4DirectionCh11 };
            Dimmer5Direction = new ComboBox[] { cmbDimmer5DirectionCh00, cmbDimmer5DirectionCh01, cmbDimmer5DirectionCh02, cmbDimmer5DirectionCh03, cmbDimmer5DirectionCh04, cmbDimmer5DirectionCh05, cmbDimmer5DirectionCh06, cmbDimmer5DirectionCh07, cmbDimmer5DirectionCh08, cmbDimmer5DirectionCh09, cmbDimmer5DirectionCh10, cmbDimmer5DirectionCh11 };
            Dimmer6Direction = new ComboBox[] { cmbDimmer6DirectionCh00, cmbDimmer6DirectionCh01, cmbDimmer6DirectionCh02, cmbDimmer6DirectionCh03, cmbDimmer6DirectionCh04, cmbDimmer6DirectionCh05, cmbDimmer6DirectionCh06, cmbDimmer6DirectionCh07, cmbDimmer6DirectionCh08, cmbDimmer6DirectionCh09, cmbDimmer6DirectionCh10, cmbDimmer6DirectionCh11 };
            dimmerDirections = new ComboBox[][] { Dimmer1Direction, Dimmer2Direction, Dimmer3Direction, Dimmer4Direction, Dimmer5Direction, Dimmer6Direction };
            Dimmer2Timeout = new CheckBox[] { chkDimmer2TimeoutCh00, chkDimmer2TimeoutCh01, chkDimmer2TimeoutCh02, chkDimmer2TimeoutCh03, chkDimmer2TimeoutCh04, chkDimmer2TimeoutCh05, chkDimmer2TimeoutCh06, chkDimmer2TimeoutCh07, chkDimmer2TimeoutCh08, chkDimmer2TimeoutCh09, chkDimmer2TimeoutCh10, chkDimmer2TimeoutCh11 };
            Dimmer1Timeout = new CheckBox[] { chkDimmer1TimeoutCh00, chkDimmer1TimeoutCh01, chkDimmer1TimeoutCh02, chkDimmer1TimeoutCh03, chkDimmer1TimeoutCh04, chkDimmer1TimeoutCh05, chkDimmer1TimeoutCh06, chkDimmer1TimeoutCh07, chkDimmer1TimeoutCh08, chkDimmer1TimeoutCh09, chkDimmer1TimeoutCh10, chkDimmer1TimeoutCh11 };
            Dimmer3Timeout = new CheckBox[] { chkDimmer3TimeoutCh00, chkDimmer3TimeoutCh01, chkDimmer3TimeoutCh02, chkDimmer3TimeoutCh03, chkDimmer3TimeoutCh04, chkDimmer3TimeoutCh05, chkDimmer3TimeoutCh06, chkDimmer3TimeoutCh07, chkDimmer3TimeoutCh08, chkDimmer3TimeoutCh09, chkDimmer3TimeoutCh10, chkDimmer3TimeoutCh11 };
            Dimmer4Timeout = new CheckBox[] { chkDimmer4TimeoutCh00, chkDimmer4TimeoutCh01, chkDimmer4TimeoutCh02, chkDimmer4TimeoutCh03, chkDimmer4TimeoutCh04, chkDimmer4TimeoutCh05, chkDimmer4TimeoutCh06, chkDimmer4TimeoutCh07, chkDimmer4TimeoutCh08, chkDimmer4TimeoutCh09, chkDimmer4TimeoutCh10, chkDimmer4TimeoutCh11 };
            Dimmer5Timeout = new CheckBox[] { chkDimmer5TimeoutCh00, chkDimmer5TimeoutCh01, chkDimmer5TimeoutCh02, chkDimmer5TimeoutCh03, chkDimmer5TimeoutCh04, chkDimmer5TimeoutCh05, chkDimmer5TimeoutCh06, chkDimmer5TimeoutCh07, chkDimmer5TimeoutCh08, chkDimmer5TimeoutCh09, chkDimmer5TimeoutCh10, chkDimmer5TimeoutCh11 };
            Dimmer6Timeout = new CheckBox[] { chkDimmer6TimeoutCh00, chkDimmer6TimeoutCh01, chkDimmer6TimeoutCh02, chkDimmer6TimeoutCh03, chkDimmer6TimeoutCh04, chkDimmer6TimeoutCh05, chkDimmer6TimeoutCh06, chkDimmer6TimeoutCh07, chkDimmer6TimeoutCh08, chkDimmer6TimeoutCh09, chkDimmer6TimeoutCh10, chkHC1DCDimmer };
            dimmerTimeouts = new CheckBox[][] { Dimmer1Timeout, Dimmer2Timeout, Dimmer3Timeout, Dimmer4Timeout, Dimmer5Timeout, Dimmer6Timeout };
            Dimmer1TimeoutTime = new TextBox[] { txtbDimmer1TimeoutTimeCh00, txtbDimmer1TimeoutTimeCh01, txtbDimmer1TimeoutTimeCh02, txtbDimmer1TimeoutTimeCh03, txtbDimmer1TimeoutTimeCh04, txtbDimmer1TimeoutTimeCh05, txtbDimmer1TimeoutTimeCh06, txtbDimmer1TimeoutTimeCh07, txtbDimmer1TimeoutTimeCh08, txtbDimmer1TimeoutTimeCh09, txtbDimmer1TimeoutTimeCh10, txtbDimmer1TimeoutTimeCh11 };
            Dimmer2TimeoutTime = new TextBox[] { txtbDimmer2TimeoutTimeCh00, txtbDimmer2TimeoutTimeCh01, txtbDimmer2TimeoutTimeCh02, txtbDimmer2TimeoutTimeCh03, txtbDimmer2TimeoutTimeCh04, txtbDimmer2TimeoutTimeCh05, txtbDimmer2TimeoutTimeCh06, txtbDimmer2TimeoutTimeCh07, txtbDimmer2TimeoutTimeCh08, txtbDimmer2TimeoutTimeCh09, txtbDimmer2TimeoutTimeCh10, txtbDimmer2TimeoutTimeCh11 };
            Dimmer3TimeoutTime = new TextBox[] { txtbDimmer3TimeoutTimeCh00, txtbDimmer3TimeoutTimeCh01, txtbDimmer3TimeoutTimeCh02, txtbDimmer3TimeoutTimeCh03, txtbDimmer3TimeoutTimeCh04, txtbDimmer3TimeoutTimeCh05, txtbDimmer3TimeoutTimeCh06, txtbDimmer3TimeoutTimeCh07, txtbDimmer3TimeoutTimeCh08, txtbDimmer3TimeoutTimeCh09, txtbDimmer3TimeoutTimeCh10, txtbDimmer3TimeoutTimeCh11 };
            Dimmer4TimeoutTime = new TextBox[] { txtbDimmer4TimeoutTimeCh00, txtbDimmer4TimeoutTimeCh01, txtbDimmer4TimeoutTimeCh02, txtbDimmer4TimeoutTimeCh03, txtbDimmer4TimeoutTimeCh04, txtbDimmer4TimeoutTimeCh05, txtbDimmer4TimeoutTimeCh06, txtbDimmer4TimeoutTimeCh07, txtbDimmer4TimeoutTimeCh08, txtbDimmer4TimeoutTimeCh09, txtbDimmer4TimeoutTimeCh10, txtbDimmer4TimeoutTimeCh11 };
            Dimmer5TimeoutTime = new TextBox[] { txtbDimmer5TimeoutTimeCh00, txtbDimmer5TimeoutTimeCh01, txtbDimmer5TimeoutTimeCh02, txtbDimmer5TimeoutTimeCh03, txtbDimmer5TimeoutTimeCh04, txtbDimmer5TimeoutTimeCh05, txtbDimmer5TimeoutTimeCh06, txtbDimmer5TimeoutTimeCh07, txtbDimmer5TimeoutTimeCh08, txtbDimmer5TimeoutTimeCh09, txtbDimmer5TimeoutTimeCh10, txtbDimmer5TimeoutTimeCh11 };
            Dimmer6TimeoutTime = new TextBox[] { txtbDimmer6TimeoutTimeCh00, txtbDimmer6TimeoutTimeCh01, txtbDimmer6TimeoutTimeCh02, txtbDimmer6TimeoutTimeCh03, txtbDimmer6TimeoutTimeCh04, txtbDimmer6TimeoutTimeCh05, txtbDimmer6TimeoutTimeCh06, txtbDimmer6TimeoutTimeCh07, txtbDimmer6TimeoutTimeCh08, txtbDimmer6TimeoutTimeCh09, txtbDimmer6TimeoutTimeCh10, txtbDimmer6TimeoutTimeCh11 };
            dimmerTimeoutTimes = new TextBox[][] { Dimmer1TimeoutTime, Dimmer2TimeoutTime, Dimmer3TimeoutTime, Dimmer4TimeoutTime, Dimmer5TimeoutTime, Dimmer6TimeoutTime };
            Dimmer1MaxOn = new TextBox[] { txtbDimmer1MaxOnCh00, txtbDimmer1MaxOnCh01, txtbDimmer1MaxOnCh02, txtbDimmer1MaxOnCh03, txtbDimmer1MaxOnCh04, txtbDimmer1MaxOnCh05, txtbDimmer1MaxOnCh06, txtbDimmer1MaxOnCh07, txtbDimmer1MaxOnCh08, txtbDimmer1MaxOnCh09, txtbDimmer1MaxOnCh10, txtbDimmer1MaxOnCh11 };
            Dimmer2MaxOn = new TextBox[] { txtbDimmer2MaxOnCh00, txtbDimmer2MaxOnCh01, txtbDimmer2MaxOnCh02, txtbDimmer2MaxOnCh03, txtbDimmer2MaxOnCh04, txtbDimmer2MaxOnCh05, txtbDimmer2MaxOnCh06, txtbDimmer2MaxOnCh07, txtbDimmer2MaxOnCh08, txtbDimmer2MaxOnCh09, txtbDimmer2MaxOnCh10, txtbDimmer2MaxOnCh11 };
            Dimmer3MaxOn = new TextBox[] { txtbDimmer3MaxOnCh00, txtbDimmer3MaxOnCh01, txtbDimmer3MaxOnCh02, txtbDimmer3MaxOnCh03, txtbDimmer3MaxOnCh04, txtbDimmer3MaxOnCh05, txtbDimmer3MaxOnCh06, txtbDimmer3MaxOnCh07, txtbDimmer3MaxOnCh08, txtbDimmer3MaxOnCh09, txtbDimmer3MaxOnCh10, txtbDimmer3MaxOnCh11 };
            Dimmer4MaxOn = new TextBox[] { txtbDimmer4MaxOnCh00, txtbDimmer4MaxOnCh01, txtbDimmer4MaxOnCh02, txtbDimmer4MaxOnCh03, txtbDimmer4MaxOnCh04, txtbDimmer4MaxOnCh05, txtbDimmer4MaxOnCh06, txtbDimmer4MaxOnCh07, txtbDimmer4MaxOnCh08, txtbDimmer4MaxOnCh09, txtbDimmer4MaxOnCh10, txtbDimmer4MaxOnCh11 };
            Dimmer5MaxOn = new TextBox[] { txtbDimmer5MaxOnCh00, txtbDimmer5MaxOnCh01, txtbDimmer5MaxOnCh02, txtbDimmer5MaxOnCh03, txtbDimmer5MaxOnCh04, txtbDimmer5MaxOnCh05, txtbDimmer5MaxOnCh06, txtbDimmer5MaxOnCh07, txtbDimmer5MaxOnCh08, txtbDimmer5MaxOnCh09, txtbDimmer5MaxOnCh10, txtbDimmer5MaxOnCh11 };
            Dimmer6MaxOn = new TextBox[] { txtbDimmer6MaxOnCh00, txtbDimmer6MaxOnCh01, txtbDimmer6MaxOnCh02, txtbDimmer6MaxOnCh03, txtbDimmer6MaxOnCh04, txtbDimmer6MaxOnCh05, txtbDimmer6MaxOnCh06, txtbDimmer6MaxOnCh07, txtbDimmer6MaxOnCh08, txtbDimmer6MaxOnCh09, txtbDimmer6MaxOnCh10, txtbDimmer6MaxOnCh11 };
            dimmerMaxOns = new TextBox[][] { Dimmer1MaxOn, Dimmer2MaxOn, Dimmer3MaxOn, Dimmer4MaxOn, Dimmer5MaxOn, Dimmer6MaxOn };
            Dimmer1MaxDurRec = new TextBox[] { txtbDimmer1MaxDurRecCh00, txtbDimmer1MaxDurRecCh01, txtbDimmer1MaxDurRecCh02, txtbDimmer1MaxDurRecCh03, txtbDimmer1MaxDurRecCh04, txtbDimmer1MaxDurRecCh05, txtbDimmer1MaxDurRecCh06, txtbDimmer1MaxDurRecCh07, txtbDimmer1MaxDurRecCh08, txtbDimmer1MaxDurRecCh09, txtbDimmer1MaxDurRecCh10, txtbDimmer1MaxDurRecCh11 };
            Dimmer2MaxDurRec = new TextBox[] { txtbDimmer2MaxDurRecCh00, txtbDimmer2MaxDurRecCh01, txtbDimmer2MaxDurRecCh02, txtbDimmer2MaxDurRecCh03, txtbDimmer2MaxDurRecCh04, txtbDimmer2MaxDurRecCh05, txtbDimmer2MaxDurRecCh06, txtbDimmer2MaxDurRecCh07, txtbDimmer2MaxDurRecCh08, txtbDimmer2MaxDurRecCh09, txtbDimmer2MaxDurRecCh10, txtbDimmer2MaxDurRecCh11 };
            Dimmer3MaxDurRec = new TextBox[] { txtbDimmer3MaxDurRecCh00, txtbDimmer3MaxDurRecCh01, txtbDimmer3MaxDurRecCh02, txtbDimmer3MaxDurRecCh03, txtbDimmer3MaxDurRecCh04, txtbDimmer3MaxDurRecCh05, txtbDimmer3MaxDurRecCh06, txtbDimmer3MaxDurRecCh07, txtbDimmer3MaxDurRecCh08, txtbDimmer3MaxDurRecCh09, txtbDimmer3MaxDurRecCh10, txtbDimmer3MaxDurRecCh11 };
            Dimmer4MaxDurRec = new TextBox[] { txtbDimmer4MaxDurRecCh00, txtbDimmer4MaxDurRecCh01, txtbDimmer4MaxDurRecCh02, txtbDimmer4MaxDurRecCh03, txtbDimmer4MaxDurRecCh04, txtbDimmer4MaxDurRecCh05, txtbDimmer4MaxDurRecCh06, txtbDimmer4MaxDurRecCh07, txtbDimmer4MaxDurRecCh08, txtbDimmer4MaxDurRecCh09, txtbDimmer4MaxDurRecCh10, txtbDimmer4MaxDurRecCh11 };
            Dimmer5MaxDurRec = new TextBox[] { txtbDimmer5MaxDurRecCh00, txtbDimmer5MaxDurRecCh01, txtbDimmer5MaxDurRecCh02, txtbDimmer5MaxDurRecCh03, txtbDimmer5MaxDurRecCh04, txtbDimmer5MaxDurRecCh05, txtbDimmer5MaxDurRecCh06, txtbDimmer5MaxDurRecCh07, txtbDimmer5MaxDurRecCh08, txtbDimmer5MaxDurRecCh09, txtbDimmer5MaxDurRecCh10, txtbDimmer5MaxDurRecCh11 };
            Dimmer6MaxDurRec = new TextBox[] { txtbDimmer6MaxDurRecCh00, txtbDimmer6MaxDurRecCh01, txtbDimmer6MaxDurRecCh02, txtbDimmer6MaxDurRecCh03, txtbDimmer6MaxDurRecCh04, txtbDimmer6MaxDurRecCh05, txtbDimmer6MaxDurRecCh06, txtbDimmer6MaxDurRecCh07, txtbDimmer6MaxDurRecCh08, txtbDimmer6MaxDurRecCh09, txtbDimmer6MaxDurRecCh10, txtbDimmer6MaxDurRecCh11 };
            dimmerMaxDurRecs = new TextBox[][] { Dimmer1MaxDurRec, Dimmer2MaxDurRec, Dimmer3MaxDurRec, Dimmer4MaxDurRec, Dimmer5MaxDurRec, Dimmer6MaxDurRec };
            Dimmer1UCAmps = new TextBox[] { txtbDimmer1UCAmpsCh00, txtbDimmer1UCAmpsCh01, txtbDimmer1UCAmpsCh02, txtbDimmer1UCAmpsCh03, txtbDimmer1UCAmpsCh04, txtbDimmer1UCAmpsCh05, txtbDimmer1UCAmpsCh06, txtbDimmer1UCAmpsCh07, txtbDimmer1UCAmpsCh08, txtbDimmer1UCAmpsCh09, txtbDimmer1UCAmpsCh10, txtbDimmer1UCAmpsCh11 };
            Dimmer2UCAmps = new TextBox[] { txtbDimmer2UCAmpsCh00, txtbDimmer2UCAmpsCh01, txtbDimmer2UCAmpsCh02, txtbDimmer2UCAmpsCh03, txtbDimmer2UCAmpsCh04, txtbDimmer2UCAmpsCh05, txtbDimmer2UCAmpsCh06, txtbDimmer2UCAmpsCh07, txtbDimmer2UCAmpsCh08, txtbDimmer2UCAmpsCh09, txtbDimmer2UCAmpsCh10, txtbDimmer2UCAmpsCh11 };
            Dimmer3UCAmps = new TextBox[] { txtbDimmer3UCAmpsCh00, txtbDimmer3UCAmpsCh01, txtbDimmer3UCAmpsCh02, txtbDimmer3UCAmpsCh03, txtbDimmer3UCAmpsCh04, txtbDimmer3UCAmpsCh05, txtbDimmer3UCAmpsCh06, txtbDimmer3UCAmpsCh07, txtbDimmer3UCAmpsCh08, txtbDimmer3UCAmpsCh09, txtbDimmer3UCAmpsCh10, txtbDimmer3UCAmpsCh11 };
            Dimmer4UCAmps = new TextBox[] { txtbDimmer4UCAmpsCh00, txtbDimmer4UCAmpsCh01, txtbDimmer4UCAmpsCh02, txtbDimmer4UCAmpsCh03, txtbDimmer4UCAmpsCh04, txtbDimmer4UCAmpsCh05, txtbDimmer4UCAmpsCh06, txtbDimmer4UCAmpsCh07, txtbDimmer4UCAmpsCh08, txtbDimmer4UCAmpsCh09, txtbDimmer4UCAmpsCh10, txtbDimmer4UCAmpsCh11 };
            Dimmer5UCAmps = new TextBox[] { txtbDimmer5UCAmpsCh00, txtbDimmer5UCAmpsCh01, txtbDimmer5UCAmpsCh02, txtbDimmer5UCAmpsCh03, txtbDimmer5UCAmpsCh04, txtbDimmer5UCAmpsCh05, txtbDimmer5UCAmpsCh06, txtbDimmer5UCAmpsCh07, txtbDimmer5UCAmpsCh08, txtbDimmer5UCAmpsCh09, txtbDimmer5UCAmpsCh10, txtbDimmer5UCAmpsCh11 };
            Dimmer6UCAmps = new TextBox[] { txtbDimmer6UCAmpsCh00, txtbDimmer6UCAmpsCh01, txtbDimmer6UCAmpsCh02, txtbDimmer6UCAmpsCh03, txtbDimmer6UCAmpsCh04, txtbDimmer6UCAmpsCh05, txtbDimmer6UCAmpsCh06, txtbDimmer6UCAmpsCh07, txtbDimmer6UCAmpsCh08, txtbDimmer6UCAmpsCh09, txtbDimmer6UCAmpsCh10, txtbDimmer6UCAmpsCh11 };
            dimmerUCAmps = new TextBox[][] { Dimmer1UCAmps, Dimmer2UCAmps, Dimmer3UCAmps, Dimmer4UCAmps, Dimmer5UCAmps, Dimmer6UCAmps };
            Dimmer1MeasCurTime = new ComboBox[] { cmbDimmer1MeasCurTimeCh00, cmbDimmer1MeasCurTimeCh01, cmbDimmer1MeasCurTimeCh02, cmbDimmer1MeasCurTimeCh03, cmbDimmer1MeasCurTimeCh04, cmbDimmer1MeasCurTimeCh05, cmbDimmer1MeasCurTimeCh06, cmbDimmer1MeasCurTimeCh07, cmbDimmer1MeasCurTimeCh08, cmbDimmer1MeasCurTimeCh09, cmbDimmer1MeasCurTimeCh10, cmbDimmer1MeasCurTimeCh11 }; 
            Dimmer2MeasCurTime = new ComboBox[] { cmbDimmer2MeasCurTimeCh00, cmbDimmer2MeasCurTimeCh01,cmbDimmer2MeasCurTimeCh02, cmbDimmer2MeasCurTimeCh03, cmbDimmer2MeasCurTimeCh04, cmbDimmer2MeasCurTimeCh05, cmbDimmer2MeasCurTimeCh06, cmbDimmer2MeasCurTimeCh07, cmbDimmer2MeasCurTimeCh08, cmbDimmer2MeasCurTimeCh09, cmbDimmer2MeasCurTimeCh10, cmbDimmer2MeasCurTimeCh11 };
            Dimmer3MeasCurTime = new ComboBox[] { cmbDimmer3MeasCurTimeCh00, cmbDimmer3MeasCurTimeCh01,cmbDimmer3MeasCurTimeCh02, cmbDimmer3MeasCurTimeCh03, cmbDimmer3MeasCurTimeCh04, cmbDimmer3MeasCurTimeCh05, cmbDimmer3MeasCurTimeCh06, cmbDimmer3MeasCurTimeCh07, cmbDimmer3MeasCurTimeCh08, cmbDimmer3MeasCurTimeCh09, cmbDimmer3MeasCurTimeCh10, cmbDimmer3MeasCurTimeCh11 };
            Dimmer4MeasCurTime = new ComboBox[] { cmbDimmer4MeasCurTimeCh00, cmbDimmer4MeasCurTimeCh01,cmbDimmer4MeasCurTimeCh02, cmbDimmer4MeasCurTimeCh03, cmbDimmer4MeasCurTimeCh04, cmbDimmer4MeasCurTimeCh05, cmbDimmer4MeasCurTimeCh06, cmbDimmer4MeasCurTimeCh07, cmbDimmer4MeasCurTimeCh08, cmbDimmer4MeasCurTimeCh09, cmbDimmer4MeasCurTimeCh10, cmbDimmer4MeasCurTimeCh11 };
            Dimmer5MeasCurTime = new ComboBox[] { cmbDimmer5MeasCurTimeCh00, cmbDimmer5MeasCurTimeCh01,cmbDimmer5MeasCurTimeCh02, cmbDimmer5MeasCurTimeCh03, cmbDimmer5MeasCurTimeCh04, cmbDimmer5MeasCurTimeCh05, cmbDimmer5MeasCurTimeCh06, cmbDimmer5MeasCurTimeCh07, cmbDimmer5MeasCurTimeCh08, cmbDimmer5MeasCurTimeCh09, cmbDimmer5MeasCurTimeCh10, cmbDimmer5MeasCurTimeCh11 };
            Dimmer6MeasCurTime = new ComboBox[] { cmbDimmer6MeasCurTimeCh00, cmbDimmer6MeasCurTimeCh01,cmbDimmer6MeasCurTimeCh02, cmbDimmer6MeasCurTimeCh03, cmbDimmer6MeasCurTimeCh04, cmbDimmer6MeasCurTimeCh05, cmbDimmer6MeasCurTimeCh06, cmbDimmer6MeasCurTimeCh07, cmbDimmer6MeasCurTimeCh08, cmbDimmer6MeasCurTimeCh09, cmbDimmer6MeasCurTimeCh10, cmbDimmer6MeasCurTimeCh11 };
            dimmerMeasCurTimes = new ComboBox[][] { Dimmer1MeasCurTime, Dimmer2MeasCurTime, Dimmer3MeasCurTime, Dimmer4MeasCurTime, Dimmer5MeasCurTime, Dimmer6MeasCurTime };

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
            hc1OCAmpsQuick = new ComboBox[] { cmbHC1OCAmps00, cmbHC1OCAmps01, cmbHC1OCAmps02, cmbHC1OCAmps03, cmbHC1OCAmps04, cmbHC1OCAmps05, cmbHC1OCAmps06, cmbHC1OCAmps07, cmbHC1OCAmps08, cmbHC1OCAmps09, cmbHC1OCAmps10, cmbHC1OCAmps11 };
            hc2OCAmpsQuick = new ComboBox[] { cmbHC2OCAmps00, cmbHC2OCAmps01, cmbHC2OCAmps02, cmbHC2OCAmps03, cmbHC2OCAmps04, cmbHC2OCAmps05, cmbHC2OCAmps06, cmbHC2OCAmps07, cmbHC2OCAmps08, cmbHC2OCAmps09, cmbHC2OCAmps10, cmbHC2OCAmps11 };
            hc3OCAmpsQuick = new ComboBox[] { cmbHC3OCAmps00, cmbHC3OCAmps01, cmbHC3OCAmps02, cmbHC3OCAmps03, cmbHC3OCAmps04, cmbHC3OCAmps05, cmbHC3OCAmps06, cmbHC3OCAmps07, cmbHC3OCAmps08, cmbHC3OCAmps09, cmbHC3OCAmps10, cmbHC3OCAmps11 };
            hc4OCAmpsQuick = new ComboBox[] { cmbHC4OCAmps00, cmbHC4OCAmps01, cmbHC4OCAmps02, cmbHC4OCAmps03, cmbHC4OCAmps04, cmbHC4OCAmps05, cmbHC4OCAmps06, cmbHC4OCAmps07, cmbHC4OCAmps08, cmbHC4OCAmps09, cmbHC4OCAmps10, cmbHC4OCAmps11 };
            hc5OCAmpsQuick = new ComboBox[] { cmbHC5OCAmps00, cmbHC5OCAmps01, cmbHC5OCAmps02, cmbHC5OCAmps03, cmbHC5OCAmps04, cmbHC5OCAmps05, cmbHC5OCAmps06, cmbHC5OCAmps07, cmbHC5OCAmps08, cmbHC5OCAmps09, cmbHC5OCAmps10, cmbHC5OCAmps11 };
            hc6OCAmpsQuick = new ComboBox[] { cmbHC6OCAmps00, cmbHC6OCAmps01, cmbHC6OCAmps02, cmbHC6OCAmps03, cmbHC6OCAmps04, cmbHC6OCAmps05, cmbHC6OCAmps06, cmbHC6OCAmps07, cmbHC6OCAmps08, cmbHC6OCAmps09, cmbHC6OCAmps10, cmbHC6OCAmps11 };
            hc1OCAmps = new TextBox[] { tbxHC1OCAmpsParamCh00, tbxHC1OCAmpsParamCh01, tbxHC1OCAmpsParamCh02, tbxHC1OCAmpsParamCh03, tbxHC1OCAmpsParamCh04, tbxHC1OCAmpsParamCh05, tbxHC1OCAmpsParamCh06, tbxHC1OCAmpsParamCh07, tbxHC1OCAmpsParamCh08, tbxHC1OCAmpsParamCh09, tbxHC1OCAmpsParamCh10, tbxHC1OCAmpsParamCh11 };
            hcOCAmps = new TextBox[][] { hc1OCAmps };
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
            hc1Startup = new ComboBox[] { cmbHC1Startup00, cmbHC1Startup01, cmbHC1Startup02, cmbHC1Startup03, cmbHC1Startup04, cmbHC1Startup05, cmbHC1Startup06, cmbHC1Startup07, cmbHC1Startup08, cmbHC1Startup09, cmbHC1Startup10, cmbHC1Startup11 };
            hcStartup = new ComboBox[][] { hc1Startup };
            hc1Lock = new CheckBox[] { chkHC1Lock00, chkHC1Lock01, chkHC1Lock02, chkHC1Lock03, chkHC1Lock04, chkHC1Lock05, chkHC1Lock06, chkHC1Lock07, chkHC1Lock08, chkHC1Lock09, chkHC1Lock10, chkHC1Lock11 };
            hcLock = new CheckBox[][] { hc1Lock };
            HC1PWMDuty = new TextBox[] { txtbHC1PWMDutyCh00, txtbHC1PWMDutyCh01, txtbHC1PWMDutyCh02, txtbHC1PWMDutyCh03, txtbHC1PWMDutyCh04, txtbHC1PWMDutyCh05, txtbHC1PWMDutyCh06, txtbHC1PWMDutyCh07, txtbHC1PWMDutyCh08, txtbHC1PWMDutyCh09, txtbHC1PWMDutyCh10, txtbHC1PWMDutyCh11 };
            HC2PWMDuty = new TextBox[] { txtbHC2PWMDutyCh00, txtbHC2PWMDutyCh01, txtbHC2PWMDutyCh02, txtbHC2PWMDutyCh03, txtbHC2PWMDutyCh04, txtbHC2PWMDutyCh05, txtbHC2PWMDutyCh06, txtbHC2PWMDutyCh07, txtbHC2PWMDutyCh08, txtbHC2PWMDutyCh09, txtbHC2PWMDutyCh10, txtbHC2PWMDutyCh11 };
            HC3PWMDuty = new TextBox[] { txtbHC3PWMDutyCh00, txtbHC3PWMDutyCh01, txtbHC3PWMDutyCh02, txtbHC3PWMDutyCh03, txtbHC3PWMDutyCh04, txtbHC3PWMDutyCh05, txtbHC3PWMDutyCh06, txtbHC3PWMDutyCh07, txtbHC3PWMDutyCh08, txtbHC3PWMDutyCh09, txtbHC3PWMDutyCh10, txtbHC3PWMDutyCh11 };
            HC4PWMDuty = new TextBox[] { txtbHC4PWMDutyCh00, txtbHC4PWMDutyCh01, txtbHC4PWMDutyCh02, txtbHC4PWMDutyCh03, txtbHC4PWMDutyCh04, txtbHC4PWMDutyCh05, txtbHC4PWMDutyCh06, txtbHC4PWMDutyCh07, txtbHC4PWMDutyCh08, txtbHC4PWMDutyCh09, txtbHC4PWMDutyCh10, txtbHC4PWMDutyCh11 };
            HC5PWMDuty = new TextBox[] { txtbHC5PWMDutyCh00, txtbHC5PWMDutyCh01, txtbHC5PWMDutyCh02, txtbHC5PWMDutyCh03, txtbHC5PWMDutyCh04, txtbHC5PWMDutyCh05, txtbHC5PWMDutyCh06, txtbHC5PWMDutyCh07, txtbHC5PWMDutyCh08, txtbHC5PWMDutyCh09, txtbHC5PWMDutyCh10, txtbHC5PWMDutyCh11 };
            HC6PWMDuty = new TextBox[] { txtbHC6PWMDutyCh00, txtbHC6PWMDutyCh01, txtbHC6PWMDutyCh02, txtbHC6PWMDutyCh03, txtbHC6PWMDutyCh04, txtbHC6PWMDutyCh05, txtbHC6PWMDutyCh06, txtbHC6PWMDutyCh07, txtbHC6PWMDutyCh08, txtbHC6PWMDutyCh09, txtbHC6PWMDutyCh10, txtbHC6PWMDutyCh11 };
            hcPWMDuties = new TextBox[][] { HC1PWMDuty, HC2PWMDuty, HC3PWMDuty, HC4PWMDuty, HC5PWMDuty, HC6PWMDuty };
            HC1PWMEnable = new CheckBox[] { chkHC1PWMEnableCh00, chkHC1PWMEnableCh01, chkHC1PWMEnableCh02, chkHC1PWMEnableCh03, chkHC1PWMEnableCh04, chkHC1PWMEnableCh05, chkHC1PWMEnableCh06, chkHC1PWMEnableCh07, chkHC1PWMEnableCh08, chkHC1PWMEnableCh09, chkHC1PWMEnableCh10, chkHC1PWMEnableCh11 };
            HC2PWMEnable = new CheckBox[] { chkHC2PWMEnableCh00, chkHC2PWMEnableCh01, chkHC2PWMEnableCh02, chkHC2PWMEnableCh03, chkHC2PWMEnableCh04, chkHC2PWMEnableCh05, chkHC2PWMEnableCh06, chkHC2PWMEnableCh07, chkHC2PWMEnableCh08, chkHC2PWMEnableCh09, chkHC2PWMEnableCh10, chkHC2PWMEnableCh11 };
            HC3PWMEnable = new CheckBox[] { chkHC3PWMEnableCh00, chkHC3PWMEnableCh01, chkHC3PWMEnableCh02, chkHC3PWMEnableCh03, chkHC3PWMEnableCh04, chkHC3PWMEnableCh05, chkHC3PWMEnableCh06, chkHC3PWMEnableCh07, chkHC3PWMEnableCh08, chkHC3PWMEnableCh09, chkHC3PWMEnableCh10, chkHC3PWMEnableCh11 };
            HC4PWMEnable = new CheckBox[] { chkHC4PWMEnableCh00, chkHC4PWMEnableCh01, chkHC4PWMEnableCh02, chkHC4PWMEnableCh03, chkHC4PWMEnableCh04, chkHC4PWMEnableCh05, chkHC4PWMEnableCh06, chkHC4PWMEnableCh07, chkHC4PWMEnableCh08, chkHC4PWMEnableCh09, chkHC4PWMEnableCh10, chkHC4PWMEnableCh11 };
            HC5PWMEnable = new CheckBox[] { chkHC5PWMEnableCh00, chkHC5PWMEnableCh01, chkHC5PWMEnableCh02, chkHC5PWMEnableCh03, chkHC5PWMEnableCh04, chkHC5PWMEnableCh05, chkHC5PWMEnableCh06, chkHC5PWMEnableCh07, chkHC5PWMEnableCh08, chkHC5PWMEnableCh09, chkHC5PWMEnableCh10, chkHC5PWMEnableCh11 };
            HC6PWMEnable = new CheckBox[] { chkHC6PWMEnableCh00, chkHC6PWMEnableCh01, chkHC6PWMEnableCh02, chkHC6PWMEnableCh03, chkHC6PWMEnableCh04, chkHC6PWMEnableCh05, chkHC6PWMEnableCh06, chkHC6PWMEnableCh07, chkHC6PWMEnableCh08, chkHC6PWMEnableCh09, chkHC6PWMEnableCh10, chkHC6PWMEnableCh11 };
            hcPWMEnables = new CheckBox[][] { HC1PWMEnable, HC2PWMEnable, HC3PWMEnable, HC4PWMEnable, HC5PWMEnable, HC6PWMEnable };
            HC1Direction = new ComboBox[] { cmbHC1DirectionCh00, cmbHC1DirectionCh01, cmbHC1DirectionCh02, cmbHC1DirectionCh03, cmbHC1DirectionCh04, cmbHC1DirectionCh05, cmbHC1DirectionCh06, cmbHC1DirectionCh07, cmbHC1DirectionCh08, cmbHC1DirectionCh09, cmbHC1DirectionCh10, cmbHC1DirectionCh11 };
            HC2Direction = new ComboBox[] { cmbHC2DirectionCh00, cmbHC2DirectionCh01, cmbHC2DirectionCh02, cmbHC2DirectionCh03, cmbHC2DirectionCh04, cmbHC2DirectionCh05, cmbHC2DirectionCh06, cmbHC2DirectionCh07, cmbHC2DirectionCh08, cmbHC2DirectionCh09, cmbHC2DirectionCh10, cmbHC2DirectionCh11 };
            HC3Direction = new ComboBox[] { cmbHC3DirectionCh00, cmbHC3DirectionCh01, cmbHC3DirectionCh02, cmbHC3DirectionCh03, cmbHC3DirectionCh04, cmbHC3DirectionCh05, cmbHC3DirectionCh06, cmbHC3DirectionCh07, cmbHC3DirectionCh08, cmbHC3DirectionCh09, cmbHC3DirectionCh10, cmbHC3DirectionCh11 };
            HC4Direction = new ComboBox[] { cmbHC4DirectionCh00, cmbHC4DirectionCh01, cmbHC4DirectionCh02, cmbHC4DirectionCh03, cmbHC4DirectionCh04, cmbHC4DirectionCh05, cmbHC4DirectionCh06, cmbHC4DirectionCh07, cmbHC4DirectionCh08, cmbHC4DirectionCh09, cmbHC4DirectionCh10, cmbHC4DirectionCh11 };
            HC5Direction = new ComboBox[] { cmbHC5DirectionCh00, cmbHC5DirectionCh01, cmbHC5DirectionCh02, cmbHC5DirectionCh03, cmbHC5DirectionCh04, cmbHC5DirectionCh05, cmbHC5DirectionCh06, cmbHC5DirectionCh07, cmbHC5DirectionCh08, cmbHC5DirectionCh09, cmbHC5DirectionCh10, cmbHC5DirectionCh11 };
            HC6Direction = new ComboBox[] { cmbHC6DirectionCh00, cmbHC6DirectionCh01, cmbHC6DirectionCh02, cmbHC6DirectionCh03, cmbHC6DirectionCh04, cmbHC6DirectionCh05, cmbHC6DirectionCh06, cmbHC6DirectionCh07, cmbHC6DirectionCh08, cmbHC6DirectionCh09, cmbHC6DirectionCh10, cmbHC6DirectionCh11 };
            hcDirections = new ComboBox[][] { HC1Direction, HC2Direction, HC3Direction, HC4Direction, HC5Direction, HC6Direction };
            HC1ModeParam = new ComboBox[] { cmbHC1ModeParamCh00, cmbHC1ModeParamCh01, cmbHC1ModeParamCh02, cmbHC1ModeParamCh03, cmbHC1ModeParamCh04, cmbHC1ModeParamCh05, cmbHC1ModeParamCh06, cmbHC1ModeParamCh07, cmbHC1ModeParamCh08, cmbHC1ModeParamCh09, cmbHC1ModeParamCh10, cmbHC1ModeParamCh11 };
            hcModeParam = new ComboBox[][] { HC1ModeParam };
            HC1DeadTime = new ComboBox[] { cmbHC1DeadTimeCh00, cmbHC1DeadTimeCh01, cmbHC1DeadTimeCh02, cmbHC1DeadTimeCh03, cmbHC1DeadTimeCh04, cmbHC1DeadTimeCh05, cmbHC1DeadTimeCh06, cmbHC1DeadTimeCh07, cmbHC1DeadTimeCh08, cmbHC1DeadTimeCh09, cmbHC1DeadTimeCh10, cmbHC1DeadTimeCh11 }; 
            HC2DeadTime = new ComboBox[] { cmbHC2DeadTimeCh00, cmbHC2DeadTimeCh01, cmbHC2DeadTimeCh02, cmbHC2DeadTimeCh03, cmbHC2DeadTimeCh04, cmbHC2DeadTimeCh05, cmbHC2DeadTimeCh06, cmbHC2DeadTimeCh07, cmbHC2DeadTimeCh08, cmbHC2DeadTimeCh09, cmbHC2DeadTimeCh10, cmbHC2DeadTimeCh11 };
            HC3DeadTime = new ComboBox[] { cmbHC3DeadTimeCh00, cmbHC3DeadTimeCh01, cmbHC3DeadTimeCh02, cmbHC3DeadTimeCh03, cmbHC3DeadTimeCh04, cmbHC3DeadTimeCh05, cmbHC3DeadTimeCh06, cmbHC3DeadTimeCh07, cmbHC3DeadTimeCh08, cmbHC3DeadTimeCh09, cmbHC3DeadTimeCh10, cmbHC3DeadTimeCh11 };
            HC4DeadTime = new ComboBox[] { cmbHC4DeadTimeCh00, cmbHC4DeadTimeCh01, cmbHC4DeadTimeCh02, cmbHC4DeadTimeCh03, cmbHC4DeadTimeCh04, cmbHC4DeadTimeCh05, cmbHC4DeadTimeCh06, cmbHC4DeadTimeCh07, cmbHC4DeadTimeCh08, cmbHC4DeadTimeCh09, cmbHC4DeadTimeCh10, cmbHC4DeadTimeCh11 };
            HC5DeadTime = new ComboBox[] { cmbHC5DeadTimeCh00, cmbHC5DeadTimeCh01, cmbHC5DeadTimeCh02, cmbHC5DeadTimeCh03, cmbHC5DeadTimeCh04, cmbHC5DeadTimeCh05, cmbHC5DeadTimeCh06, cmbHC5DeadTimeCh07, cmbHC5DeadTimeCh08, cmbHC5DeadTimeCh09, cmbHC5DeadTimeCh10, cmbHC5DeadTimeCh11 };
            HC6DeadTime = new ComboBox[] { cmbHC6DeadTimeCh00, cmbHC6DeadTimeCh01, cmbHC6DeadTimeCh02, cmbHC6DeadTimeCh03, cmbHC6DeadTimeCh04, cmbHC6DeadTimeCh05, cmbHC6DeadTimeCh06, cmbHC6DeadTimeCh07, cmbHC6DeadTimeCh08, cmbHC6DeadTimeCh09, cmbHC6DeadTimeCh10, cmbHC6DeadTimeCh11 };
            hcDeadTimes = new ComboBox[][] { HC1DeadTime, HC2DeadTime, HC3DeadTime, HC4DeadTime, HC5DeadTime, HC6DeadTime };
            HC1Paired = new ComboBox[] { cmbHC1PairedCh00, cmbHC1PairedCh01, cmbHC1PairedCh02, cmbHC1PairedCh03, cmbHC1PairedCh04, cmbHC1PairedCh05, cmbHC1PairedCh06, cmbHC1PairedCh07, cmbHC1PairedCh08, cmbHC1PairedCh09, cmbHC1PairedCh10, cmbHC1PairedCh11 };
            HC2Paired = new ComboBox [] { cmbHC2PairedCh00, cmbHC2PairedCh01, cmbHC2PairedCh02, cmbHC2PairedCh03, cmbHC2PairedCh04, cmbHC2PairedCh05, cmbHC2PairedCh06, cmbHC2PairedCh07, cmbHC2PairedCh08, cmbHC2PairedCh09, cmbHC2PairedCh10, cmbHC2PairedCh11 };
            HC3Paired = new ComboBox [] { cmbHC3PairedCh00, cmbHC3PairedCh01, cmbHC3PairedCh02, cmbHC3PairedCh03, cmbHC3PairedCh04, cmbHC3PairedCh05, cmbHC3PairedCh06, cmbHC3PairedCh07, cmbHC3PairedCh08, cmbHC3PairedCh09, cmbHC3PairedCh10, cmbHC3PairedCh11 };
            HC4Paired = new ComboBox [] { cmbHC4PairedCh00, cmbHC4PairedCh01, cmbHC4PairedCh02, cmbHC4PairedCh03, cmbHC4PairedCh04, cmbHC4PairedCh05, cmbHC4PairedCh06, cmbHC4PairedCh07, cmbHC4PairedCh08, cmbHC4PairedCh09, cmbHC4PairedCh10, cmbHC4PairedCh11 };
            HC5Paired = new ComboBox [] { cmbHC5PairedCh00, cmbHC5PairedCh01, cmbHC5PairedCh02, cmbHC5PairedCh02, cmbHC5PairedCh04, cmbHC5PairedCh05, cmbHC5PairedCh06, cmbHC5PairedCh07, cmbHC5PairedCh08, cmbHC5PairedCh09, cmbHC5PairedCh10, cmbHC5PairedCh11 };
            HC6Paired = new ComboBox [] { cmbHC6PairedCh00, cmbHC6PairedCh01, cmbHC6PairedCh02, cmbHC6PairedCh03, cmbHC6PairedCh04, cmbHC6PairedCh05, cmbHC6PairedCh06, cmbHC6PairedCh07, cmbHC6PairedCh08, cmbHC6PairedCh09, cmbHC6PairedCh10, cmbHC6PairedCh11 };
            hcPaired = new ComboBox[][] { HC1Paired, HC2Paired, HC3Paired, HC4Paired, HC5Paired, HC6Paired };
            HC1Timeout = new CheckBox[] { chkHC1TimeoutCh00, chkHC1TimeoutCh01, chkHC1TimeoutCh02, chkHC1TimeoutCh03, chkHC1TimeoutCh04, chkHC1TimeoutCh05, chkHC1TimeoutCh06, chkHC1TimeoutCh07, chkHC1TimeoutCh08, chkHC1TimeoutCh09, chkHC1TimeoutCh10, chkHC1TimeoutCh11 };
            HC2Timeout = new CheckBox[] { chkHC2TimeoutCh00, chkHC2TimeoutCh02, chkHC2TimeoutCh02, chkHC2TimeoutCh03, chkHC2TimeoutCh04, chkHC2TimeoutCh05, chkHC2TimeoutCh06, chkHC2TimeoutCh07, chkHC2TimeoutCh08, chkHC2TimeoutCh09, chkHC2TimeoutCh10, chkHC2TimeoutCh11 };
            HC3Timeout = new CheckBox[] { chkHC3TimeoutCh00, chkHC3TimeoutCh02, chkHC3TimeoutCh03, chkHC3TimeoutCh03, chkHC3TimeoutCh04, chkHC3TimeoutCh05, chkHC3TimeoutCh06, chkHC3TimeoutCh07, chkHC3TimeoutCh08, chkHC3TimeoutCh09, chkHC3TimeoutCh10, chkHC3TimeoutCh11 };
            HC4Timeout = new CheckBox[] { chkHC4TimeoutCh00, chkHC4TimeoutCh02, chkHC4TimeoutCh04, chkHC4TimeoutCh03, chkHC4TimeoutCh04, chkHC4TimeoutCh05, chkHC4TimeoutCh06, chkHC4TimeoutCh07, chkHC4TimeoutCh08, chkHC4TimeoutCh09, chkHC4TimeoutCh10, chkHC4TimeoutCh11 };
            HC5Timeout = new CheckBox[] { chkHC5TimeoutCh00, chkHC5TimeoutCh02, chkHC5TimeoutCh05, chkHC5TimeoutCh03, chkHC5TimeoutCh04, chkHC5TimeoutCh05, chkHC5TimeoutCh06, chkHC5TimeoutCh07, chkHC5TimeoutCh08, chkHC5TimeoutCh09, chkHC5TimeoutCh10, chkHC5TimeoutCh11 };
            HC6Timeout = new CheckBox[] { chkHC6TimeoutCh00, chkHC6TimeoutCh02, chkHC6TimeoutCh06, chkHC6TimeoutCh03, chkHC6TimeoutCh04, chkHC6TimeoutCh05, chkHC6TimeoutCh06, chkHC6TimeoutCh07, chkHC6TimeoutCh08, chkHC6TimeoutCh09, chkHC6TimeoutCh10, chkHC6TimeoutCh11 };
            hcTimeouts = new CheckBox[][] { HC1Timeout, HC2Timeout, HC3Timeout, HC4Timeout, HC5Timeout, HC6Timeout };
            HC1TimeoutTime = new TextBox[] { txtbHC1TimeoutTimeCh00, txtbHC1TimeoutTimeCh01, txtbHC1TimeoutTimeCh02, txtbHC1TimeoutTimeCh03, txtbHC1TimeoutTimeCh04, txtbHC1TimeoutTimeCh05, txtbHC1TimeoutTimeCh06, txtbHC1TimeoutTimeCh07, txtbHC1TimeoutTimeCh08, txtbHC1TimeoutTimeCh09, txtbHC1TimeoutTimeCh10, txtbHC1TimeoutTimeCh11 };
            HC2TimeoutTime = new TextBox[] { txtbHC2TimeoutTimeCh00, txtbHC2TimeoutTimeCh01, txtbHC2TimeoutTimeCh02, txtbHC2TimeoutTimeCh03, txtbHC2TimeoutTimeCh04, txtbHC2TimeoutTimeCh05, txtbHC2TimeoutTimeCh06, txtbHC2TimeoutTimeCh07, txtbHC2TimeoutTimeCh08, txtbHC2TimeoutTimeCh09, txtbHC2TimeoutTimeCh10, txtbHC2TimeoutTimeCh11 };
            HC3TimeoutTime = new TextBox[] { txtbHC3TimeoutTimeCh00, txtbHC3TimeoutTimeCh01, txtbHC3TimeoutTimeCh02, txtbHC3TimeoutTimeCh03, txtbHC3TimeoutTimeCh04, txtbHC3TimeoutTimeCh05, txtbHC3TimeoutTimeCh06, txtbHC3TimeoutTimeCh07, txtbHC3TimeoutTimeCh08, txtbHC3TimeoutTimeCh09, txtbHC3TimeoutTimeCh10, txtbHC3TimeoutTimeCh11 };
            HC4TimeoutTime = new TextBox[] { txtbHC4TimeoutTimeCh00, txtbHC4TimeoutTimeCh01, txtbHC4TimeoutTimeCh02, txtbHC4TimeoutTimeCh03, txtbHC4TimeoutTimeCh04, txtbHC4TimeoutTimeCh05, txtbHC4TimeoutTimeCh06, txtbHC4TimeoutTimeCh07, txtbHC4TimeoutTimeCh08, txtbHC4TimeoutTimeCh09, txtbHC4TimeoutTimeCh10, txtbHC4TimeoutTimeCh11 };
            HC5TimeoutTime = new TextBox[] { txtbHC5TimeoutTimeCh00, txtbHC5TimeoutTimeCh01, txtbHC5TimeoutTimeCh02, txtbHC5TimeoutTimeCh03, txtbHC5TimeoutTimeCh04, txtbHC5TimeoutTimeCh05, txtbHC5TimeoutTimeCh06, txtbHC5TimeoutTimeCh07, txtbHC5TimeoutTimeCh08, txtbHC5TimeoutTimeCh09, txtbHC5TimeoutTimeCh10, txtbHC5TimeoutTimeCh11 };
            HC6TimeoutTime = new TextBox[] { txtbHC6TimeoutTimeCh00, txtbHC6TimeoutTimeCh01, txtbHC6TimeoutTimeCh02, txtbHC6TimeoutTimeCh03, txtbHC6TimeoutTimeCh04, txtbHC6TimeoutTimeCh05, txtbHC6TimeoutTimeCh06, txtbHC6TimeoutTimeCh07, txtbHC6TimeoutTimeCh08, txtbHC6TimeoutTimeCh09, txtbHC6TimeoutTimeCh10, txtbHC6TimeoutTimeCh11 };
            hcTimeoutTimes = new TextBox[][] { HC1TimeoutTime, HC2TimeoutTime, HC3TimeoutTime, HC4TimeoutTime, HC5TimeoutTime, HC6TimeoutTime };
            HC1MaxOn = new TextBox[] { txtbHC1MaxOnCh00, txtbHC1MaxOnCh01, txtbHC1MaxOnCh02, txtbHC1MaxOnCh03, txtbHC1MaxOnCh04, txtbHC1MaxOnCh05, txtbHC1MaxOnCh06, txtbHC1MaxOnCh07, txtbHC1MaxOnCh08, txtbHC1MaxOnCh09, txtbHC1MaxOnCh10, txtbHC1MaxOnCh11 };
            HC2MaxOn = new TextBox[] { txtbHC2MaxOnCh00, txtbHC2MaxOnCh01, txtbHC2MaxOnCh02, txtbHC2MaxOnCh03, txtbHC2MaxOnCh04, txtbHC2MaxOnCh05, txtbHC2MaxOnCh06, txtbHC2MaxOnCh07, txtbHC2MaxOnCh08, txtbHC2MaxOnCh09, txtbHC2MaxOnCh10, txtbHC2MaxOnCh11 };
            HC3MaxOn = new TextBox[] { txtbHC3MaxOnCh00, txtbHC3MaxOnCh01, txtbHC3MaxOnCh02, txtbHC3MaxOnCh03, txtbHC3MaxOnCh04, txtbHC3MaxOnCh05, txtbHC3MaxOnCh06, txtbHC3MaxOnCh07, txtbHC3MaxOnCh08, txtbHC3MaxOnCh09, txtbHC3MaxOnCh10, txtbHC3MaxOnCh11 };
            HC4MaxOn = new TextBox[] { txtbHC4MaxOnCh00, txtbHC4MaxOnCh01, txtbHC4MaxOnCh02, txtbHC4MaxOnCh03, txtbHC4MaxOnCh04, txtbHC4MaxOnCh05, txtbHC4MaxOnCh06, txtbHC4MaxOnCh07, txtbHC4MaxOnCh08, txtbHC4MaxOnCh09, txtbHC4MaxOnCh10, txtbHC4MaxOnCh11 };
            HC5MaxOn = new TextBox[] { txtbHC5MaxOnCh00, txtbHC5MaxOnCh01, txtbHC5MaxOnCh02, txtbHC5MaxOnCh03, txtbHC5MaxOnCh04, txtbHC5MaxOnCh05, txtbHC5MaxOnCh06, txtbHC5MaxOnCh07, txtbHC5MaxOnCh08, txtbHC5MaxOnCh09, txtbHC5MaxOnCh10, txtbHC5MaxOnCh11 };
            HC6MaxOn = new TextBox[] { txtbHC6MaxOnCh00, txtbHC6MaxOnCh01, txtbHC6MaxOnCh02, txtbHC6MaxOnCh03, txtbHC6MaxOnCh04, txtbHC6MaxOnCh05, txtbHC6MaxOnCh06, txtbHC6MaxOnCh07, txtbHC6MaxOnCh08, txtbHC6MaxOnCh09, txtbHC6MaxOnCh10, txtbHC6MaxOnCh11 };
            hcMaxOns = new TextBox[][] { HC1MaxOn, HC2MaxOn, HC3MaxOn, HC4MaxOn, HC5MaxOn, HC6MaxOn };
            HC1MaxDurRec = new TextBox[] { txtbHC1MaxDurRecCh00, txtbHC1MaxDurRecCh01, txtbHC1MaxDurRecCh02, txtbHC1MaxDurRecCh03, txtbHC1MaxDurRecCh04, txtbHC1MaxDurRecCh05, txtbHC1MaxDurRecCh06, txtbHC1MaxDurRecCh07, txtbHC1MaxDurRecCh08, txtbHC1MaxDurRecCh09, txtbHC1MaxDurRecCh10, txtbHC1MaxDurRecCh11 };
            HC2MaxDurRec = new TextBox[] { txtbHC2MaxDurRecCh00, txtbHC2MaxDurRecCh01, txtbHC2MaxDurRecCh02, txtbHC2MaxDurRecCh03, txtbHC2MaxDurRecCh04, txtbHC2MaxDurRecCh05, txtbHC2MaxDurRecCh06, txtbHC2MaxDurRecCh07, txtbHC2MaxDurRecCh08, txtbHC2MaxDurRecCh09, txtbHC2MaxDurRecCh10, txtbHC2MaxDurRecCh11 };
            HC3MaxDurRec = new TextBox[] { txtbHC3MaxDurRecCh00, txtbHC3MaxDurRecCh01, txtbHC3MaxDurRecCh02, txtbHC3MaxDurRecCh03, txtbHC3MaxDurRecCh04, txtbHC3MaxDurRecCh05, txtbHC3MaxDurRecCh06, txtbHC3MaxDurRecCh07, txtbHC3MaxDurRecCh08, txtbHC3MaxDurRecCh09, txtbHC3MaxDurRecCh10, txtbHC3MaxDurRecCh11 };
            HC4MaxDurRec = new TextBox[] { txtbHC4MaxDurRecCh00, txtbHC4MaxDurRecCh01, txtbHC4MaxDurRecCh02, txtbHC4MaxDurRecCh03, txtbHC4MaxDurRecCh04, txtbHC4MaxDurRecCh05, txtbHC4MaxDurRecCh06, txtbHC4MaxDurRecCh07, txtbHC4MaxDurRecCh08, txtbHC4MaxDurRecCh09, txtbHC4MaxDurRecCh10, txtbHC4MaxDurRecCh11 };
            HC5MaxDurRec = new TextBox[] { txtbHC5MaxDurRecCh00, txtbHC5MaxDurRecCh01, txtbHC5MaxDurRecCh02, txtbHC5MaxDurRecCh03, txtbHC5MaxDurRecCh04, txtbHC5MaxDurRecCh05, txtbHC5MaxDurRecCh06, txtbHC5MaxDurRecCh07, txtbHC5MaxDurRecCh08, txtbHC5MaxDurRecCh09, txtbHC5MaxDurRecCh10, txtbHC5MaxDurRecCh11 };
            HC6MaxDurRec = new TextBox[] { txtbHC6MaxDurRecCh00, txtbHC6MaxDurRecCh01, txtbHC6MaxDurRecCh02, txtbHC6MaxDurRecCh03, txtbHC6MaxDurRecCh04, txtbHC6MaxDurRecCh05, txtbHC6MaxDurRecCh06, txtbHC6MaxDurRecCh07, txtbHC6MaxDurRecCh08, txtbHC6MaxDurRecCh09, txtbHC6MaxDurRecCh10, txtbHC6MaxDurRecCh11 };
            hcMaxDurRec = new TextBox[][] { HC1MaxDurRec, HC2MaxDurRec, HC3MaxDurRec, HC4MaxDurRec, HC5MaxDurRec, HC6MaxDurRec };
            HC1UndAmp = new TextBox[] { txtbHC1UndAmpCh00, txtbHC1UndAmpCh01, txtbHC1UndAmpCh02, txtbHC1UndAmpCh03, txtbHC1UndAmpCh04, txtbHC1UndAmpCh05, txtbHC1UndAmpCh06, txtbHC1UndAmpCh07, txtbHC1UndAmpCh08, txtbHC1UndAmpCh09, txtbHC1UndAmpCh10, txtbHC1UndAmpCh11 };
            HC2UndAmp = new TextBox[] { txtbHC2UndAmpCh00, txtbHC2UndAmpCh01, txtbHC2UndAmpCh02, txtbHC2UndAmpCh03, txtbHC2UndAmpCh04, txtbHC2UndAmpCh05, txtbHC2UndAmpCh06, txtbHC2UndAmpCh07, txtbHC2UndAmpCh08, txtbHC2UndAmpCh09, txtbHC2UndAmpCh10, txtbHC2UndAmpCh11 };
            HC3UndAmp = new TextBox[] { txtbHC3UndAmpCh00, txtbHC3UndAmpCh01, txtbHC3UndAmpCh03, txtbHC3UndAmpCh03, txtbHC3UndAmpCh04, txtbHC3UndAmpCh05, txtbHC3UndAmpCh06, txtbHC3UndAmpCh07, txtbHC3UndAmpCh08, txtbHC3UndAmpCh09, txtbHC3UndAmpCh10, txtbHC3UndAmpCh11 };
            HC4UndAmp = new TextBox[] { txtbHC4UndAmpCh00, txtbHC4UndAmpCh01, txtbHC4UndAmpCh04, txtbHC4UndAmpCh03, txtbHC4UndAmpCh04, txtbHC4UndAmpCh05, txtbHC4UndAmpCh06, txtbHC4UndAmpCh07, txtbHC4UndAmpCh08, txtbHC4UndAmpCh09, txtbHC4UndAmpCh10, txtbHC4UndAmpCh11 };
            HC5UndAmp = new TextBox[] { txtbHC5UndAmpCh00, txtbHC5UndAmpCh01, txtbHC5UndAmpCh05, txtbHC5UndAmpCh03, txtbHC5UndAmpCh04, txtbHC5UndAmpCh05, txtbHC5UndAmpCh06, txtbHC5UndAmpCh07, txtbHC5UndAmpCh08, txtbHC5UndAmpCh09, txtbHC5UndAmpCh10, txtbHC5UndAmpCh11 };
            HC6UndAmp = new TextBox[] { txtbHC6UndAmpCh00, txtbHC6UndAmpCh01, txtbHC6UndAmpCh06, txtbHC6UndAmpCh03, txtbHC6UndAmpCh04, txtbHC6UndAmpCh05, txtbHC6UndAmpCh06, txtbHC6UndAmpCh07, txtbHC6UndAmpCh08, txtbHC6UndAmpCh09, txtbHC6UndAmpCh10, txtbHC6UndAmpCh11 };
            hcUndAmps = new TextBox[][] { HC1UndAmp, HC2UndAmp, HC3UndAmp, HC4UndAmp, HC5UndAmp, HC6UndAmp };
            HC1MeasCurTime = new ComboBox[] { cmbHC1MeasCurTimeCh00, cmbHC1MeasCurTimeCh01, cmbHC1MeasCurTimeCh02, cmbHC1MeasCurTimeCh03, cmbHC1MeasCurTimeCh04, cmbHC1MeasCurTimeCh05, cmbHC1MeasCurTimeCh06, cmbHC1MeasCurTimeCh07, cmbHC1MeasCurTimeCh08, cmbHC1MeasCurTimeCh09, cmbHC1MeasCurTimeCh10, cmbHC1MeasCurTimeCh11 };
            HC2MeasCurTime = new ComboBox[] { cmbHC2MeasCurTimeCh00, cmbHC2MeasCurTimeCh01, cmbHC2MeasCurTimeCh02, cmbHC2MeasCurTimeCh03, cmbHC2MeasCurTimeCh04, cmbHC2MeasCurTimeCh05, cmbHC2MeasCurTimeCh06, cmbHC2MeasCurTimeCh07, cmbHC2MeasCurTimeCh08, cmbHC2MeasCurTimeCh09, cmbHC2MeasCurTimeCh10, cmbHC2MeasCurTimeCh11 };
            HC3MeasCurTime = new ComboBox[] { cmbHC3MeasCurTimeCh00, cmbHC3MeasCurTimeCh01, cmbHC3MeasCurTimeCh02, cmbHC3MeasCurTimeCh03, cmbHC3MeasCurTimeCh04, cmbHC3MeasCurTimeCh05, cmbHC3MeasCurTimeCh06, cmbHC3MeasCurTimeCh07, cmbHC3MeasCurTimeCh08, cmbHC3MeasCurTimeCh09, cmbHC3MeasCurTimeCh10, cmbHC3MeasCurTimeCh11 };
            HC4MeasCurTime = new ComboBox[] { cmbHC4MeasCurTimeCh00, cmbHC4MeasCurTimeCh01, cmbHC4MeasCurTimeCh02, cmbHC4MeasCurTimeCh03, cmbHC4MeasCurTimeCh04, cmbHC4MeasCurTimeCh05, cmbHC4MeasCurTimeCh06, cmbHC4MeasCurTimeCh07, cmbHC4MeasCurTimeCh08, cmbHC4MeasCurTimeCh09, cmbHC4MeasCurTimeCh10, cmbHC4MeasCurTimeCh11 };
            HC5MeasCurTime = new ComboBox[] { cmbHC5MeasCurTimeCh00, cmbHC5MeasCurTimeCh01, cmbHC5MeasCurTimeCh02, cmbHC5MeasCurTimeCh03, cmbHC5MeasCurTimeCh04, cmbHC5MeasCurTimeCh05, cmbHC5MeasCurTimeCh06, cmbHC5MeasCurTimeCh07, cmbHC5MeasCurTimeCh08, cmbHC5MeasCurTimeCh09, cmbHC5MeasCurTimeCh10, cmbHC5MeasCurTimeCh11 };
            HC6MeasCurTime = new ComboBox[] { cmbHC6MeasCurTimeCh00, cmbHC6MeasCurTimeCh01, cmbHC6MeasCurTimeCh02, cmbHC6MeasCurTimeCh03, cmbHC6MeasCurTimeCh04, cmbHC6MeasCurTimeCh05, cmbHC6MeasCurTimeCh06, cmbHC6MeasCurTimeCh07, cmbHC6MeasCurTimeCh08, cmbHC6MeasCurTimeCh09, cmbHC6MeasCurTimeCh10, cmbHC6MeasCurTimeCh11 };
            hcMeasCurTimes = new ComboBox[][] { HC1MeasCurTime, HC2MeasCurTime, HC3MeasCurTime, HC4MeasCurTime, HC5MeasCurTime, HC6MeasCurTime };

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
            lc1Lock = new CheckBox[] { chkLC1LockCh00, chkLC1LockCh01, chkLC1LockCh02, chkLC1LockCh03, chkLC1LockCh04, chkLC1LockCh05, chkLC1LockCh06, chkLC1LockCh07, chkLC1LockCh08, chkLC1LockCh09, chkLC1LockCh10, chkLC1LockCh11, chkLC1LockCh12, chkLC1LockCh13, chkLC1LockCh14, chkLC1LockCh15 };
            lc2Lock = new CheckBox[] { chkLC2LockCh00, chkLC2LockCh01, chkLC2LockCh02, chkLC2LockCh03, chkLC2LockCh04, chkLC2LockCh05, chkLC2LockCh06, chkLC2LockCh07, chkLC2LockCh08, chkLC2LockCh09, chkLC2LockCh10, chkLC2LockCh11, chkLC2LockCh12, chkLC2LockCh13, chkLC2LockCh14, chkLC2LockCh15 };
            lc3Lock = new CheckBox[] { chkLC3LockCh00, chkLC3LockCh01, chkLC3LockCh02, chkLC3LockCh03, chkLC3LockCh04, chkLC3LockCh05, chkLC3LockCh06, chkLC3LockCh07, chkLC3LockCh08, chkLC3LockCh09, chkLC3LockCh10, chkLC3LockCh11, chkLC3LockCh12, chkLC3LockCh13, chkLC3LockCh14, chkLC3LockCh15 };
            lc4Lock = new CheckBox[] { chkLC4LockCh00, chkLC4LockCh01, chkLC4LockCh02, chkLC4LockCh03, chkLC4LockCh04, chkLC4LockCh05, chkLC4LockCh06, chkLC4LockCh07, chkLC4LockCh08, chkLC4LockCh09, chkLC4LockCh10, chkLC4LockCh11, chkLC4LockCh12, chkLC4LockCh13, chkLC4LockCh14, chkLC4LockCh15 };
            lc5Lock = new CheckBox[] { chkLC5LockCh00, chkLC5LockCh01, chkLC5LockCh02, chkLC5LockCh03, chkLC5LockCh04, chkLC5LockCh05, chkLC5LockCh06, chkLC5LockCh07, chkLC5LockCh08, chkLC5LockCh09, chkLC5LockCh10, chkLC5LockCh11, chkLC5LockCh12, chkLC5LockCh13, chkLC5LockCh14, chkLC5LockCh15 };
            lc6Lock = new CheckBox[] { chkLC6LockCh00, chkLC6LockCh01, chkLC6LockCh02, chkLC6LockCh03, chkLC6LockCh04, chkLC6LockCh05, chkLC6LockCh06, chkLC6LockCh07, chkLC6LockCh08, chkLC6LockCh09, chkLC6LockCh10, chkLC6LockCh11, chkLC6LockCh12, chkLC6LockCh13, chkLC6LockCh14, chkLC6LockCh15 };
            lcLocks = new CheckBox[][] { lc1Lock, lc2Lock, lc3Lock, lc4Lock, lc5Lock, lc6Lock };
            lc1Direction = new ComboBox[] { cmbLC1DirectionCh00, cmbLC1DirectionCh01, cmbLC1DirectionCh02, cmbLC1DirectionCh03, cmbLC1DirectionCh04, cmbLC1DirectionCh05, cmbLC1DirectionCh06, cmbLC1DirectionCh07, cmbLC1DirectionCh08, cmbLC1DirectionCh09, cmbLC1DirectionCh10, cmbLC1DirectionCh11, cmbLC1DirectionCh12, cmbLC1DirectionCh13, cmbLC1DirectionCh14, cmbLC1DirectionCh15 };
            lc2Direction = new ComboBox[] { cmbLC2DirectionCh00, cmbLC2DirectionCh01, cmbLC2DirectionCh02, cmbLC2DirectionCh03, cmbLC2DirectionCh04, cmbLC2DirectionCh05, cmbLC2DirectionCh06, cmbLC2DirectionCh07, cmbLC2DirectionCh08, cmbLC2DirectionCh09, cmbLC2DirectionCh10, cmbLC2DirectionCh11, cmbLC2DirectionCh12, cmbLC2DirectionCh13, cmbLC2DirectionCh14, cmbLC2DirectionCh15 };
            lc3Direction = new ComboBox[] { cmbLC3DirectionCh00, cmbLC3DirectionCh01, cmbLC3DirectionCh02, cmbLC3DirectionCh03, cmbLC3DirectionCh04, cmbLC3DirectionCh05, cmbLC3DirectionCh06, cmbLC3DirectionCh07, cmbLC3DirectionCh08, cmbLC3DirectionCh09, cmbLC3DirectionCh10, cmbLC3DirectionCh11, cmbLC3DirectionCh12, cmbLC3DirectionCh13, cmbLC3DirectionCh14, cmbLC3DirectionCh15 };
            lc4Direction = new ComboBox[] { cmbLC4DirectionCh00, cmbLC4DirectionCh01, cmbLC4DirectionCh02, cmbLC4DirectionCh03, cmbLC4DirectionCh04, cmbLC4DirectionCh05, cmbLC4DirectionCh06, cmbLC4DirectionCh07, cmbLC4DirectionCh08, cmbLC4DirectionCh09, cmbLC4DirectionCh10, cmbLC4DirectionCh11, cmbLC4DirectionCh12, cmbLC4DirectionCh13, cmbLC4DirectionCh14, cmbLC4DirectionCh15 };
            lc5Direction = new ComboBox[] { cmbLC5DirectionCh00, cmbLC5DirectionCh01, cmbLC5DirectionCh02, cmbLC5DirectionCh03, cmbLC5DirectionCh04, cmbLC5DirectionCh05, cmbLC5DirectionCh06, cmbLC5DirectionCh07, cmbLC5DirectionCh08, cmbLC5DirectionCh09, cmbLC5DirectionCh10, cmbLC5DirectionCh11, cmbLC5DirectionCh12, cmbLC5DirectionCh13, cmbLC5DirectionCh14, cmbLC5DirectionCh15 };
            lc6Direction = new ComboBox[] { cmbLC6DirectionCh00, cmbLC6DirectionCh01, cmbLC6DirectionCh02, cmbLC6DirectionCh03, cmbLC6DirectionCh04, cmbLC6DirectionCh05, cmbLC6DirectionCh06, cmbLC6DirectionCh07, cmbLC6DirectionCh08, cmbLC6DirectionCh09, cmbLC6DirectionCh10, cmbLC6DirectionCh11, cmbLC6DirectionCh12, cmbLC6DirectionCh13, cmbLC6DirectionCh14, cmbLC6DirectionCh15 };
            lcDirections = new ComboBox[][] { lc1Direction, lc2Direction, lc3Direction, lc4Direction, lc5Direction, lc6Direction };
            lc1TimeoutTime = new TextBox[] { txtLC1TimoutTimeCh00, txtLC1TimoutTimeCh01, txtLC1TimoutTimeCh02, txtLC1TimoutTimeCh03, txtLC1TimoutTimeCh04, txtLC1TimoutTimeCh05, txtLC1TimoutTimeCh06, txtLC1TimoutTimeCh07, txtLC1TimoutTimeCh08, txtLC1TimoutTimeCh09, txtLC1TimoutTimeCh10, txtLC1TimoutTimeCh11, txtLC1TimoutTimeCh12, txtLC1TimoutTimeCh13, txtLC1TimoutTimeCh14, txtLC1TimoutTimeCh15 };
            lc2TimeoutTime = new TextBox[] { txtLC2TimoutTimeCh00, txtLC2TimoutTimeCh01, txtLC2TimoutTimeCh02, txtLC2TimoutTimeCh03, txtLC2TimoutTimeCh04, txtLC2TimoutTimeCh05, txtLC2TimoutTimeCh06, txtLC2TimoutTimeCh07, txtLC2TimoutTimeCh08, txtLC2TimoutTimeCh09, txtLC2TimoutTimeCh10, txtLC2TimoutTimeCh11, txtLC2TimoutTimeCh12, txtLC2TimoutTimeCh13, txtLC2TimoutTimeCh14, txtLC2TimoutTimeCh15 };
            lc3TimeoutTime = new TextBox[] { txtLC3TimoutTimeCh00, txtLC3TimoutTimeCh01, txtLC3TimoutTimeCh02, txtLC3TimoutTimeCh03, txtLC3TimoutTimeCh04, txtLC3TimoutTimeCh05, txtLC3TimoutTimeCh06, txtLC3TimoutTimeCh07, txtLC3TimoutTimeCh08, txtLC3TimoutTimeCh09, txtLC3TimoutTimeCh10, txtbLC3TimeoutTimeCh11, txtLC3TimoutTimeCh12, txtLC3TimoutTimeCh13, txtLC3TimoutTimeCh14, txtLC3TimoutTimeCh15 };
            lc4TimeoutTime = new TextBox[] { txtLC4TimoutTimeCh00, txtLC4TimoutTimeCh01, txtLC4TimoutTimeCh02, txtLC4TimoutTimeCh03, txtLC4TimoutTimeCh04, txtLC4TimoutTimeCh05, txtLC4TimoutTimeCh06, txtLC4TimoutTimeCh07, txtLC4TimoutTimeCh08, txtLC4TimoutTimeCh09, txtLC4TimoutTimeCh10, txtLC4TimoutTimeCh11, txtLC4TimoutTimeCh12, txtLC4TimoutTimeCh13, txtLC4TimoutTimeCh14, txtLC4TimoutTimeCh15 };
            lc5TimeoutTime = new TextBox[] { txtLC5TimoutTimeCh00, txtLC5TimoutTimeCh01, txtLC5TimoutTimeCh02, txtLC5TimoutTimeCh03, txtLC5TimoutTimeCh04, txtLC5TimoutTimeCh05, txtLC5TimoutTimeCh06, txtLC5TimoutTimeCh07, txtLC5TimoutTimeCh08, txtLC5TimoutTimeCh09, txtLC5TimoutTimeCh10, txtLC5TimoutTimeCh11, txtLC5TimoutTimeCh12, txtLC5TimoutTimeCh13, txtLC5TimoutTimeCh14, txtLC5TimoutTimeCh15 };
            lc6TimeoutTime = new TextBox[] { txtLC6TimoutTimeCh00, txtLC6TimoutTimeCh01, txtLC6TimoutTimeCh02, txtLC6TimoutTimeCh03, txtLC6TimoutTimeCh04, txtLC6TimoutTimeCh05, txtLC6TimoutTimeCh06, txtLC6TimoutTimeCh07, txtLC6TimoutTimeCh08, txtLC6TimoutTimeCh09, txtLC6TimoutTimeCh10, txtLC6TimoutTimeCh11, txtLC6TimoutTimeCh12, txtLC6TimoutTimeCh13, txtLC6TimoutTimeCh14, txtLC6TimoutTimeCh15 };
            lcTimeoutTimes = new TextBox[][] { lc1TimeoutTime, lc2TimeoutTime, lc3TimeoutTime, lc4TimeoutTime, lc5TimeoutTime, lc6TimeoutTime };
            lc1MaxOn = new TextBox[] { txtbLC1MaxOnCh00, txtbLC1MaxOnCh01, txtbLC1MaxOnCh02, txtbLC1MaxOnCh03, txtbLC1MaxOnCh04, txtbLC1MaxOnCh05, txtbLC1MaxOnCh06, txtbLC1MaxOnCh07, txtbLC1MaxOnCh08, txtbLC1MaxOnCh09, txtbLC1MaxOnCh10, txtbLC1MaxOnCh11, txtbLC1MaxOnCh12, txtbLC1MaxOnCh13, txtbLC1MaxOnCh14, txtbLC1MaxOnCh15 };
            lc2MaxOn = new TextBox[] { txtbLC2MaxOnCh00, txtbLC2MaxOnCh01, txtbLC2MaxOnCh02, txtbLC2MaxOnCh03, txtbLC2MaxOnCh04, txtbLC2MaxOnCh05, txtbLC2MaxOnCh06, txtbLC2MaxOnCh07, txtbLC2MaxOnCh08, txtbLC2MaxOnCh09, txtbLC2MaxOnCh10, txtbLC2MaxOnCh11, txtbLC2MaxOnCh12, txtbLC2MaxOnCh13, txtbLC2MaxOnCh14, txtbLC2MaxOnCh15 };
            lc3MaxOn = new TextBox[] { txtbLC3MaxOnCh00, txtbLC3MaxOnCh01, txtbLC3MaxOnCh02, txtLC3MaxOnCh03, txtbLC3MaxOnCh04, txtbLC3MaxOnCh05, txtbLC3MaxOnCh06, txtbLC3MaxOnCh07, txtbLC3MaxOnCh08, txtbLC3MaxOnCh09, txtbLC3MaxOnCh10, txtLC3MaxOnCh11, txtLC3MaxOnCh12, txtLC3MaxOnCh13, txtLC3MaxOnCh14, txtLC3MaxOnCh15 };
            lc4MaxOn = new TextBox[] { txtLC4MaxOnCh00, txtLC4MaxOnCh01, txtLC4MaxOnCh02, txtLC4MaxOnCh03, txtLC4MaxOnCh04, txtLC4MaxOnCh05, txtLC4MaxOnCh06, txtLC4MaxOnCh07, txtLC4MaxOnCh08, txtLC4MaxOnCh09, txtLC4MaxOnCh10, txtLC4MaxOnCh11, txtLC4MaxOnCh12, txtLC4MaxOnCh13, txtLC4MaxOnCh14, txtLC4MaxOnCh15 };
            lc5MaxOn = new TextBox[] { txtLC5MaxOnCh00, txtLC5MaxOnCh01, txtLC5MaxOnCh02, txtLC5MaxOnCh03, txtLC5MaxOnCh04, txtLC5MaxOnCh05, txtLC5MaxOnCh06, txtLC5MaxOnCh07, txtLC5MaxOnCh08, txtLC5MaxOnCh09, txtLC5MaxOnCh10, txtLC5MaxOnCh11, txtLC5MaxOnCh12, txtLC5MaxOnCh13, txtLC5MaxOnCh14, txtLC5MaxOnCh15 };
            lc6MaxOn = new TextBox[] { txtLC6MaxOnCh00, txtLC6MaxOnCh01, txtLC6MaxOnCh02, txtLC3MaxOnCh03, txtLC6MaxOnCh04, txtLC6MaxOnCh05, txtLC6MaxOnCh06, txtLC6MaxOnCh07, txtLC6MaxOnCh08, txtLC6MaxOnCh09, txtLC6MaxOnCh10, txtLC6MaxOnCh11, txtLC6MaxOnCh12, txtLC6MaxOnCh13, txtLC6MaxOnCh14, txtLC6MaxOnCh15 };
            lcMaxOns = new TextBox[][] { lc1MaxOn, lc2MaxOn, lc3MaxOn, lc4MaxOn, lc5MaxOn, lc6MaxOn }; 
            lc1MaxDurRecovery = new TextBox[] { txtbLC1MaxDurRecoveryCh00, txtbLC1MaxDurRecoveryCh01, txtbLC1MaxDurRecoveryCh02, txtbLC1MaxDurRecoveryCh03, txtbLC1MaxDurRecoveryCh04, txtbLC1MaxDurRecoveryCh05, txtbLC1MaxDurRecoveryCh06, txtbLC1MaxDurRecoveryCh07, txtbLC1MaxDurRecoveryCh08, txtbLC1MaxDurRecoveryCh09, txtbLC1MaxDurRecoveryCh10, txtbLC1MaxDurRecoveryCh11, txtbLC1MaxDurRecoveryCh12, txtbLC1MaxDurRecoveryCh13, txtbLC1MaxDurRecoveryCh14, txtbLC1MaxDurRecoveryCh15 };
            lc2MaxDurRecovery = new TextBox[] { txtbLC2MaxDurRecoveryCh00, txtbLC2MaxDurRecoveryCh01, txtbLC2MaxDurRecoveryCh02, txtbLC2MaxDurRecoveryCh03, txtbLC2MaxDurRecoveryCh04, txtbLC2MaxDurRecoveryCh05, txtbLC2MaxDurRecoveryCh06, txtbLC2MaxDurRecoveryCh07, txtbLC2MaxDurRecoveryCh08, txtbLC2MaxDurRecoveryCh09, txtbLC2MaxDurRecoveryCh10, txtbLC2MaxDurRecoveryCh11, txtbLC2MaxDurRecoveryCh12, txtbLC2MaxDurRecoveryCh13, txtbLC2MaxDurRecoveryCh14, txtbLC2MaxDurRecoveryCh15 };
            lc3MaxDurRecovery = new TextBox[] { txtbLC3MaxDurRecoveryCh00, txtbLC3MaxDurRecoveryCh01, txtbLC3MaxDurRecoveryCh02, txtbLC3MaxDurRecoveryCh03, txtbLC3MaxDurRecoveryCh04, txtbLC3MaxDurRecoveryCh05, txtbLC3MaxDurRecoveryCh06, txtbLC3MaxDurRecoveryCh07, txtbLC3MaxDurRecoveryCh08, txtbLC3MaxDurRecoveryCh09, txtbLC3MaxDurRecoveryCh10, txtbLC3MaxDurRecoveryCh11, txtbLC3MaxDurRecoveryCh12, txtbLC3MaxDurRecoveryCh13, txtbLC3MaxDurRecoveryCh14, txtbLC3MaxDurRecoveryCh15 };
            lc4MaxDurRecovery = new TextBox[] { txtbLC4MaxDurRecoveryCh00, txtbLC4MaxDurRecoveryCh01, txtbLC4MaxDurRecoveryCh02, txtbLC4MaxDurRecoveryCh03, txtbLC4MaxDurRecoveryCh04, txtbLC4MaxDurRecoveryCh05, txtbLC4MaxDurRecoveryCh06, txtbLC4MaxDurRecoveryCh07, txtbLC4MaxDurRecoveryCh08, txtbLC4MaxDurRecoveryCh09, txtbLC4MaxDurRecoveryCh10, txtbLC4MaxDurRecoveryCh11, txtbLC4MaxDurRecoveryCh12, txtbLC4MaxDurRecoveryCh13, txtbLC4MaxDurRecoveryCh14, txtbLC4MaxDurRecoveryCh15 };
            lc5MaxDurRecovery = new TextBox[] { txtbLC5MaxDurRecoveryCh00, txtbLC5MaxDurRecoveryCh01, txtbLC5MaxDurRecoveryCh02, txtbLC5MaxDurRecoveryCh03, txtbLC5MaxDurRecoveryCh04, txtbLC5MaxDurRecoveryCh05, txtbLC5MaxDurRecoveryCh06, txtbLC5MaxDurRecoveryCh07, txtbLC5MaxDurRecoveryCh08, txtbLC5MaxDurRecoveryCh09, txtbLC5MaxDurRecoveryCh10, txtbLC5MaxDurRecoveryCh11, txtbLC5MaxDurRecoveryCh12, txtbLC5MaxDurRecoveryCh13, txtbLC5MaxDurRecoveryCh14, txtbLC5MaxDurRecoveryCh15 };
            lc6MaxDurRecovery = new TextBox[] { txtbLC6MaxDurRecoveryCh00, txtbLC6MaxDurRecoveryCh01, txtbLC6MaxDurRecoveryCh02, txtbLC6MaxDurRecoveryCh03, txtbLC6MaxDurRecoveryCh04, txtbLC6MaxDurRecoveryCh05, txtbLC6MaxDurRecoveryCh06, txtbLC6MaxDurRecoveryCh07, txtbLC6MaxDurRecoveryCh08, txtbLC6MaxDurRecoveryCh09, txtbLC6MaxDurRecoveryCh10, txtbLC6MaxDurRecoveryCh11, txtbLC6MaxDurRecoveryCh12, txtbLC6MaxDurRecoveryCh13, txtbLC6MaxDurRecoveryCh14, txtbLC6MaxDurRecoveryCh15 };
            lcMaxDurRecoveries = new TextBox[][] { lc1MaxDurRecovery, lc2MaxDurRecovery, lc3MaxDurRecovery, lc4MaxDurRecovery, lc5MaxDurRecovery, lc6MaxDurRecovery };
            lc1UCAmp = new TextBox[] { txtbLC1UndercurrentAmpsCh00, txtbLC1UndercurrentAmpsCh01, txtbLC1UndercurrentAmpsCh02, txtbLC1UndercurrentAmpsCh03, txtbLC1UndercurrentAmpsCh04, txtbLC1UndercurrentAmpsCh05, txtbLC1UndercurrentAmpsCh06, txtbLC1UndercurrentAmpsCh07, txtbLC1UndercurrentAmpsCh08, txtbLC1UndercurrentAmpsCh09, txtbLC1UndercurrentAmpsCh10, txtbLC1UndercurrentAmpsCh11, txtbLC1UndercurrentAmpsCh12, txtbLC1UndercurrentAmpsCh13, txtbLC1UndercurrentAmpsCh14, txtbLC1UndercurrentAmpsCh15 };
            lc2UCAmp = new TextBox[] { txtbLC2UndercurrentAmpsCh00, txtbLC2UndercurrentAmpsCh01, txtbLC2UndercurrentAmpsCh02, txtbLC2UndercurrentAmpsCh03, txtbLC2UndercurrentAmpsCh04, txtbLC2UndercurrentAmpsCh05, txtbLC2UndercurrentAmpsCh06, txtbLC2UndercurrentAmpsCh07, txtbLC2UndercurrentAmpsCh08, txtbLC2UndercurrentAmpsCh09, txtbLC2UndercurrentAmpsCh10, txtbLC2UndercurrentAmpsCh11, txtbLC2UndercurrentAmpsCh12, txtbLC2UndercurrentAmpsCh13, txtbLC2UndercurrentAmpsCh14, txtbLC2UndercurrentAmpsCh15 };
            lc3UCAmp = new TextBox[] { txtbLC3UndercurrentAmpsCh00, txtbLC3UndercurrentAmpsCh01, txtbLC3UndercurrentAmpsCh02, txtbLC3UndercurrentAmpsCh03, txtbLC3UndercurrentAmpsCh04, txtbLC3UndercurrentAmpsCh05, txtbLC3UndercurrentAmpsCh06, txtbLC3UndercurrentAmpsCh07, txtbLC3UndercurrentAmpsCh08, txtbLC3UndercurrentAmpsCh09, txtbLC3UndercurrentAmpsCh10, txtbLC3UndercurrentAmpsCh11, txtbLC3UndercurrentAmpsCh12, txtbLC3UndercurrentAmpsCh13, txtbLC3UndercurrentAmpsCh14, txtbLC3UndercurrentAmpsCh15 };
            lc4UCAmp = new TextBox[] { txtbLC4UndercurrentAmpsCh00, txtbLC4UndercurrentAmpsCh01, txtbLC4UndercurrentAmpsCh02, txtbLC4UndercurrentAmpsCh03, txtbLC4UndercurrentAmpsCh04, txtbLC4UndercurrentAmpsCh05, txtbLC4UndercurrentAmpsCh06, txtbLC4UndercurrentAmpsCh07, txtbLC4UndercurrentAmpsCh08, txtbLC4UndercurrentAmpsCh09, txtbLC4UndercurrentAmpsCh10, txtbLC4UndercurrentAmpsCh11, txtbLC4UndercurrentAmpsCh12, txtbLC4UndercurrentAmpsCh13, txtbLC4UndercurrentAmpsCh14, txtbLC4UndercurrentAmpsCh15 };
            lc5UCAmp = new TextBox[] { txtbLC5UndercurrentAmpsCh00, txtbLC5UndercurrentAmpsCh01, txtbLC5UndercurrentAmpsCh02, txtbLC5UndercurrentAmpsCh03, txtbLC5UndercurrentAmpsCh04, txtbLC5UndercurrentAmpsCh05, txtbLC5UndercurrentAmpsCh06, txtbLC5UndercurrentAmpsCh07, txtbLC5UndercurrentAmpsCh08, txtbLC5UndercurrentAmpsCh09, txtbLC5UndercurrentAmpsCh10, txtbLC5UndercurrentAmpsCh11, txtbLC5UndercurrentAmpsCh12, txtbLC5UndercurrentAmpsCh13, txtbLC5UndercurrentAmpsCh14, txtbLC5UndercurrentAmpsCh15 };
            lc6UCAmp = new TextBox[] { txtbLC6UndercurrentAmpsCh00, txtbLC6UndercurrentAmpsCh01, txtbLC6UndercurrentAmpsCh02, txtbLC6UndercurrentAmpsCh03, txtbLC6UndercurrentAmpsCh04, txtbLC6UndercurrentAmpsCh05, txtbLC6UndercurrentAmpsCh06, txtbLC6UndercurrentAmpsCh07, txtbLC6UndercurrentAmpsCh08, txtbLC6UndercurrentAmpsCh09, txtbLC6UndercurrentAmpsCh10, txtbLC6UndercurrentAmpsCh11, txtbLC6UndercurrentAmpsCh12, txtbLC6UndercurrentAmpsCh13, txtbLC6UndercurrentAmpsCh14, txtbLC6UndercurrentAmpsCh15 };
            lcUCAmps = new TextBox[][] { lc1UCAmp, lc2UCAmp, lc3UCAmp, lc4UCAmp, lc5UCAmp, lc6UCAmp };
            lc1MeasCurTime = new ComboBox[] { cmbLC1MeasCurTimeCh00, cmbLC1MeasCurTimeCh01, cmbLC1MeasCurTimeCh02, cmbLC1MeasCurTimeCh03, cmbLC1MeasCurTimeCh04, cmbLC1MeasCurTimeCh05, cmbLC1MeasCurTimeCh06, cmbLC1MeasCurTimeCh07, cmbLC1MeasCurTimeCh08, cmbLC1MeasCurTimeCh09, cmbLC1MeasCurTimeCh10, cmbLC1MeasCurTimeCh11, cmbLC1MeasCurTimeCh12, cmbLC1MeasCurTimeCh13, cmbLC1MeasCurTimeCh14, cmbLC1MeasCurTimeCh15 };
            lc2MeasCurTime = new ComboBox[] { cmbLC2MeasCurTimeCh00, cmbLC2MeasCurTimeCh01, cmbLC2MeasCurTimeCh02, cmbLC2MeasCurTimeCh03, cmbLC2MeasCurTimeCh04, cmbLC2MeasCurTimeCh05, cmbLC2MeasCurTimeCh06, cmbLC2MeasCurTimeCh07, cmbLC2MeasCurTimeCh08, cmbLC2MeasCurTimeCh09, cmbLC2MeasCurTimeCh10, cmbLC2MeasCurTimeCh11, cmbLC2MeasCurTimeCh12, cmbLC2MeasCurTimeCh13, cmbLC2MeasCurTimeCh14, cmbLC2MeasCurTimeCh15 };
            lc3MeasCurTime = new ComboBox[] { cmbLC3MeasCurTimeCh00, cmbLC3MeasCurTimeCh01, cmbLC3MeasCurTimeCh02, cmbLC3MeasCurTimeCh03, cmbLC3MeasCurTimeCh04, cmbLC3MeasCurTimeCh05, cmbLC3MeasCurTimeCh06, cmbLC3MeasCurTimeCh07, cmbLC3MeasCurTimeCh08, cmbLC3MeasCurTimeCh09, cmbLC3MeasCurTimeCh10, cmbLC3MeasCurTimeCh11, cmbLC3MeasCurTimeCh12, cmbLC3MeasCurTimeCh13, cmbLC3MeasCurTimeCh14, cmbLC3MeasCurTimeCh15 };
            lc4MeasCurTime = new ComboBox[] { cmbLC4MeasCurTimeCh00, cmbLC4MeasCurTimeCh01, cmbLC4MeasCurTimeCh02, cmbLC4MeasCurTimeCh03, cmbLC4MeasCurTimeCh04, cmbLC4MeasCurTimeCh05, cmbLC4MeasCurTimeCh06, cmbLC4MeasCurTimeCh07, cmbLC4MeasCurTimeCh08, cmbLC4MeasCurTimeCh09, cmbLC4MeasCurTimeCh10, cmbLC4MeasCurTimeCh11, cmbLC4MeasCurTimeCh12, cmbLC4MeasCurTimeCh13, cmbLC4MeasCurTimeCh14, cmbLC4MeasCurTimeCh15 };
            lc5MeasCurTime = new ComboBox[] { cmbLC5MeasCurTimeCh00, cmbLC5MeasCurTimeCh01, cmbLC5MeasCurTimeCh02, cmbLC5MeasCurTimeCh03, cmbLC5MeasCurTimeCh04, cmbLC5MeasCurTimeCh05, cmbLC5MeasCurTimeCh06, cmbLC5MeasCurTimeCh07, cmbLC5MeasCurTimeCh08, cmbLC5MeasCurTimeCh09, cmbLC5MeasCurTimeCh10, cmbLC5MeasCurTimeCh11, cmbLC5MeasCurTimeCh12, cmbLC5MeasCurTimeCh13, cmbLC5MeasCurTimeCh14, cmbLC5MeasCurTimeCh15 };
            lc6MeasCurTime = new ComboBox[] { cmbLC6MeasCurTimeCh00, cmbLC6MeasCurTimeCh01, cmbLC6MeasCurTimeCh02, cmbLC6MeasCurTimeCh03, cmbLC6MeasCurTimeCh04, cmbLC6MeasCurTimeCh05, cmbLC6MeasCurTimeCh06, cmbLC6MeasCurTimeCh07, cmbLC6MeasCurTimeCh08, cmbLC6MeasCurTimeCh09, cmbLC6MeasCurTimeCh10, cmbLC6MeasCurTimeCh11, cmbLC6MeasCurTimeCh12, cmbLC6MeasCurTimeCh13, cmbLC6MeasCurTimeCh14, cmbLC6MeasCurTimeCh15 };
            lcMeasCurTimes = new ComboBox[][] { lc1MeasCurTime, lc2MeasCurTime, lc3MeasCurTime, lc4MeasCurTime, lc5MeasCurTime, lc6MeasCurTime };

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

        private void ckbTabVisAux2_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbTabVisAux2.Checked == true)
            {
                this.tabControlAux2QF.SelectedIndex = 1;
            } 
            else
            {
                this.tabControlAux2QF.SelectedIndex = 0;
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

        private void ckbTabVisBreaker2_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbTabVisBreaker2.Checked == true)
            {
                this.tablessControl4.SelectedIndex = 1;
            } 
            else
            {
                this.tablessControl4.SelectedIndex = 0;
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

        private void ckbTabVisDimmer2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTabVisDimmer2.Checked == true)
            {
                this.tabControlDimmer2QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlDimmer2QF.SelectedIndex = 0;
            }
        }

        private void ckbTabVisHC1_CheckedChanged(object sender, EventArgs e)
        {
            if( ckbTabVisHC1.Checked == true)
            {
                this.tabControlHC1QF.SelectedIndex = 1;
            } 
            else
            {
                this.tabControlHC1QF.SelectedIndex = 0;
            }
        }

        private void ckbTabVisHC2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTabVisHC2.Checked == true)
            {
                this.tabControlHC2QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlHC2QF.SelectedIndex = 0;
            }
        }

        private void ckbTabVisLC2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTabVisLC2.Checked == true)
            {
                this.tabControlLC2QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlLC2QF.SelectedIndex = 0;
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

        private void checkBox514_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox514.Checked == true)
            {
                this.tablessControl1.SelectedIndex = 1;
            }
            else
            {
                this.tablessControl1.SelectedIndex = 0;
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

        private void checkBox515_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox515.Checked == true)
            {
                this.tablessControl2.SelectedIndex = 1;
            }
            else
            {
                this.tablessControl2.SelectedIndex = 0;
            }
        }

        private void checkBox516_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox516.Checked == true)
            {
                this.tabControlDimmer3QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlDimmer3QF.SelectedIndex = 0;
            }
        }

        private void checkBox517_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox517.Checked == true)
            {
                this.tabControlDimmer4QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlDimmer4QF.SelectedIndex = 0;
            }
        }

        private void checkBox518_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox518.Checked == true)
            {
                this.tabControlDimmer5QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlDimmer5QF.SelectedIndex = 0;
            }
        }

        private void checkBox519_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox519.Checked == true)
            {
                this.tabControlDimmer6QF.SelectedIndex = 1;
            }
            else
            {
                this.tabControlDimmer6QF.SelectedIndex = 0;
            }
        }

        private void checkBox520_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox520.Checked == true)
            {
                this.tabControl1.SelectedIndex = 1;
            }
            else
            {
                this.tabControl1.SelectedIndex = 0;
            }
        }

        private void checkBox521_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox521.Checked == true)
            {
                this.tabControl2.SelectedIndex = 1;
            }
            else
            {
                this.tabControl2.SelectedIndex = 0;
            }
        }

        private void checkBox522_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox522.Checked == true)
            {
                this.tabControl3.SelectedIndex = 1;
            }
            else
            {
                this.tabControl3.SelectedIndex = 0;
            }
        }

        private void checkBox523_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox523.Checked == true)
            {
                this.tabControl4.SelectedIndex = 1;
            }
            else
            {
                this.tabControl4.SelectedIndex = 0;
            }
        }

        private void checkBox524_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox524.Checked == true)
            {
                this.tablessControl9.SelectedIndex = 1;
            }
            else
            {
                this.tablessControl9.SelectedIndex = 0;
            }
        }

        private void checkBox525_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox525.Checked == true)
            {
                this.tablessControl10.SelectedIndex = 1;
            }
            else
            {
                this.tablessControl10.SelectedIndex = 0;
            }
        }

        private void checkBox526_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox526.Checked == true)
            {
                this.tablessControl11.SelectedIndex = 1;
            }
            else
            {
                this.tablessControl11.SelectedIndex = 0;
            }
        }

        private void checkBox527_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox527.Checked == true)
            {
                this.tablessControl12.SelectedIndex = 1;
            }
            else
            {
                this.tablessControl12.SelectedIndex = 0;
            }
        }

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
    }
}
