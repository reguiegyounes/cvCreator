using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CV_creator.Entity
{
    class cItem2
    {
        cDetails detail = new cDetails();
        public DataTable getItems(int idSection)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"select idSub_section AS " + Words.idSection
                                + ",sub_sectionNameEn  AS " + Words.En
                                + ",sub_sectionNameAr AS " + Words.Ar
                                + ",sub_sectionNameFr AS " + Words.Fr
                                + " from tblSub_sections WHERE id_Section=@id ORDER BY idSub_section";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@id", DbType.Int32);
            param[0].Value = idSection;
            DataTable dt = new DataTable();
            dt = db.SelectData(query, param);
            return dt;
        }
        public DataTable getItemsNotRepeat(int idSection, int idPerson)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            DataTable dtSection = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT repeatItem FROM tblSections WHERE idSection=" + idSection, db.Connection);
            da.Fill(dtSection);
            bool isRepeat = (bool)dtSection.Rows[0][0];
            string query = "";
            OleDbParameter[] param = new OleDbParameter[0];
            if (isRepeat)
            {
                query = @"select idSub_section AS " + Words.idSection
                                + ",sub_sectionNameEn  AS " + Words.En
                                + ",sub_sectionNameAr AS " + Words.Ar
                                + ",sub_sectionNameFr AS " + Words.Fr
                        + " from tblSub_sections WHERE id_Section=@id ORDER BY idSub_section";
                param = new OleDbParameter[1];
                param[0] = new OleDbParameter("@id", DbType.Int32);
                param[0].Value = idSection;
            }
            else
            {
                query = query = @"select ii.idSub_section AS " + Words.idSection
                        + ",sub_sectionNameEn  AS " + Words.En
                        + ",sub_sectionNameAr AS " + Words.Ar
                        + ",sub_sectionNameFr AS " + Words.Fr
                        + " FROM tblSub_sections ii "
                        + " INNER JOIN (select idSub_section "
                                    + "FROM tblSub_sections "
                                    + "WHERE idSub_section NOT IN(SELECT id_Sub_section FROM(tblCv c INNER JOIN tblSelections d "
                                                        + "ON c.id_Selection = d.idSelection) "
                                    + "INNER JOIN tblSub_sections i ON i.idSub_section = d.id_Sub_section "
                                    + "WHERE id_Section = @id_Section AND id_Person=@id_Person "
                                    + "GROUP BY id_Sub_section)) t "
                        + "ON ii.idSub_section = t.idSub_section "
                        + "WHERE id_Section = @id_Section ORDER BY ii.idSub_section";
                param = new OleDbParameter[2];
                param[0] = new OleDbParameter("@id_Section", DbType.Int32);
                param[0].Value = idSection;
                param[1] = new OleDbParameter("@id_Person", DbType.Int32);
                param[1].Value = idPerson;
            }
            DataTable dt = new DataTable();
            dt = db.SelectData(query, param);
            return dt;
        }
        public void insert(string en, string ar, string fr, int idSection)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"insert into tblSub_sections(sub_sectionNameEn,sub_sectionNameAr,sub_sectionNameFr,id_Section) values (@en,@ar,@fr,@id_Section)";
            OleDbParameter[] param = new OleDbParameter[4];
            param[0] = new OleDbParameter("@en", DbType.String);
            param[0].Value = en;
            param[1] = new OleDbParameter("@ar", DbType.String);
            param[1].Value = ar;
            param[2] = new OleDbParameter("@fr", DbType.String);
            param[2].Value = fr;
            param[3] = new OleDbParameter("@idSection", DbType.Int32);
            param[3].Value = idSection;
            db.ExecuteCommand(query, param);

            DataTable dtItem = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT LAST(idSub_section) FROM tblSub_sections", db.Connection);
            da.Fill(dtItem);
            int idItem = (int)dtItem.Rows[0][0];
            detail.insert("", "", "", idItem);
        }
        public void update(string en, string ar, string fr, int idSection, int idSub_section)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"UPDATE tblSub_sections SET 
                                 sub_sectionNameEn=@en
                                 ,sub_sectionNameAr=@ar
                                 ,sub_sectionNameFr=@fr
                                ,id_Section=@idSection
                                  WHERE idSub_section=@idSub_section ";
            OleDbParameter[] param = new OleDbParameter[5];

            param[0] = new OleDbParameter("@en", DbType.String);
            param[0].Value = en;
            param[1] = new OleDbParameter("@ar", DbType.String);
            param[1].Value = ar;
            param[2] = new OleDbParameter("@fr", DbType.String);
            param[2].Value = fr;
            param[3] = new OleDbParameter("@idSection", DbType.Int32);
            param[3].Value = idSection;
            param[4] = new OleDbParameter("@idSub_section", DbType.Int32);
            param[4].Value = idSub_section;
            db.ExecuteCommand(query, param);
        }
        public void delete(int idItem)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"DELETE  FROM  tblSub_sections 
                            WHERE idSub_section=@id ";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@id", DbType.Int32);
            param[0].Value = idItem;

            db.ExecuteCommand(query, param);
        }
        public void fillCombo(ComboBox cmb, string language, int idSection)
        {
            cmb.DataSource = this.getItems(idSection);
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
        public void fillCombo(ComboBox cmb, string language, int idSection, int idPerson)
        {
            cmb.DataSource = this.getItemsNotRepeat(idSection, idPerson);
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
