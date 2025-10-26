# Randomly - Random Data Generator

A Blazor WebAssembly application that generates random test data according to user-defined fields, with support for Liquid templates to customize the output.

## Features

### 1. Field Definition Management
- Add/remove/modify fields with custom names
- Support for multiple data types:
  - **Personal**: First Name, Last Name, Full Name
  - **Contact**: Email, Phone Number
  - **Location**: City, Country, Address, Zip Code, State
  - **Numbers**: Integer, Decimal
  - **Other**: Boolean, Date, DateTime, UUID, Company, Job Title, Username, URL, Lorem text, Paragraph

### 2. Data Generation
- Configure the number of rows to generate (up to 10,000)
- Instant generation with preview table
- Uses Bogus library for realistic fake data

### 3. Liquid Template Editor
- Integrated Monaco Editor with syntax highlighting
- Customize output format using Liquid template syntax
- Auto-save templates to local storage
- Real-time preview of rendered output
- Support for loops and iterations

### 4. Export Options
- **Copy to Clipboard**: Quick copy of rendered output
- **Export as Text**: Plain text file
- **Export as CSV**: Comma-separated values
- **Export as JSON**: Structured JSON format

## Technology Stack

- **Blazor WebAssembly** (.NET 9.0) - Client-side web framework
- **Bogus** (v35.6.5) - Fake data generation
- **Fluid.Core** (v2.30.0) - Liquid template engine
- **BlazorMonaco** (v3.4.0) - Monaco code editor integration
- **Bootstrap 5** - UI framework

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/Netonia/Randomly.git
cd Randomly
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the application:
```bash
dotnet run
```

4. Open your browser and navigate to `http://localhost:5000`

### Building for Production

```bash
dotnet publish -c Release
```

The published files will be in `bin/Release/net9.0/publish/wwwroot/`

## Usage

1. **Define Fields**: Click "Add Field" to create new fields. Enter a field name and select a data type.

2. **Set Row Count**: Specify how many rows of data you want to generate (1-10,000).

3. **Generate Data**: Click "Generate Data" to create random data based on your field definitions.

4. **Customize Output**: Use the Liquid Template Editor to format your output. The default template shows all fields:

```liquid
{% for item in items %}
{% for property in item %}
{{ property.Key }}: {{ property.Value }}
{% endfor %}
---
{% endfor %}
```

5. **Preview**: Click "Update Preview" to see the rendered output.

6. **Export**: Use the export buttons to save your data in different formats.

## Example Liquid Templates

### Simple List Format
```liquid
{% for item in items %}
{{ item.firstName }} {{ item.lastName }} - {{ item.email }}
{% endfor %}
```

### CSV-like Format
```liquid
{% for item in items %}
"{{ item.field1 }}","{{ item.field2 }}","{{ item.field3 }}"
{% endfor %}
```

### Custom Formatting
```liquid
{% for item in items %}
Name: {{ item.firstName }} {{ item.lastName }}
Contact: {{ item.email }} | {{ item.phoneNumber }}
Location: {{ item.city }}, {{ item.country }}
---
{% endfor %}
```

## Architecture

- **Models/FieldDefinition.cs**: Defines the structure of a field
- **Services/RandomDataService.cs**: Handles data generation using Bogus
- **Services/TemplateService.cs**: Manages Liquid template rendering
- **Pages/Home.razor**: Main UI component

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available under the MIT License.

## Acknowledgments

- [Bogus](https://github.com/bchavez/Bogus) - For fake data generation
- [Fluid](https://github.com/sebastienros/fluid) - For Liquid template support
- [BlazorMonaco](https://github.com/serdarciplak/BlazorMonaco) - For Monaco Editor integration
