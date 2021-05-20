using Client.Server;
using FTN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DMSType> Enums { get; set; }
        public List<CheckBox> Lista = new List<CheckBox>();
        public List<ModelCode> RefLista = new List<ModelCode>();



        public List<string> Gids { get; set; }


        public MainWindow()
        {
            Enums = new ObservableCollection<DMSType>();
            Array values = Enum.GetValues(typeof(DMSType));
            foreach (var val in values)
            {
                if ((DMSType)val != DMSType.MASK_TYPE)
                {
                    Enums.Add((DMSType)val);
                }
            }
            InitializeComponent();
            comboBox.ItemsSource = Enums;
            comboBox1.ItemsSource = Enums;
            comboBox2.ItemsSource = Enums;



        }



        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox.Clear();
            ModelResourcesDesc model = new ModelResourcesDesc();
            DMSType tip;
            Enum.TryParse(comboBox.SelectedItem.ToString(), out tip);
            List<ModelCode> propList = model.GetAllPropertyIds(tip);
            listBox.Items.Clear();
            foreach (ModelCode mc in propList)
            {
                CheckBox a = new CheckBox { Name = mc.ToString(), Content = mc };
                listBox.Items.Add(a);
            }


        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Clear();
            TestGda QueryResults = new TestGda();
            ModelCode temp = (ModelCode)Enum.Parse(typeof(ModelCode), comboBox.SelectedItem.ToString());
            List<ModelCode> props = new List<ModelCode>();
            foreach (CheckBox a in listBox.Items)
            {
                if (a.IsChecked == true)
                {
                    props.Add((ModelCode)a.Content);
                }
            }
            List<ResourceDescription> result = QueryResults.GetExtentValues(temp, props);
            ResultHelper.FillTextBoxExtentValues(richTextBox, result);


        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textbox2.Clear();
            Gids = new List<string>();
            TestGda QueryResults = new TestGda();
            ModelResourcesDesc model = new ModelResourcesDesc();
            DMSType tip;
            Enum.TryParse(comboBox1.SelectedItem.ToString(), out tip);
            ModelCode temp = (ModelCode)Enum.Parse(typeof(ModelCode), comboBox1.SelectedItem.ToString());
            List<ModelCode> propList = model.GetAllPropertyIds(tip);
            List<ResourceDescription> result = QueryResults.GetExtentValues(temp, propList);
            foreach (ResourceDescription rds in result)
            {
                string hexValue = rds.Id.ToString("X");
                string insert = "0x" + hexValue;
                Gids.Add(insert);

            }
            comboGids.ItemsSource = Gids;
            comboGids.SelectedItem = Gids[0];
            listBox1.Items.Clear();
            foreach (ModelCode p in propList)
            {
                CheckBox a = new CheckBox { Name = p.ToString(), Content = p };
                listBox1.Items.Add(a);
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textbox2.Clear();
            TestGda QueryResults = new TestGda();
            ModelCode temp = (ModelCode)Enum.Parse(typeof(ModelCode), comboBox1.SelectedItem.ToString());
            string hexString = comboGids.SelectedValue.ToString();
            string[] niz = hexString.Split('x');
            string hexValue = niz[1];
            long decValue = long.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            List<ModelCode> props = new List<ModelCode>();
            foreach (CheckBox a in listBox1.Items)
            {
                if (a.IsChecked == true)
                {
                    props.Add((ModelCode)a.Content);
                }
            }
            List<ResourceDescription> result = QueryResults.GetExtentValues(temp, props);
            foreach (ResourceDescription rds in result)
            {
                if (rds.Id == decValue)
                {
                    ResultHelper.FillTextBoxValues(textbox2, rds);
                    break;
                }
            }

        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefLista.Clear();
            ConcreteLabel.Content = "";
            Gids = new List<string>();
            listBoxRefProp.Items.Clear();
            comboBoxRefProp.ItemsSource = null;
            TestGda QueryResults = new TestGda();
            ModelResourcesDesc model = new ModelResourcesDesc();
            DMSType tip;
            Enum.TryParse(comboBox2.SelectedItem.ToString(), out tip);
            ModelCode temp = (ModelCode)Enum.Parse(typeof(ModelCode), comboBox2.SelectedItem.ToString());
            List<ModelCode> propList = model.GetAllPropertyIds(tip);

            List<ResourceDescription> result = QueryResults.GetExtentValues(temp, propList);
            foreach (ResourceDescription rds in result)
            {
                string hexValue = rds.Id.ToString("X");
                string insert = "0x" + hexValue;
                Gids.Add(insert);

            }
            comboRgids.ItemsSource = Gids;
            comboRgids.SelectedItem = Gids[0];

            foreach (Property p in result[0].Properties)
            {
                if (p.Type.ToString() == "Reference" || p.Type.ToString() == "ReferenceVector")
                {
                    RefLista.Add(p.Id);
                }

            }
            comboBoxRefProp.ItemsSource = RefLista;


        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                ModelResourcesDesc model = new ModelResourcesDesc();

                string[] names = comboRgids.SelectedItem.ToString().Split('x');

                long globalId = long.Parse(names[1], System.Globalization.NumberStyles.HexNumber);
                ModelCode temp = (ModelCode)Enum.Parse(typeof(ModelCode), comboBox2.SelectedItem.ToString());
                ModelCode child = ResultHelper.getLatestChild((ModelCode)comboBoxRefProp.SelectedItem);
                ConcreteLabel.Content = child.ToString();
                List<ModelCode> propList = model.GetAllPropertyIds(child);
                foreach (ModelCode p in propList)
                {
                    CheckBox a = new CheckBox() { Name = p.ToString(), Content = p };
                    listBoxRefProp.Items.Add(a);

                }


            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBoxRelatedResult.Clear();
            Association asc = new Association();
            TestGda gda = new TestGda();
            string[] names = comboRgids.SelectedItem.ToString().Split('x');
            long globalId = long.Parse(names[1], System.Globalization.NumberStyles.HexNumber);
            ModelCode child = ResultHelper.getLatestChild((ModelCode)comboBoxRefProp.SelectedItem);
            asc.Type = child;
            asc.PropertyId = (ModelCode)comboBoxRefProp.SelectedItem;
            List<ModelCode> props = new List<ModelCode>();
            foreach(object obj in listBoxRefProp.Items)
            {
                
                CheckBox a = (CheckBox)obj;
                if (a.IsChecked == true)
                {
                    props.Add((ModelCode)a.Content);
                }
            }
            List<ResourceDescription> result = gda.GetRelatedValues(globalId, asc, props);
            if(result.Count>0)
            {
                ResultHelper.FillTextBoxExtentValues(textBoxRelatedResult, result);
            }
            else
            {
                textBoxRelatedResult.AppendText("No data for selected reference!");
            }

        }
    }



        

        
    
}
