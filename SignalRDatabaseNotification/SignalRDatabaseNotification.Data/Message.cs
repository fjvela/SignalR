namespace SignalRDatabaseNotification.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int MessageID { get; set; }

        [Column("Message")]
        [StringLength(50)]
        public string MessageText { get; set; }

        public DateTime? Date { get; set; }
    }
}
