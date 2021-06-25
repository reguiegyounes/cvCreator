using CV_creator.MyMessageBox;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace CV_creator
{
    class MSAccessDatabase
    {
        private OleDbConnection dbConnection;

        private string directory = "./data/";
        private string fileName = "database.accdb";
        private string password = "1111";
        private string path;
        public MSAccessDatabase()
        {
            CreateDatabase();
            this.path = directory + fileName;
            this.dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Jet OLEDB:Database Password=" + password);
        }
        public void CreateDatabase()
        {
            this.path = directory + fileName;
            if (!Directory.Exists(directory))
            { Directory.CreateDirectory(directory); }

            if (!File.Exists(path))
            {
                try
                {
                    var cat = new ADOX.Catalog();
                    cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Jet OLEDB:Database Password=" + password);
                    cat.ActiveConnection.Close();
                    cat = null;
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Jet OLEDB:Database Password=" + password);
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(@"CREATE TABLE tblSections(idSection INT PRIMARY KEY 
                                , sectionNameEn VARCHAR(100) UNIQUE
                                , sectionNameAr VARCHAR(100) UNIQUE
                                , sectionNameFr VARCHAR(100) UNIQUE
                                , repeatItem BIT DEFAULT 0); ", con);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand(@"CREATE TABLE tblSub_sections(idSub_section AUTOINCREMENT UNIQUE
                                ,sub_sectionNameEn VARCHAR(150)
                                ,sub_sectionNameAr VARCHAR(150) 
                                ,sub_sectionNameFr VARCHAR(150)
                                ,id_Section INT ,
                                FOREIGN KEY (id_Section) 
                                REFERENCES tblSections(idSection) 
                                ON UPDATE CASCADE ON DELETE CASCADE)", con);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand(@"CREATE TABLE tblSelections(idSelection AUTOINCREMENT  UNIQUE
                                ,selectionNameEn VARCHAR(255)
                                ,selectionNameAr VARCHAR(255) 
                                ,selectionNameFr VARCHAR(255)
                                ,id_Sub_section INT
                                ,FOREIGN KEY (id_Sub_section) 
                                REFERENCES tblSub_sections(idSub_section) 
                                 ON DELETE CASCADE)", con);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand(@"CREATE TABLE tblPersons(idPerson AUTOINCREMENT  UNIQUE
                                ,fullNameEn VARCHAR(150)
                                ,fullNameAr VARCHAR(150)
                                ,fileName VARCHAR(255)
                                ,date_ins VARCHAR(40) 
                                )", con);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand(@"CREATE TABLE tblCv(idCvItem AUTOINCREMENT  UNIQUE
                                ,moreDetailEn VARCHAR(255)
                                ,moreDetailAr VARCHAR(255) 
                               ,moreDetailFr VARCHAR(255)
                                ,order_ INT
                                ,id_Selection INT
                                ,id_Person INT
                                ,FOREIGN KEY (id_Selection) 
                                REFERENCES tblSelections(idSelection) 
                                ON DELETE CASCADE
                                ,FOREIGN KEY (id_Person) 
                                REFERENCES tblPersons(idPerson) 
                                ON DELETE CASCADE)", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    new MessageOk(Words.DatabaseCreated, "", MessageIcon.Success).ShowDialog();
                }
                catch (Exception ex)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    new MessageOk(Words.InstallEngine + "\n https://www.microsoft.com/en-us/download/details.aspx?id=13255&fbclid=IwAR0q8_Cv1P57Yw1Cqv3jd2vvpTCnaA2PuVZ0qk8FbL-bAcrapcABlOEWBuU \n" + ex.Message, "", MessageIcon.Error).ShowDialog();
                }
            }
            else return;


        }
        public OleDbConnection Connection
        {
            get
            {
                return dbConnection;
            }
        }
        public String connectionString
        {
            get
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Jet OLEDB:Database Password=" + password;
            }
        }


        public void Open()
        {
            try
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Words.ErrorOpenConnection + "\n" + ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                if (dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Words.ErrorClosingConnection + "\n" + ex.Message);
            }
        }

        public DataTable SelectData(string query_string, OleDbParameter[] param)
        {
            OleDbCommand cmd = new OleDbCommand(query_string, Connection);
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public void ExecuteCommand(string query_string, OleDbParameter[] param)
        {
            OleDbCommand cmd = new OleDbCommand(query_string, Connection);
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public bool TestConnection()
        {
            try
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
