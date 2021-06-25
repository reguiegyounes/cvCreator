using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CV_creator.Entity
{
    class cDetails
    {
        public DataTable getDetails(int idItem)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"select idSelection AS " + Words.idSection
                                + ",selectionNameEn  AS " + Words.En
                                + ",selectionNameAr AS " + Words.Ar
                                + ",selectionNameFr AS " + Words.Fr
                                + " from tblSelections WHERE  id_Sub_section=@idSub_section";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@idSub_section", DbType.Int32);
            param[0].Value = idItem;
            return db.SelectData(query, param); ;
        }
        public void insert(string en, string ar, string fr, int idItem)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"insert into tblSelections(selectionNameEn,selectionNameAr,selectionNameFr,id_Sub_section) VALUES (@en,@ar,@fr,@idSub_section)";
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@en", DbType.String);
            param[0].Value = en;
            param[1] = new OleDbParameter("@ar", DbType.String);
            param[1].Value = ar;
            param[2] = new OleDbParameter("@fr", DbType.String);
            param[2].Value = fr;
            param[3] = new OleDbParameter("@idSub_section", DbType.Int32);
            param[3].Value = idItem;
            db.ExecuteCommand(query, param);
        }
        public void update(int idSelection, string en, string ar, string fr, int idSub_section)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"UPDATE tblSelections SET 
                                 selectionNameEn=@en
                                 ,selectionNameAr=@ar
                                 ,selectionNameFr=@fr
                                 ,id_Sub_section=@idSub_section
                                  WHERE idSelection=@idSelection";
            OleDbParameter[] param = new OleDbParameter[5];
            param[0] = new OleDbParameter("@en", DbType.String);
            param[0].Value = en;
            param[1] = new OleDbParameter("@ar", DbType.String);
            param[1].Value = ar;
            param[2] = new OleDbParameter("@fr", DbType.String);
            param[2].Value = fr;
            param[3] = new OleDbParameter("@idSub_section", DbType.Int32);
            param[3].Value = idSub_section;
            param[4] = new OleDbParameter("@idSelection", DbType.Int32);
            param[4].Value = idSelection;
            db.ExecuteCommand(query, param);
        }
        public void delete(int idSelection)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"DELETE  FROM  tblSelections 
                            WHERE idSelection=@idSelection";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@idSelection", DbType.Int32);
            param[0].Value = idSelection;
            db.ExecuteCommand(query, param);
        }
        public DataTable search(string searchWord, int idSub_section)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"select idSelection AS " + Words.idSection
                                + ",selectionNameEn  AS " + Words.En
                                + ",selectionNameAr AS " + Words.Ar
                                + ",selectionNameFr AS " + Words.Fr
                                + " from tblSelections WHERE  id_Sub_section=@idSub_section" +
                                " AND idSelection & selectionNameEn & selectionNameAr & selectionNameFr LIKE '%'+@searchWord+'%'";
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@idSub_section", DbType.Int32);
            param[0].Value = idSub_section;
            param[1] = new OleDbParameter("@searchWord", DbType.String);
            param[1].Value = searchWord;
            return db.SelectData(query, param); ;
        }
        public void fillCombo(ComboBox cmb, string language, int idItem)
        {
            cmb.DataSource = this.getDetails(idItem);
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
        public void fillCombo(ComboBox cmb, string language, string searchWord, int idItem)
        {
            cmb.DataSource = this.search(searchWord, idItem);
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
