   M S B A M L   `   `   `  ����Q  MDashBoard.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:DashBoard.Presentation.ActiveDashBoard.Presentation.Active  5      f bMicrosoft.ReportViewer.WinForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3atSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms 5      ^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5      5    /DashBoard.Presentation.Active.ctlrptActiveAgent   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      ;local+clr-namespace:DashBoard.Presentation.Active    5      `rvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms    5      \myOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration    5      -   5          >�Name$  ucrptActiveAgent��5      $	��404��6   $
��1040��6    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:MyCommands.Barge��5      6;     5   
   -   5        $ local:MyCommands.Hangup��5      6;   .��5      � ��6   ��  �� Path$ Width� �� ElementName$ ucrptActiveAgent�� � ColumnDefinitions 5   
   �� 5      $	��515 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��cnvView1��5      $	��400��6!   $��0��6.   
��� ���$
��Left=�6S   $	��Top=�6n    � 	Resources 5       �� MergedDictionaries �� Source�� 5       5      �� 5      $ ActiveAgent.xaml?�6-   %    5       .+�5#      �� $��Visible=�6   $	��370��6A   ��. $
��0,26q�6f   $��Disabled=�6u   .��5$      �� -   5        	 ��Name$	 
AgentItems��5$      $
��Left=�5%      $	��490��5&      $	��500��6   $	��Top=�5'      5(      5)      �� 5+      -   5        $��stackPanel1��5+   >   
 �� Orientation$
 
Horizontal=�6   $��25��62   $	��500��6Q   ���	#FF1982B6.+�5,      �� -   5        $��lblAgentName��5,   D    �� Left$ 0��6   
 �� Top$ 0��6)   $��25��68   $	��100��6X   
�������$��Center=�6w   $��11(�6�   .��6�   	AgentName6�   �� 5-      -   5        $��lblCampName��5-   E   $	 100��6   $ 0��6*   $��25��69   $��60��6X   
�������$��Center=�6v   $��11(�6�   .��6�   
Campaign6�   �� 5.      -	   5        $��lblCustomerNumber��5.   E   $	 160��6   $ 0��6*   $��25��69   $��80��6^   
�������$��Center=�6|   $��11(�6�   .��6�   Number6�   �� 5/      -
   5        $��lblCallStatus��5/   E   $	 240��6   $ 0��6*   $��25��69   $��80��6Z   
�������$��Center=�6x   $��11(�6�   .��6�   Status6�   �� 50      -   5        $��lblCallDuration��50   E   $	 320��6   $ 0��6*   $��25��69   $��80��6\   
�������$��Center=�6z   $��11(�6�   .��6�   CallDuration6�   �� 51      -   5        $��lblBarge��51   E   $	 400��6   $ 0��6*   $��25��69   $��50��6U   
�������$��Center=�6s   $��11(�6�   .��6�   Barge6�   �� 52      -   5        $��	lblHangUp��52   E   $	 450��6   $ 0��6*   $��25��69   $��50��6V   
�������$��Center=�6t   $��11(�6�   .��6�   HangUp6�   53      55      �� 58   
   -   5        $��cnvView2��58      $	��400��6!   $��1��6.   
��� ���$
��Left=�6S   $	��Top=�6n    5:      �� 5;       5<      �� 5=      $ ActiveAgent.xaml?�6-   %    5?      .+�5B      �� $��Visible=�6   $	��370��6A   ��. $
��0,26q�6f   $��Disabled=�6u   .��5C      �� -   5        $	 AgentItems1��5C      $
��Left=�5D      $	��490��5E      $	��505��6"   $	��Top=�5F      5G      5H      �� 5J      -   5        $��stackPanel2��5J   ]   $
 
Horizontal=�6   $ 0��62   $ 0��6B   $��25��6Q   $	��500��6p   ���	#FF1982B6.+�5K      �� -   5        $��lblAgentName1��5K   ?   $ 0��6   $ 0��6$   $��25��63   $	��100��6T   
�������$��Center=�6s   $��11(�6�   .��6�   	AgentName6�   �� 5L      -   5        $��lblCampName1��5L   A   $	 100��6   $ 0��6&   $��25��65   $��60��6U   
�������$��Center=�6s   $��11(�6�   .��6�   
Campaign6�   �� 5M      -   5        $��lblCustomerNumber1��5M   A   $	 160��6   $ 0��6&   $��25��65   $��80��6[   
�������$��Center=�6y   $��11(�6�   .��6�   Number6�   �� 5N      -   5        $��lblCallStatus1��5N   A   $	 240��6   $ 0��6&   $��25��65   $��80��6W   
�������$��Center=�6u   $��11(�6�   .��6�   Status6�   �� 5O      -   5        $��lblCallDuration1��5O   A   $	 320��6   $ 0��6&   $��25��65   $��80��6Y   
�������$��Center=�6w   $��11(�6�   .��6�   CallDuration6�   �� 5P      -   5        $��	lblBarge1��5P   A   $	 400��6   $ 0��6&   $��25��65   $��50��6R   
�������$��Center=�6p   $��11(�6�   .��6�   Barge6�   �� 5Q      -   5        $��
lblHangUp1��5Q   A   $	 450��6   $ 0��6&   $��25��65   $��50��6S   
�������$��Center=�6q   $��11(�6�   .��6�   HangUp6�   5R      5T      5V      5W      