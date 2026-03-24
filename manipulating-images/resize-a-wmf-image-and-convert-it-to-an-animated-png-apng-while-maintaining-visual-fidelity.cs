using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input, temporary raster, and output paths
        string inputPath = "input.wmf";
        string tempPngPath = "temp_resized.png";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

        // Load WMF, resize, and rasterize to a temporary PNG
        using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
        {
            // Example: double the size using nearest neighbour resampling
            wmf.Resize(wmf.Width * 2, wmf.Height * 2, ResizeType.NearestNeighbourResample);

            // Rasterize WMF to PNG
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = wmf.Size,
                    BackgroundColor = Color.White
                }
            };
            wmf.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as source for APNG creation
        using (RasterImage source = (RasterImage)Image.Load(tempPngPath))
        {
            // Set up APNG creation options
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image bound to the output file
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, source.Width, source.Height))
            {
                // Prepare simple animation by adding the same frame multiple times
                apng.RemoveAllFrames();
                int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apng.AddFrame(source);
                }

                // Save the APNG (output path already bound via FileCreateSource)
                apng.Save();
            }
        }

        // Optionally delete the temporary PNG
        try
        {
            File.Delete(tempPngPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}