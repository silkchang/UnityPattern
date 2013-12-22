using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public enum TacticTemplateFunctionKind {
    NONE = 0,
    CONDITION,
}


public class TacticTemplate
{
    static private bool mIsInitial = false;
    static private DataSet mSet = null;

    static public void Initial ()
    {
        if (mIsInitial) {
            return;
        }

        TacticDataSource source = new TacticDataSource ();
        source.OnFinishLoaded += OnFinishLoaded;
        source.Load ();
    }

    static public bool IsReady() {
        return mSet != null;
    }

    static public bool IsExistPaper(int paperId) {
        if (!IsReady()) {
            return false;
        }

        DataView v = new DataView(mSet.Tables["Paper"]);
        v.RowFilter = string.Format("Id = {0}", paperId);
        return (v.Count != 0);
    }

    static public DataView Conditions(int paperId) {
        if (!IsReady()) {
            return new DataView();
        }
        
        DataView v = new DataView(mSet.Tables["Function"]);
        v.RowFilter = string.Format("PaperId = {0} AND Type = {1}", paperId, 1);

        return v;
    }

    static private void OnFinishLoaded (DataSet set) {
        mSet = set;
    }
}
