﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions; // PermissionSetAttribute
using System.Data.SqlClient;

namespace GeneradorAmir
{
    public partial class Form1 : Form
    {
        #region Member Variables
        string ConnectionString;
        StringBuilder ErrorLog, SuccessLog;
        #endregion

        #region Form Load / Constructor
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(".", " ");
            name = name.Substring(name.IndexOf('\\') + 1);
            this.txtAuthor.Text = ToTitleCase(name);
        }
        #endregion

        #region helper method - to-title-case
        /// <summary>
        /// Applies title case format to the input string
        /// </summary>
        /// <param name="strIn">Input string tobe formatted</param>
        /// <returns>Title case formatted string</returns>
        public string ToTitleCase(string strIn) {
            //check if is null
            if (strIn == null)
                return string.Empty;

            //split the input string using space char as delimiter
            string[] words = strIn.Split(' ');
            string retValue = string.Empty;

            //apply upper case format to each string and append it to the output string
            foreach (string word in words) {
                retValue += String.Format("{0}{1} ", word[0].ToString().ToUpper(), word.Substring(1));
            }

            //return the formatted string
            return retValue;
        }
        #endregion

        #region Methods that call to the dac. also append to logs
        private string Execute(string sql, string name) {
            try {
                using (CrudDac dac = new CrudDac(ConnectionString))
                {
                    //dac.Execute(sql);
                }
            } catch {
                //ErrorLog.Append("----------------ERROR! Following procedure did not generate--\r\n");
                //ErrorLog.Append(sql);
                //return name + ", ";
            }
            SuccessLog.Append("--Following Procedure was created.");
            SuccessLog.Append(sql);
            return "";
        }
        private DataTable GetColumns() {
            using (CrudDac dac = new CrudDac(ConnectionString))
            {
                return dac.GetColumns(this.txtTableName.Text);
            }
        }
        #endregion

        #region Make Stored Procedures BUTTON
        private void button1_Click(object sender, EventArgs e) {
            string server = this.txtServer.Text, database = this.txtDatabase.Text;
            if (server.Length > 0 && database.Length > 0) {
                ConnectionString = "Server=" + server + ";Database=" + database + ";Trusted_Connection=True;";
               

                DataTable dt = GetColumns();
                List<Table> tables = Table.ParseDataTable(dt);
                string errors = "";
                SuccessLog = new StringBuilder();
                ErrorLog = new StringBuilder();
                foreach (Table table in tables) {
                    table.db = database;
                    table.Author = this.txtAuthor.Text;
                    table.IsActive = this.txtIsActive.Text;
                    
                    string errorLine = "";
                    
                    if (this.chkCreate.Checked)
                        errorLine = errorLine + Execute(table.GenerateCreate(), "Create");
                    if (this.chkDelete.Checked) 
                        errorLine = errorLine + Execute(table.GenerateDelete(), "Delete");
                    if (this.chkUpdate.Checked) 
                        errorLine = errorLine + Execute(table.GenerateUpdate(), "Update");
                    if (this.chkReadAll.Checked) 
                        errorLine = errorLine + Execute(table.GenerateSelectAll(), "ReadAll");
                    if (this.chkReadById.Checked)
                        errorLine = errorLine + Execute(table.GenerateSelectById(), "ReadById");
                    if (this.chkDeactivate.Checked)
                        errorLine = errorLine + Execute(table.GenerateDeactiveate(), "Deactivate");

                    if (errorLine.Length > 0) {
                        if (errors.Length > 0)
                            errors = errors + Environment.NewLine;
                        errors = errors + table.TableName + "-" + errorLine.Remove(errorLine.Length-2);//remove ", "
                    }
                }
                if (errors.Length > 0)
                    MessageBox.Show("The following procedures were not able to be generated:" + Environment.NewLine + errors);
                else {
                    MessageBox.Show("SUCCESS");
                }
                this.txtSuccessLog.Text = SuccessLog.ToString();
                this.txtErrorLog.Text = ErrorLog.ToString();
                ErrorLog = null;
                SuccessLog = null;
            } else {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Must enter both server and database;");
            }
        }
        #endregion

        private void chkReadById_CheckedChanged(object sender, EventArgs e)
        {

        }
    
       
    }
}
