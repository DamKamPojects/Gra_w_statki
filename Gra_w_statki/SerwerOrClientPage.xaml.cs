﻿using System;
using System.Collections.Generic;
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

namespace Gra_w_statki
{
    /// <summary>
    /// Interaction logic for SerwerOrClientPage.xaml
    /// </summary>
    public partial class SerwerOrClientPage : Page
    {
        public SerwerOrClientPage()
        {
            InitializeComponent();
        }

        private void btn_Serwer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(13);
        }

        private void btn_Klient_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangeCurrentPage(12);

        }
    }
}
