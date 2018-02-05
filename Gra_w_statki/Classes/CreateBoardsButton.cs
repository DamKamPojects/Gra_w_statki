using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gra_w_statki
{

    //sluzy do tworzenia buttonow wypelniajacych pole oraz indeksow
    class CreateBoardsButton
    {
        private double ButtonMargin = 0.2;

        //tworzy podpis osi X
        public TextBlock CreateTextBlock_X(int index)
        {
            TextBlock xDescriptionBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = Convert.ToString(index),
                Margin = new Thickness(ButtonMargin)
            };

            Grid.SetRow(xDescriptionBlock, 0);
            Grid.SetColumn(xDescriptionBlock, index);
            return xDescriptionBlock;
        }

        //tworzy podpis osi Y
        public TextBlock CreateTextBlock_Y(int index)
        {
            TextBlock yDescriptionBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = Convert.ToString(Convert.ToChar(64 + index)),
                Margin = new Thickness(ButtonMargin)
            };
            Grid.SetRow(yDescriptionBlock, index);
            Grid.SetColumn(yDescriptionBlock, 0);
            return yDescriptionBlock;
        }

        public Button CreateButton(int indexX, int indexY)
        {
            Button FieldButton = new Button()
            {
                //Content = "x" + indexX + "y" + indexY,
                Margin = new Thickness(ButtonMargin, ButtonMargin, ButtonMargin, ButtonMargin),
                Background = Brushes.White,
                Name = "x" + indexX + "y" + indexY,
            };

            //FieldButton.ToolTip = "Współrzędne pola:" + Environment.NewLine + "X=" + indexX+ " Y=" + in Convert.ToString(FieldButton.Name);
            FieldButton.ToolTip = "Współrzędne pola:" + Environment.NewLine + "             "+Convert.ToChar(64 + indexX) + indexY;
            
            Grid.SetRow(FieldButton, indexX);
            Grid.SetColumn(FieldButton, indexY);

            return FieldButton;
        }
    }
}
