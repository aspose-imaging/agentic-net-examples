using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\BmpInput";
            string outputDirectory = @"C:\Images\PdfOutput";

            // Ensure the output directory exists (will also handle null path safely)
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);

            // Process each BMP file
            foreach (string bmpPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Create a unique timestamp prefix for the output file name
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(bmpPath)}.pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(bmpPath))
                {
                    // Set up PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to automatically convert a folder of legacy BMP screenshots into searchable PDF reports while ensuring each PDF has a unique timestamped filename.
 * 2. When an application must archive scanned BMP documents to PDF format on a daily basis, using C# and Aspose.Imaging to generate timestamp‑prefixed files for version control.
 * 3. When a batch processing script is required to migrate BMP assets from a legacy system to PDF for web publishing, creating unique filenames to avoid overwriting existing files.
 * 4. When a Windows service needs to monitor an input directory, convert incoming BMP images to PDF, and store them in an output folder with a precise timestamp for audit trails.
 * 5. When a developer wants to implement a one‑time data‑migration tool that reads BMP files, applies Aspose.Imaging PDF export options, and saves each result with a millisecond‑level timestamp to guarantee uniqueness.
 */