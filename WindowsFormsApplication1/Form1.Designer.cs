namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablet = new System.Windows.Forms.DataGridView();
            this.apregnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docoriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apfinals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.math = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeentry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupList = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.finalList = new System.Windows.Forms.ComboBox();
            this.tb = new System.Windows.Forms.TextBox();
            this.butt = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.findBut = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // tablet
            // 
            this.tablet.AllowUserToResizeColumns = false;
            this.tablet.AllowUserToResizeRows = false;
            this.tablet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apregnum,
            this.fio,
            this.specgroup,
            this.docoriginal,
            this.apfinals,
            this.math,
            this.phys,
            this.inf,
            this.rus,
            this.summ,
            this.dop,
            this.total_sum,
            this.typeentry,
            this.priv});
            this.tablet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablet.EnableHeadersVisualStyles = false;
            this.tablet.Location = new System.Drawing.Point(0, 24);
            this.tablet.MaximumSize = new System.Drawing.Size(911, 0);
            this.tablet.MinimumSize = new System.Drawing.Size(911, 0);
            this.tablet.Name = "tablet";
            this.tablet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablet.Size = new System.Drawing.Size(911, 538);
            this.tablet.TabIndex = 1;
            this.tablet.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.tablet_RowStateChanged);
            // 
            // apregnum
            // 
            this.apregnum.HeaderText = "Апрегнум";
            this.apregnum.Name = "apregnum";
            this.apregnum.Width = 70;
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.Name = "fio";
            this.fio.Width = 200;
            // 
            // specgroup
            // 
            this.specgroup.HeaderText = "Группа";
            this.specgroup.Name = "specgroup";
            this.specgroup.Width = 70;
            // 
            // docoriginal
            // 
            this.docoriginal.HeaderText = "Оригинал";
            this.docoriginal.Name = "docoriginal";
            this.docoriginal.Width = 62;
            // 
            // apfinals
            // 
            this.apfinals.HeaderText = "Финальное заявление";
            this.apfinals.Name = "apfinals";
            this.apfinals.Width = 70;
            // 
            // math
            // 
            this.math.HeaderText = "мат";
            this.math.Name = "math";
            this.math.Width = 35;
            // 
            // phys
            // 
            this.phys.HeaderText = "физ";
            this.phys.Name = "phys";
            this.phys.Width = 35;
            // 
            // inf
            // 
            this.inf.HeaderText = "инф";
            this.inf.Name = "inf";
            this.inf.Width = 35;
            // 
            // rus
            // 
            this.rus.HeaderText = "рус";
            this.rus.Name = "rus";
            this.rus.Width = 35;
            // 
            // summ
            // 
            this.summ.HeaderText = "сумма";
            this.summ.Name = "summ";
            this.summ.Width = 50;
            // 
            // dop
            // 
            this.dop.HeaderText = "доп";
            this.dop.Name = "dop";
            this.dop.Width = 35;
            // 
            // total_sum
            // 
            this.total_sum.HeaderText = "итого";
            this.total_sum.Name = "total_sum";
            this.total_sum.Width = 50;
            // 
            // typeentry
            // 
            this.typeentry.HeaderText = "форма";
            this.typeentry.Name = "typeentry";
            this.typeentry.Width = 50;
            // 
            // priv
            // 
            this.priv.HeaderText = "привелегия";
            this.priv.Name = "priv";
            this.priv.Width = 70;
            // 
            // groupList
            // 
            this.groupList.Items.AddRange(new object[] {
            "  "});
            this.groupList.Location = new System.Drawing.Point(311, 3);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(72, 21);
            this.groupList.Sorted = true;
            this.groupList.TabIndex = 2;
            this.groupList.SelectedIndexChanged += new System.EventHandler(this.groupList_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // finalList
            // 
            this.finalList.FormattingEnabled = true;
            this.finalList.Items.AddRange(new object[] {
            " "});
            this.finalList.Location = new System.Drawing.Point(441, 3);
            this.finalList.Name = "finalList";
            this.finalList.Size = new System.Drawing.Size(73, 21);
            this.finalList.TabIndex = 4;
            this.finalList.SelectedIndexChanged += new System.EventHandler(this.finalList_SelectedIndexChanged);
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(112, 3);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(200, 20);
            this.tb.TabIndex = 5;
            this.tb.Text = "Фамилия и баллы через пробел";
            this.tb.Visible = false;
            // 
            // butt
            // 
            this.butt.Location = new System.Drawing.Point(56, 1);
            this.butt.Name = "butt";
            this.butt.Size = new System.Drawing.Size(59, 23);
            this.butt.TabIndex = 6;
            this.butt.Text = "Сверить";
            this.butt.UseVisualStyleBackColor = true;
            this.butt.Visible = false;
            this.butt.Click += new System.EventHandler(this.butt_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // findBut
            // 
            this.findBut.Location = new System.Drawing.Point(520, 1);
            this.findBut.Name = "findBut";
            this.findBut.Size = new System.Drawing.Size(75, 23);
            this.findBut.TabIndex = 7;
            this.findBut.Text = "Найти";
            this.findBut.UseVisualStyleBackColor = true;
            this.findBut.Visible = false;
            this.findBut.Click += new System.EventHandler(this.FindBut_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(592, 3);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(174, 20);
            this.NameBox.TabIndex = 8;
            this.NameBox.Text = "Имя и фамилия через пробел";
            this.NameBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 562);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.findBut);
            this.Controls.Add(this.butt);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.finalList);
            this.Controls.Add(this.groupList);
            this.Controls.Add(this.tablet);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Просмотр поступающих";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.DataGridView tablet;
        private System.Windows.Forms.ComboBox groupList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox finalList;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Button butt;
        private System.Windows.Forms.DataGridViewTextBoxColumn apregnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn specgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn docoriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn apfinals;
        private System.Windows.Forms.DataGridViewTextBoxColumn math;
        private System.Windows.Forms.DataGridViewTextBoxColumn phys;
        private System.Windows.Forms.DataGridViewTextBoxColumn inf;
        private System.Windows.Forms.DataGridViewTextBoxColumn rus;
        private System.Windows.Forms.DataGridViewTextBoxColumn summ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dop;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeentry;
        private System.Windows.Forms.DataGridViewTextBoxColumn priv;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button findBut;
        private System.Windows.Forms.TextBox NameBox;
    }
}

