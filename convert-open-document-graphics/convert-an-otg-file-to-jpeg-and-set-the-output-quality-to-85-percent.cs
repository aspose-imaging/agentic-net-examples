using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.otg";
        string outputPath = "output\\converted.jpg";

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
            // Prepare rasterization options for OTG vector content
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size
            };

            // Configure JPEG save options with quality 85%
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 85,
                // Attach the rasterization options so the vector OTG is rasterized to JPEG
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save the image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}