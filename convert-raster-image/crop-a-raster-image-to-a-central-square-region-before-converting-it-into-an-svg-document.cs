using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Crop
                RasterImage raster = (RasterImage)image;

                // Determine the size of the central square
                int side = Math.Min(raster.Width, raster.Height);
                int left = (raster.Width - side) / 2;
                int top = (raster.Height - side) / 2;

                // Crop to the central square region
                var area = new Rectangle(left, top, side, side);
                raster.Crop(area);

                // Convert and save as SVG
                var svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}