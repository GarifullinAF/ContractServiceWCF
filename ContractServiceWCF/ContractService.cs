using System;
using System.Collections.Generic;
using ContractService.Model.Interfaces;
using ContractService.Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections.Specialized;

namespace ContractServiceWCF
{
    public class ContractService : IContractService
    {
        public IEnumerable<Contract> GetContracts()
        {
            SqlConnection objConnection = new SqlConnection();
            DataSet ObjDataset = new DataSet();
            SqlDataAdapter objAdapater = new SqlDataAdapter();
            SqlCommand objCommand = new SqlCommand("Select * from Contract");            
            objConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\adm_GarifullinAF\\source\\repos\\ContractServiceWCF\\ContractServiceWCF\\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            objCommand.Connection = objConnection;
            objAdapater.SelectCommand = objCommand;
            objAdapater.Fill(ObjDataset);

            var contracts = new List<Contract>();
            for (int i = 0; i < ObjDataset.Tables[0].Rows.Count; i++)
            {
                var id = int.Parse(ObjDataset.Tables[0].Rows[i][0].ToString());
                var contractDate = DateTime.Parse(ObjDataset.Tables[0].Rows[i][1].ToString());
                var contractUpdateDate = DateTime.Parse(ObjDataset.Tables[0].Rows[i][2].ToString());
                var contract = new Contract(id, contractDate, contractUpdateDate);                

                contracts.Add(contract);
            }

            objConnection.Close();
            return contracts;
        }
    }
}
