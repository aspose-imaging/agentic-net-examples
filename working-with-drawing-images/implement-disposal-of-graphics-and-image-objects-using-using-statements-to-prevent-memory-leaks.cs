using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"input.png";
        string outputPath = @"output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, new Rectangle(10, 10, 100, 100));
                }

                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to overlay a red rectangle on a PNG image while ensuring the Graphics and Image objects are properly disposed to avoid memory leaks in a .NET application.
 * 2. When an automated batch process must read existing PNG files, draw shapes using Aspose.Imaging brushes, and save the modified images without exhausting system resources.
 * 3. When integrating image annotation features into a C# web service, the code guarantees that file streams are closed and unmanaged resources are released after drawing on the image.
 * 4. When creating a desktop utility that generates highlighted sections on screenshots, using statements prevent lingering GDI+ handles that could crash the application.
 * 5. When performing server‑side image manipulation for a reporting tool, the pattern ensures safe loading, editing, and saving of PNG files while complying with .NET memory‑management best practices.
 */