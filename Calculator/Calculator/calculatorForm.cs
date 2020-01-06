using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator{
    public partial class calculatorForm : Form{
        /* ***Start of Class Fields*** */
        private Boolean operators;
        private Boolean equalsActive;
        private String operatorsSymbol;
        private double number1;
        private double number2;
        /* ***End of Class Fields*** */

        //Constructor
        public calculatorForm(){
            InitializeComponent();
            operators = false;
            equalsActive = false;
            number1 = 0;
            number2 = 0;
        }

        /*
         * Event Handler: On Button Click
         * 
         * This function determines which button was click, and then
         * handle it accordingly. 
        */
        private void Button_Click(object sender, EventArgs e){
            //Getting the button that was click as a Button Object
            Button button = (Button)sender;
            //checking if the user clicked the clear button
            if (button.Text == "CE"){
                textBoxDisplay.Clear();
                textBoxDisplayEquation.Clear();
                operators = false;
                equalsActive = false;
                operatorsSymbol = null;
                number1 = 0;
                number2 = 0;
            }
            //checking if the user clicked one of the operators
            else if (button.Text == "+" && operators == true){
                number1 = Convert.ToInt64(textBoxDisplay.Text);
                textBoxDisplay.Clear();
                textBoxDisplayEquation.Text = (number1 + " + ");
                operatorsSymbol = "+";
                operators = false;
                equalsActive = true;
            }
            else if (button.Text == "-" && operators == true){
                number1 = Convert.ToInt64(textBoxDisplay.Text);
                textBoxDisplay.Clear();
                textBoxDisplayEquation.Text = (number1 + " - ");
                operatorsSymbol = "-";
                operators = false;
                equalsActive = true;
            }
            else if (button.Text == "*" && operators == true){
                number1 = Convert.ToInt64(textBoxDisplay.Text);
                textBoxDisplay.Clear();
                textBoxDisplayEquation.Text = (number1 + " * ");
                operatorsSymbol = "*";
                operators = false;
                equalsActive = true;
            }
            else if (button.Text == "/" && operators == true){
                number1 = Convert.ToInt64(textBoxDisplay.Text);
                textBoxDisplay.Clear();
                textBoxDisplayEquation.Text = (number1 + " / ");
                operatorsSymbol = "/";
                operators = false;
                equalsActive = true;
            }
            //checking if the user clicked the equals sign
            else if (button.Text == "=" && equalsActive == true){
                number2 = Convert.ToInt64(textBoxDisplay.Text);
                textBoxDisplayEquation.Text += " " + number2;
                textBoxDisplay.Clear();
                if (operatorsSymbol == "+")
                    textBoxDisplay.Text = (number1 + number2).ToString();
                else if (operatorsSymbol == "-")
                    textBoxDisplay.Text = (number1 - number2).ToString();
                else if (operatorsSymbol == "*")
                    textBoxDisplay.Text = (number1 * number2).ToString();
                else if (operatorsSymbol == "/")
                    textBoxDisplay.Text = (number1 / number2).ToString();
                equalsActive = false;
                operators = true;
                number1 = 0;
                number2 = 0;
            }
            else{   //Since the user click the button with a digit, displaying that number
                //Making sure the the equals buttons was not pushed
                if (button.Text != "=")
                {
                    textBoxDisplay.Text += button.Text;
                    operators = true;
                }
            }
        }

        /*
         * Event Handler: On MenuStrip item "New" is clicked
         * This creates a new calculatorForm
        */ 
        private void newToolStripMenuItemNew_Click(object sender, EventArgs e){
            calculatorForm settingForm = new calculatorForm();
            settingForm.Show();
        }
    }
}
