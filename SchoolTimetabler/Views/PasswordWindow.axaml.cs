using System.Reactive;using System.Reactive.Disposables;using System.Threading.Tasks;using Avalonia;using Avalonia.Controls;using Avalonia.Markup.Xaml;using Avalonia.ReactiveUI;using ReactiveUI;using SchoolTimetabler.ViewModels;namespace SchoolTimetabler.Views;public partial class PasswordWindow : ReactiveWindow<SetPasswordViewModel>{    public PasswordWindow()    {        InitializeComponent();#if DEBUG        this.AttachDevTools();#endif        this.WhenActivated(d => ViewModel!.Close.RegisterHandler(DoCLoseDialog).DisposeWith(d));    }    private async Task DoCLoseDialog(InteractionContext<string, Unit> interactionContext)    {        interactionContext.SetOutput(Unit.Default);        Close(interactionContext.Input);    }    private void InitializeComponent()    {        AvaloniaXamlLoader.Load(this);    }}