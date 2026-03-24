using System;
using System.IO;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\result.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image to obtain its dimensions
        using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;

            // Create a WMF recorder graphics canvas with the same size
            Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, width, height);
            int dpi = 96; // default screen resolution
            var graphics = new WmfRecorderGraphics2D(frame, dpi);

            // Draw the raster image onto the WMF canvas at the origin
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

            // Finalize recording and obtain the WMF image
            using (WmfImage wmf = graphics.EndRecording())
            {
                // Save the WMF image to the specified output path
                wmf.Save(outputPath);
            }
        }
    }
}