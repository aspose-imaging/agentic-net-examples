using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load EPS image
            using (var image = Image.Load(inputPath) as EpsImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load EPS image.");
                    return;
                }

                // Calculate new height to maintain aspect ratio
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize using Mitchell interpolation
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}