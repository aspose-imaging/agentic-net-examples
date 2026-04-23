using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output_apng.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (single frame PNG)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha, // supports alpha channel
                    DefaultFrameTime = 500 // 500 ms per frame (example)
                };

                // Create an empty APNG image with the same dimensions as the source
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                {
                    // Set background color to fully transparent
                    apngImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                    apngImage.HasBackgroundColor = true;

                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add the source image as the first (and only) frame
                    apngImage.AddFrame(sourceImage);

                    // Save the APNG file
                    apngImage.Save();
                }
            }

            // Optional verification: load the saved APNG and check background color
            using (ApngImage verifyImage = (ApngImage)Image.Load(outputPath))
            {
                bool isTransparent = verifyImage.HasBackgroundColor && verifyImage.BackgroundColor.A == 0;
                Console.WriteLine(isTransparent
                    ? "APNG background is transparent."
                    : "APNG background is not transparent.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}