// HOW-TO: How To Draw A Rectangle On An Image With Error Handling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics;
                try
                {
                    graphics = new Graphics(image);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Graphics creation failed: {ex.Message}");
                    return;
                }

                Pen pen = new Pen(Color.Blue, 5);
                graphics.DrawRectangle(pen, new Rectangle(10, 10, 100, 100));

                FileCreateSource src = new FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions() { Source = src };
                image.Save(outputPath, options);
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
 * 1. When you need to add a highlighted rectangle to a JPEG photo and save the result as a PNG while safely handling formats that Graphics cannot process.
 * 2. When your application must verify the existence of an input file, create missing output directories, and gracefully report errors during image manipulation.
 * 3. When you want to use Aspose.Imaging to draw vector graphics on images in a .NET service without crashing on unsupported image types.
 * 4. When you are converting user‑uploaded images to a standard PNG format and need to log any failures that occur while creating a Graphics object.
 * 5. When you are building a batch image‑processing tool that draws annotations and must continue processing other files even if one file’s format is not supported.
 */
