   M S B A M L   `   `   `  ���� G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki       Gra_w_statki.CreateMapPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Gra_w_statki       N� Title$  CreateMapPage��.��� -    �Name$ MainGrid��
������� � ColumnDefinitions �� $��3* ��� $��4* � � RowDefinitions �� $
��auto ��� $��4* �.+� � -     �Name$
 dupa��$	��200��$��40���� $��1��$��1��$��3��$��5q�
���   � � -   $ 
BoardFrame��$��1��$��1��  � NavigationUIVisibility$ Hidden=�$��	5 5 10 10q�� $��5q�$��0��$��1�� �� $
��auto ��� $
��auto ��� $��3* ��� $
��1.5* �.+��� $��0��$��Statki do rozstawienia:�� �� TextAlignment$ Center=�$��24(�$
��Wrap=��� $��0��$��3��$��0q�
���   �� $��1�� �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��2q�$��Rodzaj statku:��$��Center=�$��Center=�$��14(�$
��Wrap=�$ Center=��� $��2q�$��1��$��Ilość:��$��Center=�$��Center=�$��14(�$
��Wrap=�$ Center=��� $��2q�$��2��$��Roztawiono:��$��Center=�$��Center=�$��14(�$
��Wrap=�$ Center=��� $��2q�$��3��$��Pozostało:��$��Center=�$��Center=�$��14(�$
��Wrap=�$ Center=�� -   $ ShipAmountInfoGrid�� � ShowGridLines . $��2�����#ccc$��3q� �� $��* ��� $��* ��� $��* ��� $��* � �� $��* �� $��4�� �� $��* ��� $��2* �.+��� -    ��Name$ ResetButton��$��0��$��	20 8 20 8q�
�������$!��Resetuj ustawienie statków���� -   $ ConfirmButton��$��1��$��8q�
�������$&�� Zatwierdź rozstawienie statków��