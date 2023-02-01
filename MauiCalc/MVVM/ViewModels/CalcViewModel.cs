using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiCalc.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalcViewModel
    {
        public string Formula { get; set; }
        public string Result { get; set; } = "0";
        public string LastOperator { get; set; } = null;
        public List<string> NumbersList { get; set; } = new List<string>();
        public string NumbersListStr { get; set; }

        public string[] operators = { " % ", " / ", " * ", " - ", " + " };

        public void CheckLastOperator(string buttonValue) {

            //string[] operators = { " % ", " / ", " * ", " - ", " + " };
         
            if (Array.IndexOf(operators, buttonValue) >= 0) 
            {
                if (Array.IndexOf(operators, LastOperator) >= 0)
                {                   

                }
                else {
                    Formula += buttonValue;                 
                    NumbersList.Add(buttonValue);
                    NumbersListStr = string.Join(",", NumbersList).Replace(",", " ");
                    LastOperator = NumbersList.LastOrDefault();
                }
            }


            else {

                Formula += buttonValue;
                NumbersList.Add(buttonValue);
                NumbersListStr = string.Join(",", NumbersList).Replace(",", " ");
                LastOperator = NumbersList.LastOrDefault();
            }
           

        }

        //public ICommand OperationCommand =>

        //    new Command((number) => { Formula += number; });

        public ICommand OperationCommand =>

            new Command((number) => { CheckLastOperator(number.ToString()); });

        public ICommand ResetCommand =>
            new Command(() =>
            {

                Result = "0";
                Formula = "";
                LastOperator = null;
                NumbersList.Clear();
                NumbersListStr = "";

            });

        public ICommand BackspaceCommand =>
            new Command(() => {

                if (Formula.Length >0) {

                    
                    char lastCharacter = Formula[Formula.Length - 1];
                    if (char.IsWhiteSpace(lastCharacter)) {

                        // remove last 3 characters from the string
                        Formula = Formula.Substring(0, Formula.Length - 3);
                        //Remove last element in List
                        NumbersList.RemoveAt(NumbersList.Count - 1);
                        NumbersListStr = string.Join(",", NumbersList).Replace(",", " ");
                        LastOperator = NumbersList.LastOrDefault();

                    }
                    else {

                        // remove last 1 character from the string
                        Formula = Formula.Substring(0, Formula.Length - 1);
                        //Remove last element in List
                        NumbersList.RemoveAt(NumbersList.Count - 1);
                        NumbersListStr = string.Join(",", NumbersList).Replace(",", " ");
                        LastOperator = NumbersList.LastOrDefault();
                    }
                    
                
                }
            
            });

        public ICommand CalculateCommand => new Command(() => {

            if (Formula.Length == 0)
            {
                return;
            }
            if (Array.IndexOf(operators, LastOperator) >= 0)
            {
                return;
            }
            var calculation = Calculator.Calculate(Formula);
            Result = calculation.Result.ToString();


        });
    }
}
