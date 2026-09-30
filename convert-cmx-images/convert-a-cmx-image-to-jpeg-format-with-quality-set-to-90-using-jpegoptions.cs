// HOW-TO: Convert CMX Image To JPEG With 90 Quality In C# (Aspose.Imaging for .NET)
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
                string inputPath = "input.cmx";
                string outputPath = "output\\output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions();
                    jpegOptions.Quality = 90;

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
 * 1. When a developer needs to display legacy CorelDRAW CMX artwork on a website that only supports JPEG images, they can use this code to convert the files with high visual quality.
 * 2. When an automated pipeline must generate thumbnails from CMX files for a digital asset management system, the snippet provides a quick way to produce JPEG previews at a specified compression level.
 * 3. When a desktop application imports user‑provided CMX drawings and saves them as JPEGs for printing or sharing, this code ensures the output retains 90 % quality.
 * 4. When a cloud service receives CMX uploads and must store them in a storage‑friendly format, the example shows how to convert and compress them to JPEG using Aspose.Imaging in C#.
 * 5. When a batch‑processing script needs to convert multiple CMX files to JPEG with consistent quality settings, the code demonstrates the necessary steps to load, set JpegOptions, and save each image.
 */
