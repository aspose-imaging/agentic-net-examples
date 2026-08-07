using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image inputImage = Image.Load(inputPath))
            {
                Graphics graphics;
                try
                {
                    graphics = new Graphics(inputImage);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Graphics creation failed: {ex.Message}");
                    return;
                }

                graphics.Clear(Color.White);
                graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(20, 20, 200, 150));

                inputImage.Save(outputPath, new PngOptions());
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
 * 1. When a web service receives user‑uploaded SVG files and must convert them to PNG thumbnails while safely handling formats that Aspose.Imaging cannot render.
 * 2. When an automated report generator needs to overlay shapes on vector images (e.g., SVG logos) and must catch exceptions if the source image type is not supported by the Graphics class.
 * 3. When a desktop application processes batch image conversions from various formats and wants to log a clear error instead of crashing when an unsupported file like PDF is encountered.
 * 4. When a CI/CD pipeline validates image assets by drawing diagnostic rectangles on each file and must gracefully skip files that cannot be loaded into a Graphics object.
 * 5. When a cloud function creates PNG previews of uploaded design files and requires robust error handling for unsupported formats such as EPS or AI to prevent runtime failures.
 */