using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Online_Admission_Test
{
    public partial class general : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            

            mobileNoPanel2.Text = Session["mobile"] as string;
            tx_idpanel2.Text = Session["tx_id"] as string;
            
        }

        protected void submitB_Click(object sender, EventArgs e)
        {
            wrongLabel.Text = " ";
            //check
            try
            {

                con.Open();
                //SELECT * FROM `student` WHERE `BOARD_NAME`='RAJSHAHI' and `ROLL_NO`='135322' and `PASS_YEAR`='2011'
                MySqlCommand cmd = new MySqlCommand("Select * from student where BOARD_NAME='" + boardDDL.SelectedItem.ToString() + "'and ROLL_NO='" + rollTB.Text.ToString() + "'and PASS_YEAR='" + passYearDDL.SelectedItem.ToString() + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wrongLabel.Visible = true;
                wrongLabel.Text ="Matches Found.";
                reader.Close();
                //for update
                try
                {

                   

                    //UPDATE `admission`.`dbbl` SET `hsc_board` = 'RAJSHAHI',`hsc_roll` = '135323',`hsc_pass_year` = '2011' WHERE `dbbl`.`mobile_no` = '01683065253' AND `dbbl`.`tx_id` = '0987654321' AND `dbbl`.`taka` =500 AND `dbbl`.`hsc_board` = 'DHAKA' AND `dbbl`.`hsc_roll` = '135322' AND `dbbl`.`hsc_pass_year` = '2013'


                    MySqlCommand cmdo = new MySqlCommand("Update dbbl set hsc_board='" + boardDDL.SelectedItem.ToString() + "', hsc_roll='" + rollTB.Text.ToString() + "',hsc_pass_year='" + passYearDDL.SelectedItem.ToString() + "' where mobile_no='"+mobileNoPanel2.Text+"' and tx_id='"+tx_idpanel2.Text+"'", con);
                    cmdo.ExecuteNonQuery();
                    
                    wrongLabel.Text = wrongLabel + "Update Complete";
                    Session["mobile"] = mobileNoPanel2.Text;
                    Session["tx_id"] = tx_idpanel2.Text;
                    Session["hsc_board"] = boardDDL.SelectedItem.ToString();
                    Session["hsc_roll"] = rollTB.Text;
                    Session["hsc_pass_year"] = passYearDDL.SelectedItem.ToString();
                    
                    Response.Redirect("main.aspx");
                   

                }
                catch (Exception ee)
                {
                    wrongLabel.Text = wrongLabel.Text + ee.Message.ToString();
                    
                }




                }else{
                    wrongLabel.Visible = true;
                    wrongLabel.Text = "No Matches Found. Please input correct information";
                    return;
                
                }
                con.Close();

            }
            catch (Exception ee)
            {
                wrongLabel.Text = ee.Message.ToString();

            }
            
            
               



        
        }

        protected void signOutB_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}