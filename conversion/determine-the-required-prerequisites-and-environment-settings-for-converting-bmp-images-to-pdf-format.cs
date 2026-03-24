using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input BMP file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options (optional customizations)
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve the original image DPI in the PDF
                UseOriginalImageResolution = true
            };

            // Save the image as a PDF file
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("BMP to PDF conversion completed.");
    }
}

/* Prerequisites and environment settings:
 * - .NET Framework 4.6+ or .NET Core 2.0+ (compatible with Aspose.Imaging for .NET)
 * - Aspose.Imaging for .NET library referenced (install via NuGet: Aspose.Imaging)
 * - Valid Aspose.Imaging license (apply with Aspose.Imaging.License if required)
 * - Read permission for the input BMP file and write permission for the output directory
 * - Ensure the platform (x86/x64) matches the Aspose.Imaging binaries used at runtime
 */