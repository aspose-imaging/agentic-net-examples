// HOW-TO: Crop a CorelDRAW CDR to 200x200 and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_cropped.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW (CDR) image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access vector-specific functionality
                CdrImage cdrImage = (CdrImage)image;

                // Define a 200x200 rectangle starting at (0,0)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image
                cdrImage.Crop(cropArea);

                // Prepare GIF save options
                GifOptions gifOptions = new GifOptions();

                // Save the cropped image as GIF
                cdrImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a thumbnail GIF from a large CorelDRAW design for web previews.
 * 2. When an e‑commerce platform requires a 200 × 200 GIF extracted from a CDR logo file.
 * 3. When automating batch conversion of vector CDR assets into small GIF icons for mobile apps.
 * 4. When creating a preview image for a document management system that only supports GIF format.
 * 5. When extracting a specific region of a CDR illustration to embed in a PowerPoint slide as a GIF.
 */
