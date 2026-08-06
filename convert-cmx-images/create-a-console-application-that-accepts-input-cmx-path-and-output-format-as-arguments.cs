using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CMX file path
            string inputPath = "Input/sample.cmx";

            // Desired output format passed as first argument (e.g., "png", "jpg", "pdf")
            string format = args[0];

            // Determine output file extension and corresponding save options
            string outputExtension;
            ImageOptionsBase options;
            switch (format.ToLower())
            {
                case "jpg":
                case "jpeg":
                    outputExtension = "jpg";
                    options = new JpegOptions();
                    break;
                case "png":
                    outputExtension = "png";
                    options = new PngOptions();
                    break;
                case "bmp":
                    outputExtension = "bmp";
                    options = new BmpOptions();
                    break;
                case "gif":
                    outputExtension = "gif";
                    options = new GifOptions();
                    break;
                case "tiff":
                    outputExtension = "tiff";
                    options = new TiffOptions(TiffExpectedFormat.Default);
                    break;
                case "pdf":
                    outputExtension = "pdf";
                    options = new PdfOptions();
                    break;
                default:
                    // Fallback to PNG if format is unrecognized
                    outputExtension = "png";
                    options = new PngOptions();
                    break;
            }

            // Construct output path and ensure its directory exists
            string outputPath = Path.Combine("Output", $"output.{outputExtension}");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CMX image and save it in the requested format
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, options);
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
 * 1. When a developer needs a command‑line tool to batch‑convert legacy CorelDRAW CMX files into common image formats such as PNG, JPEG, BMP, GIF, TIFF, or PDF for downstream processing.
 * 2. When an automated build or CI pipeline must generate image thumbnails of CMX drawings in PNG or GIF to include in documentation or release notes.
 * 3. When a Windows service processes incoming CMX files and archives them as high‑quality TIFF images using Aspose.Imaging’s TiffOptions for compliance purposes.
 * 4. When a desktop utility allows end‑users to specify the desired output format via command‑line arguments to quickly export CMX artwork to the format required by another application.
 * 5. When a migration script reads CMX files from a legacy folder structure and saves them to a new Output directory, selecting the appropriate ImageOptions based on the user‑provided format.
 */