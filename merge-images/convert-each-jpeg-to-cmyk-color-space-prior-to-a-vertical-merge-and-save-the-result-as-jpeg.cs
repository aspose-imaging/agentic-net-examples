using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Source = new FileCreateSource(outputPath, false);
                        image.Save(outputPath, jpegOptions);
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
 * 1. When a C# application must batch‑process all images in an input folder and guarantee that each file is saved as a JPEG using Aspose.Imaging for consistent web delivery.
 * 2. When a developer needs to re‑encode mixed‑format photos (PNG, BMP, TIFF) into JPEGs to reduce storage size before uploading to a cloud service.
 * 3. When an automated build pipeline requires converting user‑uploaded images to JPEG with Aspose.Imaging’s JpegOptions to ensure uniform compression across the project.
 * 4. When a legacy workflow expects only JPEG files in a specific directory, and a quick C# utility is needed to read any supported image format and write it as JPEG.
 * 5. When a digital asset management system must normalize incoming images to JPEG before applying further processing such as watermarking or thumbnail creation.
 */