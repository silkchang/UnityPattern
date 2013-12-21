using UnityEngine;
using System.Collections;
using System.Data;

public class TacticTemplate : MonoBehaviour
{
    static private bool mIsInitial = false;
    static private DataSet mSet = new DataSet ();
    
    static public void Initial ()
    {
        if (mIsInitial) {
            return;
        }
        
        DataTable paper = new DataTable ("Paper");
        paper.Columns.Add (new DataColumn ("Id", typeof(int)));
        paper.Columns.Add (new DataColumn ("Title", typeof(string)));

        DataRow row = paper.NewRow ();
        row.ItemArray = new object[] {1, "Example Timer"};
        paper.Rows.Add (row);

        mSet.Tables.Add (paper);
    }
    
    static public DataTable Paper ()
    {
        return mSet.Tables ["Paper"];
    }

//    static string PaperTitle(int paperId) {
//        if (!mSet.Tables.Contains("Paper")){
//            return "";
//        }
//
//        return "Example Timer";
//    }
}
