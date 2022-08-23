namespace GeneradorAmir
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.label6 = new System.Windows.Forms.Label();
            this.chkDeactivate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.chkReadById = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkCreate = new System.Windows.Forms.CheckBox();
            this.txtErrorLog = new System.Windows.Forms.TextBox();
            this.txtSuccessLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "IsActive Field:";
            // 
            // chkDeactivate
            // 
            this.chkDeactivate.AutoSize = true;
            this.chkDeactivate.Location = new System.Drawing.Point(119, 163);
            this.chkDeactivate.Name = "chkDeactivate";
            this.chkDeactivate.Size = new System.Drawing.Size(78, 17);
            this.chkDeactivate.TabIndex = 29;
            this.chkDeactivate.Text = "Deactivate";
            this.chkDeactivate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(12, 163);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 27;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Location = new System.Drawing.Point(119, 140);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(63, 17);
            this.chkReadAll.TabIndex = 26;
            this.chkReadAll.Text = "ReadAll";
            this.chkReadAll.UseVisualStyleBackColor = true;
            // 
            // chkReadById
            // 
            this.chkReadById.AutoSize = true;
            this.chkReadById.Checked = true;
            this.chkReadById.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadById.Location = new System.Drawing.Point(12, 140);
            this.chkReadById.Name = "chkReadById";
            this.chkReadById.Size = new System.Drawing.Size(105, 17);
            this.chkReadById.TabIndex = 25;
            this.chkReadById.Text = "ReaTraductorBL";
            this.chkReadById.UseVisualStyleBackColor = true;
            this.chkReadById.CheckedChanged += new System.EventHandler(this.chkReadById_CheckedChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(119, 117);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(53, 17);
            this.chkUpdate.TabIndex = 24;
            this.chkUpdate.Text = "UpBL";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkCreate
            // 
            this.chkCreate.AutoSize = true;
            this.chkCreate.Checked = true;
            this.chkCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreate.Location = new System.Drawing.Point(12, 117);
            this.chkCreate.Name = "chkCreate";
            this.chkCreate.Size = new System.Drawing.Size(69, 17);
            this.chkCreate.TabIndex = 23;
            this.chkCreate.Text = "CreaDAL";
            this.chkCreate.UseVisualStyleBackColor = true;
            // 
            // txtErrorLog
            // 
            this.txtErrorLog.Location = new System.Drawing.Point(203, 355);
            this.txtErrorLog.Multiline = true;
            this.txtErrorLog.Name = "txtErrorLog";
            this.txtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorLog.Size = new System.Drawing.Size(530, 179);
            this.txtErrorLog.TabIndex = 33;
            // 
            // txtSuccessLog
            // 
            this.txtSuccessLog.Location = new System.Drawing.Point(203, 28);
            this.txtSuccessLog.Multiline = true;
            this.txtSuccessLog.Name = "txtSuccessLog";
            this.txtSuccessLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSuccessLog.Size = new System.Drawing.Size(530, 283);
            this.txtSuccessLog.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 31);
            this.button1.TabIndex = 31;
            this.button1.Text = "Make Stored Procedures";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(88, 285);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(83, 20);
            this.txtIsActive.TabIndex = 30;
            this.txtIsActive.Text = "IsActive";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(72, 91);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtAuthor.TabIndex = 22;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(72, 65);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(100, 20);
            this.txtTableName.TabIndex = 21;
            this.txtTableName.Text = "%";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(72, 39);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtDatabase.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Author";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(72, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Table Like";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Error Log:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Server";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 541);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkDeactivate);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.chkReadAll);
            this.Controls.Add(this.chkReadById);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.chkCreate);
            this.Controls.Add(this.txtErrorLog);
            this.Controls.Add(this.txtSuccessLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIsActive);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDeactivate;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkReadAll;
        private System.Windows.Forms.CheckBox chkReadById;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkCreate;
        private System.Windows.Forms.TextBox txtErrorLog;
        private System.Windows.Forms.TextBox txtSuccessLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

