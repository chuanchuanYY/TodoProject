   M S B A M L   `   `   `  ����E  AMyTodo.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyTodo.Wpf.CommonMyTodo.Wpf.Common  5      K GValueConverters, Version=3.0.26.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:ValueConverters;assembly=ValueConvertersValueConverters 5      =#clr-namespace:MyTodo.Wpf.ExtensionsMyTodo.Wpf.Extensions  5      3clr-namespace:MyTodo.Wpf.ViewsMyTodo.Wpf.Views  5
          MyTodo.Wpf.Views.TodoView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2MyConvclr-namespace:MyTodo.Wpf.Common     5      Gconv6clr-namespace:ValueConverters;assembly=ValueConverters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2ex#clr-namespace:MyTodo.Wpf.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      *localclr-namespace:MyTodo.Wpf.Views  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      ! 	 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5         PrimaryColor1#��[  5       � 	Resources 5        TodoView �� Source)  #ValueConverters.ValueConverterGroup ! FilterTextIsEmptyToVisibility   
Converters2  ,ValueConverters.StringIsNullOrEmptyConverter/  )ValueConverters.BoolToVisibilityConverter4   .MyTodo.Wpf.Common.MultiValueToObjectArrConvert   multiValueToObjectArrConvert��%�   &	       &	 ;     &	 q     �� 5   
   -   5         5      �� *
TodoList+  5   
   . 5          5      5        5   
   6.   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       .+�5#   
   ]� $��
10,10,0,10q�6   $��False��6(   .+�5$      �� $	��200��6   $
��Left=�6!   .+�5%      �� -   5         ��Name$ 	SearchBox��5&      $	��200��5'      $��20��5(      
������ $��0,0,0,1q�5*        
FontColor1#��[ 5+      5,      �� 5-      $��Center=�5.        
FontColor2#��[ 5/      y�50      ��  �� ElementName$ 	SearchBox�� �� Path$
 Text� �� 	Converter# [ .��6�   查找代办事项...52      53      �� 54      $��	10,0,10,0q�55      $��Center=�56      #��[ 57      $��筛选:��58      �� 59      -   5        	 ��Name$	 FilterCondition��5:      $��80��5;      $��0,0,0,1q�5<      
�������
 �� SelectedIndex$
 0��5?        ComboBoxStyle1#��[ 5A      ��5>      �� *FilterCondition+5A      �� 5B      $��90��5C      $��0,0,10,0q�5D      (   "MyTodo.Wpf.Extensions.ButtonHelper   CornerRadius$ 2��5E      ���#3f9546$��0q�5G      $��+ 添加代办��5I      $��Right=�5J      $��DemiBold"�5K        CornerRadiusButton#��[ 5L      ��5H      �� *AddTotoCommand+5L      5M      �� 5O   
   -   5         ��Name$ todoListView��5P      $��1��5Q      $��	30,0,30,0q�5R      $��Center=�5S      #��[  5T      $��0q�5U      $��Hidden=�5W      ��5V      ��  �� Source# [ ��5Y      �� 5Z      .R�5[      � 5\      ��5_      �� 5`      .R�5a      �� $	��150��5b      $	��130��5c      $��8q�5d      ���#10b136 �� CornerRadius$ 4��5f      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5g      +  %Microsoft.Xaml.Behaviors.EventTrigger  5h         	EventName$ MouseLeftButtonDown��6-   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5i   "   2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
   
  Command 68   �� *DataContext.ModifyTotoCommand+ �� RelativeSource ��  �� AncestorType UserControl 
  CommandParameter 5j   &   `� 5k   *    `� 	Converter# [ 67   1�5l   .   �� 5m   2   $ Id�6:   �� 5n   2   $ Title�6:   �� 5o   2   $ Content�6:   �� 5p   2   $ IsCompleted�6:   5r   +   5t   #   5u       J� BitmapEffect 5w      F� 5x       F� ShadowDepth$ 0Q�65    F� Softness$ 0Q�6E   ._�5z      ]� $��10q�6$   .+�5{      �� $��Right=�5|   !   $��Right=�5}   !   #��[ 5~   !     IconTextBlock#��[ 5   !   $	����5�   !   �� 5�      $
��Left=�5�   !   $	��Top=�5�   !   $��DemiBold"�5�   !   #��[ 5�   !   ��5�   !   �� *Title+�� 5�      
������ $��0q�5�   !   #��[ 5�   !    �� 
IsReadOnly$
 True��5�   !   ��5�   !   �� *	Content+5�      5�      5�      5�      5�      5�      