
using System;
using System.Data;
using System.Data.OleDb;

namespace CV_creator.Entity
{
    class cCV
    {

        public DataTable getCv(int id_Person, string language)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = "";
            switch (language)
            {
                case "ar":
                    {
                        query = @"SELECT idCvItem,sectionNameAr AS [" + Words.Section + "]"
                            + ", sub_sectionNameAr AS [" + Words.Sub_section + "], selectionNameAr AS [" + Words.Selection + "]"
                            + ",moreDetailAr AS [" + Words.More + "],order_ AS [" + Words.Order + "]"
                            + ",idSelection,idSub_section,idSection,moreDetailEn,moreDetailFr "
                            + "FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) "
                            + "INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) "
                            + "INNER JOIN tblSections s ON i.id_Section=s.idSection "
                            + "WHERE id_Person=@id_Person " +
                            "ORDER BY idSection,order_";
                    }
                    break;
                case "fr":
                    {
                        query = @"SELECT idCvItem,sectionNameFr AS [" + Words.Section + "]"
                            + ", sub_sectionNameFr AS [" + Words.Sub_section + "], selectionNameFr AS [" + Words.Selection + "]"
                            + ",moreDetailFr AS [" + Words.More + "],order_ AS [" + Words.Order + "]"
                            + ",idSelection,idSub_section,idSection,moreDetailEn,moreDetailAr "
                            + "FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) "
                            + "INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) "
                            + "INNER JOIN tblSections s ON i.id_Section=s.idSection "
                            + "WHERE id_Person=@id_Person " +
                            "ORDER BY idSection,order_";
                    }
                    break;
                default:
                    {
                        query = @"SELECT idCvItem,sectionNameEn AS [" + Words.Section + "]"
                            + ", sub_sectionNameEn AS [" + Words.Sub_section + "], selectionNameEn AS [" + Words.Selection + "]"
                            + ",moreDetailEn AS [" + Words.More + "],order_ AS [" + Words.Order + "]"
                            + ",idSelection,idSub_section,idSection,moreDetailAr,moreDetailFr "
                            + "FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) "
                            + "INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) "
                            + "INNER JOIN tblSections s ON i.id_Section=s.idSection "
                            + "WHERE id_Person=@id_Person " +
                            "ORDER BY idSection,order_";
                    }
                    break;
            }
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@id_Person", DbType.Int32);
            param[0].Value = id_Person;
            return db.SelectData(query, param); ;
        }
        public DataTable getCv(int id_Person, int idSection, string language)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = "";
            switch (language)
            {
                case "ar":
                    {
                        query = @"SELECT idCvItem,sectionNameAr AS [" + Words.Section + "]"
                            + ", sub_sectionNameAr AS [" + Words.Sub_section + "], selectionNameAr AS [" + Words.Selection + "]"
                            + ",moreDetailAr AS [" + Words.More + "],order_ AS [" + Words.Order + "]"
                            + ",idSelection,idSub_section,idSection,moreDetailEn,moreDetailFr "
                            + "FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) "
                            + "INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) "
                            + "INNER JOIN tblSections s ON i.id_Section=s.idSection "
                            + "WHERE id_Person=@id_Person AND idSection=@idSection " +
                            "ORDER BY order_";
                    }
                    break;
                case "fr":
                    {
                        query = @"SELECT idCvItem,sectionNameFr AS [" + Words.Section + "]"
                            + ", sub_sectionNameFr AS [" + Words.Sub_section + "], selectionNameFr AS [" + Words.Selection + "]"
                            + ",moreDetailFr AS [" + Words.More + "],order_ AS [" + Words.Order + "]"
                            + ",idSelection,idSub_section,idSection,moreDetailEn,moreDetailAr "
                            + "FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) "
                            + "INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) "
                            + "INNER JOIN tblSections s ON i.id_Section=s.idSection "
                            + "WHERE id_Person=@id_Person AND idSection=@idSection " +
                            "ORDER BY order_";
                    }
                    break;
                default:
                    {
                        query = @"SELECT idCvItem,sectionNameEn AS [" + Words.Section + "]"
                            + ", sub_sectionNameEn AS [" + Words.Sub_section + "], selectionNameEn AS [" + Words.Selection + "]"
                            + ",moreDetailEn AS [" + Words.More + "],order_ AS [" + Words.Order + "]"
                            + ",idSelection,idSub_section,idSection,moreDetailAr,moreDetailFr "
                            + "FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) "
                            + "INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) "
                           + "INNER JOIN tblSections s ON i.id_Section=s.idSection "
                           + "WHERE id_Person=@id_Person AND idSection=@idSection " +
                            "ORDER BY order_";
                    }
                    break;
            }
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@id_Person", DbType.Int32);
            param[0].Value = id_Person;
            param[1] = new OleDbParameter("@idSection", DbType.Int32);
            param[1].Value = idSection;
            return db.SelectData(query, param); ;
        }
        public void insert(string en, string ar, string fr, int order, int id_Selection, int id_Person)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"insert into tblCv(moreDetailEn,moreDetailAr,moreDetailFr
                            ,order_,id_Selection,id_Person) VALUES (@en,@ar,@fr,@order,@id_Selection,@id_Person)";
            OleDbParameter[] param = new OleDbParameter[6];
            param[0] = new OleDbParameter("@en", DbType.String);
            param[0].Value = en;
            param[1] = new OleDbParameter("@ar", DbType.String);
            param[1].Value = ar;
            param[2] = new OleDbParameter("@fr", DbType.String);
            param[2].Value = fr;
            param[3] = new OleDbParameter("@order", DbType.Int32);
            param[3].Value = order;
            param[4] = new OleDbParameter("@id_Selection", DbType.Int32);
            param[4].Value = id_Selection;
            param[5] = new OleDbParameter("@id_Person", DbType.Int32);
            param[5].Value = id_Person;
            db.ExecuteCommand(query, param);
        }
        public void update(int idCvItem, string en, string ar, string fr, int order, int id_Selection, int id_Person)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"UPDATE tblCv SET 
                                    moreDetailEn=@en
                                    ,moreDetailAr=@ar
                                    ,moreDetailFr=@fr
                                    ,order_=@order
                                    ,id_Selection=@id_Selection
                                    ,id_Person=@id_Person
                                    WHERE idCvItem=@idCvItem";
            OleDbParameter[] param = new OleDbParameter[7];
            param[0] = new OleDbParameter("@en", DbType.String);
            param[0].Value = en;
            param[1] = new OleDbParameter("@ar", DbType.String);
            param[1].Value = ar;
            param[2] = new OleDbParameter("@fr", DbType.String);
            param[2].Value = fr;
            param[3] = new OleDbParameter("@order", DbType.Int32);
            param[3].Value = order;
            param[4] = new OleDbParameter("@id_Selection", DbType.Int32);
            param[4].Value = id_Selection;
            param[5] = new OleDbParameter("@id_Person", DbType.Int32);
            param[5].Value = id_Person;
            param[6] = new OleDbParameter("@idCvItem", DbType.Int32);
            param[6].Value = idCvItem;
            db.ExecuteCommand(query, param);
        }
        public void delete(int idCvItem)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"DELETE  FROM  tblCv 
                            WHERE idCvItem=@idCvItem";
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@idCvItem", DbType.Int32);
            param[0].Value = idCvItem;
            db.ExecuteCommand(query, param);
        }
        private void drop_tblReport()
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = @"DROP TABLE tblReport";
            db.ExecuteCommand(query, null);
        }
        private void create_tblReport(int id_Person, string language)
        {
            MSAccessDatabase db = new MSAccessDatabase();
            string query = "";
            switch (language)
            {
                case "ar":
                    {
                        query = @"SELECT sectionNameAr AS [section], sub_sectionNameAr AS item 
                            ,(selectionNameAr+' '+moreDetailAr) AS detail
                            ,order_ AS [order] ,idSection into tblReport
                            FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) 
                            INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) 
                            INNER JOIN tblSections s ON i.id_Section=s.idSection WHERE id_Person=@id_Person 
                            ORDER BY idSection,order_";
                    }
                    break;
                case "fr":
                    {
                        query = @"SELECT sectionNameFr AS [section], sub_sectionNameFr AS item 
                            ,(selectionNameFr+' '+moreDetailFr) AS detail
                            ,order_ AS [order] ,idSection into tblReport
                            FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) 
                            INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) 
                            INNER JOIN tblSections s ON i.id_Section=s.idSection WHERE id_Person=@id_Person 
                            ORDER BY idSection,order_";
                    }
                    break;
                default:
                    {
                        query = @"SELECT sectionNameEn AS [section], sub_sectionNameEn AS item 
                            ,(selectionNameEn+' '+moreDetailEn) AS detail
                            ,order_ AS [order] ,idSection into tblReport
                            FROM ((tblCv c INNER JOIN tblSelections d ON c.id_Selection=d.idSelection) 
                            INNER JOIN tblSub_sections i ON d.id_Sub_section=i.idSub_section) 
                            INNER JOIN tblSections s ON i.id_Section=s.idSection WHERE id_Person=@id_Person 
                            ORDER BY idSection,order_";
                    }
                    break;
            }
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@id_Person", DbType.Int32);
            param[0].Value = id_Person;
            db.ExecuteCommand(query, param);
        }

        public void createReport(int id_Person, string language)
        {
            try
            {
                create_tblReport(id_Person, language);
            }
            catch (Exception)
            {
                drop_tblReport();
                create_tblReport(id_Person, language);
            }
        }
    }
}
