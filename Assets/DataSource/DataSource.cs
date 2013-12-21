using UnityEngine;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


public class DataSource : MonoBehaviour
{
    public string ConnectionString = "";
    public string QueryString = "";

    private DataTable mDataTable = null;

    void Awake() {
        SqlConnection con = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand(QueryString, con);
        SqlDataReader data = cmd.ExecuteReader();
        mDataTable = new DataTable();
        mDataTable.Load(data);
    }
}
