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
    public partial class attendancesheet : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString);

        string constring = ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void attendanceButton_Click(object sender, EventArgs e)
        {
            Document document = new Document(PageSize.A4.Rotate(), 5, 5, 15, 15);
            PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("~/PDFs/doc.pdf"), FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(6);
            //for font
            string fontpath = Server.MapPath("~/font/") + "times.ttf";
            BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
            //for end of font
            //set font size
            Font font16 = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font16bold = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            Font font14bold = new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            float[] widths = new float[] { 6f, 6f, 8f,8f,8f,10f };

table.SetWidths(widths);

table.HorizontalAlignment = 1;

//leave a gap before and after the table

table.SpacingBefore = 20f;

table.SpacingAfter = 30f;


            PdfPCell cell = new PdfPCell();

          //  float[] widthss = new float[] { 1f };
            cell.Padding = 9f;
            /*
            cell.PaddingTop = 7f;
            cell.PaddingBottom = 7f;
            cell.PaddingLeft = 7f;
            cell.PaddingRight = 7f;
            */

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

            Paragraph p1 = new Paragraph("Jahangirnagar University\nAdmission Test 2013-14\n",font16bold);
            p1.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(p1);

            Paragraph p2 = new Paragraph("Unit Name : "+DropDownList2.SelectedValue.ToString());
            
            p2.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(p2);
            Paragraph p3 = new Paragraph("Room No:" + DropDownList1.SelectedValue.ToString());

            p3.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(p3);


            cell.Phrase = new Phrase("Serial No",font14bold );
            
            table.AddCell(cell);

            cell.Phrase = new Phrase("HSC Roll",font14bold);
            table.AddCell(cell);

            cell.Phrase = new Phrase("Name",font14bold);
            table.AddCell(cell);

            cell.Phrase = new Phrase("Father name",font14bold);
            table.AddCell(cell);

            
            cell.Phrase = new Phrase("Image", font14bold);
            table.AddCell(cell);

            cell.Phrase = new Phrase("Signature", font14bold);
            table.AddCell(cell);
 
            con.Open();
            string tablename = DropDownList2.SelectedValue.ToLower();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM apply" + tablename + " inner join dbbl,student  where apply" + tablename + ".mobile_no = dbbl.mobile_no and apply" + tablename + ".tx_id = dbbl.tx_id  and student.ROLL_NO=dbbl.hsc_roll and number_found='" + DropDownList1.SelectedValue.ToString() + "'", con);


            MySqlDataReader reader = cmd.ExecuteReader();
            int i = 0;    
            while (reader.Read())
            {
               
                cell.Phrase = new Phrase(reader.GetString(0).ToString());
                table.AddCell(cell);

                cell.Phrase = new Phrase(reader.GetString(9).ToString());
                table.AddCell(cell);




                cell.Phrase = new Phrase(reader.GetString(12).ToString());
                table.AddCell(cell);
                
                cell.Phrase = new Phrase(reader.GetString(13).ToString());
                table.AddCell(cell);
                string imgpath = reader.GetString(1)+"_"+reader.GetString(2)+".jpg";

                if (File.Exists(Server.MapPath("~/Images/") + imgpath))
                {
                    //for image
                    iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/") + imgpath);
                    jpeg.ScaleToFit(10f, 10f);
                    jpeg.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_LEFT;
                    jpeg.IndentationRight = 9f;
                    jpeg.SpacingAfter = 9f;
                    jpeg.Border = Rectangle.BOX;

                    jpeg.BorderColor = iTextSharp.text.BaseColor.YELLOW;

                    jpeg.BorderWidth = 5f;

                    table.AddCell(jpeg);
                    //end of image
                }
                else {
                    //for image
                    iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + "defaultpic.png");
                    jpeg.ScaleToFit(25f, 25f);
                    jpeg.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_LEFT;
                    jpeg.IndentationRight = 9f;
                    jpeg.SpacingAfter = 9f;
                    jpeg.Border = Rectangle.BOX;

                    jpeg.BorderColor = iTextSharp.text.BaseColor.YELLOW;

                    jpeg.BorderWidth = 5f;

                    table.AddCell(jpeg);
                    //end of image
                }   

                cell.Phrase = new Phrase("");
                table.AddCell(cell);

                i++;

            }

            
            reader.Close();
            con.Close();
            
            document.Add(table);
            Paragraph p = new Paragraph("Total Student: " + i.ToString());
            p.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(p);

            document.Close();
            Response.Redirect("~/PDFs/doc.pdf");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //for datagridview 1
            string table_name = "apply" + DropDownList2.SelectedValue.ToLower();
            con.Open();
            SqlDataSource dataSource = new SqlDataSource("MySql.Data.MySqlClient", constring, "SELECT serialNo," + table_name + ".mobile_no," + table_name + ".tx_id,dbbl.hsc_roll ,student.name,student.fname FROM " + table_name + " inner join dbbl,student where " + table_name + ".mobile_no = dbbl.mobile_no and  dbbl.hsc_roll=student.ROLL_NO and " + table_name + ".tx_id = dbbl.tx_id and number_found='" + DropDownList1.SelectedValue.ToString() + "'");
            GridView1.DataSource = dataSource;
            GridView1.DataBind();
            con.Close();
        }
    }
}