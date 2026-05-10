namespace Aladin.Domain.Models
{
    public enum RequestStatus
    {
        Pending = 0,     // Client just submitted the request
        Contacted = 1,   // Admin called the client
        Approved = 2,    // Leasing company accepted
        Rejected = 3     // Refused
    }
}
