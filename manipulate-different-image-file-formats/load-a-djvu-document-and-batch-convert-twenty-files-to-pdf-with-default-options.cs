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
            // Hardcoded input DjVu file paths
            string[] inputPaths = new string[]
            {
                @"C:\Input\file1.djvu",
                @"C:\Input\file2.djvu",
                @"C:\Input\file3.djvu",
                @"C:\Input\file4.djvu",
                @"C:\Input\file5.djvu",
                @"C:\Input\file6.djvu",
                @"C:\Input\file7.djvu",
                @"C:\Input\file8.djvu",
                @"C:\Input\file9.djvu",
                @"C:\Input\file10.djvu",
                @"C:\Input\file11.djvu",
                @"C:\Input\file12.djvu",
                @"C:\Input\file13.djvu",
                @"C:\Input\file14.djvu",
                @"C:\Input\file15.djvu",
                @"C:\Input\file16.djvu",
                @"C:\Input\file17.djvu",
                @"C:\Input\file18.djvu",
                @"C:\Input\file19.djvu",
                @"C:\Input\file20.djvu"
            };

            // Corresponding output PDF file paths
            string[] outputPaths = new string[]
            {
                @"C:\Output\file1.pdf",
                @"C:\Output\file2.pdf",
                @"C:\Output\file3.pdf",
                @"C:\Output\file4.pdf",
                @"C:\Output\file5.pdf",
                @"C:\Output\file6.pdf",
                @"C:\Output\file7.pdf",
                @"C:\Output\file8.pdf",
                @"C:\Output\file9.pdf",
                @"C:\Output\file10.pdf",
                @"C:\Output\file11.pdf",
                @"C:\Output\file12.pdf",
                @"C:\Output\file13.pdf",
                @"C:\Output\file14.pdf",
                @"C:\Output\file15.pdf",
                @"C:\Output\file16.pdf",
                @"C:\Output\file17.pdf",
                @"C:\Output\file18.pdf",
                @"C:\Output\file19.pdf",
                @"C:\Output\file20.pdf"
            };

            for (int i = 0; i < inputPaths.Length; i++)
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
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
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
 * 1. When a developer needs to migrate a legacy archive of scanned DjVu documents into universally viewable PDF files for distribution to clients, they can use this code to batch convert twenty files at a time.
 * 2. When an automated document processing pipeline must transform incoming DjVu scans from a scanner into PDF format for storage in a content management system, the snippet provides a simple C# loop that loads each DjVu and saves it as PDF with default settings.
 * 3. When a legal firm wants to prepare evidence files originally saved as DjVu for courtroom presentation, they can employ this code to quickly convert a batch of twenty files to PDF without manually opening each file.
 * 4. When a cloud‑based service offers on‑demand file format conversion and needs to handle DjVu‑to‑PDF requests efficiently, the example demonstrates how to load multiple DjVu images and export them as PDFs using Aspose.Imaging in .NET.
 * 5. When a developer is building a desktop utility that lets users select a folder of DjVu manuals and generate corresponding PDF versions in one click, this code shows the core logic for iterating through twenty file paths and performing the conversion with default image options.
 */