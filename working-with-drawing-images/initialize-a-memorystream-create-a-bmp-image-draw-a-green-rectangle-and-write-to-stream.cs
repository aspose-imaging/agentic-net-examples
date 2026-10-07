// HOW-TO: Create BMP Image With Green Rectangle In Memory Stream C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(memoryStream);

                int width = 200;
                int height = 200;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 100, 100);
                    Pen pen = new Pen(Aspose.Imaging.Color.Green, 3);
                    graphics.DrawRectangle(pen, rect);

                    image.Save();
                }

                // The BMP data is now in memoryStream.
                // Example: write to a file (optional)
                // string outputPath = "output.bmp";
                // Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                // File.WriteAllBytes(outputPath, memoryStream.ToArray());
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
 * 1. When you need to generate a BMP thumbnail with a highlighted area on the fly without writing temporary files.
 * 2. When you want to embed a simple graphic, such as a green rectangle, into a PDF or email attachment directly from a memory buffer.
 * 3. When a web service must return a dynamically created BMP image for client‑side preview, using Aspose.Imaging to draw shapes in memory.
 * 4. When you are unit‑testing image‑processing logic and require an in‑memory BMP image with known dimensions and drawing content.
 * 5. When you need to batch‑process images and store intermediate BMP results in a stream before uploading them to cloud storage.
 */
