using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
//using GrievanceSystem.BAL;
using System.Data.SqlTypes;
using GrievanceSystemDetails.BAL;
//using GrievanceSystem.ENT;

namespace GrievanceSystem
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
        }

        public static void FillDropDownListOrderTypeID(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select Order Type", "-99"));
            ddl.Items.Insert(1, new ListItem("Buy", "1"));
            ddl.Items.Insert(2, new ListItem("Sell", "2"));
            ddl.Items.Insert(3, new ListItem("Call (CE)", "3"));
            ddl.Items.Insert(4, new ListItem("Put (PE)", "4"));
            ddl.DataBind();
        }

        public static void FillDropDownListEmotionType(DropDownList ddl,string ForWhat)
        {
            ddl.Items.Insert(0, new ListItem("Select " + ForWhat + " Emotion Type", "-99"));
            ddl.Items.Insert(1, new ListItem("Anxiety", "1"));
            ddl.Items.Insert(2, new ListItem("Excitement", "2"));
            ddl.Items.Insert(3, new ListItem("Euphoria", "3"));
            ddl.Items.Insert(4, new ListItem("Frustration", "4"));
            ddl.Items.Insert(5, new ListItem("Normal", "5"));
            ddl.Items.Insert(6, new ListItem("Fear", "6"));
            ddl.Items.Insert(7, new ListItem("Greed", "7"));
            ddl.DataBind();
        }

        public static void FillDropDownListDepartment(DropDownList ddl)
        {
            MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
            DataTable dtDepartment = balMST_Department.SelectAll();
            ddl.DataSource = dtDepartment;
            ddl.DataTextField = "DepartmentName";
            ddl.DataValueField = "DepartmentID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Department", "-99"));
        }

        public static void FillDropDownListUserByDepartment(DropDownList ddl, SqlInt32 DepartmentID)
        {
            SEC_UserBAL balSEC_User = new SEC_UserBAL();
            DataTable dtSEC_User = balSEC_User.SelectByDepartmentID(DepartmentID);
            ddl.DataSource = dtSEC_User;
            ddl.DataTextField = "UserName";
            ddl.DataValueField = "UserID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select User", "-99"));
        }
    }
}
