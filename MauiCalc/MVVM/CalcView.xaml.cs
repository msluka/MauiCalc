using MauiCalc.MVVM.ViewModels;

namespace MauiCalc.MVVM;

public partial class CalcView : ContentPage
{
	public CalcView()
	{
		InitializeComponent();
		BindingContext = new CalcViewModel();
	}
}