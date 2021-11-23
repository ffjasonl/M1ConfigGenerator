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
        List<DimmerCard> dimmerObjects = new List<DimmerCard>();
        ComboBox[] dimCardNum;
        ComboBox[] dimPanelNum;
        TextBox[] dimConfigRev;
        TextBox[] dimConfigType;
        CheckBox[] dimDCDriver; CheckBox[] dimDCMotor; CheckBox[] dimShade; CheckBox[] dimForce;
        TextBox[] dimBaseInstance;
        ComboBox[] dim1OCAmps; ComboBox[] dim2OCAmps; ComboBox[] dim3OCAmps; ComboBox[] dim4OCAmps; ComboBox[] dim5OCAmps; ComboBox[] dim6OCAmps;
        ComboBox[] dim1OCTime; ComboBox[] dim2OCTime; ComboBox[] dim3OCTime; ComboBox[] dim4OCTime; ComboBox[] dim5OCTime; ComboBox[] dim6OCTime;
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


            dimCardNum = new ComboBox[] { cmbDimmer1CardNum, cmbDimmer2CardNum, cmbDimmer3CardNum, cmbDimmer4CardNum, cmbDimmer5CardNum, cmbDimmer6CardNum };
            dimPanelNum = new ComboBox[] { cmbDimmer1PanelNum, cmbDimmer2PanelNum, cmbDimmer3PanelNum, cmbDimmer4PanelNum, cmbDimmer5PanelNum, cmbDimmer6PanelNum };
            dimConfigRev = new TextBox[] { tbxDimmer1CfgRev, tbxDimmer2CfgRev, tbxDimmer3CfgRev, tbxDimmer4CfgRev, tbxDimmer5CfgRev, tbxDimmer6CfgRev };
            dimConfigType = new TextBox[] { tbxDimmer1CfgType, tbxDimmer2CfgType, tbxDimmer3CfgType, tbxDimmer4CfgType, tbxDimmer5CfgType, tbxDimmer6CfgType };
            dimDCDriver = new CheckBox[] { chkDimmer1DCDriver, chkDimmer2DCDriver, chkDimmer3DCDriver, chkDimmer4DCDriver, chkDimmer5DCDriver, chkDimmer6DCDriver };
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
            dim1OCTime = new ComboBox[] { cmbDimmer1OCTime00, cmbDimmer1OCTime01, cmbDimmer1OCTime02, cmbDimmer1OCTime03, cmbDimmer1OCTime04, cmbDimmer1OCTime05, cmbDimmer1OCTime06, cmbDimmer1OCTime07, cmbDimmer1OCTime08, cmbDimmer1OCTime09, cmbDimmer1OCTime10, cmbDimmer1OCTime11 };
            dim2OCTime = new ComboBox[] { cmbDimmer2OCTime00, cmbDimmer2OCTime01, cmbDimmer2OCTime02, cmbDimmer2OCTime03, cmbDimmer2OCTime04, cmbDimmer2OCTime05, cmbDimmer2OCTime06, cmbDimmer2OCTime07, cmbDimmer2OCTime08, cmbDimmer2OCTime09, cmbDimmer2OCTime10, cmbDimmer2OCTime11 };
            dim3OCTime = new ComboBox[] { cmbDimmer3OCTime00, cmbDimmer3OCTime01, cmbDimmer3OCTime02, cmbDimmer3OCTime03, cmbDimmer3OCTime04, cmbDimmer3OCTime05, cmbDimmer3OCTime06, cmbDimmer3OCTime07, cmbDimmer3OCTime08, cmbDimmer3OCTime09, cmbDimmer3OCTime10, cmbDimmer3OCTime11 };
            dim4OCTime = new ComboBox[] { cmbDimmer4OCTime00, cmbDimmer4OCTime01, cmbDimmer4OCTime02, cmbDimmer4OCTime03, cmbDimmer4OCTime04, cmbDimmer4OCTime05, cmbDimmer4OCTime06, cmbDimmer4OCTime07, cmbDimmer4OCTime08, cmbDimmer4OCTime09, cmbDimmer4OCTime10, cmbDimmer4OCTime11 };
            dim5OCTime = new ComboBox[] { cmbDimmer5OCTime00, cmbDimmer5OCTime01, cmbDimmer5OCTime02, cmbDimmer5OCTime03, cmbDimmer5OCTime04, cmbDimmer5OCTime05, cmbDimmer5OCTime06, cmbDimmer5OCTime07, cmbDimmer5OCTime08, cmbDimmer5OCTime09, cmbDimmer5OCTime10, cmbDimmer5OCTime11 };
            dim6OCTime = new ComboBox[] { cmbDimmer6OCTime00, cmbDimmer6OCTime01, cmbDimmer6OCTime02, cmbDimmer6OCTime03, cmbDimmer6OCTime04, cmbDimmer6OCTime05, cmbDimmer6OCTime06, cmbDimmer6OCTime07, cmbDimmer6OCTime08, cmbDimmer6OCTime09, cmbDimmer6OCTime10, cmbDimmer6OCTime11 };
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HidePanels();
            HideNavButtons();
            panelBlank.Visible = true;
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

        private void ShowPanel(Panel aPanel)
        {
            HidePanels();
            aPanel.Visible = true;
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
            ResetStartPanel();
            ShowPanel(panelStart);
        }

        private void btnMenuLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuAux_Click(object sender, EventArgs e)
        {
            SetMenuColors(0);
            ShowPanel(panelAux);
            ShowAuxNav(Convert.ToInt16(cmbStartAux.SelectedItem.ToString()));
        }

        private void btnMenuBreaker_Click(object sender, EventArgs e)
        {
            SetMenuColors(1);
            ShowPanel(panelBreaker);
            ShowBreakerNav(Convert.ToInt16(cmbStartBreaker.SelectedItem.ToString()));
        }

        private void btnMenuDimmer_Click(object sender, EventArgs e)
        {
            SetMenuColors(2);
            ShowPanel(panelDimmer);
            ShowDimmerNav(Convert.ToInt16(cmbStartDimmer.SelectedItem.ToString()));
        }

        private void btnMenuHC_Click(object sender, EventArgs e)
        {
            SetMenuColors(3);
            ShowPanel(panelHC);
            ShowHCNav(Convert.ToInt16(cmbStartHC.SelectedItem.ToString()));
        }

        private void btnMenuLC_Click(object sender, EventArgs e)
        {
            SetMenuColors(4);
            ShowPanel(panelLC);
            ShowLCNav(Convert.ToInt16(cmbStartLC.SelectedItem.ToString()));
        }

        private void btnMenuSlide_Click(object sender, EventArgs e)
        {
            SetMenuColors(5);
            ShowPanel(panelSlide);
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
            ShowPanel(panelBlank);
            HideNavButtons();
            ResetStartPanel();
        }

        private void btnStartCreate_Click(object sender, EventArgs e)
        {
            HideNavButtons();
            HidePanels();
            // for some reason, had to put these in opposite order so they appear correctly in nav bar
            ShowNavButton(btnMenuSlide, cmbStartSlide.SelectedIndex);
            ShowNavButton(btnMenuLC, cmbStartLC.SelectedIndex);
            ShowNavButton(btnMenuHC, cmbStartHC.SelectedIndex);
            ShowNavButton(btnMenuDimmer, cmbStartDimmer.SelectedIndex);
            ShowNavButton(btnMenuBreaker, cmbStartBreaker.SelectedIndex);
            ShowNavButton(btnMenuAux, cmbStartAux.SelectedIndex);

            // create card objects
            for (int i = 0; i < cmbStartDimmer.SelectedIndex; i++)
            {
                dimmerObjects.Add(new DimmerCard(i + 1));
            }
        }

        private void ResetStartPanel()
        {
            cmbStartSetup.Text = "Quick";
            cmbStartAux.SelectedIndex = 0;
            cmbStartBreaker.SelectedIndex = 0;
            cmbStartDimmer.SelectedIndex = 0;
            cmbStartHC.SelectedIndex = 0;
            cmbStartLC.SelectedIndex = 0;
            cmbStartSlide.SelectedIndex = 0;
        }

        // @Panel -------------------------------------------------------- Panel
        private void HidePanels()
        {
            HideCardPanels();
            //panelTest.Visible = false;
            panelStart.Visible = false;
            panelAux.Visible = false;
            panelBreaker.Visible = false;
            panelDimmer.Visible = false;
            panelHC.Visible = false;
            panelLC.Visible = false;
            panelSlide.Visible = false;
        }

        private void HideCardPanels()
        {
            panelDimmer1General.Visible = false;
            panelDimmer1Full.Visible = false;
            panelDimmer2General.Visible = false;
            //panelDimmer2Full.Visible = false;
            panelDimmer3General.Visible = false;
            //panelDimmer3Full.Visible = false;
            panelDimmer4General.Visible = false;
            //panelDimmer4Full.Visible = false;
            panelDimmer5General.Visible = false;
            //panelDimmer5Full.Visible = false;
            panelDimmer6General.Visible = false;
            //panelDimmer6Full.Visible = false;
            panelDimmerAllQuick.Visible = false;
            panelLC1General.Visible = false;
            panelLC1Quick.Visible = false;
            panelLC1Full.Visible = false;
            panelLC2General.Visible = false;
            panelLC3General.Visible = false;
            panelLC4General.Visible = false;
            panelLC5General.Visible = false;
            panelLC6General.Visible = false;
        }

        private void ShowCardPanels(Panel argPanel1, Panel argPanel2)
        {
            HideCardPanels();
            argPanel1.Visible = true;
            argPanel2.Visible = true;
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


        //   ###    ##     ## ##     ## 
        //  ## ##   ##     ##  ##   ##  
        // ##   ##  ##     ##   ## ##   
        //##     ## ##     ##    ###    
        //######### ##     ##   ## ##   
        //##     ## ##     ##  ##   ##  
        //##     ##  #######  ##     ## 
        //@Aux


        private void btnAuxCard1_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard1);
        }

        private void btnAuxCard2_Click(object sender, EventArgs e)
        {
            AuxCardNavColor(btnAuxCard2);
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


        //########  ########  ########    ###    ##    ## ######## ########  
        //##     ## ##     ## ##         ## ##   ##   ##  ##       ##     ## 
        //##     ## ##     ## ##        ##   ##  ##  ##   ##       ##     ## 
        //########  ########  ######   ##     ## #####    ######   ########  
        //##     ## ##   ##   ##       ######### ##  ##   ##       ##   ##   
        //##     ## ##    ##  ##       ##     ## ##   ##  ##       ##    ##  
        //########  ##     ## ######## ##     ## ##    ## ######## ##     ## 
        //@Breaker

        private void btnBreakerCard1_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard1);
        }

        private void btnBreakerCard2_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard2);
        }

        private void btnBreakerCard3_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard3);
        }

        private void btnBreakerCard4_Click(object sender, EventArgs e)
        {
            BreakerCardNavColor(btnBreakerCard4);
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

            // Dimmer cards
            for (int card = 0; card < Convert.ToInt16(cmbStartDimmer.Text); card++)
            {
                dimmerObjects[card].SetDevAddr(dimCardNum[card].SelectedIndex, dimPanelNum[card].SelectedIndex);
                dimmerObjects[card].SetCfgRev(dimConfigRev[card].Text);
                dimmerObjects[card].SetCfgType(dimConfigType[card].Text);
                dimmerObjects[card].SetDCDriver(dimDCDriver[card].Checked);
                dimmerObjects[card].SetDCDimmer(true); // hard coding for dimmer card
                dimmerObjects[card].SetDCMotor(dimDCMotor[card].Checked);
                dimmerObjects[card].SetShade(dimShade[card].Checked);
                dimmerObjects[card].SetForce(dimForce[card].Checked);
                dimmerObjects[card].SetBaseIndex(dimBaseInstance[card].Text);
                for (int channel = 0; channel < 12; channel++)
                {
                    dimmerObjects[card].SetOCAmps(channel, dim1OCAmps[channel].Text);
                    dimmerObjects[card].SetOCTime(channel, dim1OCTime[channel].Text);
                    dimmerObjects[card].SetGroup0(dim1Groups[channel], channel);
                }

                if (cmbStartSetup.Text == "Full")
                {

                }
            }

            dimmerObjects.ForEach(dimmerObjects => dimmerObjects.CreateFile());
            CreateDimmerReferenceFile();

        }

        private void CreateDimmerReferenceFile()
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h", "DevAddrE.h", "DevAddrF.h" };

            using (StreamWriter sw = File.AppendText(@"M1_DcDriver_Config\Src\M1_Dimmer\DeviceConfigs\DevAddrConfigs.h"))
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
            if (cmbStartSetup.Text == "Quick")
            {
                ShowCardPanels(panelDimmer1General, panelDimmerAllQuick);
            }
            else
            {
                ShowCardPanels(panelDimmer1General, panelDimmer1Full);
            }
        }

        private void btnDimmerCard2_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard2);
            if (cmbStartSetup.Text == "Quick")
            {
                ShowCardPanels(panelDimmer2General, panelDimmerAllQuick);
            }
            else
            {
                //ShowCardPanels(panelDimmer2General, panelDimmer2Full);
            }
        }

        private void btnDimmerCard3_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard3);
            if (cmbStartSetup.Text == "Quick")
            {
                ShowCardPanels(panelDimmer3General, panelDimmerAllQuick);
            }
            else
            {
                //ShowCardPanels(panelDimmer3General, panelDimmer3Full);
            }
        }

        private void btnDimmerCard4_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard4);
            if (cmbStartSetup.Text == "Quick")
            {
                ShowCardPanels(panelDimmer4General, panelDimmerAllQuick);
            }
            else
            {
                //ShowCardPanels(panelDimmer4General, panelDimmer4Full);
            }
        }

        private void btnDimmerCard5_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard5);
            if (cmbStartSetup.Text == "Quick")
            {
                ShowCardPanels(panelDimmer5General, panelDimmerAllQuick);
            }
            else
            {
                //ShowCardPanels(panelDimmer5General, panelDimmer5Full);
            }
        }

        private void btnDimmerCard6_Click(object sender, EventArgs e)
        {
            DimmerCardNavColor(btnDimmerCard6);
            if (cmbStartSetup.Text == "Quick")
            {
                ShowCardPanels(panelDimmer6General, panelDimmerAllQuick);
            }
            else
            {
                //ShowCardPanels(panelDimmer6General, panelDimmer6Full);
            }
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

        private void btnHCCard1_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard1);
        }

        private void btnHCCard2_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard2);
        }

        private void btnHCCard3_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard3);
        }

        private void btnHCCard4_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard4);
        }

        private void btnHCCard5_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard5);
        }

        private void btnHCCard6_Click(object sender, EventArgs e)
        {
            HCCardNavColor(btnHCCard6);
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


        //##        ######  
        //##       ##    ## 
        //##       ##       
        //##       ##       
        //##       ##       
        //##       ##    ## 
        //########  ######  
        //@LC 

        private void CreateLCReferenceFile()
        {
            string[] configNamesReference = { "DevAddrA.h", "DevAddrB.h", "DevAddrC.h", "DevAddrD.h", "DevAddrE.h", "DevAddrF.h" };

            using (StreamWriter sw = File.AppendText(@"M1_DcDriver_Config\Src\M1_LC_Bridge\DeviceConfigs\DevAddrConfigs.h"))
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
            int numLCCards = Convert.ToInt16(cmbStartDimmer.Text);

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

        private void cmbLC1CardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLCGenerate();
        }

        private void cmbLC1PanelNum_SelectedIndexChanged(object sender, EventArgs e)
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
            CheckLCGenerate();
        }

        private void btnLCGenerate_Click(object sender, EventArgs e)
        {

        }

        private void btnLCCard1_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard1);
        }

        private void btnLCCard2_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard2);
        }

        private void btnLCCard3_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard3);
        }

        private void btnLCCard4_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard4);
        }

        private void btnLCCard5_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard5);
        }

        private void btnLCCard6_Click(object sender, EventArgs e)
        {
            LCCardNavColor(btnLCCard6);
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


        // ######  ##       #### ########  ######## 
        //##    ## ##        ##  ##     ## ##       
        //##       ##        ##  ##     ## ##       
        // ######  ##        ##  ##     ## ######   
        //      ## ##        ##  ##     ## ##       
        //##    ## ##        ##  ##     ## ##       
        // ######  ######## #### ########  ######## 
        //@Slide

        private void btnSlideCard1_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard1);
        }

        private void btnSlideCard2_Click(object sender, EventArgs e)
        {
            SlideCardNavColor(btnSlideCard2);
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

    }
}
