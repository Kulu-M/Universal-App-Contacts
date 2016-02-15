﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Universal_Contacts.Classes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Universal_Contacts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        Random rnd = new Random();
        public List<Person> persons;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
                    
        }

        private void b_generate_Click(object sender, RoutedEventArgs e)
        {
            persons = new List<Person>();
            generatePersons(20);
        }

        private void generatePersons(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var person = new Person();

                person.nachname = generatePersonNachname();

                person.gender = generatePersonGender();

                person.vorname = generatePersonVorname(person.gender);  

                person.dateofbirth = generateAge(16, 40);

                person.familyStatz = generateFamilyStatus();

                person.zipcode = generateZipCode();

                persons.Add(person);
            }
            setListBoxItemSource();  
        }

        private string generateFamilyStatus()
        {
            int caseSwitch = rnd.Next(4);
            switch (caseSwitch)
            {
                case 1:
                    return Person.familyStatus.Married.ToString();
                case 2:
                    return Person.familyStatus.Unmarried.ToString();
                case 3:
                    return Person.familyStatus.Divorced.ToString();
                case 0:
                    return Person.familyStatus.Widowed.ToString();      
            }
            return null;
        }

        private void setListBoxItemSource()
        {
            lb_persons.ItemsSource = persons;
        }

        private string generatePersonGender()
        {
            string gender;

            if (rnd.Next(2) == 0)
            {
                gender = Person.sex.Female.ToString();
            }
            else
            {
                gender = Person.sex.Male.ToString();
            }

            return gender;
        }

        private string generatePersonVorname(string gender)
        {
            List<string> vn_male = new List<string> { "Light", "Makarov-San", "John", "Tony", "Agent", "George", "Obi-Wan" };

            List<string> vn_female = new List<string> { "Kerrigan", "Lara", "Samus", "Faith", "Rochelle", "Katniss" };

            string vorname = "Max";

            if (gender == "Female")
            {
                vorname = vn_female[rnd.Next(vn_female.Count)];
            }
            else if(gender == "Male")
            {
                vorname = vn_male[rnd.Next(vn_male.Count)];
            }
            else
            {
                //generate Transvestit Names from both Lists
            }
            return vorname;
        }

        private string generatePersonNachname()
        {
            List<string> nn = new List<string> { "Yagami", "Wayne", "Stark", "Croft", "47", "R. R. Martin", "Kenobi", "Aran" };

            string nachname = nn[rnd.Next(nn.Count)];

            return nachname;
        }

        private int generateZipCode()
        {
            int plz = rnd.Next(01001, 99998);
            return plz;
        }

        private DateTime generateAge(int minAge, int maxAge)
        {
            int minD = minAge * 365;
            int maxD = maxAge * 365;
            int days = rnd.Next(minD, maxD);
            DateTime date = DateTime.Now.AddDays(-days);
            return date;
        }

        private void Lb_persons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_persons.SelectedItem == null)
            {
                return;
            }
            else
            {
                pi_person.SelectedIndex = 1;
            }
        }
    }
}
