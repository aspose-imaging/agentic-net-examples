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
            // Hardcoded paths
            // Name of the embedded OTG resource (adjust namespace and file name as needed)
            const string resourceName = "MyNamespace.Resources.Sample.otg";
            // Output PNG file path
            const string outputPath = @"C:\Output\sample.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG file from the embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                    return;
                }

                // Load the image from the stream
                using (Image image = Image.Load(resourceStream))
                {
                    // Set up PNG save options with OTG rasterization
                    var pngOptions = new PngOptions();
                    var otgRasterization = new OtgRasterizationOptions
                    {
                        PageSize = image.Size // Preserve original size
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