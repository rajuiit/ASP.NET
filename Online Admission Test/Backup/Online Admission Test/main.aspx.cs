using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Online_Admission_Test
{
    public partial class main : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString);
        
        string constring = ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString;
        
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            mobileNoPanel7.Text = Session["mobile"] as string;
            tx_idPanel7.Text = Session["tx_id"] as string;
           /* hscboardLPanel7.Text = Session["hsc_board"] as string;
            hscrollLpanel7.Text = Session["hsc_roll"] as string;
            hscpassyearLpane7.Text = Session["hsc_pass_year"] as string;
*/
            
            //admit card choose
            admitcardselection("applya", admitcardBA,Aunitserial,AunitExamRoom);
            admitcardselection("applyb", admitcardBB,Bunitserial,BunitExamRoom);
            admitcardselection("applyc", admitcardBC,Cunitserial,CunitExamRoom);
            admitcardselection("applyd", admitcardBD,Dunitserial,DunitExamRoom);
            admitcardselection("applye", admitcardBE,Eunitserial,EunitExamRoom);
            admitcardselection("applyf", admitcardBF,Funitserial,FunitExamRoom);
            admitcardselection("applyg", admitcardBG,Gunitserial,GunitExamRoom);
            admitcardselection("applyh", admitcardBH,Hunitserial,HunitExamRoom);
            
            //end of admit card  button choose


            if (!IsPostBack == true)
            {

          

            //for show data
           con.Open();

           //SELECT * FROM `student` WHERE `BOARD_NAME`='RAJSHAHI' and `ROLL_NO`= '135323' and `PASS_YEAR`='2011'
           MySqlCommand cmd = new MySqlCommand("Select * from student where BOARD_NAME=(SELECT hsc_board from dbbl where mobile_no='" + mobileNoPanel7.Text + "' and tx_id = '" + tx_idPanel7.Text + "') and ROLL_NO=(SELECT hsc_roll from dbbl where mobile_no='" + mobileNoPanel7.Text + "' and tx_id = '" + tx_idPanel7.Text + "') and PASS_YEAR=(SELECT hsc_pass_year from dbbl where mobile_no='" + mobileNoPanel7.Text + "' and tx_id = '" + tx_idPanel7.Text + "')", con);
          
                
           MySqlDataReader reader = cmd.ExecuteReader();
           if (reader.Read())
           {

               nameL.Text = reader.GetString(0).ToString();
               f_nameL.Text = reader.GetString(1).ToString();
               m_nameL.Text = reader.GetString(2).ToString();
               registrationL.Text = reader.GetString(3).ToString();
               sessionL.Text = reader.GetString(4).ToString();
               rollL.Text = reader.GetString(5).ToString();
               boardL.Text = reader.GetString(7).ToString();
               passYearL.Text = reader.GetString(6).ToString();
               mobileNoL.Text = Session["mobile"] as string;
               totalGPAL.Text = reader.GetString(12).ToString();
               //Panel2.Enabled = false;
               hscboardLPanel7.Text = boardL.Text;
               hscrollLpanel7.Text = rollL.Text;
               hscpassyearLpane7.Text = passYearL.Text;
           }
           reader.Close();
           con.Close();
            //end show data
            
//for pic
           //wrongLabel.Text = File.Exists(Server.MapPath("~/Images/") + mobileNoPanel7.Text + "_" + tx_idPanel7.Text + ".jpg").ToString();
           if (File.Exists(Server.MapPath("~/Images/") + mobileNoPanel7.Text + "_" + tx_idPanel7.Text + ".jpg"))
           {
               imgI.ImageUrl = "Images/" + mobileNoPanel7.Text + "_" + tx_idPanel7.Text + ".jpg";
           }
           else {
               imgI.ImageUrl = "img/defaultpic.png" ;
           
           }




                //end of pic

            //for datagridview 1
           
           con.Open();
           SqlDataSource dataSource = new SqlDataSource("MySql.Data.MySqlClient", constring, "SELECT mobile_no,tx_id,taka FROM dbbl where mobile_no = '"+mobileNoPanel7.Text+"' and tx_id = '"+tx_idPanel7.Text+"'");
           GridView1.DataSource = dataSource;
           GridView1.DataBind();
           con.Close();

          

            //dataGridView1.Rows[i].Cells[0].Value.ToString()
          
         takaLabel.Text = GridView1.Rows[0].Cells[2].Text.ToString();


                //for select panel 6 or panel 8
                try
            {
                con.Open();
                string query = "SELECT submit from dbbl where mobile_no='" + mobileNoPanel7.Text.ToString() + "' and tx_id ='" + tx_idPanel7.Text.ToString() + "'";
                MySqlCommand cmde = new MySqlCommand(query, con);
                MySqlDataReader readerp = cmde.ExecuteReader();
                

                if (readerp.Read())
                {
                    if(readerp.GetString(0) == "YES")
                    {
                       Panel6.Visible = false;
                        Panel8.Visible = true;
                    }
                    else{

                        Panel6.Visible = true;
                        Panel8.Visible = false;
                    }
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

                //end of selection

        }


            //check money
            if (int.Parse(takaLabel.Text) < 300)
                disableFunc();
            else
                enableFunc();

            //end of check money


/*
            //for datagridview 2

            con.Open();
            SqlDataSource dataSource2 = new SqlDataSource("MySql.Data.MySqlClient", constring, "SELECT * FROM apply where mobile_no = '" + mobileNoPanel7.Text + "' and tx_id = '" + tx_idPanel7.Text + "' ");
            GridView2.DataSource = dataSource2;
            GridView2.DataBind();
            con.Close();

            //end datgirdview 2
 */
        }

       
        

        protected void AunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(AunitChB,AunitMR);
            
        }

        private void changeValue(CheckBox unitName,Label unitMR)
        {

            if (Double.Parse(totalGPAL.Text) < Double.Parse(unitMR.Text))
            {
                unitName.Checked = false;
                appliedSubjectL.Text = "You can't apply.";
                appliedSubjectL.ForeColor = System.Drawing.Color.Red;
                submitApplyB.Focus();
                return;

            }
            //if (Double.Parse(totalGPAL.Text) < Double.Parse(AunitMR.Text))
            //{
            //    unitName.Enabled = false;
            //    unitName.Checked = false;
            //    appliedSubjectL.Text = "You can't apply.";
            //    appliedSubjectL.ForeColor = System.Drawing.Color.Red;
            //    return;

            //}


            string unit = "=";
            int taka = int.Parse(takaLabel.Text);
            
            if (unitName.Checked)
            {
                taka = taka - 300;
                
            }
            else
            {
                taka = taka + 300;

            }
            takaLabel.Text = taka.ToString();

            if (AunitChB.Checked)
                unit = unit + ",A";
            if (BunitChB.Checked)
                unit = unit+",B";
            if (CunitChB.Checked)
                unit = unit+ ",C";
            if (DunitChB.Checked)
                unit = unit+",D";
            if (EunitChB.Checked)
                unit = unit+",E";
            if (FunitChB.Checked)
                unit = unit+",F";
            if (GunitChB.Checked)
                unit = unit+ ",G";
            if (HunitChB.Checked)
                unit = ",H";

            unit = unit.Remove(0,1);
            appliedSubjectL.Text = "You are applied on " + unit + " unit.";
            appliedSubjectL.ForeColor = System.Drawing.Color.Black;

            if (int.Parse(takaLabel.Text) < 300)
                disableFunc();
            else
                enableFunc();

            submitApplyB.Focus();
           
        }

        protected void BunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(BunitChB,BunitMR);
        }

        protected void CunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(CunitChB,CunitMR);
        }

        protected void DunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(DunitChB,DunitMR);
        }

        protected void EunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(EunitChB,EunitMR);
        }

        protected void FunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(FunitChB,FunitMR);
        }

        protected void GunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(GunitChB,GunitMR);
        }

        protected void HunitChB_CheckedChanged(object sender, EventArgs e)
        {
            changeValue(HunitChB,HunitMR);
        }
        private void disableFunc() {

            if (AunitChB.Checked == false)
                AunitChB.Enabled = false;
            if (BunitChB.Checked == false)
                BunitChB.Enabled = false;
            if (BunitChB.Checked == false)
                BunitChB.Enabled = false;
            if (CunitChB.Checked == false)
                CunitChB.Enabled = false;
            if (DunitChB.Checked == false)
                DunitChB.Enabled = false;
            if (EunitChB.Checked == false)
                EunitChB.Enabled = false;
            if (FunitChB.Checked == false)
                FunitChB.Enabled = false;
            if (GunitChB.Checked == false)
                GunitChB.Enabled = false;
            if (HunitChB.Checked == false)
                HunitChB.Enabled = false;

            
        
        }

        private void enableFunc() {

          
                AunitChB.Enabled = true;
                BunitChB.Enabled = true;
                BunitChB.Enabled = true;
                CunitChB.Enabled = true;
                DunitChB.Enabled = true;
                EunitChB.Enabled = true;
                FunitChB.Enabled = true;
                GunitChB.Enabled = true;
                HunitChB.Enabled = true;

        }

        protected void submitApplyB_Click(object sender, EventArgs e)
        {

            if (AunitChB.Checked)
                insertvalues("applya");
            if (BunitChB.Checked)
                insertvalues("applyb");
            if (CunitChB.Checked)
                insertvalues("applyc");
            if (DunitChB.Checked)
                insertvalues("applyd");
            if (EunitChB.Checked)
                insertvalues("applye");
            if (FunitChB.Checked)
                insertvalues("applyf");
            if (GunitChB.Checked)
                insertvalues("applyg");
            if (HunitChB.Checked)
                insertvalues("applyh");

            Panel6.Visible = false;
            Panel8.Visible = true;
        }

        public void insertvalues(string tablename) {
            try
            {
                con.Open();
                //INSERT INTO `admission`.`applya` (`serialNo` ,`mobile_no` ,`tx_id` ,`number_found` ,`merit_position`)VALUES (NULL , '01819466747', '1234567890', '', ');
                //UPDATE `admission`.`dbbl` SET `submit` = 'YES' WHERE `dbbl`.`mobile_no` = '01819466747' AND `dbbl`.`tx_id` = '1234567890' AND `dbbl`.`taka` =600 AND `dbbl`.`hsc_board` = 'RAJSHAHI' AND `dbbl`.`hsc_roll` = '135323' AND `dbbl`.`hsc_pass_year` = '2011' AND `dbbl`.`submit` = 'No'
                MySqlCommand cmdo = new MySqlCommand("UPDATE dbbl SET submit='YES' WHERE mobile_no='" + mobileNoPanel7.Text + "' and tx_id='" + tx_idPanel7.Text + "'", con);

                MySqlCommand cmd = new MySqlCommand("insert into "+tablename+" values(NULL , '" + mobileNoPanel7.Text + "', '" + tx_idPanel7.Text + "', '', '')", con);

                cmd.ExecuteNonQuery();
                    cmdo.ExecuteNonQuery();
                submitLabel.Text = "Success";
                con.Close();
            }
            catch (Exception exx)
            {
                submitLabel.Text = exx.Message.ToString();
            }
        
        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {

            if (imgFU.HasFile)
            {
                try
                {
                    if (imgFU.PostedFile.ContentType == "image/jpeg")
                    {
                        if (imgFU.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(imgFU.FileName);
                            string extension = Path.GetExtension(imgFU.FileName);
                            String newfilename = mobileNoPanel7.Text +"_"+tx_idPanel7.Text;
                           imgFU.SaveAs(Server.MapPath("~/Images/") + newfilename + extension);
                            //imgFU.SaveAs("Images/"+newfilename+extension);
                            StatusLabel.Text = "Upload status: File uploaded!";
                            imgI.ImageUrl = ("~/Images/") + newfilename + extension;
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void admitcardBA_Click(object sender, EventArgs e)
        {
            showadmitcard("A", Aunitserial);
        }

        protected void signOutB_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }


        public void admitcardselection(string tablename , Button btnName, Label unitserial,Label examRoom) {

            //for select download admit
            try
            {
                con.Open();
                string querys = "SELECT * from "+tablename+" where mobile_no='" + mobileNoPanel7.Text.ToString() + "' and tx_id ='" + tx_idPanel7.Text.ToString() + "'";
                MySqlCommand cmdee = new MySqlCommand(querys, con);
                MySqlDataReader readerpa = cmdee.ExecuteReader();


                if (readerpa.Read())
                {
                    btnName.Enabled = true;
                    unitserial.Text = readerpa.GetString(0).ToString();
                        examRoom.Text = "Seat plan : "+readerpa.GetString(3).ToString();
                }
                else
                {
                    btnName.Enabled = false;
                    unitserial.Text = "None";
                    examRoom.Text = "None";
                }


                readerpa.Close();  //close Data Reader


                //close Connection


                con.Close();
            }
            catch (Exception ew)
            {
                wrongLabel.Text = ew.Message.ToString();


            }

            //end of admit download
        }

        protected void admitcardBB_Click(object sender, EventArgs e)
        {
            showadmitcard("B", Bunitserial);
           
        }

        protected void admitcardBC_Click(object sender, EventArgs e)
        {
            showadmitcard("C", Cunitserial);
        }

        public void showadmitcard(string unitName, Label lblName) {

            if (File.Exists(Server.MapPath("~/Images/") + mobileNoPanel7.Text + "_" + tx_idPanel7.Text + ".jpg"))
            {
                string studentImgPath = mobileNoPanel7.Text + "_" + tx_idPanel7.Text + ".jpg";
                //mobileNoPanel7.Text+"_"+tx_idPanel7.Text+".jpg"
                createAdmitPDF a = new createAdmitPDF();
                a.createPDF(unitName, rollL.Text, lblName.Text, nameL.Text, f_nameL.Text, m_nameL.Text, studentImgPath);
                Response.Redirect("~/PDFs/Doc2.pdf");

            }
            else
            {
                infoL.Visible = true;
                infoL.Text = "Please Upload your own Image.";
                infoL.Focus();
            }
        }

        protected void admitcardBD_Click(object sender, EventArgs e)
        {
            showadmitcard("D", Dunitserial);
        }

        protected void admitcardBE_Click(object sender, EventArgs e)
        {
            showadmitcard("E", Eunitserial);
        }

        protected void admitcardBF_Click(object sender, EventArgs e)
        {
            showadmitcard("F", Funitserial);
        }

        protected void admitcardBG_Click(object sender, EventArgs e)
        {
            showadmitcard("G", Gunitserial);
        }

        protected void admitcardBH_Click(object sender, EventArgs e)
        {
            showadmitcard("H", Hunitserial);
        }
       

      
        
       

       
       


       
    }
}