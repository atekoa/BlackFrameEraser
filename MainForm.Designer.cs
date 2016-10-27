namespace BlackFrameEraser
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnProcesaVideo = new System.Windows.Forms.Button();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.comboBoxVISION = new System.Windows.Forms.ComboBox();
            this.checkBuenos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVideo = new System.Windows.Forms.TextBox();
            this.btnSeleccionaVideo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnProcesaVideo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExtraer, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(224, 73);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(216, 34);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // btnProcesaVideo
            // 
            this.btnProcesaVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcesaVideo.Location = new System.Drawing.Point(111, 3);
            this.btnProcesaVideo.Name = "btnProcesaVideo";
            this.btnProcesaVideo.Size = new System.Drawing.Size(102, 28);
            this.btnProcesaVideo.TabIndex = 3;
            this.btnProcesaVideo.Text = "Generar VIDEO";
            this.btnProcesaVideo.UseVisualStyleBackColor = true;
            this.btnProcesaVideo.Click += new System.EventHandler(this.btnProcesaVideo_Click);
            // 
            // btnExtraer
            // 
            this.btnExtraer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExtraer.Location = new System.Drawing.Point(3, 3);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(102, 28);
            this.btnExtraer.TabIndex = 8;
            this.btnExtraer.Text = "Extraer FRAMES";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // comboBoxVISION
            // 
            this.comboBoxVISION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxVISION.FormattingEnabled = true;
            this.comboBoxVISION.Location = new System.Drawing.Point(224, 33);
            this.comboBoxVISION.Name = "comboBoxVISION";
            this.comboBoxVISION.Size = new System.Drawing.Size(216, 21);
            this.comboBoxVISION.TabIndex = 10;
            this.comboBoxVISION.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBuenos
            // 
            this.checkBuenos.AutoSize = true;
            this.checkBuenos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBuenos.Location = new System.Drawing.Point(446, 33);
            this.checkBuenos.Name = "checkBuenos";
            this.checkBuenos.Size = new System.Drawing.Size(217, 34);
            this.checkBuenos.TabIndex = 9;
            this.checkBuenos.Text = "Extraer buenos";
            this.checkBuenos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directorio/Fichero :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbVideo
            // 
            this.tbVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVideo.Location = new System.Drawing.Point(224, 3);
            this.tbVideo.Name = "tbVideo";
            this.tbVideo.Size = new System.Drawing.Size(216, 20);
            this.tbVideo.TabIndex = 1;
            // 
            // btnSeleccionaVideo
            // 
            this.btnSeleccionaVideo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSeleccionaVideo.Location = new System.Drawing.Point(446, 3);
            this.btnSeleccionaVideo.Name = "btnSeleccionaVideo";
            this.btnSeleccionaVideo.Size = new System.Drawing.Size(40, 24);
            this.btnSeleccionaVideo.TabIndex = 2;
            this.btnSeleccionaVideo.Text = "...";
            this.btnSeleccionaVideo.UseVisualStyleBackColor = true;
            this.btnSeleccionaVideo.Click += new System.EventHandler(this.btnSeleccionaVideo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnSeleccionaVideo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbVideo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBuenos, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxVISION, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(666, 135);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 135);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTILIDADES DE VIDEO";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnProcesaVideo;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.ComboBox comboBoxVISION;
        private System.Windows.Forms.CheckBox checkBuenos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVideo;
        private System.Windows.Forms.Button btnSeleccionaVideo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}

