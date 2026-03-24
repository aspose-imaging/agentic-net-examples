using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Rotation angle (degrees)
        float angle = 45f;

        // Load the source image (may be multi‑page/animated)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Prepare APNG creation options with bound output file
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                // Optional: set default frame duration (ms)
                DefaultFrameTime = 100
            };

            // Create the APNG canvas using the source dimensions
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apng.RemoveAllFrames();

                // If the source image supports multiple pages, iterate them
                if (sourceImage is IMultipageImage multipage)
                {
                    foreach (Image page in multipage.Pages)
                    {
                        using (RasterImage rasterPage = (RasterImage)page)
                        {
                            // Rotate each frame; resize proportionally to fit rotated bounds
                            rasterPage.Rotate(angle, true, Color.Transparent);
                            apng.AddFrame(rasterPage);
                        }
                    }
                }
                else
                {
                    // Single‑frame image handling
                    using (RasterImage raster = (RasterImage)sourceImage)
                    {
                        raster.Rotate(angle, true, Color.Transparent);
                        apng.AddFrame(raster);
                    }
                }

                // Save the APNG (output file already bound via FileCreateSource)
                apng.Save();
            }
        }
    }
}