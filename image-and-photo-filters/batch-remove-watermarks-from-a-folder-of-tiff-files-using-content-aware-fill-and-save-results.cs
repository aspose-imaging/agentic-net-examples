using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input TIFF file paths
        string[] inputFiles = new string[]
        {
            "input1.tif",
            "input2.tif",
            "input3.tif"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Construct output path (saved in an "output" subfolder)
            string outputPath = Path.Combine("output", Path.GetFileNameWithoutExtension(inputPath) + "_clean.tif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for watermark removal
                RasterImage raster = (RasterImage)image;

                // Create a mask covering the whole image
                GraphicsPath mask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, raster.Width, raster.Height)));
                mask.AddFigure(figure);

                // Configure Content Aware Fill options
                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                // Remove watermark
                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    // Save the cleaned image as TIFF
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    result.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}