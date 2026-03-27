using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Create a thumbnail raster image (100x100) in memory
            PngOptions thumbOptions = new PngOptions();
            using (RasterImage thumbImage = (RasterImage)Image.Create(thumbOptions, 100, 100))
            {
                // Fill the thumbnail with a solid red color
                Graphics graphics = new Graphics(thumbImage);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, thumbImage.Bounds);

                // Prepare JFIF data and assign the thumbnail
                JFIFData jfif = new JFIFData();
                jfif.Thumbnail = thumbImage;
                jpegImage.Jfif = jfif;

                // Save the JPEG image with the new JFIF thumbnail
                jpegImage.Save(outputPath);
            }
        }
    }
}