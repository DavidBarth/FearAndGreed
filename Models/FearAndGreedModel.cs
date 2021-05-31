using FearAndGreed.Util;
using System;

namespace FearAndGreed.Models
{
    /// <summary>
    /// Model to describe the current Fear and Greed market sentiment in crypto
    /// </summary>
    public class FearAndGreedModel
    {
        private DateTime indexDateTime;

        private DateTime indexNextUpdate;

        public string IndexValue { get; set; }

        public string IndexClassification { get; set; }

        public string IndexDateTime 
        {
            get { return indexDateTime.ToString(); }
            set { indexDateTime = TimeStampConverter.UnixTimestampToDateTime(double.Parse(value)); }
        }

        public string IndexNextUpdate
        {
            get { return indexNextUpdate.ToString(); }
            set { indexNextUpdate = TimeStampConverter.UnixTimestampToDateTime(double.Parse(value)); }

        }
    }
}