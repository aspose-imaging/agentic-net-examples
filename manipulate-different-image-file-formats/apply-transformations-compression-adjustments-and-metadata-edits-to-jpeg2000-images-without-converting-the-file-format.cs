using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jp2";
        string outputPath = @"C:\Images\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG2000 image
        using (Jpeg2000Image image = (Jpeg2000Image)Image.Load(inputPath))
        {
            // Example transformation: resize to half the original dimensions
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Example transformation: rotate 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Configure compression options
            Jpeg2000Options options = new Jpeg2000Options
            {
                Irreversible = true,                         // Use irreversible DWT (lossy)
                Codec = Jpeg2000Codec.J2K,                    // Choose raw J2K codec
                CompressionRatios = new int[] { 20 },        // Set compression ratio
                KeepMetadata = true                           // Preserve existing metadata
            };

            // Save the modified image back to JPEG2000 format
            image.Save(outputPath, options);
        }
    }
}