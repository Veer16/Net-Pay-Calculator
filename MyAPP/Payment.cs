using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPP
{
   public class Payment
    {
        private double DEPENDENT_BENEFIT_RATE = 0.0875, GST_RATE = 0.15, INCOME_TAX_RATE = 0.27, MEMBERSHIP_RATE = 0.03;
        private int HOURLY_RATE =75;
        private double grossPay;
        private int noOfHoursWorked;
        private Contractor aContractor;
        private double base_pay;
        public Payment(Contractor aContractor, int noHour)
        {
            this.aContractor = aContractor;

            this.noOfHoursWorked = noHour;
            this.base_pay = noHour * HOURLY_RATE;
            this.grossPay = this.base_pay - (this.base_pay * MEMBERSHIP_RATE);

        }
        public double GetGst()
        {
            double gST;
            gST = this.grossPay * GST_RATE;
            return gST;


        }
        public double GetIncomeTax()
        {

            double income_tax_base = INCOME_TAX_RATE * grossPay;
            double dependent_benefits = income_tax_base * DEPENDENT_BENEFIT_RATE * aContractor.GetNumberOfDependents();
            double incomeTaxDeduction = income_tax_base - dependent_benefits;
            return incomeTaxDeduction;
        }
        public double getMemberShipFee()
        {
            double memberShip;
            memberShip = (noOfHoursWorked * HOURLY_RATE) * MEMBERSHIP_RATE;
            return memberShip;
        }
        public double GetTotalDeduction()
        {
            double totalDeduction;
            totalDeduction = GetGst() + GetIncomeTax();
            return totalDeduction;

        }
        public double GetNetPay()
        {

            double netPay;
            netPay = this.grossPay - GetTotalDeduction();
            Console.WriteLine("Gross Pay: {0:C}", grossPay);
            return netPay;

        }
    }
}

