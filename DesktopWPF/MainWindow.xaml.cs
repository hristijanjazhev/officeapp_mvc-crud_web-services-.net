using Dapper;
using DesktopWPF.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace DesktopWPF
{
    public partial class MainWindow : Window
    {
        private List<Person> peopleList = new List<Person>();
        private List<Address> addressList = new List<Address>();
        private List<Organization> organizationList = new List<Organization>();
        public int FKPerson { get; set; }
        public int FKAddress { get; set; }
        public int FKOrganization { get; set; }

        private readonly DataAccess db = new DataAccess();

        public MainWindow()
        {
            InitializeComponent();
            UpdateBinding();
        }
        private void UpdateBinding()
        {
            if (personCheckBox.IsChecked == true)
            {
                searchResultListBox.ItemsSource = peopleList;
            }
            else if (addressCheckBox.IsChecked == true)
            {
                searchResultListBox.ItemsSource = addressList;
            }
            else if (organizationCheckBox.IsChecked == true)
            {
                searchResultListBox.ItemsSource = organizationList;
            }
            searchResultListBox.DisplayMemberPath = "FullInfo";
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (personCheckBox.IsChecked == true)
            {
                peopleList = db.GetPeople(defaultSearchOneInsert.Text, defaultSearchTwoInsert.Text);
                if (peopleList.Count == 0)
                {
                    searchResultLabel.Text = $"Last name: '{defaultSearchOneInsert.Text}' not found.";
                }
                else
                {
                    searchResultLabel.Text = "";
                }
            }
            else if (addressCheckBox.IsChecked == true)
            {
                addressList = db.GetAddresses(defaultSearchOneInsert.Text, defaultSearchTwoInsert.Text);
                if (addressList.Count == 0)
                {
                    searchResultLabel.Text = $"Street: '{defaultSearchOneInsert.Text}', and number: '{defaultSearchTwoInsert.Text}' not found.";
                }
                else
                {
                    searchResultLabel.Text = "";
                }
            }
            else if (organizationCheckBox.IsChecked == true)
            {
                organizationList = db.GetOrganizations(defaultSearchOneInsert.Text, defaultSearchTwoInsert.Text);
                if (organizationList.Count == 0)
                {
                    searchResultLabel.Text = $"Organization: '{defaultSearchOneInsert.Text}' with company id: '{defaultSearchTwoInsert.Text}' not found";
                }
                else
                {
                    searchResultLabel.Text = "";
                }
            }

            UpdateBinding();
        }
        private void Insert_Button_Click(object sender, RoutedEventArgs e)
        {
            if (personCheckBox.IsChecked == true)
            {
                db.InsertPerson(defaultOneInsert.Text, defaultTwoInsert.Text, defaultThreeInsert.Text, defaultFourInsert.Text, defaultFiveInsert.Text, defaultSixInsert.Text, defaultSevenInsert.Text, defaultEightInsert.Text, defaultNineInsert.Text, defaultTenInsert.Text, defaultElevenInsert.Text);

                UpdateBinding();
                ClearAllFields();
            }
            else if (addressCheckBox.IsChecked == true)
            {
                db.InsertAddress(defaultOneInsert.Text, defaultTwoInsert.Text, defaultThreeInsert.Text, defaultFourInsert.Text, defaultFiveInsert.Text, defaultSixInsert.Text, defaultSevenInsert.Text, defaultEightInsert.Text, defaultNineInsert.Text);

                UpdateBinding();
                ClearAllFields();
            }
            else if (organizationCheckBox.IsChecked == true)
            {
                db.InsertOrganiation(defaultOneInsert.Text, defaultTwoInsert.Text, defaultThreeInsert.Text, defaultFourInsert.Text, defaultFiveInsert.Text, defaultSixInsert.Text, defaultSevenInsert.Text, defaultEightInsert.Text, defaultNineInsert.Text, defaultTenInsert.Text);

                UpdateBinding();
                ClearAllFields();
            }

            UpdateBinding();
        }
        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (personCheckBox.IsChecked == true)
            {
                db.UpdatePerson(FKPerson, defaultOneInsert.Text, defaultTwoInsert.Text, defaultThreeInsert.Text, defaultFourInsert.Text, defaultFiveInsert.Text, defaultSixInsert.Text, defaultSevenInsert.Text, defaultEightInsert.Text, defaultNineInsert.Text, defaultTenInsert.Text, defaultElevenInsert.Text);

                UpdateBinding();
                ClearAllFields();
            }
            else if (addressCheckBox.IsChecked == true)
            {
                db.UpdateAddresss(FKAddress, defaultOneInsert.Text, defaultTwoInsert.Text, defaultThreeInsert.Text, defaultFourInsert.Text, defaultFiveInsert.Text, defaultSixInsert.Text, defaultSevenInsert.Text, defaultEightInsert.Text, defaultNineInsert.Text);

                UpdateBinding();
                ClearAllFields();
            }
            else if (organizationCheckBox.IsChecked == true)
            {
                db.UpdateOrganization(FKOrganization, defaultOneInsert.Text, defaultTwoInsert.Text, defaultThreeInsert.Text, defaultFourInsert.Text, defaultFiveInsert.Text, defaultSixInsert.Text, defaultSevenInsert.Text, defaultEightInsert.Text, defaultNineInsert.Text, defaultTenInsert.Text);

                UpdateBinding();
                ClearAllFields();
            }

            UpdateBinding();
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (personCheckBox.IsChecked == true)
            {
                db.DeletePerson(FKPerson);

                UpdateBinding();
                ClearAllFields();
            }
            else if (addressCheckBox.IsChecked == true)
            {
                db.DeleteAddress(FKAddress);

                UpdateBinding();
                ClearAllFields();
            }
            else if (organizationCheckBox.IsChecked == true)
            {
                db.DeleteOrganization(FKOrganization);

                UpdateBinding();
                ClearAllFields();
            }

            UpdateBinding();
        }
        private void ClearAllFields()
        {
            defaultOneInsert.Text = "";
            defaultThreeInsert.Text = "";
            defaultTwoInsert.Text = "";
            defaultFourInsert.Text = "";
            defaultFiveInsert.Text = "";
            defaultSixInsert.Text = "";
            defaultSevenInsert.Text = "";
            defaultEightInsert.Text = "";
            defaultNineInsert.Text = "";
            defaultTenInsert.Text = "";
            defaultElevenInsert.Text = "";
            defaultSearchOneInsert.Text = "";
            defaultSearchTwoInsert.Text = "";
            searchResultLabel.Text = "";
            searchResultListBox.ItemsSource = "";
        }
        private void SearchResultListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (personCheckBox.IsChecked == true)
            {
                Person personSelector = (Person)searchResultListBox.SelectedItem;

                foreach (Person person in peopleList)
                {
                    if (personSelector == null)
                    {
                        UpdateBinding();
                        break;
                    }
                    else if (person.PersonFirstName == personSelector.PersonFirstName && person.PersonMiddleName == personSelector.PersonMiddleName && person.PersonLastName == personSelector.PersonLastName && person.IdNumber == personSelector.IdNumber && person.Email == personSelector.Email && person.PhoneNumber == personSelector.PhoneNumber && person.AddressId == personSelector.AddressId && person.IsActive == personSelector.IsActive && person.IsDeleted == personSelector.IsDeleted && person.Gender == personSelector.Gender && person.EMBG == personSelector.EMBG)
                    {
                        defaultOneInsert.Text = personSelector.PersonFirstName;
                        defaultTwoInsert.Text = personSelector.PersonMiddleName;
                        defaultThreeInsert.Text = personSelector.PersonLastName;
                        defaultFourInsert.Text = personSelector.IdNumber.ToString();
                        defaultFiveInsert.Text = personSelector.Email;
                        defaultSixInsert.Text = personSelector.PhoneNumber;
                        defaultSevenInsert.Text = personSelector.AddressId.ToString();
                        defaultEightInsert.Text = personSelector.IsActive.ToString();
                        defaultNineInsert.Text = personSelector.IsDeleted.ToString();
                        defaultTenInsert.Text = personSelector.Gender.ToString();
                        defaultElevenInsert.Text = personSelector.EMBG;
                    }
                }

                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
                {
                    FKAddress = connection.QueryFirstOrDefault<int>($"SELECT AddressId FROM dbo.Person WHERE PersonFirstName = '{defaultOneInsert.Text}' AND EMBG = '{defaultElevenInsert.Text}'");
                    FKPerson = connection.QueryFirstOrDefault<int>($"SELECT * FROM dbo.Person WHERE PersonFirstName = '{defaultOneInsert.Text}' AND EMBG = '{defaultElevenInsert.Text}'");
                }


                UpdateBinding();
            }
            else if (addressCheckBox.IsChecked == true)
            {
                Address addressSelector = (Address)searchResultListBox.SelectedItem;

                foreach (Address address in addressList)
                {
                    if (addressSelector == null)
                    {
                        UpdateBinding();
                        break;
                    }
                    else if (addressSelector.Street == addressSelector.Street && address.Number == addressSelector.Number && address.PostalCode == addressSelector.PostalCode && address.City == addressSelector.City && address.State == addressSelector.State && address.Province == addressSelector.Province && address.Country == addressSelector.Country && address.IsActive == addressSelector.IsActive && address.IsDeleted == addressSelector.IsDeleted)
                    {
                        defaultOneInsert.Text = addressSelector.Street;
                        defaultTwoInsert.Text = addressSelector.Number.ToString();
                        defaultThreeInsert.Text = addressSelector.PostalCode.ToString();
                        defaultFourInsert.Text = addressSelector.City;
                        defaultFiveInsert.Text = addressSelector.State;
                        defaultSixInsert.Text = addressSelector.Province;
                        defaultSevenInsert.Text = addressSelector.Country;
                        defaultEightInsert.Text = addressSelector.IsActive.ToString();
                        defaultNineInsert.Text = addressSelector.IsDeleted.ToString();
                    }
                }

                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
                {
                    FKAddress = connection.QueryFirstOrDefault<int>($"SELECT * FROM dbo.Address WHERE Street = '{defaultOneInsert.Text}' AND Number = '{defaultTwoInsert.Text}'");
                }

                UpdateBinding();
            }
            else if (organizationCheckBox.IsChecked == true)
            {
                Organization organizationSelector = (Organization)searchResultListBox.SelectedItem;

                foreach (Organization organization in organizationList)
                {
                    if (organizationSelector == null)
                    {
                        UpdateBinding();
                        break;
                    }
                    else if (organization.OrganizationName == organizationSelector.OrganizationName && organization.CompanyId == organizationSelector.CompanyId && organization.VatNumber == organizationSelector.VatNumber && organization.Description == organizationSelector.Description && organization.Email == organizationSelector.Email && organization.PhoneNumber == organizationSelector.PhoneNumber && organization.Type == organizationSelector.Type && organization.AddressId == organizationSelector.AddressId && organization.IsActive == organizationSelector.IsActive && organization.IsDeleted == organizationSelector.IsDeleted)
                    {
                        defaultOneInsert.Text = organizationSelector.OrganizationName;
                        defaultTwoInsert.Text = organizationSelector.CompanyId;
                        defaultThreeInsert.Text = organizationSelector.VatNumber.ToString();
                        defaultFourInsert.Text = organizationSelector.Description;
                        defaultFiveInsert.Text = organizationSelector.Email;
                        defaultSixInsert.Text = organizationSelector.PhoneNumber;
                        defaultSevenInsert.Text = organizationSelector.Type;
                        defaultEightInsert.Text = organizationSelector.AddressId.ToString();
                        defaultNineInsert.Text = organizationSelector.IsActive.ToString();
                        defaultTenInsert.Text = organizationSelector.IsDeleted.ToString();
                    }
                }

                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("DMS")))
                {
                    FKAddress = connection.QueryFirstOrDefault<int>($"SELECT AddressId FROM dbo.Organization WHERE OrganizationName = '{defaultOneInsert.Text}' AND CompanyId = '{defaultTwoInsert.Text}'"); 
                    FKOrganization = connection.QueryFirstOrDefault<int>($"SELECT * FROM dbo.Organization WHERE OrganizationName = '{defaultOneInsert.Text}' AND CompanyId = '{defaultTwoInsert.Text}'");
                }

                UpdateBinding();
            }
        }
        private void PersonCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (personCheckBox.IsChecked == true)
            {
                addressCheckBox.IsEnabled = false;
                organizationCheckBox.IsEnabled = false;
                defaultSearchOneLabel.Content = "Last Name";
                defaultSearchTwoLabel.Content = "EMBG";
                defaultOneLabel.Content = "First Name";
                defaultTwoLabel.Content = "Middle Name";
                defaultThreeLabel.Content = "Last Name";
                defaultFourLabel.Content = "Id Number";
                defaultFiveLabel.Content = "Email Address";
                defaultSixLabel.Content = "Phone Number";
                defaultSevenLabel.Content = "Address Id";
                defaultEightLabel.Content = "Person Active";
                defaultNineLabel.Content = "Person Deleted";
                defaultTenLabel.Content = "Gender";
                defaultElevenLabel.Content = "EMBG";
            }
            else if (personCheckBox.IsChecked == false)
            {
                ClearAllFields();
                addressCheckBox.IsEnabled = true;
                organizationCheckBox.IsEnabled = true;
                defaultSearchOneLabel.Content = "Default Search One";
                defaultSearchTwoLabel.Content = "Default Search Two";
                defaultSearchTwoInsert.Visibility = Visibility.Visible;
                defaultOneLabel.Content = "Default One";
                defaultTwoLabel.Content = "Default Two";
                defaultThreeLabel.Content = "Default Three";
                defaultFourLabel.Content = "Default Four";
                defaultFiveLabel.Content = "Default Five";
                defaultSixLabel.Content = "Default Six";
                defaultSevenLabel.Content = "Default Seven";
                defaultEightLabel.Content = "Default Eight";
                defaultNineLabel.Content = "Default Nine";
                defaultTenLabel.Content = "Default Ten";
                defaultElevenLabel.Content = "Default Eleven";
                defaultElevenInsert.Visibility = Visibility.Visible;
            }
        }
        private void AddressCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (addressCheckBox.IsChecked == true)
            {
                personCheckBox.IsEnabled = false;
                organizationCheckBox.IsEnabled = false;
                defaultSearchOneLabel.Content = "Street";
                defaultSearchTwoLabel.Content = "Number";
                defaultOneLabel.Content = "Street";
                defaultTwoLabel.Content = "Number";
                defaultThreeLabel.Content = "Postal Code";
                defaultFourLabel.Content = "City";
                defaultFiveLabel.Content = "State";
                defaultSixLabel.Content = "Province";
                defaultSevenLabel.Content = "Country";
                defaultEightLabel.Content = "Address Active";
                defaultNineLabel.Content = "Address Deleted";
                defaultTenLabel.Content = "";
                defaultElevenLabel.Content = "";
                defaultTenInsert.Visibility = Visibility.Hidden;
                defaultElevenInsert.Visibility = Visibility.Hidden;
            }
            else if (addressCheckBox.IsChecked == false)
            {
                ClearAllFields();
                addressList.Clear();
                personCheckBox.IsEnabled = true;
                organizationCheckBox.IsEnabled = true;
                defaultSearchOneLabel.Content = "Default Search One";
                defaultSearchTwoLabel.Content = "Default Search Two";
                defaultOneLabel.Content = "Default One";
                defaultTwoLabel.Content = "Default Two";
                defaultThreeLabel.Content = "Default Three";
                defaultFourLabel.Content = "Default Four";
                defaultFiveLabel.Content = "Default Five";
                defaultSixLabel.Content = "Default Six";
                defaultSevenLabel.Content = "Default Seven";
                defaultEightLabel.Content = "Default Eight";
                defaultNineLabel.Content = "Default Nine";
                defaultTenLabel.Content = "Default Ten";
                defaultElevenLabel.Content = "Default Eleven";
                defaultTenInsert.Visibility = Visibility.Visible;
                defaultElevenInsert.Visibility = Visibility.Visible;
            }
        }
        private void OrganizationCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (organizationCheckBox.IsChecked == true)
            {
                personCheckBox.IsEnabled = false;
                addressCheckBox.IsEnabled = false;
                defaultSearchOneLabel.Content = "Organization Name";
                defaultSearchTwoLabel.Content = "Company Id";
                defaultOneLabel.Content = "Organization Name";
                defaultTwoLabel.Content = "Company Id";
                defaultThreeLabel.Content = "VAT Number";
                defaultFourLabel.Content = "Description";
                defaultFiveLabel.Content = "Email";
                defaultSixLabel.Content = "Phone Number";
                defaultSevenLabel.Content = "Type";
                defaultEightLabel.Content = "Address Id";
                defaultNineLabel.Content = "Organization Active";
                defaultTenLabel.Content = "Organization Delete";
                defaultElevenLabel.Content = "";
                defaultElevenInsert.Visibility = Visibility.Hidden;
            }
            else if (organizationCheckBox.IsChecked == false)
            {
                ClearAllFields();
                personCheckBox.IsEnabled = true;
                addressCheckBox.IsEnabled = true;
                defaultSearchOneLabel.Content = "Default Search One";
                defaultSearchTwoLabel.Content = "Default Search Two";
                defaultOneLabel.Content = "Default One";
                defaultTwoLabel.Content = "Default Two";
                defaultThreeLabel.Content = "Default Three";
                defaultFourLabel.Content = "Default Four";
                defaultFiveLabel.Content = "Default Five";
                defaultSixLabel.Content = "Default Six";
                defaultSevenLabel.Content = "Default Seven";
                defaultEightLabel.Content = "Default Eight";
                defaultNineLabel.Content = "Default Nine";
                defaultTenLabel.Content = "Default Ten";
                defaultElevenLabel.Content = "Default Eleven";
                defaultElevenInsert.Visibility = Visibility.Visible;
            }
        }
        private void ClearAll(object sender, RoutedEventArgs e)
        {
            ClearAllFields();
        }
    }
}