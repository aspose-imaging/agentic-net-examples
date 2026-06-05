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
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (BmpImage bmp = (BmpImage)Image.Load(inputPath))
            {
                // Create a graphics object for drawing
                Graphics graphics = new Graphics(bmp);

                // Pen used for drawing the lines
                Pen pen = new Pen(Color.Black, 1);

                // Angle of the parallel lines (in degrees) and spacing between them
                double angleDeg = 45.0;
                double rad = angleDeg * Math.PI / 180.0;
                int spacing = 20; // pixels

                int width = bmp.Width;
                int height = bmp.Height;

                // Draw a series of parallel lines that cover the whole image
                for (int offset = -height; offset < height; offset += spacing)
                {
                    int x1 = 0;
                    int y1 = offset;
                    int x2 = width;
                    int y2 = offset + (int)(width * Math.Tan(rad));

                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified BMP image
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
 * 1. When a developer needs to add a diagonal parallel‑line watermark to a BMP file using the Aspose.Imaging library in C# for branding or security.
 * 2. When generating printable engineering schematics that require evenly spaced hatch lines at a specific angle drawn onto a bitmap image with Aspose.Imaging.
 * 3. When creating custom texture overlays for game assets by programmatically drawing angled parallel lines on a BMP using C# and Aspose.Imaging.
 * 4. When preprocessing scanned documents to add visual guide lines at a chosen angle on the original BMP for manual annotation, leveraging Aspose.Imaging’s drawing API.
 * 5. When automating the production of patterned background images for UI components by drawing spaced parallel lines at a configurable angle on BMP files with Aspose.Imaging in .NET.
 */