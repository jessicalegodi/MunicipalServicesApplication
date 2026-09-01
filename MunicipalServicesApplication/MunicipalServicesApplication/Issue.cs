using System;

namespace MunicipalServicesApplication
{
    public class Issue
    {
        public int IssueId { get; set; }

        public string Location { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Attachment { get; set; }

        public DateTime DateReported { get; set; }
    }
}
