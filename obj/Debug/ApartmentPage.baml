   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AgencyAgency  5          Agency.ApartmentPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Agency     5      -   5          N� Title$  AppartmentPage��5	      .��5      �  � RowDefinitions 5   
   �� 5   
   $��* �6   �� 5   
   $��25 �6    � ColumnDefinitions 5      �� 5   
   $��* �6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ apartmentDataGrid��5         AutoGenerateColumns .     
IsReadOnly .    EnableRowVirtualization . $��10q�6x      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��1��6�      Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��5   J   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Id+6V     5      -   5        firstNameColumn��$	 Id_Districts��5   \   $

 Auto 6r    6;   �� *Id_Districts+6r     5      -   5        middleNameColumn��$	 
Город��5   \   $

 Auto 6k    6;   �� *Address_City+6k     5      -   5        lastNameColumn��$	 
Улица��5   \   $

 Auto 6k    69   �� *Address_Street+6k     5      -   5        phoneColumn��$	 Дом��5   X   $

 Auto 6e    66   �� *Address_House+6e     5      -   5        emailColumn��$	 
Адрес��5   Y   $

 Auto 6h    66   �� *Address_Number+6h     5      $	 Широта��6J   $

 Auto 6Z    6"   �� *Coordinate_latitude+6Z     5      $	 Долгота��6K   $

 Auto 6\    6"   �� *Coordinate_longitude+6\     5      $	 Площадь��6@   $

 Auto 6Q    6"   �� *	TotalArea+6Q     5      $	 Комнаты��6<   $

 Auto 6M    6"   �� *Rooms+6M     5      $	 
Этажи��6<   $

 Auto 6K    6"   �� *Floor+6K   4  .System.Windows.Controls.DataGridTemplateColumn  5       $

 Auto 6%      CellTemplate 5!      �� 5"      .R�5#      ��  ��Name$ BtnEdit��69   -	   5        $ ��Редактировать��5#   !   6J   5$      5&        5'      $

 Auto 6%    5(      �� 5)      .R�5*      �� $ BtnDel��63   -
   5        $��Удалить��5*   !   6C   5+      5-      5/      � 51       K� ZIndex$ -2��6   
�������$��2��6/   $��2��6<   �� 52      -   5        $ BtnAdd��52       $��Добавить��6   $��2��60   $��0��6=   $
��Left=�6M   $	��125��6h   6t   56      57      