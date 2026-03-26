using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.jpg";

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
            // Set up rasterization options for the WMF source
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure JPEG options with progressive compression
            var jpegOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 100,
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save as progressive JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}