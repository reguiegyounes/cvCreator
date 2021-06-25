
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_creator.Entity
{
    class cSection
    {
        
       
        public DataTable getSections()
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"select idSection AS " + Words.idSection
                                + ",sectionNameEn  AS " + Words.En
                                + ",sectionNameAr AS " + Words.Ar
                                + ",sectionNameFr AS " + Words.Fr
                                 + ",repeatItem AS " + Words.Repeat
                                + " from tblSections ORDER BY idSection";
            DataTable dt = new DataTable();
            dt = db.SelectData(query, null);
            db.Close();
            return dt;
        }
        public void insert(int id, string en, string ar, string fr, bool repeat)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"insert into tblSections values (@id,@en,@ar,@fr,@r)";
            OleDbParameter[] param = new OleDbParameter[5];
            param[0] = new OleDbParameter("@id", DbType.Int32);
            param[0].Value = id;
            param[1] = new OleDbParameter("@en", DbType.String);
            param[1].Value = en;
            param[2] = new OleDbParameter("@ar", DbType.String);
            param[2].Value = ar;
            param[3] = new OleDbParameter("@fr", DbType.String);
            param[3].Value = fr;
            param[4] = new OleDbParameter("@r", DbType.Boolean);
            param[4].Value = repeat;
            db.ExecuteCommand(query, param);
        }
        public void update(int idOld, int idNew, string en, string ar, string fr, bool repeat)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"UPDATE tblSections SET idSection=@idNew
                                 ,sectionNameEn=@en
                                 ,sectionNameAr=@ar
                                 ,sectionNameFr=@fr
                                  ,repeatItem=@r
                                  WHERE idSection=@idOld";
            OleDbParameter[] param = new OleDbParameter[6];
            param[0] = new OleDbParameter("@idNew", DbType.Int32);
            param[0].Value = idNew;
            param[1] = new OleDbParameter("@en", DbType.String);
            param[1].Value = en;
            param[2] = new OleDbParameter("@ar", DbType.String);
            param[2].Value = ar;
            param[3] = new OleDbParameter("@fr", DbType.String);
            param[3].Value = fr;
            param[4] = new OleDbParameter("@r", DbType.Boolean);
            param[4].Value = repeat;
            param[5] = new OleDbParameter("@idOld", DbType.Int32);
            param[5].Value = idOld;
            db.ExecuteCommand(query, param);
        }
        public void delete(int id)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"DELETE  FROM  tblSections 
                            WHERE idSection=@id";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@id", DbType.Int32);
            param[0].Value = id;
            db.ExecuteCommand(query, param);
        }
        public void fillCombo(ComboBox cmb, string language)
        {
            cmb.DataSource = this.getSections();
            cmb.ValueMember = Words.idSection;
            switch (language)
            {
                case "ar":
                    {
                        cmb.DisplayMember = Words.Ar;
                    }
                    break;
                case "fr":
                    {
                        cmb.DisplayMember = Words.Fr;
                    }
                    break;
                default:
                    {
                        cmb.DisplayMember = Words.En;
                    }
                    break;
            }
        }
        
    }


    
}
