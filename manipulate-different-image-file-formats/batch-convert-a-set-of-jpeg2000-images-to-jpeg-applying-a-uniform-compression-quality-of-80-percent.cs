// HOW-TO: Batch Convert JPEG2000 Images to JPEG with 80% Quality in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".jp2" && ext != ".j2k" && ext != ".jpx" && ext != ".jpf")
                {
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Quality = 80;
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
 * 1. When you need to migrate a legacy archive of JPEG2000 files to standard JPEG format for compatibility with web browsers, you can use this code to convert them in bulk with a consistent 80% quality setting.
 * 2. When preparing high‑resolution medical or satellite images stored as JP2 for faster preview thumbnails, the batch conversion to JPEG reduces file size while preserving acceptable visual quality.
 * 3. When automating a nightly build that packages image assets, this script can transform all incoming JPEG2000 assets into JPEGs with uniform compression, ensuring the output folder contains ready‑to‑use files.
 * 4. When integrating Aspose.Imaging into a C# application that receives user‑uploaded JPX or J2K files, you can instantly re‑encode them to JPEG with a predefined quality to simplify downstream processing.
 * 5. When creating a migration tool to move digital assets from a content management system that stores JPEG2000 to one that only supports JPEG, the code provides a simple way to batch convert and preserve naming conventions.
 */
