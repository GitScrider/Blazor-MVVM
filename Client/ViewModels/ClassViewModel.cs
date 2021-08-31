using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMVVM.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorMVVM.Client.ViewModels
{
    public class ClassViewModel :  IClassViewModel
    {

        #region Variables
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (this._message == value)
                {
                    return;
                }

                this._message = value;

            }
        }

        private string _addClassString;
        public string ClassString
        {
            get
            {
                return _addClassString;
            }
            set
            {
                if (this._addClassString == value)
                {
                    return;
                }

                this._addClassString = value;
          
            }
        }

        private double _addClassValue;
        public double ClassValue
        {
            get
            {
                return _addClassValue;
            }
            set
            {
                if (this._addClassValue == value)
                {
                    return;
                }

                this._addClassValue = value;
        
            }
        }

        private Class _selectedClass;
        public Class SelectedClass {
            get
            {
                return _selectedClass;

            }
            set
            {
                if (this._selectedClass == value)
                {
                    return;
                }

                this._selectedClass = value;
          
            }
        }


        private List<Class> ClassList = new List<Class>();
        public List<Class> ClassListViewModel {
            get
            {
                return this.ClassList;
            }
            set
            {
                if (this.ClassList == value)
                {
                    return;
                }

                this.ClassList = value;
          
            }
        }

        #endregion

        #region Constructor
        public ClassViewModel()
        {
            InitializeViewModel();
        }

        #endregion

        #region Methods

        private void InitializeViewModel()
        {

            Message = "Titulo";

            ClassList.Add(new Class() { IdClass = 1, ValueClass = 1.0, StringClass = "teste 1" });
            ClassList.Add(new Class() { IdClass = 2, ValueClass = 2.0, StringClass = "teste 2" });
            ClassList.Add(new Class() { IdClass = 3, ValueClass = 3.0, StringClass = "teste 3" });
        }

        public async Task ClassSelected(ChangeEventArgs args)
        {
            await Task.Delay(0);
            SelectedClass = ClassListViewModel.FirstOrDefault(sc => sc.IdClass == Convert.ToInt32(args.Value.ToString()));
        }

        public Task GetClass()
        {
            //get class from endpoint instead initializedvm
            throw new NotImplementedException();
        }

        public async Task AddClass()
        {
            await Task.Delay(0);

            Class newclass = new Class
            {
                IdClass = GetId() + 1,
                StringClass = ClassString,
                ValueClass= ClassValue
            };

            ClassListViewModel.Add(newclass);

        }

        public async Task UpdateClass()
        {
            await Task.Delay(0);
            var classindex = (from x in ClassListViewModel where x.IdClass == SelectedClass.IdClass select x).FirstOrDefault();
            if (classindex != null)
            {
                var index = ClassListViewModel.IndexOf(classindex);
                ClassListViewModel[index] = SelectedClass;
            }

        }

        public async Task DeleteClass()
        {
            await Task.Delay(0);
            ClassListViewModel.Remove(SelectedClass);
        }

        private int GetId() 
        {
            int id=0;
            foreach (Class c in ClassListViewModel) 
            {
                if (id < c.IdClass) 
                {
                    id = c.IdClass;
                }
            
            }
            return id;
        }



        #endregion
    }
}
