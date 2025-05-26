namespace Headlinr_System2.Models.DTOs.Output
{
    public class SoapRssFeed
    {
        public string Version { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public SoapItem[] Items { get; set; } = [];

    }
    public class SoapItem
    {
        public SoapGuidElement Guid { get; set; } = new();
        public string Link { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PubDate { get; set; } = string.Empty;
        public SoapMrssGroup Group { get; set; } = new();
        public SoapMrssContent[] MrssContents { get; set; } = [];
        public SoapMrssContent InlineContent { get; set; } = new();
        public string MrssCredit { get; set; } = string.Empty;
        public string InlineCredit { get; set; } = string.Empty;
    }

    public class SoapGuidElement
    {
        public bool IsPermaLink { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class SoapMrssGroup
    {
        public SoapMrssContent[] Contents { get; set; } = [];
        public string Credit { get; set; } = string.Empty;
    }

    public class SoapMrssContent
    {
        public int Width { get; set; }
        public string Url { get; set; } = string.Empty;
    }

}