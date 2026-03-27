using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.jpg");

        // Validate input file existence
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
            // Prepare JPEG save options with metadata preservation
            JpegOptions jpegOptions = new JpegOptions
            {
                KeepMetadata = true
            };

            // Configure OTG rasterization options
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };
            jpegOptions.VectorRasterizationOptions = otgRasterizationOptions;

            // Save as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}