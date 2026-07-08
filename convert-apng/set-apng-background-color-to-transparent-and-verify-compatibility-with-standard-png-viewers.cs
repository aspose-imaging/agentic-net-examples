using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates if null path, which results in no action)
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? string.Empty);

            // Load the source image (any raster image)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Set up APNG creation options with alpha support
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    // Optional: set a default frame time (e.g., 100 ms)
                    DefaultFrameTime = 100
                };

                // Create a new APNG image based on the source dimensions
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add the source image as the first (and only) frame
                    apngImage.AddFrame(sourceImage);

                    // Set background color to fully transparent
                    apngImage.BackgroundColor = Color.Transparent;
                    apngImage.HasBackgroundColor = true;

                    // Save the APNG file
                    apngImage.Save();

                    // Verify that the saved file reports a transparent background
                    using (ApngImage verifyImage = (ApngImage)Image.Load(outputPath))
                    {
                        bool isTransparent = verifyImage.HasBackgroundColor &&
                                             verifyImage.BackgroundColor.Equals(Color.Transparent);
                        Console.WriteLine(isTransparent
                            ? "APNG background is transparent."
                            : "APNG background is not transparent.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a static PNG into an animated PNG (APNG) with a fully transparent background so that the resulting file can be displayed correctly in browsers and standard image viewers.
 * 2. When building a C# web application that serves animated icons and wants to ensure the icons blend seamlessly over any page background by setting the APNG background color to transparent.
 * 3. When creating marketing assets for mobile apps where an APNG logo must overlay different UI themes without showing a solid background, requiring transparent background handling and verification with common PNG viewers.
 * 4. When generating dynamic report graphics in a .NET service that includes animated charts, and the developer must produce APNG files that remain compatible with legacy PNG viewers that do not support animation.
 * 5. When automating a batch process that converts a folder of PNG screenshots into APNG sequences with transparent backgrounds for use in documentation, ensuring the output can be opened by standard image editors and viewers.
 */