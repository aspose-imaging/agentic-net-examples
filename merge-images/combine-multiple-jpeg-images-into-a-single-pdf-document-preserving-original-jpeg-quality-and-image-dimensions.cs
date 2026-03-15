using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least one output path and one input JPEG file.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <output.pdf> <input1.jpg> [input2.jpg] ...");
            return;
        }

        string outputPdfPath = args[0];
        var inputJpegPaths = new List<string>();

        for (int i = 1; i < args.Length; i++)
        {
            inputJpegPaths.Add(args[i]);
        }

        // Load each JPEG image.
        var images = new List<Image>();
        foreach (string jpegPath in inputJpegPaths)
        {
            images.Add(Image.Load(jpegPath));
        }

        // Create a multipage image from the loaded JPEGs.
        // The 'true' flag disposes the source images after creation.
        using (Image pdfImage = Image.Create(images.ToArray(), true))
        {
            // Save the combined image as a PDF, preserving original quality and dimensions.
            pdfImage.Save(outputPdfPath, new PdfOptions());
        }
    }
}