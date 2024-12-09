using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;

namespace YourNamespace
{
    public partial class SuccessfulLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Existing code...
        }

        protected void HashButton_Click(object sender, EventArgs e)
        {
            string inputText = InputTextBox.Text;
            string hashedPassword = ComputeSha256Hash(inputText);

            ResultLabel.Text = $"Hashed Password: {hashedPassword}";
        }

        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected global::System.Web.UI.WebControls.TextBox InputTextBox;
        protected global::System.Web.UI.WebControls.Label ResultLabel;
    }
}

namespace WebApplication8
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null && Session["Username"] != null)
                {
                    UsernameLabel.Text = Session["Username"].ToString();
                    UserIDLabel.Text = Session["UserID"].ToString();
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        protected global::System.Web.UI.WebControls.Label UsernameLabel;
        protected global::System.Web.UI.WebControls.Label UserIDLabel;
    }
}