using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Create a thumbnail raster image (100x100) in memory
            JpegOptions thumbOptions = new JpegOptions
            {
                // Use a memory stream as source to avoid creating a temporary file
                Source = new StreamSource(new MemoryStream(), false)
            };

            using (RasterImage thumbnail = (RasterImage)Image.Create(thumbOptions, 100, 100))
            {
                // Fill the thumbnail with a solid red color
                Graphics graphics = new Graphics(thumbnail);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, thumbnail.Bounds);

                // Assign the thumbnail to the EXIF data
                jpegImage.ExifData.Thumbnail = thumbnail;
            }

            // Save the modified JPEG image
            jpegImage.Save(outputPath);
        }
    }
}