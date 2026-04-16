using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.wmf";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image and convert to progressive JPEG
        using (Image image = Image.Load(inputPath))
        {
            JpegOptions jpegOptions = new JpegOptions
            {
                // Enable progressive encoding
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                // Set desired quality (1-100)
                Quality = 90,
                // Rasterize vector WMF using appropriate options
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the image as JPEG with the specified options
            image.Save(outputPath, jpegOptions);
        }
    }
}