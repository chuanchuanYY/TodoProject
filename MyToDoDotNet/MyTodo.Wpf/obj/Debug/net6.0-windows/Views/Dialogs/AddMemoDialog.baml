   M S B A M L   `   `   `  ����E  AMyTodo.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MyTodo.Wpf.ExtensionsMyTodo.Wpf.Extensions  5      C&clr-namespace:MyTodo.Wpf.Views.DialogsMyTodo.Wpf.Views.Dialogs  5      ,    &MyTodo.Wpf.Views.Dialogs.AddMemoDialog   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2ex#clr-namespace:MyTodo.Wpf.Extensions     5      8local&clr-namespace:MyTodo.Wpf.Views.Dialogs     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      $	��320��5
      $	��220��5      #  Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�WindowStyle$
 None=�6,   �� 5       �@�AllowsTransparency$
 True��63   �� 5       � �� �	#000000006+   5      .��5      ��    PrimaryColor2#��[  6    �� CornerRadius$ 5��69    J� BitmapEffect 5   
   F� 5       F� ShadowDepth$ 1Q�6%    F� Softness$ 1Q�65   ._�5   
   ]� $��10q�6   $��False��6    .+�5      �� $	��Top=�5      $��15(�5        
FontColor1#��[ 5      $��添加备忘录��5      �� 5       $��0,5,0,0q�5!      )   #MyTodo.Wpf.Extensions.TextBoxHelper   HitText$ 请输入备忘录概要��5"      $	��Top=�5#      #��[ 5$        
HitTextBox#��[ 5%      ��5&      �� *	MemoTitle+�� 5'      $��0,5,0,0q�5(      $	��Top=�5)        
FontColor2#��[ 5*      $��请输入备忘录内容��5+      �� 5-      $��60��5.      $��0,5,0,0q�5/      	 �� AcceptsReturn$
	 True��50      
������ $��0,0,0,1q�52      $	��Top=�53      #��[ 54      
 �� TextWrapping$

 Wrap=�56      ��55      �� *	Content+56      �� 57      $��Bottom=�58      $��Right=�59       �� Orientation$ 
Horizontal=�5:      .+�5;      �� $��40��5<      $��20��5=      (   "MyTodo.Wpf.Extensions.ButtonHelper   CornerRadius$ 2��5>      
������ ���#13b237$��1q�5A      $��取消��5C      #��[ 5D        CornerRadiusButton#��[ 5E      ��5B      �� *RequestCloseCommand+5E      �� 5F      $��40��5G      $��20��5H      $��5,0,0,0q�5I      $ 2��5J      ���#13b237���#13b237$��确定��5N      #��[ 5O      #��[ 5P      ��5M      �� *SubmitCommand+5P      5Q      5R      5S      5T      