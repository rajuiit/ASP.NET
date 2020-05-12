using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Online_Admission_Test
{
    public partial class seatplan : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString);


        string constring = ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //for datagridview 1
                
               
                con.Open();
                SqlDataSource dataSource = new SqlDataSource("MySql.Data.MySqlClient", constring, "SELECT * FROM apply"+DropDownList1.SelectedValue.ToLower()+"");
                GridView3.DataSource = dataSource;
                GridView3.DataBind();
                con.Close();
           
        }

        protected void updateB_Click(object sender, EventArgs e)
        {
            
            //int dif = Convert.ToInt32( endRollNo.Text) - Convert.ToInt32(intialRollNo.Text); 
            //UPDATE `admission`.`applya` SET `number_found` = '437' WHERE `applya`.`serialNo` =1100000;
            int dif = Convert.ToInt32(seatTB.Text);
            con.Open();
            for (int i = 0; i <= dif; i++)
            {

                MySqlCommand cmdo = new MySqlCommand("Update apply" + DropDownList1.SelectedValue.ToLower() + " set number_found='" + roomNoDDL.SelectedValue + "' where serialNo='" + (Convert.ToInt32(intialRollNo.Text) + i) + "'", con);
                cmdo.ExecuteNonQuery();
               // GridView1.DataBind();
                
            }

            con.Close();
            Response.Redirect("seatplan.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Document document = new Document(PageSize.A4, 5, 5, 15, 15);
            PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("~/PDFs/doc.pdf"), FileMode.Create));
            document.Open();
            PdfPTable table = new PdfPTable(5);
            PdfPCell cell = new PdfPCell();
            //for font
            string fontpath = Server.MapPath("~/font/") + "times.ttf";
            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
            //for end of font
            //set font size
            Font font16 = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font16bold = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            Font font14bold = new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            //for image
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + "julogo.GIF");
            gif.ScaleToFit(50f, 50f);
            gif.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_CENTER;
            gif.IndentationRight = 9f;
            gif.SpacingAfter = 9f;
            gif.Border = Rectangle.BOX;
            gif.BorderColor = iTextSharp.text.BaseColor.YELLOW;
            gif.BorderWidth = 5f;
            document.Add(gif);
            //end of image
            Paragraph p1 = new Paragraph("Jahangirnagar University\nAdmission Test 2013-14\n\n", font16bold);
            p1.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(p1);
            //cell.Padding = 9f;
            cell.Phrase = new Phrase("Serial");
            table.AddCell(cell);
            cell.Phrase = new Phrase("mobile");
            table.AddCell(cell);
            cell.Phrase = new Phrase("Tx");
            table.AddCell(cell);
            cell.Phrase = new Phrase("seat");
            table.AddCell(cell);
            cell.Phrase = new Phrase("merit");
            table.AddCell(cell);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `applya` inner join dbbl where applya.mobile_no = dbbl.mobile_no and applya.tx_id = dbbl.tx_id ", con);


            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cell.Phrase = new Phrase(reader.GetString(0).ToString());
                table.AddCell(cell);

                cell.Phrase = new Phrase(reader.GetString(1).ToString());
                table.AddCell(cell);

                cell.Phrase = new Phrase(reader.GetString(2).ToString());
                table.AddCell(cell);

                cell.Phrase = new Phrase(reader.GetString(3).ToString());
                table.AddCell(cell);

                cell.Phrase = new Phrase(reader.GetString(4).ToString());
                table.AddCell(cell);
                

                }
            reader.Close();
            con.Close();
            document.Add(table);
            document.Close();
            Response.Redirect("~/PDFs/doc.pdf");
        }
    }
}