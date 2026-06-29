using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\green_square.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2);
                graphics.DrawRectangle(pen, 50, 50, 100, 100);

                image.Save();
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
 * 1. When generating a PNG thumbnail for a product catalog, a developer can use this code to draw a green square overlay that highlights a specific area of interest.
 * 2. When creating a custom QR code scanner UI, the code can outline a green square on a white background to indicate the scanning region in a .NET application.
 * 3. When building an automated test that validates image processing pipelines, a developer can generate a 200×200 PNG with a green rectangle to compare against expected output.
 * 4. When designing a simple game board in a C# Windows or WPF app, the code can be used to draw green squares as tiles or selection markers on a PNG sprite sheet.
 * 5. When preparing instructional graphics for documentation, a developer can quickly produce a green‑bordered square in a PNG file to illustrate layout boundaries or cropping guides.
 */