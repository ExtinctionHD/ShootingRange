   M S B A M L   `   `   `  ����H  DShootingRange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ShootingRange.classes.MenuShootingRange.classes.Menu  5      -    'ShootingRange.classes.Menu.MainMenuGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ShootingRange.classes.Menu     5      -   5          >�Name$  controlMainMenu��5      $��./Art/#FuturaBookC)�5
      ��5      �� 5   
    �� ImageSource$ Art/menuBg.jpg��6    j� Stretch$ UniformToFill=�62   .��5      � .+�5   
   � $��0q�6   ���	#7F000000 � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      .+�5      �� $��Bottom=�6   $	��2.5��5      $��0, 50q�5      
������� J� Opacity$	 0.3Q�5      � 5      $
��Left=�6   $��Center=�5      $��100, 0q�5        � ColumnDefinitions 5!      �� 5"      �� 5#      �� 5$      .+�5'      	� -   5         	�Name$ btnLvlChoose��5'      $��ВЫБОР КАРТЫ��5(         MenuButtons#��[  5)      $��Center=�5*      $��Center=�5+      $��36(�5,      $��0, 50q�5-       d� 	IsChecked$
 TrueY�5.      	� 50      -   5        $ btnStats��50      $��СТАТИСТИКА��51      $��1��52      #��[  53      $��Center=�54      $��Center=�55      $��36(�56      $��0, 50q�57      	� 59      -   5        $ 
btnControl��59      $��УПРАВЛЕНИЕ��5:      $��2��5;      #��[  5<      $��Center=�5=      $��Center=�5>      $��36(�5?      $��0, 50q�5@      5A      � 5C      $��1��6   $��100, 0, 100, 50q�5D      y�5E      ��  �� ElementName$ btnLvlChoose��	 �� Path$	 	IsChecked�  	BoolToVis
 �� 	Converter#
 [  5F      �� 5G      $
��Auto �6'   �� 5H      �� 5I      $
��Auto �6'   .+�5L      �� -   5          
ButtonNext#��[ 5L      $��2��5M      $��Center=�5N      $��Center=�5O      $��80��5P      5Q      �� 5S      -   5          
ButtonPrev#��[ 5S      $��0��5T      $��Center=�5U      $��Center=�5V      $��80��5W      5X      +   %ShootingRange.classes.Menu.LvlPreview  5Z      -   5          Name$ 
lvlPreview��5Z   #   +   %ShootingRange.classes.Menu.LvlPreview   LvlPreviewClick$ lvlPreview_Click��5]   #   $��1��5[   #   $��50q�5\   #   5]   #   5_      � 5a      $��1��6   $��Center=�5b      $��Center=�5c      $��0, 0, 0, 50q�5d      y�5e      �� $ btnStats��$	 	IsChecked�#
 [  5g      �� 5h      $	��320 �6'   �� 5i      $	��320 �6'   �� 5j      $	��320 �6'    5l      �� 5m      �� 5n      �� 5o      .+�5r      �� $��0��6   $	��Top=�5s      $��1��5t      
�������5u      �� 5v      $��1��6   $	��Top=�5w      $��1��5x      
�������5y      �� 5z      $��2��6   $	��Top=�5{      $��1��5|      
�������5}      �� 5      $��0��6   $��2��5�      $��Bottom=�5�      $��1��5�      
�������5�      �� 5�      $��1��6   $��2��5�      $��Bottom=�5�      $��1��5�      
�������5�      �� 5�      $��2��6   $��2��5�      $��Bottom=�5�      $��1��5�      
�������5�      � 5�      $��0��6   $��0��5�      $
��Left=�5�      $��Center=�5�      $��
60,30,0,30q�5�       5�      �� 5�      �� 5�      .+�5�      �� $��ВЫСТРЕЛОВ��6   $��0��5�      $
��Left=�5�      $��Center=�5�      
�������$��24(�5�      ��5�      �� *
FontFamily+$ controlMainMenu���� 5�      $��1��5�      $
��Left=�5�      $��Center=�5�      
�������$��48(�5�      $
��Bold"�5�      ��5�      �� *Shoots+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >���5�      �� *
FontFamily+$ controlMainMenu��5�      � 5�      $��0��6   $��1��5�      $
��Left=�5�      $��Center=�5�      $��
60,30,0,30q�5�       5�      �� 5�      �� 5�      .+�5�      �� $��УБИЙСТВ��6   $��0��5�      $
��Left=�5�      $��Center=�5�      
�������$��24(�5�      ��5�      �� *
FontFamily+$ controlMainMenu���� 5�      $��1��5�      $
��Left=�5�      $��Center=�5�      
�������$��48(�5�      $
��Bold"�5�      ��5�      �� *Kills+ �� *FindAncestor+" >���5�      �� *
FontFamily+$ controlMainMenu��5�      � 5�      $��0��6   $��2��5�      $
��Left=�5�      $��Center=�5�      $��
60,30,0,30q�5�       5�      �� 5�      �� 5�      .+�5�      �� $��В ГОЛОВУ��6   $��0��5�      $
��Left=�5�      
�������$��24(�5�      ��5�      �� *
FontFamily+$ controlMainMenu���� 5�      $��1��5�      $
��Left=�5�      $��Center=�5�      
�������$��48(�5�      $
��Bold"�5�      ��5�      �� *	Headshots+ �� *FindAncestor+" >���5�      �� *
FontFamily+$ controlMainMenu��5�      � 5�      $��1��6   $��0��5�      $
��Left=�5�      $��Center=�5�      $��
60,30,0,30q�5�       5�      �� 5�      �� 5�      .+�5�      �� $��ВРЕМЯ ИГРЫ��6   $��0��5�      $
��Left=�5�      $��Center=�5�      
�������$��24(�5�      ��5�      �� *
FontFamily+$ controlMainMenu���� 5�      $��1��5�      $
��Left=�5�      $��Center=�5�      
�������$��48(�5      $
��Bold"�5     ��5�      �� *
PlayTime+ �� *FindAncestor+" >���5     �� *
FontFamily+$ controlMainMenu��5     � 5     $��1��6   $��1��5     $
��Left=�5     $��Center=�5	     $��
60,30,0,30q�5
      5     �� 5     �� 5     .+�5     �� $��ТОЧНОСТЬ��6   $��0��5     $
��Left=�5     $��Center=�5     
�������$��24(�5     ��5     �� *
FontFamily+$ controlMainMenu���� 5     $��1��5     $
��Left=�5     $��Center=�5     
�������$��48(�5     $
��Bold"�5     ��5     �� *
Accuracy+ �� *FindAncestor+" >���5      �� *
FontFamily+$ controlMainMenu��5"     � 5$     $��1��6   $��2��5%     $
��Left=�5&     $��Center=�5'     $��
60,30,0,30q�5(      5*     �� 5+     �� 5,     .+�5/     �� $��УВС��6   $��0��50     $
��Left=�51     $��Center=�52     
�������$��24(�54     ��55     �� *
FontFamily+$ controlMainMenu���� 57     $��1��58     $
��Left=�59     $��Center=�5:     
�������$��48(�5<     $
��Bold"�5=     ��57     �� *KPS+ �� *FindAncestor+" >���5>     �� *
FontFamily+$ controlMainMenu��5@     � 5B     $��2��6   $��0��5C     $
��Left=�5D     $��Center=�5E     $��
60,30,0,30q�5F      5H     �� 5I     �� 5J     .+�5M     �� $��
ПОБЕД��6   $��0��5N     $
��Left=�5O     $��Center=�5P     
�������$��24(�5R     ��5S     �� *
FontFamily+$ controlMainMenu���� 5U     $��1��5V     $
��Left=�5W     $��Center=�5X     
�������$��48(�5Z     $
��Bold"�5[     ��5U     �� *	Winrate+ �� *FindAncestor+" >���5\     �� *
FontFamily+$ controlMainMenu��5^     � 5`     $��2��6   $��1��5a     $
��Left=�5b     $��Center=�5c     $��
60,30,0,30q�5d      5f     �� 5g     �� 5h     .+�5k     �� $��ВСЕГО ИГР��6   $��0��5l     $
��Left=�5m     $��Center=�5n     
�������$��24(�5p     ��5q     �� *
FontFamily+$ controlMainMenu���� 5s     $��1��5t     $
��Left=�5u     $��Center=�5v     
�������$��48(�5x     $
��Bold"�5y     ��5s     �� *Games+ �� *FindAncestor+" >���5z     �� *
FontFamily+$ controlMainMenu��5|     � 5~     $��2��6   $��2��5     $
��Left=�5�     $��Center=�5�     $��
60,30,0,30q�5�      5�     �� 5�     �� 5�     .+�5�     �� $��ВСЕГО ОЧКОВ��6   $��0��5�     $
��Left=�5�     $��Center=�5�     
�������$��24(�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $��1��5�     $
��Left=�5�     $��Center=�5�     
�������$��48(�5�     $
��Bold"�5�     ��5�     �� *Score+ �� *FindAncestor+" >���5�     �� *
FontFamily+$ controlMainMenu��5�     5�     � 5�     $��1��6   $��0, 0, 0, 50q�5�     $��Center=�5�     $��Center=�5�     y�5�     �� $ 
btnControl��$	 	IsChecked�#
 [  5�     �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   .+�5�     �� $	��Top=�6   $��1��5�     
�������5�     �� 5�     $��4��6   $��Bottom=�5�     $��1��5�     
�������5�     �� 5�     $��ЛКМ��6   $��0��5�     $
��Left=�5�     $��Center=�5�     $��60, 15q�5�     
�������$��48(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $��Стрельба��6   $��0��5�     $
��Left=�5�     $��Center=�5�     $��300, 15, 60, 15q�5�     
�������$��24(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $��ПКМ��6   $��1��5�     $
��Left=�5�     $��Center=�5�     $��60, 15q�5�     
�������$��48(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $3��-Прицеливание удержанием��6   $��1��5�     $
��Left=�5�     $��Center=�5�     $��300, 15, 60, 15q�5�     
�������$��24(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $��R��6   $��2��5�     $
��Left=�5�     $��Center=�5�     $��60, 15q�5�     
�������$��48(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $��Перезарядка��6   $��2��5�     $
��Left=�5�     $��Center=�5�     $��300, 15, 60, 15q�5�     
�������$��24(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $��S��6   $��3��5�     $
��Left=�5�     $��Center=�5�     $��60, 15q�5�     
�������$��48(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5�     $%��Пропустить песню��6   $��3��5�     $
��Left=�5�     $��Center=�5�     $��300, 15, 60, 15q�5�     
�������$��24(�5�     $
��Bold"�5�     ��5�     �� *
FontFamily+$ controlMainMenu���� 5      $	��ESC��6   $��4��5     $
��Left=�5     $��Center=�5     $��60, 15q�5     
�������$��48(�5     $
��Bold"�5     ��5     �� *
FontFamily+$ controlMainMenu���� 5	     $��Меню паузы��6   $��4��5
     $
��Left=�5     $��Center=�5     $��300, 15, 60, 15q�5     
�������$��24(�5     $
��Bold"�5     ��5     �� *
FontFamily+$ controlMainMenu��5     �� 5     -   5          
ButtonExit#��[ 5     $��1��5     $��48��5     $��10q�5     $
��Left=�5     $��Bottom=�5     5     5     5      5!     