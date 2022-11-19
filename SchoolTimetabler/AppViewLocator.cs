using System;using ReactiveUI;using SchoolTimetabler.ViewModels;using SchoolTimetabler.Views;namespace SchoolTimetabler{    public class AppViewLocator : IViewLocator    {        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch        {            ClassEditingMenuViewModel context => new ClassEditingMenu {DataContext = context},            DisciplineEditingMenuViewModel context => new DisciplineEditingMenu {DataContext = context},            CreateSchoolProfileViewModel context => new CreateSchoolProfile { DataContext = context },            TeacherEditingMenuViewModel context => new TeacherEditingMenu {DataContext = context},            SchoolInfoViewModel context => new SchoolInfo {DataContext = context}        };    }}    