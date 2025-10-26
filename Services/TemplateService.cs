using Fluid;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

namespace Randomly.Services;

public class TemplateService
{
    private readonly FluidParser _parser;

    public TemplateService()
    {
        _parser = new FluidParser();
    }

    public string RenderTemplate(string template, List<ExpandoObject> data)
    {
        try
        {
            if (!_parser.TryParse(template, out var fluidTemplate, out var error))
            {
                return $"Template parsing error: {error}";
            }

            // Convert ExpandoObject to Dictionary for proper Fluid rendering
            var convertedData = data.Select(item =>
            {
                var dict = (IDictionary<string, object?>)item;
                return dict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }).ToList();

            var context = new TemplateContext(new { items = convertedData });
            context.Options.MemberAccessStrategy.Register<Dictionary<string, object?>>();

            var result = fluidTemplate.Render(context);
            return result;
        }
        catch (Exception ex)
        {
            return $"Template rendering error: {ex.Message}";
        }
    }
}
