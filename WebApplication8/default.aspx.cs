using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Page.Request.UrlReferrer != null && Page.Request.UrlReferrer.ToString().ToLower().Contains(Page.Request.Url.Host.ToLower()))
            {
                Form.Attributes["autocomplete"] = "off";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.Request.UrlReferrer != null && Page.Request.UrlReferrer.ToString().ToLower().Contains(Page.Request.Url.Host.ToLower()))
                {
                    ResetForm();
                }
            }
        }

        private void ResetForm()
        {
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT [ID], [User_id], [PlainTextPassword] FROM [user_data] WHERE [User_id] = @UserId AND [PlainTextPassword] = @Password";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // User authenticated successfully
                    if (reader.Read())
                    {
                        Session["UserID"] = reader["ID"];
                        Session["Username"] = reader["User_id"];
                    }
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    // Authentication failed
                    ErrorMessageLabel.Text = "Invalid username or password.";
                }
            }
        }
    }
}