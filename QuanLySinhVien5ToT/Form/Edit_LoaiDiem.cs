using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien5ToT
{
    public partial class Edit_LoaiDiem : UserControl
    {
        public Edit_LoaiDiem()
        {
            InitializeComponent();
        }

        private void btnThemLĐ_Click(object sender, EventArgs e)
        {
            pn_view.Visible = false;
            pn_themLĐ.Visible = true;
            btnLuuLĐ.Visible = true;

        }

        private void dtgv_LĐ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_LĐ.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_view.Visible = false;
                pn_themLĐ.Visible = true;
                btnLuuLĐ.Visible = true;
            }
        }

        private void btnLuuLĐ_Click(object sender, EventArgs e)
        {
            pn_view.Visible = true;
            pn_themLĐ.Visible = false;
            btnLuuLĐ.Visible = false;
        }

        private void btnXLĐ_Click(object sender, EventArgs e)
        {
            pn_view.Visible = true;
            pn_themLĐ.Visible = false;
            btnLuuLĐ.Visible = false;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
            QUYDINHDIEM QD = new QUYDINHDIEM();
            QD.Enabled = true;
        }
    }
}
