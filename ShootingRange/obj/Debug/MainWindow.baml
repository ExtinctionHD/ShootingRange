   M S B A M L   `   `   `  ����H  DShootingRange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ShootingRangeShootingRange  5   	   G(clr-namespace:ShootingRange.classes.MenuShootingRange.classes.Menu  5   	       ShootingRange.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ShootingRange     5   	   J FWpfAnimatedGif, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   3Menu(clr-namespace:ShootingRange.classes.Menu  5   	   -   5          �Name$  
windowMain��5   ?   $	��864��5
   	   $
��1536��5   	    � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   $%��./classes/Menu/Art/#FuturaBookC)�5   	   .��5      � -   5         �Name$ grMain��5      $��0q�5      .+�5   
   � -   5        $ grGame��5      $��0q�5      .+�5      �� $��0q�6    � Cursor$
 None��5       K� ZIndex$ 1��5       .+�5"      �� -   5         ��Name$ imgCharacterModel��5"      $y�Hidden=�5#       �� Left$ 0��5$      	 �� Bottom$	 0��5%      "  WpfAnimatedGif.ImageBehavior
   RepeatBehavior$
 1x��5&      5'      5)      5+      .   (ShootingRange.classes.Menu.PauseMenuGrid  5-   
   -   5          Name$ grPauseMenu��5-      .   (ShootingRange.classes.Menu.PauseMenuGrid   BtnResumeClick$ btnPauseResume_Click��5.         BtnRestartClick$ btnPauseRestart_Click��5/         BtnMainMenuClick$ btnPauseMainMenu_Click��50      -   'ShootingRange.classes.Menu.ChoiceDialog  52   
   -   5          Name$ 	dlgDefeat��52      -   'ShootingRange.classes.Menu.ChoiceDialog   LeftButtonClick$ dlg_StartGame��59         RightButtonClick$ dlg_Continue��5:         Title$ ПОРАЖЕНИЕ��53         SubTitle$  Начать заново?��54         Left$
 ДА��55         Right$ НЕТ��56         ButtonsWidth$	 120Q�57      ���	#7F0000005:        5<   
   -   5        $ 
dlgVictory��5<      $ dlg_Continue��5C      $ dlgVictory_ShowStats��5D      $ ПРОЙДЕНО��5=      $  Результат: 13 000��5>      $ ПРОДОЛЖИТЬ��5?      $ СТАТИСТИКА��5@      $	 220Q�5A      ���	#7F0000005D      *   $ShootingRange.classes.Menu.StatsGrid  5F   
   -   5          Name$ grStats��5F      *   $ShootingRange.classes.Menu.StatsGrid   ReturnButtonClick$ grStats_btnReturnClick��5G      -   'ShootingRange.classes.Menu.MainMenuGrid  5I   
   -	   5          Name$ 
grMainMenu��5I      -	   'ShootingRange.classes.Menu.MainMenuGrid 	  LvlPreviewClick$ dlg_StartGame��5J      � 5L   
   -
   5        $ grLoadScreen��5L      $
 None��5M      .+�5O      �� -   5        $	 img��5O      $��splashScreen.png��5P      5R      5U      5W      