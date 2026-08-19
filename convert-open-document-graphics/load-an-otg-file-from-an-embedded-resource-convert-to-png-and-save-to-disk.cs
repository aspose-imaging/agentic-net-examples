// HOW-TO: Convert Embedded OTG Resource to PNG File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output/sample.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG image from embedded resource
            // Replace the resource name with the actual fully qualified name of your OTG file
            const string resourceName = "MyNamespace.Resources.Sample.otg";
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                    return;
                }

                using (Image image = Image.Load(resourceStream))
                {
                    // Set up PNG save options with OTG rasterization
                    var pngOptions = new PngOptions();
                    var otgRasterization = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    pngOptions.VectorRasterizationOptions = otgRasterization;

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to display a vector OTG diagram stored in your assembly as a PNG on a web page.
 * 2. When you want to generate thumbnail images from OTG files packaged as embedded resources for a desktop application.
 * 3. When you must convert proprietary OTG graphics to a widely supported PNG format for email attachments.
 * 4. When you are building a reporting tool that embeds OTG charts in the executable and needs to export them as PNG for printing.
 * 5. When you require automated batch processing that reads OTG files from resources, rasterizes them, and saves PNGs to a file system.
 */
