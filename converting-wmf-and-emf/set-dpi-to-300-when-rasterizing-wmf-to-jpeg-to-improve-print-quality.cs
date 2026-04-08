using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for WMF
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
                // If the Inch property is available, set it to 300 DPI
                // Inch = 300
            };

            // Configure JPEG save options with 300 DPI resolution
            var jpegOptions = new JpegOptions
            {
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}