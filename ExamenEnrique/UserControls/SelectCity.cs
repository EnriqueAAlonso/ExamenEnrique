﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenEnrique.ProxyServices;

namespace ExamenEnrique.UserControls
{
    public partial class SelectCity : UserControl
    {
        private Form1 owner;
        public List<string> countries = new List<string>
        {
            "Kabul", "Mariehamn", "Tirana", "Algiers", "Pago Pago", "Andorra la Vella", "Luanda", "The Valley",
            "Saint John's", "Buenos Aires", "Yerevan", "Oranjestad", "Canberra", "Vienna", "Baku", "Nassau", "Manama",
            "Dhaka", "Bridgetown", "Minsk", "Brussels", "Belmopan", "Porto-Novo", "Hamilton", "Thimphu", "Sucre",
            "Kralendijk", "Sarajevo", "Gaborone", "Brasília", "Diego Garcia", "Road Town", "Charlotte Amalie",
            "Bandar Seri Begawan", "Sofia", "Ouagadougou", "Bujumbura", "Phnom Penh", "Yaoundé", "Ottawa", "Praia",
            "George Town", "Bangui", "N'Djamena", "Santiago", "Beijing", "Flying Fish Cove", "West Island", "Bogotá",
            "Moroni", "Brazzaville", "Kinshasa", "Avarua", "San José", "Zagreb", "Havana", "Willemstad", "Nicosia",
            "Prague", "Copenhagen", "Djibouti", "Roseau", "Santo Domingo", "Quito", "Cairo", "San Salvador", "Malabo",
            "Asmara", "Tallinn", "Addis Ababa", "Stanley", "Tórshavn", "Suva", "Helsinki", "Paris", "Cayenne",
            "Papeetē", "Port-aux-Français", "Libreville", "Banjul", "Tbilisi", "Berlin", "Accra", "Gibraltar", "Athens",
            "Nuuk", "St. George's", "Basse-Terre", "Hagåtña", "Guatemala City", "St. Peter Port", "Conakry", "Bissau",
            "Georgetown", "Port-au-Prince", "Rome", "Tegucigalpa", "City of Victoria", "Budapest", "Reykjavík",
            "New Delhi", "Jakarta", "Yamoussoukro", "Tehran", "Baghdad", "Dublin", "Douglas", "Jerusalem", "Rome",
            "Kingston", "Tokyo", "Saint Helier", "Amman", "Astana", "Nairobi", "South Tarawa", "Kuwait City", "Bishkek",
            "Vientiane", "Riga", "Beirut", "Maseru", "Monrovia", "Tripoli", "Vaduz", "Vilnius", "Luxembourg", "Skopje",
            "Antananarivo", "Lilongwe", "Kuala Lumpur", "Malé", "Bamako", "Valletta", "Majuro", "Fort-de-France",
            "Nouakchott", "Port Louis", "Mamoudzou", "Mexico City", "Palikir", "Chișinău", "Monaco", "Ulan Bator",
            "Podgorica", "Plymouth", "Rabat", "Maputo", "Naypyidaw", "Windhoek", "Yaren", "Kathmandu", "Amsterdam",
            "Nouméa", "Wellington", "Managua", "Niamey", "Abuja", "Alofi", "Kingston", "Pyongyang", "Saipan", "Oslo",
            "Muscat", "Islamabad", "Ngerulmud", "Ramallah", "Panama City", "Port Moresby", "Asunción", "Lima", "Manila",
            "Adamstown", "Warsaw", "Lisbon", "San Juan", "Doha", "Pristina", "Saint-Denis", "Bucharest", "Moscow",
            "Kigali", "Gustavia", "Jamestown", "Basseterre", "Castries", "Marigot", "Saint-Pierre", "Kingstown", "Apia",
            "City of San Marino", "São Tomé", "Riyadh", "Dakar", "Belgrade", "Victoria", "Freetown", "Singapore",
            "Philipsburg", "Bratislava", "Ljubljana", "Honiara", "Mogadishu", "Pretoria", "King Edward Point", "Seoul",
            "Juba", "Madrid", "Colombo", "Khartoum", "Paramaribo", "Longyearbyen", "Lobamba", "Stockholm", "Bern",
            "Damascus", "Taipei", "Dushanbe", "Dodoma", "Bangkok", "Dili", "Lomé", "Fakaofo", "Nuku'alofa",
            "Port of Spain", "Tunis", "Ankara", "Ashgabat", "Cockburn Town", "Funafuti", "Kampala", "Kiev", "Abu Dhabi",
            "London", "Washington, D.C.", "Montevideo", "Tashkent", "Port Vila", "Caracas", "Hanoi", "Mata-Utu",
            "El Aaiún", "Sana'a", "Lusaka", "Harare"
        };

        public SelectCity()
        {
            InitializeComponent();
            comboBox1.DataSource = countries;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.updateWeather(comboBox1.Text);
        }
        public void setOwner(Form1 o)
        {
            owner = o;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if(owner.increaseCities(comboBox1.Text)) this.Hide(); 

           
        }

        private void panel1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            owner.cancel();
            this.Hide();
        }
    }
}
