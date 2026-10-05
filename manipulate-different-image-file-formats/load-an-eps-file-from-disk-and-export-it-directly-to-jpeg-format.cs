// HOW-TO: Convert EPS File to JPEG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace EpsToJpeg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output\\output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
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
 * 1. When a designer needs to display vector EPS artwork on a website that only supports JPEG images, this code converts the EPS to a JPEG in C#.
 * 2. When an automated build pipeline must generate thumbnail previews of EPS files for a document management system, the snippet creates JPEG thumbnails on the fly.
 * 3. When a desktop application imports EPS logos and must store them as compressed JPEGs for faster loading, the code performs the conversion using Aspose.Imaging.
 * 4. When a cloud service receives EPS uploads and must return a JPEG version for client‑side rendering, this example shows how to load and save the image in C#.
 * 5. When a batch job processes a folder of EPS files and needs to output JPEG files to a separate directory, the program demonstrates the required file existence checks and directory creation.
 */
