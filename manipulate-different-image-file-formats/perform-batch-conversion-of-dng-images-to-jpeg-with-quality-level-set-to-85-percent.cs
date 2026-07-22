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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.dng");
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;
                    var jpegOptions = new JpegOptions { Quality = 85 };
                    dngImage.Save(outputPath, jpegOptions);
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
 * 1. When a photographer needs to prepare a web‑ready gallery by converting raw DNG files from a shoot into compressed JPEGs with a quality setting of 85 % using C# and Aspose.Imaging.
 * 2. When a mobile‑app backend must batch‑process uploaded raw DNG images from users and store them as smaller JPEG files for faster download and display.
 * 3. When an e‑commerce platform wants to automate the conversion of high‑resolution product photos captured in DNG format to JPEG thumbnails while preserving visual fidelity at 85 % quality.
 * 4. When a digital archiving system requires a scheduled job that scans a folder of DNG scans, converts each to JPEG, and saves them to an output directory using Aspose.Imaging’s JpegOptions.
 * 5. When a scientific imaging workflow needs to transform raw DNG microscope images into JPEGs for inclusion in reports, ensuring consistent compression level across all files.
 */