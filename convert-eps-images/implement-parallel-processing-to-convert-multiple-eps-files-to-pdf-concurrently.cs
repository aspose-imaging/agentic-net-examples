// HOW-TO: Convert Multiple EPS Files to PDF in Parallel Using C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.eps", SearchOption.TopDirectoryOnly);

            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    epsImage.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a design team needs to quickly batch‑convert a large collection of EPS artwork into PDF for client review, this code speeds up the process by using parallel execution.
 * 2. When an automated build pipeline must generate PDF documentation from EPS diagrams without slowing down the build, the parallel conversion ensures efficient resource utilization.
 * 3. When a web service receives multiple EPS uploads and must return PDF versions instantly, this snippet demonstrates how to handle the conversions concurrently in C#.
 * 4. When migrating legacy EPS assets to a PDF‑based archive, the code lets you process thousands of files simultaneously, reducing migration time.
 * 5. When integrating Aspose.Imaging into a Windows service that monitors an input folder for new EPS files, the parallel loop converts each new file to PDF as soon as it appears.
 */
