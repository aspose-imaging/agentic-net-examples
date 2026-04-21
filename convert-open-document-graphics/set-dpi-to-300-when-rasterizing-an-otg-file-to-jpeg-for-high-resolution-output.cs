using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for OTG vector image
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = image.Size
            };

            // Configure JPEG save options with 300 DPI resolution
            JpegOptions jpegOptions = new JpegOptions
            {
                // Set high resolution (300 DPI)
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                ResolutionUnit = ResolutionUnit.Inch,
                // Attach vector rasterization options so OTG is rasterized correctly
                VectorRasterizationOptions = otgRasterizationOptions,
                // Optional: set quality to maximum
                Quality = 100
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}