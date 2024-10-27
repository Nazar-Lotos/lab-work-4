using System;
using System.Windows.Forms;

namespace lab_work_4
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            gvTVs.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Brand";
            column.Name = "Бренд";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Model";
            column.Name = "Модель";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ScreenSize";
            column.Name = "Діагональ екрану";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Resolution";
            column.Name = "Роздільна здатність";
            gvTVs.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "IsSmartTV";
            column.Name = "Smart TV";
            gvTVs.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "SoundPower";
            column.Name = "Потужність звуку";
            gvTVs.Columns.Add(column);

            bindSrcTVs.Add(new Television("Samsung", "QLED-Q80T", 55, "4K", true, 20));
            EventArgs args = new EventArgs(); OnResize(args);
        }
        private void fMain_Resize(object sender, EventArgs e) 
        {
            int buttonSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnEdit.Margin = new Padding(Width - buttonSize, 0, 0, 0);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Television television = new Television();

            fTelevision ft = new fTelevision(television);
            if(ft.ShowDialog() == DialogResult.OK) 
            {
                bindSrcTVs.Add(television);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Television television = (Television)bindSrcTVs.List[bindSrcTVs.Position];

            fTelevision ft = new fTelevision(ref television);
            if(ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTVs.List[bindSrcTVs.Position] = television;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Видалити поточний запис?", "Видалення запису", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcTVs.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
            {
                bindSrcTVs.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Закрити застосунок?", "Вихід з програми", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK ) 
            {
                Application.Exit();
            }
        }
    }
}
