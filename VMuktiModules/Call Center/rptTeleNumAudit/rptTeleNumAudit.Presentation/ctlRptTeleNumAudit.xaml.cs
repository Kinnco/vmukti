﻿/* VMukti 2.0 -- An Open Source Video Communications Suite
*
* Copyright (C) 2008 - 2009, VMukti Solutions Pvt. Ltd.
*
* Hardik Sanghvi <hardik@vmukti.com>
*
* See http://www.vmukti.com for more information about
* the VMukti project. Please do not directly contact
* any of the maintainers of this project for assistance;
* the project provides a web site, forums and mailing lists      
* for your use.

* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.

* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.

* You should have received a copy of the GNU General Public License
* along with this program. If not, see <http://www.gnu.org/licenses/>
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using VMuktiAPI;
using rptTeleNumAudit.Business;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Reflection;

namespace rptTeleNumAudit.Presentation
{  
    //set permission for module Report TeleNumAudit
    public enum ModulePermissions
    {
        Add = 0,
        Edit = 1,
        Delete = 2,
        View = 3
    }
    public partial class ctlRptTeleNumAudit : UserControl
    {
        //public static StringBuilder sb1;

        DataSet dsReport = new dsTeleNumAudit();
        ReportDataSource rds = new ReportDataSource();

        //public static StringBuilder CreateTressInfo()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("User Is : " + VMuktiAPI.VMuktiInfo.CurrentPeer.DisplayName);
        //    sb.AppendLine();
        //    sb.Append("Peer Type is : " + VMuktiAPI.VMuktiInfo.CurrentPeer.CurrPeerType.ToString());
        //    sb.AppendLine();
        //    sb.Append("User's SuperNode is : " + VMuktiAPI.VMuktiInfo.CurrentPeer.SuperNodeIP);
        //    sb.AppendLine();
        //    sb.Append("User's Machine Ip Address : " + VMuktiAPI.GetIPAddress.ClsGetIP4Address.GetIP4Address());
        //    sb.AppendLine();
        //    sb.AppendLine("----------------------------------------------------------------------------------------");
        //    return sb;
        //}

        public ctlRptTeleNumAudit(ModulePermissions[] MyPermissions)
        {
            try
            {
                InitializeComponent();
                
                this.Loaded += new RoutedEventHandler(ctlRptRemainingLeads_Loaded);
                this.Loaded += new RoutedEventHandler(ctlRptTeleNumAudit_Loaded);

                System.Data.DataSet ds = rptTeleNumAudit.Business.ClsRptTeleNumAudit.GetAllCampaign();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboBoxItem cbi = new ComboBoxItem();
                        cbi.Content = ds.Tables[0].Rows[i][0].ToString();
                        cbi.Tag = ds.Tables[0].Rows[i][1].ToString();

                        cmbCampaign.Items.Add(cbi);
                    }
                }
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "ctlRptTeleNumAudit()", "ctlRptTeleNumAudit.xaml.cs");
            }



            //public ctlRptTeleNumAudit()
            //{
            //    InitializeComponent();

            //    System.Data.DataSet ds = rptTeleNumAudit.Business.ClsRptTeleNumAudit.GetAllCampaign();
            //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            ComboBoxItem cbi = new ComboBoxItem();
            //            cbi.Content = ds.Tables[0].Rows[i][0].ToString();
            //            cbi.Tag = ds.Tables[0].Rows[i][1].ToString();

            //            cmbCampaign.Items.Add(cbi);
            //        }
            //    }
            //}
        }

        //select Campaign from comboBox..
        private void cmbCampaign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmbList.Items.Clear();
                //select data using GetAllListOfCampaign function from rptTeleNumAudit.Business
                System.Data.DataSet ds = rptTeleNumAudit.Business.ClsRptTeleNumAudit.GetAllListOfCampaign(int.Parse(((ComboBoxItem)cmbCampaign.SelectedItem).Tag.ToString()));
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboBoxItem cbi = new ComboBoxItem();
                        cbi.Content = ds.Tables[0].Rows[i][0].ToString();
                        cbi.Tag = ds.Tables[0].Rows[i][1].ToString();
                        //add compaign to comboBox
                        cmbList.Items.Add(cbi);
                    }
                }
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "cmbCampaign_SelectionChanged()", "ctlRptTeleNumAudit.xaml.cs");
            }
        }
        //Generate Report after clicking Go..
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                wfhRptViewer.Visibility = Visibility.Visible;
                //get data using GetTeleNumAudit function from rptTeleNumAudit.Business
                dsReport = Business.ClsRptTeleNumAudit.GetTeleNumAudit(Int64.Parse(((ComboBoxItem)cmbTeleNumber.SelectedItem).Content.ToString()));
                if (dsReport.Tables.Count > 0)
                {
                    dsReport.Tables[0].TableName = "dtTeleNumAudit";
                }

                rds.Name = "dsTeleNumAudit_dtTeleNumAudit";
                //set value for report viewer
                rds.Value = dsReport.Tables["dtTeleNumAudit"];

                objReportViewer.LocalReport.ReportPath = Assembly.GetAssembly(this.GetType()).Location.Replace("rptTeleNumAudit.Presentation.dll", "rptTeleNumAudit.rdlc");
                objReportViewer.LocalReport.ReportEmbeddedResource = Assembly.GetAssembly(this.GetType()).Location.Replace("rptTeleNumAudit.Presentation.dll", "rptTeleNumAudit.rdlc");
                objReportViewer.LocalReport.DataSources.Add(rds);
                objReportViewer.RefreshReport();
            }

            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "btnGo_Click()", "ctlRptTeleNumAudit.xaml.cs");
            }
        }

        //select telenum from comboBox..
        private void cmbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmbTeleNumber.Items.Clear();
                //select data using GetAllListOfNumber function from rptTeleNumAudit.Business
                System.Data.DataSet ds = rptTeleNumAudit.Business.ClsRptTeleNumAudit.GetAllListOfNumber(int.Parse(((ComboBoxItem)cmbList.SelectedItem).Tag.ToString()));
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboBoxItem cbi = new ComboBoxItem();
                        cbi.Content = ds.Tables[0].Rows[i][0].ToString();
                        cbi.Tag = ds.Tables[0].Rows[i][1].ToString();
                        //add TeleNumber to comboBox
                        cmbTeleNumber.Items.Add(cbi);
                    }
                }

            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "cmbList_SelectionChanged()", "ctlRptTeleNumAudit.xaml.cs");
            }




        }
        #region changes for reportviewer resiging

        void ctlRptTeleNumAudit_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Parent != null)
                {
                    if (this.Parent.GetType() == typeof(Grid))
                    {
                        this.Width = ((Grid)this.Parent).ActualWidth;
                        this.Height = ((Grid)this.Parent).ActualHeight;
                        wfhRptViewer.Height = ((Grid)this.Parent).ActualHeight - 150.0;
                        ((Grid)this.Parent).SizeChanged += new SizeChangedEventHandler(ctlRptTeleNumAudit_SizeChanged);
                    }
                    else if (this.Parent.GetType() == typeof(TabItem))
                    {

                        ((TabControl)((TabItem)this.Parent).Parent).SizeChanged += new SizeChangedEventHandler(ctlRptRemainingLeads_SizeChanged);
                        this.Width = ((TabControl)((TabItem)this.Parent).Parent).ActualWidth;
                        this.Height = ((TabControl)((TabItem)this.Parent).Parent).ActualHeight;
                        wfhRptViewer.Height = ((TabControl)((TabItem)this.Parent).Parent).ActualHeight - 150.0;
                        wfhRptViewer.Width = ((TabControl)((TabItem)this.Parent).Parent).ActualWidth - 130.0;
                    }
                }
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "ctlRptTeleNumAudit_Loaded()", "ctlRptTeleNumAudit.xaml.cs");
            }
        }

        void ctlRptRemainingLeads_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Parent != null)
                {
                    if (this.Parent.GetType() == typeof(Grid))
                    {
                        ((Grid)this.Parent).SizeChanged += new SizeChangedEventHandler(ctlRptRemainingLeads_SizeChanged);
                        wfhRptViewer.Height = ((Grid)this.Parent).ActualHeight - 150.0;
                        wfhRptViewer.Width = ((Grid)this.Parent).ActualWidth - 4.0;
                    }
                    else if (this.Parent.GetType() == typeof(TabItem))
                    {
                        ((TabControl)((TabItem)this.Parent).Parent).SizeChanged += new SizeChangedEventHandler(ctlRptRemainingLeads_SizeChanged);
                        this.Width = ((TabControl)((TabItem)this.Parent).Parent).ActualWidth;
                        this.Height = ((TabControl)((TabItem)this.Parent).Parent).ActualHeight;
                        wfhRptViewer.Height = ((TabControl)((TabItem)this.Parent).Parent).ActualHeight - 150.0;
                        wfhRptViewer.Width = ((TabControl)((TabItem)this.Parent).Parent).ActualWidth - 130.0;
                    }
                }
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "ctlRptRemainingLeads_Loaded()", "ctlRptTeleNumAudit.xaml.cs");
            }
        }

        void ctlRptTeleNumAudit_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (this.Parent != null)
                {
                    if (this.Parent.GetType() == typeof(Grid))
                    {
                        this.Width = e.NewSize.Width;
                        this.Height = e.NewSize.Height;
                    }
                }
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "ctlRptUserAudit_SizeChanged()", "ctlRptTeleNumAudit.xaml.cs");
            }
        }

        void ctlRptRemainingLeads_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (this.Parent != null)
                {
                    if (this.Parent.GetType() == typeof(Grid))
                    {
                        if (e.NewSize.Width > 0)
                        {
                            this.Width = e.NewSize.Width;
                            wfhRptViewer.Width = e.NewSize.Width - 4.0;
                            wfhRptViewer.Height = e.NewSize.Height - 150.0;
                        }
                    }
                    else if (this.Parent.GetType() == typeof(TabItem))
                    {
                        if (e.NewSize.Width > 0)
                        {
                            this.Width = e.NewSize.Width - 4.0;
                            wfhRptViewer.Width = e.NewSize.Width - 130.0;
                            wfhRptViewer.Height = e.NewSize.Height - 150.0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                VMuktiHelper.ExceptionHandler(ex, "ctlRptRemainingLeads_SizeChanged()", "ctlRptTeleNumAudit.xaml.cs");
            }
        }

        #endregion

        private void cmbCampaign_DropDownOpened(object sender, EventArgs e)
        {
            wfhRptViewer.Visibility = Visibility.Hidden;
        }
    }




}