using System;

namespace FearAndGreed.Models
{
    /// <summary>
    /// Model to describe the current Fear and Greed market sentiment in crypto
    /// </summary>
    public class FearAndGreedModel
    {
        public int IndexValue { get; set; }
        public string IndexClassification { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime NextUpdate { get; set; }
    }
}
