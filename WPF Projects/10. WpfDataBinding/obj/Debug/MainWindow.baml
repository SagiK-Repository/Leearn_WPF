   M S B A M L   `   `   `  ????M  I_10.WpfDataBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:_10.WpfDataBinding_10.WpfDataBinding  5   	   #    _10.WpfDataBinding.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:_10.WpfDataBinding     5   	     ? Title$  
MainWindow??5   	   $	??230??6   $	??284??6)   .??5	      ??  ?? Orientation$ Vertical=?6   $??20q?6(   .+?5
   
   ?? $??Which city do you love??6   ?? 5   
   $??SEOUL??6    d? 	IsChecked 6#   ?? *Seoul+?? 5   
   $??JEJOO??6    6#   ?? *Jejoo+?? 5   
   $??INCHEON??6    6%   ?? *	Incheon+?? 5   
   -   5        $??제출??5      6   ?? 5   
   -   5        $
??txt1??5      ??6   ??  ?? Mode$ OneWay=??? 5   
   -   5         ??Name$
 txt2??5      ??6    ?? *Text+ ?? Source %  System.Windows.Markup.Reference  *txt1+ ?? UpdateSourceTrigger$ PropertyChanged=?5      5      