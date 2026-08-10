// HOW-TO: Create BMP Image and Mirror Diagonal Line Using Transform in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = "c:\\temp\\reflected.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            // Create a BMP canvas
            using (BmpImage bmp = new BmpImage(width, height))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(bmp);
                graphics.Clear(Color.White);

                // Draw original diagonal line
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, 0, 0, width, height);

                // Apply horizontal reflection transform (vertical axis)
                Matrix reflect = new Matrix(-1, 0, 0, 1, width, 0);
                graphics.Transform = reflect;

                // Draw the same line; it will appear reflected
                graphics.DrawLine(pen, 0, 0, width, height);

                // Reset transform (optional)
                graphics.Transform = new Matrix();

                // Save the resulting image
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
 * 1. When you need to generate a BMP file with a simple geometric pattern for testing image rendering pipelines.
 * 2. When you want to programmatically create a mirrored version of a line or shape without manually calculating pixel positions.
 * 3. When you are building a graphics editor that supports real‑time reflection of drawing strokes on a bitmap canvas.
 * 4. When you need to produce a symmetric design for UI icons or placeholders by reflecting existing graphics.
 * 5. When you are benchmarking Aspose.Imaging transformation performance on BMP images in a .NET application.
 */
