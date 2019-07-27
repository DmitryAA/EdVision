using System;
using System.Collections.Generic;


namespace EdVision.Models {
    public enum ContactType {
        Phone,
        Email,
        Postalddress, 
        UrlAddress,
        SocialProfiles,
        Location
    }

    public class Contact {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}