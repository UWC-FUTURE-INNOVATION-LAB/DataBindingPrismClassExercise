﻿using Prism;
using Prism.Ioc;
using DataBindingPrism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DataBindingPrism.Services.Interfaces;
using DataBinding.Data;
using DataBinding;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DataBindingPrism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

         //   await NavigationService.NavigateAsync("NavigationPage/MainPage");

            await NavigationService.NavigateAsync("NavigationPage/SecondExcercisePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDatabase, ProductsDatabase>();
            
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondExcercisePage, SecondExerciseViewModel>();
        }
    }
}
