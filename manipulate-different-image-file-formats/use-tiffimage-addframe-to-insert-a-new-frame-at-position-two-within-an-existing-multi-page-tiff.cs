using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load existing multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Determine size for the new frame (use size of first frame)
                int width = tiffImage.Frames[0].Width;
                int height = tiffImage.Frames[0].Height;

                // Create options for the new frame
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a new blank frame
                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                // Fill the new frame with a solid color (light gray)
                Graphics graphics = new Graphics(newFrame);
                SolidBrush brush = new SolidBrush(Color.LightGray);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Insert the new frame at position two (index 1)
                tiffImage.InsertFrame(1, newFrame);

                // Save the modified TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}