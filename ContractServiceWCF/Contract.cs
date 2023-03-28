using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ContractServiceWCF
{
    [DataContract]
    public class Contract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime UpdateDate { get; set; }
        public bool IsActual
        {
            get
            {
                return DateTime.Now.Subtract(UpdateDate).Days < 60;
            }
        }

        public Contract(int id, DateTime date, DateTime updateDate)
        {
            Id = id;
            Date = date;
            UpdateDate = updateDate;
        }
    }
}
