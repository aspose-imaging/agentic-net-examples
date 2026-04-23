using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories (relative paths)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add EPS files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        if (files.Length == 0)
        {
            Console.WriteLine("No files found in the input directory.");
            return;
        }

        // Ask user for desired output format
        Console.WriteLine("Enter desired output format (png, jpg, pdf):");
        string format = Console.ReadLine()?.Trim().ToLowerInvariant();

        // Validate format selection
        if (format != "png" && format != "jpg" && format != "pdf")
        {
            Console.Error.WriteLine("Unsupported format selected.");
            return;
        }

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build output file path with new extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "." + format;
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists (unconditional as per safety rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and save in selected format
            using (Image image = Image.Load(inputPath))
            {
                switch (format)
                {
                    case "png":
                        image.Save(outputPath, new PngOptions());
                        break;
                    case "jpg":
                        image.Save(outputPath, new JpegOptions());
                        break;
                    case "pdf":
                        image.Save(outputPath, new PdfOptions());
                        break;
                }
            }

            Console.WriteLine($"Converted '{Path.GetFileName(inputPath)}' to '{outputFileName}'.");
        }

        Console.WriteLine("Conversion process completed.");
    }
}