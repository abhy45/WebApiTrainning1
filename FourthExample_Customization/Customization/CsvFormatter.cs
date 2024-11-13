using FourthExample_Customization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthExample_Customization.Customization
{
    public class CsvFormatter : TextOutputFormatter
    {
        public CsvFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type) => typeof(Blog).IsAssignableFrom(type) || typeof(IEnumerable<Blog>).IsAssignableFrom(type);

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<Blog>)
            {
                foreach (var blog in context.Object as IEnumerable<Blog>)
                {
                    writeCSV(buffer, blog);
                }
            }
            else
            {
                writeCSV(buffer, context.Object as Blog);
            }
            await response.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        private static void writeCSV(StringBuilder buffer, Blog blog)
        {
            foreach (var blogPost in blog.BlogPosts)
            {
                buffer.AppendLine($"{blog.Name}, {blog.Description}, {blogPost.Title}, {blogPost.Published}, {blogPost.MetaDescription}");
            }
        }
    }
}
