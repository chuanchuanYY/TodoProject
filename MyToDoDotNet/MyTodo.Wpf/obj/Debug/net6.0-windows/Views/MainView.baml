   M S B A M L   `   `   `  ����E  AMyTodo.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MyTodo.Wpf.ExtensionsMyTodo.Wpf.Extensions  5      3clr-namespace:MyTodo.Wpf.ViewsMyTodo.Wpf.Views  5          MyTodo.Wpf.Views.MainView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2ex#clr-namespace:MyTodo.Wpf.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      *localclr-namespace:MyTodo.Wpf.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5
        � Title$  MainView��5      $
��1080��5      $	��720��5      !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5       � AllowsTransparency$
 True��5      
������� � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � 	Resources 5      ��%    .��5      �� ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      .+�5      �� 
������� J� BitmapEffect 5      F� 5       F� ShadowDepth$	 0.5Q�6-   	 F� Softness$		 0.2Q�6?   ._�5      ]� -   5        
 ]�Name$
 TopZoon��5       $��60��5!      
������ $��False��5#      .+�5%      �� -   5         ��Name$ LeftDrawerOpen��5&      $��	20,0,40,0q�5'      $��Center=�5(      $	����5)      $��25(�5*         IconCheckBox#��[  5+      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5,      /  )Microsoft.Xaml.Behaviors.Core.DataTrigger  5-         Value$ false��6�   :  4Microsoft.Xaml.Behaviors.Core.PropertyChangedTrigger   Binding 6,   ��  �� RelativeSource ��  �� AncestorType CheckBox �� Path$ 	IsChecked�*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5.   "   8  2Microsoft.Xaml.Behaviors.Core.ChangePropertyAction     PropertyName$ Margin��5/   %   4  .Microsoft.Xaml.Behaviors.TargetedTriggerAction   
TargetName$ 
LeftDrawer��50   %      Value$ 
-200 0 0 0��51   %   52        53      $
 true��6�    6,   ��  ��  CheckBox$ 	IsChecked�. 54   "     $ Margin��55   %   $ 
LeftDrawer��56   %   $ 0 0 0 0��57   %   58      5:      �� 5;      $	����5<      $��20(�5=        
IconButton#��[ 5>      �� 5?      $��	20,0,20,0q�5@      $	����5A      $��25(�5B      #��[ 5C      �� 5D      $��Center=�5E      $��20(�5F      $��	笔记本��5G      �� 5I      $��Right=�6!    �� Orientation$ 
Horizontal=�68   .+�5J      �� $��40��5K      $��40��5L      $��0,0,20,0q�5M      $
}�True��5N      $��/Fonts/touxiang.png��5O       J� Clip 5P      @� 5Q   "    @� Center$ 20 20&�5R   %    @� RadiusX$ 20Q�5S   %    @� RadiusY$ 20Q�5T   %   5V      �� 5X      -   5         ��Name$	 Min��5Y      $��10q�5Z      
������ $��0q�5\      $	��─��5]      $��20(�5^      �� 5_      -   5        $	 Max��5`      $��10q�5a      
������ $��0q�5c      $	��☐��5d      $��20(�5e      �� 5f      -   5        $ Close��5g      $��	10,0,30,0q�5h      
������ $��0q�5j      $	��✕��5k      $��20(�5l      5m      5n      5o      �� 5p      $��1��6   !  Prism.Regions.RegionManager   
RegionName$ 
MainRegion��6*   �� 5s      -   5         ��Name$ 
LeftDrawer��5t      $��2��5u      $	��200��5v      $��
-210,0,0,0q�5w      $
��Left=�5x        PrimaryColor2#��[ 5y       5z      F� 5{       F� Opacity$	 0.5Q�5|      $ 0Q�5}      $	 1Q�5~      ._�5�      ]� $��False��6   .+�5�      �� $��0,20,0,0q�6!   $	��Top=�63   .+�5�      �� $��80��5�      $��80��5�      $��Center=�5�      $��/Fonts/touxiang.png��5�      $��UniformToFill=�5�       5�      @� 5�   "   $ 40 40 &�5�   %   $ 40Q�5�   %   $ 40Q�5�   %   5�      �� 5�      $��5q�5�      $��Center=�5�      $��15(�5�      $��DemiBold"�5�        
FontColor1#��[ 5�      $��UserName��5�      5�      �� 5�      $��0,30,0,0q�5�      
������ $	��Top=�5�      .+�5�      	� -	  'MyTodo.Wpf.Extensions.RadioButtonHelper 	  IconText$	 ��5�      $
��Home��5�      $��首页��5�      $��20(�5�      #��[ 5�        RadioButton_MenuButton#��[ 5�      ��5�      �� *
NavCommand+5�      	� 5�      $��0,10,0,0q�5�      $	 ��5�      $
��Todo��5�      $��待办事项��5�      $��20(�5�      #��[ 5�      #��[ 5�      ��5�      �� *
NavCommand+5�      	� 5�      $��0,10,0,0q�5�      $	 ��5�      $
��Memo��5�      $��	备忘录��5�      $��20(�5�      #��[ 5�      #��[ 5�      ��5�      �� *
NavCommand+5�      	� 5�      $��0,10,0,0q�5�      $	 ��5�      $��Setting��5�      $��设置��5�      $��20(�5�      #��[ 5�      #��[ 5�      ��5�      �� *
NavCommand+5�      5�      5�      5�      5�      5�      5�      