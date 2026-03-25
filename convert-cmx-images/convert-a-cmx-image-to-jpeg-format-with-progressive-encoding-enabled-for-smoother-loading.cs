using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX vector image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Configure JPEG options with progressive compression
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.CompressionType = JpegCompressionMode.Progressive;
                jpegOptions.Quality = 90;

                // Set vector rasterization options based on the CMX image size
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height
                };
                jpegOptions.VectorRasterizationOptions = vectorOptions;

                // Save the rasterized image as JPEG
                cmxImage.Save(outputPath, jpegOptions);
            }
        }
    }
}