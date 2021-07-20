using FearAndGreed.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FearAndGreed.Models
{
    /// <summary>
    /// Model to describe the current Fear and Greed market sentiment in crypto
    /// </summary>
    public class FearAndGreedModel
    {
        [Key]
        public int Id { get; set; }
        public string IndexValue { get; set; }

        public string IndexClassification { get; set; }

        public DateTime IndexDate { get; set; }

        public DateTime IndexNextUpdate { get; set; }
    }
}