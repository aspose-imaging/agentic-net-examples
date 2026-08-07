using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access vector-specific functionality
                CdrImage cdrImage = (CdrImage)image;

                // Define a 200x200 rectangle starting at (0,0)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image
                cdrImage.Crop(cropArea);

                // Save the cropped image as GIF
                cdrImage.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to generate a 200×200 thumbnail preview of a CorelDRAW (.cdr) design for a web gallery by cropping the image and saving it as a lightweight GIF using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must extract a 200‑pixel square logo from a vector CDR file and convert it to GIF for inclusion in email newsletters.
 * 3. When a desktop application automates the creation of animated GIF icons from specific sections of CorelDRAW artwork by cropping a 200×200 rectangle in C#.
 * 4. When a content management system requires batch processing of CDR files to produce 200×200 GIF snapshots for quick preview loading.
 * 5. When a developer integrates vector‑to‑raster conversion in a reporting tool, needing to crop a CorelDRAW drawing to a fixed 200×200 area and output it as a GIF for inclusion in PDF reports.
 */