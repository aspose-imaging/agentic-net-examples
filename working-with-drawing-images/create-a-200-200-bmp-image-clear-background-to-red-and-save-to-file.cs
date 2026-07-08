using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 200x200 BMP image
            using (BmpImage bmpImage = new BmpImage(200, 200))
            {
                // Fill the entire image with red color
                Graphics graphics = new Graphics(bmpImage);
                SolidBrush redBrush = new SolidBrush(Color.Red);
                graphics.FillRectangle(redBrush, bmpImage.Bounds);

                // Save the image to the specified file
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
 * 1. When a developer needs to generate a simple placeholder image in BMP format for testing UI components that require a 200 × 200 red background.
 * 2. When an automated report generator must embed a red square BMP image of fixed dimensions into a PDF using C# and Aspose.Imaging.
 * 3. When a game asset pipeline requires creating a solid‑color BMP texture of 200 × 200 pixels for prototyping level design.
 * 4. When a Windows desktop application needs to programmatically create a red BMP icon file for dynamic theming or branding.
 * 5. When a batch image processing script must produce a red background BMP file as a base layer before applying additional graphics operations.
 */