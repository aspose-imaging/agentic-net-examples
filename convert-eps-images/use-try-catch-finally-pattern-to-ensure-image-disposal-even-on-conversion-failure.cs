// HOW-TO: Convert JPG to PNG in C# With Safe Disposal Using Try Catch Finally (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output\\output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Image image = null;
                try
                {
                    image = Image.Load(inputPath);
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Conversion error: {ex.Message}");
                }
                finally
                {
                    if (image != null)
                    {
                        image.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert user‑uploaded JPEG photos to PNG for web display while guaranteeing the image object is released even if conversion fails.
 * 2. When an automated service processes scanned documents, converting each JPG file to lossless PNG and handling missing files or I/O errors gracefully.
 * 3. When integrating image conversion into a Windows service that must not leak memory, using try‑catch‑finally to ensure Image.Dispose runs on every execution.
 * 4. When building a desktop application that lets users select a JPEG and saves a PNG version in a specific folder, with error messages logged if the source file is absent.
 * 5. When creating a scheduled task that transforms images for archival, employing nested try blocks to catch conversion exceptions and still clean up resources.
 */
