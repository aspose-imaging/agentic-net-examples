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
        string inputPath = "input.cdr";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary raster PNG path
        string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load vector image, remove background, and rasterize to PNG
        using (Image image = Image.Load(inputPath))
        {
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };

            image.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG and create APNG with a single frame
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 500 // 500 ms per frame
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
            {
                apng.RemoveAllFrames();
                apng.AddFrame(raster);
                apng.Save();
            }
        }

        // Clean up temporary file
        try
        {
            File.Delete(tempPngPath);
        }
        catch
        {
            // Ignored
        }
    }
}