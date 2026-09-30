// HOW-TO: Convert EPS to PDF with Custom Output File Name in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

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

            string inputPath = Path.Combine(inputDirectory, "sample.eps");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_converted.pdf";
            string outputPath = Path.Combine(outputDirectory, outputFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to turn an EPS illustration into a PDF for client delivery while automatically appending a “_converted” suffix to the file name.
 * 2. When a C# application must generate PDF versions of vector graphics stored in an Input folder and place them in an Output folder with consistent naming.
 * 3. When integrating Aspose.Imaging into a workflow that converts design assets from EPS to PDF for printing, ensuring the output files are uniquely named.
 * 4. When automating the creation of PDF previews of EPS logos for a web catalog, using a custom naming pattern to avoid overwriting existing files.
 * 5. When building a CI/CD pipeline that validates EPS files by converting them to PDF and storing the results with a predictable filename for later verification.
 */
