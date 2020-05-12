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
    public partial class Default : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString);

       

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void systemDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (systemDDL.SelectedIndex == 0)
            {
                teletalkPanel.Visible = true;
                DBBLPanel.Visible = false;

            }
            else {
                teletalkPanel.Visible = false ;
                DBBLPanel.Visible = true;

            }
        }

        protected void submitDBBL_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT * from dbbl where mobile_no='" + mobileNoTB.Text.ToString() + "' and tx_id ='" + txIDTB.Text.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                

                if (reader.Read())
                {
                    //this.Visible = false;
                   // main c = new main();
                    Session["mobile"] = reader.GetString(0);
                    Session["tx_id"] = reader.GetString(1);
                   // c.Visible = true;

                    if(reader.GetString(3) == "")
                    Response.Redirect("general.aspx");
                    else
                        Response.Redirect("main.aspx");
                    
                }
                else
                {
                    wrongLabel.Visible = true;
                   
                }


                reader.Close();  //close Data Reader


                //close Connection


                con.Close();
            }
            catch (Exception ew)
            {
                wrongLabel.Text = ew.Message.ToString();

                
            }
            

        }

        protected void submitTeletalk_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

            }
}