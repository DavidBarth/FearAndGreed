using FearAndGreed.Data;
using FearAndGreed.Models;
using FearAndGreed.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FearAndGreed.Service.FearAndGreed
{
    public class FearAndGreedService
    {
        public static FearAndGreedModel BuildViewModelInfo(JObject result)
        {
            var data = result.SelectToken("data").SelectToken(string.Empty).First;
            FearAndGreedModel model = new FearAndGreedModel();

            model.IndexValue = data.SelectToken("value").ToString();
            model.IndexClassification = data.SelectToken("value_classification").ToString();
            model.IndexDate = TimeStampConverter.UnixTimestampToDateTime(double.Parse(data.SelectToken("timestamp").ToString()));
            model.IndexNextUpdate = TimeStampConverter.UnixTimestampToDateTime(double.Parse(data.SelectToken("time_until_update").ToString()));
            return model;
        }

        internal static void SaveModel(FearAndGreedModel model, FearAndGreedContext context)
        {
            DbInitializer.Initialize(context);
            context.Add(model);
            context.SaveChanges();

        }

        internal static IQueryable<FearAndGreedModel> GetAllModels(FearAndGreedContext _context)
        {
            return _context.FearAndGreeds;
        }
    }
}
