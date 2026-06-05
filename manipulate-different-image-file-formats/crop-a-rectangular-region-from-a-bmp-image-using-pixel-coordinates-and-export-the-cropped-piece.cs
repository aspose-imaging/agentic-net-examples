using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_cropped.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage for clarity (optional)
                BmpImage bmpImage = (BmpImage)image;

                // Define the cropping rectangle (example: top-left corner (50,30), width 200, height 150)
                int left = 50;   // X coordinate of the left edge
                int top = 30;    // Y coordinate of the top edge
                int width = 200; // Width of the cropped area
                int height = 150; // Height of the cropped area
                Aspose.Imaging.Rectangle cropArea = new Aspose.Imaging.Rectangle(left, top, width, height);

                // Perform the crop operation
                bmpImage.Crop(cropArea);

                // Save the cropped image (default BMP options)
                bmpImage.Save(outputPath);
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
 * 1. When a developer needs to extract a specific region from a large BMP screenshot for a thumbnail in a Windows desktop application using C# and Aspose.Imaging.
 * 2. When an automated batch process must trim unwanted margins from scanned BMP documents before archiving them in a document management system.
 * 3. When a game developer wants to slice sprite sheets stored as BMP files into individual character frames by specifying pixel coordinates in C#.
 * 4. When a medical imaging tool requires cropping a region of interest from a BMP X‑ray image for further analysis while preserving the original file format.
 * 5. When a legacy reporting system generates BMP charts and the developer must programmatically isolate a chart area for inclusion in a PDF report.
 */