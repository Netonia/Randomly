using Fluid;
using System.Dynamic;

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

            var context = new TemplateContext(new { items = data });
            var result = fluidTemplate.Render(context);
            return result;
        }
        catch (Exception ex)
        {
            return $"Template rendering error: {ex.Message}";
        }
    }
}
