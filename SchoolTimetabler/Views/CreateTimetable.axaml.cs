using Avalonia;using Avalonia.Controls;using Avalonia.Markup.Xaml;using Avalonia.ReactiveUI;using SchoolTimetabler.ViewModels;namespace SchoolTimetabler.Views;public partial class CreateTimetable : ReactiveUserControl<CreateTimetableViewModel>{    public CreateTimetable()    {        InitializeComponent();    }    private void InitializeComponent()    {        AvaloniaXamlLoader.Load(this);    }}