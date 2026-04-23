using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = "Input/sample.otg";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ICC profile (example; not directly used for PNG)
        using (FileStream iccStream = File.OpenRead("Input/profile.icc"))
        {
            StreamSource iccSource = new StreamSource(iccStream);
            // ICC profile could be used with formats that support it (e.g., JPEG)
            // For PNG, Aspose.Imaging does not expose a direct ICC property.
        }

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
                // Additional rasterization settings can be configured here
            };

            // Set PNG save options with the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}