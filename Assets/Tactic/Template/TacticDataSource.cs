using UnityEngine;
using System.Collections;
using System.Data;

public class TacticDataSource
{
    public event System.Action<DataSet> OnFinishLoaded = null;

    public void Load ()
    {
        DataSet set = new DataSet ();
        DataTable paper = new DataTable ("Paper");
        paper.Columns.Add (new DataColumn ("Id", typeof(int)));
        paper.Columns.Add (new DataColumn ("Title", typeof(string)));
        paper.Columns["Id"].AutoIncrement = true;
        paper.Columns["Id"].AutoIncrementStep = 1;
        paper.Columns["Id"].AutoIncrementSeed = 1;
        paper.PrimaryKey = new DataColumn[] {paper.Columns ["Id"]};
        set.Tables.Add (paper);
        
        DataTable function = new DataTable ("Function");
        function.Columns.Add (new DataColumn ("Id", typeof(int)));
        function.Columns.Add (new DataColumn ("PaperId", typeof(int)));
        function.Columns.Add (new DataColumn ("Type", typeof(int)));
        function.Columns.Add (new DataColumn ("SubType", typeof(int)));
        function.Columns.Add (new DataColumn ("Title", typeof(string)));
        function.Columns.Add (new DataColumn ("NParam1", typeof(int)));
        function.Columns.Add (new DataColumn ("NParam2", typeof(int)));
        function.Columns["Id"].AutoIncrement = true;
        function.Columns["Id"].AutoIncrementStep = 1;
        function.Columns["Id"].AutoIncrementSeed = 1;
        function.PrimaryKey = new DataColumn[] {function.Columns ["Id"]};

        set.Tables.Add (function);

        set.Relations.Add (new DataRelation (
            "PaperFunctions",
            paper.Columns ["Id"],
            function.Columns ["PaperId"]
        ));

        for (int i =0; i<10; i++) {
            DataRow r = paper.NewRow();
            r["Title"] = string.Format ("Example Paper {0}", i.ToString());
            paper.Rows.Add(r);
        }
        paper.AcceptChanges ();

        foreach (DataRow r in paper.Rows) {
            DataRow fr = function.NewRow();
            fr["PaperId"] = r["Id"];
            fr["Type"] = 1;
            fr["SubType"] = 1;
            fr["Title"] = "Example Condition 1";
            fr["NParam1"] = 0;
            fr["NParam2"] = 0;
            function.Rows.Add (fr);
        }
        function.AcceptChanges();

        CallFinishLoaded(set);
    }

    private void CallFinishLoaded(DataSet set) {
        if (OnFinishLoaded != null) {
            OnFinishLoaded.Invoke(set);
        }
    }
}
