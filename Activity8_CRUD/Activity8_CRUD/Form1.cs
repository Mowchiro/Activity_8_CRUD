using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity8_CRUD
{
    public partial class Form1 : Form
    {
        int selectedRow = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(
                txtFirstName.Text,
                txtLastName.Text,
                txtMiddleName.Text,
                cmbBarangay.Text,
                cmbCity.Text,
                cmbProvince.Text,
                cmbCourse.Text,
                rdoMale.Checked ? "Male" : "Female"
            );
            ClearInputs();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                txtFirstName.Text = row.Cells[0].Value.ToString();
                txtLastName.Text = row.Cells[1].Value.ToString();
                txtMiddleName.Text = row.Cells[2].Value.ToString();
                cmbBarangay.Text = row.Cells[3].Value.ToString();
                cmbCity.Text = row.Cells[4].Value.ToString();
                cmbProvince.Text = row.Cells[5].Value.ToString();
                cmbCourse.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value.ToString() == "Male")
                    rdoMale.Checked = true;
                else
                    rdoFemale.Checked = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                row.SetValues(
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtMiddleName.Text,
                    cmbBarangay.Text,
                    cmbCity.Text,
                    cmbProvince.Text,
                    cmbCourse.Text,
                    rdoMale.Checked ? "Male" : "Female"
                );
                ClearInputs();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                dataGridView1.Rows.RemoveAt(selectedRow);
                ClearInputs();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data saved in memory (no database).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearInputs()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();
            cmbBarangay.SelectedIndex = -1;
            cmbCity.SelectedIndex = -1;
            cmbProvince.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            selectedRow = -1;
        }
    }
}