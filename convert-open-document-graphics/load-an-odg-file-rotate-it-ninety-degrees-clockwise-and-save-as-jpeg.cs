// HOW-TO: Rotate ODG Image 90 Degrees Clockwise and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgRotateExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert an ODG diagram to a JPEG thumbnail for quick web preview, you can load the ODG, rotate it, and save it as JPEG using C#.
 * 2. When a scanned ODG drawing is oriented incorrectly, you can programmatically rotate it ninety degrees clockwise before publishing it as a JPEG image.
 * 3. When building a batch processor that generates JPEG previews of multiple ODG files, you can rotate each image to the correct orientation during the conversion.
 * 4. When an email client only accepts JPEG attachments, you can rotate the ODG artwork and save it as a JPEG to ensure proper display in the message.
 * 5. When integrating ODG support into a .NET application that displays user‑uploaded drawings, you can rotate the image and convert it to JPEG for consistent rendering across browsers.
 */
