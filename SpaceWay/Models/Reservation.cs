﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaceWay.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public int PassengerID { get; set; }
        public virtual Passenger Passenger { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        //[ForeignKey("Flight")]
        public int OutboundID { get; set; }
        public virtual Flight Outbound { get; set; }

        //[ForeignKey("Flight")]
        public int InboundID { get; set; }
        public virtual Flight Inbound { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid Number Of Tickets Enterd Please Enter Positive Number")]
        public int NumOfTickets { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Total Price Enterd Please Enter Positive Number")]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

    }
}