using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin: Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string password = maskedTextBox1.Text;

            // Kullanıcıyı kullanıcı adına göre bul
            var user = db.TblUsers.FirstOrDefault(x => x.UserName == kullaniciAdi);

            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Şifre kontrolü
            if (user.Password == password)
            {
                FrmBank frm = new FrmBank();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

