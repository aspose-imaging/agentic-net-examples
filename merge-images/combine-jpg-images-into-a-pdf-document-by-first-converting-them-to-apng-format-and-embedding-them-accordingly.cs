using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect: first argument = output PDF path, remaining arguments = input JPG files
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program output.pdf input1.jpg input2.jpg ...");
            return;
        }

        string outputPdfPath = args[0];
        List<string> jpgPaths = new List<string>();
        for (int i = 1; i < args.Length; i++)
        {
            jpgPaths.Add(args[i]);
        }

        // Convert each JPG to a temporary APNG file
        List<string> apngPaths = new List<string>();
        foreach (string jpgPath in jpgPaths)
        {
            string tempApngPath = Path.Combine(Path.GetTempPath(),
                Path.GetFileNameWithoutExtension(jpgPath) + ".apng");

            using (RasterImage sourceImage = (RasterImage)Image.Load(jpgPath))
            {
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(tempApngPath, false),
                    DefaultFrameTime = 500, // 500 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Ensure only one frame (the source image) is present
                    apngImage.RemoveAllFrames();
                    apngImage.AddFrame(sourceImage);
                    apngImage.Save(); // Saves to tempApngPath
                }
            }

            apngPaths.Add(tempApngPath);
        }

        // Create a multipage PDF from the APNG files
        using (Image pdfImage = Image.Create(apngPaths.ToArray()))
        {
            pdfImage.Save(outputPdfPath, new PdfOptions());
        }

        // Optional: clean up temporary APNG files
        foreach (string apngPath in apngPaths)
        {
            try
            {
                File.Delete(apngPath);
            }
            catch
            {
                // Ignore any errors during cleanup
            }
        }
    }
}