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
    public partial class FrmCategory: Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblCategory.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            string CategoryName = txtName.Text;
            TblCategory category = new TblCategory();
            category.CategoryName = CategoryName;
            db.TblCategory.Add(category);
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.TblCategory.Find(id);
            db.TblCategory.Remove(removeValue);
            db.SaveChanges();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string CategoryName = txtName.Text;
            int id = int.Parse(txtId.Text);
            var values = db.TblCategory.Find(id);
            values.CategoryName = CategoryName;
            db.SaveChanges();
        }
    }
}
