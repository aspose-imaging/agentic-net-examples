using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (PngImage pngImage = new PngImage(pngOptions, 400, 400))
            {
                Graphics graphics = new Graphics(pngImage);
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 300, 300));

                pngImage.Save();
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
 * 1. When a developer needs to programmatically generate a PNG diagram, draw shapes, and enhance the shape outlines with a 3×3 edge‑detection convolution filter for clearer presentation in reports.
 * 2. When an application must create a white canvas, render vector graphics such as rectangles, apply an edge detection filter to emphasize borders, and save the result as a PNG for web preview.
 * 3. When an automated testing framework requires rendering UI mockups, extracting edge features via a convolution filter, and storing the processed image as PNG for visual regression comparison.
 * 4. When a document generation system wants to embed dynamically drawn graphics with stronger edge contrast, using Aspose.Imaging’s C# API to apply a convolution filter before exporting the final image as PNG.
 * 5. When a developer builds a lightweight image‑processing pipeline that creates simple drawings, runs a 3×3 edge detection filter to prepare the image for OCR preprocessing, and outputs the processed image in PNG format.
 */