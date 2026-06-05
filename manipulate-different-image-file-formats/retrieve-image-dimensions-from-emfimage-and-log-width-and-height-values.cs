using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\dimensions.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Retrieve dimensions
                int width = emfImage.Width;
                int height = emfImage.Height;

                // Log dimensions to console
                Console.WriteLine($"Width: {width}");
                Console.WriteLine($"Height: {height}");

                // Write dimensions to output file
                File.WriteAllText(outputPath, $"Width: {width}{Environment.NewLine}Height: {height}");
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
 * 1. When generating a report that includes EMF graphics, a developer can use this code to read the image dimensions and store them for layout calculations.
 * 2. When validating uploaded vector images on a web service, the code helps ensure the EMF file meets size constraints before processing.
 * 3. When converting a batch of EMF files to PDFs, the dimensions are needed to set the page size correctly, and this snippet logs them for verification.
 * 4. When creating a thumbnail gallery of EMF drawings, the width and height values are required to maintain aspect ratio, and the code writes them to a text file for later use.
 * 5. When troubleshooting rendering issues in a Windows Forms application, a developer can log the EMF image dimensions to diagnose mismatched control sizes.
 */