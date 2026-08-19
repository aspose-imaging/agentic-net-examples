// HOW-TO: Create Animated APNG from SVG with Custom Frame Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG and output APNG paths
            string inputSvgPath = "input.svg";
            string outputApngPath = "output.apng";

            // Verify input file exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

            // Define frame size and background color
            const int frameWidth = 200;
            const int frameHeight = 200;
            var backgroundColor = Color.AliceBlue;

            // Load the SVG as a raster image (will be rasterized on load)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputSvgPath))
            {
                // Configure APNG creation options
                var createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputApngPath, false),
                    DefaultFrameTime = 100, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = frameWidth,
                        PageHeight = frameHeight,
                        BackgroundColor = backgroundColor
                    }
                };

                // Create the APNG image with the specified dimensions
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, frameWidth, frameHeight))
                {
                    // Set the overall background color for the animation
                    apngImage.BackgroundColor = backgroundColor;

                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Add multiple frames (here we simply duplicate the SVG raster)
                    const int totalFrames = 10;
                    for (int i = 0; i < totalFrames; i++)
                    {
                        apngImage.AddFrame(sourceImage);

                        // Example per-frame modification: adjust gamma to create a simple effect
                        ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                        float gamma = (i % 2 == 0) ? 0.8f : 1.2f;
                        lastFrame.AdjustGamma(gamma);
                    }

                    // Save the animated PNG
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate a lightweight animated PNG for web banners from scalable SVG icons while controlling the pixel dimensions.
 * 2. When you want to programmatically create an APNG slideshow where each frame is a rasterized vector graphic with a consistent background color.
 * 3. When you are building a C# desktop application that converts user‑uploaded SVG files into animated PNGs for email newsletters.
 * 4. When you need to automate the production of animated product previews, ensuring each frame matches a specific width and height.
 * 5. When you require server‑side image processing that turns vector logos into APNGs with a uniform background for consistent branding.
 */
