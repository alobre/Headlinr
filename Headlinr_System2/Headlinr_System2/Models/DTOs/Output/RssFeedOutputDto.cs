namespace Headlinr_System2.Models.DTOs.Output
{
    public class RssFeedOutputDto
    {
        public string Version { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public IEnumerable<Item> Items { get; set; } = [];

    }
    public class Item
    {
        public GuidElement Guid { get; set; } = new();
        public string Link { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PubDate { get; set; } = string.Empty;
        public MrssGroup Group { get; set; } = new();
        public IEnumerable<MrssContent> MrssContents { get; set; } = [];
        public MrssContent InlineContent { get; set; } = new();
        public string MrssCredit { get; set; } = string.Empty;
        public string InlineCredit { get; set; } = string.Empty;
    }

    public class GuidElement
    {
        public bool IsPermaLink { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class MrssGroup
    {
        public IEnumerable<MrssContent> Contents { get; set; } = [];
        public string Credit { get; set; } = string.Empty;
    }

    public class MrssContent
    {
        public int Width { get; set; }
        public string Url { get; set; } = string.Empty;
    }

}
