using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with anti‑aliasing for smoother rendering
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size,
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
            };

            // Set PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}