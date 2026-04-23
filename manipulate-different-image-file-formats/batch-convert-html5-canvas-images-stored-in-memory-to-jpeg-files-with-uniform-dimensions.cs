using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input HTML5 Canvas files
            string[] inputPaths = new string[]
            {
                @"C:\Images\canvas1.html",
                @"C:\Images\canvas2.html"
            };

            // Corresponding output JPEG files
            string[] outputPaths = new string[]
            {
                @"C:\Output\image1.jpg",
                @"C:\Output\image2.jpg"
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
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the HTML5 Canvas image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to uniform dimensions if necessary
                    if (image.Width != targetWidth || image.Height != targetHeight)
                    {
                        image.Resize(targetWidth, targetHeight);
                    }

                    // Set JPEG save options
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}