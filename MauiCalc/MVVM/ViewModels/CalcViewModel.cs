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

        public ICommand OperationCommand =>
            new Command((number) => { Formula += number; });

        public ICommand ResetCommand =>
            new Command(() =>
            {

                Result = "0";
                Formula = "";

            });

        public ICommand BackspaceCommand =>
            new Command(() => {

                if (Formula.Length >0) {

                    char lastCharacter = Formula[Formula.Length - 1];
                    if (char.IsWhiteSpace(lastCharacter)) {

                        // remove last 3 characters from the string
                        Formula = Formula.Substring(0, Formula.Length - 3);

                    }
                    else {

                        // remove last 1 character from the string
                        Formula = Formula.Substring(0, Formula.Length - 1);
                    }
                    
                
                }
            
            });

        public ICommand CalculateCommand => new Command(() => {

            if (Formula.Length == 0)
            {
                return;
            }
            var calculation = Calculator.Calculate(Formula);
            Result = calculation.Result.ToString();


        });
    }
}
