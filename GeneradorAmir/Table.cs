using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorAmir
{
   public class Table
    {
       public string db;


        #region Member variables
        string tableName = string.Empty;
        string author = string.Empty;
        string isActive = string.Empty;
        List<Column> columns = new List<Column>();
        #endregion
       
        #region Properties
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public List<Column> Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        #endregion

        #region Column Selector Methods

        public List<Column> GetPrimaryKeys()
        {
            List<Column> list = new List<Column>();
            foreach (Column column in columns)
            {
                if (column.IsPrimaryKey)
                    list.Add(column);
            }
            return list;
        }
        public List<Column> GetNotPrimaryKeysAndNotIdentity()
        {
            List<Column> list = new List<Column>();
            foreach (Column column in columns)
            {
                if (!column.IsPrimaryKey && !column.IsIdentity)
                    list.Add(column);
            }
            return list;
        }
        public List<Column> GetAllColumns()
        {
            return columns;
        }
        public Column GetIdentityColumn()
        {
            foreach (Column column in columns)
            {
                if (column.IsIdentity)
                    return column;
            }
            return null;
        }
        public List<Column> GetNotIdentity()
        {
            List<Column> list = new List<Column>();
            foreach (Column column in columns)
            {
                if (!column.IsIdentity)
                    list.Add(column);
            }
            return list;
        }
        #endregion

        #region STATIC - Parse Table method
        public static List<Table> ParseDataTable(DataTable dt)
        {
            List<Table> tables = new List<Table>();
            foreach (DataRow dr in dt.Rows)
            {
                Table table;
                if (tables.Count == 0 || tables[tables.Count - 1].TableName != dr["TableName"].ToString())
                {
                    table = new Table();
                    table.TableName = dr["TableName"].ToString();
                    tables.Add(table);
                }
                else
                {
                    table = tables[tables.Count - 1];
                }
                Column column = new Column();
                column.Name = dr["ColumnName"].ToString();
                column.IsIdentity = ((int)dr["IsIdentity"] == 1);
                column.IsPrimaryKey = ((int)dr["IsPrimaryKey"] == 1);
                column.DataType = dr["DataType"].ToString();
                table.Columns.Add(column);
            }
            return tables;
        }
        #endregion

        #region CRUD Methods
        internal string GenerateSelectById()
        {
            StringBuilder sb = new StringBuilder(500000);
            WriteComments(sb);
            bool first;
            List<Column> nonIdentity = GetNotIdentity();

            sb.Append("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;");
            sb.Append("\r\nnamespace " + db + "System.BL.Traductores\r\n{\r\n");

            sb.Append("//Create BL \r\n");
            sb.Append("\npublic partial class ");
            sb.Append(this.tableName);
            sb.Append("\r\n{");


            sb.Append("\r\n public " + db + "System.DAL." + this.tableName + " Hacia" + this.tableName + "(" + db + "System.BL.Entidades." + this.tableName + " desde)\r\n{\r\n");
            sb.Append("var hacia = new " + db + "System.DAL." + this.tableName + "();");


            first = true;
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {
                    sb.Append("\r\n hacia." + c.Name + "=desde." + c.Name + ";");
                }
                else
                {
                    sb.Append("\r\n hacia." + c.Name + "=desde."+ c.Name+";");
                    first = !first;
                }
            }
            sb.Append("\r\nreturn hacia;\r\n}");



            sb.Append("\r\n public " + db + "System.BL.Entidades." + this.tableName + " Hacia" + this.tableName + "(" + db + "System.DAL." + this.tableName + " desde)\r\n{\r\n");
            sb.Append("var hacia = new " + db + "System.BL.Entidades." + this.tableName + "();");


            first = true;
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {
                    sb.Append("\r\n hacia." + c.Name + "=desde." + c.Name + ";");
                }
                else
                {
                    sb.Append("\r\n hacia." + c.Name + "=desde." + c.Name + ";");
                    first = !first;
                }
            }
          sb.Append("\r\nreturn hacia;\r\n}");
          sb.Append("\r\npublic List<" + db + "System.DAL." + this.tableName + "> Hacia" + this.tableName + "(List<" + db + "System.BL.Entidades." + this.tableName + "> desde)\r\n{");
          sb.Append("\r\nreturn desde.Select(Hacia"+ this.tableName +").ToList();\r\n}");
          sb.Append("\r\npublic List<" + db + "System.BL.Entidades." + this.tableName + "> Hacia" + this.tableName + "(List<" + db + "System.DAL." + this.tableName + "> desde)\r\n{");
          sb.Append("\r\nreturn desde.Select(Hacia" + this.tableName + ").ToList();\r\n}\r\n");






            return sb.ToString();
        }

        internal string GenerateSelectAll()
        {
            StringBuilder sb = new StringBuilder(500000);
            WriteComments(sb);
            bool first;
            List<Column> nonIdentity = GetNotIdentity();

            sb.Append("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;");
            sb.Append("\r\nnamespace " + db + "System.BL.Traductores\r\n{\r\n");

            sb.Append("//Create BL \r\n");
            sb.Append("\npublic partial class ");
            sb.Append(this.tableName);
            sb.Append("\r\n{");


            first = true;
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n public string " + c.Name + "{ get; set; }");

                }
                else
                {
                    sb.Append("\r\n public string " + c.Name + "{ get; set; }");
                    first = !first;
                    sb.Append(c.Name);
                    sb.Append(" == ");
                    sb.Append(c.Name);

                }
            }
            return sb.ToString();
        }
        internal string GenerateUpdate()
        {

            StringBuilder sb = new StringBuilder(500000);
            WriteComments(sb);
            bool first;
            List<Column> nonIdentity = GetNotIdentity();

            sb.Append("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\n");
            sb.Append("namespace " + db + "System.BL.Entidades\r\n{\r\n");
            
            sb.Append("//Create BL \r\n");
            sb.Append("\npublic partial class ");
            sb.Append(this.tableName);
            sb.Append("\r\n{");


            first = true;
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n public string " + c.Name+ "{ get; set; }");
                   
                }
                else
                {
                    sb.Append("\r\n public string " + c.Name + "{ get; set; }");
                    first = !first;
                   

                }
            }
            sb.Append("\r\npublic " + this.tableName + " ()\r\n{\r\n}");
            




            sb.Append(" \r\npublic ");
            sb.Append(this.tableName);
            sb.Append("  (");
            sb.Append(this.tableName);
            sb.Append(" obj)\r\n{");
            

            SelectColumns(sb, true, nonIdentity);
            sb.Append("\r\n}\r\n");
            sb.Append("public override bool Equals(object obj)\r\n{\r\n");
            sb.Append("\treturn obj is ");
            sb.Append(this.tableName);
            first = true;
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t&&((");
                    sb.Append(this.tableName);
                    sb.Append(")obj).");
                    first = !first;
                    sb.Append(c.Name);
                    sb.Append(" == ");
                    sb.Append(c.Name);

                }
                else
                {
                    sb.Append("\r\n\t&&((");
                    sb.Append(this.tableName);
                    sb.Append(")obj).");
                    first = !first;
                    sb.Append(c.Name);
                    sb.Append(" == ");
                    sb.Append(c.Name);

                }
            }
            sb.Append("\r\n;\r\n}\r\n");

            sb.Append("public override int GetHashCode()\r\n{\r\n");
            first = true;
            sb.Append("\tint hash=13;");
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\thash=(hash * 7 ) + ");
                    sb.Append(c.Name);
                    sb.Append(".GetHashCode();");

                }
                else
                {
                    sb.Append("\r\n\thash=(hash * 7 ) + ");
                    sb.Append(c.Name);
                    sb.Append(".GetHashCode();");
                    first = !first;

                }
            }
            sb.Append("\r\nreturn hash;\r\n}\r\n");

            sb.Append("public override string ToString()\r\n{\r\n");
            first = true;
            sb.Append("\t var retorno = \"[" + this.tableName + " \";");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t retorno = retorno + \"" + c.Name + "=\" + " + c.Name + ";");

                }
                else
                {
                    sb.Append("\r\n\t retorno = retorno + \"" + c.Name + "=\" + " + c.Name + ";");
                    first = !first;

                }
            }
            sb.Append("\r\nreturn retorno + \"]\";\r\n}\r\n");




            sb.Append("public static bool operator ==(" + this.tableName + " obj1, " + this.tableName + " obj2)\r\n{\r\n");
            first = true;
            sb.Append("return true");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t  && obj1." + c.Name + "== obj2." + c.Name);

                }
                else
                {
                    sb.Append("\r\n\t  && obj1." + c.Name + "== obj2." + c.Name);
                    first = !first;

                }
            }
            sb.Append("\r\n;\r\n}\r\n");


            sb.Append("public static bool operator !=(" + this.tableName + " obj1, " + this.tableName + " obj2)\r\n{\r\n");
            first = true;
            sb.Append("return ");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t  || obj1." + c.Name + "!= obj2." + c.Name);

                }
                else
                {
                    sb.Append("\r\n\t   obj1." + c.Name + "!= obj2." + c.Name);
                    first = !first;

                }
            }
            sb.Append("\r\n;\r\n}\r\n");




            sb.Append("public void Insertar()\r\n{\r\n");
            first = true;
            sb.Append("var DAL" + this.tableName + " = new "+db+"System.DAL." + this.tableName + "();\r\n");
            sb.Append(" var traductor = new Traductores." + this.tableName + "();\r\n");
            sb.Append(" DAL" + this.tableName + " = traductor.Hacia" + this.tableName + "(this);\r\n");
            sb.Append(" DAL" + this.tableName + ".Insertar();\r\n");
                  
            sb.Append("\r\n\r\n}\r\n");







            sb.Append("public void Actualizar()\r\n{\r\n");
            sb.Append("var DAL" + this.tableName + " = new " + db + "System.DAL." + this.tableName + "();\r\n");
            sb.Append(" var traductor = new Traductores." + this.tableName + "();\r\n");
            sb.Append(" DAL" + this.tableName + " = traductor.Hacia" + this.tableName + "(this);\r\n");
            sb.Append(" DAL" + this.tableName + ".Actualizar();\r\n");
            sb.Append("\r\n\r\n}\r\n");




            sb.Append("public void Eliminar()\r\n{\r\n");
            sb.Append("var DAL" + this.tableName + " = new " + db + "System.DAL." + this.tableName + "();\r\n");
            sb.Append(" var traductor = new Traductores." + this.tableName + "();\r\n");
            sb.Append(" DAL" + this.tableName + " = traductor.Hacia" + this.tableName + "(this);\r\n");
            sb.Append(" DAL" + this.tableName + ".Eliminar();\r\n");
            sb.Append("\r\n\r\n}\r\n}");
            return sb.ToString();
        }

        internal string GenerateDelete()
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_Delete\r\n");

            DeclareColumnList(sb, GetPrimaryKeys(), true);

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tdelete from ");
            sb.Append(this.tableName);

            PK_WhereClause(sb);

            sb.Append("\r\nEnd\r\n");

            return sb.ToString();
        }

        internal string GenerateCreate()
        {
            StringBuilder sb = new StringBuilder(500000);
            WriteComments(sb);
            sb.Append("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;");
            sb.Append("\r\nnamespace " + db + "System.DAL\r\n{\r\n");
            sb.Append("//Create DAL \r\n");
            sb.Append("\npublic partial class ");
            sb.Append(this.tableName);
            sb.Append("\r\n{ \r\npublic ");
            sb.Append(this.tableName);
            sb.Append("  (");
            sb.Append(this.tableName);
            sb.Append(" obj)\r\n{");
            bool first;
            List<Column> nonIdentity = GetNotIdentity();
          
            SelectColumns(sb, true, nonIdentity);
            sb.Append("\r\n}\r\n");
            sb.Append("public override bool Equals(object obj)\r\n{\r\n");
            sb.Append("\treturn obj is ");
            sb.Append(this.tableName);
            first = true;
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t&&((");
                    sb.Append(this.tableName);
                    sb.Append(")obj).");
                    sb.Append(c.Name);
                    sb.Append(" == ");
                    sb.Append(c.Name);
                  
                }
                else
                {
                    sb.Append("\r\n\t&&((");
                    sb.Append(this.tableName);
                    sb.Append(")obj).");
                    first = !first;
                    sb.Append(c.Name);
                    sb.Append(" == ");
                    sb.Append(c.Name);
                    
                }
            }
            sb.Append("\r\n;\r\n}\r\n");

            sb.Append("public override int GetHashCode()\r\n{\r\n");
            first = true;
            sb.Append("\tint hash=13;");
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\thash=(hash * 7 ) + ");
                    sb.Append(c.Name);
                    sb.Append(".GetHashCode();");

                }
                else
                {
                    sb.Append("\r\n\thash=(hash * 7 ) + ");
                    sb.Append(c.Name);
                    sb.Append(".GetHashCode();");
                    first = !first;

                }
            }
            sb.Append("\r\nreturn hash;\r\n}\r\n");

            sb.Append("public override string ToString()\r\n{\r\n");
            first = true;
            sb.Append("\t var retorno = \"[" + this.tableName + " \";");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t retorno = retorno + \"" + c.Name + "=\" + " + c.Name + ";");
                   
                }
                else
                {
                    sb.Append("\r\n\t retorno = retorno + \"" + c.Name + "=\" + " + c.Name + ";");
                    first = !first;

                }
            }
            sb.Append("\r\nreturn retorno + \"]\";\r\n}\r\n");




            sb.Append("public static bool operator ==("+this.tableName+" obj1, "+this.tableName+" obj2)\r\n{\r\n");
            first = true;
            sb.Append("return true");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t  && obj1." + c.Name + "== obj2." + c.Name );

                }
                else
                {
                    sb.Append("\r\n\t  && obj1." + c.Name + "== obj2." + c.Name );
                    first = !first;

                }
            }
            sb.Append("\r\n;\r\n}\r\n");


            sb.Append("public static bool operator !=(" + this.tableName + " obj1, " + this.tableName + " obj2)\r\n{\r\n");
            first = true;
            sb.Append("return ");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t  || obj1." + c.Name + "!= obj2." + c.Name );

                }
                else
                {
                    sb.Append("\r\n\t  obj1." + c.Name + "!= obj2." + c.Name );
                    first = !first;

                }
            }
            sb.Append("\r\n;\r\n}\r\n");




            sb.Append("public void Insertar()\r\n{\r\n");
            first = true;
            sb.Append("var db = new " + db + "Entities();\r\n");
            sb.Append("db." + this.tableName + ".Add(this);\r\n");
            sb.Append("db.SaveChanges();\r\n");
            sb.Append("\r\n\r\n}\r\n");







            sb.Append("public void Actualizar()\r\n{\r\n"); 
            first = true;
            sb.Append("var db = new " + db + "Entities();\r\n");
            
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n  reg." + c.Name + "= " + c.Name + ";");

                }
                else
                {
                    sb.Append("  var reg = (from obj in db." + this.tableName + " where  obj." + c.Name + " == "+ c.Name +" select obj).First();");
                    sb.Append("\r\n  reg." + c.Name + "= " + c.Name+";");
                    first = !first;

                }
            }
            sb.Append("\r\ndb.SaveChanges();\r\n}\r\n");





            sb.Append("public void Eliminar()\r\n{\r\n");
            first = true;
            sb.Append("var db = new " + db + "Entities();\r\n");

            foreach (Column c in nonIdentity)
            {
                if (!first)
                {


                }
                else
                {
                    
                    sb.Append("  var reg = (from obj in db." + this.tableName + " where  obj." + c.Name + " == " + c.Name + "  select obj).First();");
                    sb.Append("\r\n db." + this.tableName + ".Remove(reg);");
                    break;

                }
            }
            sb.Append("\r\ndb.SaveChanges();\r\n}\r\n}\r\n");



            return sb.ToString();
        }
        internal string GenerateDeactiveate()
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_Deactivate\r\n");

            DeclareColumnList(sb, GetPrimaryKeys(), true);

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tupdate ");
            sb.Append(this.tableName);
            sb.Append("\r\n\tset\r\n\t\t");

            sb.Append(this.IsActive);

            sb.Append(" = 0");

            PK_WhereClause(sb);

            sb.Append("\r\nEnd\r\n");

            return sb.ToString();
        }
        #endregion

        #region CRUD - Common Code Methods
        private void WriteComments(StringBuilder sb)
        {
            sb.Append("-- =============================================");
            sb.Append("\r\n-- Author:\t\t");
            sb.Append(author);
            sb.Append("\r\n-- Create date:\t");
            sb.Append(DateTime.Now.ToShortDateString());
            sb.Append("\r\n-- Description:\t");
            sb.Append("\r\n-- Revisions:\t");
            sb.Append("\r\n-- =============================================\r\n");
        }
        private void PK_WhereClause(StringBuilder sb)
        {
            sb.Append("\r\n\twhere\r\n");
            bool first = true;
            foreach (Column c in GetPrimaryKeys())
            {
                if (!first)
                {
                    sb.Append("\r\n\t\tand ");
                }
                else
                {
                    first = !first;
                    sb.Append("\t\t");
                }
                sb.Append(c.Name);
                sb.Append(" = @");
                sb.Append(c.Name);
            }
        }
        private bool DeclareColumnList(StringBuilder sb, List<Column> columns, bool first)
        {
            foreach (Column c in columns)
            {
                first = DeclareColumn(sb, c, first, false);
            }
            return first;
        }

        private static bool DeclareColumn(StringBuilder sb, Column c, bool first, bool output)
        {
            if (!first)
            {
                sb.Append(",\r\n");
            }
            else
            {
                first = !first;
            }
            sb.Append("\t@");
            sb.Append(c.Name + " ");
            sb.Append(c.DataType);
            if (output)
            {
                sb.Append(" OUTPUT");
            }
            return first;
        }
        private static bool SelectColumns(StringBuilder sb, bool first, List<Column> nonIdentity)
        {
            foreach (Column c in nonIdentity)
            {
                if (!first)
                {

                    sb.Append("\r\n\t");
                    sb.Append(c.Name);
                    sb.Append(" =");
                    sb.Append(" obj.");
                    sb.Append(c.Name);
                    sb.Append(";");
                }
                else
                {
                    sb.Append("\r\n\t");
                    first = !first;
                    sb.Append(c.Name);
                    sb.Append(" =");
                    sb.Append(" obj.");
                    sb.Append(c.Name);
                    sb.Append(";");
                }
            }
            return first;
        }
        #endregion
    }
}