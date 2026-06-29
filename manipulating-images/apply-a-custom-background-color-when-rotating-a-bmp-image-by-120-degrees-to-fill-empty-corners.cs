using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\rotated.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access BMP-specific features if needed
                BmpImage bmp = (BmpImage)image;

                // Rotate 120 degrees, resize proportionally, fill empty corners with a custom background color
                Color backgroundColor = Color.FromArgb(255, 200, 200, 200); // Light gray
                bmp.Rotate(120f, true, backgroundColor);

                // Save the rotated image
                bmp.Save(outputPath);
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
 * 1. When generating printable game assets that must be rotated at a non‑right angle, a developer can use Aspose.Imaging for .NET to rotate a BMP sprite by 120° and fill the resulting empty corners with a light‑gray background color to maintain a consistent visual appearance.
 * 2. When converting legacy BMP diagrams into a rotated layout for a technical manual, a C# application can apply a custom background color during the 120‑degree rotation to avoid transparent gaps that would otherwise appear in the PDF output.
 * 3. When creating a batch‑processing tool that aligns scanned BMP photographs to a standard orientation, developers can rotate each image by 120° with Aspose.Imaging and specify a background color so the newly exposed corners blend with the surrounding page background.
 * 4. When building a custom map‑tiling service that needs to display BMP tiles at an angled perspective, the code can rotate each tile by 120 degrees and fill empty corners with a chosen color to prevent visual artifacts in the rendered map.
 * 5. When developing an automated watermarking pipeline that first rotates BMP logos by 120° before overlaying them, using a custom background color ensures the rotated logo’s corners match the document’s background and do not appear transparent.
 */