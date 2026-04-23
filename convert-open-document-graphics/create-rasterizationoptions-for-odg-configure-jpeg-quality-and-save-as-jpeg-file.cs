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
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size // preserve aspect ratio if needed
            };

            // Configure JPEG save options, including quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90, // value between 1 and 100
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}