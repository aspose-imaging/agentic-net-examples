using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of JPEG files to process
            string[] files = new string[]
            {
                "photo1.jpg",
                "photo2.jpg",
                "photo3.jpg"
            };

            foreach (var fileName in files)
            {
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, fileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;

                    // Determine scaling factor to fit within 1200 pixels
                    double maxDimension = 1200.0;
                    double scale = Math.Min(1.0, maxDimension / Math.Max(originalWidth, originalHeight));

                    int newWidth = (int)Math.Round(originalWidth * scale);
                    int newHeight = (int)Math.Round(originalHeight * scale);

                    // Resize only if dimensions change
                    if (newWidth != originalWidth || newHeight != originalHeight)
                    {
                        image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                    }

                    // Save as JPEG using default options
                    image.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}