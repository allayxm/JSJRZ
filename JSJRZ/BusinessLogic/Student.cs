using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;
using System.Data;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    public class Student : BusinessLogicBase
    {
        public Edu_StudentsEF QueryStudentByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Edu_StudentsEF>(ID);
        }


        public OrgStruct[] GetAllGrade()
        {
            DataTable vTable = m_BasicDBClass.SelectCustom("Select *From edu_org where level_type=3");
            List<OrgStruct> vGradeList = new List<OrgStruct>();
            foreach ( DataRow vTempRow in vTable.Rows )
            {
                OrgStruct vNewGrade = new OrgStruct()
                {
                    ID = DBConvert.ToInt32(vTempRow["ID"]).Value,
                    Name = DBConvert.ToString(vTempRow["Name"])+ DBConvert.ToString(vTempRow["Normal_Name"])
                };
                vGradeList.Add(vNewGrade);
            }
            return vGradeList.ToArray();
        }

        public OrgStruct[] QueryClassByGrade( int GradeID)
        {
            DataTable vTable = m_BasicDBClass.SelectCustom(string.Format( "Select *From edu_org where parent_id={0}",GradeID));
            List<OrgStruct> vGradeList = new List<OrgStruct>();
            foreach (DataRow vTempRow in vTable.Rows)
            {
                OrgStruct vNewGrade = new OrgStruct()
                {
                    ID = DBConvert.ToInt32(vTempRow["ID"]).Value,
                    Name = DBConvert.ToString(vTempRow["Name"])
                };
                vGradeList.Add(vNewGrade);
            }
            return vGradeList.ToArray();
        }

        public StudentStruct[] QueryStudent(int GradeID, int ClassID, string StudentName)
        {
            StudentStruct[] vResutl = new StudentStruct[0];
            DataTable vTable = new DataTable();
            string vSql = "";
            if (GradeID == 0 && ClassID == 0)
                vSql = "Select *From edu_students";
            else if (GradeID != 0 && ClassID == 0)
                vSql = string.Format("Select edu_students.* From edu_students left join edu_org on edu_org.id=edu_students.org_id where edu_org.level_type=4 and edu_org.parent_id='{0}'", GradeID);
            else if (GradeID != 0 && ClassID != 0)
                vSql = string.Format("Select * From edu_students Where org_id={0}", ClassID);
            vTable = m_BasicDBClass.SelectCustom(vSql);
            DataRow[] vSelectRow = null;
            if (StudentName == "")
                vSelectRow = vTable.Select();
            else
                vSelectRow = vTable.Select(string.Format("Name Like '*{0}*'", StudentName));
            if (vSelectRow .Length>0)
            {
                vResutl = new StudentStruct[vSelectRow.Length];
                for( int i=0;i<vResutl.Length;i++)
                {
                    vResutl[i] = new StudentStruct();
                    vResutl[i].ID = DBConvert.ToInt32(vSelectRow[i]["ID"]).Value;
                    vResutl[i].Name = DBConvert.ToString(vSelectRow[i]["Name"]);
                }
            }
            vTable.Clear();
            return vResutl;
        }
    }

    public class OrgStruct
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class StudentStruct
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
