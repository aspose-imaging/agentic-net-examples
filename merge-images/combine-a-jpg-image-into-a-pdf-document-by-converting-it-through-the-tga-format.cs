using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputJpgPath = "input.jpg";
        string tempTgaPath = "temp.tga";
        string outputPdfPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputJpgPath))
        {
            Console.Error.WriteLine($"File not found: {inputJpgPath}");
            return;
        }

        // Ensure output directory exists (creates even if null)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load the JPG image
        using (RasterImage jpgImage = (RasterImage)Image.Load(inputJpgPath))
        {
            // Save as TGA using TgaOptions
            jpgImage.Save(tempTgaPath, new TgaOptions());
        }

        // Verify the intermediate TGA file was created
        if (!File.Exists(tempTgaPath))
        {
            Console.Error.WriteLine($"File not found: {tempTgaPath}");
            return;
        }

        // Load the TGA image
        using (RasterImage tgaImage = (RasterImage)Image.Load(tempTgaPath))
        {
            // Save as PDF (using PdfOptions – assumed to exist in Aspose.Imaging)
            tgaImage.Save(outputPdfPath, new PdfOptions());
        }

        // Optional cleanup of the temporary TGA file
        try
        {
            File.Delete(tempTgaPath);
        }
        catch
        {
            // Ignored – cleanup failure should not stop the program
        }
    }
}