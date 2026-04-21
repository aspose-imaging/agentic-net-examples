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
            // Hardcoded input and output paths
            string[] inputPaths = {
                @"c:\temp\image1.webp",
                @"c:\temp\image2.webp"
            };

            string[] outputPaths = {
                @"c:\temp\image1.png",
                @"c:\temp\image2.png"
            };

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

                // Set memory usage limit via BufferSizeHint (in megabytes)
                var loadOptions = new LoadOptions { BufferSizeHint = 50 };

                // Load WebP image with memory limit
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save as PNG
                    image.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}