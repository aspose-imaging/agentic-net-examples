using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.otg";
        string outputPath = @"C:\temp\output.jpg";

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
            // Prepare JPEG save options with quality set to 85%
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 85
            };

            // Configure rasterization options for vector to raster conversion
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = image.Size
            };

            // Assign rasterization options to the JPEG options
            jpegOptions.VectorRasterizationOptions = otgRasterization;

            // Save the image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}