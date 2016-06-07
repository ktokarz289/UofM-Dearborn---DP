using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//this is a test about the files work
namespace designPatterns2
{ 
    public partial class Form1 : Form
    {
        Char currency = 'U';
        double value, value2;
        String m;
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

            value = Convert.ToDouble(textBox1.Text);
            usd.setSuccessor(cad);
            cad.setSuccessor(aus);
            value2 =  usd.handleRequest(value);
            m = value2.ToString();
            Money money = new convertedMoney(m);
            money = new roundedMoney(money);
            money = new scientificMoney(money);
            money = new currencyMoney(currency, money);
            textBox2.Text = money.modifyMoney();
            //these statements change the second label so that is says USD or CAD or AUS depending on what the user converts to
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
            //the remaining lines of code remove the trailing zeros from my scientific notation
            //i.e 1.15000e1 -> 1.15e1
            int length = textBox2.Text.IndexOf("e");
            int length2 = length--; 
            while (textBox2.Text[length] == '0')
            {
                length--;
            }
            length++;
            textBox2.Text = textBox2.Text.Remove(length, length2 - length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }


    public abstract class moneyHandler
    {
        public moneyHandler successor;
        public double convertedValue;
        public void setSuccessor( moneyHandler money )
        {
            this.successor = money;
        }

        public abstract double handleRequest(double money);
    }

    class USD : moneyHandler
    {
        char currencyType;
        public USD( char currency)
        {
            currencyType = currency;
        }
        override public double handleRequest(double money)
        {
            if (currencyType == 'U' )
            {
                return money * 1.35;
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

    class CAD : moneyHandler
    {
        char currencyType;
        public CAD( char currency)
        {
            currencyType = currency;
        }
        override public double handleRequest(double money)
        {
            if (currencyType == 'C')
            {
                return convertedValue = money * 1.41;
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

    class AUS : moneyHandler
    {
        char currencyType;
        public AUS( char currency)
        {
            currencyType = currency;
        }
        override public double handleRequest(double money)
        {
            if (currencyType == 'A')
            {
                return convertedValue = money * 1.44;
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

//Everything below this is used for the decorator classes
//Money is the component and is the "base" item we start with
    public abstract class Money
    {
        public String moneyDescr;
        public abstract String modifyMoney();
    }
//My value decorator. Makes it abstract for the decorators to override
    public abstract class moneyDecorator : Money
    {
        public override abstract String modifyMoney();
    }
//Decorator that rounds my number
    public class roundedMoney : moneyDecorator
    {
        Money money;
        public roundedMoney(Money money)
        {
            this.money = money;
        }
        override public String modifyMoney()
        {
            moneyDescr = money.modifyMoney();
            Decimal d = Convert.ToDecimal(moneyDescr);
            d = Math.Round(d, 2);
            moneyDescr = d.ToString();
            return moneyDescr;
        }
    }
//decorator that converts my standard number into scientific notation
    public class scientificMoney : moneyDecorator
    {
        Money money;
        public scientificMoney(Money money) 
        {
            this.money = money;
        }
        override public String modifyMoney()
        {
            moneyDescr = money.modifyMoney();
            decimal d = Convert.ToDecimal(moneyDescr);
            moneyDescr = d.ToString("e");
            return moneyDescr;
        }
    }
//this is the decorator that dictates currency type
    public class currencyMoney : moneyDecorator
    {
        Char currency;
        Money money;
        public currencyMoney(Char c, Money m)
        {
            this.currency = c;
            this.money = m;
        }
        override public String modifyMoney()
        {   //I call money's modifyMoney to get to the original object and return my value all the way back to the outermost wrapper
            moneyDescr = money.modifyMoney();
            if (currency == 'U')
            {
                moneyDescr = moneyDescr + " USD";
            }
            else if (currency == 'C')
            {
                moneyDescr = moneyDescr + " CAD";
            }
            else if (currency == 'A')
            {
                moneyDescr = moneyDescr + " AUS";
            }
            return moneyDescr;
        }
    }
//concrete decorator that starts as just an unknown currency
    public class convertedMoney : Money
    {
        public convertedMoney( String m )
        {
            moneyDescr = m;
        }

        public override String modifyMoney()
        {
            return moneyDescr;
        }
    }
}
