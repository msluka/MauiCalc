using MauiCalc.MVVM;

namespace MauiCalc;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new CalcView();
	}
}
