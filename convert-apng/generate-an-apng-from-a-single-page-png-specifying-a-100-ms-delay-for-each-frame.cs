using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG as a raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100u, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image with the same dimensions as the source
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Define number of frames for the animation
                    const int frameCount = 5;

                    // Add the same source image repeatedly to create animation frames
                    for (int i = 0; i < frameCount; i++)
                    {
                        apngImage.AddFrame(sourceImage);
                    }

                    // Save the APNG (output is already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}