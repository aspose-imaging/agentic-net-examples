// HOW-TO: Rotate EMF Image 90 Degrees and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Rotate the image 90 degrees clockwise without flipping
                emfImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the rotated image as PNG
                PngOptions pngOptions = new PngOptions();
                emfImage.Save(outputPath, pngOptions);
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
 * 1. When a Windows application needs to display vector graphics from legacy EMF files in a web page, rotating them 90° and converting to PNG for browser compatibility.
 * 2. When generating printable reports that require EMF charts to be reoriented and saved as PNG thumbnails for inclusion in PDF documents.
 * 3. When automating a batch process that standardizes the orientation of scanned EMF diagrams before archiving them as lossless PNG files.
 * 4. When a GIS system must align map symbols stored as EMF by rotating them 90 degrees and converting to PNG for use in mobile map tiles.
 * 5. When a document conversion service needs to preserve the visual layout of EMF logos by rotating them and exporting to PNG for email newsletters.
 */
