// HOW-TO: Load OTG Embedded Resource and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        const string inputPath = "input.otg";
        const string outputPath = "output.png";

        try
        {
            // Load OTG file from embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "YourNamespace.Resources.sample.otg"; // adjust to actual resource name

            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                    return;
                }

                // Write the resource to a temporary file to satisfy the existence check
                using (FileStream fileStream = File.Create(inputPath))
                {
                    resourceStream.CopyTo(fileStream);
                }
            }

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image (OTG) from the temporary file
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a vector OTG diagram stored inside your assembly as a PNG on a web page.
 * 2. When an application ships sample OTG files as embedded resources and must convert them to raster PNG for printing.
 * 3. When you want to automate batch conversion of OTG assets packaged in a DLL to PNG files for use in mobile apps.
 * 4. When a CI/CD pipeline must verify that embedded OTG graphics can be rendered and saved as PNG without manual extraction.
 * 5. When you are building a document generator that reads OTG icons from resources and embeds them as PNG thumbnails in PDFs.
 */
