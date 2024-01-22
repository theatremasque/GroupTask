﻿namespace Tandem.Api.Core;

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public int? Rating { get; set; }
    public ICollection<Post> Posts { get; set; }
}