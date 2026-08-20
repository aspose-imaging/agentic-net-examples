// HOW-TO: How To Dispose Image And Graphics Objects In Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

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

            // Load the source image (disposed automatically)
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing (not disposable)
                Graphics graphics = new Graphics(image);

                // Optional: clear the canvas with white background
                graphics.Clear(Color.White);

                // Draw a red rectangle
                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                // Fill a blue ellipse using a SolidBrush (disposable)
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(brush, new Rectangle(300, 100, 150, 100));
                }

                // Save the modified image as PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to load a JPEG, draw shapes, and save as PNG while ensuring unmanaged resources are released.
 * 2. When you want to add a red rectangle and a blue ellipse to an existing image without causing memory leaks in a .NET application.
 * 3. When you are processing user‑uploaded photos and must guarantee that Image and Brush objects are disposed after editing.
 * 4. When you are generating thumbnails with custom graphics and need deterministic cleanup of Aspose.Imaging resources.
 * 5. When you integrate Aspose.Imaging into a web service that draws on images and must prevent out‑of‑memory errors by using using statements.
 */
