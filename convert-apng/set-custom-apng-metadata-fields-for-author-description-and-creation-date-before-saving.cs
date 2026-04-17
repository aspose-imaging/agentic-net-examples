using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG options with metadata
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 100, // default frame duration in ms
                ExifData = new ExifData
                {
                    Artist = "John Doe",
                    ImageDescription = "Sample APNG created with Aspose.Imaging",
                    DateTimeOriginal = DateTime.Now
                }
            };

            // Create APNG image canvas
            using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
            {
                // Remove default frame and add the source image as the first frame
                apng.RemoveAllFrames();
                apng.AddFrame(sourceImage);

                // Save the APNG file (metadata is embedded via options)
                apng.Save();
            }
        }
    }
}