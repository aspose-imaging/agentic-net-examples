// HOW-TO: Convert Transparent EMF to JPEG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                Source src = new FileCreateSource(outputPath, false);
                using (JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 100 })
                {
                    using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, emfImage.Width, emfImage.Height))
                    {
                        Aspose.Imaging.Color bgColor = Aspose.Imaging.Color.White;
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(bgColor);
                        graphics.DrawImage(emfImage, 0, 0);
                        canvas.Save();
                    }
                }
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
 * 1. When you need to embed vector EMF logos with transparent areas into a JPEG report and require a solid white background to avoid visual artifacts.
 * 2. When generating thumbnails of EMF diagrams for web pages that only support JPEG and need a consistent background color.
 * 3. When converting legacy EMF drawings to JPEG for email attachments while ensuring the transparent parts appear on a chosen background.
 * 4. When automating batch processing of EMF files to JPEG in a C# application and must replace transparency with a specific color for printing.
 * 5. When creating JPEG assets from EMF icons for mobile apps where the platform does not support transparency and a background fill is required.
 */
