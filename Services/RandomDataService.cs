using Bogus;
using Randomly.Models;
using System.Dynamic;

namespace Randomly.Services;

public class RandomDataService
{
    public List<ExpandoObject> GenerateData(List<FieldDefinition> fields, int numberOfRows)
    {
        var result = new List<ExpandoObject>();
        var faker = new Faker();

        for (int i = 0; i < numberOfRows; i++)
        {
            dynamic row = new ExpandoObject();
            var rowDict = (IDictionary<string, object?>)row;

            foreach (var field in fields)
            {
                rowDict[field.Name] = GenerateValueForType(faker, field.Type);
            }

            result.Add(row);
        }

        return result;
    }

    private object? GenerateValueForType(Faker faker, string type)
    {
        return type.ToLowerInvariant() switch
        {
            "firstname" => faker.Name.FirstName(),
            "lastname" => faker.Name.LastName(),
            "fullname" => faker.Name.FullName(),
            "email" => faker.Internet.Email(),
            "phonenumber" => faker.Phone.PhoneNumber(),
            "city" => faker.Address.City(),
            "country" => faker.Address.Country(),
            "address" => faker.Address.FullAddress(),
            "zipcode" => faker.Address.ZipCode(),
            "state" => faker.Address.State(),
            "integer" => faker.Random.Int(1, 1000),
            "decimal" => faker.Random.Decimal(1, 1000),
            "boolean" => faker.Random.Bool(),
            "date" => faker.Date.Past(10),
            "datetime" => faker.Date.Recent(30),
            "uuid" => Guid.NewGuid(),
            "company" => faker.Company.CompanyName(),
            "jobtitle" => faker.Name.JobTitle(),
            "username" => faker.Internet.UserName(),
            "url" => faker.Internet.Url(),
            "lorem" => faker.Lorem.Sentence(),
            "paragraph" => faker.Lorem.Paragraph(),
            _ => faker.Lorem.Word()
        };
    }

    public string ExportToCsv(List<ExpandoObject> data)
    {
        if (data.Count == 0) return string.Empty;

        var firstRow = data[0] as IDictionary<string, object?>;
        if (firstRow == null) return string.Empty;

        var headers = string.Join(",", firstRow.Keys.Select(EscapeCsvValue));
        var rows = data.Select(row =>
        {
            var dict = (IDictionary<string, object?>)row;
            return string.Join(",", dict.Values.Select(v => EscapeCsvValue(v?.ToString() ?? "")));
        });

        return headers + "\n" + string.Join("\n", rows);
    }

    public string ExportToJson(List<ExpandoObject> data)
    {
        return System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        });
    }

    private string EscapeCsvValue(string value)
    {
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
        return value;
    }
}
