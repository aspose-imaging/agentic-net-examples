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
        string inputPath = "largeImage.jpg";
        string outputPath = "thumbnail.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image with a memory buffer limit (e.g., 50 MB)
        using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
        {
            // Resize to 200x200 pixels using nearest‑neighbour resampling
            image.Resize(200, 200, ResizeType.NearestNeighbourResample);

            // Prepare JPEG save options (optional quality setting)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the thumbnail
            image.Save(outputPath, jpegOptions);
        }
    }
}