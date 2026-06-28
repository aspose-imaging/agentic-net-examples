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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to batch‑convert legacy BMP scans of printed forms into searchable PDF reports by applying a custom color matrix that enhances the form fields.
 * 2. When an e‑learning platform must transform BMP screenshots of classroom whiteboards using a contrast‑adjusting color matrix and deliver the results as PDF handouts.
 * 3. When a medical imaging system has to preprocess BMP X‑ray images with a false‑color matrix to improve tissue visibility before archiving them as PDF documents.
 * 4. When a marketing automation tool generates product catalogs by recoloring BMP product photos with a brand‑specific color matrix and packaging each page as a PDF.
 * 5. When a legal document management solution needs to normalize BMP‑encoded signatures using a color matrix for background removal and store the cleaned signatures as PDF files.
 */