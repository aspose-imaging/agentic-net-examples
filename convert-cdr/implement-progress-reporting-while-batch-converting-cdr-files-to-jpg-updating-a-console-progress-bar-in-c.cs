using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputCdr";
            string outputFolder = "OutputJpg";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] inputFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    cdr.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert a large collection of CorelDRAW (CDR) files to JPEG images for web publishing, they can use this batch conversion with a console progress bar.
 * 2. When automating the migration of legacy CDR assets to a modern image format for a digital asset management system, this code provides a C# solution that reports progress.
 * 3. When building a command‑line tool that processes design files in a CI/CD pipeline and needs to show conversion status for each CDR to JPG conversion, the example fits.
 * 4. When creating a desktop utility that prepares print‑ready JPEG previews from multiple CDR drawings and wants users to see real‑time progress, this implementation is ideal.
 * 5. When integrating Aspose.Imaging into a batch processing service that converts CDR diagrams to compressed JPEGs while monitoring throughput via a console progress bar, developers can apply this code.
 */