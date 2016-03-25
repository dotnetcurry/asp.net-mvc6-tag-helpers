using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.TagHelpers;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace MVC_TagHelper.CustomTagHelper
{
    //1.
    [HtmlTargetElement("table",Attributes ="generate-rows,source-model")]
    public class TableTagHelper : TagHelper
    {
        //2.
        [HtmlAttributeName("generate-rows")]
        public int RepeatCount { get; set; }
        //3.
        [HtmlAttributeName("source-model")]
        public ModelExpression DataModel { get; set; }
        //4.
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //4a
            IEnumerable model = DataModel.Model as IEnumerable;
            //4b
            if (model == null)
            {
                return;
            }
            else
            {
             //4c
                StringBuilder sb = new StringBuilder();
                //4d
                foreach (var m in model)
                {
                    PropertyInfo[] properties = m.GetType().GetProperties();

                    //var contents = (await output.GetChildContentAsync(false)).GetContent();
                    
                    //4e
                    string html = "<tr>";
                    for (int i = 0; i < properties.Length; i++)
                    {
                        html += "<td>" + m.GetType().GetProperty(properties[i].Name).GetValue(m, null) + "</td>";
                    }
                    html += "</tr>";

                    sb.Append(html);
                } 

                //4f
                output.Content.SetHtmlContent(sb.ToString());
            }
        }
    }
}
