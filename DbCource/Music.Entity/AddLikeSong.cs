namespace Music.UI.Dtos;
public class AddLikeSong
{
    public Guid AlbumID { get; set; } = Guid.NewGuid();
    public Guid MusicID { get; set; } = Guid.NewGuid();
    public Guid SingerID { get; set; } = Guid.NewGuid();
    public Guid SongID { get; set; } = Guid.NewGuid();
    public Guid SongTableID { get; set; } = Guid.NewGuid();
    public Guid UserID { get; set; } = Guid.NewGuid();
    public string SongTableName { get; set; } = "默认";

}
