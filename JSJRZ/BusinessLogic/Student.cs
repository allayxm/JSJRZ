using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    public class Student: BusinessLogicBase
    {
        public Edu_StudentsEF QueryStudentByID( int ID )
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Edu_StudentsEF>(ID);
        }
    }
}
