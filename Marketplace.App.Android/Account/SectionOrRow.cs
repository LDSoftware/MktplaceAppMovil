using System;
using System.Collections.Generic;

namespace Marketplace.App.Android.Account
{
    public class SectionOrRow
    {

        private String row;
        private String section;
        private bool isRow;
        private bool isLogin;
        private bool isLogout;
        private List<string> dataUser;

        public static SectionOrRow createRow(String row)
        {
            SectionOrRow ret = new SectionOrRow();
            ret.row = row;
            ret.isRow = true;
            ret.isLogin = false;
            ret.isLogout = false;
            return ret;
        }

        public static SectionOrRow createRowLogout(String row)
        {
            SectionOrRow ret = new SectionOrRow();
            ret.row = row;
            ret.isRow = true;
            ret.isLogin = false;
            ret.isLogout = true;
            return ret;
        }

        public static SectionOrRow createRowLogin(List<string> row)
        {
            SectionOrRow ret = new SectionOrRow();
            ret.row = "";
            ret.dataUser = row;
            ret.isRow = true;
            ret.isLogin = true;
            ret.isLogout = false;
            return ret;
        }

        public static SectionOrRow createSection(String section)
        {
            SectionOrRow ret = new SectionOrRow();
            ret.section = section;
            ret.isRow = false;
            ret.isLogin = false;
            ret.isLogout = false;
            return ret;
        }

        public String getRow()
        {
            return row;
        }

        public List<string> getUserData()
        {
            return dataUser;
        }

        public String getSection()
        {
            return section;
        }

        public bool IsRow()
        {
            return isRow;
        }

        public bool IsLogin()
        {
            return isLogin;
        }

        public bool IsLogout()
        {
            return isLogout;
        }
    }
}
