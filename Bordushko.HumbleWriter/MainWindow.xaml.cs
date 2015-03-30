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
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace Bordushko.HumbleWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontSizeComboBox.ItemsSource = new List<double>() { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Rich Text Format (*.rtf) | *.rtf|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
	        {
                FileStream fStream = new FileStream(dialog.FileName, FileMode.Open);
                TextRange range = new TextRange(mainRichTextBox.Document.ContentStart, mainRichTextBox.Document.ContentEnd);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
	        }
        }

        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Rich Text Format (*.rtf) | *.rtf|All files (*.*)|*.*";
            
            if (dialog.ShowDialog() == true)
            {
                FileStream fStream = new FileStream(dialog.FileName, FileMode.CreateNew);
                TextRange range = new TextRange(mainRichTextBox.Document.ContentStart, mainRichTextBox.Document.ContentEnd);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();
            }
            
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                mainRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.Text);
            }
        }

        private void fontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontSizeComboBox.SelectedItem != null)
            {
                mainRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
            }
        }

        private void mainRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //object temp = mainRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty);
            
        }
    }
}
