   M S B A M L   `   `   `  ���� G  CGra_w_statki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Gra_w_statkiGra_w_statki  "    Gra_w_statki.GameOptionsPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Gra_w_statki       N� Title$  GameOptionsPage��.��� 
������� � ColumnDefinitions �� $��* � � RowDefinitions �� $
��auto ��� $��5* ��� $��3* ��� $
��1.5* �.+��� $B��<Ustaw rozmiar planszy oraz ilość poszczególnych statków:��$��40(�$
��Wrap=� �� TextAlignment$ Center=�$��7q�� $��1��$��5q� �� $��2* ��� $��1* �.+��� $��0��
���   �$��5q��� $��1��
���   �$��5q�� $��0��$��0��$��10q� �� $��* ��� $��* ��� $��* � �� $
��auto ��� $��2* ��� $��2* �.+��� $��3��$��Rozmiar planszy:��$ Center=�$��Center=�$��30(��� $��1��$��0��$��Center=�$��Center=�.+��� $��30(�$ Center=�$	��6x6��	� -    	�Name$ rb_Size6�� 	� 	GroupName$ 	BoardSize��$��14�� d� 	IsChecked$
 TrueY��� $��1��$��1��$��Center=�$��Center=�.+��� $��30(�$ Center=�$	��8x8��	� -   $ rb_Size8��$ 	BoardSize��$��14���� $��1��$��2��$��Center=�$��Center=�.+��� $��30(�$ Center=�$��10x10��	� -   $ 	rb_Size10��$ 	BoardSize��$��14��$ FalseY��� $��2��$��0��$��Center=�$��Center=�.+��� $��30(�$ Center=�$��12x12��	� -   $ 	rb_Size12��$ 	BoardSize��$��14���� $��2��$��1��$��Center=�$��Center=�.+��� $��30(�$ Center=�$��14x14��	� -   $ 	rb_Size14��$ 	BoardSize��$��14���� $��2��$��2��$��Center=�$��Center=�.+��� $��30(�$ Center=�$��16x16��	� -   $ 	rb_Size16��$ 	BoardSize��$��14��� $��1��$��10q� �� $
��auto ��� $��6* �.+��� $��Ilość staków:��$��30(�$
��Wrap=�$ Center=�� $��1�� �� $��* ��� $��* ��� $��* � �� $��1* ��� $��3* �.+��� $��0��$��1��$��30(�$ Center=�$��Mała��$
��left=�$��Center=�	� -   $ 	rb_little��$��0��$��0��$��14��$��Center=�$��Center=��� $��1��$��1��$��30(�$ Center=�$��Średnia��$
��left=�$��Center=�	� -   $ 	rb_normal��$��1��$��0��$��14��$��Center=�$��Center=�$
 TrueY��� $��2��$��1��$��30(�$ Center=�$��Duża��$
��left=�$��Center=�	� -	   $ rb_many��$��2��$��0��$��14��$��Center=�$��Center=��� $��2��$��0��
���   �$��	10 0 10 5q�� -
    �Name$ ShipCategoriesGrid��$��2�� �� $
��auto ��� $��* �.+��� $��Statki dostępne w grze:��$��30(�$
��Wrap=�$ Center=�$��Center=�$��
20 5 20 5 q��� -    ��Name$ AvailableShipsStackPanel��$��Center=�$��Center=�$��1��	 �� Orientation$	 
Horizontal=��� -   
 ��Name$
 
PlayButton��$��3��$��	50 5 50 5q�$��2q�$��Graj!��$��26(�
�������