using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Input\sample.otg";
        string outputPath = @"C:\Output\sample.jpg";

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
            // Configure JPEG save options with 300 dpi resolution
            var jpegOptions = new JpegOptions
            {
                // Set horizontal and vertical DPI to 300
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Configure rasterization options for the vector OTG source
            var otgRasterOptions = new OtgRasterizationOptions
            {
                // Preserve the original page size
                PageSize = image.Size
            };

            // Attach the rasterization options to the JPEG options
            jpegOptions.VectorRasterizationOptions = otgRasterOptions;

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}