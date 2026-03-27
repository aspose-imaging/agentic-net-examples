using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF vector image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for high‑resolution rendering
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,                     // Use original size as page size
                BackgroundColor = Aspose.Imaging.Color.White // Optional background color
            };

            // Set BMP save options with 300 DPI resolution
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300) // 300 DPI horizontal and vertical
            };

            // Save the rasterized image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}