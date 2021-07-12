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
        public int Index { get; set; }

        private DateTime _indexDateTime;

        private DateTime _indexNextUpdate;

        public string IndexValue { get; set; }

        public string IndexClassification { get; set; }

        public virtual List<FearAndGreedModel> FearAndGreeds { get; set; }

        public string IndexDate 
        {
            get { return _indexDateTime.Day.ToString() + "/" + _indexDateTime.Month.ToString() + "/" + _indexDateTime.Year.ToString(); }
            set { _indexDateTime = TimeStampConverter.UnixTimestampToDateTime(double.Parse(value)); }
        }

        public string IndexNextUpdate
        {
            get { return _indexNextUpdate.Hour.ToString(); }
            set { _indexNextUpdate = TimeStampConverter.UnixTimestampToDateTime(double.Parse(value)); }
        }
    }
}