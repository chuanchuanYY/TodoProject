   M S B A M L   `   `   `  ����K  GValueConverters, Version=3.0.26.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:ValueConverters;assembly=ValueConvertersValueConverters  5      E AMyTodo.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyTodo.Wpf.CommonMyTodo.Wpf.Common 5      =#clr-namespace:MyTodo.Wpf.ExtensionsMyTodo.Wpf.Extensions 5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089/   )MyTodo.Wpf.Common.TextIsEmptyToVisibility   textisEmptyToVisibility)   #ValueConverters.ValueConverterGroup  TextisEmptyToVisibility    
Converters2   ,ValueConverters.StringIsNullOrEmptyConverter/   )ValueConverters.BoolToVisibilityConverter  
HitTextBox �� 
TargetType �� Property �� Value ��Name �� RelativeSource �� AncestorType �� Path  
FontColor1 �� FallbackValue	 �� Mode  
FontColor2
 �� ElementName �� 	Converter �� Triggers P� Property P� Value �� 
TargetName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ?conv6clr-namespace:ValueConverters;assembly=ValueConverters  5      &cvclr-namespace:MyTodo.Wpf.Common  5      *ex#clr-namespace:MyTodo.Wpf.Extensions  5      %�  &	        &	      &	 I     7  7  7     5      6!     5      .  5	   
       5
   
   5      �� 5      " ��6   .�5   
   ��  � �� 5      �� 5      .R�5      � .+�5      �� $ InputBox��5      $��Center=�5      
������ $��0,0,0,1q�5      ��5      ��  ��  TextBox$ 
Foreground�8   ��5      ��  ��  TextBox$	 TwoWay=�$
 Text��� 5      $��HitLabel��5      8�� ��5      ��  ��  TextBox$  (ex:TextBoxHelper.HitText)�y�5      �� $
 InputBox��$
 Text�8  5       5      P� 5       �@J�	IsFocused$
 true��67   . �5       �� $ HitLabel��6%    � y�$ Hidden=�6Q   5!      5#      5%      5&      5'      