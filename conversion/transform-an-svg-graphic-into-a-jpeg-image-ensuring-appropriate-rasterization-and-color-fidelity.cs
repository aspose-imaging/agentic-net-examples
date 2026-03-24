using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options
            var jpegOptions = new JpegOptions
            {
                Quality = 100 // Preserve maximum quality
            };

            // Configure rasterization options for vector to raster conversion
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,               // Preserve original dimensions
                BackgroundColor = Color.White,       // Set background to white
                SmoothingMode = SmoothingMode.AntiAlias
            };

            jpegOptions.VectorRasterizationOptions = rasterOptions;

            // Save as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}