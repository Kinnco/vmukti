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
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using VMuktiAPI;

namespace VMuktiGrid
{

    public class CTabControlHeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return 0.0;
                }
                if (double.Parse(value.ToString()) > 0)
                {
                    return double.Parse(value.ToString());
                }
                else
                {
                    return 0.0;
                }
            }
            catch (Exception ex)
            {
                VMuktiAPI.VMuktiHelper.ExceptionHandler(ex, "Convert()", "Controls\\VMuktiGrid\\clsConverters.cs");
                
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                VMuktiAPI.VMuktiHelper.ExceptionHandler(ex, "ConvetBack()", "Controls\\VMuktiGrid\\clsConverters.cs");                
                return null;
            }
        }

    }

    public class CTabControlWidth : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return 0.0;
                }
                if (double.Parse(value.ToString()) > 0)
                {
                    return double.Parse(value.ToString());
                }
                else
                {
                    return 0.0;
                }
            }
            catch (Exception ex)
            {
                VMuktiAPI.VMuktiHelper.ExceptionHandler(ex, "Convert--1", "Controls\\VMuktiGrid\\clsConverters.cs");               
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                VMuktiAPI.VMuktiHelper.ExceptionHandler(ex, "ConvertBack()--1", "Controls\\VMuktiGrid\\clsConverters.cs");                
                return null;
            }
        }

    }
}
