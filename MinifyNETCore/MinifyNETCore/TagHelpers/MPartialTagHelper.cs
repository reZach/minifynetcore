using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinifyNETCore.TagHelpers
{
    public class MPartialTagHelper : PartialTagHelper
    {
        public MPartialTagHelper(ICompositeViewEngine viewEngine, IViewBufferScope viewBufferScope)
            : base(viewEngine, viewBufferScope)
        {

        }

        public override void Init(TagHelperContext context)
        {
            var allAttributes = context.AllAttributes;
            var newAttributes = new List<TagHelperAttribute>();
            string name = string.Empty;
            object value;

            for (int i = 0; i < allAttributes.Count; i++)
            {
                name = allAttributes.ElementAt(i).Name;
                value = allAttributes.ElementAt(i).Value;

                if (name.Equals("name", StringComparison.OrdinalIgnoreCase)
                    && IsDevelopment())
                {
                    value += ".min";
                }

                newAttributes.Add(new TagHelperAttribute(name, value, allAttributes[i].ValueStyle));
            }

            TagHelperContext newContext = new TagHelperContext(context.TagName,
                new TagHelperAttributeList(newAttributes), context.Items, context.UniqueId);
            base.Init(newContext);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var a = context.AllAttributes;
            //if (!IsDevelopment())
            //{
            //    context.TagName += ".min";
            //}

            base.Process(context, output);
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //var existing = context.AllAttributes;

            //context.AllAttributes.Append(new TagHelperAttribute("a", "b"));
            //var updated = new Dictionary<object, object>();

            //string name = string.Empty;
            //object value;
            //for (int i = 0; i < existing.Count; i++)
            //{
            //    name = existing.ElementAt(i).Name;
            //    value = existing.ElementAt(i).Value;

            //    if (name.Equals("name", StringComparison.OrdinalIgnoreCase)
            //        && IsDevelopment())
            //    {
            //        value += ".min";
            //    }

            //    updated.Add(name, value);
            //}
            
            //context.Reinitialize(context.TagName, updated, context.UniqueId);
            return base.ProcessAsync(context, output);
        }

        private bool IsDevelopment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development;
        }
    }
}
