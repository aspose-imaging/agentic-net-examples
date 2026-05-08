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

            // Define frame sizes (different resolutions)
            int[] frameSizes = new int[] { 200, 400, 600 };
            int maxSize = 0;
            foreach (int s in frameSizes)
                if (s > maxSize) maxSize = s;

            // Load the SVG once
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                // Set up APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputApngPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 200 // milliseconds per frame
                };

                // Create APNG canvas with the largest size
                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, maxSize, maxSize))
                {
                    apng.RemoveAllFrames();

                    // Generate each frame at its specific resolution
                    foreach (int size in frameSizes)
                    {
                        // Rasterization options for current resolution
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = size,
                            PageHeight = size
                        };
                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Rasterize SVG to a memory stream and load as RasterImage
                        using (MemoryStream ms = new MemoryStream())
                        {
                            svgImage.Save(ms, pngOptions);
                            ms.Position = 0;
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                // Add the rasterized frame to the APNG
                                apng.AddFrame(raster);
                            }
                        }
                    }

                    // Save the compiled APNG
                    apng.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}