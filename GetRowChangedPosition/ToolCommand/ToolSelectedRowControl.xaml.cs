using GetRowChangedPosition.Models;
using GetRowChangedPosition.Services;
using GetRowChangedPosition.Services.Interfaces;
using Ninject;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using GetRowChangedPosition.Annotations;

namespace GetRowChangedPosition.ToolCommand
{
    /// <summary>
    /// Interaction logic for ToolSelectedRowControl.
    /// </summary>
    public partial class ToolSelectedRowControl : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolSelectedRowControl"/> class.
        /// </summary>
        public ToolSelectedRowControl()
        {
            this.InitializeComponent();
            
            Action<RowInfoModel> action = ChangeToolOptions;
            RowTrackerService.SetDelegate(action);
            this.DataContext = this;
        }

        private int _rowNumber;

        public int RowNumber
        {
            get => _rowNumber;
            set { _rowNumber = value; OnPropertyChanged(); }
        }

        private string _textCode;

        public string TextCode
        {
            get => _textCode;
            set { _textCode = value; OnPropertyChanged(); }
        }

        private void ChangeToolOptions(RowInfoModel model)
        {
            TextCode = model.Text;
            RowNumber = model.Number;
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "ToolSelectedRow");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}