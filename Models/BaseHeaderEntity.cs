using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_webapi.Models
{
    public abstract class BaseHeaderEntity : BaseEntity
    {
              
        // Completion Date (specific)
        public DateTime? CompletionDate { get; set; } // kayıt tamamlanma tarihi
        public bool IsCompleted { get; set; } = false;
        

        // Approval Fields (ERP specific)
        public bool IsPendingApproval { get; set; } = false; // Onaya gönderilecek mi? default false
        public bool? ApprovalStatus { get; set; } // Onay durumu (true = Approved, false = Rejected, null = Pending)
        public int? ApprovedByUserId { get; set; } // Onaylayan kullanıcı ID
        public DateTime? ApprovalDate { get; set; } // Onay tarihi
        public bool IsERPIntegrated { get; set; } = false;
        public string? ERPIntegrationNumber { get; set; } // ERP kayıt referansı
        public DateTime? LastSyncDate { get; set; } // ERP'ye en son gönderim tarihi
        public int? CountTriedBy { get; set; } = 0; // kaç kez denedik

    }
}
