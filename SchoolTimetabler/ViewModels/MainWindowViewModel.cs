﻿using System.Collections.Generic;using System.Reactive;using Data.FakeDataBase;using ReactiveUI;namespace SchoolTimetabler.ViewModels;public class MainWindowViewModel : ViewModelBase, IScreen{    private readonly FDataBaseClasses _storageClasses;    private readonly FDataBaseDisciplines _storageDisciplines;    private readonly FDataBaseTeachers _storageTeachers;    private FDataBaseTimetable _storageTimetables;    public List<string> DisciplinesName = new();    public MainWindowViewModel()    {        _storageClasses = FDataBaseClasses.GetInstance();        _storageDisciplines = FDataBaseDisciplines.GetInstance();        _storageTeachers = FDataBaseTeachers.GetInstance();        _storageTimetables = FDataBaseTimetable.GetInstance();        GoTimetableInfo = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(new TimetableInfoViewModel())        );        GoCreateTimetable = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(new CreateTimetableViewModel(this))        );        GoSchoolInfo = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(new SchoolInfoViewModel(this, _storageClasses,                _storageDisciplines, _storageTeachers))        );        GoCreateProfile = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(new CreateSchoolProfileViewModel(                _storageClasses,                _storageDisciplines, _storageTeachers, DisciplinesName))        );    }    public ReactiveCommand<Unit, IRoutableViewModel> GoCreateProfile { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoCreateTimetable { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoTimetableInfo { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoSchoolInfo { get; }    public RoutingState Router { get; } = new();}