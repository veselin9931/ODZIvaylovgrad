﻿namespace ODZ.Web.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Web.Http.ModelBinding;

    public static class ModelStateDictionaryExtensions
    {
        public static string GetFirstError(this ModelStateDictionary modelState)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            return modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).FirstOrDefault();
        }
    }
}
