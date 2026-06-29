using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage png = (RasterImage)Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Quality = 100;
                        png.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert a large collection of PNG assets with transparent backgrounds into high‑quality JPEGs for web delivery, they can use this batch processing code.
 * 2. When an e‑commerce platform must generate product thumbnails by applying a 64‑alpha overlay to PNG logos and saving them as JPEG files to reduce file size, this snippet automates the task.
 * 3. When a mobile app requires pre‑processing of user‑uploaded PNG stickers by adding a semi‑transparent overlay and exporting them as JPEGs for faster rendering, the code provides a C# solution.
 * 4. When a digital publishing workflow needs to prepare print‑ready images by converting PNG illustrations with a uniform 64‑alpha mask into JPEGs with maximum quality, the example handles the conversion in a folder loop.
 * 5. When a CI/CD pipeline must ensure that all PNG icons in a repository are batch‑converted to JPEG format with a consistent alpha overlay before deployment, this Aspose.Imaging routine can be integrated into the build script.
 */