using Microsoft.Reporting.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace RemoteAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isReportViewerLoaded;

        public MainWindow()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                ReportDataSource reportDataSource1 = new ReportDataSource();
                RemoteappEmployees dataset = new RemoteappEmployees();
                dataset.BeginInit();
                reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.EmployeeSalary;
                _reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                _reportViewer.LocalReport.ReportEmbeddedResource = "RemoteAppDemo.Report1.rdlc";
                dataset.EndInit();

                RemoteappEmployeesTableAdapters.EmployeeSalaryTableAdapter tableAdapter = new RemoteappEmployeesTableAdapters.EmployeeSalaryTableAdapter();
                tableAdapter.ClearBeforeFill = true;
                tableAdapter.Fill(dataset.EmployeeSalary);

                _reportViewer.RefreshReport();
                _isReportViewerLoaded = true;

            }
        }
    }
}
