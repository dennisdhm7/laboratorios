namespace lab_WS_Cliente_Basico_Hinojosa
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIgual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNumero,
            this.ColX,
            this.Coli,
            this.ColIgual,
            this.ColResultado});
            this.dgvTabla.Location = new System.Drawing.Point(137, 157);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.Size = new System.Drawing.Size(547, 253);
            this.dgvTabla.TabIndex = 26;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(479, 118);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 25;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(284, 118);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ingrese número: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tabla de Multiplicar 2 con WS";
            // 
            // ColNumero
            // 
            this.ColNumero.HeaderText = "Numero";
            this.ColNumero.Name = "ColNumero";
            this.ColNumero.ReadOnly = true;
            // 
            // ColX
            // 
            this.ColX.HeaderText = "X";
            this.ColX.Name = "ColX";
            this.ColX.ReadOnly = true;
            // 
            // Coli
            // 
            this.Coli.HeaderText = "i";
            this.Coli.Name = "Coli";
            this.Coli.ReadOnly = true;
            // 
            // ColIgual
            // 
            this.ColIgual.HeaderText = "=";
            this.ColIgual.Name = "ColIgual";
            this.ColIgual.ReadOnly = true;
            // 
            // ColResultado
            // 
            this.ColResultado.HeaderText = "Resultado";
            this.ColResultado.Name = "ColResultado";
            this.ColResultado.ReadOnly = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coli;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIgual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColResultado;
    }
}