using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative to the current directory)
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

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
        if (epsFiles.Length == 0)
        {
            Console.WriteLine("No EPS files found in the Input directory.");
            return;
        }

        // Prompt user to select target format
        Console.WriteLine("Select output format:");
        Console.WriteLine("1 - PNG");
        Console.WriteLine("2 - JPEG");
        Console.WriteLine("3 - BMP");
        Console.WriteLine("4 - GIF");
        Console.WriteLine("5 - TIFF");
        Console.WriteLine("6 - PDF");
        Console.WriteLine("7 - WEBP");
        Console.Write("Enter the number of the desired format: ");
        string choice = Console.ReadLine();

        // Determine options and file extension based on user choice
        ImageOptionsBase options;
        string extension;
        switch (choice)
        {
            case "1":
                options = new PngOptions();
                extension = ".png";
                break;
            case "2":
                options = new JpegOptions();
                extension = ".jpg";
                break;
            case "3":
                options = new BmpOptions();
                extension = ".bmp";
                break;
            case "4":
                options = new GifOptions();
                extension = ".gif";
                break;
            case "5":
                options = new TiffOptions(TiffExpectedFormat.Default);
                extension = ".tiff";
                break;
            case "6":
                options = new PdfOptions();
                extension = ".pdf";
                break;
            case "7":
                options = new WebPOptions();
                extension = ".webp";
                break;
            default:
                Console.WriteLine("Invalid selection.");
                return;
        }

        // Process each EPS file
        foreach (string epsPath in epsFiles)
        {
            // Verify input file exists
            if (!File.Exists(epsPath))
            {
                Console.Error.WriteLine($"File not found: {epsPath}");
                continue;
            }

            // Build output file path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epsPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + extension);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and save in selected format
            using (Image image = Image.Load(epsPath))
            {
                // Cast to EpsImage for clarity (full name used to avoid extra using)
                var epsImage = image as Aspose.Imaging.FileFormats.Eps.EpsImage;
                if (epsImage == null)
                {
                    Console.Error.WriteLine($"Failed to load EPS image: {epsPath}");
                    continue;
                }

                // Save using the chosen options
                epsImage.Save(outputPath, options);
            }

            Console.WriteLine($"Converted '{Path.GetFileName(epsPath)}' to '{Path.GetFileName(outputPath)}'.");
        }

        Console.WriteLine("Conversion process completed.");
    }
}