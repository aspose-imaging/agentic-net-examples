using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "Output\\cropped.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!raster.IsCached)
                    raster.CacheData();

                // Determine central 400x400 crop rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int x = (raster.Width - cropWidth) / 2;
                int y = (raster.Height - cropHeight) / 2;
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                Rectangle cropRect = new Rectangle(x, y, cropWidth, cropHeight);

                // Perform cropping
                raster.Crop(cropRect);

                // Create an SVG canvas matching the cropped size
                int dpi = 96;
                SvgGraphics2D svgGraphics = new SvgGraphics2D(raster.Width, raster.Height, dpi);

                // Draw the cropped raster onto the SVG canvas
                svgGraphics.DrawImage(raster, new Point(0, 0));

                // Finalize and save the SVG image
                using (SvgImage svgImage = svgGraphics.EndRecording())
                {
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}