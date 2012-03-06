﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KineticMath.SubControls
{
    /// <summary>
    /// Interaction logic for Bird.xaml
    /// </summary>
    public partial class Bird : SeesawObject
    {
        public static double BIRD_HEIGHT = 110;

        private bool _onLeftSeeSaw;
        public bool OnLeftSeeSaw
        {
            get { return _onLeftSeeSaw; }
            set { 
                _onLeftSeeSaw = value;
                if (value)
                    ValueText.RenderTransform = new ScaleTransform(1, -1);
            }
        }
        
        public String Text
        {
            get { return text; }
            set { 
                text = value;
                ValueText.Text = text;
            }
        }

        public Bird()
        {
            InitializeComponent();
            init("",5);
            
        }

        public Bird(String text, double weight)
        {
            InitializeComponent();
            init(text, weight);
            
        }

        private void init(String text, double weight)
        {
            //BallEllipse.Fill = new SolidColorBrush(DESELECTED_COLOR);
            this.Text = text;
            this.Weight = weight;
            this.Height = BIRD_HEIGHT;
        }
    }
}