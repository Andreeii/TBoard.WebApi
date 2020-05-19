namespace TBoard.Entities
{
    public class PlayerGame:BaseEntity
    {
        public int? PlayerId { get; set; }
        public int GameId { get; set; }
        public bool? IsWinner { get; set; }

        public virtual Game Games { get; set; }
        public virtual Player Players { get; set; }
    }
}
