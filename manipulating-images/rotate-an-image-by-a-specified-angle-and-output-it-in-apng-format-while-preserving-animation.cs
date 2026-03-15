using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input animated image (any format supported by Aspose.Imaging)
        string inputPath = "input_animation.webp";
        // Output APNG file path
        string outputPath = "rotated_output.apng";
        // Rotation angle in degrees (positive = clockwise)
        float angle = 45f;

        // Load the source image
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Determine canvas size (use source dimensions)
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Prepare APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                // Preserve original frame timing if possible; otherwise default
                DefaultFrameTime = 100 // 100 ms per frame as a fallback
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
            {
                // Ensure no default frame remains
                apngImage.RemoveAllFrames();

                // Helper to process a single raster frame
                void ProcessAndAddFrame(RasterImage raster)
                {
                    // Cache data for better performance
                    if (!raster.IsCached) raster.CacheData();

                    // Rotate the frame; resize proportionally to fit rotated bounds
                    raster.Rotate(angle, true, Color.Transparent);

                    // Add the rotated frame to the APNG
                    apngImage.AddFrame(raster);
                }

                // If the source image is multipage (animated), iterate its pages
                if (sourceImage is IMultipageImage multipage)
                {
                    foreach (Image page in multipage.Pages)
                    {
                        using (RasterImage rasterPage = (RasterImage)page)
                        {
                            ProcessAndAddFrame(rasterPage);
                        }
                    }
                }
                else
                {
                    // Single-frame image
                    using (RasterImage raster = (RasterImage)sourceImage)
                    {
                        ProcessAndAddFrame(raster);
                    }
                }

                // Save the resulting APNG animation
                apngImage.Save();
            }
        }
    }
}