// HOW-TO: Batch Convert Multiple DjVu Files to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths for 20 documents
            string[] inputPaths = new string[20];
            string[] outputPaths = new string[20];
            for (int i = 0; i < 20; i++)
            {
                inputPaths[i] = $"C:\\Input\\file{i + 1}.djvu";
                outputPaths[i] = $"C:\\Output\\file{i + 1}.pdf";
            }

            // Process each file
            for (int i = 0; i < 20; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document and save as PDF
                using (Stream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
                        // Save with default PDF options
                        djvuImage.Save(outputPath, new PdfOptions());
                    }
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
 * 1. When a company needs to archive a large set of scanned DjVu documents as searchable PDFs for legal compliance.
 * 2. When a desktop application must automatically convert newly uploaded DjVu files into PDF format for easier viewing by end‑users.
 * 3. When a migration script processes a batch of legacy DjVu manuals, turning each into PDF without custom rendering settings.
 * 4. When an automated workflow generates PDF reports from DjVu source files to integrate with existing PDF‑based document management systems.
 * 5. When a developer wants to ensure all DjVu files in a folder are converted to PDF with default options before sending them to a third‑party service.
 */
