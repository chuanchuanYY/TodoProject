   M S B A M L   `   `   `  ����E  AMyTodo.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyTodo.Wpf.CommonMyTodo.Wpf.Common  5      K GValueConverters, Version=3.0.26.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:ValueConverters;assembly=ValueConvertersValueConverters 5      =#clr-namespace:MyTodo.Wpf.ExtensionsMyTodo.Wpf.Extensions  5      C&clr-namespace:MyTodo.Wpf.Views.DialogsMyTodo.Wpf.Views.Dialogs  5	      *    $MyTodo.Wpf.Views.Dialogs.LoginDialog   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2Myconvclr-namespace:MyTodo.Wpf.Common     5      Gconv6clr-namespace:ValueConverters;assembly=ValueConverters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2ex#clr-namespace:MyTodo.Wpf.Extensions     5      8local&clr-namespace:MyTodo.Wpf.Views.Dialogs     5	      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5        � 	Resources  5      )  #ValueConverters.ValueConverterGroup !  FilterTextIsEmptyToVisibility   
Converters2  ,ValueConverters.StringIsNullOrEmptyConverter/  )ValueConverters.BoolToVisibilityConverter4   .MyTodo.Wpf.Common.MultiValueToObjectArrConvert   multiValueToObjectArrConvert��%]   &	        &	 6       5   
   . 5          5      5        5   
   6.   5      #  Prism.Services.Dialogs.Dialog   WindowStyle 5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�WindowStyle$
 None=�6,   �� 5       �@�AllowsTransparency$
 True��63   �� 5       � �� �	#000000006+   -   5        5      .��5      �� -   5         ��Name$ Dialog��5    	   $	��800��5!   	   $	��450��5"   	   
������� �� CornerRadius$ 10��5$   	    J� BitmapEffect 5%   
   F� 5&      	 F� ShadowDepth$	 0Q�6%   ._�5(   
   � 
 � RowDefinitions
 5)      �� 5*      $
��auto �6    �� 5+      .+�5-      �� $��
10,10,20,0q�5.      $��Right=�5/      $	��✕��51      $��20(�52        
IconButton#��[ 53      ��50      �� *CloseCommand+53      �� 54      $��10q�55      $
��Left=�56      $��20(�57      $��DemiBold"�58      $
��Todo��59      ]� 5:      $��1��6   .+�5;      �� $	��550��5<      $
��Left=�5=      $��/Fonts/LoginBack.png��5>      ]� 5?      $��0,0,20,0q�5@      $��Center=�5A      $��False��5B      .+�5C      �� $	��Top=�5D      $��35(�5E      $��DemiBold"�5F      $��欢迎使用��5G      �� 5H      -   5         ��Name$ 
AccountBox��5I      $��	0,20,0,10q�5J      )   #MyTodo.Wpf.Extensions.TextBoxHelper   HitText$ 请输入账号��5K      $��0q�5L      
���   �$	��Top=�5O        
HitTextBox#��[ 5P      �� 5Q      -   5        $ PasswordBox��5R      $ 请输入密码��5S      $��0q�5T      $	��Top=�5U      
���   �#��[ 5W      �� 5X      $��30��5Y      $��0,10,0,0q�5Z      (   "MyTodo.Wpf.Extensions.ButtonHelper   CornerRadius$ 4��5[      ���#673ab7$��0q�5]      $��登 录��5_      $	��Top=�5`      $��DemiBold"�5a      
�������  CornerRadiusButton#��[ 5c      ��5^      �� *LoginCommand+��5d      `� 5e       `� 	Converter# [ 6+   1�5f   "   �� 5g   &    �� ElementName$ 
AccountBox��6.    �� Path$
 Text�6G   �� 5h   &   $ PasswordBox��6.   $
 Text�6H   5j      5l      ]� 5m      $��0,10,0,0q�5n      $	��Top=�5o      $��False��5p      .+�5q      �� $��注册账号��5r      $
��Left=�5s      $��DemiBold"�5t      #��[ 5u      �� 5v      $��忘记密码��5w      $��Right=�5x      $��DemiBold"�5y      #��[ 5z      5{      5|      5}      5~      5      5�      