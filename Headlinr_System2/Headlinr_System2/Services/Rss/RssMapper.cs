﻿using Headlinr_System2.Models.DTOs.Output;

namespace Headlinr_System2.Services.Rss
{
    public static class RssMapper
    {
        public static SoapItem MapItemToSoap(this Models.DTOs.Output.Item input)
        {
            return  new SoapItem()
            {
                Description = input.Description,
                PubDate = input.PubDate,
                Title = input.Title,
                Link = input.Link,
                InlineCredit = input.InlineCredit,
                MrssCredit = input.MrssCredit,
                Group = new SoapMrssGroup()
                {
                    Credit = input.Group.Credit,
                    Contents = input.Group.Contents.Select(content => new SoapMrssContent
                    {
                        Url = content.Url,
                        Width = content.Width
                    }).ToArray()
                },
                Guid = new SoapGuidElement()
                {
                    IsPermaLink = input.Guid.IsPermaLink,
                    Value = input.Guid.Value
                },
                MrssContents = input.MrssContents.Select(content => new SoapMrssContent
                {
                    Url = content.Url,
                    Width = content.Width
                }).ToArray(),
                InlineContent = new SoapMrssContent
                {
                    Url = input.InlineContent.Url,
                    Width = input.InlineContent.Width
                }
            };
        }

        public static SoapItem[] MapToSoap(this IEnumerable<Models.DTOs.Output.Item> input)
        {
            return input.Select(item => new SoapItem()
            {
                Description = item.Description,
                PubDate = item.PubDate,
                Title = item.Title,
                Link = item.Link,
                InlineCredit = item.InlineCredit,
                MrssCredit = item.MrssCredit,
                Group = new SoapMrssGroup()
                {
                    Credit = item.Group.Credit,
                    Contents = item.Group.Contents.Select(content => new SoapMrssContent
                    {
                        Url = content.Url,
                        Width = content.Width
                    }).ToArray()
                },
                Guid = new SoapGuidElement()
                {
                    IsPermaLink = item.Guid.IsPermaLink,
                    Value = item.Guid.Value
                },
                MrssContents = item.MrssContents.Select(content => new SoapMrssContent
                {
                    Url = content.Url,
                    Width = content.Width
                }).ToArray(),
                InlineContent = new SoapMrssContent
                {
                    Url = item.InlineContent.Url,
                    Width = item.InlineContent.Width
                }
            }).ToArray();
        }
        public static RssFeedOutputDto MapRssInputXmlToRssOutputJson(this RssFeedInputDto input)
        {
            return new RssFeedOutputDto
            {
                Version = input.Version,
                Description = input.Channel.Description,
                Language = input.Channel.Language,
                Link = input.Channel.Link,
                Title = input.Channel.Title,
                Items = input.Channel.Items.Select(item => new Models.DTOs.Output.Item
                {
                    Description = item.Description,
                    PubDate = item.PubDate,
                    Title = item.Title,
                    Link = item.Link,
                    InlineCredit = item.InlineCredit,
                    MrssCredit = item.MrssCredit,
                    Group = new Models.DTOs.Output.MrssGroup
                    {
                        Credit = item.Group.Credit,
                        Contents = item.Group.Contents.Select(content => new Models.DTOs.Output.MrssContent
                        {
                            Url = content.Url,
                            Width = content.Width
                        })
                    },
                    Guid = new Models.DTOs.Output.GuidElement
                    {
                        IsPermaLink = item.Guid.IsPermaLink,
                        Value = item.Guid.Value
                    },
                    MrssContents = item.MrssContents.Select(content => new Models.DTOs.Output.MrssContent
                    {
                        Url = content.Url,
                        Width = content.Width
                    }),
                    InlineContent = new Models.DTOs.Output.MrssContent
                    {
                        Url = item.InlineContent.Url,
                        Width = item.InlineContent.Width
                    }
                })

            };
        }
    }
}
