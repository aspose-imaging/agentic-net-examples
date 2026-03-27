using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = "ConvertedImage.png";

        // Embedded resource name (adjust namespace and file name as needed)
        const string resourceName = "MyApp.Resources.Sample.otg";

        // Load OTG image from embedded resource
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resourceStream == null)
            {
                Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                return;
            }

            // Load the OTG image from the stream
            using (Image otgImage = Image.Load(resourceStream))
            {
                // Configure PNG save options with OTG rasterization
                var pngOptions = new PngOptions();
                var otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // Preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as PNG
                otgImage.Save(outputPath, pngOptions);
            }
        }
    }
}