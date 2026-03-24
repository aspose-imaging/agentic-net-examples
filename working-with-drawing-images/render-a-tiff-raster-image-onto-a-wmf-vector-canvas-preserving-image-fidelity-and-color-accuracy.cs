using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF raster image
        using (RasterImage tiffImage = (RasterImage)Image.Load(inputPath))
        {
            // Create a WMF recorder with the same dimensions as the TIFF image
            Rectangle frame = new Rectangle(0, 0, tiffImage.Width, tiffImage.Height);
            int dpi = 96; // default screen resolution

            WmfRecorderGraphics2D recorder = new WmfRecorderGraphics2D(frame, dpi);

            // Draw the raster image onto the WMF canvas
            recorder.DrawImage(
                tiffImage,
                new Rectangle(0, 0, tiffImage.Width, tiffImage.Height),
                new Rectangle(0, 0, tiffImage.Width, tiffImage.Height),
                GraphicsUnit.Pixel);

            // Finalize recording and obtain the WMF image
            using (WmfImage wmfImage = recorder.EndRecording())
            {
                // Save the WMF file
                wmfImage.Save(outputPath);
            }
        }
    }
}