using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputDirectory = @"C:\temp\output";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional as required)
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Prepare XMP metadata containing the source file path
            string xmpData = $"<x:xmpmeta xmlns:x='adobe:ns:meta/'><rdf:RDF xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#'><rdf:Description rdf:about='' xmlns:dc='http://purl.org/dc/elements/1.1/'><dc:source>{inputPath}</dc:source></rdf:Description></rdf:RDF></x:xmpmeta>";

            // Iterate through each page and save as PNG with XMP tag
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Embed XMP metadata into the page
                page.XmpData = xmpData;

                // Build output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"sample.{page.PageNumber}.png");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                page.Save(outputPath, new PngOptions());
            }
        }
    }
}