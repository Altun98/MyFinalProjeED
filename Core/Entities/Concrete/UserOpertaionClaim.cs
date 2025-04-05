namespace Core.Entities.Concrete
{
    public class UserOpertaionClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OpertaionClaimId { get; set; }
    }
}
