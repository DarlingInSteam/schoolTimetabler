using Avalonia;using Avalonia.Controls;using Avalonia.Markup.Xaml;using Avalonia.ReactiveUI;using Avalonia.schoolTimetabler.ViewModels;namespace Avalonia.schoolTimetabler.Views;public partial class CreateSchoolProfile : ReactiveUserControl<CreateSchoolProfileViewModel>{    public CreateSchoolProfile()    {        InitializeComponent();        DataContext = new CreateSchoolProfileViewModel();    }    private void InitializeComponent()    {        AvaloniaXamlLoader.Load(this);    }}