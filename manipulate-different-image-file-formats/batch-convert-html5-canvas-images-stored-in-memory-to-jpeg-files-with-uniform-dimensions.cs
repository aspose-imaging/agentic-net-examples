using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string[] inputPaths = {
            @"C:\Images\Input1.svg",
            @"C:\Images\Input2.svg"
        };

        string[] outputPaths = {
            @"C:\Images\Output1.jpg",
            @"C:\Images\Output2.jpg"
        };

        // Desired uniform dimensions
        const int targetWidth = 800;
        const int targetHeight = 600;

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (e.g., SVG, WMF, etc.) that will be rasterized to a JPEG
            using (Image image = Image.Load(inputPath))
            {
                // Resize to uniform dimensions if necessary
                if (image.Width != targetWidth || image.Height != targetHeight)
                {
                    // Resize works on RasterImage; cast if needed
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Resize(targetWidth, targetHeight);
                    }
                }

                // Configure JPEG save options
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // Adjust quality as required
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}