using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ParkingBooking.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        IEnumerable<BookingsTable> GetBookings(bool get);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    public class BookingsTable
    {
        [DataMember]
        public Guid BookingId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string CarPlate { get; set; }
        [DataMember]
        public string BookedDates { get; set; }
        [DataMember]
        public int NumberofDaysBooked { get; set; }
        [DataMember]
        public DateTime? BookedOn { get; set; }

        //[DataMember]
        //public virtual PaymentTranscationTable PaymentTranscationTable { get; set; }
    }


    //public partial class PaymentTranscationTable
    //{
    //    [DataMember]
    //    public Guid BookingId { get; set; }
    //    public string PaymentTranscationId { get; set; }
    //    public int AmountPaid { get; set; }
    //    public string StripResponse { get; set; }
    //    public Guid Id { get; set; }

    //    [JsonIgnore]
    //    public virtual BookingsTable Booking { get; set; }
    //}
}
