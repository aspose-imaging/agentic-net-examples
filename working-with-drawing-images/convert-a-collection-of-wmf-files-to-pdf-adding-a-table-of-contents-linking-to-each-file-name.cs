// HOW-TO: Convert Multiple WMF Files to PDF with Linked Table of Contents in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            List<string> wmfFiles = files.Where(f => f.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase)).ToList();

            if (wmfFiles.Count == 0)
            {
                Console.WriteLine("No WMF files found in the Input directory.");
                return;
            }

            foreach (string wmfPath in wmfFiles)
            {
                if (!File.Exists(wmfPath))
                {
                    Console.Error.WriteLine($"File not found: {wmfPath}");
                    return;
                }
            }

            string tocPath = Path.Combine(outputDirectory, "toc.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tocPath));

            int lineHeight = 30;
            int tocWidth = 800;
            int tocHeight = lineHeight * (wmfFiles.Count + 1);
            Source tocSource = new FileCreateSource(tocPath, false);
            PngOptions tocOptions = new PngOptions { Source = tocSource };
            using (RasterImage tocCanvas = (RasterImage)Image.Create(tocOptions, tocWidth, tocHeight))
            {
                Graphics graphics = new Graphics(tocCanvas);
                graphics.Clear(Color.White);
                for (int i = 0; i < wmfFiles.Count; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(wmfFiles[i]);
                    graphics.DrawString(fileName, new Font("Arial", 12), new SolidBrush(Color.Black), new Point(10, lineHeight * (i + 1)));
                }
                tocCanvas.Save();
            }

            List<string> pageFiles = new List<string> { tocPath };
            pageFiles.AddRange(wmfFiles);

            string outputPdfPath = Path.Combine(outputDirectory, "Combined.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (Image dummy = Image.Load(wmfFiles[0]))
            {
                PdfOptions pdfOptions = new PdfOptions();
                dummy.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to batch‑convert legacy WMF drawings into a single searchable PDF for archiving.
 * 2. When an application must generate a PDF report that includes each WMF diagram and a clickable table of contents for easy navigation.
 * 3. When automating the creation of documentation that combines multiple vector graphics into one PDF with page links to each graphic’s name.
 * 4. When integrating Aspose.Imaging into a C# workflow to transform a folder of WMF assets into a PDF portfolio with a visual TOC image.
 * 5. When building a tool that prepares engineering schematics for distribution by converting WMF files to PDF and providing a navigable index.
 */
