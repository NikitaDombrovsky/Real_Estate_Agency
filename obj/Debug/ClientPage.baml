   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AgencyAgency  5          Agency.ClientPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Agency     5      -   5          N� Title$  
ClientPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��25 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ clientDataGrid��5         AutoGenerateColumns .     
IsReadOnly .    EnableRowVirtualization . $��10q�6y      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��5   N   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Id+6Z     5      -   5        firstNameColumn��$	 Фамилия��5   \   $

 Auto 6m    6>   �� *	FirstName+6m     5      -   5        middleNameColumn��$	 Имя��5   ^   $

 Auto 6k    6?   �� *
MiddleName+6k     5      -   5        lastNameColumn��$	 Отчество��5   Z   $

 Auto 6l    6=   �� *
LastName+6l     5      -   5        phoneColumn��$	 Телефон��5   T   $

 Auto 6e    6:   �� *Phone+6e     5      -   5        emailColumn��$	 
Почта��5   T   $

 Auto 6c    6:   �� *Email+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5      $

 Auto 6)      CellTemplate 5      �� 5      .R�5      ��  ��Name$ BtnEdit��6=   -	   5        $ ��Редактировать��5   %   6N   5      5!        5"      $

 Auto 6)    5#      �� 5$      .R�5%      �� $ BtnDel��67   -
   5        $��Удалить��5%   %   6G   5&      5(      5*      � 5,   
    K� ZIndex$ -2��6   
�������$��2��63   $��2��6@   �� 5-   
   -   5        $ BtnAdd��5-   $   $��Добавить��6   $��2��64   $��0��6A   $
��Left=�6Q   $	��125��6l   6x   51      52      