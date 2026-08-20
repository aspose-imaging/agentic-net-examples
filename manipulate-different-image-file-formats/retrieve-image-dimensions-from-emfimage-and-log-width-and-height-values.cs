// HOW-TO: Get Width and Height of EMF Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\Images\output\dimensions.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access Width and Height
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid EMF image.");
                    return;
                }

                // Retrieve dimensions
                int width = emfImage.Width;
                int height = emfImage.Height;

                // Log dimensions to console
                Console.WriteLine($"Width: {width}");
                Console.WriteLine($"Height: {height}");

                // Optionally write dimensions to a file
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
 * 1. When a desktop application must display an EMF graphic correctly, it can read the image’s width and height to size the container control.
 * 2. When generating a PDF report that includes vector EMF files, developers need the dimensions to calculate page layout and scaling.
 * 3. When validating uploaded EMF files on a server, checking the width and height ensures they meet predefined size restrictions before further processing.
 * 4. When creating thumbnails or preview images for a document management system, the original EMF dimensions are required to maintain aspect ratio.
 * 5. When logging image metadata for audit trails, recording the EMF image’s width and height provides essential information for future reference.
 */
