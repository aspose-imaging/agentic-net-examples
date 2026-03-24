using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Create WebP options instance
            var webpOptions = new WebPOptions();

            // Example: set lossless compression and quality
            webpOptions.Lossless = true;
            webpOptions.Quality = 80f;

            // Save the image as WebP using the configured options
            image.Save(outputPath, webpOptions);
        }

        // Enumerate available WebPOptions configuration properties
        Console.WriteLine("Available WebPOptions configuration properties:");
        PropertyInfo[] properties = typeof(WebPOptions).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in properties)
        {
            // Retrieve the property name and its type
            string name = prop.Name;
            string typeName = prop.PropertyType.Name;

            // Attempt to get the default value by creating a fresh instance
            object defaultValue = null;
            try
            {
                var defaultInstance = new WebPOptions();
                defaultValue = prop.GetValue(defaultInstance);
            }
            catch
            {
                // Ignore any property that cannot be read
            }

            Console.WriteLine($"- {name} ({typeName}) Default: {defaultValue ?? "N/A"}");
        }
    }
}