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
            // Hardcoded input path
            string inputPath = "input.emf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access Width and Height properties
                EmfImage emfImage = image as EmfImage;
                if (emfImage != null)
                {
                    // Log dimensions
                    Console.WriteLine($"Width: {emfImage.Width}");
                    Console.WriteLine($"Height: {emfImage.Height}");
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not an EMF image.");
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application uses Aspose.Imaging to load an EMF file with Image.Load and must verify that the EmfImage.Width and EmfImage.Height meet predefined size limits before further processing.
 * 2. When generating a catalog of graphics where the system logs the width and height of each EMF image to provide metadata for quality‑control reviews.
 * 3. When converting EMF files to another format and the conversion routine reads the EmfImage dimensions to calculate the correct scaling factors.
 * 4. When a server‑side service receives EMF assets from external partners and records the image dimensions using Aspose.Imaging for monitoring and auditing purposes.
 * 5. When building a thumbnail generator that first reads the EMF image’s Width and Height via EmfImage to determine the appropriate thumbnail dimensions.
 */