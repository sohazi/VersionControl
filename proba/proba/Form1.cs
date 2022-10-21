using proba.Entities;
using proba.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace proba
{
    public partial class Form1 : Form
    {
        BindingList<RateDate> rd = new BindingList<RateDate>();
        BindingList<string> Currencies = new BindingList<string>();
        


        public Form1()
        {
            InitializeComponent();
            RefreshData();
            comboBox1.DataSource = Currencies;



        }

        private void Looad()
        {
            var xml = new XmlDocument();
            xml.LoadXml(harmadik());


            foreach (XmlElement element in xml.DocumentElement)
            {

                var rate = new RateDate();
                rd.Add(rate);

                //dátum
                rate.Date = dateTimePicker1.Value;

                //valuta
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = (string)comboBox1.SelectedItem;


                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }

        }


        
            private string harmadik()
            {
                var mnbService = new MNBArfolyamServiceSoapClient();


                var request = new GetExchangeRatesRequestBody()
                {
                    currencyNames = "EUR",
                    startDate = "2020-01-01",
                    endDate = "2020-06-30"
                };

                var response = mnbService.GetExchangeRates(request);

                var result = response.GetExchangeRatesResult;
                return result;


                //richTextBox1.Text = result;
                //XMLFILE1.xml.Text = result;
            }

        private void hatodik()
        {
            chartRateData.DataSource = rd;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void RefreshData()
        {
            harmadik();


            Looad();

            hatodik();

            rd.Clear();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
