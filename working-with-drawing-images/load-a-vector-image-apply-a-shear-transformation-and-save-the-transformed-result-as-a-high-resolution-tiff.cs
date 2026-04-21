using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load SVG and rasterize to high resolution PNG
        using (Image svgImg = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    ScaleX = 5f,
                    ScaleY = 5f,
                    BackgroundColor = Aspose.Imaging.Color.White
                }
            };
            ((SvgImage)svgImg).Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG
        using (RasterImage rasterImg = (RasterImage)Image.Load(tempPngPath))
        {
            // Prepare TIFF save options with high resolution
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Create a TIFF image bound to the output file
            using (RasterImage tiffImg = (RasterImage)Image.Create(tiffOptions, rasterImg.Width, rasterImg.Height))
            {
                // Apply shear transformation using a transformation matrix
                var shearMatrix = new Matrix(1f, 0f, 0.5f, 1f, 0f, 0f);
                Graphics graphics = new Graphics(tiffImg);
                graphics.Transform = shearMatrix;
                graphics.DrawImage(rasterImg, new Point(0, 0));

                // Save the TIFF image (output path already bound)
                tiffImg.Save();
            }
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}