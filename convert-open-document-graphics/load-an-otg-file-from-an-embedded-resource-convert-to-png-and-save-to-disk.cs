using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded literal)
        string outputPath = Path.Combine("Output", "sample.png");

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG file from an embedded resource
        // Adjust the resource name to match the actual embedded file
        string resourceName = "MyNamespace.Resources.sample.otg";
        using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            if (resourceStream == null)
            {
                Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                return;
            }

            // Load the image from the stream
            using (Image image = Image.Load(resourceStream))
            {
                // Prepare PNG save options
                using (PngOptions pngOptions = new PngOptions())
                {
                    // Configure vector rasterization for OTG conversion
                    OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size // Preserve original size
                    };
                    pngOptions.VectorRasterizationOptions = otgOptions;

                    // Save the converted PNG image
                    image.Save(outputPath, pngOptions);
                }
            }
        }
    }
}