// HOW-TO: Convert OTG Vector File to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OTGToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to display an OTG design on a web page, they can convert it to a PNG bitmap with Aspose.Imaging in C#.
 * 2. When integrating a CAD workflow that receives OTG drawings, the code lets the application generate PNG thumbnails for quick preview.
 * 3. When building a document‑generation service that must embed vector graphics into PDFs, converting OTG to PNG provides a raster image compatible with most PDF libraries.
 * 4. When creating an automated batch job that processes a folder of OTG files, this snippet can be used to rasterize each file to PNG for archival or reporting purposes.
 * 5. When a mobile app requires PNG assets but the source graphics are stored as OTG, developers can use this code to perform the conversion on the server side before sending the images to the device.
 */
