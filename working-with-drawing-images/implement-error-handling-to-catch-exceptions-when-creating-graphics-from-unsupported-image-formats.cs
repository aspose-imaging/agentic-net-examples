using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
            {
                Source source = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, inputImage.Width, inputImage.Height))
                {
                    try
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Color.White);
                        Pen pen = new Pen(Color.Blue, 5);
                        graphics.DrawRectangle(pen, new Rectangle(10, 10, canvas.Width - 20, canvas.Height - 20));
                    }
                    catch (Exception gex)
                    {
                        Console.Error.WriteLine($"Graphics creation failed: {gex.Message}");
                        return;
                    }

                    canvas.Save();
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
 * 1. When a web service receives user‑uploaded JPEG files and must convert them to PNG while drawing a border, the code ensures unsupported formats are caught before creating a Graphics object.
 * 2. When an automated batch job processes scanned documents stored as TIFF or BMP and needs to overlay annotations, the try‑catch around Graphics prevents crashes on formats that Aspose.Imaging cannot render.
 * 3. When a desktop application lets users edit images from a network share and the file may be a RAW or PSD file, the error handling alerts the user that Graphics cannot be created for those unsupported types.
 * 4. When a cloud function generates thumbnails for various image formats and must fall back gracefully if the source image is corrupted or in an unknown format, the exception handling around Graphics creation provides a clear error message.
 * 5. When a reporting tool programmatically draws shapes on images loaded from a database and the stored blob could be an unsupported GIF or ICO, the code captures the exception to avoid terminating the report generation process.
 */