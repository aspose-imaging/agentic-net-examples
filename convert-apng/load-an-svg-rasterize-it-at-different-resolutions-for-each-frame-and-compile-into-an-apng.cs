// HOW-TO: Create Animated PNG from SVG at Multiple Resolutions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG and output APNG paths
            string inputSvgPath = "input.svg";
            string outputApngPath = "output.apng";

            // Validate input file existence
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputApngPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                int originalWidth = svgImage.Width;
                int originalHeight = svgImage.Height;

                // Define target widths for each frame (heights will be scaled proportionally)
                int[] targetWidths = new int[] { 200, 400, 600 };

                // Prepare APNG creation options (output bound to FileCreateSource)
                ApngOptions apngCreateOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputApngPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 200 // milliseconds per frame
                };

                // Create the APNG image using the dimensions of the first frame
                int firstWidth = targetWidths[0];
                int firstHeight = originalHeight * firstWidth / originalWidth;
                using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, firstWidth, firstHeight))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Generate and add each rasterized frame
                    foreach (int targetWidth in targetWidths)
                    {
                        int targetHeight = originalHeight * targetWidth / originalWidth;

                        // Set up rasterization options for the current resolution
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = targetWidth,
                            PageHeight = targetHeight,
                            BackgroundColor = Color.White
                        };

                        // Configure PNG save options with the rasterization settings
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Rasterize SVG to a PNG stored in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0;

                            // Load the rasterized PNG as a RasterImage
                            using (RasterImage rasterFrame = (RasterImage)Image.Load(ms))
                            {
                                // Add the raster frame to the APNG
                                apngImage.AddFrame(rasterFrame);
                            }
                        }
                    }

                    // Save the APNG (output is already bound to the source)
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
 * 1. When you need to generate a responsive animated PNG that shows the same vector graphic at several sizes for use in web banners or UI components.
 * 2. When you want to convert a single SVG logo into an APNG sequence where each frame is a higher‑resolution raster for progressive zoom effects.
 * 3. When an application must produce lightweight animated assets for mobile apps by rasterizing SVG frames at custom widths before packaging them into an APNG.
 * 4. When you are building a server‑side service that creates animated PNG previews of SVG diagrams at different scales for email thumbnails.
 * 5. When you need to automate the creation of multi‑size animation frames from a vector source to ensure consistent color depth and timing in an APNG file.
 */
