using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToPngExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded resource name and output file path
                string inputResourceName = "OtgToPngExample.Resources.sample.otg";
                string outputPath = @"C:\Temp\output.png";

                // Load OTG image from embedded resource
                Assembly assembly = typeof(Program).Assembly;
                using (Stream resourceStream = assembly.GetManifestResourceStream(inputResourceName))
                {
                    if (resourceStream == null)
                    {
                        Console.Error.WriteLine($"Embedded resource not found: {inputResourceName}");
                        return;
                    }

                    using (Image image = Image.Load(resourceStream))
                    {
                        // Configure PNG save options with OTG rasterization
                        var pngOptions = new PngOptions();
                        var otgRasterization = new OtgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        pngOptions.VectorRasterizationOptions = otgRasterization;

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
}