using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";
        string tempSvgPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp.svg");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));

        // Load the raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Create SVG graphics with same dimensions as raster
            var svgGraphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(raster.Width, raster.Height, 96);

            // Draw a vector rectangle (example vector graphic)
            svgGraphics.DrawRectangle(
                new Pen(Color.Red, 5),
                50, 50, raster.Width - 100, raster.Height - 100);

            // End recording and obtain the SVG image
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Save SVG to a temporary file
                svgImage.Save(tempSvgPath);
            }

            // Load the rendered SVG as a raster image
            using (RasterImage vectorRaster = (RasterImage)Image.Load(tempSvgPath))
            {
                // Blend the vector raster onto the original raster (full opacity)
                raster.Blend(new Point(0, 0), vectorRaster, 255);
            }

            // Prepare PNG options for saving
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };

            // Save the combined image
            raster.Save(outputPath, pngOptions);
        }

        // Clean up temporary SVG file
        if (File.Exists(tempSvgPath))
        {
            File.Delete(tempSvgPath);
        }
    }
}