using System.Xml.Serialization;

[XmlRoot("rss")]
public class RssFeedInputDto
{
    [XmlAttribute("version")] public string Version { get; set; } = string.Empty;

    [XmlElement("channel")] public Channel Channel { get; set; } = new();
}

public class Channel
{
    [XmlElement("title")] public string Title { get; set; } = string.Empty;

    [XmlElement("link")] public string Link { get; set; } = string.Empty;

    [XmlElement("description")] public string Description { get; set; } = string.Empty;

    [XmlElement("language")] public string Language { get; set; } = string.Empty;

    [XmlElement("item")] public List<Item> Items { get; set; } = [];
}

public class Item
{
    [XmlElement("guid")] public GuidElement Guid { get; set; } = new();

    [XmlElement("link")] public string Link { get; set; } = string.Empty;

    [XmlElement("title")] public string Title { get; set; } = string.Empty;

    [XmlElement("description")] public string Description { get; set; } = string.Empty;

    [XmlElement("pubDate")] public string PubDate { get; set; } = string.Empty;

    [XmlElement("group", Namespace = "http://search.yahoo.com/mrss/")]
    public MrssGroup Group { get; set; } = new();

    // There are two <content> elements in the MRSS namespace and one in default
    [XmlElement("content", Namespace = "http://search.yahoo.com/mrss/")]
    public List<MrssContent> MrssContents { get; set; } = [];

    [XmlElement("content")] public MrssContent InlineContent { get; set; } = new();

    // Likewise for <credit>
    [XmlElement("credit", Namespace = "http://search.yahoo.com/mrss/")]
    public string MrssCredit { get; set; } = string.Empty;

    [XmlElement("credit")] public string InlineCredit { get; set; } = string.Empty;
}

public class GuidElement
{
    [XmlAttribute("isPermaLink")]
    public bool IsPermaLink { get; set; }

    [XmlText] public string Value { get; set; } = string.Empty;
}

[XmlType(Namespace = "http://search.yahoo.com/mrss/")]
public class MrssGroup
{
    [XmlElement("content")] public List<MrssContent> Contents { get; set; } = [];

    [XmlElement("credit")] public string Credit { get; set; } = string.Empty;
}

[XmlType(Namespace = "http://search.yahoo.com/mrss/")]
public class MrssContent
{
    [XmlAttribute("width")]
    public int Width { get; set; }

    [XmlAttribute("url")] public string Url { get; set; } = string.Empty;
}
