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
        // Hardcoded input and output paths
        string inputPath = @"Resources\sample.odg";
        string outputPath = @"Output\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG from embedded resource
        // The resource name must match the embedded file name (including namespace folders)
        string resourceName = "YourNamespace.Resources.sample.odg"; // adjust namespace as needed
        Assembly assembly = Assembly.GetExecutingAssembly();

        using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resourceStream == null)
            {
                Console.Error.WriteLine($"Embedded resource not found: {resourceName}");
                return;
            }

            // Load the image from the stream (Aspose.Imaging can detect format)
            using (Image image = Image.Load(resourceStream))
            {
                // Cast to OdgImage to ensure proper handling (optional)
                OdgImage odgImage = image as OdgImage;
                if (odgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an ODG image.");
                    return;
                }

                // Save as PNG using PngOptions
                var pngOptions = new PngOptions();
                odgImage.Save(outputPath, pngOptions);
            }
        }
    }
}