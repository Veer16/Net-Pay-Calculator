using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPP
{
   public class Contractor
    {
        private string firstName;
        private int IRD;
        private bool isMarried;
        private string lastName;
        private int noChildren;
        private int noDependents;


        public Contractor(String firstName, String lastName, int iRD, bool isMarried, int noChildren)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.IRD = iRD;
            this.isMarried = isMarried;
            this.noChildren = noChildren;
            if (isMarried == true)
            {
                this.noDependents = noChildren + 1;
            }
            else
                this.noDependents = noChildren;


        }


        //Overloaded GetContractorInfo
        public void GetContractorInfo(out String firstName, out String lastName, out int IRD, out int noChildren, out bool isMarried)
        {
            firstName = this.firstName;
            lastName = this.lastName;
            IRD = this.IRD;
            noChildren = this.noChildren;
            isMarried = this.isMarried;

        }

        public void GetContractorInfo(out String firstName, out String lastName, out int IRD)
        {
            firstName = this.firstName;
            lastName = this.lastName;
            IRD = this.IRD;
        }
        
public int GetNumberOfDependents()
        {

            if (noDependents > 4)
            {
                return 4;
            }        

            else
                return this.noDependents; ;

        }
    }
    }

