using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\source.png";
        string outputPath = @"C:\Temp\output\animated.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image from file into a memory stream
        using (MemoryStream sourceStream = new MemoryStream())
        {
            // Load image from file (lifecycle rule)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Save the loaded image into the memory stream as PNG
                sourceImage.Save(sourceStream, new PngOptions());
            }

            // Reset stream position for reading
            sourceStream.Position = 0;

            // Load raster image from the memory stream (lifecycle rule)
            using (RasterImage rasterFromStream = (RasterImage)Image.Load(sourceStream))
            {
                // Prepare APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    // Default frame duration (e.g., 80 ms)
                    DefaultFrameTime = 80,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create an empty APNG image with the same dimensions as the source
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    rasterFromStream.Width,
                    rasterFromStream.Height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Number of frames for the animation
                    int totalFrames = 10;

                    // Add frames and apply a simple gamma adjustment to each
                    for (int i = 0; i < totalFrames; i++)
                    {
                        // Add a copy of the source raster as a new frame
                        apngImage.AddFrame(rasterFromStream);

                        // Retrieve the frame just added
                        ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                        // Adjust gamma progressively (example manipulation)
                        float gamma = 0.5f + (i * 0.1f);
                        frame.AdjustGamma(gamma);
                    }

                    // Save the animated PNG to the specified output path (lifecycle rule)
                    apngImage.Save(outputPath, new ApngOptions());
                }
            }
        }
    }
}