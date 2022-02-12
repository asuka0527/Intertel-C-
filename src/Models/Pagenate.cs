using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using X.PagedList;

namespace Intertel.Models
{
    public class Pagenate<T>
    {
        public IPagedList<T> Data { get; set; }
        public PagedListMetaData MetaData { get; set; }
    }
}