   M S B A M L   `   `   `  ���� G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  !    Gra_w_statki.GameWindowPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Gra_w_statki       N� Title$  GameWindowPage��.��� 
������� � RowDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� $��Bitwa!��$��Center=�$��36(�� $��1�� � ColumnDefinitions �� $��4* ��� $��4* �.+� � -     �Name$ 
BoardFrame��$��1��$��1��  � NavigationUIVisibility$ Hidden=�$��	5 5 10 10q��� $��1��$��1��$��3��$��5q�
���   ��� $��1��$��0��$��3��$��5q�
���   ��  �� $
��auto ��� $��7* ��� $��2* �.+��� $��5q�$��24(�$��0��$��Gracz��$��Center=� � -   $ OurBoardFrame��$��1��$��1��$ Hidden=�$��
10 5 10 10q�� $��3�� �� $
��auto ��� $��* �.+��� $��2q�$��16(�$��0��$&�� Pozostałe niezatopione okręty:��$��Center=��� -    ��Name$ OurShipsStackPanel��$��1��$��Center=�$��Center=� �� Orientation$ 
Horizontal=�� $��1�� �� $
��auto ��� $��7* ��� $��2* �.+��� $��5q�$��24(�$��0��$��
Przeciwnik��$��Center=� � -   $ EnemyBoardFrame��$��1��$��1��$ Hidden=�$��
10 5 10 10q�� $��3�� �� $
��auto ��� $��* �.+��� $��2q�$��16(�$��0��$&�� Pozostałe niezatopione okręty:��$��Center=��� -   $ EnemyShipsStackPanel��$��1��$��Center=�$��Center=�$ 
Horizontal=��� $��Poddaj się��$��2��$��5q�$	��200��$��20��