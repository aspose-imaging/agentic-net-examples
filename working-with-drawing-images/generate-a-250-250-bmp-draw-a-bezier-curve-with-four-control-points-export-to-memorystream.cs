using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions
                {
                    Source = new StreamSource(memoryStream)
                };

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 250, 250))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                    graphics.DrawBezier(
                        pen,
                        new Aspose.Imaging.Point(20, 20),
                        new Aspose.Imaging.Point(80, 10),
                        new Aspose.Imaging.Point(150, 200),
                        new Aspose.Imaging.Point(230, 230)
                    );

                    image.Save();
                }

                Console.WriteLine($"MemoryStream length: {memoryStream.Length}");
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
 * 1. When a developer needs to create a 250 × 250 BMP image on the fly and draw a custom Bezier curve for a UI thumbnail, using Aspose.Imaging in C# and keeping the result in a MemoryStream to avoid temporary files.
 * 2. When a backend service must generate a lightweight BMP signature graphic with four control points for PDF stamping, leveraging Aspose.Imaging’s Graphics API and streaming the output directly to a response stream.
 * 3. When an automated testing framework requires an in‑memory BMP sample that contains a precise Bezier curve to validate image‑processing algorithms without persisting files to disk.
 * 4. When a cloud function has to produce a BMP icon with a blue Bezier path for dynamic email attachments, using Aspose.Imaging’s StreamSource to write the image into a MemoryStream for attachment encoding.
 * 5. When a desktop application needs to export a custom‑drawn BMP chart element—such as a Bezier‑based trend line—directly to a MemoryStream for further manipulation or embedding in another document format.
 */