using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
public partial class Default2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=NI3-PC;Initial Catalog=AssignData;Integrated Security=True");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Random rnd = new Random();
        string r;
        r = rnd.Next(2, 23).ToString();
        TextBox15.Text = r.ToString();
        TextBox15.Enabled = false; //Disp();
        }
    private void Disp()
    {
        cmd = new SqlCommand("dispdata", con);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter();
        con.Open(); 
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds, "data");
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
        con.Close();
   }
    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("insertdata", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id",TextBox15.Text);
        cmd.Parameters.AddWithValue("@username", TextBox1.Text);
        cmd.Parameters.AddWithValue("@pass", TextBox3.Text);
        cmd.Parameters.AddWithValue("@confirmpass", TextBox4.Text);
        cmd.Parameters.AddWithValue("@fname", TextBox5.Text);
        cmd.Parameters.AddWithValue("@lname", TextBox6.Text);
        cmd.Parameters.AddWithValue("@email", TextBox7.Text);
        cmd.Parameters.AddWithValue("@phone", TextBox8.Text);
        cmd.Parameters.AddWithValue("@location", TextBox9.Text);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
      //  this.Disp();
        
       }

     protected void GridDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        //Disp();
    }
    protected void GridDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        //Disp();
    }
    protected void GridDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //Disp();
    }
    protected void GridDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string user = (GridView1.DataKeys[e.RowIndex].Values["username"].ToString());
        TextBox name     = (TextBox)GridView1.Rows[e.RowIndex].FindControl("fname");
        TextBox lastname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("lname");
        TextBox emalid = (TextBox)GridView1.Rows[e.RowIndex].FindControl("email");
        TextBox phonen = (TextBox)GridView1.Rows[e.RowIndex].FindControl("phone");
        TextBox loc = (TextBox)GridView1.Rows[e.RowIndex].FindControl("location");

    updateall(name.Text,lastname.Text,emalid.Text,phonen.Text,loc.Text,user);

    }
    protected void GridDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["id"].ToString());

            deleteall(Id);
    }
    protected void deleteall(int Id)
    {
           con.Open();
        SqlCommand cmd = new SqlCommand("deletedata", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id",Id);
        cmd.ExecuteNonQuery();
        con.Close();
        //Disp();

    }
protected void updateall(string name, string lastname, string emailid,string phonen,string loc,string user)
{
    con.Open();
    SqlCommand cmd = new SqlCommand("updatedata", con);
cmd.CommandType= CommandType.StoredProcedure;
cmd.Parameters.AddWithValue("@fname", name);
cmd.Parameters.AddWithValue("@lname",lastname);
cmd.Parameters.AddWithValue("@email",emailid);
cmd.Parameters.AddWithValue("@phone",phonen);
cmd.Parameters.AddWithValue("@location",loc);
cmd.ExecuteNonQuery();
//Label11.ForeColor = Color.Green;
Label11.Text = "Data retrived ";
GridView1.EditIndex = -1;
//Disp();
}
}