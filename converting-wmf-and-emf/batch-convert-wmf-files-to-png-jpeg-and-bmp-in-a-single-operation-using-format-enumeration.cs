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
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all WMF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    // Convert to PNG
                    string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    image.Save(pngPath, new PngOptions());

                    // Convert to JPEG
                    string jpegPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
                    image.Save(jpegPath, new JpegOptions());

                    // Convert to BMP
                    string bmpPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                    image.Save(bmpPath, new BmpOptions());
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
 * 1. When a developer needs to migrate a legacy collection of Windows Metafile (WMF) graphics to modern web‑friendly formats such as PNG, JPEG, and BMP in a single batch operation using Aspose.Imaging for .NET.
 * 2. When an automation script must generate thumbnail previews and high‑resolution copies of WMF icons for a desktop application by converting each file to PNG, JPEG, and BMP without manual intervention.
 * 3. When a content management system requires bulk import of WMF diagrams and must store them in multiple raster formats for cross‑platform compatibility, leveraging C# file I/O and Aspose.Imaging’s format enumeration.
 * 4. When a reporting tool needs to export WMF charts to printable JPEG images and lossless PNG files while also preserving a BMP version for legacy printers, using a single loop over the input directory.
 * 5. When a migration project automates the conversion of archived WMF assets into standard image formats for SEO‑friendly web pages, employing Aspose.Imaging’s Image.Load and Save methods in C#.
 */