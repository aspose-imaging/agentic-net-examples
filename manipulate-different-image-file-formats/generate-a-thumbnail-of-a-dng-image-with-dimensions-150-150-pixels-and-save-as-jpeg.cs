using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output\\thumbnail.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image, resize, and save as JPEG
        using (Image image = Image.Load(inputPath))
        {
            DngImage dng = (DngImage)image;

            // Resize to 150x150 pixels using nearest neighbour resampling
            dng.Resize(150, 150, ResizeType.NearestNeighbourResample);

            // Configure JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the thumbnail as JPEG
            dng.Save(outputPath, jpegOptions);
        }
    }
}