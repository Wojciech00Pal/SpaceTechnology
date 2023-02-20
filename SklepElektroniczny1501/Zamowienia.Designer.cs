namespace SklepElektroniczny
{
    partial class Zamowienia
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerzamowieniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datazamowieniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zamowienieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.space_TechnologyDataSet = new SklepElektroniczny1501.Space_TechnologyDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.zamowienieTableAdapter = new SklepElektroniczny1501.Space_TechnologyDataSetTableAdapters.zamowienieTableAdapter();
            this.tableAdapterManager = new SklepElektroniczny1501.Space_TechnologyDataSetTableAdapters.TableAdapterManager();
            this.Do_Sklepu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zamowienieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.space_TechnologyDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.numerzamowieniaDataGridViewTextBoxColumn,
            this.datazamowieniaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.zamowienieBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(351, 119);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 53;
            this.dataGridView1.Size = new System.Drawing.Size(603, 410);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 7;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 130;
            // 
            // numerzamowieniaDataGridViewTextBoxColumn
            // 
            this.numerzamowieniaDataGridViewTextBoxColumn.DataPropertyName = "numer_zamowienia";
            this.numerzamowieniaDataGridViewTextBoxColumn.HeaderText = "numer_zamowienia";
            this.numerzamowieniaDataGridViewTextBoxColumn.MinimumWidth = 7;
            this.numerzamowieniaDataGridViewTextBoxColumn.Name = "numerzamowieniaDataGridViewTextBoxColumn";
            this.numerzamowieniaDataGridViewTextBoxColumn.ReadOnly = true;
            this.numerzamowieniaDataGridViewTextBoxColumn.Width = 130;
            // 
            // datazamowieniaDataGridViewTextBoxColumn
            // 
            this.datazamowieniaDataGridViewTextBoxColumn.DataPropertyName = "data_zamowienia";
            this.datazamowieniaDataGridViewTextBoxColumn.HeaderText = "data_zamowienia";
            this.datazamowieniaDataGridViewTextBoxColumn.MinimumWidth = 7;
            this.datazamowieniaDataGridViewTextBoxColumn.Name = "datazamowieniaDataGridViewTextBoxColumn";
            this.datazamowieniaDataGridViewTextBoxColumn.ReadOnly = true;
            this.datazamowieniaDataGridViewTextBoxColumn.Width = 130;
            // 
            // zamowienieBindingSource
            // 
            this.zamowienieBindingSource.DataMember = "zamowienie";
            this.zamowienieBindingSource.DataSource = this.space_TechnologyDataSet;
            // 
            // space_TechnologyDataSet
            // 
            this.space_TechnologyDataSet.DataSetName = "Space_TechnologyDataSet";
            this.space_TechnologyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista zamówień:";
            // 
            // zamowienieTableAdapter
            // 
            this.zamowienieTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.kategoriaTableAdapter = null;
            this.tableAdapterManager.produkt_kategoriaTableAdapter = null;
            this.tableAdapterManager.produktTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SklepElektroniczny1501.Space_TechnologyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.zamowienie_produktTableAdapter = null;
            this.tableAdapterManager.zamowienieTableAdapter = this.zamowienieTableAdapter;
            // 
            // Do_Sklepu
            // 
            this.Do_Sklepu.Location = new System.Drawing.Point(1102, 22);
            this.Do_Sklepu.Name = "Do_Sklepu";
            this.Do_Sklepu.Size = new System.Drawing.Size(141, 43);
            this.Do_Sklepu.TabIndex = 2;
            this.Do_Sklepu.Text = "Sklep";
            this.Do_Sklepu.UseVisualStyleBackColor = true;
            this.Do_Sklepu.Click += new System.EventHandler(this.Do_Sklepu_Click);
            // 
            // Zamowienia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 921);
            this.Controls.Add(this.Do_Sklepu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Zamowienia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zamowienia";
            this.Load += new System.EventHandler(this.Zamowienia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zamowienieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.space_TechnologyDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private SklepElektroniczny1501.Space_TechnologyDataSet space_TechnologyDataSet;
        private System.Windows.Forms.BindingSource zamowienieBindingSource;
        private SklepElektroniczny1501.Space_TechnologyDataSetTableAdapters.zamowienieTableAdapter zamowienieTableAdapter;
        private SklepElektroniczny1501.Space_TechnologyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerzamowieniaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datazamowieniaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Do_Sklepu;
    }
}