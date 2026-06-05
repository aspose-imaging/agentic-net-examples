using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.otg";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
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
                // Configure OTG rasterization options (preserve original size)
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure JPEG save options with 300 DPI
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = otgOptions,
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                    ResolutionUnit = ResolutionUnit.Inch,
                    Quality = 100 // optional: maximum quality
                };

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}