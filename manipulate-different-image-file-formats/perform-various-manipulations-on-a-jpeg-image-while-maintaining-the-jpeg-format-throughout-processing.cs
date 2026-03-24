using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\sample_processed.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to JpegImage to access JPEG‑specific features
            JpegImage jpegImage = image as JpegImage;
            if (jpegImage != null)
            {
                // Rotate the image 90 degrees clockwise
                jpegImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Add a comment to the JPEG metadata
                jpegImage.Comment = "Processed with Aspose.Imaging";

                // Prepare JPEG save options (quality 80, progressive compression)
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 80,
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive
                };

                // Save the processed image while preserving JPEG format
                jpegImage.Save(outputPath, saveOptions);
            }
            else
            {
                // Fallback: save any non‑JPEG image as JPEG with default options
                JpegOptions fallbackOptions = new JpegOptions();
                image.Save(outputPath, fallbackOptions);
            }
        }
    }
}