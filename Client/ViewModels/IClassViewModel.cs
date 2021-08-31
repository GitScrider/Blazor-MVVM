using BlazorMVVM.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazorMVVM.Client.ViewModels
{
    public interface IClassViewModel 
    {
        string ClassString { get; set; }
        double ClassValue { get; set; }
        string Message { get; set; }
        Class SelectedClass { get; set; }
        List<Class> ClassListViewModel { get; set; }
        Task ClassSelected(ChangeEventArgs args);
        Task GetClass();
        Task AddClass();
        Task UpdateClass();
        Task DeleteClass();

    }
}
