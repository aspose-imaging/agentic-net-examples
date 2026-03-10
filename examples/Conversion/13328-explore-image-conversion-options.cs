using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageConversionDemo
{
    static void Main()
    {
        // Input image path – replace with your source file
        string inputPath = @"C:\Images\source.png";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the image using Aspose.Imaging's Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Define the target formats you want to convert to
            // The file extension determines the output format when using Save(string)
            string[] targetExtensions = new[]
            {
                ".jpg",   // JPEG
                ".jpeg",  // JPEG (alternative)
                ".png",   // PNG
                ".bmp",   // BMP
                ".tiff",  // TIFF
                ".gif",   // GIF
                ".webp",  // WebP
                ".ico",   // ICO
                ".apng",  // APNG
                ".djvu"   // DJVU
            };

            // Output directory – change as needed
            string outputDir = @"C:\Images\Converted";
            Directory.CreateDirectory(outputDir);

            // Iterate over each target format and save the image
            foreach (string ext in targetExtensions)
            {
                // Build the output file name (same base name, different extension)
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + ext);

                // Save the image using the Save(string) overload (lifecycle rule)
                // The format is inferred from the file extension
                image.Save(outputPath);

                Console.WriteLine($"Saved as: {outputPath}");
            }
        }

        Console.WriteLine("Conversion completed.");
    }
}