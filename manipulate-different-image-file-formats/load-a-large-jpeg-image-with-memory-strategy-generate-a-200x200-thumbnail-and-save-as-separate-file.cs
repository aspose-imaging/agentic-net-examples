using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output/thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG with memory limit (buffer size hint in MB)
            using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
            {
                // Resize to 200x200 thumbnail
                image.Resize(200, 200);

                // Save thumbnail as JPEG with desired quality
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}