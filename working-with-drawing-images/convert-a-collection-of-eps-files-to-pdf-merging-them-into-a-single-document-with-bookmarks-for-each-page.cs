using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] epsPaths = {
                "input1.eps",
                "input2.eps",
                "input3.eps"
            };

            string outputPath = "output/merged.pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Image> images = new List<Image>();
            foreach (var path in epsPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                Image epsImage = Image.Load(path);
                images.Add(epsImage);
            }

            using (Image pdfDocument = Image.Create(images.ToArray(), true))
            {
                pdfDocument.Save(outputPath, new PdfOptions());
            }

            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. When a developer must batch‑convert a series of vector‑based EPS illustrations into a single PDF portfolio with page‑level bookmarks for easy navigation in client presentations.
 * 2. When an automated build pipeline needs to merge EPS logo assets from multiple design teams into one searchable PDF report using C# and Aspose.Imaging.
 * 3. When a web application offers users the ability to upload several EPS schematics and receive a consolidated PDF document with bookmarks for each schematic page.
 * 4. When a document‑management system has to archive engineering EPS drawings as a single PDF file, preserving each drawing as a separate bookmarked page for quick retrieval.
 * 5. When a marketing workflow requires combining EPS banner files into one PDF brochure, adding bookmarks so sales staff can jump directly to each product section.
 */