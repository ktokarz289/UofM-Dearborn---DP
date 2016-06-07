using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace designPatterns2
{ 
    public partial class Form1 : Form
    {
        Char currency = 'U';
        decimal value, value2;
        int strLength;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currency = 'U';
            //label3.Text = "USD";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currency = 'C';
            //label3.Text = "CAD";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            currency = 'A';
            //label3.Text = "AUS";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moneyHandler usd = new USD(currency);
            moneyHandler cad = new CAD(currency);
            moneyHandler aus = new AUS(currency);

            value = Convert.ToDecimal(textBox1.Text);
            usd.setSuccessor(cad);
            cad.setSuccessor(aus);

            value2 =  usd.handleRequest(value);
            value2 = Math.Round(value2, 2);
            textBox2.Text = value2.ToString(); 
            if (currency == 'U')
            {
                label3.Text = "USD";
            }
            else if (currency == 'C')
            {
                label3.Text = "CAD";
            }
            else if (currency == 'A')
            {
                label3.Text = "AUS";
            }
        }
    }

// handler for money
    public abstract class moneyHandler
    {
        public moneyHandler successor;
        public decimal convertedValue;
        public void setSuccessor( moneyHandler money )
        {
            this.successor = money;
        }

        public abstract decimal handleRequest(decimal money);
    }
//class for when converting to USD
    class USD : moneyHandler
    {
        char currencyType;
        public USD( char currency)
        {
            currencyType = currency;
        }
        override public decimal handleRequest(decimal money)
        {
            if (currencyType == 'U' )
            {
                return money * 1.35m;
            }
            else if (successor != null)
            {
                return successor.handleRequest(money);
            }
            else
            {
                return money;
            }
        }
    }
//class for when converting to CAD
    class CAD : moneyHandler
    {
        char currencyType;
        public CAD( char currency)
        {
            currencyType = currency;
        }
        override public decimal handleRequest(decimal money)
        {
            if (currencyType == 'C')
            {
                return convertedValue = money * 1.41m;
            }
            else if (successor != null)
            {
                return successor.handleRequest(money);
            }
            else
            {
                return money;
            }
        }
    }
//class for converting to AUS
    class AUS : moneyHandler
    {
        char currencyType;
        public AUS( char currency)
        {
            currencyType = currency;
        }
        override public decimal handleRequest(decimal money)
        {
            if (currencyType == 'A')
            {
                return convertedValue = money * 1.44m;
            }
            else if (successor != null)
            {
                return successor.handleRequest(money);
            }
            else
            {
                return money;
            }
        }
    }
}
