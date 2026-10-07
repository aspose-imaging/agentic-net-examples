// HOW-TO: Convert ODG File to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output\\output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions options = new JpegOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to display OpenDocument graphics on a website that only supports JPEG images.
 * 2. When an automated batch job must convert archived ODG drawings to JPEG for quick preview generation.
 * 3. When integrating a C# application with a content management system that stores images as JPEG but receives source files in ODG format.
 * 4. When creating thumbnails of ODG diagrams for email attachments where JPEG is the required format.
 * 5. When migrating legacy OpenDocument graphics to a photo‑gallery application that only accepts JPEG files.
 */
