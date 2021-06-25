using System.Data;
using System.Data.OleDb;

namespace CV_creator.Entity
{
    class cPerson
    {
        
        public DataTable getPersons()
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"select idPerson AS " + Words.idSection
                                + ",fullNameEn  AS [" + Words.FullNameLatin + "]"
                                + ",fullNameAr AS [" + Words.FullNameAr + "]"
                                + ",date_ins AS [" + Words.DateRegistration + "]"
                                + ",fileName  AS [" + Words.ImageNamePerson + "]"
                                + " from tblPersons";
            return db.SelectData(query, null); 
        }
        public void insert(string fullNameEn, string fullNameAr, string fileName, string date_ins)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"insert into tblPersons(fullNameEn,fullNameAr,fileName,date_ins) VALUES (@fullNameEn,@fullNameAr,@fileName,@date_ins)";
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@fullNameEn", DbType.String);
            param[0].Value = fullNameEn;
            param[1] = new OleDbParameter("@fullNameAr", DbType.String);
            param[1].Value = fullNameAr;
            param[2] = new OleDbParameter("@fileName", DbType.String);
            param[2].Value = fileName;
            param[3] = new OleDbParameter("@date_ins", DbType.String);
            param[3].Value = date_ins;
            db.ExecuteCommand(query, param);
            DataTable dtPersons = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT LAST(idPerson) FROM tblPersons", db.Connection);
            da.Fill(dtPersons);
            int idPerson = (int)dtPersons.Rows[0][0];
            Properties.Settings.Default["IndexLastPerson"] = idPerson;
        }
        public void update(int idPerson, string fullNameEn, string fullNameAr, string fileName)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"UPDATE tblPersons SET 
                                    fullNameEn=@fullNameEn 
                                    ,fullNameAr=@fullNameAr 
                                    ,fileName=@fileName 
                                    WHERE idPerson=@idPerson";
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@fullNameEn", DbType.String);
            param[0].Value = fullNameEn;
            param[1] = new OleDbParameter("@fullNameAr", DbType.String);
            param[1].Value = fullNameAr;
            param[2] = new OleDbParameter("@fileName", DbType.String);
            param[2].Value = fileName;
            param[3] = new OleDbParameter("@idPerson", DbType.Int32);
            param[3].Value = idPerson;
            db.ExecuteCommand(query, param);
        }
        public void delete(int idPerson)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"DELETE  FROM  tblPersons 
                            WHERE idPerson=@idPerson";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@idPerson", DbType.Int32);
            param[0].Value = idPerson;
            db.ExecuteCommand(query, param);
        }
        public DataTable search(string searchWord)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"select idPerson AS " + Words.idSection
                                + ",fullNameEn  AS [" + Words.FullNameLatin + "]"
                                + ",fullNameAr AS [" + Words.FullNameAr + "]"
                                + ",date_ins AS [" + Words.DateRegistration + "]"
                                + ",fileName AS [" + Words.ImageNamePerson + "]"
                                + " from tblPersons "
                                + " WHERE idPerson & fullNameEn & fullNameAr & date_ins  LIKE '%'+@searchWord+'%'";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@searchWord", DbType.String);
            param[0].Value = searchWord;
            return db.SelectData(query, param); ;
        }
    }
}
