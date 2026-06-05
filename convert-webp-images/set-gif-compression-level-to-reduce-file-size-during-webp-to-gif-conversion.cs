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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                // Configure GIF compression options
                GifOptions gifOptions = new GifOptions
                {
                    // Use lossy compression with a moderate MaxDiff value to reduce size
                    MaxDiff = 80
                };

                // Save the image as GIF with the specified options
                webpImage.Save(outputPath, gifOptions);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}