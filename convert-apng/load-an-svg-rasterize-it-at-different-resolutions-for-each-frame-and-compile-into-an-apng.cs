using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string svgPath = "input.svg";
            string outputApngPath = "output.apng";

            // Validate input file existence
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputApngPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the SVG image
            using (Image svgImage = Image.Load(svgPath))
            {
                // Define desired widths for each frame (heights will keep aspect ratio)
                int[] frameWidths = new int[] { 100, 200, 300 };

                // Prepare list to hold rasterized frames
                List<RasterImage> rasterFrames = new List<RasterImage>();

                // Rasterize each resolution and store the RasterImage
                foreach (int targetWidth in frameWidths)
                {
                    // Calculate height to preserve aspect ratio
                    int targetHeight = (int)((double)svgImage.Height / svgImage.Width * targetWidth);

                    // Set up PNG save options with vector rasterization settings
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = targetWidth,
                            PageHeight = targetHeight
                        }
                    };

                    // Rasterize to a memory stream
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized image
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        rasterFrames.Add(raster);
                    }
                }

                // Use the first frame dimensions for the APNG canvas
                RasterImage firstFrame = rasterFrames[0];
                int canvasWidth = firstFrame.Width;
                int canvasHeight = firstFrame.Height;

                // Set up APNG creation options
                ApngOptions apngCreateOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputApngPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100 // default frame duration in ms
                };

                // Create the APNG image bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, canvasWidth, canvasHeight))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add each raster frame to the APNG
                    foreach (RasterImage frame in rasterFrames)
                    {
                        // Ensure the frame matches canvas size (optional scaling could be added here)
                        apngImage.AddFrame(frame);
                    }

                    // Save the APNG (output path already bound via FileCreateSource)
                    apngImage.Save();
                }

                // Dispose raster frames
                foreach (RasterImage frame in rasterFrames)
                {
                    frame.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}