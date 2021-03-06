﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace MinifyNETCore.TagHelpers
{
    /// <summary>
    ///     The minified-partial tag helper that loads
    ///     minified partials depending on the value
    ///     of ASPNETCORE_ENVIRONMENT
    /// </summary>
    public class MPartialTagHelper : PartialTagHelper
    {
        public MPartialTagHelper(ICompositeViewEngine viewEngine, IViewBufferScope viewBufferScope)
            : base(viewEngine, viewBufferScope)
        {

        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Tack on a .min exension to load the minified partial view
            if (!IsDevelopment())
            {
                Name += ".min";
            }

            return base.ProcessAsync(context, output);
        }

        private bool IsDevelopment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development;
        }
    }
}