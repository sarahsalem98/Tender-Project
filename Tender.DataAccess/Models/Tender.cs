using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class Tender:TimeStamp
    {
        public int Id { get; set; }

        public Activity Activity { get; set; }
        [ForeignKey("ActivityId")]
        public int? ActivityId { get; set; }

        public City City { get; set; }
        [ForeignKey("CityId")]
        public int? CityId { get; set; }


        public Government Government { get; set; }
        [ForeignKey("GovernmentId")]
        public int? GovernmentId { get; set; }
        public TechnicalSide TechnicalSide { get; set; }
        [ForeignKey("TechnicalSideId")]
        public int? TechnicalSideId { get; set; }

        public OpeningEnvelopeCommittee OpeningEnvelopeCommittee { get; set; }
        [ForeignKey("OpeningEnvelopeCommitteeId")]
        public int? OpeningEnvelopeCommitteeId { get; set; }
        public OffersExaminationCommitte OffersExaminationCommitte { get; set; }
        [ForeignKey("OffersExaminationCommitteId")]
        public int? OffersExaminationCommitteId { get; set; }




      
        public int State { get; set; }


    
        public int CategoryType { get; set; }


        public int TarsiaType { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

       //public int TermsOfReferenceValue { get; set; }
        public string ReferenceNumber { get; set; }

       // public int PrimaryInsuranceValue { get; set; }
        public string? PlaceOfOpeningEnvelops { get; set; }
        public string? SiteDetails { get; set; }

        //ManualReceivingAddress  is special for the attachments
        public string? ManualReceivingAddress { get; set; }


        //

        public string? SumbittingOffersPlace { get; set; }

        public string? ExecutionPlace { get; set; }
        public string? ActivityDescription { get; set; }

        //Dates

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime InquiriesDeadline { get; set; }


        public DateTime RecievingOffersDeadline { get; set; }




        public DateTime OpeningEnvelposDate { get; set; }




        public DateTime CheckOffersDate { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime ExpectingResultsDate { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? PublishingDate { get; set; }


        public string? ApprovedBy { get; set; }

       // public IList<TenderAttachment> TenderAttachments { get; set; }
    }
}
